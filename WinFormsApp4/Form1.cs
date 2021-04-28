using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private bool mouseClicked = false;
        private bool isSelected = false;
        private bool isSelectedDown = false;
        private bool isMouseDown = false;
        private bool isSelecteup = false;
        private bool isSelecteleft = false;
        int x = 200;
        int y = 200;
        int width = 200;
        int higth = 200;
        private Point point = new Point(0, 0);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            g.DrawEllipse(new Pen(Brushes.Black, 4), x, y, width, higth);
            if (isSelecteleft)
            {
                g.DrawEllipse(new Pen(Brushes.Red, 4), (x - 5), (y + higth / 2 - 5), 2, 2);
            }
            if (isSelecteup)
            {
                g.DrawEllipse(new Pen(Brushes.Red, 4), (x + width / 2 - 5), (y - 5), 2, 2);
            }
            if (isSelectedDown)
            {
                g.DrawEllipse(new Pen(Brushes.Red, 4), (x + width / 2 - 5), (y + higth - 5), 2, 2);
            }
            if (isSelected)
            {
                g.DrawEllipse(new Pen(Brushes.Red, 4), (x + width / 2 - 5), (y + higth / 2 - 5), 3, 3); 
                g.DrawEllipse(new Pen(Brushes.Red, 4), (x + width / 2 - 5), (y - 5), 2, 2); 
                g.DrawEllipse(new Pen(Brushes.Red, 4), (x - 5), (y + higth / 2 - 5), 2, 2);
                g.DrawEllipse(new Pen(Brushes.Red, 4), (x + width - 5), (y + higth / 2 - 5), 2, 2); 
                g.DrawEllipse(new Pen(Brushes.Red, 4), (x + width / 2 - 5), (y + higth - 5), 2, 2); 
            }
            

        }

        public bool checkIntract(MouseEventArgs mouse)
        {
            var rect1 = new System.Drawing.Rectangle(this.x, this.y, this.width, this.higth);
            var rect2 = new System.Drawing.Rectangle(mouse.X, mouse.Y, 10, 10);
            return rect1.IntersectsWith(rect2);
        }

        public bool checkdown(MouseEventArgs mouse)
        {
            var rect1 = new System.Drawing.Rectangle(this.x + width / 2 , this.y + higth , this.width, this.higth);
            var rect2 = new System.Drawing.Rectangle(mouse.X, mouse.Y, 10, 10);
            return rect1.IntersectsWith(rect2);
        }

        public bool checkup(MouseEventArgs mouse)
        {
            var rect1 = new System.Drawing.Rectangle(this.x + width / 2 - 5, this.y , this.width, this.higth);
            var rect2 = new System.Drawing.Rectangle(mouse.X, mouse.Y, 10, 10);
            return rect1.IntersectsWith(rect2);
        }

        public bool checkleft(MouseEventArgs mouse)
        {
            var rect1 = new System.Drawing.Rectangle(this.x - 5, this.y + higth / 2 - 5, this.width, this.higth);
            var rect2 = new System.Drawing.Rectangle(mouse.X, mouse.Y, 10, 10);
            return rect1.IntersectsWith(rect2);
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
            if (checkIntract(e))
            {
                this.isSelected = true;
                this.Invalidate();
            }
            else
            {
                this.isSelected = false;
                this.Invalidate();
            }
            if (checkdown(e))
            {
                this.isSelectedDown = true;
                this.Invalidate();
            }
            else
            {
                this.isSelectedDown = false;
                this.Invalidate();
            }

            if (checkup(e))
            {
                this.isSelecteup = true;
                this.Invalidate();
            }
            else
            {
                this.isSelecteup = false;
                this.Invalidate();
            }

            if (checkleft(e))
            {
                this.isSelecteleft = true;
                this.Invalidate();
            }
            else
            {
                this.isSelecteleft = false;
                this.Invalidate();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (isSelected && checkIntract(e))
            {
                this.isMouseDown = true;
            }
            if (isSelectedDown && checkdown(e))
            {
                this.isMouseDown = true;
            }
            if (isSelectedDown && checkup(e))
            {
                this.isMouseDown = true;
            }
            if (isSelectedDown && checkleft(e))
            {
                this.isMouseDown = true;
            }


        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isMouseDown  && checkIntract(e))
            {
                this.x = e.Location.X - (width / 2);
                this.y = e.Location.Y - (higth / 2);
                this.Invalidate();
            }

            if (this.isMouseDown && checkdown(e))
            {
                this.higth = e.Location.Y - (width / 2);
                this.Invalidate();
            }

            if (this.isMouseDown && checkup(e))
            {
                this.higth = e.Location.Y;
                this.Invalidate();
            }
            if (this.isMouseDown && checkleft(e))
            {
                this.width = e.Location.Y;
                this.Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isMouseDown = false;
        }
    }
}
