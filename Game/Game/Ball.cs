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
        public float size { set; get; }
        public float velocity { get; set; }
        public float angle { get; set; }

        private float velocityX;
        private float velocityY;

        public Ball(Point Coordinates, float Size, float Velocity, float Angle)
        {
            coordinates = Coordinates;
            size = Size;
            velocity = Velocity;
            angle = Angle;
        }

    }
}
