using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brLicitacionesActaFallo:brConexion
    {
        public beLicitacionesActaFallo traerActaFallo_Licitaciones_x_IdLicitacion(int IdLicitacion)
        {
            beLicitacionesActaFallo obeLicitaciones = new beLicitacionesActaFallo();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaFallo odaLicitaciones = new daLicitacionesActaFallo();
                    obeLicitaciones = odaLicitaciones.traerActaFallo_Licitaciones_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesActaFallo> traerActaFallo_PropuestasTecnicaEconomica_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesActaFallo> lbeLicitacionesActaFallo = new List<beLicitacionesActaFallo>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaFallo odaLicitaciones = new daLicitacionesActaFallo();
                    lbeLicitacionesActaFallo = odaLicitaciones.traerActaFallo_PropuestasTecnicaEconomica_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesActaFallo;
            }
        }

        public beLicitacionesActaFallo traerRep_ActaFallo_Licitaciones_x_IdLicitacion(int IdLicitacion)
        {
            beLicitacionesActaFallo obeLicitaciones = new beLicitacionesActaFallo();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaFallo odaLicitaciones = new daLicitacionesActaFallo();
                    obeLicitaciones = odaLicitaciones.traerRep_ActaFallo_Licitaciones_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesActaFallo> traerRep_ActaFallo_PropuestasTecnicaEconomica_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesActaFallo> lbeLicitacionesActaFallo = new List<beLicitacionesActaFallo>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaFallo odaLicitaciones = new daLicitacionesActaFallo();
                    lbeLicitacionesActaFallo = odaLicitaciones.traerRep_ActaFallo_PropuestasTecnicaEconomica_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesActaFallo;
            }
        }
    }
}
