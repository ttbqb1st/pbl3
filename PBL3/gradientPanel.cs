using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3
{  

    internal class gradientPanel : Panel
    {   
        public Color gradientTop { get;set; }
        public Color gradientBottom { get; set; }
        public gradientPanel()
        {
            this.Resize+= gradientPanel_Resize;
        }
        private void gradientPanel_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, gradientTop, gradientBottom, 90F);
            Graphics g = e.Graphics;
            g.FillRectangle(brush, this.ClientRectangle);
            base.OnPaint(e);
        }

    }
}
