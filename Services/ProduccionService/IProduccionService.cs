using Ritrama2025.Models;
using System.Data;

namespace Ritrama2025.Services.ProduccionService
{
    public interface IProduccionService
    {
        Task<DataSet> LoadDataOC();
        void GuardarEncabezadoOrdenCorte(Orden OrdenCorte);
        void GuardarCortes(List<Corte> cortes);
        void GuardarRollos(List<RolloCortado> rollos);
        bool UpdateStatusDocumentOC(int stepchange,string oc);
        int BuscarConsecOC();
        bool UpdateConsecOC(string consec);
        int BuscarUniqueCodeConsec();
        void UpdateUniqueCodeRollosCortados(List<RolloCortado> lista);
        bool UpdateUniqueCodeBD(string consec);
        public bool CheckOperatorDefault(string id, string name);
        public bool OrdenUpdateCodePerson(string orden,string code_person);
        public bool UpdateOrdenCorte(Orden orden);
    }
}
