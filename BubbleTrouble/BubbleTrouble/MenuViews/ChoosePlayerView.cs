using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BubbleTrouble.Properties;

namespace BubbleTrouble
{
    public class ChoosePlayerView :View
    {
        public Image firstPlayerImg { set; get; }
        public Image secondPlayerImg { set; get; }
        public Image thirdPlayerImg { set; get; }
        public Image backImg { set; get; }
        public ChoosePlayerView()
            : base(Resources.choose)
        {
            this.firstPlayerImg = Resources.pl1;
            this.secondPlayerImg = Resources.pl2;
            this.thirdPlayerImg = Resources.pl3;
            this.backImg = Resources.back;
        }

        public System.Windows.Forms.Button enableChoosePlayerView_BACK_Button(System.Windows.Forms.Button button_BACK)
        {
            button_BACK.Image = this.backImg;
            button_BACK.Size = new Size(this.backImg.Width, this.backImg.Height);
            button_BACK.Location = new Point(12, 410);
            button_BACK.Visible = true;
            button_BACK.Enabled = true;
            return button_BACK;
        }
        public System.Windows.Forms.Button disableChoosePlayerView_BACK_Button(System.Windows.Forms.Button button_BACK)
        {
            button_BACK.Visible = false;
            button_BACK.Enabled = false;
            return button_BACK;
        }
        //palyer 1
        public System.Windows.Forms.Button enableChoosePlayerView_player1_Button(System.Windows.Forms.Button button_player1)
        {
            button_player1.Image = this.firstPlayerImg;
            button_player1.Size = new Size(this.firstPlayerImg.Width, this.firstPlayerImg.Height);
            button_player1.Location = new Point(192, 399);
            button_player1.Visible = true;
            button_player1.Enabled = true;
            return button_player1;
        }
        public System.Windows.Forms.Button disableChoosePlayerView_player1_Button(System.Windows.Forms.Button button_player1)
        {
            button_player1.Visible = false;
            button_player1.Enabled = false;
            return button_player1;
        }
        //Player 2
        public System.Windows.Forms.Button enableChoosePlayerView_player2_Button(System.Windows.Forms.Button button_player2)
        {
            button_player2.Image = this.secondPlayerImg;
            button_player2.Size = new Size(this.secondPlayerImg.Width, this.secondPlayerImg.Height);
            button_player2.Location = new Point(309, 399);
            button_player2.Visible = true;
            button_player2.Enabled = true;
            return button_player2;
        }
        public System.Windows.Forms.Button disableChoosePlayerView_player2_Button(System.Windows.Forms.Button button_player2)
        {
            button_player2.Visible = false;
            button_player2.Enabled = false;
            return button_player2;
        }

        //player 3
        public System.Windows.Forms.Button enableChoosePlayerView_player3_Button(System.Windows.Forms.Button button_player3)
        {
            button_player3.Image = this.thirdPlayerImg;
            button_player3.Size = new Size(this.thirdPlayerImg.Width, this.thirdPlayerImg.Height);
            button_player3.Location = new Point(446, 399);
            button_player3.Visible = true;
            button_player3.Enabled = true;
            return button_player3;
        }
        public System.Windows.Forms.Button disableChoosePlayerView_player3_Button(System.Windows.Forms.Button button_player3)
        {
            button_player3.Visible = false;
            button_player3.Enabled = false;
            return button_player3;
        }

        public  override void drawView(Graphics g, Rectangle ClientRectangle)
        {
            g.DrawImage(this.backgroundImg, ClientRectangle);
        }




    }
}
