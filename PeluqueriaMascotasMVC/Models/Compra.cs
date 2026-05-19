namespace PeluqueriaMascotasMVC.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<CarritoItem> Items { get; set; }
        public string Estado { get; set; }

        public decimal Total => Items?.Sum(i => i.Subtotal) ?? 0;
    }
}
