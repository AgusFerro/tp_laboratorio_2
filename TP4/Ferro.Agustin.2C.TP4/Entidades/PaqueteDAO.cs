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
        public delegate void DelegadoBase(string mensaje, Exception e);

        #region Atributos
        private static SqlConnection conexion;
        private static SqlCommand comando;
        #endregion
        #region Metodos
        /// <summary>
        /// Metodo estatico que instancia el atributo estatico conexion
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection("Data Source = localhost; Database = correo-sp-2017; Trusted_Connection=True;");
        }
        /// <summary>
        /// Metodo que devuelve true si un Paquete pudo insertarse en la Base
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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
                InformarException($"No se pudo insertar el Paquete {p.TrackingID} en la tabla", e);
            }
            finally
            {
                conexion.Close();
            }
            return success;
        }
        #endregion
        /// <summary>
        /// Evento que informa si se produce una Excepcion el en metodo PaqueteDAO.Insertar(Paquete p)
        /// </summary>
        public static event DelegadoBase InformarException;
    }
}
