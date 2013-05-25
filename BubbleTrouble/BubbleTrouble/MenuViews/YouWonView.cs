using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BubbleTrouble.Properties;

namespace BubbleTrouble.MenuViews
{
    class YouWonView: View
    {
        public Image mainMenuImg { set; get; }
        public Image quitImg { set; get; }

         public YouWonView()
            : base(Resources.youWon)
        {
            this.mainMenuImg = Resources.mainMenu;
            this.quitImg = Resources.QUIT;           
        }

         public System.Windows.Forms.Button enableScoreView_BACK_Button( System.Windows.Forms.Button button_BACK)
         {
             button_BACK.Image = this.mainMenuImg;
             button_BACK.Size = new Size(this.mainMenuImg.Width, this.mainMenuImg.Height);
             button_BACK.Location = new Point(95, 312);
             button_BACK.Visible = true;
             button_BACK.Enabled = true;
             return button_BACK;
         }

         public System.Windows.Forms.Button enableScoreView_QUIT_Button(System.Windows.Forms.Button button_QUITGame)
         {
             button_QUITGame.Visible = true;
             button_QUITGame.Enabled = true;
             button_QUITGame.Size = new Size(Resources.QUIT.Width, Resources.QUIT.Height);
             button_QUITGame.Image = Resources.QUIT;
             button_QUITGame.Location = new Point(502, 312);
             return button_QUITGame;
         }

         public System.Windows.Forms.Button disableScoreView_BACK_Button(System.Windows.Forms.Button button_BACK)
         {
             button_BACK.Visible = false;
             button_BACK.Enabled = false;
             return button_BACK;
         }

         public System.Windows.Forms.Button disableScoreView_QUIT_Button(System.Windows.Forms.Button button_QUITGame)
         {
             button_QUITGame.Visible = false;
             button_QUITGame.Enabled = false;
             return button_QUITGame;
         }

         public override void drawView(Graphics g, Rectangle ClientRectangle)
         {
             g.DrawImage(this.backgroundImg, ClientRectangle);
         }
    }
}
