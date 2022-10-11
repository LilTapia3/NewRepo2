using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Recepcion : Form
    {
        public Recepcion()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login frm2 = new Login();
            frm2.Show();

            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Inicio_Click(object sender, EventArgs e)
        {

        }

        private void Checkin_Click(object sender, EventArgs e)
        {

            Checkin frm3 = new Checkin();
            frm3.Show();

            this.Close();
        }

        private void Checkout_Click(object sender, EventArgs e)
        {
            Checkout frm4 = new Checkout();
            frm4.Show();
            this.Close();
        }

        private void Ventas_Click(object sender, EventArgs e)
        {
            Ventas frm5 = new Ventas();
            frm5.Show();
            this.Close();
        }
    }
}
