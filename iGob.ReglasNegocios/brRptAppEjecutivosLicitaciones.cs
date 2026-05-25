using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brRptAppEjecutivosLicitaciones:brConexion
    {
        public beRptAppEjecutivosLicitaciones RepPresupuesto(int pIdGobierno)
        {
            beRptAppEjecutivosLicitaciones obeRep = new beRptAppEjecutivosLicitaciones();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRptAppEjecutivosLicitaciones odaRep = new daRptAppEjecutivosLicitaciones();
                    obeRep = odaRep.RepPresupuesto(con, pIdGobierno);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }

        public beRptAppEjecutivosLicitaciones RepAdquisiciones(int pIdGobierno)
        {
            beRptAppEjecutivosLicitaciones obeRep = new beRptAppEjecutivosLicitaciones();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRptAppEjecutivosLicitaciones odaRep = new daRptAppEjecutivosLicitaciones();
                    obeRep = odaRep.RepAdquisiciones(con, pIdGobierno);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }

        public beRptAppEjecutivosLicitaciones RepPresupuestoDep(int pIdDependencia)
        {
            beRptAppEjecutivosLicitaciones obeRep = new beRptAppEjecutivosLicitaciones();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRptAppEjecutivosLicitaciones odaRep = new daRptAppEjecutivosLicitaciones();
                    obeRep = odaRep.RepPresupuestoDep(con, pIdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }

        public beRptAppEjecutivosLicitaciones RepAdquisicionesDep(int pIdDependencia)
        {
            beRptAppEjecutivosLicitaciones obeRep = new beRptAppEjecutivosLicitaciones();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRptAppEjecutivosLicitaciones odaRep = new daRptAppEjecutivosLicitaciones();
                    obeRep = odaRep.RepAdquisicionesDep(con, pIdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }

        public List<beRptAppEjecutivosLicitaciones> ListaDependencias(string pNombreProducto)
        {
            List<beRptAppEjecutivosLicitaciones> lbeRep = new List<beRptAppEjecutivosLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRptAppEjecutivosLicitaciones odaRep = new daRptAppEjecutivosLicitaciones();
                    lbeRep = odaRep.ListaDependencias(con, pNombreProducto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRep;
            }
        }

        public List<beRptAppEjecutivosLicitaciones> ListaProductos(string pNombreProducto)
        {
            List<beRptAppEjecutivosLicitaciones> lbeRep = new List<beRptAppEjecutivosLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRptAppEjecutivosLicitaciones odaRep = new daRptAppEjecutivosLicitaciones();
                    lbeRep = odaRep.ListaProductos(con, pNombreProducto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRep;
            }
        }

        public beRptAppEjecutivosLicitaciones PrecioProducto(int pIdBienServicio)
        {
            beRptAppEjecutivosLicitaciones obeRep = new beRptAppEjecutivosLicitaciones();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRptAppEjecutivosLicitaciones odaRep = new daRptAppEjecutivosLicitaciones();
                    obeRep = odaRep.PrecioProducto(con, pIdBienServicio);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }

        public List<beRptAppEjecutivosLicitaciones> ListaProveedores(string pNombreProducto)
        {
            List<beRptAppEjecutivosLicitaciones> lbeRep = new List<beRptAppEjecutivosLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRptAppEjecutivosLicitaciones odaRep = new daRptAppEjecutivosLicitaciones();
                    lbeRep = odaRep.ListaProveedores(con, pNombreProducto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRep;
            }
        }

        public List<beRptAppEjecutivosLicitaciones> AdquisicionesProveedoresDependencias(int pIdProveedor)
        {
            List<beRptAppEjecutivosLicitaciones> lbeRep = new List<beRptAppEjecutivosLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRptAppEjecutivosLicitaciones odaRep = new daRptAppEjecutivosLicitaciones();
                    lbeRep = odaRep.AdquisicionesProveedoresDependencias(con, pIdProveedor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRep;
            }
        }

        public beRptAppEjecutivosLicitaciones AdquisicionesDependenciaProveedor(int pIdDependencia, int pIdProveedor)
        {
            beRptAppEjecutivosLicitaciones obeRep = new beRptAppEjecutivosLicitaciones();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRptAppEjecutivosLicitaciones odaRep = new daRptAppEjecutivosLicitaciones();
                    obeRep = odaRep.AdquisicionesDependenciaProveedor(con, pIdDependencia, pIdProveedor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }
    }
}
