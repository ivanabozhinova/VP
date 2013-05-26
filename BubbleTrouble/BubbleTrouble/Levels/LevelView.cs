using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BubbleTrouble.Properties;

namespace BubbleTrouble
{
    public class LevelView : View
    {
        public List<Ball> Balls;
        public Ball ball { set; get; }
        public Image lifeImg { set; get; }
        public Image statusBarImg { set; get; }
        public Image levelImg { set; get; }
        public int numLives { set; get; }
        public int scores { set; get; }

        public LevelView(Image backgroundImg, Image levelImg,int numLives,int scores): base (backgroundImg)
        {

            this.lifeImg = Resources.fire;
            this.statusBarImg = Resources.infoBar1;
            this.levelImg = levelImg;
            this.numLives = numLives;
            this.scores = scores;
            
           
        }
        public virtual void resetBalls(int width,int height) { }

        //display the background of the status bar
        protected  void drawStatusBar(Graphics g, Rectangle ClientRectangle)
        {
            g.DrawImage(statusBarImg, ClientRectangle.X, ClientRectangle.Y + ClientRectangle.Height - statusBarImg.Height,
                            statusBarImg.Width + 5, statusBarImg.Height);
        }


        //display the number of lives
        protected   void drawLives(Graphics g, Rectangle ClientRectangle)
        {
             if (numLives > 0)
                {
                    for (int i = numLives; i >= 1; i--)
                        g.DrawImage(lifeImg,
                                    ClientRectangle.X + i * (lifeImg.Width + 12) + 260, ClientRectangle.Y + ClientRectangle.Height - statusBarImg.Height * 2 / 3 + 27,
                                    lifeImg.Width + 5, lifeImg.Height - 5);
                }
        }


        //display the number of current level
        protected  void drawLevel(Graphics g, Rectangle ClientRectangle)
        {
            g.DrawImage(this.levelImg, ClientRectangle.X + 615, ClientRectangle.Y + 425,48,44);
        }

        //draw the background
        protected override void drawBackground(Graphics g, Rectangle ClientRectangle)
        {
            g.DrawImage(this.backgroundImg, ClientRectangle);
        }


        //draw the whole Scene
        public override void drawView(Graphics g, Rectangle ClientRectangle)
        {
            g.Clear(Color.White);

            this.drawBackground(g, ClientRectangle);
            this.drawStatusBar(g, ClientRectangle);
            this.drawLives(g, ClientRectangle);
            this.drawLevel(g, ClientRectangle);

        }


    }
}
