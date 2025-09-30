
namespace Ritrama2025
{
    public static class R
    {
        public class PARAMETERS
        {
            internal static string NAME_RELATION_OC_MASTER_DETAILS = "FK_MASTER_DETAILS";
        }
        public class QUERY
        {
            public class PRODUCTION
            {
                internal static string SQL_QUERY_LOAD_INVENTARIO_ROLLO_CORTADO = "SELECT product_id,product_name,roll_number,unique_code,width,large,msi,splice,numero,roll_id,code_person,status,disponible,ubic,fecha,despacho,fecha_despacho FROM rolls_details";
                internal static string SQL_QUERY_SELECT_LOAD_OC_HEADER = "SELECT numero,fecha,fecha_produccion,a.product_id,b.product_Name,rollid_1,width_1,lenght_1,rollid_2,width_2,lenght_2,util1_real_width,util1_real_lenght,util2_real_width,util2_real_lenght,rest1_width,rest1_lenght,rest2_width,rest2_lenght,a.operador_id,c.nombre,a.customer_id,d.customer_name,tot_inch_ancho,lenght_entrada,resta_entrada,total_salida,plus1_pies,plus2_pies,longitud_cortar,cortes_ancho,cortes_largo,cant_rollos,cant_rollos2,step,sellOrder,desperdicio,master_tipo FROM orden_corte a LEFT JOIN producto b ON a.product_id = b.product_id LEFT JOIN operadores c ON a.operador_id = c.operador_id LEFT JOIN customer d ON a.customer_id = d.customer_id ORDER BY numero";
                internal static string SQL_QUERY_SELECT_LOAD_OC_CORTES = "select num,width,lenght,msi,orden,code_person from cortes";
                internal static string SQL_QUERY_SELECT_LOAD_OC_ROLLO_CORTADO = "SELECT numero,product_id,product_name,roll_number,unique_code,splice,width,large,msi,roll_id,code_person,status,disponible,width_c,lenght_c,ubic,ratio,fecha,rollid_oculto FROM rolls_details";
                internal static string SQL_QUERY_SELECT_LOAD_ROLL_ID = "SELECT a.roll_id,a.part_number,b.product_name,a.Width,lenght, ISNULL(msi,0) AS msi,disponible, fecha_pro, fecha_recep, splice,Core,Ubicacion,'Inic.' AS tipo_mov,largo_consumido,(lenght - largo_consumido) as largo_restante,CASE WHEN largo_consumido=0 THEN 'Completo' WHEN (lenght - largo_consumido)=0 THEN 'Agotado' ELSE 'Parcialmente Consumido' END AS estado FROM MasterInic a LEFT JOIN producto b ON a.part_number = b.product_id where b.MasterRolls = 1 and a.disponible = 1 union SELECT a.rollid as roll_id,a.product_id as part_number,b.product_name,width,length,ISNULL(msi,0) AS msi,disponible=1,c.fecha_pro,c.fecha_recepcion as fecha_recep,splice,Core,ubicacion,'Importacion' AS tipo_mov,a.largo_consumido,a.largo_restante,a.estado FROM ItemsMateria a LEFT JOIN producto b ON a.product_id= b.product_id LEFT JOIN OrdenMateria c ON a.numero=c.numero WHERE b.MasterRolls=1";
                internal static string SQL_QUERY_SELECT_LOAD_OPERATOR = "SELECT operador_id,nombre,status FROM operadores";
                internal static string SQL_QUERY_SELECT_LOAD_CUSTOMER = "SELECT customer_id,customer_name FROM customer";

                internal static string SQL_QUERY_ACTUALIZAR_INVENTARIO_INICIALES = "UPDATE MasterInic SET largo_consumido=largo_consumido+@consumo WHERE roll_id=@rollid";
                internal static string SQL_QUERY_ACTUALIZAR_INVENTARIO_MATERIA = "UPDATE ItemsMateria SET largo_consumido=largo_consumido+@consumo WHERE rollid=@rollid";

                internal static string UPDATE_QUERY_ACTUALIZAR_INVENTARIO_DETAILS_INICIALES = "INSERT INTO MasterDetailsInic (rollid,orden,consumo,fecha_reg,desperdicio) VALUES(@rollid,@orden,@consumo,@fecha,@desperdicio)";

