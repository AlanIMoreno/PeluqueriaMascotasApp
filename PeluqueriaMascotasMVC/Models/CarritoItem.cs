namespace PeluqueriaMascotasMVC.Models
{
    public class CarritoItem
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public Servicio Servicio { get; set; }
        public int Cantidad { get; set; }

        public decimal Subtotal
        {
            get
            {
                if (Producto != null)
                    return Producto.Precio * Cantidad;

                if (Servicio != null)
                    return Servicio.Precio;

                return 0;
            }
        }

        public CarritoItem() { }

        public CarritoItem(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

        public CarritoItem(Servicio servicio)
        {
            Servicio = servicio;
            Cantidad = 1;
        }
    }
}
