
namespace Ritrama2025
{
    public static class R
    {
        public static class CONSTANTES
        {
            public const  double FACTOR_METROS_PULDADAS = 39.3701;

            public const double FACTOR_METROS_PIES = 3.28084;

            public const double FACTOR_PULGADAS_METROS = 0.0254;

            public const double FACTOR_PIES_METROS = 0.3048;

            public const double FACTOR_CALCULO_MSI = 0.012;

            public const double FACTOR_MM_PULGADAS = 0.0393701;
        }
        public class PATH_REPORTS 
        {
            public const string REPORTS_DESPACHO = @"Reports";
            public const string REPORTS_PRODUCTION = @"Reports\Production\";
        }
        public class REPORT_NAME 
        {
            public const string REPORT_OC = @"ReporteOC.rdlc";
        }
        public class REPORT_TITLE 
        {
            public const string REPORT_OC = @"REPORTE DE ORDEN DE CORTE.";
        }
        public static class SQL_STRING_QUERY 
        {
            public readonly static string SELECT_QUERY_PROVEEDORES  = "SELECT Proveedor_ID,Proveedor_Name,phone,direccion,email,anulado,unidad_master_1,unidad_master_2  FROM provider";

            public readonly static string SELECT_QUERY_TRANSPORTISTA = "SELECT transport_id,transport_name FROM transporte";

            public readonly static string SELECT_QUERY_PRODUCTS = "SELECT product_id,product_name,case when MasterRolls=1 then 'Master' when rollo_cortado=1 then 'Rollo Cortado' when resmas=1 then 'Resma' when Graphics=1 then 'Graphics' end as tipo,product_descrip,product_ref,codebar,category_id,masterRolls,rollo_cortado,resmas,graphics,anulado,precio,code_rc,ratio FROM producto";

            public readonly static string SELECT_QUERY_MP_MASTER = "select numero,fecha_recepcion,fecha_pro,proveedor_id,orden_compra,persona_respons,notas,CloseDocument,transport_id,guia_import,lote,doc_embarque,estado,total_cantidad,fecha_hora_close,anulado,person_id from OrdenMateria";

            public readonly static string SELECT_QUERY_MP_DETAILS = "select numero,product_id,type,cant_pedido,cant_real,width,length,msi,rollid,splice,ubicacion,core from ItemsMateria";

            public readonly static string SELECT_QUERY_PERSON = "SELECT person_id, person_name FROM person";

        }
        public static class ERROR_MESSAGE_SYSTEM 
        {
            public static readonly string ERROR_LOAD_PRODUCTS = "error al cargar los productos en el modulo de materia prima. error code: ";

            public static readonly string ERROR_LOAD_MP_MASTER = "error al cargar la tabla de encabezado de recepciones de materia prima. error code: ";
            public static readonly string ERROR_MP_DETAILS = "error al cargar la tabla de detalle de recepciones de materia prima. error code: ";
            public static readonly string ERROR_MP_PROVEEDORES = "error al cargar la tabla de proveedores en el modulo de la materia prima. error code: ";

            public static readonly string ERROR_MP_TRANSPORT = "error al cargar la tabla de proveedores. error code: ";
            public static readonly string ERROR_LOAD_PERSON = "error al cargar la tabla de PERSON. error code: ";

        }
        public static class  COMMAND
        {
            public static readonly string CREATE_QUERY_PRODUCTS = "";
        }
    }
}
