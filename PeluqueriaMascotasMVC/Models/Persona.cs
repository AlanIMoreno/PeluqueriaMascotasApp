namespace PeluqueriaMascotasMVC.Models
{
    public abstract class Persona
    {
        private string _usuario;
        private string _contraseña;
        private string _mail;
        private DateTime _fechaAlta;
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _direccion;

        public Persona()
        {
            _usuario = string.Empty;
            _contraseña = string.Empty;
            _mail = string.Empty;
            _fechaAlta = DateTime.Now;
            _nombre = string.Empty;
            _apellido = string.Empty;
            _telefono = string.Empty;
            _direccion = string.Empty;
        }

        public Persona(string usuario, string contraseña, string mail, DateTime fechaAlta,
            string nombre, string apellido, string telefono, string direccion)
        {
            _usuario = usuario;
            _contraseña = contraseña;
            _mail = mail;
            _fechaAlta = fechaAlta;
            _nombre = nombre;
            _apellido = apellido;
            _telefono = telefono;
            _direccion = direccion;
        }

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public DateTime FechaAlta
        {
            get { return _fechaAlta; }
            set { _fechaAlta = value; }
        }

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

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
    }
}
