using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;


namespace iGob.ReglasNegocios
{
    public class brLicitacionesDictamen:brConexion
    {
        public beLicitacionesDictamen traerDictamen_Licitaciones_x_IdLicitacion(int IdLicitacion)
        {
            beLicitacionesDictamen obeLicitaciones = new beLicitacionesDictamen();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    obeLicitaciones = odaLicitaciones.traerDictamen_Licitaciones_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesDictamen> traerDictamen_PropuestasTecnicaEconomica_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerDictamen_PropuestasTecnicaEconomica_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesDictamen> traerDictamen_PropuestasTecnicaEconomicaLotes_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerDictamen_PropuestasTecnicaEconomicaLotes_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesDictamen> traerDictamen_Cartas_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerDictamen_Cartas_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesDictamen> traerDictamen_RequisicionesCondicionesEntregasDetalles_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerDictamen_RequisicionesCondicionesEntregasDetalles_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        /*
        public List<beLicitacionesDictamen> traerDictamen_RequisicionesCondicionesPagosDetalles_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerDictamen_RequisicionesCondicionesPagosDetalles_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }
        */

        public List<beLicitacionesDictamen> traerDictamen_ManifiestoProveedoresClientes_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerDictamen_ManifiestoProveedoresClientes_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesDictamen> traerDictamen_ManifiestoProveedoresDeclaratorias_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerDictamen_ManifiestoProveedoresDeclaratorias_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        /* IMPRESIONES */

        public beLicitacionesDictamen traerRep_Dictamen_Licitaciones_x_IdLicitacion(int IdLicitacion)
        {
            beLicitacionesDictamen obeLicitaciones = new beLicitacionesDictamen();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    obeLicitaciones = odaLicitaciones.traerRep_Dictamen_Licitaciones_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesDictamen> traerRep_Dictamen_PropuestasTecnicaEconomica_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerRep_Dictamen_PropuestasTecnicaEconomica_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesDictamen> traerRep_Dictamen_PropuestasTecnicaEconomicaLotes_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerRep_Dictamen_PropuestasTecnicaEconomicaLotes_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesDictamen> traerRep_Dictamen_Cartas_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerRep_Dictamen_Cartas_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesDictamen> traerRep_Dictamen_RequisicionesCondicionesEntregasDetalles_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerRep_Dictamen_RequisicionesCondicionesEntregasDetalles_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesDictamen> traerRep_Dictamen_RequisicionesCondicionesPagosDetalles_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerRep_Dictamen_RequisicionesCondicionesPagosDetalles_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesDictamen> traerRep_Dictamen_ManifiestoProveedoresClientes_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerRep_Dictamen_ManifiestoProveedoresClientes_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesDictamen> traerRep_Dictamen_ManifiestoProveedoresDeclaratorias_x_IdLicitacion(int IdLicitacion)
        {
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesDictamen odaLicitaciones = new daLicitacionesDictamen();
                    lbeLicitacionesDictamen = odaLicitaciones.traerRep_Dictamen_ManifiestoProveedoresDeclaratorias_x_IdLicitacion(con, IdLicitacion);
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
