using Ritrama2025.Models;
using System.Data;

namespace Ritrama2025.Services.ProduccionService
{
    public interface IProduccionService
    {
        Task<DataTable> LoadDataRollID();
        Task<DataSet> LoadDataOC();
        void GuardarEncabezadoOrdenCorte(Orden OrdenCorte);
        void GuardarCortes(List<Corte> cortes);
        void GuardarRollos(List<RolloCortado> rollos);
        bool UpdateStatusDocumentOC(int stepchange, string oc);
        int BuscarConsecOC();
        bool UpdateConsecOC(string consec);
        int BuscarUniqueCodeConsec();
        void UpdateUniqueCodeRollosCortados(List<RolloCortado> lista);
        bool UpdateUniqueCodeBD(string consec);
        public bool CheckOperatorDefault(string id, string name);
        public bool OrdenUpdateCodePerson(string orden, string code_person);
        public bool UpdateOrdenCorte(Orden orden);
        public Task<bool> UpdateInventaryMasterInitial(object objeto);
        public Task<DataTable?> LoadTableMasterInic();
        public Task<bool> UpdateDetailsConsumosMasterIniciales(string rollid, string orden, double length_consumo, DateTime fecha_reg, bool desperdicio);
        public Task<DataTable?> LoadDataDetailsConsumosMasterInic(string rollid);
        public void Update_Items_Orden_Corte(List<RolloCortado> rollos);
        public void Update_Header_Documnet_OC(Orden orden);
        public void RollosCortadosDispobnibles(string oc);
        public void GuardarConfigVueltas(List<ConfigVueltas> lista);
        public void UpdateConfigVueltas(List<ConfigVueltas> lista);
        public List<ConfigVueltas> GetConfigVueltas(string oc);
        bool AnularOrdenCorte(string numero_oc);

    }
}
