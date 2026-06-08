using System.Collections;

namespace PeluqueriaMascotasMVC.Models
{
    public class Servicio
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private decimal _precio;
        private int _duracionMinutos;
        private TipoServicio _tipo;


        public Servicio()
        {
            _id = 0;
            _nombre = string.Empty;
            _descripcion = string.Empty;
            _precio = 0m;
            _duracionMinutos = 0;
            _tipo = TipoServicio.Consulta;

        }

        public Servicio(string nombre, string descripcion, decimal precio, int duracionMinutos, TipoServicio tipo)
        {
            _nombre = nombre;
            _descripcion = descripcion;
            _precio = precio;
            _duracionMinutos = duracionMinutos;
            _tipo = tipo;

        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int DuracionMinutos
        {
            get { return _duracionMinutos; }
            set { _duracionMinutos = value; }
        }

        public TipoServicio Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

    }
}
