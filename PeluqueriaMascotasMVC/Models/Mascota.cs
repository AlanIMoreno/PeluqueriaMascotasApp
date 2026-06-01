namespace PeluqueriaMascotasMVC.Models
{
    public class Mascota
    {
        private string _nombre;
        private TipoMascota _tipo;
        private int _edad;

        public Mascota()
        {
            _nombre = string.Empty;
            _tipo = TipoMascota.Perro;
            _edad = 0;
        }

        public Mascota(string nombre, TipoMascota tipo, int edad)
        {
            _nombre = nombre;
            _tipo = tipo;
            _edad = edad;
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
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
    }
}
