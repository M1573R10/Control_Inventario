using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;

namespace Capa_Datos
{
    public class datCicloAcademico
    {
        #region sigleton

        private static readonly datCicloAcademico _instancia = new datCicloAcademico();
        public static datCicloAcademico Instancia { get { return _instancia; } }

        #endregion

        #region metodos

        //Agregar
        public Boolean InsertaCicloAcademico(entCicloAcademico cicloAcademico)
        {
            SqlCommand cmd = new SqlCommand();
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_AgregarCicloAcademico", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Ciclo_Academico", cicloAcademico.ID_Ciclo_Academico);
                cmd.Parameters.AddWithValue("@Detalle", cicloAcademico.Detalle);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if ( i > 0 ) { inserta = true; }
            }catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return inserta;
        }

        #endregion
    }
}
