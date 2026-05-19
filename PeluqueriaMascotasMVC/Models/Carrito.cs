namespace PeluqueriaMascotasMVC.Models
{
    public class Carrito
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
        public Cliente Cliente { get; set; }
        public List<CarritoItem> CarritoItems { get; set; }
        public DateTime FechaCreacion { get; set; }

        public decimal Subtotal
        {
            get
            {
                return CarritoItems?.Sum(item => item.Subtotal) ?? 0;
            }
        }

        public Carrito() 
        {
            CarritoItems = new List<CarritoItem>();
            FechaCreacion = DateTime.Now;
        }

        public Carrito(Cliente cliente) : this()
        {
            Cliente = cliente;
            Activo = true;
        }

        public void AgregarItem(CarritoItem item)
        {
            if (item != null)
            {
                CarritoItems.Add(item);
            }
        }

        public void EliminarItem(CarritoItem item)
        {
            if (item != null)
            {
                CarritoItems.Remove(item);
            }
        }

        public void Limpiar()
        {
            CarritoItems.Clear();
        }
    }
}
