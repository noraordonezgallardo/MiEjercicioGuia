using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace PinturilloSO
{
    public partial class MenuInicio : Form
    {
        Socket Servidor;
        Thread atender;

        string Correo;
        string Usuario;
        string Contrasena;

        bool ConexionEstablecida = false;
        bool ContrasenaOculta = true;
        string ContrasenaEscrita = "";

        private System.Windows.Forms.Timer timer;

        public MenuInicio(Socket Servidor = null)
        {
            InitializeComponent();
            this.Servidor = Servidor;
            this.AcceptButton = BotonAceptar;

            PanelImagenConexion.BackgroundImage = System.Drawing.Image.FromFile(@"Desconectado.png");
            PanelImagenConexion.BackgroundImageLayout = ImageLayout.Stretch;
            BotonOcultarContrasena.BackgroundImage = System.Drawing.Image.FromFile(@"VerContrasena.png");
            BotonOcultarContrasena.BackgroundImageLayout = ImageLayout.Stretch;
            BotonAyuda.BackgroundImage = System.Drawing.Image.FromFile(@"Ayuda.png");
            BotonAyuda.BackgroundImageLayout = ImageLayout.Stretch;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ConexionEstablecida)
            {
                string mensaje = "99/99/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Servidor.Send(msg);

                byte[] msg2 = new byte[80];
                Servidor.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] partes = mensaje.Split('/');
                int TipoMensaje = Convert.ToInt32(partes[1]);
                mensaje = string.Join("/", partes.Skip(2));

                LableNumeroConectados.Text = mensaje;
            }
        }

        private void BotonConectar_Click(object sender, EventArgs e)
        {
            if (!ConexionEstablecida)
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse("192.168.56.102");
                IPEndPoint ipep = new IPEndPoint(direc, 9050);


                //Creamos el socket 
                Servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    Servidor.Connect(ipep);//Intentamos conectar el socket
                    LabelConexion.Text = "Conectado";
                    ConexionEstablecida = true;

                    PanelImagenConexion.BackgroundImage = System.Drawing.Image.FromFile(@"Conectado.png");
                    PanelImagenConexion.BackgroundImageLayout = ImageLayout.Stretch;

                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show($"No he podido conectar con el servidor.");
                    return;
                }
            }
        }

        private void BotonDesconectar_Click(object sender, EventArgs e)
        {
            if (ConexionEstablecida)
            {
                //Mensaje de desconexión
                string mensaje = "0/";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Servidor.Send(msg);

                // Nos desconectamos
                Servidor.Shutdown(SocketShutdown.Both);
                Servidor.Close();
                LabelConexion.Text = "Desconectado";
                ConexionEstablecida = false;
                PanelImagenConexion.BackgroundImage = System.Drawing.Image.FromFile(@"Desconectado.png");
                PanelImagenConexion.BackgroundImageLayout = ImageLayout.Stretch;

                LableNumeroConectados.Text = "0";
            }
        }

        private void BotonCrearUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            CrearUsuario CrearUsuarioForm = new CrearUsuario(ConexionEstablecida, Servidor);
            CrearUsuarioForm.ShowDialog();
            this.Show();
        }

        private void BotonAceptar_Click(object sender, EventArgs e)
        {
            if (TextUsuario.Text == "" || TextContrasena.Text == "")
            {
                MessageBox.Show("Por favor, rellene todos los campos.");
            }
            else 
            {
                if (!ConexionEstablecida)
                {
                    MessageBox.Show("No se ha establecido conexion con el servidor.");
                }
                else 
                {
                    Usuario = TextUsuario.Text;

                    if (ContrasenaOculta)
                    {
                        Contrasena = ContrasenaEscrita;
                    }
                    else
                    {
                        Contrasena = TextContrasena.Text;
                    }

                    string mensaje = "2/" + Usuario + "/" + Contrasena;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Servidor.Send(msg);

                    byte[] msg2 = new byte[80];
                    Servidor.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    string[] partes = mensaje.Split('/');
                    int TipoMensaje = Convert.ToInt32(partes[1]);
                    mensaje = string.Join("/", partes.Skip(2));

                    if (TipoMensaje == 0)
                    {
                        this.Hide();
                        MenuJugador MenuJugadorForm = new MenuJugador(TextUsuario.Text, Servidor);

                        mensaje = "99/1/" + Usuario;
                        byte[] msg3 = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        Servidor.Send(msg3);

                        MenuJugadorForm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
            }
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