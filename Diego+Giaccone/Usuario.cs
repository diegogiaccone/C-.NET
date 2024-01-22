using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diego_Giaccone
{
    public class Usuario
    {
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _pass;
        private string _mail;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public string Contraseña
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        // Método para validar la contraseña
        public bool ValidarContraseña(string contraseñaIngresada)
        {
            return _pass == contraseñaIngresada;
        }
    }
}
