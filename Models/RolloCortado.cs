namespace Ritrama2025.Models
{
    public class RolloCortado
    {
        public int RollNumber { get; set; }

        public string Product_Id { get; set; } = null!;
        public string Product_Name { get; set; } = null!;
        public string UniqueCode { get; set; } = null!;
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal Msi { get; set; }
        public int Splice { get; set; }
        public string Roll_Id { get; set; } = null!;
        public string Code_Person { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public int Cantidad_despacho { get; set; }
        public int Cantidad { get; set; }
        public string Tipo { get; set; } = null!;
        public string Paleta { get; set; } = null!;
        public bool Disponible { get; set; }
        public string Numero { get; set; } = null!;
        public string tipo_mov { get; set; } = null!;
        public int vuelta { get; set; }
    }
}
