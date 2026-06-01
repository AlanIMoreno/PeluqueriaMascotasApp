namespace PeluqueriaMascotasMVC.Models
{
    public class Producto
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private float _precioVigente;
        private bool _activo;

        public Producto()
        {
            _id = 0;
            _nombre = string.Empty;
            _descripcion = string.Empty;
            _precioVigente = 0f;
            _activo = true;
        }

        public Producto(string nombre, string descripcion, float precioVigente, bool activo)
        {
            _nombre = nombre;
            _descripcion = descripcion;
            _precioVigente = precioVigente;
            _activo = activo;
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

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value ?? string.Empty; }
        }

        public float PrecioVigente
        {
            get { return _precioVigente; }
            set { _precioVigente = value; }
        }

        public decimal Precio
        {
            get { return (decimal)_precioVigente; }
            set { _precioVigente = (float)value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
    }
}
