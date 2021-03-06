﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        string selDirectory;
        bool selectionMade = false;
        bool directorySelected = false;

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

            Size visImageSize;

            var wfactor = (double)targetImage.Width / pictureBox1.ClientSize.Width;
            var hfactor = (double)targetImage.Height / pictureBox1.ClientSize.Height;

            var resizeFactor = Math.Max(wfactor, hfactor);
            var imageSize = new Size((int)(targetImage.Width / resizeFactor), (int)(targetImage.Height / resizeFactor));


            visImageSize = new Size(
                (int)(targetImage.Width / resizeFactor),
                (int)(targetImage.Height / resizeFactor));

            var proportion = targetImage.Width / visImageSize.Width;

            // Calculate margins
            var marginX = pictureBox1.Width / 2 - (int)((targetImage.Width / resizeFactor) / 2);
            var marginY = pictureBox1.Height / 2 - (int)((targetImage.Height / resizeFactor) / 2);

            Point newLocation;
            Size newSize = new Size(columnWidth*proportion, rowHeight*proportion);

            // Put each cell of grid into a rectangle object
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    newLocation = new Point(
                        proportion*(rect.Location.X - marginX + (col * columnWidth)),
                        proportion*(rect.Location.Y - marginY + (row * rowHeight)));
                    listRect.Add(new Rectangle(newLocation, newSize));
                }
            }

            selectionMade = true;
            if (directorySelected)
                confirmSelectionButton.Enabled = true;
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
            myPen.Width = 1;

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
            string pathAndFile;
            int count = 0;

            // Save each rectangle in listRect as an image
            foreach (Rectangle rect in listRect)
            {
                fileName = "sub_image_" + count + ".jpg";
                pathAndFile = Path.Combine(selDirectory, fileName);

                PixelFormat format = myBitmap.PixelFormat;
                cloneBitmap = myBitmap.Clone(rect, format);
                cloneBitmap.Save(pathAndFile, ImageFormat.Jpeg);

                count++;
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        selDirectory = fbd.SelectedPath;
                        pathLabel.Text = selDirectory;
                        directorySelected = true;
                    }
                }
            }

            if (selectionMade)
                confirmSelectionButton.Enabled = true;
        }

    }
}
