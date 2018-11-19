using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPropietarios
{
    public partial class AcercaDe : Form
    {
        public AcercaDe()
        {
            InitializeComponent();
            InitializeComponent();
            this.CenterToScreen();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void AcercaDe_Load(object sender, EventArgs e)
        {
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal mp = new MenuPrincipal();
            mp.Show();
            this.Hide();
        }
    }
}
