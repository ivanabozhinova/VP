﻿namespace Game
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_pl3 = new System.Windows.Forms.Button();
            this.btn_pl2 = new System.Windows.Forms.Button();
            this.btn_pl1 = new System.Windows.Forms.Button();
            this.buttonCONTROLS = new System.Windows.Forms.Button();
            this.buttonNewGAME = new System.Windows.Forms.Button();
            this.buttonChoosePLAYER = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_pl3
            // 
            this.btn_pl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_pl3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pl3.Font = new System.Drawing.Font("Ravie", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pl3.Image = global::Game.Properties.Resources.pl3;
            this.btn_pl3.Location = new System.Drawing.Point(416, 194);
            this.btn_pl3.Name = "btn_pl3";
            this.btn_pl3.Size = new System.Drawing.Size(63, 58);
            this.btn_pl3.TabIndex = 5;
            this.btn_pl3.UseVisualStyleBackColor = false;
            // 
            // btn_pl2
            // 
            this.btn_pl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_pl2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pl2.Font = new System.Drawing.Font("Ravie", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pl2.Image = global::Game.Properties.Resources.pl2;
            this.btn_pl2.Location = new System.Drawing.Point(330, 193);
            this.btn_pl2.Name = "btn_pl2";
            this.btn_pl2.Size = new System.Drawing.Size(63, 58);
            this.btn_pl2.TabIndex = 4;
            this.btn_pl2.UseVisualStyleBackColor = false;
            // 
            // btn_pl1
            // 
            this.btn_pl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_pl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pl1.Font = new System.Drawing.Font("Ravie", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pl1.Image = global::Game.Properties.Resources.pl1;
            this.btn_pl1.Location = new System.Drawing.Point(245, 193);
            this.btn_pl1.Name = "btn_pl1";
            this.btn_pl1.Size = new System.Drawing.Size(63, 58);
            this.btn_pl1.TabIndex = 3;
            this.btn_pl1.UseVisualStyleBackColor = false;
            // 
            // buttonCONTROLS
            // 
            this.buttonCONTROLS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCONTROLS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCONTROLS.Font = new System.Drawing.Font("Ravie", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCONTROLS.Image = global::Game.Properties.Resources.instructions;
            this.buttonCONTROLS.Location = new System.Drawing.Point(405, 268);
            this.buttonCONTROLS.Name = "buttonCONTROLS";
            this.buttonCONTROLS.Size = new System.Drawing.Size(262, 58);
            this.buttonCONTROLS.TabIndex = 2;
            this.buttonCONTROLS.UseVisualStyleBackColor = false;
            // 
            // buttonNewGAME
            // 
            this.buttonNewGAME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonNewGAME.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewGAME.Font = new System.Drawing.Font("Ravie", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGAME.Image = global::Game.Properties.Resources.newGame;
            this.buttonNewGAME.Location = new System.Drawing.Point(37, 268);
            this.buttonNewGAME.Name = "buttonNewGAME";
            this.buttonNewGAME.Size = new System.Drawing.Size(233, 58);
            this.buttonNewGAME.TabIndex = 1;
            this.buttonNewGAME.UseVisualStyleBackColor = false;
            this.buttonNewGAME.Click += new System.EventHandler(this.buttonNewGAME_Click);
            // 
            // buttonChoosePLAYER
            // 
            this.buttonChoosePLAYER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonChoosePLAYER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonChoosePLAYER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChoosePLAYER.Font = new System.Drawing.Font("Ravie", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChoosePLAYER.Image = global::Game.Properties.Resources.player;
            this.buttonChoosePLAYER.Location = new System.Drawing.Point(244, 337);
            this.buttonChoosePLAYER.Name = "buttonChoosePLAYER";
            this.buttonChoosePLAYER.Size = new System.Drawing.Size(196, 96);
            this.buttonChoosePLAYER.TabIndex = 0;
            this.buttonChoosePLAYER.UseVisualStyleBackColor = false;
            this.buttonChoosePLAYER.Click += new System.EventHandler(this.buttonChoosePLAYER_Click);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font = new System.Drawing.Font("Ravie", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Image = global::Game.Properties.Resources.back;
            this.btn_back.Location = new System.Drawing.Point(12, 375);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(139, 58);
            this.btn_back.TabIndex = 6;
            this.btn_back.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 445);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_pl3);
            this.Controls.Add(this.btn_pl2);
            this.Controls.Add(this.btn_pl1);
            this.Controls.Add(this.buttonCONTROLS);
            this.Controls.Add(this.buttonNewGAME);
            this.Controls.Add(this.buttonChoosePLAYER);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonChoosePLAYER;
        private System.Windows.Forms.Button buttonNewGAME;
        private System.Windows.Forms.Button buttonCONTROLS;
        private System.Windows.Forms.Button btn_pl1;
        private System.Windows.Forms.Button btn_pl2;
        private System.Windows.Forms.Button btn_pl3;
        private System.Windows.Forms.Button btn_back;
    }
}

