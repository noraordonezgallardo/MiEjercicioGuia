namespace VERSION1._1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nombreusuario = new TextBox();
            correo = new TextBox();
            contrasena = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BotonAceptar = new Button();
            botonconectar = new Button();
            botondesconectar = new Button();
            SuspendLayout();
            // 
            // nombreusuario
            // 
            nombreusuario.Location = new Point(445, 92);
            nombreusuario.Name = "nombreusuario";
            nombreusuario.Size = new Size(150, 31);
            nombreusuario.TabIndex = 0;
            // 
            // correo
            // 
            correo.Location = new Point(450, 185);
            correo.Name = "correo";
            correo.Size = new Size(150, 31);
            correo.TabIndex = 1;
            // 
            // contrasena
            // 
            contrasena.Location = new Point(447, 272);
            contrasena.Name = "contrasena";
            contrasena.Size = new Size(150, 31);
            contrasena.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(236, 92);
            label1.Name = "label1";
            label1.Size = new Size(166, 25);
            label1.TabIndex = 3;
            label1.Text = "NOMBRE USUARIO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 185);
            label2.Name = "label2";
            label2.Size = new Size(201, 25);
            label2.TabIndex = 4;
            label2.Text = "CORREO ELECTRÓNICO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(250, 275);
            label3.Name = "label3";
            label3.Size = new Size(126, 25);
            label3.TabIndex = 5;
            label3.Text = "CONTRASEÑA";
            // 
            // BotonAceptar
            // 
            BotonAceptar.Location = new Point(571, 334);
            BotonAceptar.Name = "BotonAceptar";
            BotonAceptar.Size = new Size(112, 34);
            BotonAceptar.TabIndex = 6;
            BotonAceptar.Text = "Aceptar";
            BotonAceptar.UseVisualStyleBackColor = true;
            BotonAceptar.Click += BotonAceptar_Click;
            // 
            // botonconectar
            // 
            botonconectar.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            botonconectar.Location = new Point(25, 176);
            botonconectar.Name = "botonconectar";
            botonconectar.Size = new Size(170, 34);
            botonconectar.TabIndex = 7;
            botonconectar.Text = "CONECTAR";
            botonconectar.UseVisualStyleBackColor = true;
            botonconectar.Click += botonconectar_Click;
            // 
            // botondesconectar
            // 
            botondesconectar.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            botondesconectar.Location = new Point(25, 240);
            botondesconectar.Name = "botondesconectar";
            botondesconectar.Size = new Size(170, 34);
            botondesconectar.TabIndex = 8;
            botondesconectar.Text = "DESCONECTAR";
            botondesconectar.UseVisualStyleBackColor = true;
            botondesconectar.Click += botondesconectar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(botondesconectar);
            Controls.Add(botonconectar);
            Controls.Add(BotonAceptar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(contrasena);
            Controls.Add(correo);
            Controls.Add(nombreusuario);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nombreusuario;
        private TextBox correo;
        private TextBox contrasena;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button BotonAceptar;
        private Button botonconectar;
        private Button botondesconectar;
    }
}
