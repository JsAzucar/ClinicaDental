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
    public partial class Prinicipal : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {

            AuthSecret = "6VrSeH4nDLoD0aLyaM7gynA5YpRLDnMmDzuUXj9D",
            BasePath = "https://clinicadentalmelara.firebaseio.com/"

            //AuthSecret = "4Z8eZHmcJ9G1mbPqj4Qp9D7rA1eSz5oFlW4jBjHy",
            //BasePath = "https://pruebaclinicaunica.firebaseio.com/"



        };
        IFirebaseClient client;

      

        public Prinicipal()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            //this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            btn_restaurar.Visible = false;
            personalizar();
        }
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.Central.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.Purple);         //Color.FromArgb(64, 64, 64)
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            //base.OnPaint(e);
            //ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }



        private void personalizar()
        {
            //panel_SubmenuCita.Visible = false;
            Panel_SubmenuFicha.Visible = false;
        }

        private void hideMenu()
        {
            //if (panel_SubmenuCita.Visible == true)
            //{
            //    panel_SubmenuCita.Visible = false;
            //}
            if (Panel_SubmenuFicha.Visible == true)
            {
                Panel_SubmenuFicha.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_citas_Click(object sender, EventArgs e)
        {
            CreateCita C = new CreateCita();
            C.Tipo.Text = Tipo.Text;
            openprincipal(C);
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            hideMenu();
            //showSubMenu(panel_SubmenuCita);

        }

        private void Prinicipal_Load(object sender, EventArgs e)
        {
            if (Tipo.Text == "Usuario")
            {
                btn_administrarusuarios.Visible = false;
                btn_administrardoctores.Visible = false;
            }

            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
               MessageBox.Show("Conexión establecida");
            }

            btn_image_Click(null, e);


            //    else
            //    {
            //        MessageBox.Show("Hay problemas con la coneccion verifique su servidor de internet");
            //    }
            //    //else if(client == null)
            //    //{
            //    //    MessageBox.Show("Hay problemas con la coneccion verifique su servidor de internet");
            //    //}
            //}
        }



        private void btn_AdministrarCitas_Click(object sender, EventArgs e)
        {
            AdminCitas AC = new AdminCitas();
            AC.Tipo.Text = Tipo.Text;
            openprincipal(AC);
            Cursor = Cursors.WaitCursor;
            timer2.Start();
            hideMenu();
        }

        private void btn_CrearFicha_Click(object sender, EventArgs e)
        {
            openprincipal(new CreateFicha());
            Cursor = Cursors.WaitCursor;
            timer2.Start();
            hideMenu();
        }

        private void btn_AdministrarFichas_Click(object sender, EventArgs e)
        {
            openprincipal(new AdminFicha());
            Cursor = Cursors.WaitCursor;
            timer2.Start();

            hideMenu();
        }

        private void btn_fichas_Click(object sender, EventArgs e)
        {
            showSubMenu(Panel_SubmenuFicha);
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
            hideMenu();
        }

        private void btn_AdministrarUs_Click(object sender, EventArgs e)
        {
            openprincipal(new AdminUsuarios());
            hideMenu();
        }

        private Form activeform = null;
        private void openprincipal(Form formhijo)
        {
            if (activeform != null)
                activeform.Close();
            activeform = formhijo;
            formhijo.TopLevel = false;
            formhijo.FormBorderStyle = FormBorderStyle.None;
            formhijo.Dock = DockStyle.Fill;
            Panel_Contenedor.Controls.Add(formhijo);
            Panel_Contenedor.Tag = formhijo;
            formhijo.BringToFront();
            formhijo.Show();
        } 


        //if (WindowState == FormWindowState.Normal)
        //    {
        //        WindowState = FormWindowState.Minimized;
        //    }
        //    else if (WindowState == FormWindowState.Minimized)
        //    {
        //        WindowState = FormWindowState.Normal;
        //    }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
            hideMenu();
        }

        //private void panel3_MouseUp(object sender, MouseEventArgs e)
        //{
        //    mov = 0;
        //}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //Capturar posicion y tamaño antes de maximizar para restaurar

        int lx, ly;
        int sw, sh;

        private void btn_maximizar_Click(object sender, EventArgs e)
        {

            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btn_maximizar.Visible = false;
            //pb_maxin.Visible = false;

            btn_restaurar.Visible = true;
            //pb_restaurar.Visible = true;
     

            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btn_maximizar.Visible = true;
            //pb_maxin.Visible = true;
            btn_restaurar.Visible = false;
            //pb_restaurar.Visible = false;
       

            //    lx = this.Location.X;
            //    ly = this.Location.Y;
            //    sw = this.Size.Width;
            //    sh = this.Size.Height;
            //    this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //    this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            //    if(WindowState== FormWindowState.Normal)
            //    {
            //        this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //        this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            //    }
            //else if (WindowState == FormWindowState.Maximized)
            //{
            //WindowState = FormWindowState.Normal;
            //this.Size = new Size(sw, sh);
            //    this.Location = new Point(lx, ly);
            //}

        }

        private void pb_logo_Click(object sender, EventArgs e)
        {

        }


        private void btn_image_Click(object sender, EventArgs e)
        {
            openprincipal(new Central());
            hideMenu();


        }
        private void reset()
        {
           
        }

        private void image_Click(object sender, EventArgs e)
        {

        }

        private void Panel_Contenedor_Paint(object sender, PaintEventArgs e)
        {
             
        }

        //private void panel3_MouseDown(object sender, MouseEventArgs e)
        //{

        //    mov = 1;
        //    movX = (e.X) + 200;
        //    movY = e.Y;
        //}

        int posy = 0;

        private void porfa_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            hideMenu();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            openprincipal(new Administrar_doctores());
            hideMenu();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {

        }

        private void btn_maximizar2_Click(object sender, EventArgs e)
        {
            //lx = this.Location.X;
            //ly = this.Location.Y;
            //sw = this.Size.Width;
            //sh = this.Size.Height;
            //btn_maximizar.Visible = false;
            //btn_maximizar2.Visible = false;
            //btn_restaurar.Visible = true;
            //btn_restaurar2.Visible = true;

            //this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void btn_restaurar2_Click(object sender, EventArgs e)
        {
            //this.Size = new Size(sw, sh);
            //this.Location = new Point(lx, ly);
            //btn_maximizar.Visible = false;
            //btn_maximizar2.Visible = false;
            //btn_restaurar.Visible = false;
            //btn_restaurar2.Visible = false;
        }

        private void pb_maxin_Click(object sender, EventArgs e)
        {
        }

        private void pb_restaurar_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            showSubMenu(Panel_SubmenuFicha);
        }

        private void Panel_SubmenuFicha_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openprincipal(new CreateFicha());
            Cursor = Cursors.WaitCursor;
            timer2.Start();
            hideMenu();
        }

        private void button3_Click_4(object sender, EventArgs e)
        {
            AdminFicha AF = new AdminFicha();
            AF.Tipo.Text = Tipo.Text;
            openprincipal(AF);

            hideMenu();
        }

        private void button3_Click_5(object sender, EventArgs e)
        {

            openprincipal(new AdminUsuarios());
            Cursor = Cursors.WaitCursor;
            timer2.Start();
            hideMenu();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            openprincipal(new Administrar_doctores());
            Cursor = Cursors.WaitCursor;
            timer2.Start();
            hideMenu();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
            hideMenu();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Cursor = Cursors.Default;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            Cursor = Cursors.Default;

        }

        private void DataClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }

        int posx = 0;

        private void panel3_MouseMove(object sender, MouseEventArgs e)
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
    }
}
