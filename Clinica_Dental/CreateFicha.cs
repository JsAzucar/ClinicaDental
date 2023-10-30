using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Clinica_Dental
{
    public partial class CreateFicha : Form
    {
        DataTable dt = new DataTable();

        string IDHeredada;

        IFirebaseConfig config = new FirebaseConfig
        {

            AuthSecret = "6VrSeH4nDLoD0aLyaM7gynA5YpRLDnMmDzuUXj9D",
            BasePath = "https://clinicadentalmelara.firebaseio.com/"

            //AuthSecret = "4Z8eZHmcJ9G1mbPqj4Qp9D7rA1eSz5oFlW4jBjHy",
            //BasePath = "https://pruebaclinicaunica.firebaseio.com/"



        };
        IFirebaseClient client;


        public CreateFicha(string id, string Nombre, string telefono1, string telefono2, string Fecha_ingreso, string Direccion,string Edad, string Dui, string Email, string Lugar_trabajo, string Informacion_adicional, string Monto, string NombreEncargado, string TelefonoEncargado,string EdadEncargado, string DuiEncargado, string DirecciónEncargado, string LugarTrEncargado, Image Imagefoto, Image Imagecontrato1, Image Imagecontrato2, Image Imagecontrato3, Image Imagecontrato4, Image Radiografia1, Image Radiografia2, Image Radiografia3, Image Radiografia4)
        {
            InitializeComponent();

            txtid.Text = id;
            txt_nombre.Text = Nombre;
            MaskTelefono1.Text = telefono1;
            maskTelefono2.Text = telefono2;
            mask_fechaingreso.Text = Fecha_ingreso;
            txt_Direccion.Text = Direccion;
            comboedad.Text = Edad;
            txtDui.Text = Dui;
            txt_Email.Text = Email;
            txt_LugarTr.Text = Lugar_trabajo;
            rich_InfoPer.Text = Informacion_adicional;
            txt_monto.Text = Monto;
            txtnombrencargado.Text = NombreEncargado;
            masktelefonoencargado.Text = TelefonoEncargado;
            comboedadencargado.Text = EdadEncargado;
            txtdireccionencargado.Text = DirecciónEncargado;
            txtduiencargado.Text = DuiEncargado;
            txtlugarencargado.Text = LugarTrEncargado;
            PBFOTO.Image = Imagefoto;
            pb_contrato1.Image = Imagecontrato1;
            pb_contrato2.Image = Imagecontrato2;
            pb_contrato3.Image = Imagecontrato3;
            pb_contrato4.Image = Imagecontrato4;
            pb_rad1.Image = Radiografia1;
            pb_rad2.Image = Radiografia2;
            pb_rad3.Image = Radiografia3;
            pb_rad4.Image = Radiografia4;





        }
        public CreateFicha()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            dataficha.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }



        public static bool validaremail(string email)
        {
            string expresion = "^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
      
        private async void CreateFicha_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;


            dt.Columns.Add("id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Tipo_Consulta");
            dt.Columns.Add("Justificacion");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Hora");
            dt.Columns.Add("Doctor");

            dataficha.DataSource = dt;

            exportar();

            panel_orange.Visible = false;
            btn_editar.Visible = false;
            btn_guardar.Visible = true;
            btn_salir.Visible = false;
            txtid.Visible = false;

            if (lbpass2.Text == "sip")
            {

                btn_editar.Visible =true;
                btn_guardar.Visible = false;
                btn_salir.Visible = true;
                panel_orange.BackColor = Color.Orange;
                panel_orange.Visible = true;
                BTN_EDITAR2.Visible = true;
                btn_editarData.Visible = false;
                groupBuscar.Enabled = false;
                
                
                
            }

            groupImage.Enabled = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int posy = 0;
        int posx = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posx = e.X;
                posy = e.Y;

            }
            else
            {
                Left = Left + (e.X - posx);
                Top = Top + (e.Y - posy);
            }
        }

    

        private async void button1_Click(object sender, EventArgs e)
        {
            var resultado4 = MessageBox.Show("Seguro que desea actualizar esta información", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resultado4 == DialogResult.OK)
            {

                FirebaseResponse resp = await client.GetTaskAsync("Contador2/nodo2");
                Contador2 get = resp.ResultAs<Contador2>();

                //Imagenes Foto

                MemoryStream ms = new MemoryStream();
                PBFOTO.Image.Save(ms, ImageFormat.Jpeg);

                //Imagenes contrato

                MemoryStream msc1 = new MemoryStream();
                pb_contrato1.Image.Save(msc1, ImageFormat.Jpeg);

                MemoryStream msc2 = new MemoryStream();
                pb_contrato2.Image.Save(msc2, ImageFormat.Jpeg);

                MemoryStream msc3 = new MemoryStream();
                pb_contrato3.Image.Save(msc3, ImageFormat.Jpeg);

                MemoryStream msc4 = new MemoryStream();
                pb_contrato4.Image.Save(msc4, ImageFormat.Jpeg);

                ////Imagenes Radiografia

                MemoryStream msr1 = new MemoryStream();
                pb_rad1.Image.Save(msr1, ImageFormat.Png);

                MemoryStream msr2 = new MemoryStream();
                pb_rad2.Image.Save(msr2, ImageFormat.Jpeg);

                MemoryStream msr3 = new MemoryStream();
                pb_rad3.Image.Save(msr3, ImageFormat.Jpeg);

                MemoryStream msr4 = new MemoryStream();
                pb_rad4.Image.Save(msr4, ImageFormat.Jpeg);




                //string urlArchivo =  PBFOTO.FileName;
                //string file = Path.GetFileName(img.FileName);

                //Foto
                byte[] a = ms.GetBuffer();
                string output = Convert.ToBase64String(a);
                //Contratos

                byte[] c1 = msc1.GetBuffer();
                string outputc1 = Convert.ToBase64String(c1);


                byte[] c2 = msc2.GetBuffer();

                string outputc2 = Convert.ToBase64String(c2);

                byte[] c3 = msc3.GetBuffer();

                string outputc3 = Convert.ToBase64String(c3);

                byte[] c4 = msc4.GetBuffer();

                string outputc4 = Convert.ToBase64String(c4);

                ////Radiografias

                byte[] r1 = msr1.GetBuffer();

                string outputr1 = Convert.ToBase64String(r1);


                byte[] r2 = msr2.GetBuffer();

                string outputr2 = Convert.ToBase64String(r2);


                byte[] r3 = msr3.GetBuffer();

                string outputr3 = Convert.ToBase64String(r3);


                byte[] r4 = msr4.GetBuffer();

                string outputr4 = Convert.ToBase64String(r4);


                //var dataimage = new fichasf
                //{
                //    img = output
                //};

                //SetResponse response3 = await client.SetTaskAsync("Ficha/", dataimage);
                //fichasf resultado = response3.ResultAs<fichasf>();

                //MessageBox.Show("Imagenes insertadas con exito");




                var datosfichas = new fichasf
                {
                    id = txtid.Text,
                    Nombre = txt_nombre.Text,
                    Telefono = MaskTelefono1.Text,
                    Telefono2 = maskTelefono2.Text,
                    Direccion = txt_Direccion.Text,
                    Edad=(comboedad.Text),
                    DUI = txtDui.Text,
                    Fecha = mask_fechaingreso.Text,
                    Informacion_adicional = rich_InfoPer.Text,
                    Email = txt_Email.Text,
                    Lugar_Trabajo = txt_LugarTr.Text,
                    Monto = txt_monto.Text,
                    NombreEncargado = txtnombrencargado.Text,
                    TelefonoEncargado = masktelefonoencargado.Text,
                    EdadEncargado=(comboedadencargado.Text),
                    DirecciónEncargado = txtdireccionencargado.Text,
                    DuiEncargado = txtduiencargado.Text,
                    LugarTrEncargado = txtlugarencargado.Text,
                    img = output,
                    ImgContrato1 = outputc1,
                    ImgContrato2 = outputc2,
                    ImgContrato3 = outputc3,
                    ImgContrato4 = outputc4,
                    ImgRadiografia1 = outputr1,
                    ImgRadiografia2 = outputr2,
                    ImgRadiografia3 = outputr3,
                    ImgRadiografia4 = outputr4

                };

                FirebaseResponse response = await client.UpdateTaskAsync("Ficha/" + txtid.Text, datosfichas);
                fichasf result = response.ResultAs<fichasf>();

                MessageBox.Show("Información actualizada correctamente" + result.id);

                this.Hide();
            }
            else
            {

            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            string carpeta = @"c:\Folder_dentist\Imagenes";

            try
            {
                if (Directory.Exists(carpeta))
                {
                    //MessageBox.Show("Carpeta existe");
                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
     

                        //string nombre = img.SafeFileName;
                        //string fname = txt_nombre.Text + "jpg";
                        //string folder = "I:\\files";
                        //string pathstring = System.IO.Path.Combine(folder, fname);


                        //this.Text = nombre;

                        try
                        {

                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {


                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Imagenes\\" + (txt_nombre.Text) + lb_id.Text + "-" + file);

                                //File.Delete(path + "\\Imagenes\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                PBFOTO.Image = imagen.GetThumbnailImage(111, 93, null, new IntPtr());

                                PBFOTO.SizeMode = PictureBoxSizeMode.CenterImage;
                                PBFOTO.SizeMode = PictureBoxSizeMode.StretchImage;


                                PBFOTO.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");

                                ////for (int i = 1; i <= 1; i++)
                                ////{
                                //    Bitmap b = new Bitmap(urlArchivo);
                                //    b.Save(@"c:\Folder_dentist\Imagenes\numero.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                //    b.Dispose();
                                ////}



                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Imagenes\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                PBFOTO.Image = imagen.GetThumbnailImage(111, 93, null, new IntPtr());


                                PBFOTO.SizeMode = PictureBoxSizeMode.CenterImage;
                                PBFOTO.SizeMode = PictureBoxSizeMode.StretchImage;


                                PBFOTO.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");

                                //Bitmap b = new Bitmap(urlArchivo);
                                //b.Save(@"c:\Folder_dentist\Imagenes\imagin.png", System.Drawing.Imaging.ImageFormat.Png);
                                //b.Dispose();

                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }

                        }

                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);
                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");

                    OpenFileDialog img = new OpenFileDialog();
                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {

                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Imagenes\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                PBFOTO.Image = imagen.GetThumbnailImage(111, 93, null, new IntPtr());


                                PBFOTO.SizeMode = PictureBoxSizeMode.CenterImage;
                                PBFOTO.SizeMode = PictureBoxSizeMode.StretchImage;


                                PBFOTO.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                                //foreach (int numero in imagenes)

                                //Bitmap b = new Bitmap(urlArchivo);
                                //b.Save(@"c:\Folder_dentist\Imagenes\numero.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                //b.Dispose();

                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Imagenes\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                PBFOTO.Image = imagen.GetThumbnailImage(111, 93, null, new IntPtr());


                                PBFOTO.SizeMode = PictureBoxSizeMode.CenterImage;
                                PBFOTO.SizeMode = PictureBoxSizeMode.StretchImage;


                                PBFOTO.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                                //Bitmap b = new Bitmap(urlArchivo);
                                //b.Save(@"c:\Folder_dentist\Imagenes\imagin.png", System.Drawing.Imaging.ImageFormat.Png);
                                //b.Dispose();

                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }

                        }

                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            ////////////////////////////////

        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            PBFOTO.Image = null;
            PBFOTO.Image = Image.FromFile(@"C:\Users\ISMAEL MARIN\Pictures\Clinica_Dental\Clinica_Dental\Resources\perfil_ambos.png");
            PBFOTO.SizeMode = PictureBoxSizeMode.CenterImage;
            PBFOTO.SizeMode = PictureBoxSizeMode.StretchImage;

        }


            private void btn_contrato_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Guardado exitosamente");

                //string carpeta = Application.StartupPath + @"\Carpeta";

                ////string carpeta = @"c:\Folder_dentist\Contrato";

                ////try
                ////{
                ////    if(Directory.Exists(carpeta ))
                ////    {
                ////        MessageBox.Show("Carpeta existe");
                ////        System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                ////    }
                ////    else
                ////    {
                ////        MessageBox.Show("Carpeta no existe, Creando...");
                ////        Directory.CreateDirectory(carpeta);
                ////        System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                ////    }

                ////}
                ////catch(Exception ex)
                ////{
                ////    MessageBox.Show("Error: " + ex.Message);
                ////}
            }

            private void btn_radiografia_Click(object sender, EventArgs e)
            {
                //string carpeta = @"c:\Folder_dentist\Radiografia";

                //try
                //{
                //    if (Directory.Exists(carpeta))
                //    {
                //        MessageBox.Show("Carpeta existe");
                //        System.Diagnostics.Process.Start(@"C:\Folder_dentist\Radiografia");
                //    }
                //    else
                //    {
                //        MessageBox.Show("Carpeta no existe, Creando...");
                //        Directory.CreateDirectory(carpeta);
                //        System.Diagnostics.Process.Start(@"C:\Folder_dentist\Radiografia");
                //    }

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error: " + ex.Message);
                //}
            }

            private void btn_guardar_Click(object sender, EventArgs e)
            {


            }

            private void txt_nombre_TextChanged(object sender, EventArgs e)
            {

            }

            private void lbpass2_Click(object sender, EventArgs e)
            {

            }

            private void label12_Click(object sender, EventArgs e)
            {

            }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pb_contrato1_Click_1(object sender, EventArgs e)
        {

            string carpeta = @"c:\Folder_dentist\Contrato";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());
                               

                                pb_contrato1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_contrato1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_contrato1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_contrato1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btn_archivos_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            string carpeta6 = @"c:\Folder_dentist\Imagenes";
            string carpeta7 = @"c:\Folder_dentist\Contrato";
            string carpeta8 = @"c:\Folder_dentist\Radiografia";

            if (Directory.Exists(carpeta6) && Directory.Exists(carpeta7) && Directory.Exists(carpeta8))
            {
                System.Diagnostics.Process.Start(@"C:\Folder_dentist");
            }
            else
            {
                MessageBox.Show("Carpeta no existe, Creando...");
                Directory.CreateDirectory(carpeta6);
                Directory.CreateDirectory(carpeta7);
                Directory.CreateDirectory(carpeta8);

                System.Diagnostics.Process.Start(@"C:\Folder_dentist");

            }
        }

            private void pb_contrato2_Click(object sender, EventArgs e)
        {

            string carpeta = @"c:\Folder_dentist\Contrato";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_contrato2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_contrato2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_contrato2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_contrato2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pb_contrato3_Click(object sender, EventArgs e)
        {

            string carpeta = @"c:\Folder_dentist\Contrato";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_contrato3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());



                                pb_contrato3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_contrato3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_contrato3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pb_contrato4_Click(object sender, EventArgs e)
        {

            string carpeta = @"c:\Folder_dentist\Contrato";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_contrato4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());



                                pb_contrato4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_contrato4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Contrato\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_contrato4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_contrato4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_contrato4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_contrato4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_contrato_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); MessageBox.Show("Haga clic sobre la imagen que está arriba del botón para agregar la imagen");
        }

        private void btn_radiografia_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); MessageBox.Show("Haga clic sobre la imagen que está arriba del botón para agregar la imagen");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            pb_rad1.Image = null;
           pb_rad1.Image = Image.FromFile(@"C:\Users\ISMAEL MARIN\Pictures\Clinica_Dental\Clinica_Dental\Resources\Radiografia_image.jpg");
           pb_rad1.SizeMode = PictureBoxSizeMode.CenterImage;
           pb_rad1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btn_borrar_c1_Click(object sender, EventArgs e)
        {
            pb_contrato1.Image = null;
            pb_contrato1.Image = Image.FromFile(@"C:\Users\ISMAEL MARIN\Pictures\Clinica_Dental\Clinica_Dental\Resources\imagen_contrato.jpg");
            pb_contrato1.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_contrato1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btn_borrar_c2_Click(object sender, EventArgs e)
        {
            pb_contrato2.Image = null;
            pb_contrato2.Image = Image.FromFile(@"C:\Users\ISMAEL MARIN\Pictures\Clinica_Dental\Clinica_Dental\Resources\imagen_contrato.jpg");
            pb_contrato2.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_contrato2.SizeMode = PictureBoxSizeMode.StretchImage;


        }

        private void btn_borrar_c3_Click(object sender, EventArgs e)
        {

            pb_contrato3.Image = null;
            pb_contrato3.Image = Image.FromFile(@"C:\Users\ISMAEL MARIN\Pictures\Clinica_Dental\Clinica_Dental\Resources\imagen_contrato.jpg");
            pb_contrato3.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_contrato3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btn_borrar_c4_Click(object sender, EventArgs e)
        {
            pb_contrato4.Image = null;
            pb_contrato4.Image = Image.FromFile(@"C:\Users\ISMAEL MARIN\Pictures\Clinica_Dental\Clinica_Dental\Resources\imagen_contrato.jpg");
            pb_contrato4.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_contrato4.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btn_borrar_r3_Click(object sender, EventArgs e)
        {
            pb_rad3.Image = null;
            pb_rad3.Image = Image.FromFile(@"C:\Users\ISMAEL MARIN\Pictures\Clinica_Dental\Clinica_Dental\Resources\Radiografia_image.jpg");
            pb_rad3.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_rad3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btn_borrar_r2_Click(object sender, EventArgs e)
        {
            pb_rad2.Image = null;
            pb_rad2.Image = Image.FromFile(@"C:\Users\ISMAEL MARIN\Pictures\Clinica_Dental\Clinica_Dental\Resources\Radiografia_image.jpg");
            pb_rad2.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_rad2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btn_borrar_r4_Click(object sender, EventArgs e)
        {
            pb_rad4.Image = null;
            pb_rad4.Image = Image.FromFile(@"C:\Users\ISMAEL MARIN\Pictures\Clinica_Dental\Clinica_Dental\Resources\Radiografia_image.jpg");
            pb_rad4.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_rad4.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)

        { 
        //    if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
        //    else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
        //    else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
        //    else
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("Solo se permite digitar letras");
        //    }
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo puede ingresar letras", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else

            {
                e.Handled = false;
            }
        }

        private void txt_Email_Leave(object sender, EventArgs e)
        {

            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if(Regex.IsMatch(txt_Email.Text,pattern))
            {
                Error.SetError(txt_Email, "");
            }
            else
            {
                Error.SetError(this.txt_Email, "Dirección de Email incorrecta");
            }
            //if (validaremail(txt_Email.Text))//verifica que este bien el texto con la expresion 
            //{
            //}
            //else
            //{
            //    MessageBox.Show("Dirección de correo no válida"); txt_Email.SelectAll();
            //    txt_Email.Focus();
            //}
        }

        private void txt_telefono1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
           /* Regex rex = new Regex("(503)+[-]{1}[0-9]{8,8}$");
            if (!rex.IsMatch(txt_telefono1.Text))
            {
                MessageBox.Show("Formato no válido");
                e.Cancel = true;
            }*/
        }

        private void txt_telefono2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
           /* Regex rex = new Regex("(503)+[-]{1}[0-9]{8,8}$");
            if (!rex.IsMatch(txt_telefono1.Text))
            {
                MessageBox.Show("Formato no válido");
                e.Cancel = true;
            }*/
        }

        private void txt_Dui_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
         /*   Regex rex = new Regex("{1}[0-9]{8,8}+[-]{1}[0-9]{1,1}$");
            if (!rex.IsMatch(txt_Dui.Text))
            {
                MessageBox.Show("Formato no válido");
                e.Cancel = true;
            }*/
        }

        private void txt_telefono1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("solamente se pueden ingresar números");
            }
        }

        private void txt_telefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("solamente se pueden ingresar números");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("solamente se pueden ingresar números");
            }
        }

        private void txt_nombre_Validated(object sender, EventArgs e)
        {
         
        }

        private void txt_telefono1_Validated(object sender, EventArgs e)
        {
            
        }

        private void txt_Direccion_Validated(object sender, EventArgs e)
        {
           
        }

        private void txt_Dui_Validated(object sender, EventArgs e)
        {
           
        }

        private void txt_Email_Validated(object sender, EventArgs e)
        {
         
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            //if (textBox2.Text.Trim() == "")
            //{
            //    Error.SetError(textBox2, "Este campo no puede quedar vacio...");
            //    textBox2.Focus();
            //}
            //else
            //{
            //    Error.Clear();
            //}
        }

        private async void btn_guardar_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            var resultado4 = MessageBox.Show("Seguro que desea guardar esta información", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resultado4 == DialogResult.OK)
            {

                FirebaseResponse resp = await client.GetTaskAsync("Contador2/nodo2");
                Contador2 get = resp.ResultAs<Contador2>();

                //MessageBox.Show(get.cnt);

                //Imagenes Foto

                MemoryStream ms = new MemoryStream();
                PBFOTO.Image.Save(ms, ImageFormat.Jpeg);

                //Imagenes contrato

                MemoryStream msc1 = new MemoryStream();
                pb_contrato1.Image.Save(msc1, ImageFormat.Jpeg);

                MemoryStream msc2 = new MemoryStream();
                pb_contrato2.Image.Save(msc2, ImageFormat.Jpeg);

                MemoryStream msc3 = new MemoryStream();
                pb_contrato3.Image.Save(msc3, ImageFormat.Jpeg);

                MemoryStream msc4 = new MemoryStream();
                pb_contrato4.Image.Save(msc4, ImageFormat.Jpeg);

                ////Imagenes Radiografia

                MemoryStream msr1 = new MemoryStream();
                pb_rad1.Image.Save(msr1, ImageFormat.Png);

                MemoryStream msr2 = new MemoryStream();
                pb_rad2.Image.Save(msr2, ImageFormat.Jpeg);

                MemoryStream msr3 = new MemoryStream();
                pb_rad3.Image.Save(msr3, ImageFormat.Jpeg);

                MemoryStream msr4 = new MemoryStream();
                pb_rad4.Image.Save(msr4, ImageFormat.Jpeg);




                //string urlArchivo =  PBFOTO.FileName;
                //string file = Path.GetFileName(img.FileName);

                //Foto
                byte[] a = ms.GetBuffer();
                string output = Convert.ToBase64String(a);
                //Contratos

                byte[] c1 = msc1.GetBuffer();
                string outputc1 = Convert.ToBase64String(c1);


                byte[] c2 = msc2.GetBuffer();

                string outputc2 = Convert.ToBase64String(c2);

                byte[] c3 = msc3.GetBuffer();

                string outputc3 = Convert.ToBase64String(c3);

                byte[] c4 = msc4.GetBuffer();

                string outputc4 = Convert.ToBase64String(c4);

                ////Radiografias

                byte[] r1 = msr1.GetBuffer();

                string outputr1 = Convert.ToBase64String(r1);


                byte[] r2 = msr2.GetBuffer();

                string outputr2 = Convert.ToBase64String(r2);


                byte[] r3 = msr3.GetBuffer();

                string outputr3 = Convert.ToBase64String(r3);


                byte[] r4 = msr4.GetBuffer();

                string outputr4 = Convert.ToBase64String(r4);


                //var dataimage = new fichasf
                //{
                //    img = output
                //};

                //SetResponse response3 = await client.SetTaskAsync("Ficha/", dataimage);
                //fichasf resultado = response3.ResultAs<fichasf>();

                //MessageBox.Show("Imagenes insertadas con exito");




                var datosfichas = new fichasf
                {
                    id = (Convert.ToInt32(get.cnt2) + 1).ToString(),
                    Nombre = txt_nombre.Text,
                    Telefono = MaskTelefono1.Text,
                    Telefono2 = maskTelefono2.Text,
                    Direccion = txt_Direccion.Text,
                    Edad=(comboedad.Text),
                    DUI = txtDui.Text,
                    Fecha = mask_fechaingreso.Text,
                    Informacion_adicional = rich_InfoPer.Text,
                    Email = txt_Email.Text,
                    Lugar_Trabajo = txt_LugarTr.Text,
                    Monto = txt_monto.Text,
                    NombreEncargado = txtnombrencargado.Text,
                    TelefonoEncargado = masktelefonoencargado.Text,
                    EdadEncargado=(comboedadencargado.Text),
                    DuiEncargado = txtduiencargado.Text,
                    DirecciónEncargado = txtdireccionencargado.Text,
                    LugarTrEncargado = txtlugarencargado.Text,
                    img = output,
                    ImgContrato1 = outputc1,
                    ImgContrato2 = outputc2,
                    ImgContrato3 = outputc3,
                    ImgContrato4 = outputc4,
                    ImgRadiografia1 = outputr1,
                    ImgRadiografia2 = outputr2,
                    ImgRadiografia3 = outputr3,
                    ImgRadiografia4 = outputr4

                };

                SetResponse response = await client.SetTaskAsync("Ficha/" + datosfichas.id, datosfichas);
                fichasf result = response.ResultAs<fichasf>();



                MessageBox.Show(" datos insertados " + result.id);

                var obj = new Contador2
                {
                    cnt2 = datosfichas.id
                };

                SetResponse response1 = await client.SetTaskAsync("Contador2/nodo2", obj);



                BorrarCampos();
                groupFichaData.Enabled = true;
                groupBuscar.Enabled = true;
                groupImage.Enabled = false;
            }
            else
            {

            }
        
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            exportar();
      
        }

        private async void exportar()
        {
            dt.Rows.Clear();
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

                    DataRow row = dt.NewRow();


                    if (obj2.Tipo_consulta == "ESPECIALIDAD")
                    {
                        row["id"] = obj2.id;
                        row["Tipo_consulta"] = obj2.Tipo_consulta;
                        row["Doctor"] = obj2.Doctor;
                        row["Fecha"] = obj2.Fecha;
                        row["Hora"] = obj2.Hora;
                        row["Justificacion"] = obj2.Justificacion;
                        row["Nombre"] = obj2.Nombre;
                        row["Telefono"] = obj2.Telefono;
                        dt.Rows.Add(row);

                    }
                    
                }

                catch//(Exception p)
                {
                    
                }


            }
            //MessageBox.Show("Hecho");
        }

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void maskPagar_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void BorrarMensajeError()
        {
            Error.SetError(txt_nombre, "");
            Error.SetError(MaskTelefono1, "");
            Error.SetError(maskTelefono2, "");
            Error.SetError(masktelefonoencargado, "");
            Error.SetError(mask_fechaingreso, "");
            Error.SetError(txtDui, "");
            Error.SetError(txt_Direccion, "");
            Error.SetError(txt_Email, "");
        }
        private void BorrarCampos()
        {
            txt_nombre.Text = "";
            MaskTelefono1.Text = "";
            maskTelefono2.Text = "";
            mask_fechaingreso.Text = "";
            txt_Direccion.Text = "";
            txtDui.Text = "";
            txt_monto.Text = "";
            rich_InfoPer.Text = "";
            txt_LugarTr.Text = "";
            txt_Email.Text = "";
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            BorrarMensajeError();
            if (validarCampos())
            {

                groupFichaData.Enabled = false;
                groupBuscar.Enabled = false;
                groupImage.Enabled = true;



            }
            else
            {
                MessageBox.Show("Los datos  no se registraron correctamente, Verifique que estén llenos todos los campos " +
                    "y que estén llenados correctamente", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }
        private bool validarCampos()
        {
            bool ok = true;
            if (txt_nombre.Text == "")
            {
                ok = false;
                Error.SetError(txt_nombre, "Ingresar nombre");
            }
            if (MaskTelefono1.Text == "")
            {
                ok = false;
                Error.SetError(MaskTelefono1, "Ingresar un número de teléfono");

            }
                      
            if (mask_fechaingreso.Text == "")
            {
                ok = false;
                Error.SetError(mask_fechaingreso, "Ingresar el fecha");

            }
            if (txt_Direccion.Text == "")
            {
                ok = false;
                Error.SetError(txt_Direccion, "Ingresar la dirección del cliente");

            }
            //if (txtDui.Text == "")
            //{
            //    ok = false;
            //    Error.SetError(txtDui, "Ingrese el numero de DUI");
            //    MessageBox.Show("Ingrese el numero de DUI");

            //}
            return ok;
        }

        private void mask_fecha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void mask_fechaingreso_Validating(object sender, CancelEventArgs e)
        {
            DateTime fecha;
            if (!DateTime.TryParse(mask_fechaingreso.Text, out fecha))
            {
                Error.SetError(mask_fechaingreso, "El formato de la fecha debe ser MM/DD/YYYY");
            }
            else
            {
                Error.SetError(mask_fechaingreso, "");
            }
        }

        private void MaskTelefono1_Validating(object sender, CancelEventArgs e)
        {
            //int numero;
            //if (!int.TryParse(MaskTelefono1.Text, out numero))
            //{
            //    Error.SetError(MaskTelefono1, "Debe de ingresar un numero de telefono");
            //}
            //else
            //{
            //    Error.SetError(MaskTelefono1, "");
            //}
        }

        private void maskTelefono2_Validating(object sender, CancelEventArgs e)
        {
            int numero2;
            if (!int.TryParse(MaskTelefono1.Text, out numero2))
            {
                Error.SetError(MaskTelefono1, "Debe de ingresar un número de telfono");
            }
            else
            {
                Error.SetError(MaskTelefono1, "");
            }
        }

        private void txt_Email_Validating(object sender, CancelEventArgs e)
        {
        

        }

        private void maskdui_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txt_monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo puede ingresar números", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else

            {
                e.Handled = false;
            }
        }

        private void txtDui_Leave(object sender, EventArgs e)
        {

            Regex regex = new Regex("^\\d{8}-\\d$");
            if (regex.IsMatch(txtDui.Text))
            {

            }
            else
            {
                MessageBox.Show("Por favor, digite un Dui valido (########-#)");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            BuscarNombre();
            TraerDatos();
            
           

            //FirebaseResponse response = await client.GetTaskAsync("citas/" + txtnombreBuscar.Text);
            //citasE obj = response.ResultAs<citasE>();

            //txtnombreBuscar.Text = obj.id;
            //txt_nombre.Text = obj.Nombre;

            //MessageBox.Show("datos regresados correctamente");
        }
        private async void TraerDatos()
        {
            dt.Rows.Clear();
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
                    FirebaseResponse resp2 = await client.GetTaskAsync("citas/"+i);
                    citasE obj2 = resp2.ResultAs<citasE>();

                    DataRow row = dt.NewRow();

                    if (obj2.Nombre == txtnombreBuscar.Text)
                    {


                        String id = dataficha.SelectedRows[0].Cells["id"].Value.ToString();
                        //string Nombre = dataficha.SelectedRows[0].Cells["Nombre"].Value.ToString();
                        //string Telefono = dataficha.SelectedRows[0].Cells["Telefono"].Value.ToString();
                        //string Fecha = dataficha.SelectedRows[0].Cells["Fecha"].Value.ToString();
                        ////Image Image = (Image)dataclient.SelectedRows[0].Cells["Image"].Value;

                        //if (obj2.Nombre == txtnombreBuscar.Text)
                        //{

                        //    if (obj2.Tipo_consulta == "ESPECIALIDAD")
                        //    {
                        //        lb_id.Text = obj2.id;
                        //        txt_nombre.Text = Nombre;
                        //        MaskTelefono1.Text = Telefono;
                        //        mask_fechaingreso.Text = Fecha;




                        if (obj2.Tipo_consulta == "ESPECIALIDAD")
                        {

                            //lb_id.Text = obj2.id;
                            //txt_nombre.Text = Nombre;
                            //MaskTelefono1.Text = Telefono;
                            //mask_fechaingreso.Text = Fecha;

                            lb_id.Text = obj2.id;
                            txt_nombre.Text = obj2.Nombre;
                            MaskTelefono1.Text = obj2.Telefono;
                            mask_fechaingreso.Text = obj2.Fecha;




                        }

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

        private async void BuscarNombre()
        {
            dt.Rows.Clear();
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

                    DataRow row = dt.NewRow();

                    if (obj2.Nombre == txtnombreBuscar.Text)
                    {

                        if (obj2.Tipo_consulta == "ESPECIALIDAD")
                        {
                            row["id"] = obj2.id;
                            row["Tipo_consulta"] = obj2.Tipo_consulta;
                            row["Doctor"] = obj2.Doctor;
                            row["Fecha"] = obj2.Fecha;
                            row["Hora"] = obj2.Hora;
                            row["Justificacion"] = obj2.Justificacion;
                            row["Nombre"] = obj2.Nombre;
                            row["Telefono"] = obj2.Telefono;
                            dt.Rows.Add(row);


                        }
                        else
                        {
                            MessageBox.Show("Nombre no encontrado");
                        }

                    }
                }

                catch(Exception p)
                {
                    //MessageBox.Show("Exception caught" + p);
                }


            }
            MessageBox.Show("Hecho");
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            txt_nombre.Text = "";
            MaskTelefono1.Text = "";
            mask_fechaingreso.Text = "";
        }

        private void btn_editarData_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); groupFichaData.Enabled = true;
            groupBuscar.Enabled = true;
            groupImage.Enabled = false;
        }

        private void PBFOTO_Click(object sender, EventArgs e)
        {

        }

        private async void btn_retrieve_Click(object sender, EventArgs e)
        {

            //FirebaseResponse response = await client.GetTaskAsync("Ficha/");
            //fichasf image = response.ResultAs<fichasf>();

            //byte[] b = Convert.FromBase64CharArray(.imagen);
        }

        private void lbpass2_Click_1(object sender, EventArgs e)
        {

        }

        private void dataficha_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            String id = dataficha.SelectedRows[0].Cells["id"].Value.ToString();
            string Nombre = dataficha.SelectedRows[0].Cells["Nombre"].Value.ToString();
            string Telefono = dataficha.SelectedRows[0].Cells["Telefono"].Value.ToString();
            string Fecha = dataficha.SelectedRows[0].Cells["Fecha"].Value.ToString();
            //Image Image = (Image)dataclient.SelectedRows[0].Cells["Image"].Value;

         
                lb_id.Text = id;
                txt_nombre.Text = Nombre;
                MaskTelefono1.Text = Telefono;
                mask_fechaingreso.Text = Fecha;


            }

        private void pb_rad1_Click(object sender, EventArgs e)
        {

            string carpeta = @"c:\Folder_dentist\Radiografia";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiogafia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void pb_rad2_Click(object sender, EventArgs e)
        {


            string carpeta = @"c:\Folder_dentist\Radiografia";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiogafia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pb_rad3_Click(object sender, EventArgs e)
        {

            string carpeta = @"c:\Folder_dentist\Radiografia";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiogafia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pb_rad4_Click(object sender, EventArgs e)
        {
            string carpeta = @"c:\Folder_dentist\Radiografia";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiogafia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());

                                pb_rad4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


            string carpeta = @"c:\Folder_dentist\Radiografia";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_rad2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_rad2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_rad2.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad2.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad2.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad2.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pb_rad1_Click_1(object sender, EventArgs e)
        {


            string carpeta = @"c:\Folder_dentist\Radiografia";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_rad1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_rad1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_rad1.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad1.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad1.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad1.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pb_rad3_Click_1(object sender, EventArgs e)
        {


            string carpeta = @"c:\Folder_dentist\Radiografia";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_rad3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);



                                Image imagen = new Bitmap(img.FileName);
                                pb_rad3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);



                                Image imagen = new Bitmap(img.FileName);
                                pb_rad3.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad3.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad3.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad3.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pb_rad4_Click_1(object sender, EventArgs e)
        {

            string carpeta = @"c:\Folder_dentist\Radiografia";

            try
            {
                if (Directory.Exists(carpeta))
                {

                    //System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
                    OpenFileDialog img = new OpenFileDialog();
                    //PictureBox o = sender as PictureBox;

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {

                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);

                                Image imagen = new Bitmap(img.FileName);
                                pb_rad4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_rad4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Carpeta no existe, Creando...");
                    Directory.CreateDirectory(carpeta);

                    OpenFileDialog img = new OpenFileDialog();

                    img.Title = "Open image";
                    img.Filter = "Imagenes|*.jpg;*.png";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {


                            string regexPattern = @"([^\s]+(\.(?i)(jpg))$)";
                            string regexPattern2 = @"([^\s]+(\.(?i)(png))$)";

                            if (Regex.IsMatch(img.FileName, regexPattern))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + "-" + file);


                                Image imagen = new Bitmap(img.FileName);
                                pb_rad4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else if (Regex.IsMatch(img.FileName, regexPattern2))
                            {
                                string urlArchivo = img.FileName;
                                string file = Path.GetFileName(img.FileName);
                                string path = @"c:\Folder_dentist\";/*Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);*/
                                File.Copy(urlArchivo, path + "\\Radiografia\\" + (txt_nombre.Text) + " - " + file);



                                Image imagen = new Bitmap(img.FileName);
                                pb_rad4.Image = imagen.GetThumbnailImage(100, 91, null, new IntPtr());


                                pb_rad4.SizeMode = PictureBoxSizeMode.CenterImage;
                                pb_rad4.SizeMode = PictureBoxSizeMode.StretchImage;


                                pb_rad4.Load(urlArchivo);
                                MessageBox.Show("Imagen Guardada con Exito.");
                            }
                            else
                            {
                                MessageBox.Show("no es una imagen ");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BTN_EDITAR2_Click(object sender, EventArgs e)
        {
            groupFichaData.Enabled = true;
            groupBuscar.Enabled = false;
            groupImage.Enabled = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupFichaData_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtnombrencargado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdireccionencargado_TextChanged(object sender, EventArgs e)
        {

        }

        private void masktelefonoencargado_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtduiencargado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlugarencargado_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskTelefono2_Validating_1(object sender, CancelEventArgs e)
        {

            int numero2;

            if (!int.TryParse(maskTelefono2.Text, out numero2))
            {
                Error.SetError(maskTelefono2, "Debe de ingresar un número de teléfono");
            }
            else
            {
                Error.SetError(maskTelefono2, "");
            }
        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {

            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txt_Email.Text, pattern))
            {
                Error.SetError(txt_Email, "");
            }
            else
            {
                Error.SetError(this.txt_Email, "Dirección de Email incorrecta");
            }
        }

        private void txt_nombre_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txt_nombre_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo puede ingresar letras", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else

            {
                e.Handled = false;
            }
        }

        private void MaskTelefono1_Validating_1(object sender, CancelEventArgs e)
        {
            int numero;
            if (!int.TryParse(MaskTelefono1.Text, out numero))
            {
                Error.SetError(MaskTelefono1, "Debe de ingresar un número de teléfono");
            }
            else
            {
                Error.SetError(MaskTelefono1, "");
            }
        }

        private void mask_fechaingreso_Validating_1(object sender, CancelEventArgs e)
        {
            DateTime fecha;
            if (!DateTime.TryParse(mask_fechaingreso.Text, out fecha))
            {
                Error.SetError(mask_fechaingreso, "El formato de la fecha debe ser MM/DD/YYYY");
            }
            else
            {
                Error.SetError(mask_fechaingreso, "");
            }
        }

        private void txtDui_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtDui_Leave_1(object sender, EventArgs e)
        {

            Regex regex = new Regex("^\\d{8}-\\d$");
            if (regex.IsMatch(txtDui.Text))
            {

            }
            else
            {
                MessageBox.Show("Por favor, digite un Dui valido (########-#)");
            }
        }

        private void txt_Email_Leave_1(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txt_Email.Text, pattern))
            {
                Error.SetError(txt_Email, "");
            }
            else
            {
                Error.SetError(this.txt_Email, "Dirección de Email incorrecta");
            }
        }

        private void txt_monto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo puede ingresar números", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else

            {
                e.Handled = false;
            }
        }

        private void txtnombrencargado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo puede ingresar letras", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else

            {
                e.Handled = false;
            }
        }

        private void masktelefonoencargado_Validating(object sender, CancelEventArgs e)
        {
            int numero3;
            if (!int.TryParse(masktelefonoencargado.Text, out numero3))
            {
                Error.SetError(masktelefonoencargado, "Debe de ingresar un número de teléfono");
            }
            else
            {
                Error.SetError(masktelefonoencargado, "");
            }
        }

        private void txtduiencargado_Leave(object sender, EventArgs e)
        {

            Regex regex = new Regex("^\\d{8}-\\d$");
            if (regex.IsMatch(txtduiencargado.Text))
            {

            }
            else
            {
                MessageBox.Show("Por favor, digite un Dui valido (########-#)");
            }
        }

        private void groupBuscar_Enter(object sender, EventArgs e)
        {

        }

        private void mask_fecha_Validating(object sender, CancelEventArgs e)
        {
            DateTime fecha;
            if (!DateTime.TryParse(mask_fecha.Text, out fecha))
            {
                Error.SetError(mask_fecha, "El formato de la fecha debe ser MM/DD/YYYY");
            }
            else
            {
                Error.SetError(mask_fecha, "");
            }
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            BuscarFecha();
            TraerDatosFecha();

        }

        private async void TraerDatosFecha()
        {
            dt.Rows.Clear();
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

                    DataRow row = dt.NewRow();

                    if (obj2.Fecha == mask_fecha.Text)
                    {


                        String id = dataficha.SelectedRows[0].Cells["id"].Value.ToString();
                        //string Nombre = dataficha.SelectedRows[0].Cells["Nombre"].Value.ToString();
                        //string Telefono = dataficha.SelectedRows[0].Cells["Telefono"].Value.ToString();
                        //string Fecha = dataficha.SelectedRows[0].Cells["Fecha"].Value.ToString();
                        ////Image Image = (Image)dataclient.SelectedRows[0].Cells["Image"].Value;

                        //if (obj2.Nombre == txtnombreBuscar.Text)
                        //{

                        //    if (obj2.Tipo_consulta == "ESPECIALIDAD")
                        //    {
                        //        lb_id.Text = obj2.id;
                        //        txt_nombre.Text = Nombre;
                        //        MaskTelefono1.Text = Telefono;
                        //        mask_fechaingreso.Text = Fecha;




                        if (obj2.Tipo_consulta == "ESPECIALIDAD")
                        {

                            //lb_id.Text = obj2.id;
                            //txt_nombre.Text = Nombre;
                            //MaskTelefono1.Text = Telefono;
                            //mask_fechaingreso.Text = Fecha;

                            lb_id.Text = obj2.id;
                            txt_nombre.Text = obj2.Nombre;
                            MaskTelefono1.Text = obj2.Telefono;
                            mask_fechaingreso.Text = obj2.Fecha;




                        }

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

        private async void BuscarFecha()
        {
            dt.Rows.Clear();
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

                    DataRow row = dt.NewRow();

                    if (obj2.Fecha == mask_fecha.Text)
                    {

                        if (obj2.Tipo_consulta == "ESPECIALIDAD")
                        {
                            row["id"] = obj2.id;
                            row["Tipo_consulta"] = obj2.Tipo_consulta;
                            row["Doctor"] = obj2.Doctor;
                            row["Fecha"] = obj2.Fecha;
                            row["Hora"] = obj2.Hora;
                            row["Justificacion"] = obj2.Justificacion;
                            row["Nombre"] = obj2.Nombre;
                            row["Telefono"] = obj2.Telefono;
                            dt.Rows.Add(row);


                        }
                        else
                        {
                            MessageBox.Show("No hay registros en esa fecha");
                        }

                    }
                }

                catch (Exception p)
                {
                   // MessageBox.Show("Exception caught" + p);
                }


            }
            MessageBox.Show("Hecho");
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
        }

        private void btn_vercontrato2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
        }

        private void btn_vercontrato3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
        }

        private void btn_vercontrato4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Folder_dentist\Contrato");
        }

        private void btn_verradiografia_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Folder_dentist\Radiografia");
        }

        private void btn_verradiografia2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Folder_dentist\Radiografia");
        }

        private void btn_verradiografia3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Folder_dentist\Radiografia");
        }

        private void btn_verradiografia4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Folder_dentist\Radiografia");
        }

        private void btn_verFoto_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Folder_dentist\Imagenes");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Cursor = Cursors.Default;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
            