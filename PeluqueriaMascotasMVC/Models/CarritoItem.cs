namespace PeluqueriaMascotasMVC.Models
{
    public class CarritoItem
    {
        public int Id { get; set; }
        public int? ProductoId { get; set; }
        public Producto? Producto { get; set; }
        public int? ServicioId { get; set; }
        public Servicio? Servicio { get; set; }
        public int Cantidad { get; set; }
        public int? CarritoId { get; set; }

        public decimal Subtotal
        {
            get
            {
                if (Producto != null)
                    return Producto.Precio * Cantidad;

                if (Servicio != null)
                    return (decimal)Servicio.Precio;

                return 0;
            }
        }

        public CarritoItem() { }

        public CarritoItem(Producto producto, int cantidad)
        {
            Producto = producto;
            ProductoId = producto?.Id;
            Cantidad = cantidad;
        }

        public CarritoItem(Servicio servicio)
        {
            Servicio = servicio;
            ServicioId = servicio?.Id;
            Cantidad = 1;
        }
    }
}
