using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brActividadesEconomicas : brConexion
    {
        public int guardarActividadesEconomicas(beActividadesEconomicas obeActividadesEconomicas)
        {
            int IdActividadEconomica;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daActividadesEconomicas odaActividadesEconomicas = new daActividadesEconomicas();
                    IdActividadEconomica = odaActividadesEconomicas.guardarActividadesEconomicas(con, obeActividadesEconomicas);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdActividadEconomica;
            }
        }

        public int actualizarActividadesEconomicas(beActividadesEconomicas obeActividadesEconomicas)
        {
            int IdActividadEconomica;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daActividadesEconomicas odaActividadesEconomicas = new daActividadesEconomicas();
                    IdActividadEconomica = odaActividadesEconomicas.actualizarActividadesEconomicas(con, obeActividadesEconomicas);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdActividadEconomica;
            }
        }

        public int eliminarActividadesEconomicas(int IdActividadEconomica)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daActividadesEconomicas odaActividadesEconomicas = new daActividadesEconomicas();
                    IdActividadEconomica = odaActividadesEconomicas.eliminarActividadesEconomicas(con, IdActividadEconomica);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdActividadEconomica;
            }
        }

        public beActividadesEconomicas traerActividadesEconomicas_x_IdActividadEconomica(int IdActividadEconomica)
        {
            beActividadesEconomicas obeActividadesEconomicas = new beActividadesEconomicas();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daActividadesEconomicas odaActividadesEconomicas = new daActividadesEconomicas();
                    obeActividadesEconomicas = odaActividadesEconomicas.traerActividadesEconomicas_x_IdActividadEconomica(con, IdActividadEconomica);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeActividadesEconomicas;
            }
        }

        public List<beActividadesEconomicas> listarTodos_ActividadesEconomicas()
        {
            List<beActividadesEconomicas> lbeActividadesEconomicas = new List<beActividadesEconomicas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daActividadesEconomicas odaActividadesEconomicas = new daActividadesEconomicas();
                    lbeActividadesEconomicas = odaActividadesEconomicas.listarTodos_ActividadesEconomicas(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeActividadesEconomicas;
            }
        }
    }
}
