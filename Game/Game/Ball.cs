using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Game.Properties;

namespace Game
{
    public class Ball
    {
        public Image bubble { set; get; }
        public double X { set; get; }
        public double Y { set; get; }
        public double Radius { set; get; }
        public double velocity { get; set; }
        public double Angle { get; set; }
        public bool ishited { set; get; }

        private double velocityX;
        private double velocityY;
        private int Width;
        private int Height;

        public Ball(double x, double y, int worldWidth, int worldHeight, double radius, double angle)
        {
            Width = worldWidth - 30;
            Height = worldHeight - 150;
            bubble = Resources.rball61;
            X = x;
            Y = y;
            Radius = 40;
            velocity = 5;
            //Random r = new Random();
            // angle = Math.PI * r.NextDouble();
            Angle = angle;
            velocityX = (float)(Math.Cos(Angle) * velocity);
            velocityY = (float)(Math.Sin(Angle) * velocity);
        }


        public void MoveBall()
        {

            double nextX = X + velocityX;
            double nextY = Y + velocityY;
            if (nextX - Radius < -45 || (nextX + Radius >= Width))
            {
                velocityX = -velocityX;
            }
            if (nextY - Radius < -45 || (nextY + Radius >= Height))
            {
                velocityY = -velocityY;
            }
            X += velocityX;
            Y += velocityY;


        }


        public bool isHitBall()
        {
            return false;
        }

        public void DrawBall(Graphics g)
        {
            g.DrawImage(bubble, (float)X, (float)Y, bubble.Width, bubble.Height);
        }

    }
}
