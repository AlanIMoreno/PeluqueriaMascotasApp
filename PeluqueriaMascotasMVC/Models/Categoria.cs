using System.Collections;

namespace PeluqueriaMascotasMVC.Models
{
    public class Categoria
    {
        private string _nombre;
        private string _descripcion;
        private ArrayList _productos;

        public Categoria()
        {
            _nombre = string.Empty;
            _descripcion = string.Empty;
            _productos = new ArrayList();
        }

        public Categoria(string nombre, string descripcion)
        {
            _nombre = nombre;
            _descripcion = descripcion;
            _productos = new ArrayList();
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

        public ArrayList Productos
        {
            get { return _productos; }
            set { _productos = value; }
        }
    }
}