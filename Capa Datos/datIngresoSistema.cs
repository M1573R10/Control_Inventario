using System;
using System.Collections.Generic;
using System.Data;
using Capa_Datos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class datIngresoSistema
    {
        private string connectionString = "Data Source=DESKTOP-4QQ7SJ4;Initial Catalog=Sistema_Control_Inventario;Integrated Security=True";
        public (string mensaje, string rol) IniciarSesion(string nombreUsuario, string contrasena)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
            conn.Open();

            using (SqlCommand command = new SqlCommand("SP_IniciarSesion", conn))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Correo", nombreUsuario);
                command.Parameters.AddWithValue("@Password", contrasena);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string mensaje = reader["Mensaje"].ToString();
                        string rol = reader["Rol"].ToString();
                        return (mensaje, rol);
                    }
                }
            }
        }

        return ("Error de inicio de sesión", null);
}
}

}

