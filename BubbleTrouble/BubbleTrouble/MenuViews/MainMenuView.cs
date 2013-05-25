using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BubbleTrouble.Properties;

namespace BubbleTrouble
{
     public class MainMenuView:View
    {
        public Image newGameImg { set; get; }
        public Image choosePlayerImg { set; get; }
        public Image instructionsImg { set; get; }

        public MainMenuView()
            : base(Resources.start)
        {
            
            this.newGameImg=Resources.newGame;
            this.choosePlayerImg=Resources.player;
            this.instructionsImg = Resources.instructions;
        }


        public System.Windows.Forms.Button enableMainMenuView_newGAME_Button(System.Windows.Forms.Button button_NewGAME)
        {
            button_NewGAME.Image = this.newGameImg;
            button_NewGAME.Size = new Size(this.newGameImg.Width, this.newGameImg.Height);
            button_NewGAME.Location = new Point(41, 268);
            button_NewGAME.Visible = true;
            button_NewGAME.Enabled = true;
            return button_NewGAME;
        }
        public System.Windows.Forms.Button enableMainMenuView_choosePLAYER_Button(System.Windows.Forms.Button button_choosePLAYER)
        {
            button_choosePLAYER.Image = this.choosePlayerImg;
            button_choosePLAYER.Size = new Size(this.choosePlayerImg.Width, this.choosePlayerImg.Height);
            button_choosePLAYER.Location = new Point(244, 337);
            button_choosePLAYER.Visible = true;
            button_choosePLAYER.Enabled = true;
            return button_choosePLAYER;
        }
        public System.Windows.Forms.Button enableMainMenuView_INSTRCTIONS_Button(System.Windows.Forms.Button button_INSTRCTIONS)
        {
            button_INSTRCTIONS.Image = this.instructionsImg;
            button_INSTRCTIONS.Size = new Size(this.instructionsImg.Width, this.instructionsImg.Height);
            button_INSTRCTIONS.Location = new Point(405, 268);
            button_INSTRCTIONS.Visible = true;
            button_INSTRCTIONS.Enabled = true;
            return button_INSTRCTIONS;
        }

        public System.Windows.Forms.Button disableMainMenuView_newGAME_Button(System.Windows.Forms.Button button_NewGAME)
        {
            
            button_NewGAME.Visible = false;
            button_NewGAME.Enabled = false;
            return button_NewGAME;
        }
        public System.Windows.Forms.Button disableMainMenuView_choosePLAYER_Button(System.Windows.Forms.Button button_choosePLAYER)
        {

            button_choosePLAYER.Visible = false;
            button_choosePLAYER.Enabled = false;
            return button_choosePLAYER;
        }
        public System.Windows.Forms.Button disableMainMenuView_INSTRCTIONS_Button(System.Windows.Forms.Button button_INSTRCTIONS)
        {

            button_INSTRCTIONS.Visible = false;
            button_INSTRCTIONS.Enabled = false;
            return button_INSTRCTIONS;
        }

        public override void drawView(Graphics g, Rectangle ClientRectangle)
        {
            g.DrawImage(this.backgroundImg, ClientRectangle);
        }
    }
}
