using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;

namespace Capa_Datos
{
    public class datSoftware
    {
        #region sigleton
        private static readonly datSoftware _instancia = new datSoftware();
        public static datSoftware Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region metodos
        //Agregar
        public Boolean InsertaSoftware(entSoftware software)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_AgregarSoftware", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", software.Nombre);
                cmd.Parameters.AddWithValue("@Version", software.Version);
                cmd.Parameters.AddWithValue("@Tipo", software.Tipo);
                cmd.Parameters.AddWithValue("@LicenciasDisponibles", software.Licencias_Disponibles);
                cmd.Parameters.AddWithValue("@LicenciasAsignadas", software.Licencias_Asignadas);
                cmd.Parameters.AddWithValue("@VencimientoLicencias", software.Vencimiento_Licencias);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserta = true; }
            }catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return inserta;
        }
        //Modificar
        public Boolean EditarSoftware(entSoftware software)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_ModificarSoftware", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Software", software.ID_Software);
                cmd.Parameters.AddWithValue("@Nombre", software.Nombre);
                cmd.Parameters.AddWithValue("@Version", software.Version);
                cmd.Parameters.AddWithValue("@Tipo", software.Tipo);
                cmd.Parameters.AddWithValue("@LicenciasDisponibles", software.Licencias_Disponibles);
                cmd.Parameters.AddWithValue("@LicenciasAsignadas", software.Licencias_Asignadas);
                cmd.Parameters.AddWithValue("@VencimientoLicencias", software.Vencimiento_Licencias);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { edita = true; }
            }catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return edita;
        }
        //Eliminar
        public Boolean EliminarSoftware(entSoftware software)
        {
            SqlCommand cmd = null;
            Boolean eliminar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_EliminarSoftware", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Software", software.ID_Software);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { eliminar = true; }
            }catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return eliminar;
        
        }


        #endregion metodos
    }
}

