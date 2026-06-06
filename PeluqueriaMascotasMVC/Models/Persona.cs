

namespace PeluqueriaMascotasMVC.Models
{
    public class Persona 
    {
        private DateTime _fechaAlta;
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _direccion;
        private int _dni;

        public Persona()
        {
            _fechaAlta = DateTime.Now;
            _nombre = string.Empty;
            _apellido = string.Empty;
            _telefono = string.Empty;
            _direccion = string.Empty;
            _dni = 0;
        }



        public DateTime FechaAlta
        {
            get { return _fechaAlta; }
            set { _fechaAlta = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value ?? string.Empty; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value ?? string.Empty; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value ?? string.Empty; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value ?? string.Empty; }
        }

        public int Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }
    }
}
