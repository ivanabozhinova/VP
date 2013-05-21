namespace Game
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
            this.buttonChoosePLAYER = new System.Windows.Forms.Button();
            this.buttonNewGAME = new System.Windows.Forms.Button();
            this.buttonCONTROLS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonChoosePLAYER
            // 
            this.buttonChoosePLAYER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonChoosePLAYER.Font = new System.Drawing.Font("Ravie", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChoosePLAYER.Location = new System.Drawing.Point(31, 24);
            this.buttonChoosePLAYER.Name = "buttonChoosePLAYER";
            this.buttonChoosePLAYER.Size = new System.Drawing.Size(102, 118);
            this.buttonChoosePLAYER.TabIndex = 0;
            this.buttonChoosePLAYER.Text = "CHOOSE A PLAYER";
            this.buttonChoosePLAYER.UseVisualStyleBackColor = false;
            // 
            // buttonNewGAME
            // 
            this.buttonNewGAME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonNewGAME.Font = new System.Drawing.Font("Ravie", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGAME.Location = new System.Drawing.Point(355, 146);
            this.buttonNewGAME.Name = "buttonNewGAME";
            this.buttonNewGAME.Size = new System.Drawing.Size(109, 120);
            this.buttonNewGAME.TabIndex = 1;
            this.buttonNewGAME.Text = "START NEW GAME";
            this.buttonNewGAME.UseVisualStyleBackColor = false;
            this.buttonNewGAME.Click += new System.EventHandler(this.buttonNewGAME_Click);
            // 
            // buttonCONTROLS
            // 
            this.buttonCONTROLS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCONTROLS.Font = new System.Drawing.Font("Ravie", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCONTROLS.Location = new System.Drawing.Point(468, 40);
            this.buttonCONTROLS.Name = "buttonCONTROLS";
            this.buttonCONTROLS.Size = new System.Drawing.Size(101, 100);
            this.buttonCONTROLS.TabIndex = 2;
            this.buttonCONTROLS.Text = "CONTROLS";
            this.buttonCONTROLS.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 431);
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
    }
}

