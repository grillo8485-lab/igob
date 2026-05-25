using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brLicitacionesAclaracionDudas:brConexion
    {
        public beLicitacionesAclaracionDudas traerLicitaciones_x_IdLicitacion_AclaracionDudas(int IdLicitacion)
        {
            beLicitacionesAclaracionDudas obeLicitaciones = new beLicitacionesAclaracionDudas();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesAclaracionDudas odaLicitaciones = new daLicitacionesAclaracionDudas();
                    obeLicitaciones = odaLicitaciones.traerLicitaciones_x_IdLicitacion_AclaracionDudas(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesAclaracionDudas> traerProveedoresPreguntas_x_IdLicitacion_AclaracionDudas(int IdLicitacion)
        {
            List<beLicitacionesAclaracionDudas> lbeProveedoresPreguntas = new List<beLicitacionesAclaracionDudas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesAclaracionDudas odaLicitaciones = new daLicitacionesAclaracionDudas();
                    lbeProveedoresPreguntas = odaLicitaciones.traerProveedoresPreguntas_x_IdLicitacion_AclaracionDudas(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeProveedoresPreguntas;
            }
        }
    }
}
