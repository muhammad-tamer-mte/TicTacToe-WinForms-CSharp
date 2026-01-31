namespace Tic_Tac_Toe_Game
{
    partial class frmStart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPvsC = new System.Windows.Forms.RadioButton();
            this.rbPvsP = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tic-Tac-Toe Game";
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.Black;
            this.btnStartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGame.Font = new System.Drawing.Font("Sukar", 15F, System.Drawing.FontStyle.Bold);
            this.btnStartGame.ForeColor = System.Drawing.Color.Wheat;
            this.btnStartGame.Location = new System.Drawing.Point(125, 191);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(154, 47);
            this.btnStartGame.TabIndex = 2;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbPvsC);
            this.groupBox1.Controls.Add(this.rbPvsP);
            this.groupBox1.Font = new System.Drawing.Font("Sukar", 15F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(102, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode: ";
            // 
            // rbPvsC
            // 
            this.rbPvsC.AutoSize = true;
            this.rbPvsC.Cursor = System.Windows.Forms.Cursors.Cross;
            this.rbPvsC.Font = new System.Drawing.Font("Sukar", 12F, System.Drawing.FontStyle.Bold);
            this.rbPvsC.Location = new System.Drawing.Point(22, 61);
            this.rbPvsC.Name = "rbPvsC";
            this.rbPvsC.Size = new System.Drawing.Size(167, 31);
            this.rbPvsC.TabIndex = 1;
            this.rbPvsC.TabStop = true;
            this.rbPvsC.Text = "Player vs Computer";
            this.rbPvsC.UseVisualStyleBackColor = true;
            this.rbPvsC.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbPvsP
            // 
            this.rbPvsP.AutoSize = true;
            this.rbPvsP.Cursor = System.Windows.Forms.Cursors.Cross;
            this.rbPvsP.Font = new System.Drawing.Font("Sukar", 12F, System.Drawing.FontStyle.Bold);
            this.rbPvsP.Location = new System.Drawing.Point(22, 31);
            this.rbPvsP.Name = "rbPvsP";
            this.rbPvsP.Size = new System.Drawing.Size(139, 31);
            this.rbPvsP.TabIndex = 0;
            this.rbPvsP.TabStop = true;
            this.rbPvsP.Text = "Player vs Player";
            this.rbPvsP.UseVisualStyleBackColor = true;
            this.rbPvsP.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(406, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tic-Tac-Toe Game";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPvsC;
        private System.Windows.Forms.RadioButton rbPvsP;
    }
}

