namespace PinturilloSO
{
    partial class SalaPartida
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
            this.BotonDesconectar = new System.Windows.Forms.Button();
            this.LabelTituloPrincipal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BotonDesconectar
            // 
            this.BotonDesconectar.AutoSize = true;
            this.BotonDesconectar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BotonDesconectar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BotonDesconectar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.BotonDesconectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BotonDesconectar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BotonDesconectar.Font = new System.Drawing.Font("Cooper Black", 16.06154F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonDesconectar.Location = new System.Drawing.Point(90, 664);
            this.BotonDesconectar.Name = "BotonDesconectar";
            this.BotonDesconectar.Size = new System.Drawing.Size(405, 44);
            this.BotonDesconectar.TabIndex = 21;
            this.BotonDesconectar.Text = "ABANDONAR PARTIDA";
            this.BotonDesconectar.UseVisualStyleBackColor = true;
            // 
            // LabelTituloPrincipal
            // 
            this.LabelTituloPrincipal.AutoSize = true;
            this.LabelTituloPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.LabelTituloPrincipal.Font = new System.Drawing.Font("Cooper Black", 48.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTituloPrincipal.Location = new System.Drawing.Point(12, 9);
            this.LabelTituloPrincipal.Name = "LabelTituloPrincipal";
            this.LabelTituloPrincipal.Size = new System.Drawing.Size(608, 100);
            this.LabelTituloPrincipal.TabIndex = 12;
            this.LabelTituloPrincipal.Text = "PinturilloSO";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(29, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 465);
            this.panel1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 23.81538F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(491, 51);
            this.label1.TabIndex = 23;
            this.label1.Text = "Las palabras van aquí";
            // 
            // SalaPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 720);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BotonDesconectar);
            this.Controls.Add(this.LabelTituloPrincipal);
            this.Name = "SalaPartida";
            this.Text = "SalaPartida";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BotonDesconectar;
        private System.Windows.Forms.Label LabelTituloPrincipal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}