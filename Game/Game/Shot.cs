using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Game
{
    public class Shot
    {
        public List<Point> ShootingPoints { get; set; }
        public int shootingY { get; set; }
        public int shootingX { get; set; }
        public Pen shootingPen = new Pen(Color.Black, 3);
        public Pen shootingPen1 = new Pen(Color.Gray, 1);
        public int deviation = 5;
        public int numTicks { get; set; }

        public Shot()
        {
            ShootingPoints = new List<Point>();
            numTicks = 0;
        }

        public void Draw(Graphics g)
        { 
            g.DrawCurve(shootingPen, ShootingPoints.ToArray());
            g.TranslateTransform(1, 0);
            g.DrawCurve(shootingPen1, ShootingPoints.ToArray());
            g.ResetTransform();
        }

        public void resetShot(Player player, int height)
        {
            player.isShooting = true;
            shootingX = player.X + 15;
            shootingY = height - 100;
            numTicks = 0;
            ShootingPoints = new List<Point>();

        }
    }



}
