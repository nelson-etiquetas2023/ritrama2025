using System.Data;

namespace Ritrama2025.Services.ExportData
{
    public interface IExportDataService
    {
        bool ExportToExcel<T>(List<T> data,string FileName);
        bool ExportTxtFormatRollosCortados(DataRow[] rollos,bool solo_rc,string? fecha_produccion,string? fecha_registro,bool openNotePad);
    }
}
