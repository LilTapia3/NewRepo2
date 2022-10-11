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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Checkout frm4 = new Checkout();
            frm4.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
