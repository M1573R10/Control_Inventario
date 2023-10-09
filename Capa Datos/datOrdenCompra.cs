using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Capa_Datos
{
    public class datOrdenCompra
    {
        private string connectionString = "Data Source=DESKTOP-4QQ7SJ4;Initial Catalog=Sistema_Control_Inventario;Integrated Security=True";
        public int InsertarOrdenCompra(entOrdenCompra ordenCompra, entDetalleOrdenCompra detalle)
        {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insertar en la tabla Orden_Compra
                            SqlCommand cmdOrdenCompra = new SqlCommand("InsertarOrdenCompra", connection, transaction);
                            cmdOrdenCompra.CommandType = CommandType.StoredProcedure;

                            cmdOrdenCompra.Parameters.AddWithValue("@RUCProveedor", ordenCompra.RUCProveedor);
                            cmdOrdenCompra.Parameters.AddWithValue("@Fecha", ordenCompra.Fecha);
                            cmdOrdenCompra.Parameters.AddWithValue("@Estado", ordenCompra.Estado);
                            cmdOrdenCompra.Parameters.AddWithValue("@Tipo", ordenCompra.Tipo);

                            SqlParameter orderIdParameter = new SqlParameter("@ID_Orden_Compra", SqlDbType.Int);
                            orderIdParameter.Direction = ParameterDirection.Output;
                            cmdOrdenCompra.Parameters.Add(orderIdParameter);

                            cmdOrdenCompra.ExecuteNonQuery();

                            int orderId = Convert.ToInt32(orderIdParameter.Value);

                            // Insertar en la tabla Det_Orden_Compra
                            SqlCommand cmdDetalleOrdenCompra = new SqlCommand("InsertarDetOrdenCompra", connection, transaction);
                            cmdDetalleOrdenCompra.CommandType = CommandType.StoredProcedure;

                            cmdDetalleOrdenCompra.Parameters.AddWithValue("@ID_Software", detalle.ID_Software);
                            cmdDetalleOrdenCompra.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            cmdDetalleOrdenCompra.Parameters.AddWithValue("@Monto", detalle.Monto);
                            cmdDetalleOrdenCompra.Parameters.AddWithValue("@Monto_Total", detalle.Monto_Total);
                            cmdDetalleOrdenCompra.Parameters.AddWithValue("@ID_Orden_Compra", orderId);

                            cmdDetalleOrdenCompra.ExecuteNonQuery();

                            transaction.Commit();

                            return orderId;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }


        
}