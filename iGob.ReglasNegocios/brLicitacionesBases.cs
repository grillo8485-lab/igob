using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brLicitacionesBases:brConexion
    {
        public beLicitacionesBases traerLicitaciones_x_IdLicitacion_Bases(int IdLicitacion)
        {
            beLicitacionesBases obeLicitaciones = new beLicitacionesBases();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesBases odaLicitaciones = new daLicitacionesBases();
                    obeLicitaciones = odaLicitaciones.traerLicitaciones_x_IdLicitacion_Bases(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }


        public List<beLicitacionesBases> traerRequisicionesCondicionesEntregasDetalles_x_IdLicitacion_Bases(int IdLicitacion)
        {
            List<beLicitacionesBases> lbeRequisicionesCondicionesEntregasDetalles = new List<beLicitacionesBases>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesBases odaLicitaciones = new daLicitacionesBases();
                    lbeRequisicionesCondicionesEntregasDetalles = odaLicitaciones.traerRequisicionesCondicionesEntregasDetalles_x_IdLicitacion_Bases(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesEntregasDetalles;
            }
        }


        public List<beLicitacionesBases> traerRequisicionesCartas_x_IdLicitacion_Bases(int IdLicitacion)
        {
            List<beLicitacionesBases> lbeRequisicionesCartas = new List<beLicitacionesBases>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesBases odaLicitaciones = new daLicitacionesBases();
                    lbeRequisicionesCartas = odaLicitaciones.traerRequisicionesCartas_x_IdLicitacion_Bases(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCartas;
            }
        }
    }
}
