namespace PeluqueriaMascotasMVC.Models
{
    public class Producto
    {
        private string _nombre;
        private string _descripcion;
        private float _precioVigente;
        private bool _activo;

        public Producto()
        {
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

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
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