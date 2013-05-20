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
        public float X { set; get; }
        public float Y { set; get; } 
        public double size { set; get; }
        public double velocity { get; set; }
        public double angle { get; set; }
        public bool ishited { set; get; }

        private double velocityX;
        private double velocityY;

        public Ball(int x, int y)
        {
            bubble = Resources.rball6;
            X = x;
            Y = y;
            size = 30.0;
            velocity = 10;
            Random r = new Random();
            angle = r.NextDouble() * 2 * Math.PI;
            velocityX = (float)(Math.Cos(angle) * velocity);
            velocityY = (float)(Math.Sin(angle) * velocity);
        }


        public void MoveBall(float X)
        {
           //neso mrda ama ne eopfaten slucajot koa se odbiva  
                this.X *= (float)Math.PI / 180; ;
                this.Y = (float)Math.Abs(Math.Cos(X));
            
        }


        public bool isHitBall()
        {
            return false;
        }

        public void DrawBall(Graphics g)
        {
            g.DrawImage(bubble, X, Y, bubble.Width, bubble.Height);
        }

    }
}
