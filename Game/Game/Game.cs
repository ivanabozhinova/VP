﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Game.Properties;


namespace Game
{
    public enum SCENE_NUMBER { begin, choosePlayer, instructions, showScore, level1, level2, level3 };
    public class Game
    {
        public SCENE_NUMBER sceneNo { set; get; }
        public float currentScore { set; get; }
        public int numLives { set; get; }
        public Scene currentScene { set; get; }

        //ova najverojatno ke treba u forms poso tamu ke se regulira dali e udren ili ne 
        //public bool isPlayerHit { set; get; }


        public Game(SCENE_NUMBER sceneNo)
        {
            goToScene(sceneNo);
        }

        //moze da se bira samo begin(pocetna strana),choosePlayer,controls,ili da pocne so level 1 
        public void goToScene(SCENE_NUMBER sceneNo = SCENE_NUMBER.begin, float currentScore = 0.00f, int numLives = 5)
        {
            this.sceneNo = sceneNo;
            this.currentScore = currentScore;
            this.numLives = numLives;
            this.currentScene = new Scene(sceneNo, currentScore, numLives);
        }

        //replay the level with one life less
        public void replayLevel()
        {
            numLives -= 1;
            if (numLives > 0)
            {              
                goToScene(sceneNo, currentScore,numLives);
            }
        }

        public void nextLevel()
        {
            sceneNo += 1;
            if (sceneNo <= SCENE_NUMBER.level3)
            {
                this.currentScene = new Scene(sceneNo, currentScore, numLives);
            }
            
        }

        public bool isLastLevel()
        {
            if (sceneNo == SCENE_NUMBER.level3) return true;
            return false;
        }

        public void roundOver(float playerCoordinateX, float playerCoordinateY, float radius, Graphics g, Rectangle ClientRectangle)
        {
            
            var circle = new System.Drawing.Drawing2D.GraphicsPath();
            circle.AddEllipse(playerCoordinateX, playerCoordinateY, radius, radius);

            g.SetClip(circle, System.Drawing.Drawing2D.CombineMode.Exclude);
            
            Brush brush = new SolidBrush(Color.FromArgb(30, Color.Black));
            g.FillRectangle(brush, 0, 0, currentScene.backgroundImg.Width, currentScene.backgroundImg.Height);

            // Image gameover = Resourses.gameover;
            //  g.DrawImage(gameover, ClientRectangle, this.currentScene.backgroundImg.Width / 2, this.currentScene.backgroundImg.Height/ 2,gameover.Width,gameover.Height);

        }
    }
}
