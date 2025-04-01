using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PinturilloSO;

namespace PinturilloSO
{
    public partial class CrearUsuario: Form
    {
        Socket Servidor;
        bool ConexionEstablecida = false;
        bool ContrasenaOculta = true;
        string ContrasenaEscrita = "";
        public CrearUsuario(bool ConexionEstablecida, Socket Servidor = null)
        {
            InitializeComponent();
            this.Servidor = Servidor;
            this.ConexionEstablecida = ConexionEstablecida;
            this.AcceptButton = BotonCrear;

            BotonOcultarContrasena.BackgroundImage = System.Drawing.Image.FromFile(@"VerContrasena.png");
            BotonOcultarContrasena.BackgroundImageLayout = ImageLayout.Stretch;

            if (ConexionEstablecida)
            {
                PanelImagenConexion.BackgroundImage = System.Drawing.Image.FromFile(@"Conectado.png");
                PanelImagenConexion.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                PanelImagenConexion.BackgroundImage = System.Drawing.Image.FromFile(@"Desconectado.png");
                PanelImagenConexion.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void BotonCrear_Click(object sender, EventArgs e)
        {
            if (!ConexionEstablecida)
            {
                MessageBox.Show("No se ha establecido conexion con el servidor.");
            }
            else
            {
                string Correo = TextCorreoElectronico.Text;
                string Usuario = TextUsuario.Text;
                string Contrasena = TextContrasena.Text;

                if (Correo == "" || Usuario == "" || Contrasena == "")
                {
                    MessageBox.Show("Por favor, rellene todos los campos.");
                }
                else
                {
                    string mensaje = "1/" + Correo + "/" + Usuario + "/" + Contrasena;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Servidor.Send(msg);

                    byte[] msg2 = new byte[80];
                    Servidor.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    string[] partes = mensaje.Split('/');
                    int TipoMensaje = Convert.ToInt32(partes[1]);
                    mensaje = string.Join("/", partes.Skip(2));
                    MessageBox.Show(mensaje);

                    if (TipoMensaje == 0)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void BotonMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextContrasena_TextChanged(object sender, EventArgs e)
        {
            if (ContrasenaOculta)
            {
                TextContrasena.TextChanged -= TextContrasena_TextChanged;
                if (TextContrasena.Text.Length > ContrasenaEscrita.Length)
                {
                    ContrasenaEscrita += TextContrasena.Text.Substring(ContrasenaEscrita.Length);
                }
                else if (TextContrasena.Text.Length < ContrasenaEscrita.Length)
                {
                    ContrasenaEscrita = ContrasenaEscrita.Substring(0, TextContrasena.Text.Length);
                }
                TextContrasena.Text = new String('*', ContrasenaEscrita.Length);
                TextContrasena.SelectionStart = TextContrasena.Text.Length;
                TextContrasena.TextChanged += TextContrasena_TextChanged;
            }
            else
            {
                ContrasenaEscrita = TextContrasena.Text;
            }
        }

        private void BotonOcultarContrasena_Click(object sender, EventArgs e)
        {
            ContrasenaOculta = !ContrasenaOculta;

            if (ContrasenaOculta)
            {
                TextContrasena.Text = new String('*', ContrasenaEscrita.Length);
                BotonOcultarContrasena.BackgroundImage = System.Drawing.Image.FromFile(@"VerContrasena.png");
                BotonOcultarContrasena.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                TextContrasena.Text = ContrasenaEscrita;
                BotonOcultarContrasena.BackgroundImage = System.Drawing.Image.FromFile(@"OcultarContrasena.png");
                BotonOcultarContrasena.BackgroundImageLayout = ImageLayout.Stretch;
            }
            TextContrasena.SelectionStart = TextContrasena.Text.Length;
        }
    }
}
