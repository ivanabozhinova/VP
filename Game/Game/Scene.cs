using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Game.Properties;

namespace BubbleTrouble
{
    public class Scene
    {
        private static readonly int TIME = 120;

        public int numLifes { set; get; }
        public float score { set; get; }
        public Image backgroundImg { set; get; }
        public Image lifeImg { set; get; }
        public Image infoBarImg { set; get; }
        public int level { set; get; }




        public Scene()
        {
            numLifes = 5;
            score = 0.0f;
            level = 1;
            backgroundImg = Resources.level1;
            lifeImg = Resources.fire;
            infoBarImg = Resources.infoBar;

        }

        public void updateTime()
        {

        }

        public void showInfoBar(Graphics g, Rectangle ClientRectangle)
        {
            g.DrawImage(infoBarImg, ClientRectangle.X, ClientRectangle.Y + ClientRectangle.Height - infoBarImg.Height, infoBarImg.Width+5, infoBarImg.Height);
        }

        public void showLifes(Graphics g, Rectangle ClientRectangle)
        {
            if (numLifes > 0) g.DrawImage(lifeImg, ClientRectangle.X  + 9, ClientRectangle.Y + ClientRectangle.Height - infoBarImg.Height * 2 / 3 + 4, lifeImg.Width + 12, lifeImg.Height - 2);
            for (int i = 1; i < numLifes; i++)
                g.DrawImage(lifeImg, ClientRectangle.X + i * (lifeImg.Width + 12) + 9, ClientRectangle.Y + ClientRectangle.Height - infoBarImg.Height * 2 / 3 +4, lifeImg.Width + 11, lifeImg.Height-2);


        }



    }
}