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
    public partial class Administrar_doctores : Form
    {
        string IdOriginal;
        int a = 0;

        DataTable dt = new DataTable();
        IFirebaseConfig config = new FirebaseConfig
        {

            AuthSecret = "6VrSeH4nDLoD0aLyaM7gynA5YpRLDnMmDzuUXj9D",
            BasePath = "https://clinicadentalmelara.firebaseio.com/"

            //AuthSecret = "4Z8eZHmcJ9G1mbPqj4Qp9D7rA1eSz5oFlW4jBjHy",
            //BasePath = "https://pruebaclinicaunica.firebaseio.com/"
        };
        IFirebaseClient client;

        public Administrar_doctores()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            dgvDoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void borrar()
        {
            txtnom.Clear();
            txtbuscar.Clear();
            txtape.Clear();
            cmbesp.Text = "";
        }

        private async void exportar()
        {
            dgvDoc.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("ContadorDoctor/nodo");
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
                    FirebaseResponse resp2 = await client.GetTaskAsync("Doctores/" + i);
                    Doctor obj2 = resp2.ResultAs<Doctor>();

                    DataRow row = dt.NewRow();
                    dgvDoc.Rows.Add(obj2.Id, obj2.Nombre, obj2.Telefono, obj2.Especialidad);
                }
                catch
                {
                }
            }
        }

        private async void btnagregar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            if (txtnom.Text == "")
            {
                Error.SetError(txtnom, "Este campo no puede quedar vacío...");
            }else if (txtape.Text == "")
            {
                Error.SetError(txtape, "Este campo no puede quedar vacío...");
            }else if (cmbesp.Text == "")
            {
                Error.SetError(cmbesp, "Seleccione una especialidad");
            }else { 
            FirebaseResponse resp = await client.GetTaskAsync("ContadorDoctor/nodo");
                Contador get = resp.ResultAs<Contador>();

                //MessageBox.Show(get.cnt);

                var datos = new Doctor
                {
                    Id = (Convert.ToInt32(get.cnt) + 1).ToString(),
                    Nombre = txtnom.Text,
                    Telefono = txtape.Text,
                    Especialidad = cmbesp.Text,
                };

                //var Horario1 = new Horario
                //{
                //    HoraFecha = "100"
                //};

                SetResponse response = await client.SetTaskAsync("Doctores/" + datos.Id, datos);
                //SetResponse response2 = await client.SetTaskAsync("D octores/" + datos.Id + "/Horarios", Horario1);
                citasE result = response.ResultAs<citasE>();

                MessageBox.Show("datos insertados" + result.id);

                var obj = new Contador
                {
                    cnt = datos.Id
                };

                SetResponse response1 = await client.SetTaskAsync("ContadorDoctor/nodo", obj);

                borrar();
                dgvDoc.Rows.Clear();
                exportar();
                a = 0;

                //Error.SetError(txtnom, "Este campo no puede quedar vacío...");
                //Error.SetError(txtape, "Este campo no puede quedar vacío...");
                //Error.SetError(cmbesp, "Este campo no puede quedar vacío...");

            }
        }


        private void txtnom_KeyPress(object sender, KeyPressEventArgs e)
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
                Error.SetError(txtnom, "Solo puede ingresar letras");
                //MessageBox.Show("Solo puede ingresar letras", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else

            {
                e.Handled = false;
            }
            //if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
            //else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            //else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            //else
            //{
            //    e.Handled = true;
            //    MessageBox.Show("Solo se permite digitar letras");
            //}
        }

        private void txtape_KeyPress(object sender, KeyPressEventArgs e)
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
                Error.SetError(txtape, "Solo puede ingresar números");
                //MessageBox.Show("Solo puede ingresar números", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtnom_Validated(object sender, EventArgs e)
        {
           
           
            
                Error.Clear(); a = 1;

        }

        private void txtape_Validated(object sender, EventArgs e)
        {
            Error.Clear(); a = 1;
        }

        private void txtbuscar_Validated(object sender, EventArgs e)
        {
            
                Error.Clear();
            a = 0;
        }

        private void Administrar_doctores_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            exportar();
            btnCambios.Enabled = false;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); btnCambios.Enabled = true;
            btnagregar.Enabled = false;

            Doctor obj = new Doctor();

            string id = dgvDoc.SelectedRows[0].Cells["ID"].Value.ToString();
            string Nombre = dgvDoc.SelectedRows[0].Cells["Nombre"].Value.ToString();
            string telefono = dgvDoc.SelectedRows[0].Cells["Telefono"].Value.ToString();
            string Especialidad = dgvDoc.SelectedRows[0].Cells["Especialidad"].Value.ToString();

            txtnom.Text = Nombre;
            txtape.Text = telefono;
            cmbesp.Text = Especialidad;
            IdOriginal = id;
        }

        private async void btnCambios_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); var datosDoc = new Doctor
            {
                Id = IdOriginal,
                Nombre = txtnom.Text,
                Telefono = txtape.Text,
                Especialidad = cmbesp.Text,
                Horarios = "Autogenerado"
            };

            FirebaseResponse response = await client.UpdateTaskAsync("Doctores/" + IdOriginal, datosDoc);
            Doctor result = response.ResultAs<Doctor>();

            MessageBox.Show("Información actualizada correctamente" + result.Id);
            btnagregar.Enabled = true;
            exportar();
        }

        private async void btneliminar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); var resultado4 = MessageBox.Show("Seguro que desea eliminar esta información", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resultado4 == DialogResult.OK)
            {
                string id = dgvDoc.SelectedRows[0].Cells["ID"].Value.ToString();
                string Nombre = dgvDoc.SelectedRows[0].Cells["Nombre"].Value.ToString();
                string telefono = dgvDoc.SelectedRows[0].Cells["Telefono"].Value.ToString();
                string Especialidad = dgvDoc.SelectedRows[0].Cells["Especialidad"].Value.ToString();

                FirebaseResponse response = await client.DeleteTaskAsync("Doctores/" + id);
                MessageBox.Show(" Se ha borrado correctamente " + id);
                exportar();
            }
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); exportar();
        }

        private async void btnbuscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); dgvDoc.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("ContadorDoctor/nodo");
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
                    FirebaseResponse resp2 = await client.GetTaskAsync("Doctores/" + i);
                    Doctor obj2 = resp2.ResultAs<Doctor>();
                    if (obj2.Nombre == txtbuscar.Text)
                    { 
                    DataRow row = dt.NewRow();
                    dgvDoc.Rows.Add(obj2.Id, obj2.Nombre, obj2.Telefono, obj2.Especialidad);
                    }
                }
                catch
                {
                }
            }
        }

        private void Txtnom_Leave(object sender, EventArgs e)
        {
            //if (txtnom.Text.Trim() == "")
            //{
            //    Error.SetError(txtnom, "Este campo no puede quedar vacío...");
            //    txtnom.Focus();
            //}
            //else
            //{
            //    Error.Clear();
            //}
        }

        private void Txtape_Leave(object sender, EventArgs e)
        {
            //if (txtape.Text.Trim() == "")
            //{
            //    Error.SetError(txtape, "Este campo no puede quedar vacío...");
            //    txtape.Focus();
            //}
            //else
            //{
            //    Error.Clear();
            //}
        }

        private void Cmbesp_Leave(object sender, EventArgs e)
        {
            //if (cmbesp.Text.Trim() == "")
            //{
            //    Error.SetError(cmbesp, "Este campo no puede quedar vacío...");
            //    cmbesp.Focus();
            //}
            //else
            //{
            //    Error.Clear();
            //}
        }

        private void Txtbuscar_Leave(object sender, EventArgs e)
        {
            //if (txtbuscar.Text.Trim() == "")
            //{
            //    Error.SetError(txtbuscar, "Este campo no puede quedar vacío...");
            //    txtbuscar.Focus();
            //}
            //else
            //{
            //    Error.Clear();
            //}
        }

        private void Cmbesp_Validated(object sender, EventArgs e)
        {
            //Error.Clear();a = 1;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Cursor = Cursors.Default;
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
