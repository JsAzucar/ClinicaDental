using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Clinica_Dental
{
    public partial class AdminFicha : Form
    {
        DataTable dt = new DataTable();

        IFirebaseConfig config = new FirebaseConfig
        {

            AuthSecret = "6VrSeH4nDLoD0aLyaM7gynA5YpRLDnMmDzuUXj9D",
            BasePath = "https://clinicadentalmelara.firebaseio.com/"

            //AuthSecret = "4Z8eZHmcJ9G1mbPqj4Qp9D7rA1eSz5oFlW4jBjHy",
            //BasePath = "https://pruebaclinicaunica.firebaseio.com/"



        };
        IFirebaseClient client;

        public AdminFicha()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            dgvFichas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btn_verficha_Click(object sender, EventArgs e)
        {

            

        }

        private void dgvFichas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            fichasf obj = new fichasf();

                string id = dgvFichas.SelectedRows[0].Cells["ID"].Value.ToString();
                string Nombre = dgvFichas.SelectedRows[0].Cells["Nombre"].Value.ToString();
                string telefono1 = dgvFichas.SelectedRows[0].Cells["Telefono"].Value.ToString();
                string telefono2 = dgvFichas.SelectedRows[0].Cells["Telefono2"].Value.ToString();
                string Fecha_ingreso = dgvFichas.SelectedRows[0].Cells["Fecha_ingreso"].Value.ToString();
                string Direccion = dgvFichas.SelectedRows[0].Cells["Direccion"].Value.ToString();
                string Dui = dgvFichas.SelectedRows[0].Cells["Dui"].Value.ToString();
            string Edad = (dgvFichas.SelectedRows[0].Cells["Edad"].Value.ToString());

            string Email = dgvFichas.SelectedRows[0].Cells["Email"].Value.ToString();
                string Lugar_trabajo = dgvFichas.SelectedRows[0].Cells["Lugar_trabajo"].Value.ToString();
                string Informacion_adicional = dgvFichas.SelectedRows[0].Cells["Informacion_adicional"].Value.ToString();
                string Monto = dgvFichas.SelectedRows[0].Cells["Monto"].Value.ToString();
            string NombreEncargado = dgvFichas.SelectedRows[0].Cells["NombreEncargado"].Value.ToString();
            string TelefonoEncargado = dgvFichas.SelectedRows[0].Cells["TelefonoEncargado"].Value.ToString();
            string EdadEncargado = (dgvFichas.SelectedRows[0].Cells["EdadEncargado"].Value.ToString());
            string DuiEncargado = dgvFichas.SelectedRows[0].Cells["DuiEncargado"].Value.ToString();
            string DirecciónEncargado = dgvFichas.SelectedRows[0].Cells["DirecciónEncargado"].Value.ToString();
            string LugarTrEncargado = dgvFichas.SelectedRows[0].Cells["LugarTrEncargado"].Value.ToString();


            Image Imagefoto = (Image)dgvFichas.SelectedRows[0].Cells["Imagen"].Value;
                Image Imagecontrato1 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato1"].Value;
                Image Imagecontrato2 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato2"].Value;
                Image Imagecontrato3 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato3"].Value;
                Image Imagecontrato4 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato4"].Value;

                Image Radiografia1 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia1"].Value;
                Image Radiografia2 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia2"].Value;
                Image Radiografia3 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia3"].Value;
                Image Radiografia4 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia4"].Value;

            CreateFicha ir = new CreateFicha(id, Nombre, telefono1, telefono2, Fecha_ingreso, Direccion,Edad, Dui, Email, Lugar_trabajo, Informacion_adicional, Monto, NombreEncargado, TelefonoEncargado,EdadEncargado, DirecciónEncargado, DuiEncargado, LugarTrEncargado, Imagefoto, Imagecontrato1, Imagecontrato2, Imagecontrato3, Imagecontrato4, Radiografia1, Radiografia2, Radiografia3, Radiografia4);
            CreateFicha valor = new CreateFicha();

            lbpass1.Text = "sip";
            //int i;
            ir.lbpass2.Text = lbpass1.Text;
            ir.Show();





        }

        private void AdminFicha_Load(object sender, EventArgs e)
        {
            if (Tipo.Text == "Usuario")
            {
                button2.Visible = false;
            }
            DataGridViewRow row = this.dgvFichas.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Bisque;
            row.Height = 100;
            row.MinimumHeight = 100;
            

            client = new FireSharp.FirebaseClient(config);

            //if (client != null)
            //{
            //    MessageBox.Show("La coneccion esta establecida");
            //}
            //else
            //{
            //    MessageBox.Show("Hay problemas con la coneccion verifique su servidor de internet");
            //}


            dt.Columns.Add("ID");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Telefono2");
            dt.Columns.Add("Fecha_ingreso");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Edad");
            dt.Columns.Add("Dui");
            dt.Columns.Add("Email");
            dt.Columns.Add("Lugar_trabajo");
            dt.Columns.Add("Informacion_adicional");
            dt.Columns.Add("Monto");
            dt.Columns.Add("NombreEncargado");
            dt.Columns.Add("TelefonoEncargado");
            dt.Columns.Add("EdadEncargado");
            dt.Columns.Add("DuiEncargado");
            dt.Columns.Add("DirecciónEncargado");
            dt.Columns.Add("LugarTrEncargado");
            dt.Columns.Add("Imagen", typeof(Image));
            dt.Columns.Add("Contrato1", typeof(Image));
            dt.Columns.Add("Contrato2", typeof(Image));
            dt.Columns.Add("Contrato3", typeof(Image));
            dt.Columns.Add("Contrato4", typeof(Image));
            dt.Columns.Add("Radiografia1", typeof(Image));
            dt.Columns.Add("Radiografia2", typeof(Image));
            dt.Columns.Add("Radiografia3", typeof(Image));
            dt.Columns.Add("Radiografia4", typeof(Image));

            //dt.Columns.Add("ID", typeof(string));
            //dt.Columns.Add("Nombre", typeof(string));
            //dt.Columns.Add("Telefono", typeof(string));
            //dt.Columns.Add("Telefono2", typeof(string));
            //dt.Columns.Add("Fecha_ingreso", typeof(string));
            //dt.Columns.Add("Direccion", typeof(string));
            //dt.Columns.Add("Dui", typeof(string));
            //dt.Columns.Add("Email", typeof(string));
            //dt.Columns.Add("Lugar_Trabajo", typeof(string));
            //dt.Columns.Add("Informacion_adicional", typeof(string));
            //dt.Columns.Add("Monto", typeof(string));
            //dt.Columns.Add("NombreEncargado", typeof(string));
            //dt.Columns.Add("TelefonoEncargado", typeof(string));
            //dt.Columns.Add("DuiEncargado", typeof(string));
            //dt.Columns.Add("DireccionEncargado", typeof(string));
            //dt.Columns.Add("LugarTrEncargado", typeof(string));
            //dt.Columns.Add("Imagen", typeof(Image));
            //dt.Columns.Add("Contrato1", typeof(Image));
            //dt.Columns.Add("Contrato2", typeof(Image));
            //dt.Columns.Add("Contrato3", typeof(Image));
            //dt.Columns.Add("Contrato4", typeof(Image));
            //dt.Columns.Add("Radiografia1", typeof(Image));
            //dt.Columns.Add("Radiografia2", typeof(Image));
            //dt.Columns.Add("Radiografia3", typeof(Image));
            //dt.Columns.Add("Radiografia4", typeof(Image));


            dgvFichas.DataSource = dt;

            exportar();
        }

        private async void exportar()
        {
            dt.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("Contador2/nodo2");
            Contador2 obj1 = resp1.ResultAs<Contador2>();
            int cnt = Convert.ToInt32(obj1.cnt2);

            while (true)
            {
                if (i == cnt)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetTaskAsync("Ficha/" + i);
                    fichasf obj2 = resp2.ResultAs<fichasf>();

                    DataRow row = dt.NewRow();

                        row["ID"] = obj2.id;
                        row["Nombre"] = obj2.Nombre;
                        row["Telefono"] = obj2.Telefono;
                        row["Telefono2"] = obj2.Telefono2;
                        row["Fecha_ingreso"] = obj2.Fecha;
                        row["Direccion"] = obj2.Direccion;
                    row["Edad"] = obj2.Edad;
                        row["Dui"] = obj2.DUI;
                        row["Email"] = obj2.Email;
                        row["Lugar_trabajo"] = obj2.Lugar_Trabajo;
                        row["Informacion_adicional"] = obj2.Informacion_adicional;
                        row["Monto"] = obj2.Monto;
                    row["NombreEncargado"] = obj2.NombreEncargado;
                    row["TelefonoEncargado"] = obj2.TelefonoEncargado;
                    row["EdadEncargado"] = obj2.EdadEncargado;
                    row["DuiEncargado"] = obj2.DuiEncargado;
                    row["DirecciónEncargado"] = obj2.DirecciónEncargado;
                    row["LugarTrEncargado"] = obj2.LugarTrEncargado;

                    byte[] b = Convert.FromBase64String(obj2.img);
                    MemoryStream ms = new MemoryStream();
                    ms.Write(b, 0, Convert.ToInt32(b.Length));

                    Bitmap bm = new Bitmap(ms, false);
                 

                    //Contrato
                    byte[] c1 = Convert.FromBase64String(obj2.ImgContrato1);
                    MemoryStream msc1 = new MemoryStream();
                    msc1.Write(c1, 0, Convert.ToInt32(c1.Length));

                    Bitmap bmc1  = new Bitmap(msc1, false);


                    byte[] c2 = Convert.FromBase64String(obj2.ImgContrato2);
                    MemoryStream msc2 = new MemoryStream();
                    msc2.Write(c2, 0, Convert.ToInt32(c2.Length));

                    Bitmap bmc2 = new Bitmap(msc2, false);

                    byte[] c3 = Convert.FromBase64String(obj2.ImgContrato3);
                    MemoryStream msc3 = new MemoryStream();
                    msc3.Write(c3, 0, Convert.ToInt32(c3.Length));

                    Bitmap bmc3 = new Bitmap(msc3, false);

                    byte[] c4 = Convert.FromBase64String(obj2.ImgContrato4);
                    MemoryStream msc4 = new MemoryStream();
                    msc4.Write(c4, 0, Convert.ToInt32(c4.Length));

                    Bitmap bmc4 = new Bitmap(msc4, false);


                    ////Radiografia

                    byte[] r1 = Convert.FromBase64String(obj2.ImgRadiografia1);
                    MemoryStream msr1 = new MemoryStream();
                    msr1.Write(r1, 0, Convert.ToInt32(r1.Length));

                    Bitmap bmr1 = new Bitmap(msr1, false);

                    byte[] r2 = Convert.FromBase64String(obj2.ImgRadiografia2);
                    MemoryStream msr2 = new MemoryStream();
                    msr2.Write(r2, 0, Convert.ToInt32(r2.Length));

                    Bitmap bmr2 = new Bitmap(msr2, false);


                    byte[] r3 = Convert.FromBase64String(obj2.ImgRadiografia3);
                    MemoryStream msr3 = new MemoryStream();
                    msr3.Write(r3, 0, Convert.ToInt32(r3.Length));

                    Bitmap bmr3 = new Bitmap(msr3, false);


                    byte[] r4 = Convert.FromBase64String(obj2.ImgRadiografia4);
                    MemoryStream msr4 = new MemoryStream();
                    msr4.Write(r4, 0, Convert.ToInt32(r4.Length));

                    Bitmap bmr4 = new Bitmap(msr4, false);



                    row["Imagen"] = bm;
                    
                    
                    row["Contrato1"] = bmc1;
                    row["Contrato2"] = bmc2;
                    row["Contrato3"] = bmc3;
                    row["Contrato4"] = bmc4;
                    row["Radiografia1"] = bmr1;
                    row["Radiografia2"] = bmr2;
                    row["Radiografia3"] = bmr3;
                    row["Radiografia4"] = bmr4;

                    dt.Rows.Add(row);

                }

                catch
                {

                }


            }
            MessageBox.Show("Hecho");
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permite digitar letras");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void btn_eliminar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            //FirebaseResponse response = await client.DeleteTaskAsync("Ficha/" + txt_nombre.Text);
            //MessageBox.Show(" Se ha borrado correctamente " + txt_nombre.Text);

            var resultado4 = MessageBox.Show("Seguro que desea eliminar esta información", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resultado4 == DialogResult.OK)
            {
                string id = dgvFichas.SelectedRows[0].Cells["ID"].Value.ToString();
                string Nombre = dgvFichas.SelectedRows[0].Cells["Nombre"].Value.ToString();
                string telefono1 = dgvFichas.SelectedRows[0].Cells["Telefono"].Value.ToString();
                string telefono2 = dgvFichas.SelectedRows[0].Cells["Telefono2"].Value.ToString();
                string Fecha_ingreso = dgvFichas.SelectedRows[0].Cells["Fecha_ingreso"].Value.ToString();
                string Direccion = dgvFichas.SelectedRows[0].Cells["Direccion"].Value.ToString();
                string Edad = (dgvFichas.SelectedRows[0].Cells["Edad"].Value.ToString());
                string Dui = dgvFichas.SelectedRows[0].Cells["Dui"].Value.ToString();
                string Email = dgvFichas.SelectedRows[0].Cells["Email"].Value.ToString();
                string Lugar_trabajo = dgvFichas.SelectedRows[0].Cells["Lugar_trabajo"].Value.ToString();
                string Informacion_adicional = dgvFichas.SelectedRows[0].Cells["Informacion_adicional"].Value.ToString();
                string Monto = dgvFichas.SelectedRows[0].Cells["Monto"].Value.ToString();
                string NombreEncargado = dgvFichas.SelectedRows[0].Cells["NombreEncargado"].Value.ToString();
                string TelefonoEncargado = dgvFichas.SelectedRows[0].Cells["TelefonoEncargado"].Value.ToString();
                string EdadEncargado =(dgvFichas.SelectedRows[0].Cells["EdadEncargado"].Value.ToString());
                string DuiEncargado = dgvFichas.SelectedRows[0].Cells["DuiEncargado"].Value.ToString();
                string DirecciónEncargado = dgvFichas.SelectedRows[0].Cells["DirecciónEncargado"].Value.ToString();
                string LugarTrEncargado = dgvFichas.SelectedRows[0].Cells["LugarTrEncargado"].Value.ToString();


                Image Imagefoto = (Image)dgvFichas.SelectedRows[0].Cells["Imagen"].Value;
                Image Imagecontrato1 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato1"].Value;
                Image Imagecontrato2 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato2"].Value;
                Image Imagecontrato3 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato3"].Value;
                Image Imagecontrato4 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato4"].Value;

                Image Radiografia1 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia1"].Value;
                Image Radiografia2 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia2"].Value;
                Image Radiografia3 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia3"].Value;
                Image Radiografia4 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia4"].Value;


                //Prueba ir = new Prueba(id, Nombre, Image);
                //ir.Show();
                //this.Hide();

                //Prueba visualizar = new Prueba();

                //visualizar.Show();

                FirebaseResponse response = await client.DeleteTaskAsync("Ficha/" + id);
                MessageBox.Show(" Se ha borrado correctamente " + id);
            }
            else
            {

            }


        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); DataGridViewRow row = this.dgvFichas.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Bisque;
            row.Height = 100;
            row.MinimumHeight = 100;

            exportar();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            DataGridViewRow row = this.dgvFichas.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Bisque;
            row.Height = 100;
            row.MinimumHeight = 100;
            BuscarNombre();
            //TraerDatos();
        }

        //private async void TraerDatos()
        //{
        //    dt.Rows.Clear();
        //    int i = 0;
        //    FirebaseResponse resp1 = await client.GetTaskAsync("Contador2/nodo2");
        //    Contador2 obj1 = resp1.ResultAs<Contador2>();
        //    int cnt2 = Convert.ToInt32(obj1.cnt2);

        //    //MessageBox.Show(cnt.ToString());

        //    while (true)
        //    {

        //        if (i == cnt2)
        //        {
        //            break;
        //        }
        //        i++;
        //        try
        //        {
        //            FirebaseResponse resp2 = await client.GetTaskAsync("Ficha/" + i);
        //            fichasf obj2 = resp2.ResultAs<fichasf>();

        //            DataRow row = dt.NewRow();

        //            if (obj2.Nombre == txt_nombre.Text)
        //            {
        //                string id = dgvFichas.SelectedRows[0].Cells["ID"].Value.ToString();
        //                string Nombre = dgvFichas.SelectedRows[0].Cells["Nombre"].Value.ToString();
        //                string telefono1 = dgvFichas.SelectedRows[0].Cells["Telefono"].Value.ToString();
        //                string telefono2 = dgvFichas.SelectedRows[0].Cells["Telefono2"].Value.ToString();
        //                string Fecha_ingreso = dgvFichas.SelectedRows[0].Cells["Fecha_ingreso"].Value.ToString();
        //                string Direccion = dgvFichas.SelectedRows[0].Cells["Direccion"].Value.ToString();
        //                string Edad = dgvFichas.SelectedRows[0].Cells["Edad"].Value.ToString();
        //                string Dui = dgvFichas.SelectedRows[0].Cells["Dui"].Value.ToString();
        //                string Email = dgvFichas.SelectedRows[0].Cells["Email"].Value.ToString();
        //                string Lugar_trabajo = dgvFichas.SelectedRows[0].Cells["Lugar_trabajo"].Value.ToString();
        //                string Informacion_adicional = dgvFichas.SelectedRows[0].Cells["Informacion_adicional"].Value.ToString();
        //                string Monto = dgvFichas.SelectedRows[0].Cells["Monto"].Value.ToString();
        //                string NombreEncargado = dgvFichas.SelectedRows[0].Cells["NombreEncargado"].Value.ToString();
        //                string TelefonoEncargado = dgvFichas.SelectedRows[0].Cells["TelefonoEncargado"].Value.ToString();
        //                string EdadEncargado = dgvFichas.SelectedRows[0].Cells["EdadEncargado"].Value.ToString();
        //                string DuiEncargado = dgvFichas.SelectedRows[0].Cells["DuiEncargado "].Value.ToString();
        //                string DirecciónEncargado = dgvFichas.SelectedRows[0].Cells["DirecciónEncargado"].Value.ToString();
        //                string LugarTrEncargado = dgvFichas.SelectedRows[0].Cells["LugarTrEncargado"].Value.ToString();

        //                Image Imagefoto = (Image)dgvFichas.SelectedRows[0].Cells["Imagen"].Value;
        //                Image Imagecontrato1 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato1"].Value;
        //                Image Imagecontrato2 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato2"].Value;
        //                Image Imagecontrato3 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato3"].Value;
        //                Image Imagecontrato4 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato4"].Value;

        //                Image Radiografia1 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia1"].Value;
        //                Image Radiografia2 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia2"].Value;
        //                Image Radiografia3 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia3"].Value;
        //                Image Radiografia4 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia4"].Value;

        //            }




        //            else
        //            {
        //                //MessageBox.Show("Nombre no encontado");
        //            }
        //        }



        //        catch//(Exception p)
        //        {
        //            //MessageBox.Show("Exception caught" + p);
        //        }


        //    }
        //}

        private async void BuscarNombre()
        {
            dt.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("Contador2/nodo2");
            Contador2 obj1 = resp1.ResultAs<Contador2>();
            int cnt = Convert.ToInt32(obj1.cnt2);

            while (true)
            {
                if (i == cnt)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetTaskAsync("Ficha/" + i);
                    fichasf obj2 = resp2.ResultAs<fichasf>();

                    if (txt_nombre.Text == obj2.Nombre)
                    {
                        DataRow row = dt.NewRow();

                        row["ID"] = obj2.id;
                        row["Nombre"] = obj2.Nombre;
                        row["Telefono"] = obj2.Telefono;
                        row["Telefono2"] = obj2.Telefono2;
                        row["Fecha_ingreso"] = obj2.Fecha;
                        row["Direccion"] = obj2.Direccion;
                        row["Edad"] = obj2.Edad;
                        row["Dui"] = obj2.DUI;
                        row["Email"] = obj2.Email;
                        row["Lugar_trabajo"] = obj2.Lugar_Trabajo;
                        row["Informacion_adicional"] = obj2.Informacion_adicional;
                        row["Monto"] = obj2.Monto;
                        row["NombreEncargado"] = obj2.NombreEncargado;
                        row["TelefonoEncargado"] = obj2.TelefonoEncargado;
                        row["EdadEncargado"] = obj2.EdadEncargado;
                        row["DuiEncargado"] = obj2.DuiEncargado;
                        row["DirecciónEncargado"] = obj2.DirecciónEncargado;
                        row["LugarTrEncargado"] = obj2.LugarTrEncargado;

                        byte[] b = Convert.FromBase64String(obj2.img);
                        MemoryStream ms = new MemoryStream();
                        ms.Write(b, 0, Convert.ToInt32(b.Length));

                        Bitmap bm = new Bitmap(ms, false);

                        //Contrato
                        byte[] c1 = Convert.FromBase64String(obj2.ImgContrato1);
                        MemoryStream msc1 = new MemoryStream();
                        msc1.Write(c1, 0, Convert.ToInt32(c1.Length));

                        Bitmap bmc1 = new Bitmap(msc1, false);


                        byte[] c2 = Convert.FromBase64String(obj2.ImgContrato2);
                        MemoryStream msc2 = new MemoryStream();
                        msc2.Write(c2, 0, Convert.ToInt32(c2.Length));

                        Bitmap bmc2 = new Bitmap(msc2, false);

                        byte[] c3 = Convert.FromBase64String(obj2.ImgContrato3);
                        MemoryStream msc3 = new MemoryStream();
                        msc3.Write(c3, 0, Convert.ToInt32(c3.Length));

                        Bitmap bmc3 = new Bitmap(msc3, false);

                        byte[] c4 = Convert.FromBase64String(obj2.ImgContrato4);
                        MemoryStream msc4 = new MemoryStream();
                        msc4.Write(c4, 0, Convert.ToInt32(c4.Length));

                        Bitmap bmc4 = new Bitmap(msc4, false);


                        ////Radiografia

                        byte[] r1 = Convert.FromBase64String(obj2.ImgRadiografia1);
                        MemoryStream msr1 = new MemoryStream();
                        msr1.Write(r1, 0, Convert.ToInt32(r1.Length));

                        Bitmap bmr1 = new Bitmap(msr1, false);

                        byte[] r2 = Convert.FromBase64String(obj2.ImgRadiografia2);
                        MemoryStream msr2 = new MemoryStream();
                        msr2.Write(r2, 0, Convert.ToInt32(r2.Length));

                        Bitmap bmr2 = new Bitmap(msr2, false);


                        byte[] r3 = Convert.FromBase64String(obj2.ImgRadiografia3);
                        MemoryStream msr3 = new MemoryStream();
                        msr3.Write(r3, 0, Convert.ToInt32(r3.Length));

                        Bitmap bmr3 = new Bitmap(msr3, false);


                        byte[] r4 = Convert.FromBase64String(obj2.ImgRadiografia4);
                        MemoryStream msr4 = new MemoryStream();
                        msr4.Write(r4, 0, Convert.ToInt32(r4.Length));

                        Bitmap bmr4 = new Bitmap(msr4, false);



                        row["Imagen"] = bm;
                        row["Contrato1"] = bmc1;
                        row["Contrato2"] = bmc2;
                        row["Contrato3"] = bmc3;
                        row["Contrato4"] = bmc4;
                        row["Radiografia1"] = bmr1;
                        row["Radiografia2"] = bmr2;
                        row["Radiografia3"] = bmr3;
                        row["Radiografia4"] = bmr4;

                        dt.Rows.Add(row);

                        
                    }
                    else /*if(txt_nombre.Text != obj2.Nombre)*/
                    {
                        //MessageBox.Show("Nombre no encontado");
                       
                    }
                }

                catch(Exception)
                {
                    //MessageBox.Show("Exception caught" + p);
                }
            }
            MessageBox.Show("Hecho");


        }
        


        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); DataGridViewRow row = this.dgvFichas.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Bisque;
            row.Height = 100;
            row.MinimumHeight = 100;

            exportar();
        }

        private void mask_fecha_Validating(object sender, CancelEventArgs e)
        {
            DateTime fecha;
            if (!DateTime.TryParse(mask_fecha.Text, out fecha))
            {
                errorProvider1.SetError(mask_fecha, "El formato de la fecha debe ser MM/DD/YYYY");
            }
            else
            {
                errorProvider1.SetError(mask_fecha, "");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            DataGridViewRow row = this.dgvFichas.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Bisque;
            row.Height = 100;
            row.MinimumHeight = 100;
            fecha_buscar();
            fecha_traer();


        }
        private async void fecha_traer()
        {
            dt.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("Contador2/nodo2");
            Contador2 obj1 = resp1.ResultAs<Contador2>();
            int cnt2 = Convert.ToInt32(obj1.cnt2);

            //MessageBox.Show(cnt.ToString());

            while (true)
            {

                if (i == cnt2)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetTaskAsync("Ficha/" + i);
                    fichasf obj2 = resp2.ResultAs<fichasf>();

                    DataRow row = dt.NewRow();

                    if (obj2.Fecha == mask_fecha.Text)
                    {
                        string id = dgvFichas.SelectedRows[0].Cells["ID"].Value.ToString();
                    string Nombre = dgvFichas.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    string telefono1 = dgvFichas.SelectedRows[0].Cells["Telefono"].Value.ToString();
                    string telefono2 = dgvFichas.SelectedRows[0].Cells["Telefono2"].Value.ToString();
                    string Fecha_ingreso = dgvFichas.SelectedRows[0].Cells["Fecha_ingreso"].Value.ToString();
                    string Direccion = dgvFichas.SelectedRows[0].Cells["Direccion"].Value.ToString();
                    string Edad = dgvFichas.SelectedRows[0].Cells["Edad"].Value.ToString();
                    string Dui = dgvFichas.SelectedRows[0].Cells["Dui"].Value.ToString();
                    string Email = dgvFichas.SelectedRows[0].Cells["Email"].Value.ToString();
                    string Lugar_trabajo = dgvFichas.SelectedRows[0].Cells["Lugar_trabajo"].Value.ToString();
                    string Informacion_adicional = dgvFichas.SelectedRows[0].Cells["Informacion_adicional"].Value.ToString();
                    string Monto = dgvFichas.SelectedRows[0].Cells["Monto"].Value.ToString();
                    string NombreEncargado = dgvFichas.SelectedRows[0].Cells["NombreEncargado"].Value.ToString();
                    string TelefonoEncargado = dgvFichas.SelectedRows[0].Cells["TelefonoEncargado"].Value.ToString();
                    string EdadEncargado = dgvFichas.SelectedRows[0].Cells["EdadEncargado"].Value.ToString();
                    string DuiEncargado = dgvFichas.SelectedRows[0].Cells["DuiEncargado "].Value.ToString();
                    string DirecciónEncargado = dgvFichas.SelectedRows[0].Cells["DirecciónEncargado"].Value.ToString();
                    string LugarTrEncargado = dgvFichas.SelectedRows[0].Cells["LugarTrEncargado"].Value.ToString();

                    Image Imagefoto = (Image)dgvFichas.SelectedRows[0].Cells["Imagen"].Value;
                    Image Imagecontrato1 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato1"].Value;
                    Image Imagecontrato2 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato2"].Value;
                    Image Imagecontrato3 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato3"].Value;
                    Image Imagecontrato4 = (Image)dgvFichas.SelectedRows[0].Cells["Contrato4"].Value;

                    Image Radiografia1 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia1"].Value;
                    Image Radiografia2 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia2"].Value;
                    Image Radiografia3 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia3"].Value;
                    Image Radiografia4 = (Image)dgvFichas.SelectedRows[0].Cells["Radiografia4"].Value;


                    }
                    else
                    {
                        //MessageBox.Show("Nombre no encontado");
                    }
                }

                catch//(Exception p)
                {
                    //MessageBox.Show("Exception caught" + p);
                }


            }

        }
        private async void fecha_buscar()
        {

            dt.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("Contador2/nodo2");
            Contador2 obj1 = resp1.ResultAs<Contador2>();
            int cnt = Convert.ToInt32(obj1.cnt2);

            while (true)
            {
                if (i == cnt)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetTaskAsync("Ficha/" + i);
                    fichasf obj2 = resp2.ResultAs<fichasf>();

                    if (obj2.Fecha == mask_fecha.Text)
                    {
                        DataRow row = dt.NewRow();

                        row["ID"] = obj2.id;
                        row["Nombre"] = obj2.Nombre;
                        row["Telefono"] = obj2.Telefono;
                        row["Telefono2"] = obj2.Telefono2;
                        row["Fecha_ingreso"] = obj2.Fecha;
                        row["Direccion"] = obj2.Direccion;
                        row["Edad"] = obj2.Edad;
                        row["Dui"] = obj2.DUI;
                        row["Email"] = obj2.Email;
                        row["Lugar_trabajo"] = obj2.Lugar_Trabajo;
                        row["Informacion_adicional"] = obj2.Informacion_adicional;
                        row["Monto"] = obj2.Monto;
                        row["NombreEncargado"] = obj2.NombreEncargado;
                        row["TelefonoEncargado"] = obj2.TelefonoEncargado;
                        row["EdadEncargado"] = obj2.EdadEncargado;
                        row["DuiEncargado"] = obj2.DuiEncargado;
                        row["DirecciónEncargado"] = obj2.DirecciónEncargado;
                        row["LugarTrEncargado"] = obj2.LugarTrEncargado;

                        byte[] b = Convert.FromBase64String(obj2.img);
                        MemoryStream ms = new MemoryStream();
                        ms.Write(b, 0, Convert.ToInt32(b.Length));

                        Bitmap bm = new Bitmap(ms, false);

                        //Contrato
                        byte[] c1 = Convert.FromBase64String(obj2.ImgContrato1);
                        MemoryStream msc1 = new MemoryStream();
                        msc1.Write(c1, 0, Convert.ToInt32(c1.Length));

                        Bitmap bmc1 = new Bitmap(msc1, false);


                        byte[] c2 = Convert.FromBase64String(obj2.ImgContrato2);
                        MemoryStream msc2 = new MemoryStream();
                        msc2.Write(c2, 0, Convert.ToInt32(c2.Length));

                        Bitmap bmc2 = new Bitmap(msc2, false);

                        byte[] c3 = Convert.FromBase64String(obj2.ImgContrato3);
                        MemoryStream msc3 = new MemoryStream();
                        msc3.Write(c3, 0, Convert.ToInt32(c3.Length));

                        Bitmap bmc3 = new Bitmap(msc3, false);

                        byte[] c4 = Convert.FromBase64String(obj2.ImgContrato4);
                        MemoryStream msc4 = new MemoryStream();
                        msc4.Write(c4, 0, Convert.ToInt32(c4.Length));

                        Bitmap bmc4 = new Bitmap(msc4, false);


                        ////Radiografia

                        byte[] r1 = Convert.FromBase64String(obj2.ImgRadiografia1);
                        MemoryStream msr1 = new MemoryStream();
                        msr1.Write(r1, 0, Convert.ToInt32(r1.Length));

                        Bitmap bmr1 = new Bitmap(msr1, false);

                        byte[] r2 = Convert.FromBase64String(obj2.ImgRadiografia2);
                        MemoryStream msr2 = new MemoryStream();
                        msr2.Write(r2, 0, Convert.ToInt32(r2.Length));

                        Bitmap bmr2 = new Bitmap(msr2, false);


                        byte[] r3 = Convert.FromBase64String(obj2.ImgRadiografia3);
                        MemoryStream msr3 = new MemoryStream();
                        msr3.Write(r3, 0, Convert.ToInt32(r3.Length));

                        Bitmap bmr3 = new Bitmap(msr3, false);


                        byte[] r4 = Convert.FromBase64String(obj2.ImgRadiografia4);
                        MemoryStream msr4 = new MemoryStream();
                        msr4.Write(r4, 0, Convert.ToInt32(r4.Length));

                        Bitmap bmr4 = new Bitmap(msr4, false);



                        row["Imagen"] = bm;
                        row["Contrato1"] = bmc1;
                        row["Contrato2"] = bmc2;
                        row["Contrato3"] = bmc3;
                        row["Contrato4"] = bmc4;
                        row["Radiografia1"] = bmr1;
                        row["Radiografia2"] = bmr2;
                        row["Radiografia3"] = bmr3;
                        row["Radiografia4"] = bmr4;

                        dt.Rows.Add(row);
                    }
                    else// if(obj2.Nombre != txt_nombre.Text)
                    {
                        //MessageBox.Show("Nombre no encontado");
                    }
                }

                catch (Exception p)
                {
                    //MessageBox.Show("Exception caught" + p);
                }
            }
            MessageBox.Show("Hecho");

        }

        private async void  button2_Click(object sender, EventArgs e)
        {
            var resultado4 = MessageBox.Show("Seguro que desea eliminar esta informacion", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resultado4 == DialogResult.OK)
            {
                var resultado5 = MessageBox.Show("Al eliminar esta informacion, no se podra recuperar esta deacuerdo?", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
              if (resultado4 == DialogResult.OK)
                {
                    FirebaseResponse responseEliminar = await client.DeleteTaskAsync("Ficha/");
                    MessageBox.Show(" Se han borrado correctamente todos los registros ");
                }
              else
                {

                }
            }
            else
            {

            }
        }

        private void dgvFichas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvFichas.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Bisque;
            row.Height = 35;
            row.MinimumHeight = 20;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Cursor = Cursors.Default;
        }
    }
}
