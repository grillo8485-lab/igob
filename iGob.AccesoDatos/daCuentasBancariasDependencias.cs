using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daCuentasBancariasDependencias
    {
        public int guardarCuentasBancariasDependencias(SqlConnection Conexion, beCuentasBancariasDependencias obeCuentasBancariasDependencias)
        {
            int Id = 0;
            string sp = "Proc_CuentasBancariasDependenciasInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCuentaBancaria", SqlDbType.Int).Value = obeCuentasBancariasDependencias.IdCuentaBancaria;
                    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeCuentasBancariasDependencias.IdDependencia;
                    cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeCuentasBancariasDependencias.IdOrigenRecurso;
                    cmd.Parameters.Add("@IdBanco", SqlDbType.Int).Value = obeCuentasBancariasDependencias.IdBanco;
                    cmd.Parameters.Add("@NumeroCuenta", SqlDbType.VarChar).Value = obeCuentasBancariasDependencias.NumeroCuenta;
                    cmd.Parameters.Add("@NombreCuenta", SqlDbType.VarChar).Value = obeCuentasBancariasDependencias.NombreCuenta;
                    cmd.Parameters.Add("@MontoDisponible", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoDisponible;
                    cmd.Parameters.Add("@MontoDisponibleEntidad", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoDisponibleEntidad;
                    cmd.Parameters.Add("@AutorizadoIgob", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.AutorizadoIgob;
                    cmd.Parameters.Add("@MontoComprometido", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoComprometido;
                    cmd.Parameters.Add("@MontoSaldoIgob", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoSaldoIgob;
                    cmd.Parameters.Add("@MontoEjecutado", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoEjecutado;
                    cmd.Parameters.Add("@MontoEconomia", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoEconomia;
                    cmd.Parameters.Add("@FechaMovimiento", SqlDbType.DateTime).Value = obeCuentasBancariasDependencias.FechaMovimiento;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeCuentasBancariasDependencias.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeCuentasBancariasDependencias.FechaRegistro;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarCuentasBancariasDependencias(SqlConnection Conexion, beCuentasBancariasDependencias obeCuentasBancariasDependencias)
        {
            string sp = "Proc_CuentasBancariasDependenciasActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCuentaBancaria", SqlDbType.Int).Value = obeCuentasBancariasDependencias.IdCuentaBancaria;
                    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeCuentasBancariasDependencias.IdDependencia;
                    cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeCuentasBancariasDependencias.IdOrigenRecurso;
                    cmd.Parameters.Add("@IdBanco", SqlDbType.Int).Value = obeCuentasBancariasDependencias.IdBanco;
                    cmd.Parameters.Add("@NumeroCuenta", SqlDbType.VarChar).Value = obeCuentasBancariasDependencias.NumeroCuenta;
                    cmd.Parameters.Add("@NombreCuenta", SqlDbType.VarChar).Value = obeCuentasBancariasDependencias.NombreCuenta;
                    cmd.Parameters.Add("@MontoDisponible", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoDisponible;
                    cmd.Parameters.Add("@MontoDisponibleEntidad", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoDisponibleEntidad;
                    cmd.Parameters.Add("@AutorizadoIgob", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.AutorizadoIgob;
                    cmd.Parameters.Add("@MontoComprometido", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoComprometido;
                    cmd.Parameters.Add("@MontoSaldoIgob", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoSaldoIgob;
                    cmd.Parameters.Add("@MontoEjecutado", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoEjecutado;
                    cmd.Parameters.Add("@MontoEconomia", SqlDbType.Decimal).Value = obeCuentasBancariasDependencias.MontoEconomia;
                    cmd.Parameters.Add("@FechaMovimiento", SqlDbType.DateTime).Value = obeCuentasBancariasDependencias.FechaMovimiento;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeCuentasBancariasDependencias.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeCuentasBancariasDependencias.FechaRegistro;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarCuentasBancariasDependencias(SqlConnection Conexion, int pIdCuentaBancaria)
        {
            string sp = "Proc_CuentasBancariasDependenciasEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCuentaBancaria", SqlDbType.Int).Value = pIdCuentaBancaria;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beCuentasBancariasDependencias traerCuentasBancariasDependencias_x_IdCuentaBancaria(SqlConnection Conexion, int IdCuentaBancaria)
        {
            string sp = "Proc_CuentasBancariasDependencias_x_IdCuentaBancaria";
            beCuentasBancariasDependencias obeCuentasBancariasDependencias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCuentaBancaria", SqlDbType.Int).Value = IdCuentaBancaria;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCuentaBancaria = datard.GetOrdinal("IdCuentaBancaria");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdBanco = datard.GetOrdinal("IdBanco");
                        int posNumeroCuenta = datard.GetOrdinal("NumeroCuenta");
                        int posNombreCuenta = datard.GetOrdinal("NombreCuenta");
                        int posMontoDisponible = datard.GetOrdinal("MontoDisponible");
                        int posMontoDisponibleEntidad = datard.GetOrdinal("MontoDisponibleEntidad");
                        int posAutorizadoIgob = datard.GetOrdinal("AutorizadoIgob");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posMontoSaldoIgob = datard.GetOrdinal("MontoSaldoIgob");
                        int posMontoEjecutado = datard.GetOrdinal("MontoEjecutado");
                        int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
                        int posFechaMovimiento = datard.GetOrdinal("FechaMovimiento");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        obeCuentasBancariasDependencias = new beCuentasBancariasDependencias();
                        while (datard.Read())
                        {
                            obeCuentasBancariasDependencias.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeCuentasBancariasDependencias.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeCuentasBancariasDependencias.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeCuentasBancariasDependencias.IdBanco = datard.GetInt32(posIdBanco);
                            obeCuentasBancariasDependencias.NumeroCuenta = datard.GetString(posNumeroCuenta);
                            obeCuentasBancariasDependencias.NombreCuenta = datard.GetString(posNombreCuenta);
                            obeCuentasBancariasDependencias.MontoDisponible = datard.GetDecimal(posMontoDisponible);
                            obeCuentasBancariasDependencias.MontoDisponibleEntidad = datard.GetDecimal(posMontoDisponibleEntidad);
                            obeCuentasBancariasDependencias.AutorizadoIgob = datard.GetDecimal(posAutorizadoIgob);
                            obeCuentasBancariasDependencias.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeCuentasBancariasDependencias.MontoSaldoIgob = datard.GetDecimal(posMontoSaldoIgob);
                            obeCuentasBancariasDependencias.MontoEjecutado = datard.GetDecimal(posMontoEjecutado);
                            obeCuentasBancariasDependencias.MontoEconomia = datard.GetDecimal(posMontoEconomia);
                            obeCuentasBancariasDependencias.FechaMovimiento = datard.GetDateTime(posFechaMovimiento);
                            obeCuentasBancariasDependencias.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeCuentasBancariasDependencias.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeCuentasBancariasDependencias;
            }
        }
        public List<beCuentasBancariasDependencias> listarTodos_CuentasBancariasDependencias(SqlConnection Conexion)
        {
            string sp = "Proc_CuentasBancariasDependencias_Traer_Todos";
            List<beCuentasBancariasDependencias> lbeCuentasBancariasDependencias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCuentaBancaria = datard.GetOrdinal("IdCuentaBancaria");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdBanco = datard.GetOrdinal("IdBanco");
                        int posNumeroCuenta = datard.GetOrdinal("NumeroCuenta");
                        int posNombreCuenta = datard.GetOrdinal("NombreCuenta");
                        int posMontoDisponible = datard.GetOrdinal("MontoDisponible");
                        int posMontoDisponibleEntidad = datard.GetOrdinal("MontoDisponibleEntidad");
                        int posAutorizadoIgob = datard.GetOrdinal("AutorizadoIgob");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posMontoSaldoIgob = datard.GetOrdinal("MontoSaldoIgob");
                        int posMontoEjecutado = datard.GetOrdinal("MontoEjecutado");
                        int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
                        int posFechaMovimiento = datard.GetOrdinal("FechaMovimiento");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeCuentasBancariasDependencias = new List<beCuentasBancariasDependencias>();
                        beCuentasBancariasDependencias obeCuentasBancariasDependencias;
                        while (datard.Read())
                        {
                            obeCuentasBancariasDependencias = new beCuentasBancariasDependencias();
                            obeCuentasBancariasDependencias.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeCuentasBancariasDependencias.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeCuentasBancariasDependencias.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeCuentasBancariasDependencias.IdBanco = datard.GetInt32(posIdBanco);
                            obeCuentasBancariasDependencias.NumeroCuenta = datard.GetString(posNumeroCuenta);
                            obeCuentasBancariasDependencias.NombreCuenta = datard.GetString(posNombreCuenta);
                            obeCuentasBancariasDependencias.MontoDisponible = datard.GetDecimal(posMontoDisponible);
                            obeCuentasBancariasDependencias.MontoDisponibleEntidad = datard.GetDecimal(posMontoDisponibleEntidad);
                            obeCuentasBancariasDependencias.AutorizadoIgob = datard.GetDecimal(posAutorizadoIgob);
                            obeCuentasBancariasDependencias.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeCuentasBancariasDependencias.MontoSaldoIgob = datard.GetDecimal(posMontoSaldoIgob);
                            obeCuentasBancariasDependencias.MontoEjecutado = datard.GetDecimal(posMontoEjecutado);
                            obeCuentasBancariasDependencias.MontoEconomia = datard.GetDecimal(posMontoEconomia);
                            obeCuentasBancariasDependencias.FechaMovimiento = datard.GetDateTime(posFechaMovimiento);
                            obeCuentasBancariasDependencias.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeCuentasBancariasDependencias.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            lbeCuentasBancariasDependencias.Add(obeCuentasBancariasDependencias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCuentasBancariasDependencias;
            }
        }
        public List<beCuentasBancariasDependencias> listar_CuentasBancariasDependencias_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_CuentasBancariasDependencias_TraerTodos_GetAll";
            List<beCuentasBancariasDependencias> lbeCuentasBancariasDependencias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCuentaBancaria = datard.GetOrdinal("IdCuentaBancaria");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdBanco = datard.GetOrdinal("IdBanco");
                        int posNumeroCuenta = datard.GetOrdinal("NumeroCuenta");
                        int posNombreCuenta = datard.GetOrdinal("NombreCuenta");
                        int posMontoDisponible = datard.GetOrdinal("MontoDisponible");
                        int posMontoDisponibleEntidad = datard.GetOrdinal("MontoDisponibleEntidad");
                        int posAutorizadoIgob = datard.GetOrdinal("AutorizadoIgob");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posMontoSaldoIgob = datard.GetOrdinal("MontoSaldoIgob");
                        int posMontoEjecutado = datard.GetOrdinal("MontoEjecutado");
                        int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
                        int posFechaMovimiento = datard.GetOrdinal("FechaMovimiento");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posNombreCorto = datard.GetOrdinal("NombreCorto");
                        lbeCuentasBancariasDependencias = new List<beCuentasBancariasDependencias>();
                        beCuentasBancariasDependencias obeCuentasBancariasDependencias;
                        while (datard.Read())
                        {
                            obeCuentasBancariasDependencias = new beCuentasBancariasDependencias();
                            obeCuentasBancariasDependencias.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeCuentasBancariasDependencias.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeCuentasBancariasDependencias.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeCuentasBancariasDependencias.IdBanco = datard.GetInt32(posIdBanco);
                            obeCuentasBancariasDependencias.NumeroCuenta = datard.GetString(posNumeroCuenta);
                            obeCuentasBancariasDependencias.NombreCuenta = datard.GetString(posNombreCuenta);
                            obeCuentasBancariasDependencias.MontoDisponible = datard.GetDecimal(posMontoDisponible);
                            obeCuentasBancariasDependencias.MontoDisponibleEntidad = datard.GetDecimal(posMontoDisponibleEntidad);
                            obeCuentasBancariasDependencias.AutorizadoIgob = datard.GetDecimal(posAutorizadoIgob);
                            obeCuentasBancariasDependencias.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeCuentasBancariasDependencias.MontoSaldoIgob = datard.GetDecimal(posMontoSaldoIgob);
                            obeCuentasBancariasDependencias.MontoEjecutado = datard.GetDecimal(posMontoEjecutado);
                            obeCuentasBancariasDependencias.MontoEconomia = datard.GetDecimal(posMontoEconomia);
                            obeCuentasBancariasDependencias.FechaMovimiento = datard.GetDateTime(posFechaMovimiento);
                            obeCuentasBancariasDependencias.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeCuentasBancariasDependencias.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            // debe agregar campos de la Vista
                            obeCuentasBancariasDependencias.Dependencia = datard.GetString(posDependencia);
                            obeCuentasBancariasDependencias.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            obeCuentasBancariasDependencias.NombreCorto = datard.GetString(posNombreCorto);

                            lbeCuentasBancariasDependencias.Add(obeCuentasBancariasDependencias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCuentasBancariasDependencias;
            }
        }

        public List<beCuentasBancariasDependencias> listar_CuentasBancariasDependenciasIngProp_TraerTodas(SqlConnection Conexion, int IdDependencia)
        {
            string sp = "Proc_CuentasBancariasDependenciasIngProd_Traer_Dependencia";
            List<beCuentasBancariasDependencias> lbeCuentasBancariasDependencias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = IdDependencia;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {

                        int posIdCuentaBancaria = datard.GetOrdinal("IdCuentaBancaria");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdBanco = datard.GetOrdinal("IdBanco");
                        int posNumeroCuenta = datard.GetOrdinal("NumeroCuenta");
                        int posNombreCuenta = datard.GetOrdinal("NombreCuenta");
                        int posMontoDisponible = datard.GetOrdinal("MontoDisponible");
                        int posMontoDisponibleEntidad = datard.GetOrdinal("MontoDisponibleEntidad");
                        int posAutorizadoIgob = datard.GetOrdinal("AutorizadoIgob");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posMontoSaldoIgob = datard.GetOrdinal("MontoSaldoIgob");
                        int posMontoEjecutado = datard.GetOrdinal("MontoEjecutado");
                        int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
                        int posFechaMovimiento = datard.GetOrdinal("FechaMovimiento");
                        int posNombreCorto = datard.GetOrdinal("NombreCorto");

                        lbeCuentasBancariasDependencias = new List<beCuentasBancariasDependencias>();
                        beCuentasBancariasDependencias obeCuentasBancariasDependencias;
                        while (datard.Read())
                        {
                            obeCuentasBancariasDependencias = new beCuentasBancariasDependencias();

                            obeCuentasBancariasDependencias.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeCuentasBancariasDependencias.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeCuentasBancariasDependencias.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeCuentasBancariasDependencias.IdBanco = datard.GetInt32(posIdBanco);
                            obeCuentasBancariasDependencias.NumeroCuenta = datard.GetString(posNumeroCuenta);
                            obeCuentasBancariasDependencias.NombreCuenta = datard.GetString(posNombreCuenta);
                            obeCuentasBancariasDependencias.MontoDisponible = datard.GetDecimal(posMontoDisponible);
                            obeCuentasBancariasDependencias.MontoDisponibleEntidad = datard.GetDecimal(posMontoDisponibleEntidad);
                            obeCuentasBancariasDependencias.AutorizadoIgob = datard.GetDecimal(posAutorizadoIgob);
                            obeCuentasBancariasDependencias.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeCuentasBancariasDependencias.MontoSaldoIgob = datard.GetDecimal(posMontoSaldoIgob);
                            obeCuentasBancariasDependencias.MontoEjecutado = datard.GetDecimal(posMontoEjecutado);
                            obeCuentasBancariasDependencias.MontoEconomia = datard.GetDecimal(posMontoEconomia);
                            obeCuentasBancariasDependencias.FechaMovimiento = datard.GetDateTime(posFechaMovimiento);
                            obeCuentasBancariasDependencias.NombreCorto = datard.GetString(posNombreCorto);

                            lbeCuentasBancariasDependencias.Add(obeCuentasBancariasDependencias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCuentasBancariasDependencias;
            }
        }
        //Usado en cuentas bancarias
        public List<beCuentasBancariasDependencias> listarTodosCuentasBancariasPorDependencias(SqlConnection Conexion)
        {
            string sp = "Proc_CuentasBancariasDependencias_TraerTodas";
            List<beCuentasBancariasDependencias> lbeCuentasBancariasDependencias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posTotalInicial = datard.GetOrdinal("TotalInicial");
                        lbeCuentasBancariasDependencias = new List<beCuentasBancariasDependencias>();
                        beCuentasBancariasDependencias obeCuentasBancariasDependencias;
                        while (datard.Read())
                        {
                            obeCuentasBancariasDependencias = new beCuentasBancariasDependencias();
                            obeCuentasBancariasDependencias.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeCuentasBancariasDependencias.Dependencia = datard.GetString(posDependencia);
                            obeCuentasBancariasDependencias.TotalInicial = datard.GetDecimal(posTotalInicial);
                            lbeCuentasBancariasDependencias.Add(obeCuentasBancariasDependencias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCuentasBancariasDependencias;
            }
        }
        //Usado en cuentas bancarias
        public List<beCuentasBancariasDependencias> ListadoCuentasBancariasFiltradasPorDependencias(SqlConnection Conexion, int IdDependencia)
        {
            string sp = "Proc_CuentasBancariasDependencias_Traer_IdDependencia";
            List<beCuentasBancariasDependencias> lbeCuentasBancariasDependencias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = IdDependencia;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCuentaBancaria = datard.GetOrdinal("IdCuentaBancaria");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdBanco = datard.GetOrdinal("IdBanco");
                        int posNumeroCuenta = datard.GetOrdinal("NumeroCuenta");
                        int posNombreCuenta = datard.GetOrdinal("NombreCuenta");
                        int posMontoDisponible = datard.GetOrdinal("MontoDisponible");
                        int posMontoDisponibleEntidad = datard.GetOrdinal("MontoDisponibleEntidad");
                        int posAutorizadoIgob = datard.GetOrdinal("AutorizadoIgob");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posMontoSaldoIgob = datard.GetOrdinal("MontoSaldoIgob");
                        int posMontoEjecutado = datard.GetOrdinal("MontoEjecutado");
                        int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posNombreCorto = datard.GetOrdinal("NombreCorto");

                        lbeCuentasBancariasDependencias = new List<beCuentasBancariasDependencias>();
                        beCuentasBancariasDependencias obeCuentasBancariasDependencias;
                        while (datard.Read())
                        {
                            obeCuentasBancariasDependencias = new beCuentasBancariasDependencias();

                            obeCuentasBancariasDependencias.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeCuentasBancariasDependencias.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeCuentasBancariasDependencias.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeCuentasBancariasDependencias.IdBanco = datard.GetInt32(posIdBanco);
                            obeCuentasBancariasDependencias.NumeroCuenta = datard.GetString(posNumeroCuenta);
                            obeCuentasBancariasDependencias.NombreCuenta = datard.GetString(posNombreCuenta);
                            obeCuentasBancariasDependencias.MontoDisponible = datard.GetDecimal(posMontoDisponible);
                            obeCuentasBancariasDependencias.MontoDisponibleEntidad = datard.GetDecimal(posMontoDisponibleEntidad);
                            obeCuentasBancariasDependencias.AutorizadoIgob = datard.GetDecimal(posAutorizadoIgob);
                            obeCuentasBancariasDependencias.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeCuentasBancariasDependencias.MontoSaldoIgob = datard.GetDecimal(posMontoSaldoIgob);
                            obeCuentasBancariasDependencias.MontoEjecutado = datard.GetDecimal(posMontoEjecutado);
                            obeCuentasBancariasDependencias.MontoEconomia = datard.GetDecimal(posMontoEconomia);
                            obeCuentasBancariasDependencias.Dependencia = datard.GetString(posDependencia);
                            obeCuentasBancariasDependencias.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            obeCuentasBancariasDependencias.NombreCorto = datard.GetString(posNombreCorto);

                            lbeCuentasBancariasDependencias.Add(obeCuentasBancariasDependencias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCuentasBancariasDependencias;
            }
        }
        //Usado en cuentas bancarias
    }
}
