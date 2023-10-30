using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Clinica_Dental
{
    public partial class Central : Form
    {

        string IdOriginal;
        IFirebaseConfig config = new FirebaseConfig
        {

            AuthSecret = "6VrSeH4nDLoD0aLyaM7gynA5YpRLDnMmDzuUXj9D",
            BasePath = "https://clinicadentalmelara.firebaseio.com/"

            //AuthSecret = "4Z8eZHmcJ9G1mbPqj4Qp9D7rA1eSz5oFlW4jBjHy",
            //BasePath = "https://pruebaclinicaunica.firebaseio.com/"



        };
        IFirebaseClient client;

        private async void CitasDeHoy()
        {
            String FechaActual = DateTime.Today.ToString("MM/dd/yyyy");
            DataClient.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("Contador/nodo");
            Contador obj1 = resp1.ResultAs<Contador>();
            int cnt = Convert.ToInt32(obj1.cnt);

            //MessageBox.Show(cnt.ToString());

            while (true)
            {
                if (i == cnt)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetTaskAsync("citas/" + i);
                    citasE obj2 = resp2.ResultAs<citasE>();

                    if (obj2.Fecha == FechaActual)
                    {
                        DataClient.Rows.Add(obj2.Nombre, obj2.Telefono, obj2.Tipo_consulta, obj2.Doctor,obj2.Hora,obj2.HoraFin,obj2.Justificacion);
                    }
                }
                catch
                {
                }


            }
        }

        public Central()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TiempoFecha_Tick(object sender, EventArgs e)
        {
            lbl_tiempo.Text = DateTime.Now.ToLongTimeString();
            lbl_fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void Central_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch { MessageBox.Show("Ocurrió un error con la conexión"); }
            CitasDeHoy();
        }

        //private async void CitasDeHoy()
        //{

        //}
    }
}
