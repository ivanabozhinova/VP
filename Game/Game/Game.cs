using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Game.Properties;


namespace Game
{
    public enum SCENE_NUMBER {begin,choosePlayer,controls,level1,level2,level3};
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
        public void goToScene(SCENE_NUMBER sceneNo)
        {
            this.sceneNo = sceneNo;
            this.currentScore = 0.0f;
            this.numLives = 5;
           // if (sceneNo != SCENE_NUMBER.choosePlayer)
            this.currentScene = new Scene(sceneNo, currentScore, numLives);
        }
       


        //public void nextLevel()
        //{
        //    sceneNo += 1;
        //    if (sceneNo <= SCENE_NUMBER.level3)
        //        this.currentScene = new Scene(sceneNo, currentScore, numLives);
        //    else
        //        gameOver();

        //}

        //ako izgubi da ja povtori

        //public void replayLevel(Graphics g, Rectangle ClientRectangle)
        //{
        //    this.numLives -= 1;
        //    if (numLives == 0)
        //      //  gameOver();
        //    else
        //    {
        //        this.currentScene.numLives = numLives;
        //        this.currentScene.setScene(sceneNo, currentScore, numLives);
        //        this.currentScene.drawScene(g, ClientRectangle);
        //    }
        //}

        public void gameOver(float playerCoordinateX, float playerCoordinateY,float radius,Graphics g)
        {
            using ( g = Graphics.FromImage(currentScene.backgroundImg))
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(45, 1, 1, 1)))
                {
                    g.FillRectangle(brush, 0, 0, currentScene.backgroundImg.Width, currentScene.backgroundImg.Height);
                    
                }
                Brush brush1 = new SolidBrush(Color.FromArgb(50, 240, 240, 240));

                g.FillEllipse(brush1, playerCoordinateX, playerCoordinateX, radius,radius);

                
            }

        }

    }
}
