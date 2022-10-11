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
    public partial class Checkout : Form
    {
        public Checkout()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Checkin frm3 = new Checkin();
            frm3.Show();
            this.Close();
        }

        private void Inicio_Click(object sender, EventArgs e)
        {
            Recepcion frm2 = new Recepcion();
            frm2.Show();
            this.Close();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login frm1 = new Login();
            frm1.Show();
            this.Close();
        }

        private void Ventas_Click(object sender, EventArgs e)
        {
            Ventas frm5 = new Ventas();
            frm5.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
