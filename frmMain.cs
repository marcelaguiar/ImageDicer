using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageDicer
{
    public partial class frmMain : Form
    {
        Image selectedImage;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            colNumBox.Value = 6;
            rowNumBox.Value = 8;
        }

        private void selectImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFd = new OpenFileDialog())
            {
                openFd.Title = "Open Image";
                openFd.Filter = "Images Only. |*.jpg; *.jpeg; *.png; *.gif;";

                DialogResult dr = openFd.ShowDialog();

                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                selectedImage = Image.FromFile(openFd.FileName);
                pictureBox1.Image = Image.FromFile(openFd.FileName);
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (usageError())
                return;

            frmGridSelect gridSelectPage = new frmGridSelect(selectedImage, (int)colNumBox.Value, (int)rowNumBox.Value);

            if (gridSelectPage.ShowDialog() == DialogResult.OK)
            {
                //do this stuff upon clicking OK    
            }

            gridSelectPage.Dispose();
        }

        private bool usageError()
        {
            if (selectedImage == null)
            {
                MessageBox.Show("You must select an image!", "Usage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            //else if (colNumBox.Value.Equals("") && rowNumBox.Value.Equals(""))
            //{
            //    MessageBox.Show("You must specify values for \"# of Columns\" and \"# of Rows\"", "Usage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}
            //else if (colNumBox.Value.Equals(""))
            //{
            //    MessageBox.Show("You must specify a value for \"# of Columns\"", "Usage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}
            //else if (rowNumBox.Value.Equals(""))
            //{
            //    MessageBox.Show("You must specify a value for \"# of Rows\"", "Usage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}
            //else if (colNumBox.Value.Equals(0) && rowNumBox.Value.Equals(0))
            //{
            //    MessageBox.Show("You must specify non-zero values for \"# of Columns\" and \"# of Rows\"", "Usage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}
            //else if (colNumBox.Value.Equals(0))
            //{
            //    MessageBox.Show("You must specify a non-zero value for \"# of Columns\"", "Usage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}
            //else if (rowNumBox.Value.Equals(0))
            //{
            //    MessageBox.Show("You must specify a non-zero value for \"# of Rows\"", "Usage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}

            return false;
        }
    }
}
