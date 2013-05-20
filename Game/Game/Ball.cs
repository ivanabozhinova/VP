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
        public double angle { get; set; }
        public bool ishited { set; get; }

        private double velocityX;
        private double velocityY;
        private int Width;
        private int Height;

        public Ball(int x, int y, int width, int height)
        {
            Width = width - 30;
            Height = height - 150;
            bubble = Resources.rball61;
            X = 30;
            Y = 30;
            Radius = 30;
            velocity = 5;
            Random r = new Random();
            angle = Math.PI / 4;
            velocityX = (float)(Math.Cos(angle) * velocity);
            velocityY = (float)(Math.Sin(angle) * velocity);
        }


        public void MoveBall()
        {
            //neso mrda ama ne eopfaten slucajot koa se odbiva  
            //    this.X *= (float)Math.PI / 180; ;
            //    this.Y = (float)Math.Abs(Math.Cos(X));

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
            // Brush brush = new SolidBrush(Color.Red);
            //   g.FillEllipse(brush, (float)X, (float)Y, 30, 30);
        }

    }
}
