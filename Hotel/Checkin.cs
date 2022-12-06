using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Checkin : Form
    {
        public Checkin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void Checkout_Click(object sender, EventArgs e)
        {
            Checkout frm4 = new Checkout();
            frm4.Show();
            this.Close();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void rut_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Buscador_Click(object sender, EventArgs e)
        {
            //Conexion con bd
            string id_reserva;
            id_reserva = rut.Text;
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
            String nombre = "SELECT reserva.abono_reserva as reservabono, reserva.total_reserva as total ,concat(usuario.nombre_usuario, ' ' , usuario.apellido_usuario) as nombre, usuario.rut_usuario as rut, habitacion.numero_hab as numero_hab, Concat(\"Servicio contratados:\", ' ', servicios.nombre_serv, ', tour contratado: ', tour.nombre_tour)  as servicios \r\nFROM RESERVA INNER JOIN usuario ON reserva.id_usuario = usuario.id_usuario INNER JOIN habitacion ON reserva.id_habitacion = habitacion.id_habitacion INNER JOIN servicios on reserva.id_servicio = servicios.id_servicio INNER JOIN transporte ON reserva.id_transporte = reserva.id_transporte INNER JOIN tour ON reserva.id_tour = tour.id_tour WHERE reserva.id_reserva =" + id_reserva + " and reserva.estado_reserva = 'Pendiente' GROUP by usuario.nombre_usuario, usuario.apellido_usuario, usuario.rut_usuario;";
            //Se establece la comunicacion con la bd y posteriormente la consulta
            MySqlCommand cmd = new MySqlCommand(nombre, con);
            //Se retiran los datos de la Query en la variable Read
            MySqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                read.Read();
                textBox1.Text = read["nombre"].ToString();
                textBox2.Text = rut.Text;
                textBox3.Text = read["servicios"].ToString();
                textBox4.Text = read["numero_hab"].ToString();
                Abono_ini.Text = read["reservabono"].ToString();
                Total.Text = read["Total"].ToString();
            }
            else
            {
                MessageBox.Show("Datos no coincidentes, revisar datos o ver reserva manualmente");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            string id_reserva;
            id_reserva = rut.Text;
            string checkin;
            checkin = dateTimePicker2.Text;
            string Abono;
            Abono = Abono_check.Text;
            MySqlConnection con2 = new MySqlConnection("server = 127.0.0.1; Database = turismo; User iD = root; Password=;");
            try
            {
                //Si conecta
                con2.Open();
            }
            catch (MySqlException ex)
            {
                //Si no conecta mostrar siguiente mensaje
                MessageBox.Show("error" + ex.ToString());
                throw;
            }
            String update = "UPDATE reserva SET reserva.Estado_reserva = 'Ingresado', reserva.check_in = '"+checkin+"', reserva.abono_checkin ='"+Abono+"' WHERE reserva.id_reserva = 107;";
            MySqlCommand cmd2 = new MySqlCommand(update, con2);
            //Se retiran los datos de la Query en la variable Read
            MySqlDataReader read2 = cmd2.ExecuteReader();
            MessageBox.Show("Ingreso de checkin, correcto fecha registrada: " + checkin);
            ReservarPDF();
        }

        private void ReservarPDF()
        {
            string reserva;
            reserva = rut.Text;
            PdfWriter pdfWriter = new PdfWriter("CheckinCompr.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.A4);

            documento.SetMargins(60, 20, 55, 20);
            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var parrafo = new Paragraph("CheckIn de: " + textBox1);
            string[] columnas = { "Nombre", "Fecha ingreso","Abono en check-in", "Abono de reserva" ,"Total" , "Habitacion", "Servicios" };
            float[] tamanios = { 4, 4, 4, 4, 4, 2, 10 };
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));
            foreach (string columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));

            }

            string check_compr = "SELECT reserva.abono_checkin as checkinabono, reserva.abono_reserva as reservabono, reserva.total_reserva as total ,concat(usuario.nombre_usuario, ' ' , usuario.apellido_usuario) as nombreCompleto, reserva.check_in as fecha_ingreso ,habitacion.numero_hab as numero_hab, Concat('Servicio contratados:', ' ', servicios.nombre_serv, ', tour contratado: ', tour.nombre_tour)  as servicios FROM RESERVA INNER JOIN usuario ON reserva.id_usuario = usuario.id_usuario INNER JOIN  habitacion ON reserva.id_habitacion = habitacion.id_habitacion INNER JOIN servicios on reserva.id_servicio = servicios.id_servicio INNER JOIN transporte ON reserva.id_transporte = reserva.id_transporte INNER JOIN tour ON reserva.id_tour = tour.id_tour WHERE reserva.id_reserva = "+ reserva +" and reserva.estado_reserva = 'Ingresado' GROUP by usuario.nombre_usuario, usuario.apellido_usuario, usuario.rut_usuario;";
            MySqlConnection con3 = new MySqlConnection("server = 127.0.0.1; Database = turismo; User iD = root; Password=;");
            con3.Open();
            MySqlCommand c = new MySqlCommand(check_compr, con3);
            MySqlDataReader reader3 = c.ExecuteReader();

            documento.Add(new Paragraph(""));
            documento.Add(new Paragraph("Estimado/a "+textBox1.Text+";"));
            documento.Add(new Paragraph("Por favor confirmar informacion, y posteriormente firmar"));
            if (reader3.Read())
            {
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["nombreCompleto"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["fecha_ingreso"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["checkinabono"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["reservabono"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["total"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["numero_hab"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["servicios"].ToString()).SetFont(fontContenido)));
            }
            documento.Add(tabla);
            documento.Add(new Paragraph(""));
            documento.Add(new Paragraph(""));
            documento.Add(new Paragraph(""));
            documento.Add(new Paragraph(""));
            documento.Add(new Paragraph("Firma de "+textBox1.Text+":  _________________________"));
            documento.Close();

            var logo = new iText.Layout.Element.Image(ImageDataFactory.Create("Logo.jpg")).SetWidth(50);
            var plogo = new Paragraph("").Add(logo);
            var titulo = new Paragraph("Check in de: " + textBox1.Text);
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(12);
            string nombre_cliente = textBox1.Text;
            var dfech = DateTime.Now.ToString("yyyy-MM-dd");
            var dhora = DateTime.Now.ToString("hh:mm:ss");
            var fecha = new Paragraph("Fecha: " + dfech + "\nhora: " + dhora);
            fecha.SetFontSize(12);

            PdfDocument pdfDoc = new PdfDocument(new PdfReader("CheckinCompr.pdf"), new PdfWriter("Checkintde"+textBox1.Text+".pdf"));
            Document doc = new Document(pdfDoc);

            int numeros = pdfDoc.GetNumberOfPages();
            for (int i = 1; i <= numeros; i++)
            {
                PdfPage pagina = pdfDoc.GetPage(i);
                float y = (pdfDoc.GetPage(i).GetPageSize().GetTop() - 15);
                doc.ShowTextAligned(plogo, 40, y,i,TextAlignment.CENTER,VerticalAlignment.TOP,0);
                doc.ShowTextAligned(titulo, 150, y-15, i,TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(fecha, 520, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                doc.ShowTextAligned(new Paragraph(String.Format("Pagina{0} de {1}", i, numeros)), pdfDoc.GetPage(i).GetPageSize().GetWidth() / 2, pdfDoc.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            }
            doc.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
