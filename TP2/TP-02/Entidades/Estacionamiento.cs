﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        List<Vehiculo> vehiculos;
        int espacioDisponible;
        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #region "Constructores"
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Estacionamiento(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            return Estacionamiento.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder cadenaEstacionamiento = new StringBuilder();

            cadenaEstacionamiento.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.vehiculos.Count, c.espacioDisponible);
            cadenaEstacionamiento.AppendLine("");
            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if (v is Camioneta)
                        {
                            cadenaEstacionamiento.AppendLine(((Camioneta)v).Mostrar());
                        }
                        break;
                    case ETipo.Moto:
                        if (v is Moto)
                        {
                            cadenaEstacionamiento.AppendLine(((Moto)v).Mostrar());
                        }
                        break;
                    case ETipo.Automovil:
                        if (v is Automovil)
                        {
                            cadenaEstacionamiento.AppendLine(((Automovil)v).Mostrar());
                        }
                        break;
                    default:
                        if (v is Camioneta)
                        {
                            cadenaEstacionamiento.AppendLine(((Camioneta)v).Mostrar());
                        }
                        else if (v is Moto)
                        {
                            cadenaEstacionamiento.AppendLine(((Moto)v).Mostrar());
                        }
                        else if (v is Automovil)
                        {
                            cadenaEstacionamiento.AppendLine(((Automovil)v).Mostrar());
                        }
                            break;
                }
            }

            return cadenaEstacionamiento.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            if (c.vehiculos.Count < c.espacioDisponible)
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (v == p)
                    {
                        return c;
                    }
                }

                c.vehiculos.Add(p);
            }
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="estacionamiento">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            if (c.vehiculos.Count > 0)
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (v == p)
                    {
                        c.vehiculos.Remove(v);
                        break;
                    }
                }
            }
            return c;
        }
        #endregion
    }
}
