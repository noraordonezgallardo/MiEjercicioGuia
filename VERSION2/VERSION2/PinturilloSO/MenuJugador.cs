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

namespace PinturilloSO
{
    public partial class MenuJugador: Form
    {
        string Usuario;
        Socket Servidor;
        bool FormAbierto = false;

        private System.Windows.Forms.Timer timer;

        public MenuJugador(string Usuario, Socket Servidor = null)
        {
            InitializeComponent();
            this.Usuario = Usuario;
            this.Servidor = Servidor;
            this.AcceptButton = BotonAcceder;
            this.LabelNombreUsuario.Text = Usuario;

            FormAbierto = true;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (FormAbierto)
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

        private void StripMenuRanking_Click(object sender, EventArgs e)
        {
            string mensaje = "3/1/" + Usuario;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Servidor.Send(msg);

            byte[] msg2 = new byte[80];
            Servidor.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            string[] partes = mensaje.Split('/');
            int TipoMensaje = Convert.ToInt32(partes[1]);
            mensaje = string.Join("/", partes.Skip(2));

            MessageBox.Show("Posicion Ranking: " + mensaje);
        }

        private void StripMenuPartidasJugadas_Click(object sender, EventArgs e)
        {
            string mensaje = "3/2/" + Usuario;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Servidor.Send(msg);

            byte[] msg2 = new byte[80];
            Servidor.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            string[] partes = mensaje.Split('/');
            int TipoMensaje = Convert.ToInt32(partes[1]);
            mensaje = string.Join("/", partes.Skip(2));

            MessageBox.Show("Partidas Jugadas: " + mensaje);
        }

        private void StripMenuAmigos_Click(object sender, EventArgs e)
        {
            string mensaje = "3/3/" + Usuario;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Servidor.Send(msg);

            byte[] msg2 = new byte[80];
            Servidor.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            string[] partes = mensaje.Split('/');
            int TipoMensaje = Convert.ToInt32(partes[1]);
            mensaje = string.Join("\n\t", partes.Skip(2));

            MessageBox.Show("Amigos: \n\t" + mensaje);
        }

        private void BotonCerrarSesion_Click(object sender, EventArgs e)
        {
            string mensaje = "99/0/" + Usuario;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Servidor.Send(msg);

            FormAbierto = false;
            this.Close();
        }
    }
}
