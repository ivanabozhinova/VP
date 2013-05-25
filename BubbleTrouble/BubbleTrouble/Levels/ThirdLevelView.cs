using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BubbleTrouble.Properties;

namespace BubbleTrouble
{
    public class ThirdLevelView:LevelView
    {
        

        public ThirdLevelView(int numLives, int scores)
            : base(Resources._03, Resources.lvlNo31, numLives, scores)
        {
           
        }

        public override void resetBalls(int width,int height)
        {
            this.Balls = new List<Ball>();
           
            //biggest ball
            ball = new Ball(30, 40, width, height, 40, Math.PI / 4);
            //Balls.Add(ball);
            //middle ball
            ball = new Ball(width - 115, 180, width, height, 32, 3 * Math.PI / 4);
            //Balls.Add(ball);
            //small ball
            ball = new Ball(30, 220, width, height, 20, Math.PI / 4);
            //Balls.Add(ball);
            //smallest ball
            ball = new Ball(width - 115, 270, width, height, 8, 3 * Math.PI / 4);
            Balls.Add(ball);
        }
    }
}
