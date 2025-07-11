
namespace Ritrama2025.Models
{
    public class Product
    {
        public string Product_id { get; set; } = null!;
        public string Product_Name { get; set; } = null!;
        public string Product_Description { get; set; } = null!;
        public string Referencia { get; set; } = null!;
        public string Codigo_Barra { get; set; } = null!;
        public decimal Precio { get; set; }
        public string Categopria { get; set; } = null!;
        public string Ratio { get; set; } = null!;
        public bool Anulado { get; set; }
        public TipoProduct Tipo { get; set; }
    }
    public enum TipoProduct
    {
        Master,
        Graphics,
        Hoja,
        RolloCortado
    }
}


