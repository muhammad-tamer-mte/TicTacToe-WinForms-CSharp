using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class frmStart : Form
    {
        #region Constants

        Point DEFAULT_SIZE = new Point(422, 300);
        const string PLAYER_ONE_PLACEHOLDER = "First player name";
        const string PLAYER_TWO_PLACEHOLDER = "Second player name";
        const string YOUR_NAME_PLACEHOLDER = "Enter your name";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes the start form and sets up the UI.
        /// </summary>
        public frmStart()
        {
            InitializeComponent();
        }

        #endregion

        #region Style Events

        /// <summary>
        /// Handles the Enter event for TextBox controls.
        /// Clears the placeholder text when the user focuses the textbox.
        /// </summary>
        /// <param name="sender">The TextBox control that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == (string)tb.Tag)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Handles the Leave event for TextBox controls.
        /// Restores placeholder text if the TextBox is empty.
        /// </summary>
        /// <param name="sender">The TextBox control that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = (string)tb.Tag;
                tb.ForeColor = Color.Gray;
            }
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Dynamically adds a TextBox control to the form.
        /// </summary>
        /// <param name="name">The name to assign to the TextBox.</param>
        /// <param name="width">The width of the TextBox.</param>
        /// <param name="location">The location of the TextBox on the form.</param>
        /// <param name="placeholder">The placeholder text displayed in the TextBox.</param>
        private void addTextBox(string name, short width, Point location, string placeholder)
        {
            TextBox tb = new TextBox();
            tb.Name = name;
            tb.Width = width;
            tb.Location = location;
            tb.Text = placeholder;
            tb.Tag = placeholder;
            tb.ForeColor = Color.Gray;
            tb.Enter += TextBox_Enter;
            tb.Leave += TextBox_Leave;
            this.Controls.Add(tb);
        }

        /// <summary>
        /// Dynamically adds a ComboBox for character selection (X/O) to the form.
        /// </summary>
        /// <param name="name">The name to assign to the ComboBox.</param>
        private void addComboBox(string name)
        {
            ComboBox cb = new ComboBox();
            cb.Name = name;
            cb.Location = new Point(groupBox1.Location.X + groupBox1.Width + 5, groupBox1.Location.Y + groupBox1.Height + 10);
            cb.Width = 32;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Items.Add("X");
            cb.Items.Add("O");
            cb.SelectedIndex = 0;
            this.Controls.Add(cb);
        }

        /// <summary>
        /// Removes previously added dynamic controls (TextBoxes and ComboBox) from the form.
        /// </summary>
        private void removePreviousControls()
        {
            Control cb;
            if ((cb = this.Controls["comboBoxXO"]) != null)
            {
                this.Controls.Remove(cb);
            }

            Control tb1;
            if ((tb1 = this.Controls["tbName1"]) != null)
            {
                this.Controls.Remove(tb1);
            }

            Control tb2;
            if ((tb2 = this.Controls["tbName2"]) != null)
            {
                this.Controls.Remove(tb2);
            }
        }

        #endregion

        #region Main Events

        /// <summary>
        /// Handles radio button checked changes to update the form dynamically
        /// based on the selected game mode (PvP or PvC).
        /// </summary>
        /// <param name="sender">The RadioButton that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            removePreviousControls();

            if (rbPvsP.Checked)
            {
                // Resize form
                this.Size = new Size(this.Size.Width, 360);

                // Add controls
                addTextBox("tbName1", (short)groupBox1.Width, new Point(groupBox1.Location.X, groupBox1.Location.Y + groupBox1.Height + 10), PLAYER_ONE_PLACEHOLDER);
                addTextBox("tbName2", (short)groupBox1.Width, new Point(groupBox1.Location.X, groupBox1.Location.Y + groupBox1.Height + 40), PLAYER_TWO_PLACEHOLDER);
                addComboBox("comboBoxXO");
                ((TextBox)this.Controls["tbName1"]).Focus();

                // Change button location
                btnStartGame.Location = new Point(125, groupBox1.Location.Y + groupBox1.Height + 75);
                return;
            }
            else if (rbPvsC.Checked)
            {
                // Resize form
                this.Size = new Size(this.Size.Width, 330);

                // Add controls
                addTextBox("tbName1", (short)groupBox1.Width, new Point(groupBox1.Location.X, groupBox1.Location.Y + groupBox1.Height + 10), YOUR_NAME_PLACEHOLDER);
                addComboBox("comboBoxXO");
                ((TextBox)this.Controls["tbName1"]).Focus();

                // Change button location
                btnStartGame.Location = new Point(125, groupBox1.Location.Y + groupBox1.Height + 40);
                return;
            }
            else
            {
                this.Size = (Size)DEFAULT_SIZE;
            }
        }

        /// <summary>
        /// Handles the Start Game button click.
        /// Validates inputs, initializes game info, and opens the game form.
        /// </summary>
        /// <param name="sender">The Button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (!rbPvsP.Checked && !rbPvsC.Checked)
            {
                MessageBox.Show("Choose a mode to enter!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // initialize game info
            frmGame.stGameInfo _gameInfo = new frmGame.stGameInfo();

            // get controls
            TextBox tb1 = (TextBox)this.Controls["tbName1"];
            TextBox tb2 = (TextBox)this.Controls["tbName2"];
            ComboBox cb = (ComboBox)this.Controls["comboBoxXO"];

            // Check first player
            if (tb1.Text == (string)tb1.Tag)
            {
                MessageBox.Show("Please enter player name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set first player
            _gameInfo.playerOne = new frmGame.stPlayer
            {
                name = tb1.Text,
                type = frmGame.enPlayer.ePlayerOne,
                charChoice = (cb.SelectedItem.ToString() == "X") ? frmGame.enGameChoice.X : frmGame.enGameChoice.O
            };

            if (rbPvsP.Checked)
            {
                // Check second player
                if (tb2.Text == (string)tb2.Tag)
                {
                    MessageBox.Show("Please enter second player name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Set second player
                _gameInfo.playerTwo = new frmGame.stPlayer
                {
                    name = tb2.Text,
                    type = frmGame.enPlayer.ePlayerTwo,
                    charChoice = (_gameInfo.playerOne.charChoice == frmGame.enGameChoice.X) ? frmGame.enGameChoice.O : frmGame.enGameChoice.X
                };
            }
            else if (rbPvsC.Checked)
            {
                _gameInfo.playerTwo = new frmGame.stPlayer
                {
                    name = "Computer",
                    type = frmGame.enPlayer.eComputer,
                    charChoice = (_gameInfo.playerOne.charChoice == frmGame.enGameChoice.X) ? frmGame.enGameChoice.O : frmGame.enGameChoice.X
                };
            }

            // defaulting game info
            _gameInfo.playerTurn = frmGame.enPlayer.ePlayerOne;
            _gameInfo.playedClicks = 0;
            _gameInfo.gameOver = false;

            // start game
            this.Hide();
            (new frmGame(_gameInfo)).Show();
        }

        #endregion
    }
}
