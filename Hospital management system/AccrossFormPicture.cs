using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_management_system
{
    public partial class AccrossFormPicture : Form
    {
        public AccrossFormPicture(System.Drawing.Image i)
        {
            InitializeComponent();
            pictureBox1.Image = i;
        }

        

        private void AccrossFormPicture_Load(object sender, EventArgs e)
        {

        }
    }
}
