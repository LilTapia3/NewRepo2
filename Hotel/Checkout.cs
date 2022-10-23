using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Buscador_Click(object sender, EventArgs e)
        {
            string usuario;
            usuario = rut.Text;
            MySqlConnection con = new MySqlConnection("server = 127.0.0.1; Database = turismo; User iD = root; Password=;");
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error" + ex.ToString());
                throw;
            }
            String nombre = "SELECT date_format(check_in,'%Y-%m-%d') as check_in,concat(usuario.nombre_usuario, ' ' , usuario.apellido_usuario) as nombre,usuario.rut_usuario as rut, date_format(reserva.Fech_Entr, '%Y-%m-%d') as fecha_entrada , habitacion.numero_hab as numero_hab, servicios.nombre_serv as servicios FROM reserva INNER JOIN usuario on reserva.id_usuario = usuario.id_usuario INNER JOIN habitacion on reserva.id_habitacion = habitacion.id_habitacion INNER JOIN servicios on reserva.id_servicio = servicios.id_servicio  WHERE usuario.rut_usuario= '" + usuario + "';";
            MySqlCommand cmd = new MySqlCommand(nombre, con);
            MySqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                read.Read();
                textBox1.Text = read["nombre"].ToString();
                textBox2.Text = rut.Text;
                textBox3.Text = read["servicios"].ToString();
                textBox4.Text = read["numero_hab"].ToString();
                textBox5.Text = read["fecha_entrada"].ToString();
                textBox6.Text = read["check_in"].ToString();

            }
            else
            {
                MessageBox.Show("Datos no coincidentes, revisar datos o ver reserva manualmente");
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            string usuario;
            usuario = rut.Text;
            string checkout;
            checkout = dateTimePicker2.Text;
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
            String update = "UPDATE reserva INNER JOIN usuario on reserva.id_usuario = usuario.id_usuario SET reserva.Estado_reserva = 'Terminado', reserva.check_out ='"+checkout+"' WHERE usuario.rut_usuario ='"+usuario+"';";
            MySqlCommand cmd2 = new MySqlCommand(update, con2);
            //Se retiran los datos de la Query en la variable Read
            MySqlDataReader read2 = cmd2.ExecuteReader();
            MessageBox.Show("Ingreso de checkout, correcto fecha registrada: " + checkout);
            GenerarPdf();
        }

        public void GenerarPdf()
        {
            string usuario;
            usuario = rut.Text;
            PdfWriter pdfWriter = new PdfWriter("CheckoutCompr.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.A4);

            documento.SetMargins(60, 20, 55, 20);
            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var parrafo = new Paragraph("CheckOut de: " + textBox1);
            string[] columnas = { "Nombre", "Fecha ingreso", "Cantidad dias", "Fecha salida" ,"Habitacion", "Hotel", "Servicios" };
            float[] tamanios = { 4, 4, 2, 4, 2, 6, 10 };
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));
            foreach (string columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));

            }

            string check_compr = "SELECT concat(usuario.nombre_usuario, ' ' , usuario.apellido_usuario) as nombreCompleto ,reserva.dias_estadia as dias_estadia, date_format(reserva.check_out, '%Y-%m-%d') as fecha_egreso ,date_format(reserva.check_in, '%Y-%m-%d') as fecha_ingreso , habitacion.numero_hab as habitacion, departamento.nombre_dep as hotel,servicios.nombre_serv as SERVICIOS FROM reserva INNER JOIN usuario on reserva.id_usuario = usuario.id_usuario INNER JOIN habitacion on reserva.id_habitacion = habitacion.id_habitacion INNER JOIN servicios on reserva.id_servicio = servicios.id_servicio  INNER JOIN departamento on habitacion.id_departamento = departamento.id_departamento WHERE usuario.rut_usuario = '" + usuario + "'; ";
            MySqlConnection con3 = new MySqlConnection("server = 127.0.0.1; Database = turismo; User iD = root; Password=;");
            con3.Open();
            MySqlCommand c = new MySqlCommand(check_compr, con3);
            MySqlDataReader reader3 = c.ExecuteReader();

            documento.Add(new Paragraph(""));
            documento.Add(new Paragraph("Estimado/a " + textBox1.Text + ";"));
            documento.Add(new Paragraph("Por favor confirmar informacion, y posteriormente firmar la salida del hotel."));
            if (reader3.Read())
            {
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["nombreCompleto"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["fecha_ingreso"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["dias_estadia"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["fecha_egreso"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["habitacion"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["hotel"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader3["SERVICIOS"].ToString()).SetFont(fontContenido)));
            }
            documento.Add(tabla);
            documento.Add(new Paragraph(""));
            documento.Add(new Paragraph(""));
            documento.Add(new Paragraph(""));
            documento.Add(new Paragraph(""));
            documento.Add(new Paragraph("Firma de " + textBox1.Text + ":  _________________________"));
            documento.Close();

            var logo = new iText.Layout.Element.Image(ImageDataFactory.Create("Logo.jpg")).SetWidth(50);
            var plogo = new Paragraph("").Add(logo);
            var titulo = new Paragraph("Check out de: " + textBox1.Text);
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(12);
            string nombre_cliente = textBox1.Text;
            var dfech = DateTime.Now.ToString("yyyy-MM-dd");
            var dhora = DateTime.Now.ToString("hh:mm:ss");
            var fecha = new Paragraph("Fecha: " + dfech + "\nhora: " + dhora);
            fecha.SetFontSize(12);

            PdfDocument pdfDoc = new PdfDocument(new PdfReader("CheckoutCompr.pdf"), new PdfWriter("Checkoutde" + textBox1.Text + ".pdf"));
            Document doc = new Document(pdfDoc);

            int numeros = pdfDoc.GetNumberOfPages();
            for (int i = 1; i <= numeros; i++)
            {
                PdfPage pagina = pdfDoc.GetPage(i);
                float y = (pdfDoc.GetPage(i).GetPageSize().GetTop() - 15);
                doc.ShowTextAligned(plogo, 40, y, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(titulo, 150, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(fecha, 520, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                doc.ShowTextAligned(new Paragraph(String.Format("Pagina{0} de {1}", i, numeros)), pdfDoc.GetPage(i).GetPageSize().GetWidth() / 2, pdfDoc.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            }
            doc.Close();
        }
    }
    
    
}
