using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BubbleTrouble
{
    public class View
    {
      
        public Image backgroundImg { set; get; }

        public  View(Image backgroundImg)
        {
            this.backgroundImg=backgroundImg;           
        }

        //draw the background
        protected virtual void drawBackground(Graphics g, Rectangle ClientRectangle)
        {
            g.DrawImage(this.backgroundImg, ClientRectangle);
        }
        //draw the View
        public virtual void drawView(Graphics g, Rectangle ClientRectangle)
        {
            
        }
    }
}
