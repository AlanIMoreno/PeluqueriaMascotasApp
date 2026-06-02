namespace PeluqueriaMascotasMVC.Models
{
    public class Mascota
    {
        private int _id;
        private string _nombre;
        private TipoMascota _tipo;
        private int _edad;
        private string? _clienteId;

        public Mascota()
        {
            _id = 0;
            _nombre = string.Empty;
            _tipo = TipoMascota.Perro;
            _edad = 0;
            _clienteId = null;
        }

        public Mascota(string nombre, TipoMascota tipo, int edad)
        {
            _nombre = nombre;
            _tipo = tipo;
            _edad = edad;
            _clienteId = null;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value ?? string.Empty; }
        }

        public TipoMascota Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public int Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }

        public string? ClienteId
        {
            get { return _clienteId; }
            set { _clienteId = value; }
        }

        public Cliente? Cliente { get; set; }
    }
}
