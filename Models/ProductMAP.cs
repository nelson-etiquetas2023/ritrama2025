
namespace Ritrama2025.Models
{
    public class ProductMAP
    {
        public string Product_Id { get; set; } = null!;
        public string Product_Name { get; set; } = null!;
        public string Product_Type { get; set; } = null!;
        public double Width { get; set; }
        public double Length { get; set; }
        public double Msi { get; set; }
        public int Core { get; set; }
        public int Splice { get; set; }
        public string Rollid { get; set; } = null!;
        public string Ubic { get; set; } = null!;
        public int Cant { get; set; } 
    }
}
