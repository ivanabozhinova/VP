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
        public bool isHit { set; get; }
        public int Time { set; get; } // kolku vreme pominalo otkako iskocila topkata, 
                                        // ni treba za da moze da padne od povisoko od so ke skoka posle

        public bool dying; //dali bila puknata vo poslednite nekolku tikovi

        private double velocityX;
        private double velocityY;

        // do kade ke otskoknuvaat topcinjata
        private int down;
        private int up;
        private int left;
        private int right;

        public Ball(double x, double y, int worldWidth, int worldHeight, int radius, double angle)
        {
            dying = false;
            isHit = false;
            X = x;
            //Y = y; //visinata od koja topceto paga pri negovoto pojavuvanje zavisi samo od negoviot radius
            Radius = radius;
            velocity = 5;
            Angle = angle;
            velocityX = (float)(Math.Cos(Angle) * velocity);
            velocityY = (float)(Math.Sin(Angle) * velocity);
            Time = 0;

            switch (Radius)
            {
                case 40: //mozni radiusi se 40, 32, 20, 8 => moze da gi staveme u enum
                    bubble = Resources.rball6;
                    up = 0;
                    down = 365;
                    left = -45;
                    right = 660;
                    Y = 40;
                    break;
                case 32:
                    bubble = Resources.rball5;
                    up = 80;
                    down = 370;
                    left = -37;
                    right = 670;
                    Y = 180;
                    break;
                case 20:
                    bubble = Resources.rball4;
                    up = 130;
                    down = 385;
                    left = -25;
                    right = 680;
                    Y = 220;
                    break;
                case 8:
                    bubble = Resources.rball2;
                    up = 250;
                    down = 395;
                    left = -12;
                    right = 695;
                    Y = 270;
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
            if ((nextY - Radius < up) || (nextY + Radius >= down))
            {
                velocityY = -velocityY;
            }
            X += velocityX;
            Y += velocityY;

        }


        public bool isHitBall(Point s)
        {
            double BallXc = X + Radius; //x koordinata na centarot na topkata
            double BallYc = Y + Radius; //y koordinata na centarot na topkata
            double d = (s.X - BallXc) * (s.X - BallXc) + (s.Y - BallYc) * (s.Y - BallYc);
            if (d <= ((Radius + 5) * (Radius + 5)))
                return true;
            return false;
        }


        public void DrawBall(Graphics g)
        {
             g.DrawImage(bubble, (float)X, (float)Y, 2*Radius, 2*Radius);
        }

    }
}
