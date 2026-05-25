using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRptAppEjecutivosLicitaciones
    {
        public beRptAppEjecutivosLicitaciones RepPresupuesto(SqlConnection Conexion, int pIdGobierno)
        {
            string sp = "Proc_RptAppEjecutivosLicitaciones";
            beRptAppEjecutivosLicitaciones obeRep = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pIdGobierno", SqlDbType.Int).Value = pIdGobierno;
            cmd.Parameters.Add("@pReporte", SqlDbType.Char).Value = "GOBGGP";
            cmd.Parameters.Add("@pIdDependencia", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pIdProveedor", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pNombreProducto", SqlDbType.Char).Value = "";
            cmd.Parameters.Add("@pIdBienServicio", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pAuxiliar", SqlDbType.Char).Value = "";
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posEstado = datard.GetOrdinal("Estado");
                        int posMontoPresupuestadoTotal = datard.GetOrdinal("MontoPresupuestadoTotal");
                        int posMontoTotalEjercido = datard.GetOrdinal("MontoTotalEjercido");
                        int posMontoxEjercer = datard.GetOrdinal("MontoxEjercer");
                        int posEconomia = datard.GetOrdinal("Economia");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");

                        obeRep = new beRptAppEjecutivosLicitaciones();
                        while (datard.Read())
                        {
                            obeRep.Estado = datard.GetString(posEstado);
                            obeRep.MontoPresupuestadoTotal = datard.GetDecimal(posMontoPresupuestadoTotal);
                            obeRep.MontoTotalEjercido = datard.GetDecimal(posMontoTotalEjercido);
                            obeRep.MontoxEjercer = datard.GetDecimal(posMontoxEjercer);
                            obeRep.Economia = datard.GetDecimal(posEconomia);
                            obeRep.Ejercicio = datard.GetInt32(posEjercicio);

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }

        public beRptAppEjecutivosLicitaciones RepAdquisiciones(SqlConnection Conexion, int pIdGobierno)
        {
            string sp = "Proc_RptAppEjecutivosLicitaciones";
            beRptAppEjecutivosLicitaciones obeRep = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pIdGobierno", SqlDbType.Int).Value = pIdGobierno;
            cmd.Parameters.Add("@pReporte", SqlDbType.Char).Value = "GOBGGA";
            cmd.Parameters.Add("@pIdDependencia", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pIdProveedor", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pNombreProducto", SqlDbType.Char).Value = "";
            cmd.Parameters.Add("@pIdBienServicio", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pAuxiliar", SqlDbType.Char).Value = "";
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posEstado = datard.GetOrdinal("Estado");
                        int posMontoPresupuestadoTotal = datard.GetOrdinal("MontoPresupuestadoTotal");
                        int posMontoAdjudicadoTotal = datard.GetOrdinal("MontoAdjudicadoTotal");
                        int posMontoTotalLicitaAbierta = datard.GetOrdinal("MontoTotalLicitaAbierta");
                        int posMontoTotalDirecta = datard.GetOrdinal("MontoTotalDirecta");
                        int posMontoTotalRestringida = datard.GetOrdinal("MontoTotalRestringida");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");

                        obeRep = new beRptAppEjecutivosLicitaciones();
                        while (datard.Read())
                        {
                            obeRep.Estado = datard.GetString(posEstado);
                            obeRep.MontoPresupuestadoTotal = datard.GetDecimal(posMontoPresupuestadoTotal);
                            obeRep.MontoAdjudicadoTotal = datard.GetDecimal(posMontoAdjudicadoTotal);
                            obeRep.MontoTotalLicitaAbierta = datard.GetDecimal(posMontoTotalLicitaAbierta);
                            obeRep.MontoTotalDirecta = datard.GetDecimal(posMontoTotalDirecta);
                            obeRep.MontoTotalRestringida = datard.GetDecimal(posMontoTotalRestringida);
                            obeRep.Ejercicio = datard.GetInt32(posEjercicio);

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }

        public beRptAppEjecutivosLicitaciones RepPresupuestoDep(SqlConnection Conexion, int pIdDependencia)
        {
            string sp = "Proc_RptAppEjecutivosLicitaciones";
            beRptAppEjecutivosLicitaciones obeRep = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pIdGobierno", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pReporte", SqlDbType.Char).Value = "GGPDEP";
            cmd.Parameters.Add("@pIdDependencia", SqlDbType.Int).Value = pIdDependencia;
            cmd.Parameters.Add("@pIdProveedor", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pNombreProducto", SqlDbType.Char).Value = "";
            cmd.Parameters.Add("@pIdBienServicio", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pAuxiliar", SqlDbType.Char).Value = "";
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        int posPresupuestoDependencia = datard.GetOrdinal("PresupuestoDependencia");
                        int posPresupuestoEjercido = datard.GetOrdinal("PresupuestoEjercido");
                        int posPresupuestoxEjercer = datard.GetOrdinal("PresupuestoxEjercer");
                        int posMontoTotalEconomia = datard.GetOrdinal("MontoTotalEconomia");

                        obeRep = new beRptAppEjecutivosLicitaciones();
                        while (datard.Read())
                        {
                            obeRep.Dependencia = datard.GetString(posDependencia);
                            obeRep.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeRep.PresupuestoDependencia = datard.GetDecimal(posPresupuestoDependencia);
                            obeRep.PresupuestoEjercido = datard.GetDecimal(posPresupuestoEjercido);
                            obeRep.PresupuestoxEjercer = datard.GetDecimal(posPresupuestoxEjercer);
                            obeRep.MontoTotalEconomia = datard.GetDecimal(posMontoTotalEconomia);

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }

        public beRptAppEjecutivosLicitaciones RepAdquisicionesDep(SqlConnection Conexion, int pIdDependencia)
        {
            string sp = "Proc_RptAppEjecutivosLicitaciones";
            beRptAppEjecutivosLicitaciones obeRep = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pIdGobierno", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pReporte", SqlDbType.Char).Value = "GGADEP";
            cmd.Parameters.Add("@pIdDependencia", SqlDbType.Int).Value = pIdDependencia;
            cmd.Parameters.Add("@pIdProveedor", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pNombreProducto", SqlDbType.Char).Value = "";
            cmd.Parameters.Add("@pIdBienServicio", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pAuxiliar", SqlDbType.Char).Value = "";
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posGobierno = datard.GetOrdinal("Gobierno");
                        int posMontoAdjudicadoTotal = datard.GetOrdinal("MontoAdjudicadoTotal");
                        int posMontoTotalLicitaAbierta = datard.GetOrdinal("MontoTotalLicitaAbierta");
                        int posMontoTotalDirecta = datard.GetOrdinal("MontoTotalDirecta");
                        int posMontoTotalRestringida = datard.GetOrdinal("MontoTotalRestringida");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");

                        obeRep = new beRptAppEjecutivosLicitaciones();
                        while (datard.Read())
                        {
                            obeRep.Dependencia = datard.GetString(posDependencia);
                            obeRep.Gobierno = datard.GetString(posGobierno);
                            obeRep.MontoAdjudicadoTotal = datard.GetDecimal(posMontoAdjudicadoTotal);
                            obeRep.MontoTotalLicitaAbierta = datard.GetDecimal(posMontoTotalLicitaAbierta);
                            obeRep.MontoTotalDirecta = datard.GetDecimal(posMontoTotalDirecta);
                            obeRep.MontoTotalRestringida = datard.GetDecimal(posMontoTotalRestringida);
                            obeRep.Ejercicio = datard.GetInt32(posEjercicio);

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }

        public List<beRptAppEjecutivosLicitaciones> ListaDependencias(SqlConnection Conexion, string pNombreProducto)
        {
            string sp = "Proc_RptAppEjecutivosLicitaciones";
            List<beRptAppEjecutivosLicitaciones> lbeRep = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pIdGobierno", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pReporte", SqlDbType.Char).Value = "LISDEP";
            cmd.Parameters.Add("@pIdDependencia", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pIdProveedor", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pNombreProducto", SqlDbType.Char).Value = pNombreProducto;
            cmd.Parameters.Add("@pIdBienServicio", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pAuxiliar", SqlDbType.Char).Value = "";
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posDependencia = datard.GetOrdinal("Dependencia");

                        lbeRep = new List<beRptAppEjecutivosLicitaciones>();
                        beRptAppEjecutivosLicitaciones obeRep;
                        while (datard.Read())
                        {
                            obeRep = new beRptAppEjecutivosLicitaciones();

                            obeRep.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeRep.Dependencia = datard.GetString(posDependencia);

                            lbeRep.Add(obeRep);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRep;
            }
        }

        public List<beRptAppEjecutivosLicitaciones> ListaProductos(SqlConnection Conexion, string pNombreProducto)
        {
            string sp = "Proc_RptAppEjecutivosLicitaciones";
            List<beRptAppEjecutivosLicitaciones> lbeRep = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pIdGobierno", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pReporte", SqlDbType.Char).Value = "LISART";
            cmd.Parameters.Add("@pIdDependencia", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pIdProveedor", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pNombreProducto", SqlDbType.Char).Value = pNombreProducto;
            cmd.Parameters.Add("@pIdBienServicio", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pAuxiliar", SqlDbType.Char).Value = "";
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posBienServicio = datard.GetOrdinal("BienServicio");

                        lbeRep = new List<beRptAppEjecutivosLicitaciones>();
                        beRptAppEjecutivosLicitaciones obeRep;
                        while (datard.Read())
                        {
                            obeRep = new beRptAppEjecutivosLicitaciones();

                            obeRep.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeRep.BienServicio = datard.GetString(posBienServicio);

                            lbeRep.Add(obeRep);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRep;
            }
        }

        public beRptAppEjecutivosLicitaciones PrecioProducto(SqlConnection Conexion, int pIdBienServicio)
        {
            string sp = "Proc_RptAppEjecutivosLicitaciones";
            beRptAppEjecutivosLicitaciones obeRep = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pIdGobierno", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pReporte", SqlDbType.Char).Value = "CONART";
            cmd.Parameters.Add("@pIdDependencia", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pIdProveedor", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pNombreProducto", SqlDbType.Char).Value = "";
            cmd.Parameters.Add("@pIdBienServicio", SqlDbType.Int).Value = pIdBienServicio;
            cmd.Parameters.Add("@pAuxiliar", SqlDbType.Char).Value = "";
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posPrecioUnitarioMejorLicitado = datard.GetOrdinal("PrecioUnitarioMejorLicitado");

                        obeRep = new beRptAppEjecutivosLicitaciones();
                        while (datard.Read())
                        {
                            obeRep.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeRep.BienServicio = datard.GetString(posBienServicio);
                            obeRep.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeRep.PrecioUnitarioMejorLicitado = datard.GetDecimal(posPrecioUnitarioMejorLicitado);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }

        public List<beRptAppEjecutivosLicitaciones> ListaProveedores(SqlConnection Conexion, string pNombreProducto)
        {
            string sp = "Proc_RptAppEjecutivosLicitaciones";
            List<beRptAppEjecutivosLicitaciones> lbeRep = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pIdGobierno", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pReporte", SqlDbType.Char).Value = "LISPRO";
            cmd.Parameters.Add("@pIdDependencia", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pIdProveedor", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pNombreProducto", SqlDbType.Char).Value = pNombreProducto;
            cmd.Parameters.Add("@pIdBienServicio", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pAuxiliar", SqlDbType.Char).Value = "";
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");

                        lbeRep = new List<beRptAppEjecutivosLicitaciones>();
                        beRptAppEjecutivosLicitaciones obeRep;
                        while (datard.Read())
                        {
                            obeRep = new beRptAppEjecutivosLicitaciones();

                            obeRep.IdProveedor = datard.GetInt32(posIdProveedor);
                            obeRep.RazonSocial = datard.GetString(posRazonSocial);
                            obeRep.IdGobierno = datard.GetInt32(posIdGobierno);

                            lbeRep.Add(obeRep);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRep;
            }
        }

        public List<beRptAppEjecutivosLicitaciones> AdquisicionesProveedoresDependencias(SqlConnection Conexion, int pIdProveedor)
        {
            string sp = "Proc_RptAppEjecutivosLicitaciones";
            List<beRptAppEjecutivosLicitaciones> lbeRep = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pIdGobierno", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pReporte", SqlDbType.Char).Value = "PRODEP";
            cmd.Parameters.Add("@pIdDependencia", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pIdProveedor", SqlDbType.Int).Value = pIdProveedor;
            cmd.Parameters.Add("@pNombreProducto", SqlDbType.Char).Value = "";
            cmd.Parameters.Add("@pIdBienServicio", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pAuxiliar", SqlDbType.Char).Value = "";
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posMontoTotalAbiertas = datard.GetOrdinal("MontoTotalAbiertas");
                        int posMontoTotalDirectas = datard.GetOrdinal("MontoTotalDirectas");
                        int posMontoTotalRestringidas = datard.GetOrdinal("MontoTotalRestringidas");
                        int posMontoTotal = datard.GetOrdinal("MontoTotal");


                        lbeRep = new List<beRptAppEjecutivosLicitaciones>();
                        beRptAppEjecutivosLicitaciones obeRep;
                        while (datard.Read())
                        {
                            obeRep = new beRptAppEjecutivosLicitaciones();

                            obeRep.IdProveedor = datard.GetInt32(posIdProveedor);
                            obeRep.RazonSocial = datard.GetString(posRazonSocial);
                            obeRep.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeRep.Dependencia = datard.GetString(posDependencia);
                            obeRep.MontoTotalAbiertas = datard.GetDecimal(posMontoTotalAbiertas);
                            obeRep.MontoTotalDirectas = datard.GetDecimal(posMontoTotalDirectas);
                            obeRep.MontoTotalRestringidas = datard.GetDecimal(posMontoTotalRestringidas);
                            obeRep.MontoTotal = datard.GetDecimal(posMontoTotal);

                            lbeRep.Add(obeRep);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRep;
            }
        }

        public beRptAppEjecutivosLicitaciones AdquisicionesDependenciaProveedor(SqlConnection Conexion, int pIdDependencia, int pIdProveedor)
        {
            string sp = "Proc_RptAppEjecutivosLicitaciones";
            beRptAppEjecutivosLicitaciones obeRep = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pIdGobierno", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pReporte", SqlDbType.Char).Value = "DEPRTO";
            cmd.Parameters.Add("@pIdDependencia", SqlDbType.Int).Value = pIdDependencia;
            cmd.Parameters.Add("@pIdProveedor", SqlDbType.Int).Value = pIdProveedor;
            cmd.Parameters.Add("@pNombreProducto", SqlDbType.Char).Value = "";
            cmd.Parameters.Add("@pIdBienServicio", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@pAuxiliar", SqlDbType.Char).Value = "";
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posMontoTotalAbiertas = datard.GetOrdinal("MontoTotalAbiertas");
                        int posMontoTotalDirectas = datard.GetOrdinal("MontoTotalDirectas");
                        int posMontoTotalRestringidas = datard.GetOrdinal("MontoTotalRestringidas");                        
                        int posMontoTotal = datard.GetOrdinal("MontoTotal");

                        obeRep = new beRptAppEjecutivosLicitaciones();
                        while (datard.Read())
                        {
                            obeRep.IdProveedor = datard.GetInt32(posIdProveedor);
                            obeRep.RazonSocial = datard.GetString(posRazonSocial);
                            obeRep.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeRep.Dependencia = datard.GetString(posDependencia);
                            obeRep.MontoTotalAbiertas = datard.GetDecimal(posMontoTotalAbiertas);
                            obeRep.MontoTotalDirectas = datard.GetDecimal(posMontoTotalDirectas);
                            obeRep.MontoTotalRestringidas = datard.GetDecimal(posMontoTotalRestringidas);
                            obeRep.MontoTotal = datard.GetDecimal(posMontoTotal);
                        }
                    }
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
