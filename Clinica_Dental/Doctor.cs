using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Dental
{
    class Doctor
    {
        private string nombre;
        private string telefono;
        private string especialidad;
        private string id;
        private string horarios;

        public string Horarios
        {
            get; set;
        }


        public string Id
        {
            get; set;
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

    }
}
