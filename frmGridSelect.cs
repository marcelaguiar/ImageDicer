using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDicer
{
    public partial class frmGridSelect : Form
    {
        Image targetImage;
        Point rectStartPoint;
        Rectangle rect = new Rectangle();
        Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));

        public frmGridSelect(Image selectedImage, int numColumns, int numRows)
        {
            InitializeComponent();
            targetImage = selectedImage;
        }

        private void frmGridSelect_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = targetImage;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            rectStartPoint = e.Location;

            rect.Location = new Point(rectStartPoint.X, rectStartPoint.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Point tempEndPoint = e.Location;

            rect.Location = new Point(
                Math.Min(rectStartPoint.X, e.Location.X),
                Math.Min(rectStartPoint.Y, e.Location.Y));

            rect.Size = new Size(
                Math.Abs(rectStartPoint.X - e.Location.X),
                Math.Abs(rectStartPoint.Y - e.Location.Y));

            pictureBox1.Invalidate(); // Can I remove this?
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Console.WriteLine("FINAL: Start: " + rectStartPoint);
            Console.WriteLine("FINAL: Size: " + rect.Size);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rectangle...
            if (pictureBox1.Image != null)
            {
                if (rect != null && rect.Width > 0 && rect.Height > 0)
                {
                    e.Graphics.FillRectangle(selectionBrush, rect);
                }
            }
        }

    }
}
