using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using iText.StyledXmlParser.Jsoup.Select;

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
            //Conexion con bd
            string usuario, contraseña;
            usuario = textBox1.Text;
            contraseña = textBox2.Text;
            MySqlConnection con = new MySqlConnection("server = 127.0.0.1; Database = turismo; User iD = root; Password=;");
            try
            {
                //Si conecta
                con.Open();
            }
            catch (MySqlException ex)
            {
                //Si no conecta mostrar siguiente mensaje
                MessageBox.Show("error" + ex.ToString());
                throw;
            }
            //Se establece la Query a realizarse en la bd
            String sql = "SELECT * FROM usuario WHERE rut_usuario ='"+usuario+"' and contrasena_usuario ='"+ contraseña+"' and id_rol = 2;" ;
            //Se establece la comunicacion con la bd y posteriormente la consulta
            MySqlCommand cmd = new MySqlCommand(sql, con);
            //Se retiran los datos de la Query en la variable Read
            MySqlDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                //Si lo datos son coincidentes con los ingresados en la query, se muestra el mensaje de bienvenido
                this.Hide();
                MessageBox.Show("Bienvenido");
                Recepcion frm2 = new Recepcion();
                frm2.Show();
                //this.Close();
            }
            else
            {
                //Si el dato no es coincidente se mostrara el siguiente mensaje
                MessageBox.Show("Contraseña o usuario invalido");
            }
 

        }

        // Box de id
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