                internal static string SQL_SELECT_QUERY_LOAD_DETAILS_MASTER_INICIALES = "SELECT rollid,orden,consumo,fecha_reg,a.desperdicio,case when a.desperdicio=1 then 0 else b.cant_rollos end as cant_rollos,b.customer_id,c.Customer_Name FROM MasterDetailsInic a left join orden_corte b on a.orden=b.numero left join Customer c on b.customer_id=c.customer_id WHERE rollid=@rollid";
            }
        }
        public static class CONNECTIONSTRINGS
        {
            public static readonly string DESARROLLO = @"Data Source=DATABASE-CENTER\\RITRAMASRV01; Initial Catalog=RITRAMA2;User Id=Npino;Password=123;TrustServerCertificate=True;";
            public static readonly string PRODUCCION = "Data Source=RITRAMASRV01; Initial Catalog=RITRAMA3;User Id=Npino;Password=123;TrustServerCertificate=True;";
        }
        public static class ENVIRONMET
        {
            public static readonly string DESARROLLO = "Desarrollo";
            public static readonly string PRODUCCION = "Produccion";
            public static readonly string NAME_KEY_CONNECTION = "ConnectionStringsEnvironment";
        }
        public static class CONSTANTES
        {
            public const double FACTOR_METROS_PULDADAS = 39.3701;

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
            public const string REPORTS_INVENTARIOS = @"Reports\Inventario\";

        }
        public class REPORT_NAME
        {
            public const string REPORT_OC = @"RptOC.rdlc";
        }
        public class REPORT_TITLE
        {
            public const string REPORT_OC = @"REPORTE DE ORDEN DE CORTE.";
        }
        public static class SQL_STRING_QUERY
        {
            internal readonly static string SELECT_QUERY_PROVEEDORES = "SELECT Proveedor_ID,Proveedor_Name,phone,direccion,email,anulado,unidad_master_1,unidad_master_2  FROM provider";

            internal readonly static string SELECT_QUERY_TRANSPORTISTA = "SELECT transport_id,transport_name FROM transporte";

            internal readonly static string SELECT_QUERY_PRODUCTS = "SELECT product_id,product_name,case when MasterRolls=1 then 'Master' when rollo_cortado=1 then 'Rollo Cortado' when resmas=1 then 'Resma' when Graphics=1 then 'Graphics' end as tipo,product_descrip,product_ref,codebar,category_id,masterRolls,rollo_cortado,resmas,graphics,anulado,precio,code_rc,ratio FROM producto";

            internal readonly static string SELECT_QUERY_MP_MASTER = "select numero,fecha_recepcion,fecha_pro,proveedor_id,orden_compra,persona_respons,notas,CloseDocument,Anulado,transport_id,guia_import,lote,doc_embarque,estado,total_cantidad,fecha_hora_close,anulado,person_id from OrdenMateria";

            internal readonly static string SELECT_QUERY_MP_DETAILS = "select numero,product_id,type,cant_pedido,cant_real,width,length,msi,rollid,splice,ubicacion,core,empalme,fecha_produccion,factura,num_paleta,fecha_llegada from ItemsMateria";

            internal readonly static string SELECT_QUERY_PERSON = "SELECT person_id, person_name FROM person";
        }
        public static class ERROR_MESSAGE_SYSTEM
        {
            internal static readonly string ERROR_LOAD_PRODUCTS = "error al cargar los productos en el modulo de materia prima. error code: ";

            internal static readonly string ERROR_LOAD_MP_MASTER = "error al cargar la tabla de encabezado de recepciones de materia prima. error code: ";
            internal static readonly string ERROR_MP_DETAILS = "error al cargar la tabla de detalle de recepciones de materia prima. error code: ";
            internal static readonly string ERROR_MP_PROVEEDORES = "error al cargar la tabla de proveedores en el modulo de la materia prima. error code: ";

            internal static readonly string ERROR_MP_TRANSPORT = "error al cargar la tabla de proveedores. error code: ";
            internal static readonly string ERROR_LOAD_PERSON = "error al cargar la tabla de PERSON. error code: ";
        }
        public static class COMMAND
        {
            internal static readonly string CREATE_QUERY_PRODUCTS = "";
        }
    }
}
