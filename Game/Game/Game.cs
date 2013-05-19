using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Game.Properties;


namespace Game
{
    public class Game
    {
        public static readonly int MAXLevel = 3;
        public int currentLevel { set; get; }
        public float currentScore { set; get; }
        public int numLives { set; get; }
        public Scene currentScene { set; get; }
        public Player player { set; get; }

        //ova najverojatno ke treba u forms poso tamu ke se regulira dali e udren ili ne 
        //public bool isPlayerHit { set; get; }


        public Game(Player player)
        {
            this.currentLevel = 1;
            this.currentScore = 0.0f;
            this.numLives = 5;
            this.player = player;
            this.currentScene = new Scene(currentLevel, currentScore, numLives,player);
        }


        public void nextLevel()
        {
            currentLevel += 1;
            if (currentLevel <= MAXLevel)
                this.currentScene = new Scene(currentLevel, currentScore, numLives,player);
            else
                gameOver();

        }

        //ako izgubi da ja povtori

        public void replayLevel(Graphics g, Rectangle ClientRectangle)
        {
            this.numLives -= 1;
            if (numLives == 0)
                gameOver();
            else
            {
                this.currentScene.numLives = numLives;
                this.currentScene.setScene(currentLevel, currentScore, numLives,player);
                this.currentScene.drawScene(g, ClientRectangle);
            }
        }

        public void gameOver()
        {
            //neso da se otvori novo proozrce ili neso natpis nz ..

        }

    }
}
