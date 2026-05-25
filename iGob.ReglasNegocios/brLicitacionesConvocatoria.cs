using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brLicitacionesConvocatoria:brConexion
    {
        public beLicitacionesConvocatoria traerLicitaciones_x_IdLicitacion_Convocatoria(int IdLicitacion)
        {
            beLicitacionesConvocatoria obeLicitaciones = new beLicitacionesConvocatoria();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesConvocatoria odaLicitaciones = new daLicitacionesConvocatoria();
                    obeLicitaciones = odaLicitaciones.traerLicitaciones_x_IdLicitacion_Convocatoria(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesConvocatoria> traerRequisicionesLotes_x_IdLicitacion_Convocatoria(int IdLicitacion)
        {
            List<beLicitacionesConvocatoria> lbeRequisicionesLotes = new List<beLicitacionesConvocatoria>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesConvocatoria odaLicitaciones = new daLicitacionesConvocatoria();
                    lbeRequisicionesLotes = odaLicitaciones.traerRequisicionesLotes_x_IdLicitacion_Convocatoria(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }
    }
}
