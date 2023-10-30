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
    public partial class Login : Form
    {
        CreateCita C = new CreateCita();
        IFirebaseConfig config = new FirebaseConfig
        {

            AuthSecret = "6VrSeH4nDLoD0aLyaM7gynA5YpRLDnMmDzuUXj9D",
            BasePath = "https://clinicadentalmelara.firebaseio.com/"

            //AuthSecret = "4Z8eZHmcJ9G1mbPqj4Qp9D7rA1eSz5oFlW4jBjHy",
            //BasePath = "https://pruebaclinicaunica.firebaseio.com/"

        };
        IFirebaseClient client;
        public Login()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch { MessageBox.Show("Ocurrió un error con la conexión"); }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_salir2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        //private void panel1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    mov = 0;
        //}

        private async void btn_ingresar_Click(object sender, EventArgs e)
        {
            //txt_usuario.TabIndex = 0;
            //txt_constraseña.TabIndex = 1;

            if ((txt_usuario.Text != "") && (txt_constraseña.Text != ""))
            {
                if ((txt_usuario.Text == "admin") && (txt_constraseña.Text == "123"))
                {
                    Prinicipal miforma1 = new Prinicipal();
                    miforma1.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    int i = 0;
                    FirebaseResponse resp1 = await client.GetTaskAsync("ContadorUsuarios/nodo");
                    Contador obj1 = resp1.ResultAs<Contador>();
                    int cnt = Convert.ToInt32(obj1.cnt);

                    //MessageBox.Show(cnt.ToString());

                    while (true)
                    {
                        if (i == cnt)
                        {
                            MessageBox.Show("Usuario no encontrado en la base de datos.");
                            break;
                        }
                        i++;
                        try
                        {
                            FirebaseResponse resp2 = await client.GetTaskAsync("Usuarios/" + i);
                            admin_usuarios obj2 = resp2.ResultAs<admin_usuarios>();

                            if (obj2.Usuario == txt_usuario.Text)
                            {
                                if (obj2.Contraseña == txt_constraseña.Text)
                                {
                                    Prinicipal miforma1 = new Prinicipal();
                                    miforma1.Tipo.Text = obj2.Tipo_usuario;
                                    miforma1.Visible = true;
                                    this.Visible = false;
                                    break;
                                }
                                else { MessageBox.Show("Contraseña incorrecta"); break; }
                            }
                        }
                        catch
                        {
                        }


                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese sus credenciales");
                txt_usuario.Clear();
                txt_constraseña.Clear();
                txt_usuario.Focus();
            }
        }
        int posy = 0;

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txt_constraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((int)e.KeyChar == (int)Keys.Enter)
            //{
            //    txt_usuario.TabIndex = 0;
            //    txt_constraseña.TabIndex = 1;

            //    if ((txt_usuario.Text != "") && (txt_constraseña.Text != ""))
            //    {
            //        if ((txt_usuario.Text == "admin") && (txt_constraseña.Text == "123"))
            //        {
            //            Prinicipal miforma1 = new Prinicipal();
            //            miforma1.Visible = true;
            //            this.Visible = false;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Nombre de usuario o contraseña invalida, vuelva aintentarlo");
            //            txt_usuario.Clear();
            //            txt_constraseña.Clear();
            //            txt_usuario.Focus();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Nombre de usuario o contraseña invalida, vuelva aintentarlo");
            //        txt_usuario.Clear();
            //        txt_constraseña.Clear();
            //        txt_usuario.Focus();
            //    }
            //}
        }

        private void txt_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((int)e.KeyChar == (int)Keys.Enter)
            //{
            //    txt_usuario.TabIndex = 0;
            //    txt_constraseña.TabIndex = 1;

            //    if ((txt_usuario.Text != "") && (txt_constraseña.Text != ""))
            //    {
            //        if ((txt_usuario.Text == "admin") && (txt_constraseña.Text == "123"))
            //        {
            //            Prinicipal miforma1 = new Prinicipal();
            //            miforma1.Visible = true;
            //            this.Visible = false;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Nombre de usuario o contraseña invalida, vuelva aintentarlo");
            //            txt_usuario.Clear();
            //            txt_constraseña.Clear();
            //            txt_usuario.Focus();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Nombre de usuario o contraseña invalida, vuelva aintentarlo");
            //        txt_usuario.Clear();
            //        txt_constraseña.Clear();
            //        txt_usuario.Focus();
            //    }
            //}
        }

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

        //private void panel1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    mov = 1;
        //    movX = (e.X) + 200;
        //    movY = e.Y;
        //}
    }
}
