using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Game.Properties;


namespace BubbleTrouble
{
    class Game
    {
        public static readonly int MAXLevel = 3;
        public int currentLevel { set; get; }
        public float currentScore { set; get; }
        public int numLives { set; get; }
        public Scene currentScene { set; get; }
        public bool gameOver { set; get; }
        //ova najverojatno ke treba u forms poso tamu ke se regulira dali e udren ili ne 
        //public bool isPlayerHit { set; get; }


        public Game()
        {
            this.currentLevel = 1;
            this.currentScore = 0.0f;
            this.numLives = 5;
            this.currentScene = new Scene(currentLevel, currentScore, numLives);
            this.gameOver = false;
        }


        public void nextLevel()
        {
            currentLevel += 1;
            if (currentLevel <= MAXLevel)
                this.currentScene = new Scene(currentLevel, currentScore, numLives);
            else
                gameOver = true;

        }

        //ako izgubi da ja povtori

        public void replayLevel(Graphics g, Rectangle ClientRectangle)
        {
            this.numLives -= 1;
            this.currentScene.numLives = numLives;
            this.currentScene.setScene(currentLevel, currentScore, numLives);
            this.currentScene.drawScene(g, ClientRectangle);
        }


    }
}
