using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Dental
{
     public class admin_usuarios
    {
        private string dui;
        private string nombre;
        private string usuario;
        private string contraseña;
        private string tipo_usuario;

        public string Id
        {
            get; set;
        }

        public string Dui
        {
            get { return dui; }
            set { dui = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
        public string Tipo_usuario
        {
            get { return tipo_usuario; }
            set { tipo_usuario = value; }
        }



    }
}
