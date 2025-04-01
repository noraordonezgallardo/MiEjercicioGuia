namespace PinturilloSO
{
    partial class MenuJugador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuJugador));
            this.LableNumeroConectados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BotonCerrarSesion = new System.Windows.Forms.Button();
            this.LabelTituloPrincipal = new System.Windows.Forms.Label();
            this.LabelAccederSala = new System.Windows.Forms.Label();
            this.TextUsuario = new System.Windows.Forms.TextBox();
            this.BotonAcceder = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.informacionDelJugadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuRanking = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuPartidasJugadas = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuAmigos = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelNombreUsuario = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FotoPerfil = new System.Windows.Forms.PictureBox();
            this.DataGridViewAmigos = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FotoPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAmigos)).BeginInit();
            this.SuspendLayout();
            // 
            // LableNumeroConectados
            // 
            this.LableNumeroConectados.BackColor = System.Drawing.SystemColors.HighlightText;
            this.LableNumeroConectados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LableNumeroConectados.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableNumeroConectados.Location = new System.Drawing.Point(1572, 952);
            this.LableNumeroConectados.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LableNumeroConectados.Name = "LableNumeroConectados";
            this.LableNumeroConectados.Size = new System.Drawing.Size(274, 129);
            this.LableNumeroConectados.TabIndex = 23;
            this.LableNumeroConectados.Text = "0";
            this.LableNumeroConectados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 13.84615F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1588, 847);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 84);
            this.label1.TabIndex = 22;
            this.label1.Text = "Jugadores\r\nConectados";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BotonCerrarSesion
            // 
            this.BotonCerrarSesion.AutoSize = true;
            this.BotonCerrarSesion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BotonCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BotonCerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.BotonCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BotonCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BotonCerrarSesion.Font = new System.Drawing.Font("Cooper Black", 16.06154F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonCerrarSesion.Location = new System.Drawing.Point(18, 1036);
            this.BotonCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BotonCerrarSesion.Name = "BotonCerrarSesion";
            this.BotonCerrarSesion.Size = new System.Drawing.Size(416, 58);
            this.BotonCerrarSesion.TabIndex = 21;
            this.BotonCerrarSesion.Text = "CERRAR SESION";
            this.BotonCerrarSesion.UseVisualStyleBackColor = true;
            this.BotonCerrarSesion.Click += new System.EventHandler(this.BotonCerrarSesion_Click);
            // 
            // LabelTituloPrincipal
            // 
            this.LabelTituloPrincipal.AutoSize = true;
            this.LabelTituloPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.LabelTituloPrincipal.Font = new System.Drawing.Font("Cooper Black", 64.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTituloPrincipal.Location = new System.Drawing.Point(636, 53);
            this.LabelTituloPrincipal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelTituloPrincipal.Name = "LabelTituloPrincipal";
            this.LabelTituloPrincipal.Size = new System.Drawing.Size(1208, 199);
            this.LabelTituloPrincipal.TabIndex = 12;
            this.LabelTituloPrincipal.Text = "PinturilloSO";
            // 
            // LabelAccederSala
            // 
            this.LabelAccederSala.AutoSize = true;
            this.LabelAccederSala.BackColor = System.Drawing.Color.Transparent;
            this.LabelAccederSala.Font = new System.Drawing.Font("Cooper Black", 43.75385F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAccederSala.Location = new System.Drawing.Point(674, 438);
            this.LabelAccederSala.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelAccederSala.Name = "LabelAccederSala";
            this.LabelAccederSala.Size = new System.Drawing.Size(913, 134);
            this.LabelAccederSala.TabIndex = 24;
            this.LabelAccederSala.Text = "Código de Sala";
            // 
            // TextUsuario
            // 
            this.TextUsuario.Font = new System.Drawing.Font("Comic Sans MS", 16.06154F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextUsuario.Location = new System.Drawing.Point(698, 584);
            this.TextUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextUsuario.Name = "TextUsuario";
            this.TextUsuario.Size = new System.Drawing.Size(874, 67);
            this.TextUsuario.TabIndex = 25;
            this.TextUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BotonAcceder
            // 
            this.BotonAcceder.AutoSize = true;
            this.BotonAcceder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BotonAcceder.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BotonAcceder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.BotonAcceder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BotonAcceder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BotonAcceder.Font = new System.Drawing.Font("Cooper Black", 19.93846F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonAcceder.Location = new System.Drawing.Point(1023, 669);
            this.BotonAcceder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BotonAcceder.Name = "BotonAcceder";
            this.BotonAcceder.Size = new System.Drawing.Size(264, 71);
            this.BotonAcceder.TabIndex = 26;
            this.BotonAcceder.Text = "Acceder";
            this.BotonAcceder.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacionDelJugadorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1862, 48);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // informacionDelJugadorToolStripMenuItem
            // 
            this.informacionDelJugadorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuRanking,
            this.StripMenuPartidasJugadas,
            this.StripMenuAmigos});
            this.informacionDelJugadorToolStripMenuItem.Font = new System.Drawing.Font("Cooper Black", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.informacionDelJugadorToolStripMenuItem.Name = "informacionDelJugadorToolStripMenuItem";
            this.informacionDelJugadorToolStripMenuItem.Size = new System.Drawing.Size(452, 42);
            this.informacionDelJugadorToolStripMenuItem.Text = "Información del Jugador";
            // 
            // StripMenuRanking
            // 
            this.StripMenuRanking.Name = "StripMenuRanking";
            this.StripMenuRanking.Size = new System.Drawing.Size(440, 46);
            this.StripMenuRanking.Text = "Ranking";
            this.StripMenuRanking.Click += new System.EventHandler(this.StripMenuRanking_Click);
            // 
            // StripMenuPartidasJugadas
            // 
            this.StripMenuPartidasJugadas.Name = "StripMenuPartidasJugadas";
            this.StripMenuPartidasJugadas.Size = new System.Drawing.Size(440, 46);
            this.StripMenuPartidasJugadas.Text = "Partidas Jugadas";
            this.StripMenuPartidasJugadas.Click += new System.EventHandler(this.StripMenuPartidasJugadas_Click);
            // 
            // StripMenuAmigos
            // 
            this.StripMenuAmigos.Name = "StripMenuAmigos";
            this.StripMenuAmigos.Size = new System.Drawing.Size(440, 46);
            this.StripMenuAmigos.Text = "Amigos";
            this.StripMenuAmigos.Click += new System.EventHandler(this.StripMenuAmigos_Click);
            // 
            // LabelNombreUsuario
            // 
            this.LabelNombreUsuario.AutoSize = true;
            this.LabelNombreUsuario.BackColor = System.Drawing.Color.Transparent;
            this.LabelNombreUsuario.Font = new System.Drawing.Font("Cooper Black", 26.03077F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNombreUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelNombreUsuario.Location = new System.Drawing.Point(18, 252);
            this.LabelNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelNombreUsuario.Name = "LabelNombreUsuario";
            this.LabelNombreUsuario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelNombreUsuario.Size = new System.Drawing.Size(315, 80);
            this.LabelNombreUsuario.TabIndex = 28;
            this.LabelNombreUsuario.Text = "Usuario";
            this.LabelNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FotoPerfil
            // 
            this.FotoPerfil.Image = ((System.Drawing.Image)(resources.GetObject("FotoPerfil.Image")));
            this.FotoPerfil.Location = new System.Drawing.Point(45, 81);
            this.FotoPerfil.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FotoPerfil.Name = "FotoPerfil";
            this.FotoPerfil.Size = new System.Drawing.Size(266, 166);
            this.FotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FotoPerfil.TabIndex = 29;
            this.FotoPerfil.TabStop = false;
            // 
            // DataGridViewAmigos
            // 
            this.DataGridViewAmigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewAmigos.Location = new System.Drawing.Point(18, 377);
            this.DataGridViewAmigos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DataGridViewAmigos.Name = "DataGridViewAmigos";
            this.DataGridViewAmigos.RowHeadersWidth = 56;
            this.DataGridViewAmigos.RowTemplate.Height = 24;
            this.DataGridViewAmigos.Size = new System.Drawing.Size(440, 645);
            this.DataGridViewAmigos.TabIndex = 30;
            // 
            // MenuJugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1862, 1123);
            this.Controls.Add(this.DataGridViewAmigos);
            this.Controls.Add(this.FotoPerfil);
            this.Controls.Add(this.LabelNombreUsuario);
            this.Controls.Add(this.BotonAcceder);
            this.Controls.Add(this.TextUsuario);
            this.Controls.Add(this.LabelAccederSala);
            this.Controls.Add(this.LableNumeroConectados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BotonCerrarSesion);
            this.Controls.Add(this.LabelTituloPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MenuJugador";
            this.Text = "MenuJugador";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FotoPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAmigos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LableNumeroConectados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BotonCerrarSesion;
        private System.Windows.Forms.Label LabelTituloPrincipal;
        private System.Windows.Forms.Label LabelAccederSala;
        private System.Windows.Forms.TextBox TextUsuario;
        private System.Windows.Forms.Button BotonAcceder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem informacionDelJugadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StripMenuRanking;
        private System.Windows.Forms.ToolStripMenuItem StripMenuPartidasJugadas;
        private System.Windows.Forms.ToolStripMenuItem StripMenuAmigos;
        private System.Windows.Forms.Label LabelNombreUsuario;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox FotoPerfil;
        private System.Windows.Forms.DataGridView DataGridViewAmigos;
    }
}