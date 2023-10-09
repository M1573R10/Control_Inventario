using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class datLicencia_Software
    {
        private string connectionString = "Data Source=DESKTOP-CD78G6K;Initial Catalog=Sistema_Control_Inventario;Integrated Security=True";

        public void GestionarLicencia(string operacion, int? idLicencia = null, int? cantidadLicencias = null, string proveedor = null, DateTime? fechaVencimiento = null, int? idSoftware = null, DateTime? fechaRegistro = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("GestionarLicenciaSoftware", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", operacion);
                    cmd.Parameters.AddWithValue("@ID_Licencia", idLicencia);
                    cmd.Parameters.AddWithValue("@Cantidad_Licencias", cantidadLicencias);
                    cmd.Parameters.AddWithValue("@Proveedor", proveedor);
                    cmd.Parameters.AddWithValue("@Fecha_Vencimiento", fechaVencimiento);
                    cmd.Parameters.AddWithValue("@ID_Software", idSoftware);
                    cmd.Parameters.AddWithValue("@Fecha_Registro", fechaRegistro);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
