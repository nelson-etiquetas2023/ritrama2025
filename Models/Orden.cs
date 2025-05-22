
namespace Ritrama2025.Models
{
    public class Orden
    {
        public List<Roll_Details> rollos = null!;
        public List<Corte>? Cortes;
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Fecha_produccion { get; set; }
        public decimal Lenght_entrada { get; set; }
        public decimal Resta_entrada { get; set; }
        public decimal Salida_pies { get; set; }
        public string Rollid_1 { get; set; } = null!;
        public decimal Width_1 { get; set; }
        public decimal Lenght_1 { get; set; }
        public double Descartable1_pies { get; set; }
        public decimal Plus1_pies { get; set; }
        public double Master_lenght1_Real { get; set; }
        public double Util1_Real_Width { get; set; }
        public double Util1_real_Lenght { get; set; }
        public double Rest1_width { get; set; }
        public double Rest1_lenght { get; set; }
        public string Tipo_Mov1 { get; set; } = null!;
        public string Rollid_2 { get; set; } = null!;
        public decimal Width_2 { get; set; }
        public decimal Lenght_2 { get; set; }
        public double Descartable2_pies { get; set; }
        public decimal Plus2_pies { get; set; }
        public double Master_lenght2_Real { get; set; }
        public double Util2_Real_Width { get; set; }
        public double Util2_real_Lenght { get; set; }
        public double Rest2_width { get; set; }
        public double Rest2_lenght { get; set; }
        public string Tipo_Mov2 { get; set; } = null!;
        public string Product_id { get; set; } = null!;
        public string Product_name { get; set; } = null!;
        public bool Anulada { get; set; }
        public bool Procesado { get; set; }
        public int Status { get; set; }
        public double Inch_Ancho { get; set; }
        public double Longitud_Cortar { get; set; }
        public int Cortes_Ancho { get; set; } 
        public int Cortes_Largo { get; set; }
        public int Cortes_Largo2 { get; set; }
        public int Cantidad_Rollos { get; set; }
        public int Cantidad_Rollos2 { get; set; }
        public int STATE { get; set; }
        public bool Rebobinado { get; set; }
        public DateTime LastUpdate { get; set; }
        public double Real_usado_r1 { get; set; }
        public double Real_usado_r2 { get; set; }
        public bool Rollo_unificado { get; set; }
        public string Id_operador { get; set; } = null!;
        public string Rollid_oculto { get; set; } = null!;
        public string Restante_rollid1 { get; set; } = null!;
        public string Restante_rollid2 { get; set; } = null!;
    }
}

