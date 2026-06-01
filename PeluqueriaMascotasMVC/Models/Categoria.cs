namespace PeluqueriaMascotasMVC.Models
{
    public class Categoria
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private List<Producto> _productos;

        public Categoria()
        {
            _id = 0;
            _nombre = string.Empty;
            _descripcion = string.Empty;
            _productos = new List<Producto>();
        }

        public Categoria(string nombre, string descripcion)
        {
            _nombre = nombre;
            _descripcion = descripcion;
            _productos = new List<Producto>();
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

        public List<Producto> Productos
        {
            get { return _productos; }
            set { _productos = value ?? new List<Producto>(); }
        }
    }
}
