﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Game.Properties;

namespace Game
{
    public class Scene
    {
        public int numLives { set; get; }
        public float score { set; get; }
        public Image backgroundImg { set; get; }
        public Image lifeImg { set; get; }
        public Image statusBarImg { set; get; }
        public Image levelImg { set; get; }
        public SCENE_NUMBER sceneNo { set; get; }


        public Scene(SCENE_NUMBER sceneNo, float score, int numLives)
        {
            this.setScene(sceneNo, score, numLives);
        }

        //set the Scene for the current level
        public void setScene(SCENE_NUMBER sceneNo, float score, int numLives)
        {
            this.numLives = numLives;
            this.score = score;
            this.sceneNo = sceneNo;

            backgroundImg = Resources.begin1;
            lifeImg = Resources.fire;
            statusBarImg = Resources.infoBar;

            switch (sceneNo)
            {
                case SCENE_NUMBER.level3:
                    backgroundImg = Resources.lvl3;
                    break;
                case SCENE_NUMBER.level2:
                    backgroundImg = Resources.level2;
                    break;
                case SCENE_NUMBER.level1:
                    backgroundImg = Resources._01;
                    break;
                case SCENE_NUMBER.begin:
                    backgroundImg = Resources.start;
                    break;
                case SCENE_NUMBER.choosePlayer:
                    backgroundImg = Resources.choose;
                    break;
            }



        }



        //display the currentlevel
        //public void showLevel(Graphics g, Rectangle ClientRectangle);



        //display the background of the status bar
        public void showStatusBar(Graphics g, Rectangle ClientRectangle)
        {
            if (sceneNo != SCENE_NUMBER.choosePlayer)
                g.DrawImage(statusBarImg, ClientRectangle.X, ClientRectangle.Y + ClientRectangle.Height - statusBarImg.Height,
                            statusBarImg.Width + 5, statusBarImg.Height);
        }

        //display the number of lives
        public void showLives(Graphics g, Rectangle ClientRectangle)
        {
            if (sceneNo != SCENE_NUMBER.choosePlayer)
                if (numLives > 0)
                {
                    //display the first life
                    g.DrawImage(lifeImg, ClientRectangle.X + 375, ClientRectangle.Y + ClientRectangle.Height - statusBarImg.Height * 2 / 3 + 27,
                                lifeImg.Width + 5, lifeImg.Height - 5);
                    //display the rest
                    if (numLives > 1)
                    {
                        for (int i = 1; i < numLives; i++)
                            g.DrawImage(lifeImg,
                                        ClientRectangle.X + i * (lifeImg.Width + 12) + 260, ClientRectangle.Y + ClientRectangle.Height - statusBarImg.Height * 2 / 3 + 27,
                                        lifeImg.Width + 5, lifeImg.Height - 5);
                    }
                }
        }

        //draw the background
        public void drawBackground(Graphics g, Rectangle ClientRectangle)
        {
            g.DrawImage(this.backgroundImg, ClientRectangle);
        }
        public void drawBeginScene(Graphics g, Rectangle ClientRectangle)
        {
            g.Clear(Color.White);
            this.drawBackground(g, ClientRectangle);
        }

        //draw the whole Scene
        public void drawScene(Graphics g, Rectangle ClientRectangle)
        {
            g.Clear(Color.White);

            this.drawBackground(g, ClientRectangle);
            this.showStatusBar(g, ClientRectangle);
            this.showLives(g, ClientRectangle);
            //this.showLevel(g, ClientRectangle);

        }
    }
}