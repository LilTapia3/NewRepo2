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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            textBox2.Text = "";
            // cambia las letras a *.
            textBox2.PasswordChar = '*';
            // Controla que el largo no sea superior a 16
            textBox2.MaxLength = 16;

        }

        // Box de agrupacion
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Box de password 
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Box de ingreso
        private void button1_Click(object sender, EventArgs e)
        {
            Recepcion frm2 = new Recepcion();
            frm2.Show();
            //this.Close();

        }

        // Box de id
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
