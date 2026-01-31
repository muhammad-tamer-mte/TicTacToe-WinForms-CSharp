using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class frmGame : Form
    {
        #region Enums

        /// <summary>Represents the type of player in the game.</summary>
        public enum enPlayer
        {
            eComputer = 0,
            ePlayerOne = 1,
            ePlayerTwo = 2,
        };

        /// <summary>Represents the character choice for a player.</summary>
        public enum enGameChoice
        {
            X,
            O,
            QuestionMark
        };

        /// <summary>Represents possible game results.</summary>
        enum enGameResult
        {
            eWinner,
            eDraw
        };

        #endregion

        #region Structures

        /// <summary>Stores information about a player.</summary>
        public struct stPlayer
        {
            /// <summary>Player's name.</summary>
            public string name;

            /// <summary>Player type (human or computer).</summary>
            public enPlayer type;

            /// <summary>Player's chosen character.</summary>
            public enGameChoice charChoice;
        }

        /// <summary>Stores the state of the game.</summary>
        public struct stGameInfo
        {
            /// <summary>Player one info.</summary>
            public stPlayer playerOne;

            /// <summary>Player two info.</summary>
            public stPlayer playerTwo;

            /// <summary>Indicates whose turn it is.</summary>
            public enPlayer playerTurn;

            /// <summary>Number of clicks made so far.</summary>
            public byte playedClicks;

            /// <summary>Indicates whether the game is over.</summary>
            public bool gameOver;
        };

        #endregion

        #region Fields

        /// <summary>Main game information instance.</summary>
        stGameInfo _gameInfo = new stGameInfo();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes the game form with the given game info.
        /// </summary>
        /// <param name="gameInfo">The game state and players.</param>
        public frmGame(stGameInfo gameInfo)
        {
            InitializeComponent();
            _gameInfo = gameInfo;
            lblTurn.Text = _gameInfo.playerOne.name;
            gameInfo.playerTurn = enPlayer.ePlayerOne;

            // Manually subscribe to the FormClosing event
            this.FormClosing += new FormClosingEventHandler(frmGame_FormClosing);
        }

        /// <summary>Handles form closing and exits the application.</summary>
        private void frmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Helpers

        /// <summary>Draws the game board grid lines.</summary>
        private void frmPaint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Brushes.White, 6);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 400, 150, 850, 150);
            e.Graphics.DrawLine(pen, 400, 250, 850, 250);
            e.Graphics.DrawLine(pen, 550, 50, 550, 350);
            e.Graphics.DrawLine(pen, 700, 50, 700, 350);
        }

        /// <summary>Disables all clickable picture boxes.</summary>
        private void lockChoices(Panel pa)
        {
            for (byte i = 1; i <= 9; i++)
            {
                (this.Controls[$"pb{i}"]).Enabled = false;
            }
        }

        /// <summary>Enables all clickable picture boxes.</summary>
        private void unlockChoices()
        {
            for (byte i = 1; i <= 9; i++)
            {
                (this.Controls[$"pb{i}"]).Enabled = true;
            }
        }

        /// <summary>Gets the enGameChoice value from a picture box's Tag.</summary>
        private enGameChoice getPbTag(object sender)
        {
            string pbTag = (string)((PictureBox)sender).Tag;
            return (pbTag == "X") ? enGameChoice.X : (pbTag == "O" ? enGameChoice.O : enGameChoice.QuestionMark);
        }

        /// <summary>Checks if a picture box is already chosen.</summary>
        private bool isPbChosen(enGameChoice value)
        {
            return (value == enGameChoice.X || value == enGameChoice.O);
        }

        /// <summary>Highlights winning picture boxes.</summary>
        private void highlightCohices(PictureBox pb1, PictureBox pb2, PictureBox pb3)
        {
            pb1.BackColor = Color.YellowGreen;
            pb2.BackColor = Color.YellowGreen;
            pb3.BackColor = Color.YellowGreen;
        }

        /// <summary>Sets the image of a picture box according to the player's choice.</summary>
        private void setImage(PictureBox pb, stPlayer player)
        {
            switch (player.charChoice)
            {
                case (enGameChoice.X):
                    pb.Image = Properties.Resources.X;
                    break;
                case (enGameChoice.O):
                    pb.Image = Properties.Resources.O;
                    break;
            }
        }

        #endregion

        #region Game Logic

        /// <summary>Checks if three picture boxes have matching choices.</summary>
        private bool areThreeMatched(PictureBox pb1, PictureBox pb2, PictureBox pb3)
        {
            return (getPbTag(pb1) == getPbTag(pb2) && getPbTag(pb2) == getPbTag(pb3) && isPbChosen(getPbTag(pb3)));
        }

        /// <summary>Checks for a winner or draw.</summary>
        private bool checkWinner()
        {
            if (_gameInfo.playedClicks < 5) return false;

            if (_gameInfo.playedClicks == 9) { gameOver(pb1, pb2, pb3, enGameResult.eDraw); return true; }

            if (areThreeMatched(pb1, pb2, pb3)) { gameOver(pb1, pb2, pb3, enGameResult.eWinner); return true; }
            if (areThreeMatched(pb4, pb5, pb6)) { gameOver(pb4, pb5, pb6, enGameResult.eWinner); return true; }
            if (areThreeMatched(pb7, pb8, pb9)) { gameOver(pb7, pb8, pb9, enGameResult.eWinner); return true; }

            if (areThreeMatched(pb1, pb4, pb7)) { gameOver(pb1, pb4, pb7, enGameResult.eWinner); return true; }
            if (areThreeMatched(pb2, pb5, pb8)) { gameOver(pb2, pb5, pb8, enGameResult.eWinner); return true; }
            if (areThreeMatched(pb3, pb6, pb9)) { gameOver(pb3, pb6, pb9, enGameResult.eWinner); return true; }

            if (areThreeMatched(pb1, pb5, pb9)) { gameOver(pb1, pb5, pb9, enGameResult.eWinner); return true; }
            if (areThreeMatched(pb3, pb5, pb7)) { gameOver(pb3, pb5, pb7, enGameResult.eWinner); return true; }

            return false;
        }

        /// <summary>Handles the end of the game and highlights winner or draw.</summary>
        private void gameOver(PictureBox pb1, PictureBox pb2, PictureBox pb3, enGameResult result = enGameResult.eWinner)
        {
            switch (result)
            {
                case (enGameResult.eDraw):
                    lblWinner.Text = "Draw";
                    lblWinner.ForeColor = Color.Red;
                    break;
                case (enGameResult.eWinner):
                    highlightCohices(pb1, pb2, pb3);
                    lblWinner.Text = lblTurn.Text;
                    lblWinner.ForeColor = Color.YellowGreen;
                    break;
            }
            _gameInfo.gameOver = true;
            lblTurn.Text = "Game Over!";
            MessageBox.Show("Game Over!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Updates the game board when a player clicks a picture box.</summary>
        private void updateChoice(object sender)
        {
            if (_gameInfo.gameOver) return;

            PictureBox pb = (PictureBox)sender;
            enGameChoice pbTag = getPbTag(pb);
            if (isPbChosen(pbTag))
            {
                MessageBox.Show("It's already chosen, Choose another one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (_gameInfo.playerTurn)
            {
                case (enPlayer.ePlayerOne):
                    pb.Tag = _gameInfo.playerOne.charChoice.ToString();
                    setImage(pb, _gameInfo.playerOne);
                    _gameInfo.playedClicks += 1;
                    if (!checkWinner())
                    {
                        lblTurn.Text = _gameInfo.playerTwo.name;
                        _gameInfo.playerTurn = enPlayer.ePlayerTwo;
                    }
                    break;
                case (enPlayer.ePlayerTwo):
                    pb.Tag = _gameInfo.playerTwo.charChoice.ToString();
                    setImage(pb, _gameInfo.playerTwo);
                    _gameInfo.playedClicks += 1;
                    if (!checkWinner())
                    {
                        lblTurn.Text = _gameInfo.playerOne.name;
                        _gameInfo.playerTurn = enPlayer.ePlayerOne;
                    }
                    break;
            }
        }

        /// <summary>Handles the computer's turn using random moves.</summary>
        async private void computerTurn()
        {
            if (_gameInfo.playerTwo.type == enPlayer.eComputer && _gameInfo.playerTurn == enPlayer.ePlayerTwo)
            {
                lockChoices(panel);

                for (byte i = 0, end = (byte)(new Random()).Next(1, 6); i < end; i++)
                {
                    await Task.Delay(30); lblTurn.Text += ".";
                    await Task.Delay(50); lblTurn.Text += ".";
                    await Task.Delay(70); lblTurn.Text += ".";
                    await Task.Delay(100); lblTurn.Text = lblTurn.Text.Substring(0, lblTurn.Text.Length - 3);
                }

                byte computerChoice = 0;
                do
                {
                    computerChoice = (byte)(new Random()).Next(1, 10);
                }
                while (isPbChosen(getPbTag(this.Controls[$"pb{computerChoice}"])));

                updateChoice(this.Controls[$"pb{computerChoice}"]);

                unlockChoices();
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>Handles the Back label click to return to the start form.</summary>
        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
            (new frmStart()).Show();
        }

        /// <summary>Changes Back label appearance on mouse enter.</summary>
        private void lblBack_MouseEnter(object sender, EventArgs e)
        {
            lblBack.BackColor = Color.Wheat;
            lblBack.ForeColor = Color.Black;
        }

        /// <summary>Resets Back label appearance on mouse leave.</summary>
        private void lblBack_MouseLeave(object sender, EventArgs e)
        {
            lblBack.BackColor = Color.Black;
            lblBack.ForeColor = Color.Wheat;
        }

        /// <summary>Resets the game when the Reset button is clicked.</summary>
        private void btnResetGame_Click(object sender, EventArgs e)
        {
            this.Dispose();
            _gameInfo.playedClicks = 0;
            _gameInfo.gameOver = false;
            (new frmGame(_gameInfo)).Show();
        }

        /// <summary>Handles a picture box click event.</summary>
        private void pb_Click(object sender, EventArgs e)
        {
            updateChoice(sender);
            if (_gameInfo.playerTwo.type == enPlayer.eComputer) computerTurn();
        }

        #endregion
    }
}
