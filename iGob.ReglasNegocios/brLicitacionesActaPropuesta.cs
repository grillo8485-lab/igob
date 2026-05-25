using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brLicitacionesActaPropuesta:brConexion
    {
        public beLicitacionesActaPropuesta traerLicitaciones_x_IdLicitacion_ActaApertura(int IdLicitacion)
        {
            beLicitacionesActaPropuesta obeLicitaciones = new beLicitacionesActaPropuesta();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaPropuesta odaLicitaciones = new daLicitacionesActaPropuesta();
                    obeLicitaciones = odaLicitaciones.traerLicitaciones_x_IdLicitacion_ActaApertura(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesActaPropuesta> traerPropuestasTecnicaEconomica_x_IdLicitacion_ActaApertura(int IdLicitacion)
        {
            List<beLicitacionesActaPropuesta> lbePropuestas = new List<beLicitacionesActaPropuesta>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaPropuesta odaLicitaciones = new daLicitacionesActaPropuesta();
                    lbePropuestas = odaLicitaciones.traerPropuestasTecnicaEconomica_x_IdLicitacion_ActaApertura(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePropuestas;
            }
        }


        public beLicitacionesActaPropuesta traerRep_Licitaciones_x_IdLicitacion_ActaApertura(int IdLicitacion)
        {
            beLicitacionesActaPropuesta obeLicitaciones = new beLicitacionesActaPropuesta();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaPropuesta odaLicitaciones = new daLicitacionesActaPropuesta();
                    obeLicitaciones = odaLicitaciones.traerRep_Licitaciones_x_IdLicitacion_ActaApertura(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesActaPropuesta> traerRep_PropuestasTecnicaEconomica_x_IdLicitacion_ActaApertura(int IdLicitacion)
        {
            List<beLicitacionesActaPropuesta> lbePropuestas = new List<beLicitacionesActaPropuesta>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaPropuesta odaLicitaciones = new daLicitacionesActaPropuesta();
                    lbePropuestas = odaLicitaciones.traerRep_PropuestasTecnicaEconomica_x_IdLicitacion_ActaApertura(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePropuestas;
            }
        }
    }
}
