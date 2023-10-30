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
    public partial class AdminCitas : Form
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

        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        public AdminCitas()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            DataClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataClient2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
      

        private void AdminCitas_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch { MessageBox.Show("Ocurrió un error con la conexión"); }
            if (Tipo.Text == "Usuario")
            {
                btn_eliminartodo.Visible = false;

            }
            dt.Columns.Add("id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Tipo_Consulta");
            dt.Columns.Add("Justificacion");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Hora");
            dt.Columns.Add("Hora Fin");
            dt.Columns.Add("Doctor");
            //dt.Columns.Add("HorarioID");
            //dt.Columns.Add("IndexIn");
            //dt.Columns.Add("IndexFin");

            DataClient.DataSource = dt;

            dt2.Columns.Add("Id");
            dt2.Columns.Add("Nombre");
            dt2.Columns.Add("Fecha");
            dt2.Columns.Add("Telefono");
            dt2.Columns.Add("Monto");

            DataClient2.DataSource = dt2;

            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            dateTimePicker1.Enabled = false;

            exportar();
            exportar2();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void dgvAdminCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_Validated(object sender, EventArgs e)
        {

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

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private async void exportar2()
        {
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;

            dt2.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("ContadorPago/nodo");
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
                    FirebaseResponse resp2 = await client.GetTaskAsync("Pagos/" + i);
                    Pago obj2 = resp2.ResultAs<Pago>();

                    DataRow row = dt2.NewRow();


                    row["Id"] = obj2.Id;
                    row["Nombre"] = obj2.Nombre;
                    row["Fecha"] = obj2.Fecha;
                    row["Telefono"] = obj2.Telefono;
                    row["Monto"] = obj2.Monto;

                    dt2.Rows.Add(row);
                }
                catch (Exception p)
                {
                    //MessageBox.Show("Exception caught" + p);
                }


            }
           
        }

        private async void exportar()
        {
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;

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

                    if (obj2.Tipo_consulta == "GENERAL")
                    {


                        row["Doctor"] = obj2.Doctor;
                        row["Fecha"] = obj2.Fecha;
                        row["Hora"] = obj2.Hora;
                        row["Hora Fin"] = obj2.HoraFin;
                        row["Justificacion"] = obj2.Justificacion;
                        row["Nombre"] = obj2.Nombre;
                        row["Telefono"] = obj2.Telefono;
                        row["Tipo_consulta"] = obj2.Tipo_consulta;
                        row["id"] = obj2.id;
                        //////row["HorarioID"] = obj2.HorarioID;
                        //////row["IndexIn"] = obj2.IndexInicio;
                        //////row["IndexFin"] = obj2.IndexFin;

                        dt.Rows.Add(row);
                    }
                }
                catch (Exception p)
                {
                    //MessageBox.Show("Exception caught" + p);
                }


            }
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); exportar();
            exportar2();
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            FirebaseResponse resp = await client.GetTaskAsync("ContadorPago/nodo");
            Contador get = resp.ResultAs<Contador>();

            var datos = new Pago
            {
                Id = (Convert.ToInt32(get.cnt) + 1).ToString(),
                Nombre = txtNombre.Text,
                Monto = txtMonto.Text.ToString(),
                Fecha = (dateTimePicker1.Text).ToString(),
                Telefono = txtTelefono.Text.ToString()
            };

            SetResponse response = await client.SetTaskAsync("Pagos/" + datos.Id, datos);
            Pago result = response.ResultAs<Pago>();

            MessageBox.Show("datos insertados" + result.Id);

            var obj = new Contador
            {
                cnt = datos.Id
            };

            SetResponse response1 = await client.SetTaskAsync("ContadorPago/nodo", obj);
            exportar2();
        }

        private async void btnbuscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            
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

                    if (obj2.Nombre == txtbuscar.Text)
                    {
                        DataRow row = dt.NewRow();

                        row["Doctor"] = obj2.Doctor;
                        row["Fecha"] = obj2.Fecha;
                        row["Hora"] = obj2.Hora;
                        row["Hora Fin"] = obj2.HoraFin;
                        row["Justificacion"] = obj2.Justificacion;
                        row["Nombre"] = obj2.Nombre;
                        row["Telefono"] = obj2.Telefono;
                        row["Tipo_consulta"] = obj2.Tipo_consulta;
                        row["id"] = obj2.id;
                        //row["HorarioID"] = obj2.HorarioID;
                        //row["IndexIn"] = obj2.IndexInicio;
                        //row["IndexFin"] = obj2.IndexFin;

                        dt.Rows.Add(row);
                    }
                }
                catch
                {
                }


            }
            MessageBox.Show("Hecho");
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Seguro que desea eliminar esta información", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resultado == DialogResult.OK)
            {
                string id = DataClient.SelectedRows[0].Cells["id"].Value.ToString();
                string Nombre = DataClient.SelectedRows[0].Cells["Nombre"].Value.ToString();
                string Tipo_Consulta = DataClient.SelectedRows[0].Cells["Tipo_Consulta"].Value.ToString();
                string Justificacion = DataClient.SelectedRows[0].Cells["Justificacion"].Value.ToString();
                string Telefono = DataClient.SelectedRows[0].Cells["Telefono"].Value.ToString();
                string Fecha = DataClient.SelectedRows[0].Cells["Fecha"].Value.ToString();
                string Hora = DataClient.SelectedRows[0].Cells["Hora"].Value.ToString();
                string Doctor = DataClient.SelectedRows[0].Cells["Doctor"].Value.ToString();

                FirebaseResponse response = await client.DeleteTaskAsync("citas/" + id);
                MessageBox.Show(" Se ha borrado correctamente ");



            }

        }


        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DataClient2_Validating(object sender, CancelEventArgs e)
        {

        }

        private void DateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void DateTimePicker1_Leave(object sender, EventArgs e)
        {
           

        }

        private void DateTimePicker1_Validated(object sender, EventArgs e)
        {
           
        }

        private void DataClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //String id = dataficha.SelectedRows[0].Cells["id"].Value.ToString();
            string Nombre = DataClient.SelectedRows[0].Cells["Nombre"].Value.ToString();
            string Telefono = DataClient.SelectedRows[0].Cells["Telefono"].Value.ToString();
            string Fecha = DataClient.SelectedRows[0].Cells["Fecha"].Value.ToString();
            ////Image Image = (Image)dataclient.SelectedRows[0].Cells["Image"].Value;


            //lb_id.Text = id;
           txtNombre.Text = Nombre;
            txtTelefono.Text = Telefono;
            dateTimePicker1.Text = Fecha;
        }

        private void DataClient2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); BuscarFecha();
        }
        private async void BuscarFecha()
        {
            dt.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("Contador/nodo");
            Contador obj1 = resp1.ResultAs<Contador>();
            int cnt = Convert.ToInt32(obj1.cnt);

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

                    if (obj2.Fecha == mask_fecha.Text)
                    {
                        DataRow row = dt.NewRow();

                        row["Doctor"] = obj2.Doctor;
                        row["Fecha"] = obj2.Fecha;
                        row["Hora"] = obj2.Hora;
                        row["Hora Fin"] = obj2.HoraFin;
                        row["Justificacion"] = obj2.Justificacion;
                        row["Nombre"] = obj2.Nombre;
                        row["Telefono"] = obj2.Telefono;
                        row["Tipo_consulta"] = obj2.Tipo_consulta;
                        row["id"] = obj2.id;
                        //row["HorarioID"] = obj2.HorarioID;
                        //row["IndexIn"] = obj2.IndexInicio;
                        //row["IndexFin"] = obj2.IndexFin;

                        dt.Rows.Add(row);
                    }
                }
                catch
                {
                }


            }
            MessageBox.Show("Hecho");
        }

        private async void btn_eliminar_Click(object sender, EventArgs e)
        {
            var resultado4 = MessageBox.Show("Seguro que desea eliminar esta informacion", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resultado4 == DialogResult.OK)
            {

                string id = DataClient2.SelectedRows[0].Cells["Id"].Value.ToString();
                string Monto = DataClient2.SelectedRows[0].Cells["Nombre"].Value.ToString();
                string Telefono = DataClient2.SelectedRows[0].Cells["Telefono"].Value.ToString();
                string Fecha = DataClient2.SelectedRows[0].Cells["Fecha"].Value.ToString();

                FirebaseResponse response = await client.DeleteTaskAsync("Pagos/" + id);
                MessageBox.Show(" Se ha borrado correctamente " + id);


            }
            else
            {

            }
            exportar2();

        }

        private async void btn_eliminartodo_Click(object sender, EventArgs e)
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
            exportar2();

        }

        private async void btn_editar_Click(object sender, EventArgs e)
        {
            var resultado4 = MessageBox.Show("Seguro que desea actualizar esta informacion", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resultado4 == DialogResult.OK)
            {
                FirebaseResponse resp = await client.GetTaskAsync("ContadorPago/nodo");
                Contador get = resp.ResultAs<Contador>();


                var Monto = new Pago
                {
                    Id = txtid.Text,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Monto=txtMonto.Text,
                    Fecha = dateTimePicker1.Text,

                };

                FirebaseResponse response = await client.UpdateTaskAsync("Pagos/" + txtid.Text, Monto);
                Pago result = response.ResultAs<Pago>();

                MessageBox.Show("Informacion actualizada correctamente" + result.Id);

            }
            else
            {

            }
            exportar2();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void DataClient2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string Id = DataClient2.SelectedRows[0].Cells["Id"].Value.ToString();
            string Nombre = DataClient2.SelectedRows[0].Cells["Nombre"].Value.ToString();
            string Fecha = DataClient2.SelectedRows[0].Cells["Fecha"].Value.ToString();
            string Telefono = DataClient2.SelectedRows[0].Cells["Telefono"].Value.ToString();
            string Monto = DataClient2.SelectedRows[0].Cells["Monto"].Value.ToString();

            txtid.Text = Id;
            txtNombre.Text = Nombre;
            dateTimePicker1.Text = Fecha;
            txtTelefono.Text = Telefono;
            txtMonto.Text = Monto;

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); txtNombre.Text = "";
            txtTelefono.Text = "";
            txtMonto.Text = "";
            dateTimePicker1.Text = "";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Cursor = Cursors.Default;
           
        }

        private void mask_fecha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}

