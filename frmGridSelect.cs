using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageDicer
{
    public partial class frmGridSelect : Form
    {
        Image targetImage;
        int columnCount;
        int rowCount;

        int columnWidth;
        int rowHeight;
        Point rectStartPoint;
        Point lineStartPoint;
        Point lineEndPoint;
        Rectangle rect = new Rectangle();
        List<Rectangle> listRect = new List<Rectangle>();
        
        Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));
        Pen myPen = new Pen(Color.Blue);

        public frmGridSelect(Image selectedImage, int numColumns, int numRows)
        {
            InitializeComponent();
            targetImage = selectedImage;
            columnCount = numColumns;
            rowCount = numRows;
        }

        private void frmGridSelect_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = targetImage;
            myPen.Width = 1;
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

            columnWidth = rect.Width / columnCount;
            rowHeight = rect.Height / rowCount;

            pictureBox1.Invalidate(); // Can I remove this?
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Point newLocation;
            Size newSize = new Size(columnWidth, rowHeight);

            // put each cell of grid into a rectangle object
            for (int row = 0; row < rowCount; row ++ )
            {
                for (int col = 0; col < columnCount; col++)
                {
                    newLocation = new Point(
                        rect.Location.X + (col*columnWidth),
                        rect.Location.Y + (row*rowHeight));
                    listRect.Add(new Rectangle(newLocation, newSize));
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Draw transparent rectangle
            if (pictureBox1.Image != null)
            {
                if (rect != null && rect.Width > 0 && rect.Height > 0)
                {
                    e.Graphics.FillRectangle(selectionBrush, rect);
                    drawGrid(e);
                }
            }
        }

        private void drawGrid(PaintEventArgs e)
        {
            // Draw vertical lines
            for (int i = 0; i <= columnCount; i++)
            {
                lineStartPoint.X = rect.X + (i * columnWidth);
                lineStartPoint.Y = rect.Y;
                lineEndPoint.X = lineStartPoint.X;
                lineEndPoint.Y = rect.Y + rect.Height;

                e.Graphics.DrawLine(myPen, lineStartPoint, lineEndPoint);
            }

            // Draw horizontal lines
            for (int i = 0; i <= rowCount; i++)
            {
                lineStartPoint.X = rect.X;
                lineStartPoint.Y = rect.Y + (i * rowHeight);
                lineEndPoint.X = rect.X + rect.Width;
                lineEndPoint.Y = lineStartPoint.Y;

                e.Graphics.DrawLine(myPen, lineStartPoint, lineEndPoint);
            }
        }

        private void confirmSelectionButton_Click(object sender, EventArgs e)
        {
            Bitmap myBitmap = new Bitmap(targetImage);
            Bitmap cloneBitmap;
            string fileName;
            int count = 0;

            // Save each rectangle in listRect as an image
            foreach (Rectangle rect in listRect)
            {
                fileName = "asdfwert_" + count + ".jpg";

                PixelFormat format = myBitmap.PixelFormat;
                cloneBitmap = myBitmap.Clone(rect, format);
                cloneBitmap.Save(fileName, ImageFormat.Jpeg);

                count++;
            }
        }

    }
}
