using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BubbleTrouble.Properties;

namespace BubbleTrouble
{
    public class SecondLevelView :LevelView
    {
        
        public SecondLevelView(int numLives, int scores)
            : base(Resources._02, Resources.lvlNo21, numLives, scores)
        {
        
        }

        public override void resetBalls(int width,int height)
        {
            Balls = new List<Ball>();
            
            //biggest ball
             ball = new Ball(30, 40, width, height, 40, Math.PI / 4);
           // Balls.Add(ball);
            //middle ball
            ball = new Ball(width - 115, 180, height, height, 32, 3 * Math.PI / 4);
            Balls.Add(ball);
            //small ball
            ball = new Ball(30, 220, width, height, 20, Math.PI / 4);
             Balls.Add(ball);
            //smallest ball
            ball = new Ball(width - 115, 270, width, height, 8, 3 * Math.PI / 4);
             //Balls.Add(ball);
        }
        
    }
}
