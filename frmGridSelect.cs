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

        public frmGridSelect(Image selectedImage, int numColumns, int numRows)
        {
            InitializeComponent();
            targetImage = selectedImage;
        }

        private void frmGridSelect_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = targetImage;
        }

    }
}
