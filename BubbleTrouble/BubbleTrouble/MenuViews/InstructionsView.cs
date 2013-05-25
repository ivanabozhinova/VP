using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BubbleTrouble.Properties;


namespace BubbleTrouble
{
    public class InstructionsView:View
    {
        public Image backImg { set; get; }
         public InstructionsView()
            : base(Resources.instructionsbg)
        {
            this.backImg = Resources.back;
        }


         public System.Windows.Forms.Button enableInstructionsView_BACK_Button(System.Windows.Forms.Button button_BACK)
         {
             button_BACK.Image = this.backImg;
             button_BACK.Size = new Size(this.backImg.Width, this.backImg.Height);
             button_BACK.Location = new Point(12, 410);
             button_BACK.Visible = true;
             button_BACK.Enabled = true;
             return button_BACK;
         }
         public System.Windows.Forms.Button disableInstructionsView_BACK_Button(System.Windows.Forms.Button button_BACK)
         {
             button_BACK.Visible = false;
             button_BACK.Enabled = false;
             return button_BACK;
         }

         public override void drawView(Graphics g, Rectangle ClientRectangle)
         {
             g.DrawImage(this.backgroundImg, ClientRectangle);
         }
    }
}
