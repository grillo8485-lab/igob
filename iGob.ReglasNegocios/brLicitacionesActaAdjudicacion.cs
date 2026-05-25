using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brLicitacionesActaAdjudicacion:brConexion
    {
        public beLicitacionesActaAdjudicacion traerActaAdjudicacion_Licitaciones_x_IdLicitacion(int IdLicitacion)
        {
            beLicitacionesActaAdjudicacion obeLicitaciones = new beLicitacionesActaAdjudicacion();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaAdjudicacion odaLicitaciones = new daLicitacionesActaAdjudicacion();
                    obeLicitaciones = odaLicitaciones.traerActaAdjudicacion_Licitaciones_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesActaAdjudicacion> traerActaAdjudicacion_Requisiciones_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesActaAdjudicacion> lbeLicitacionesDictamen = new List<beLicitacionesActaAdjudicacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaAdjudicacion odaLicitaciones = new daLicitacionesActaAdjudicacion();
                    lbeLicitacionesDictamen = odaLicitaciones.traerActaAdjudicacion_Requisiciones_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesActaAdjudicacion> traerActaAdjudicacion_Lotes_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesActaAdjudicacion> lbeLicitacionesDictamen = new List<beLicitacionesActaAdjudicacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaAdjudicacion odaLicitaciones = new daLicitacionesActaAdjudicacion();
                    lbeLicitacionesDictamen = odaLicitaciones.traerActaAdjudicacion_Lotes_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public beLicitacionesActaAdjudicacion traerRep_ActaAdjudicacion_Licitaciones_x_IdLicitacion(int IdLicitacion)
        {
            beLicitacionesActaAdjudicacion obeLicitaciones = new beLicitacionesActaAdjudicacion();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaAdjudicacion odaLicitaciones = new daLicitacionesActaAdjudicacion();
                    obeLicitaciones = odaLicitaciones.traerRep_ActaAdjudicacion_Licitaciones_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesActaAdjudicacion> traerRep_ActaAdjudicacion_Requisiciones_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesActaAdjudicacion> lbeLicitacionesDictamen = new List<beLicitacionesActaAdjudicacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaAdjudicacion odaLicitaciones = new daLicitacionesActaAdjudicacion();
                    lbeLicitacionesDictamen = odaLicitaciones.traerRep_ActaAdjudicacion_Requisiciones_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesActaAdjudicacion> traerRep_ActaAdjudicacion_Lotes_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesActaAdjudicacion> lbeLicitacionesDictamen = new List<beLicitacionesActaAdjudicacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesActaAdjudicacion odaLicitaciones = new daLicitacionesActaAdjudicacion();
                    lbeLicitacionesDictamen = odaLicitaciones.traerRep_ActaAdjudicacion_Lotes_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }
    }
}
