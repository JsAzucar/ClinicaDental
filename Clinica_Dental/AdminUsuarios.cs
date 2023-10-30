using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Clinica_Dental
{
    public partial class AdminUsuarios : Form
    {
        string IdOriginal;
        int a = 0;
        IFirebaseConfig config = new FirebaseConfig
        {

            AuthSecret = "6VrSeH4nDLoD0aLyaM7gynA5YpRLDnMmDzuUXj9D",
            BasePath = "https://clinicadentalmelara.firebaseio.com/"

            //AuthSecret = "4Z8eZHmcJ9G1mbPqj4Qp9D7rA1eSz5oFlW4jBjHy",
            //BasePath = "https://pruebaclinicaunica.firebaseio.com/"



        };
        IFirebaseClient client;

        public AdminUsuarios()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            dgvAdminUs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
     
        private async void btnagregar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //timer1.Start(); while (a == 1)
            
            if (txtnombre.Text == "")
            {
                Error.SetError(txtnombre, "Este campo no puede quedar vacío...");
            }else if (txtdui.Text == "")
            {
                Error.SetError(txtdui, "Este campo no puede quedar vacío...");
            }else if (txtcontraseña.Text == "")
            {
                Error.SetError(txtcontraseña, "Este campo no puede quedar vacío...");
            }else if (txtusuario.Text == "")
            {
                Error.SetError(txtusuario, "Este campo no puede quedar vacío...");
            }else if (cmbTipoUs.Text == "")
            {
                Error.SetError(cmbTipoUs, "Este campo no puede quedar vacío...");
            }else { 
                FirebaseResponse resp = await client.GetTaskAsync("ContadorUsuarios/nodo");
                Contador get = resp.ResultAs<Contador>();

                var datos = new admin_usuarios
                {
                    Id = (Convert.ToInt32(get.cnt) + 1).ToString(),
                    Nombre = txtnombre.Text,
                    Dui = txtdui.Text,
                    Usuario = txtusuario.Text,
                    Contraseña = txtcontraseña.Text,
                    Tipo_usuario = cmbTipoUs.Text
                };

                SetResponse response = await client.SetTaskAsync("Usuarios/" + datos.Id, datos);
                citasE result = response.ResultAs<citasE>();

                MessageBox.Show("Usuario creado exitosamente.!");

                var obj = new Contador
                {
                    cnt = datos.Id
                };

                SetResponse response1 = await client.SetTaskAsync("ContadorUsuarios/nodo", obj);
                exportar();
                txtusuario.Text = ""; txtnombre.Text = ""; txtdui.Text = ""; txtcontraseña.Text = ""; cmbTipoUs.Text = "";
            }
           

        }

        private async void exportar()
        {
            dgvAdminUs.Rows.Clear();
            int i = 0;
        FirebaseResponse resp1 = await client.GetTaskAsync("ContadorUsuarios/nodo");
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
                    FirebaseResponse resp2 = await client.GetTaskAsync("Usuarios/" + i);
                    admin_usuarios obj2 = resp2.ResultAs<admin_usuarios>();

                    dgvAdminUs.Rows.Add(obj2.Id, obj2.Dui, obj2.Nombre, obj2.Usuario, obj2.Contraseña, obj2.Tipo_usuario);
                }
                catch (Exception p)
                {
                }


            }
        }

        private async void btnbuscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); dgvAdminUs.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("ContadorUsuarios/nodo");
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
                    FirebaseResponse resp2 = await client.GetTaskAsync("Usuarios/" + i);
                    admin_usuarios obj2 = resp2.ResultAs<admin_usuarios>();

                    if (obj2.Nombre == txtbuscar.Text)
                    {
                        dgvAdminUs.Rows.Add(obj2.Id, obj2.Dui, obj2.Nombre, obj2.Usuario, obj2.Contraseña, obj2.Tipo_usuario);
                    }
                }
                catch
                {
                }


            }
            MessageBox.Show("Hecho");
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else if (char.IsNumber(e.KeyChar)) { e.Handled = true; }
            if (e.Handled == true)
            { 
                e.Handled = true;
                MessageBox.Show("Solo se permite digitar letras");
            }
        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else if (char.IsNumber(e.KeyChar)) { e.Handled = true; }
            if (e.Handled == true)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permite digitar letras");
            }
        }

        private void txtdui_Validated(object sender, EventArgs e)
        {
            Error.Clear();
            a = 1;
        }

        private void txtnombre_Validated(object sender, EventArgs e)
        {
            Error.Clear();
            a = 1;
        }

        private void txtusuario_Validated(object sender, EventArgs e)
        {
            Error.Clear();
            a = 1;
        }

        private void txtcontraseña_Validated(object sender, EventArgs e)
        {
            Error.Clear();
            a = 1;
        }

        private void AdminUsuarios_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            exportar();
            btnCambios.Enabled = false;

        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); exportar();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
             Cursor = Cursors.WaitCursor;
            timer1.Start();btnCambios.Enabled = true;
            btnagregar.Enabled = false;

            admin_usuarios obj = new admin_usuarios();

            string id = dgvAdminUs.SelectedRows[0].Cells["ID"].Value.ToString();
            string Dui = dgvAdminUs.SelectedRows[0].Cells["Dui"].Value.ToString();
            string Nombre = dgvAdminUs.SelectedRows[0].Cells["Nombre"].Value.ToString();
            string Usuario = dgvAdminUs.SelectedRows[0].Cells["Usuario"].Value.ToString();
            string Contraseña = dgvAdminUs.SelectedRows[0].Cells["Contraseña"].Value.ToString();
            string Tipo = dgvAdminUs.SelectedRows[0].Cells["Tipo"].Value.ToString();

            txtcontraseña.Text = Contraseña;
            txtdui.Text = Dui;
            txtnombre.Text = Nombre;
            txtusuario.Text = Usuario;
            IdOriginal = id;
            cmbTipoUs.Text = Tipo;
        }

        private async void btnCambios_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); var datosUser = new admin_usuarios
            {
                Id = IdOriginal,
                Nombre = txtnombre.Text,
                Contraseña = txtcontraseña.Text,
                Usuario = txtusuario.Text,
                Tipo_usuario = cmbTipoUs.Text,
                Dui = txtdui.Text
            };

            FirebaseResponse response = await client.UpdateTaskAsync("Usuarios/" + IdOriginal, datosUser);
            admin_usuarios result = response.ResultAs<admin_usuarios>();

            MessageBox.Show("Información actualizada correctamente" + result.Id);
            btnagregar.Enabled = true;
            btnCambios.Enabled = false;
            exportar();
        }

        private async void btneliminar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            var resultado4 = MessageBox.Show("Seguro que desea eliminar esta información", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resultado4 == DialogResult.OK)
            {
                string id = dgvAdminUs.SelectedRows[0].Cells["ID"].Value.ToString();
                string Nombre = dgvAdminUs.SelectedRows[0].Cells["Nombre"].Value.ToString();
                string Usuario = dgvAdminUs.SelectedRows[0].Cells["Usuario"].Value.ToString();
                string Contraseña = dgvAdminUs.SelectedRows[0].Cells["Contraseña"].Value.ToString();
                string Tipo = dgvAdminUs.SelectedRows[0].Cells["Tipo"].Value.ToString();
                string Dui = dgvAdminUs.SelectedRows[0].Cells["Dui"].Value.ToString();

                FirebaseResponse response = await client.DeleteTaskAsync("Usuarios/" + id);
                MessageBox.Show(" Se ha borrado correctamente " + id);
                exportar();
            }
        }

        private void Txtdui_Leave(object sender, EventArgs e)
        {
            Regex regex = new Regex("^\\d{8}-\\d$");
            if (regex.IsMatch(txtdui.Text))
            {

            }
            else
            {
                MessageBox.Show("Por favor, digite un Dui valido (########-#)");
            }
        }

        private void Txtnombre_Leave(object sender, EventArgs e)
        {

        }

        private void Txtusuario_Leave(object sender, EventArgs e)
        {

        }

        private void Txtcontraseña_Leave(object sender, EventArgs e)
        {

        }

        private void CmbTipoUs_Leave(object sender, EventArgs e)
        {

        }

        private void CmbTipoUs_Validated(object sender, EventArgs e)
        {
            Error.Clear();
            a = 1;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Cursor = Cursors.Default;
        }

        private void txtdui_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else if (char.IsNumber(e.KeyChar)) { e.Handled = true; }
            if (e.Handled == true)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permite digitar letras");
            }
        }
    }
}
