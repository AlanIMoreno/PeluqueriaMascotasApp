namespace PeluqueriaMascotasMVC.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public StockItem() { }

        public StockItem(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
            FechaActualizacion = DateTime.Now;
        }
    }
}
