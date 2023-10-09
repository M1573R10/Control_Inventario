using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class datProveedor
    {
        #region sigleton
        private static readonly datProveedor _instancia = new datProveedor();
        public static datProveedor Instancia { get { return _instancia; } }
        #endregion

        #region metodos

        //Agregar
        public Boolean InsertaProveedor(entProveedor proveedor)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_AgregarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RUCProveedor", proveedor.RUCProveedor);
                cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@Contacto", proveedor.Contacto);
                cmd.Parameters.AddWithValue("@Información_Contacto", proveedor.Informacion_Contacto);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserta = true; }
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return inserta;
        }
        //Modificar
        public Boolean EditarProveedor(entProveedor proveedor)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_ModificarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RUCProveedor", proveedor.RUCProveedor);
                cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@Contacto", proveedor.Contacto);
                cmd.Parameters.AddWithValue("@Información_Contacto", proveedor.Informacion_Contacto);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { edita = true; }
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return edita;
        }
        //Eliminar
        public Boolean EliminarProveedor(entProveedor proveedor)
        {
            SqlCommand cmd = null;
            Boolean eliminar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_DarBajaProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RUCProveedor", proveedor.RUCProveedor);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { eliminar = true; }
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return eliminar;
        }
        //Mostrar datos
        public List<entProveedor> ListarProveedor()
        {
            SqlCommand cmd = null;
            List<entProveedor> lista = new List<entProveedor>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("ListaProveedores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedor proveedor = new entProveedor();
                    proveedor.RUCProveedor = dr["RUCProveedor"].ToString();
                    proveedor.Nombre = dr["Nombre"].ToString();
                    proveedor.Contacto = dr["Contacto"].ToString();
                    proveedor.Informacion_Contacto = dr["Informacion_Contacto"].ToString();
                    lista.Add(proveedor);
                }
            } catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        #endregion metodos

    }
}
