using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2P1_T3.Model
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int id { set; get; }
        public string nombres { set; get; }
        public string apellidos { set; get; }
        public int edad { set; get; }
        public string correo { set; get; }
        public string direccion { set; get; }

        private string nombreCompleto;

        public string NombreCompleto
        {
            get { return $"{nombres} {apellidos}"; }
        }

    }
}
