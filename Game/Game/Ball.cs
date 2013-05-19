using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Game
{
    public class Ball
    {
        public Image bubble { set; get; }
        public Point coordinates { set; get; }
        public double size { set; get; }
        public double velocity { get; set; }
        public double angle { get; set; }
        public bool ishited { set; get; }

        private double velocityX;
        private double velocityY;

        public Ball(Point Coordinates)
        {
            coordinates = Coordinates;
            size = 30.0;
            velocity = 10;
            Random r = new Random();
            angle = r.NextDouble() * 2 * Math.PI;
            velocityX = (float)(Math.Cos(angle) * velocity);
            velocityY = (float)(Math.Sin(angle) * velocity);
        }


        public void MoveBall()
        {
        }


        public bool isHitBall()
        {
            return false;
        }

        public void DrawBall()
        { 
        }

    }
}
