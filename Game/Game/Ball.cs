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

<<<<<<< HEAD
        private float velocityX;
        private float velocityY;

        public Ball(float x, float y)
=======
        private double velocityX;
        private double velocityY;
        private int Width;
        private int Height;

        public Ball(double x, double y, int worldWidth, int worldHeight, double radius, double angle)
>>>>>>> 48e5c9c2fa062cd02f8bb865ddf4b68e8dc40a7e
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
<<<<<<< HEAD

            //double nextX = X + velocityX;
            //double nextY = Y + velocityY;
            //if (nextX - size <= Bounds.Left || (nextX + size >= Bounds.Right))
            //{
            //    velocityX = -velocityX;
            //}
            //if (nextY - size <= Bounds.Top || (nextY + size >= Bounds.Bottom))
            //{
            //    velocityY = -velocityY;
            //}
            //X += velocityX;
            //Y += velocityY;

           //neso mrda ama ne eopfaten slucajot koa se odbiva  
                this.X *= (float)Math.PI / 180; ;
                this.Y = (float)Math.Abs(Math.Cos(X));
            

        }
=======
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
>>>>>>> 48e5c9c2fa062cd02f8bb865ddf4b68e8dc40a7e

        }

        public bool isHitBall()
        {
            return false;
        }

        public void DrawBall(Graphics g)
        {
<<<<<<< HEAD
            g.DrawImage(bubble, X, Y, bubble.Width, bubble.Height);
            
=======
            g.DrawImage(bubble, (float)X, (float)Y, bubble.Width, bubble.Height);
            // Brush brush = new SolidBrush(Color.Red);
            //   g.FillEllipse(brush, (float)X, (float)Y, 30, 30);
>>>>>>> 48e5c9c2fa062cd02f8bb865ddf4b68e8dc40a7e
        }

    }
}
