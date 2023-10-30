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
    public partial class CreateCita : Form
    {
        DataTable dt = new DataTable();
        string HoraIn, HoraFin, HorarioID, IndexIn, IndexFin;

        IFirebaseConfig config = new FirebaseConfig
        {

            AuthSecret = "6VrSeH4nDLoD0aLyaM7gynA5YpRLDnMmDzuUXj9D",
            BasePath = "https://clinicadentalmelara.firebaseio.com/"

            //AuthSecret = "4Z8eZHmcJ9G1mbPqj4Qp9D7rA1eSz5oFlW4jBjHy",
            //BasePath = "https://pruebaclinicaunica.firebaseio.com/"



        };
        IFirebaseClient client;

        public CreateCita()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            dataClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

         


            //cmb_TipoConsulta.DropDownStyle = ComboBoxStyle.DropDownList;
            //cmb_doctor.DropDownStyle = ComboBoxStyle.DropDown;

        }

        private async void CreateCita_Load(object sender, EventArgs e)
        {
            if (Tipo.Text == "Usuario")
            {
                btn_eliminartodo.Visible = false;
            }
            mask_fecha.Mask = "00/00/0000";
            mask_fecha.ValidatingType = typeof(System.DateTime);
            mask_fecha.TypeValidationCompleted += new TypeValidationEventHandler(mask_fecha_TypeValidationCompleted);
         mask_fecha.KeyDown += new KeyEventHandler(mask_fecha_KeyDown);

            toolTip1.IsBalloon = true;
            ////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////
            client = new FireSharp.FirebaseClient(config);
            cmb_fin.Enabled = false;
            cmb_inicio.Enabled = false;
            //AÑADIENDO LOS DOCTORES AL COMBOBOX
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

                    cmb_doctor.Items.Add(obj2.Nombre);
                }
                catch
                {
                }
            }

            //dt.Columns.Add("ID");
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

            dataClient.DataSource = dt;

            exportar();

        }

        public void borrar()
        {
            txtnombre.Clear();
            cmb_TipoConsulta.Text = "";
            rich_justificacion.Clear();
            MaskTelefono.Clear();
            mask_fecha.Text = "";
            cmb_doctor.Text = "";
            
        }


        private bool validarCampos()
        {
            bool ok = true;
            if (txtnombre.Text == "")
            {
                ok = false;
                Error.SetError(txtnombre, "Ingresar nombre");
            }
            if (cmb_TipoConsulta.Text == "")
            {
                ok = false;
                Error.SetError(cmb_TipoConsulta, "Ingresar un tipo de consulta");

            }
            if (rich_justificacion.Text == "")
            {
                ok = false;
                Error.SetError(rich_justificacion, "Ingresar el motivo");

            }
            if (MaskTelefono.Text == "")
            {
                ok = false;
                Error.SetError(MaskTelefono, "Ingresar el número de teléfono");

            }
            if (mask_fecha.Text == "")
            {
                ok = false;
                Error.SetError(mask_fecha, "Ingresar el fecha");


            }
            if (cmb_inicio.Text == "")
            {
                ok = false;
                Error.SetError(cmb_inicio, "Ingresar la hora");

            }
            if (cmb_doctor.Text == "")
            {
                ok = false;
                Error.SetError(cmb_doctor, "Ingrese el nombre del doctor");

            }
            else { Error.Clear(); }
            return ok;
        }
        void mask_fecha_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                toolTip1.ToolTipTitle = "Invalid Date";
                toolTip1.Show("El formato debe de ser  mm/dd/yyyy.", mask_fecha, 0, -20, 2000);
            }
            else
            {
                //Now that the type has passed basic type validation, enforce more specific type rules.
                DateTime userDate = (DateTime)e.ReturnValue;

                DateTime tiempo = Convert.ToDateTime(mask_fecha.Text);
                
                if(tiempo < DateTime.Today)
                {
                    toolTip1.ToolTipTitle = "Invalid Date";
                    toolTip1.Show("La cita debe ser igual o mayor a la actual.", mask_fecha, 0, -20, 2000);
                    e.Cancel = true;
                }
                else if(tiempo >= DateTime.Today)
                {
                    //MessageBox.Show("La fecha debe de ser mayor o igual a la fecha actual");
                }
                //else if(tiempo < DateTime.Now)
                //{

                //    toolTip1.ToolTipTitle = "Invalid Date";
                //    toolTip1.Show("La cita debe ser igual o mayor a la actual.", mask_fecha, 0, -20, 2000);
                //    e.Cancel = true;
                //}
            }
        }

        // Hide the tooltip if the user starts typing again before the five-second display limit on the tooltip expires.
        void mask_fecha_KeyDown(object sender, KeyEventArgs e)
        {
            toolTip1.Hide(mask_fecha);
        }
        private void BorrarMensajeError()
        {
            Error.SetError(txtnombre, "");
            Error.SetError(cmb_TipoConsulta, "");
            Error.SetError(rich_justificacion, "");
            Error.SetError(mask_fecha, "");
            Error.SetError(MaskTelefono, "");
            Error.SetError(cmb_inicio, "");
            Error.SetError(cmb_doctor, "");
        }


        private async void btn_agregar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
            BorrarMensajeError();
            if (validarCampos())
            {
                FirebaseResponse resp = await client.GetTaskAsync("Contador/nodo");
                Contador get = resp.ResultAs<Contador>();
                FirebaseResponse ContHorarios = await client.GetTaskAsync("ContadorHorarios/nodo");
                Contador get2 = ContHorarios.ResultAs<Contador>();

                //MessageBox.Show(get.cnt);

                //Llenamos las instancias de clase Cita y clase Horario
                var datos = new citasE
                {
                    id = (Convert.ToInt32(get.cnt) + 1).ToString(),
                    Nombre = txtnombre.Text,
                    Tipo_consulta = cmb_TipoConsulta.Text,
                    Justificacion = rich_justificacion.Text,
                    Telefono = MaskTelefono.Text,
                    Fecha = mask_fecha.Text,
                    Hora = cmb_inicio.Text,
                    HoraFin = cmb_fin.Text,
                    Doctor = cmb_doctor.Text,
                    IndexFin = cmb_fin.SelectedIndex.ToString(),
                    IndexInicio = cmb_inicio.SelectedIndex.ToString(),
                    HorarioID = (Convert.ToInt32(get2.cnt) + 1).ToString()
                };
                var Hor = new Horario
                {
                    Id = (Convert.ToInt32(get2.cnt) + 1).ToString(),
                    Doctor = cmb_doctor.Text,
                    HoraInicio = cmb_inicio.SelectedIndex.ToString(),
                    HoraFin = cmb_fin.SelectedIndex.ToString(),
                    Fecha = mask_fecha.Text
                };

                //Verificamos la disponibilidad del horario elegido
                int i = 0;
                int cnt = Convert.ToInt32(get2.cnt);
                while (true)
                {
                    if (i == cnt)
                    {
                        //Añadiendo la cita en la BD
                        SetResponse response = await client.SetTaskAsync("citas/" + datos.id, datos);
                        citasE result = response.ResultAs<citasE>();

                        //Añadiendo un registro del horario de dicha cita en la BD
                        SetResponse response2 = await client.SetTaskAsync("Horarios/" + Hor.Id, Hor);

                        MessageBox.Show("datos insertados" + result.id);

                        //Actualizamos el contador de Citas
                        var obj = new Contador
                        {
                            cnt = datos.id
                        };

                        SetResponse response1 = await client.SetTaskAsync("Contador/nodo", obj);

                        //Actualizamos el contador de Horarios
                        var obj2 = new Contador
                        {
                            cnt = Hor.Id
                        };

                        SetResponse response3 = await client.SetTaskAsync("ContadorHorarios/nodo", obj2);

                        borrar();
                        exportar();
                        cmb_inicio.Enabled = false;
                        cmb_fin.Enabled = false;

                        break;
                    }
                    i++;
                    try
                    {
                        FirebaseResponse resp2 = await client.GetTaskAsync("Horarios/" + i);
                        Horario obj2 = resp2.ResultAs<Horario>();
                        if (cmb_inicio.SelectedIndex == cmb_fin.SelectedIndex)
                        {
                            MessageBox.Show("La hora de inicio y finalización no puede ser igual");
                            break;
                        }else if (cmb_inicio.SelectedIndex > cmb_fin.SelectedIndex)
                        {
                            MessageBox.Show("La hora de inicio no puede ser mayor a la hora de finalización");
                            break;
                        }
                        else { 
                        if (obj2.Doctor == datos.Doctor)
                        {
                            if (obj2.Fecha == datos.Fecha)
                            {
                                if (obj2.HoraInicio == datos.IndexInicio)
                                {
                                    MessageBox.Show("Horario de inicio no disponible con el doctor seleccionado");
                                    break;
                                } else if (int.Parse(datos.IndexInicio) > int.Parse(obj2.HoraInicio) && int.Parse(datos.IndexInicio) < int.Parse(obj2.HoraFin))
                                {
                                    MessageBox.Show("Horario de inicio no disponible con el doctor seleccionado");
                                    break;
                                } else if (obj2.HoraFin == datos.IndexFin)
                                {
                                    MessageBox.Show("Horario de finalización no disponible con el doctor seleccionado");
                                    break;
                                } else if (int.Parse(datos.IndexFin) > int.Parse(obj2.HoraInicio) && int.Parse(datos.IndexFin) < int.Parse(obj2.HoraFin))
                                    {
                                    MessageBox.Show("Horario de finalización no disponible con el doctor seleccionado");
                                    break;
                                    }
                                else if (int.Parse(datos.IndexInicio) > int.Parse(obj2.HoraInicio) && int.Parse(datos.IndexFin) < int.Parse(obj2.HoraFin)) 
                                {
                                    MessageBox.Show("Horario no disponible con el doctor seleccionado");
                                    break;
                                }
                            }
                        }
                    }
                    }
                    catch
                    {
                    }
                }


            }
            else
            {
                MessageBox.Show("Los datos  no se registraron correctamente, Verifique que estén llenos todos los campos " +
                    "y que estén llenados correctamente", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Error.Clear();
            }

        }



        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
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
            else if(char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo puede ingresar letras", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void rich_justificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
            //else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            //else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            //else
            //{
            //    e.Handled = true;
            //    MessageBox.Show("Solo se permite digitar letras");
            //}
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("Solo puede ingresar números", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtnombre_Validated(object sender, EventArgs e)
        {

              Error.Clear();
            
        }

        private void txt_telefono_Validated(object sender, EventArgs e)
        {
             Error.Clear();
            
        }

        private void txt_hora_Validated(object sender, EventArgs e)
        {
            Error.Clear();
            
        }

        private void cmb_TipoConsulta_Validated(object sender, EventArgs e)
        {
               Error.Clear();
           
        }

        private void cmb_doctor_Validated(object sender, EventArgs e)
        {
             Error.Clear();
           
        }

        private void cmb_doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_inicio.Enabled = true;
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

        private void MaskHora_Validating(object sender, CancelEventArgs e)
        {

            DateTime hora;
            if (!DateTime.TryParse(cmb_inicio.Text, out hora))
            {
                Error.SetError(cmb_inicio, "El formato de la hora debe ser HH:MM ,formato de 24 horas");
            }
            else
            {
                Error.SetError(cmb_inicio, "");
            }
        }

        private void txt_telefono_Validating(object sender, CancelEventArgs e)
        {
            int telefono;
            if (!int.TryParse(MaskTelefono.Text, out telefono))
            {
                Error.SetError(MaskTelefono, "Ingrese valor en números");
            }

            else
            {
                Error.SetError(MaskTelefono, "");
            }
        }

        private void cmb_doctor_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            {
                e.Handled = true;
            }

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
                if (i==cnt)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetTaskAsync("citas/"+i);
                    citasE obj2 = resp2.ResultAs<citasE>();

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
                catch(Exception p)
                {
                   //MessageBox.Show("Exception caught" + p);
                }


            }
        }

        private void meter_Click(object sender, EventArgs e)
        {
         

        }

        private async void MaskHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_fin.Enabled = true;
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
                    if (obj2.Nombre == cmb_doctor.Text)
                    {
                        SetResponse response = await client.SetTaskAsync("Doctores/" + obj2.Id + "/Horarios",cmb_inicio.Text);
                    }
                }
                catch
                {
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start();
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
            exportar();


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

                string id = dataClient.SelectedRows[0].Cells["id"].Value.ToString();
                string Nombre = dataClient.SelectedRows[0].Cells["Nombre"].Value.ToString();
                string Tipo_Consulta = dataClient.SelectedRows[0].Cells["Tipo_Consulta"].Value.ToString();
                string Justificacion = dataClient.SelectedRows[0].Cells["Justificacion"].Value.ToString();
                string Telefono = dataClient.SelectedRows[0].Cells["Telefono"].Value.ToString();
                string Fecha = dataClient.SelectedRows[0].Cells["Fecha"].Value.ToString();
                string Hora = dataClient.SelectedRows[0].Cells["Hora"].Value.ToString();
                string Doctor = dataClient.SelectedRows[0].Cells["Doctor"].Value.ToString();
                string HorID = dataClient.SelectedRows[0].Cells["HorarioID"].Value.ToString();

                FirebaseResponse response = await client.DeleteTaskAsync("citas/" + id);
                MessageBox.Show(" Se ha borrado correctamente " + id);

                FirebaseResponse response2 = await client.DeleteTaskAsync("Horarios/" + HorID);
            }
            else
            {

            }
            exportar();

        }

        private async void btn_editar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); bool ValidarDisp;
        var resultado4 = MessageBox.Show("Seguro que desea actualizar esta información", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resultado4 == DialogResult.OK)
            {
                FirebaseResponse resp = await client.GetTaskAsync("Contador/nodo");
                Contador get = resp.ResultAs<Contador>();

                if (HoraIn == cmb_inicio.Text && HoraFin == cmb_fin.Text)
                {
                    ValidarDisp = false;
                }
                else
                {
                    ValidarDisp = true;
                }

                if (!ValidarDisp)
                {
                    var datoscitas = new citasE
                    {
                        id = txt_id.Text,
                        Nombre = txtnombre.Text,
                        Telefono = MaskTelefono.Text,
                        Tipo_consulta = cmb_TipoConsulta.Text,
                        Justificacion = rich_justificacion.Text,
                        Fecha = mask_fecha.Text,
                        Hora = cmb_inicio.Text,
                        HoraFin = cmb_fin.Text,
                        Doctor = cmb_doctor.Text,
                        IndexFin = IndexFin,
                        IndexInicio = IndexIn,
                        HorarioID = HorarioID
                    };

                    FirebaseResponse response = await client.UpdateTaskAsync("citas/" + txt_id.Text, datoscitas);
                    citasE result = response.ResultAs<citasE>();

                    MessageBox.Show("Información actualizada correctamente" + result.id);
                    cmb_inicio.Enabled = false;
                    cmb_fin.Enabled = false;
                }else
                {
                    FirebaseResponse ContHorarios = await client.GetTaskAsync("ContadorHorarios/nodo");
                    Contador get2 = ContHorarios.ResultAs<Contador>();
                    var Hor = new Horario
                    {
                        Id = HorarioID,
                        Doctor = cmb_doctor.Text,
                        HoraInicio = cmb_inicio.SelectedIndex.ToString(),
                        HoraFin = cmb_fin.SelectedIndex.ToString(),
                        Fecha = mask_fecha.Text
                    };
                    var datos = new citasE
                    {
                        id = txt_id.Text,
                        Nombre = txtnombre.Text,
                        Tipo_consulta = cmb_TipoConsulta.Text,
                        Justificacion = rich_justificacion.Text,
                        Telefono = MaskTelefono.Text,
                        Fecha = mask_fecha.Text,
                        Hora = cmb_inicio.Text,
                        HoraFin = cmb_fin.Text,
                        Doctor = cmb_doctor.Text,
                        IndexFin = IndexFin,
                        IndexInicio = IndexIn,
                        HorarioID = HorarioID
                    };
                    //Verificamos la disponibilidad del horario elegido
                    int i = 0;
                    int cnt = Convert.ToInt32(get2.cnt);
                    while (true)
                    {
                        if (i == cnt)
                        {
                            //Añadiendo la cita en la BD
                            FirebaseResponse response = await client.UpdateTaskAsync("citas/" + txt_id.Text, datos);
                            citasE result = response.ResultAs<citasE>();
                            MessageBox.Show("Información actualizada correctamente" + result.id);

                            //Añadiendo un registro del horario de dicha cita en la BD
                            FirebaseResponse response2 = await client.UpdateTaskAsync("Horarios/" + HorarioID, Hor);

                            cmb_inicio.Enabled = false;
                            cmb_fin.Enabled = false;

                            //SetResponse response1 = await client.SetTaskAsync("Contador/nodo", obj);

                            //Actualizamos el contador de Horarios
                            var obj2 = new Contador
                            {
                                cnt = Hor.Id
                            };

                            //SetResponse response3 = await client.SetTaskAsync("ContadorHorarios/nodo", obj2);

                            borrar();
                            cmb_inicio.Enabled = false;
                            cmb_fin.Enabled = false;

                            break;
                        }
                        i++;
                        try
                        {
                            FirebaseResponse resp2 = await client.GetTaskAsync("Horarios/" + i);
                            Horario obj2 = resp2.ResultAs<Horario>();
                            if (cmb_inicio.SelectedIndex == cmb_fin.SelectedIndex)
                            {
                                MessageBox.Show("La hora de inicio y finalización no puede ser igual");
                                break;
                            }
                            else if (cmb_inicio.SelectedIndex > cmb_fin.SelectedIndex)
                            {
                                MessageBox.Show("La hora de inicio no puede ser mayor a la hora de finalización");
                                break;
                            }
                            else
                            {
                                if (obj2.Doctor == datos.Doctor)
                                {
                                    if (obj2.Fecha == datos.Fecha)
                                    {
                                        MessageBox.Show("Llego a comparar");
                                        if (obj2.HoraInicio == cmb_inicio.SelectedIndex.ToString() && obj2.Id != HorarioID)
                                        {
                                            MessageBox.Show("Horario de inicio no disponible con el doctor seleccionado 1");
                                            break;
                                        }
                                        else if (int.Parse(cmb_inicio.SelectedIndex.ToString()) > int.Parse(obj2.HoraInicio) && int.Parse(cmb_inicio.SelectedIndex.ToString()) < int.Parse(obj2.HoraFin) && obj2.Id != HorarioID)
                                        {
                                            MessageBox.Show("Horario de inicio no disponible con el doctor seleccionado 2");
                                            break;
                                        }
                                        else if (obj2.HoraFin == cmb_fin.SelectedIndex.ToString() && obj2.Id != HorarioID)
                                        {
                                            MessageBox.Show("Horario de finalización no disponible con el doctor seleccionado 3");
                                            break;
                                        }
                                        else if (int.Parse(cmb_fin.SelectedIndex.ToString()) > int.Parse(obj2.HoraInicio) && int.Parse(cmb_fin.SelectedIndex.ToString()) < int.Parse(obj2.HoraFin) && obj2.Id != HorarioID)
                                        {
                                            MessageBox.Show("Horario de finalización no disponible con el doctor seleccionado 4");
                                            break;
                                        }
                                        else if (int.Parse(cmb_inicio.SelectedIndex.ToString()) > int.Parse(obj2.HoraInicio) && int.Parse(cmb_fin.SelectedIndex.ToString()) < int.Parse(obj2.HoraFin) && obj2.Id != HorarioID)
                                        {
                                            MessageBox.Show("Horario no disponible con el doctor seleccionado 5");
                                            break;
                                        }
                                    }
                                }
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

                }
                exportar();
        }

        private void cmb_TipoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Cursor = Cursors.Default;
        }

        private void mask_fecha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmb_inicio.Enabled = true;
            cmb_fin.Enabled = true;
            string id = dataClient.SelectedRows[0].Cells["id"].Value.ToString();
            string Nombre = dataClient.SelectedRows[0].Cells["Nombre"].Value.ToString();
            string Tipo_Consulta = dataClient.SelectedRows[0].Cells["Tipo_Consulta"].Value.ToString();
            string  Justificacion = dataClient.SelectedRows[0].Cells["Justificacion"].Value.ToString();
            string Telefono = dataClient.SelectedRows[0].Cells["Telefono"].Value.ToString();
            string Fecha = dataClient.SelectedRows[0].Cells["Fecha"].Value.ToString();
            HoraIn = dataClient.SelectedRows[0].Cells["Hora"].Value.ToString();
            HoraFin = dataClient.SelectedRows[0].Cells["Hora Fin"].Value.ToString();
            string Doctor = dataClient.SelectedRows[0].Cells["Doctor"].Value.ToString();
            //HorarioID = dataClient.SelectedRows[0].Cells["HorarioID"].Value.ToString();
            //IndexIn = dataClient.SelectedRows[0].Cells["IndexIn"].Value.ToString();
            //IndexFin = dataClient.SelectedRows[0].Cells["IndexFin"].Value.ToString();


            txt_id.Text = id;
            txtnombre.Text = Nombre;
            cmb_TipoConsulta.Text = Tipo_Consulta;
            rich_justificacion.Text = Justificacion;
            MaskTelefono.Text = Telefono;
            mask_fecha.Text = Fecha;
            cmb_inicio.Text = HoraIn;
            cmb_fin.Text = HoraFin;
            cmb_doctor.Text = Doctor;

        }

        private void dataClient_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            timer1.Start(); borrar();
        }

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            exportar();
        }
    }
    
}

