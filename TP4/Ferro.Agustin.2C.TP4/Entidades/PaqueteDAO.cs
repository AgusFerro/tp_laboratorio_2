using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlConnection conexion;
        private static SqlCommand comando;
        #endregion
        #region Metodos

        static PaqueteDAO()
        {
            conexion = new SqlConnection("Data Source = localhost; Database = correo-sp-2017; Trusted_Connection=True;");
        }

        public static bool Insertar(Paquete p)
        {
            bool success = false;
            comando = new SqlCommand("INSERT INTO Paquetes VALUES(@direccionEntrega,@trackingID,@alumno)",conexion);
            comando.Parameters.Clear();
            comando.Parameters.Add(new SqlParameter("direccionEntrega",p.DireccionEntrega));
            comando.Parameters.Add(new SqlParameter("trackingID", p.TrackingID));
            comando.Parameters.Add(new SqlParameter("alumno", "Agustin Ferro"));

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                success = true;
            }
            catch(Exception e)
            {
                success = false;
                throw new Exception("No se pudo insertar el Paquete en la tabla",e);
            }
            finally
            {
                conexion.Close();
            }
            return success;
        }
        #endregion
    }
}
