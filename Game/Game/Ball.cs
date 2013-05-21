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
        public int Radius { set; get; }
        public double velocity { get; set; }
        public double Angle { get; set; }
        public bool ishited { set; get; }
        public int Time { set; get; } // kolku vreme pominalo otkako iskocila topkata, 
                                        // ni treba za da moze da padne od povisoko od so ke skoka posle
        public int FallTime { set; get; } //kolku vreme mu treba na topceto da padne do dole pri prvoto pushtanje
        

        private double velocityX;
        private double velocityY;

        // do kade ke otskoknuvaat topcinjata
        private int down;
        private int up;
        private int left;
        private int right;

        public Ball(double x, double y, int worldWidth, int worldHeight, int radius, double angle)
        {
            down = worldHeight - 150;
            left = -45;
            right = worldWidth - 30;
            X = x;
            Y = y;
            Radius = radius;
            velocity = 5;
            Angle = angle;
            velocityX = (float)(Math.Cos(Angle) * velocity);
            velocityY = (float)(Math.Sin(Angle) * velocity);
            Time = 0;
            FallTime = 100;

            switch (Radius)
            {
                case 40: //mozni radiusi se 40, 32, 20, 8 => moze da gi staveme u enum
                    bubble = Resources.rball6;
                    up = 80;
                    right -= 10;
                    break;
                case 32:
                    bubble = Resources.rball5;
                    up = 150;
                    down += 10;
                    left += 8;
                    break;
                case 20:
                    bubble = Resources.rball4;
                    up = 200;
                    down += 20;
                    left += 20;
                    right += 10;
                    break;
                case 8:
                    bubble = Resources.rball2;
                    up = 250;
                    down += 30;
                    left += 30;
                    right += 20;
                    break;
            }


        }


        public void MoveBall()
        {

            double nextX = X + velocityX;
            double nextY = Y + velocityY;
            if (nextX - Radius < left || (nextX + Radius >= right))
            {
                velocityX = -velocityX;
            }
            if ((nextY - Radius < up && Time > FallTime) || (nextY + Radius >= down))
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
