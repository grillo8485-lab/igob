using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brRepCedulaProgramacion:brConexion
    {
        public beRepCedulaProgramacion traerRep_Cedula_Licitaciones_x_IdLicitacion(int IdLicitacion)
        {
            beRepCedulaProgramacion obeLicitaciones = new beRepCedulaProgramacion();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRepCedulaProgramacion odaLicitaciones = new daRepCedulaProgramacion();
                    obeLicitaciones = odaLicitaciones.traerRep_Cedula_Licitaciones_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beRepCedulaProgramacion> traerRep_Cedula_Requisiciones_x_IdLicitacion(int IdLicitacion)
        {
            List<beRepCedulaProgramacion> lbeReq = new List<beRepCedulaProgramacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRepCedulaProgramacion odaLicitaciones = new daRepCedulaProgramacion();
                    lbeReq = odaLicitaciones.traerRep_Cedula_Requisiciones_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeReq;
            }
        }
    }
}
