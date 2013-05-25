namespace BubbleTrouble
{
    partial class Game
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
            this.button_BACK = new System.Windows.Forms.Button();
            this.button_QUITGame = new System.Windows.Forms.Button();
            this.button_NewGAME = new System.Windows.Forms.Button();
            this.button_choosePLAYER = new System.Windows.Forms.Button();
            this.button_INSTRCTIONS = new System.Windows.Forms.Button();
            this.button_player1 = new System.Windows.Forms.Button();
            this.button_player2 = new System.Windows.Forms.Button();
            this.button_player3 = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.finScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_BACK
            // 
            this.button_BACK.Enabled = false;
            this.button_BACK.Location = new System.Drawing.Point(71, 91);
            this.button_BACK.Name = "button_BACK";
            this.button_BACK.Size = new System.Drawing.Size(75, 23);
            this.button_BACK.TabIndex = 0;
            this.button_BACK.UseVisualStyleBackColor = true;
            this.button_BACK.Visible = false;
            this.button_BACK.Click += new System.EventHandler(this.button_BACK_Click);
            // 
            // button_QUITGame
            // 
            this.button_QUITGame.Enabled = false;
            this.button_QUITGame.Location = new System.Drawing.Point(199, 121);
            this.button_QUITGame.Name = "button_QUITGame";
            this.button_QUITGame.Size = new System.Drawing.Size(75, 23);
            this.button_QUITGame.TabIndex = 1;
            this.button_QUITGame.UseVisualStyleBackColor = true;
            this.button_QUITGame.Visible = false;
            this.button_QUITGame.Click += new System.EventHandler(this.button_QUITGame_Click);
            // 
            // button_NewGAME
            // 
            this.button_NewGAME.Enabled = false;
            this.button_NewGAME.Location = new System.Drawing.Point(105, 120);
            this.button_NewGAME.Name = "button_NewGAME";
            this.button_NewGAME.Size = new System.Drawing.Size(75, 23);
            this.button_NewGAME.TabIndex = 2;
            this.button_NewGAME.UseVisualStyleBackColor = true;
            this.button_NewGAME.Visible = false;
            this.button_NewGAME.Click += new System.EventHandler(this.button_NewGAME_Click);
            // 
            // button_choosePLAYER
            // 
            this.button_choosePLAYER.Enabled = false;
            this.button_choosePLAYER.Location = new System.Drawing.Point(166, 173);
            this.button_choosePLAYER.Name = "button_choosePLAYER";
            this.button_choosePLAYER.Size = new System.Drawing.Size(75, 23);
            this.button_choosePLAYER.TabIndex = 3;
            this.button_choosePLAYER.UseVisualStyleBackColor = true;
            this.button_choosePLAYER.Visible = false;
            this.button_choosePLAYER.Click += new System.EventHandler(this.button_choosePLAYER_Click);
            // 
            // button_INSTRCTIONS
            // 
            this.button_INSTRCTIONS.Enabled = false;
            this.button_INSTRCTIONS.Location = new System.Drawing.Point(71, 199);
            this.button_INSTRCTIONS.Name = "button_INSTRCTIONS";
            this.button_INSTRCTIONS.Size = new System.Drawing.Size(75, 23);
            this.button_INSTRCTIONS.TabIndex = 4;
            this.button_INSTRCTIONS.UseVisualStyleBackColor = true;
            this.button_INSTRCTIONS.Visible = false;
            this.button_INSTRCTIONS.Click += new System.EventHandler(this.button_INSTRCTIONS_Click);
            // 
            // button_player1
            // 
            this.button_player1.Enabled = false;
            this.button_player1.Location = new System.Drawing.Point(209, 54);
            this.button_player1.Name = "button_player1";
            this.button_player1.Size = new System.Drawing.Size(75, 23);
            this.button_player1.TabIndex = 5;
            this.button_player1.UseVisualStyleBackColor = true;
            this.button_player1.Visible = false;
            this.button_player1.Click += new System.EventHandler(this.button_player1_Click);
            // 
            // button_player2
            // 
            this.button_player2.Enabled = false;
            this.button_player2.Location = new System.Drawing.Point(105, 13);
            this.button_player2.Name = "button_player2";
            this.button_player2.Size = new System.Drawing.Size(75, 23);
            this.button_player2.TabIndex = 6;
            this.button_player2.UseVisualStyleBackColor = true;
            this.button_player2.Visible = false;
            this.button_player2.Click += new System.EventHandler(this.button_player2_Click);
            // 
            // button_player3
            // 
            this.button_player3.Enabled = false;
            this.button_player3.Location = new System.Drawing.Point(139, 54);
            this.button_player3.Name = "button_player3";
            this.button_player3.Size = new System.Drawing.Size(75, 23);
            this.button_player3.TabIndex = 7;
            this.button_player3.UseVisualStyleBackColor = true;
            this.button_player3.Visible = false;
            this.button_player3.Click += new System.EventHandler(this.button_player3_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Ravie", 11.25F);
            this.lblScore.Location = new System.Drawing.Point(195, 440);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 21);
            this.lblScore.TabIndex = 8;
            this.lblScore.Visible = false;
            // 
            // finScore
            // 
            this.finScore.AutoSize = true;
            this.finScore.Font = new System.Drawing.Font("Ravie", 11.25F);
            this.finScore.Location = new System.Drawing.Point(488, 244);
            this.finScore.Name = "finScore";
            this.finScore.Size = new System.Drawing.Size(0, 21);
            this.finScore.TabIndex = 9;
            this.finScore.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.finScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.button_player3);
            this.Controls.Add(this.button_player2);
            this.Controls.Add(this.button_player1);
            this.Controls.Add(this.button_INSTRCTIONS);
            this.Controls.Add(this.button_choosePLAYER);
            this.Controls.Add(this.button_NewGAME);
            this.Controls.Add(this.button_QUITGame);
            this.Controls.Add(this.button_BACK);
            this.Name = "Game";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_BACK;
        private System.Windows.Forms.Button button_QUITGame;
        private System.Windows.Forms.Button button_NewGAME;
        private System.Windows.Forms.Button button_choosePLAYER;
        private System.Windows.Forms.Button button_INSTRCTIONS;
        private System.Windows.Forms.Button button_player1;
        private System.Windows.Forms.Button button_player2;
        private System.Windows.Forms.Button button_player3;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label finScore;
    }
}

