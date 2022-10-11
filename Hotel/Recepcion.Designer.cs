namespace Hotel
{
    partial class Recepcion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Inicio = new System.Windows.Forms.Button();
            this.Checkin = new System.Windows.Forms.Button();
            this.Checkout = new System.Windows.Forms.Button();
            this.Ventas = new System.Windows.Forms.Button();
            this.Logout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Inicio
            // 
            this.Inicio.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Inicio.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Inicio.Location = new System.Drawing.Point(12, 38);
            this.Inicio.Margin = new System.Windows.Forms.Padding(0);
            this.Inicio.Name = "Inicio";
            this.Inicio.Size = new System.Drawing.Size(122, 45);
            this.Inicio.TabIndex = 0;
            this.Inicio.Text = "Inicio";
            this.Inicio.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Inicio.UseVisualStyleBackColor = false;
            this.Inicio.Click += new System.EventHandler(this.Inicio_Click);
            // 
            // Checkin
            // 
            this.Checkin.Location = new System.Drawing.Point(13, 90);
            this.Checkin.Name = "Checkin";
            this.Checkin.Size = new System.Drawing.Size(122, 45);
            this.Checkin.TabIndex = 1;
            this.Checkin.Text = "Check-in";
            this.Checkin.UseVisualStyleBackColor = true;
            this.Checkin.Click += new System.EventHandler(this.Checkin_Click);
            // 
            // Checkout
            // 
            this.Checkout.Location = new System.Drawing.Point(13, 141);
            this.Checkout.Name = "Checkout";
            this.Checkout.Size = new System.Drawing.Size(122, 45);
            this.Checkout.TabIndex = 2;
            this.Checkout.Text = "Check-out";
            this.Checkout.UseVisualStyleBackColor = true;
            this.Checkout.Click += new System.EventHandler(this.Checkout_Click);
            // 
            // Ventas
            // 
            this.Ventas.Location = new System.Drawing.Point(13, 192);
            this.Ventas.Name = "Ventas";
            this.Ventas.Size = new System.Drawing.Size(122, 45);
            this.Ventas.TabIndex = 3;
            this.Ventas.Text = "Ventas";
            this.Ventas.UseVisualStyleBackColor = true;
            this.Ventas.Click += new System.EventHandler(this.Ventas_Click);
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.IndianRed;
            this.Logout.Location = new System.Drawing.Point(13, 592);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(122, 45);
            this.Logout.TabIndex = 4;
            this.Logout.Text = "Salir";
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(120, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 599);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hotel.Properties.Resources.icono_simple_linear_del_hotel_de_lujo_con_las_estrellas_109534363;
            this.pictureBox1.Location = new System.Drawing.Point(101, -111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(840, 661);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Recepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.Ventas);
            this.Controls.Add(this.Checkout);
            this.Controls.Add(this.Checkin);
            this.Controls.Add(this.Inicio);
            this.MaximizeBox = false;
            this.Name = "Recepcion";
            this.Text = "Recepcion";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Inicio;
        private System.Windows.Forms.Button Checkin;
        private System.Windows.Forms.Button Checkout;
        private System.Windows.Forms.Button Ventas;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}