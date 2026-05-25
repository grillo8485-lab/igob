using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRequisicionesLiquidez
    {
        public int guardarRequisicionesLiquidez(SqlConnection Conexion, beRequisicionesLiquidez obeRequisicionesLiquidez)
        {
            int Id = 0;
            string sp = "Proc_RequisicionesLiquidezInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRequisicionLiquidez", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdRequisicionLiquidez;
                    cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdRequisicion;
                    cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdEstatus;
                    cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdOrigenRecurso;
                    cmd.Parameters.Add("@IdCuentaBancaria", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdCuentaBancaria;
                    cmd.Parameters.Add("@NumeroOperacion", SqlDbType.VarChar).Value = obeRequisicionesLiquidez.NumeroOperacion;
                    cmd.Parameters.Add("@SaldoCuenta", SqlDbType.Decimal).Value = obeRequisicionesLiquidez.SaldoCuenta;
                    cmd.Parameters.Add("@SaldoIgob", SqlDbType.Decimal).Value = obeRequisicionesLiquidez.SaldoIgob;
                    cmd.Parameters.Add("@MontoComprometido", SqlDbType.Decimal).Value = obeRequisicionesLiquidez.MontoComprometido;
                    cmd.Parameters.Add("@FechaDeposito", SqlDbType.DateTime).Value = obeRequisicionesLiquidez.FechaDeposito;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesLiquidez.FechaRegistro;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarRequisicionesLiquidez(SqlConnection Conexion, beRequisicionesLiquidez obeRequisicionesLiquidez)
        {
            string sp = "Proc_RequisicionesLiquidezActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRequisicionLiquidez", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdRequisicionLiquidez;
                    cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdRequisicion;
                    cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdEstatus;
                    cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdOrigenRecurso;
                    cmd.Parameters.Add("@IdCuentaBancaria", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdCuentaBancaria;
                    cmd.Parameters.Add("@NumeroOperacion", SqlDbType.VarChar).Value = obeRequisicionesLiquidez.NumeroOperacion;
                    cmd.Parameters.Add("@SaldoCuenta", SqlDbType.Decimal).Value = obeRequisicionesLiquidez.SaldoCuenta;
                    cmd.Parameters.Add("@SaldoIgob", SqlDbType.Decimal).Value = obeRequisicionesLiquidez.SaldoIgob;
                    cmd.Parameters.Add("@MontoComprometido", SqlDbType.Decimal).Value = obeRequisicionesLiquidez.MontoComprometido;
                    cmd.Parameters.Add("@FechaDeposito", SqlDbType.DateTime).Value = obeRequisicionesLiquidez.FechaDeposito;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesLiquidez.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesLiquidez.FechaRegistro;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarRequisicionesLiquidez(SqlConnection Conexion, int pIdRequisicionLiquidez)
        {
            string sp = "Proc_RequisicionesLiquidezEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRequisicionLiquidez", SqlDbType.Int).Value = pIdRequisicionLiquidez;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beRequisicionesLiquidez traerRequisicionesLiquidez_x_IdRequisicionLiquidez(SqlConnection Conexion, int IdRequisicionLiquidez)
        {
            string sp = "Proc_RequisicionesLiquidez_x_IdRequisicionLiquidez";
            beRequisicionesLiquidez obeRequisicionesLiquidez = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicionLiquidez", SqlDbType.Int).Value = IdRequisicionLiquidez;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicionLiquidez = datard.GetOrdinal("IdRequisicionLiquidez");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdCuentaBancaria = datard.GetOrdinal("IdCuentaBancaria");
                        int posNumeroOperacion = datard.GetOrdinal("NumeroOperacion");
                        int posSaldoCuenta = datard.GetOrdinal("SaldoCuenta");
                        int posSaldoIgob = datard.GetOrdinal("SaldoIgob");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posFechaDeposito = datard.GetOrdinal("FechaDeposito");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        obeRequisicionesLiquidez = new beRequisicionesLiquidez();
                        while (datard.Read())
                        {
                            obeRequisicionesLiquidez.IdRequisicionLiquidez = datard.GetInt32(posIdRequisicionLiquidez);
                            obeRequisicionesLiquidez.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLiquidez.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisicionesLiquidez.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeRequisicionesLiquidez.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeRequisicionesLiquidez.NumeroOperacion = datard.GetString(posNumeroOperacion);
                            obeRequisicionesLiquidez.SaldoCuenta = datard.GetDecimal(posSaldoCuenta);
                            obeRequisicionesLiquidez.SaldoIgob = datard.GetDecimal(posSaldoIgob);
                            obeRequisicionesLiquidez.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeRequisicionesLiquidez.FechaDeposito = datard.GetDateTime(posFechaDeposito);
                            obeRequisicionesLiquidez.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesLiquidez.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesLiquidez;
            }
        }
        public List<beRequisicionesLiquidez> listarTodos_RequisicionesLiquidez(SqlConnection Conexion)
        {
            string sp = "Proc_RequisicionesLiquidez_Traer_Todos";
            List<beRequisicionesLiquidez> lbeRequisicionesLiquidez = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicionLiquidez = datard.GetOrdinal("IdRequisicionLiquidez");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdCuentaBancaria = datard.GetOrdinal("IdCuentaBancaria");
                        int posNumeroOperacion = datard.GetOrdinal("NumeroOperacion");
                        int posSaldoCuenta = datard.GetOrdinal("SaldoCuenta");
                        int posSaldoIgob = datard.GetOrdinal("SaldoIgob");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posFechaDeposito = datard.GetOrdinal("FechaDeposito");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeRequisicionesLiquidez = new List<beRequisicionesLiquidez>();
                        beRequisicionesLiquidez obeRequisicionesLiquidez;
                        while (datard.Read())
                        {
                            obeRequisicionesLiquidez = new beRequisicionesLiquidez();
                            obeRequisicionesLiquidez.IdRequisicionLiquidez = datard.GetInt32(posIdRequisicionLiquidez);
                            obeRequisicionesLiquidez.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLiquidez.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisicionesLiquidez.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeRequisicionesLiquidez.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeRequisicionesLiquidez.NumeroOperacion = datard.GetString(posNumeroOperacion);
                            obeRequisicionesLiquidez.SaldoCuenta = datard.GetDecimal(posSaldoCuenta);
                            obeRequisicionesLiquidez.SaldoIgob = datard.GetDecimal(posSaldoIgob);
                            obeRequisicionesLiquidez.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeRequisicionesLiquidez.FechaDeposito = datard.GetDateTime(posFechaDeposito);
                            obeRequisicionesLiquidez.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesLiquidez.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            lbeRequisicionesLiquidez.Add(obeRequisicionesLiquidez);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLiquidez;
            }
        }
        public List<beRequisicionesLiquidez> listar_RequisicionesLiquidez_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_RequisicionesLiquidez_TraerTodos_GetAll";
            List<beRequisicionesLiquidez> lbeRequisicionesLiquidez = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicionLiquidez = datard.GetOrdinal("IdRequisicionLiquidez");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdCuentaBancaria = datard.GetOrdinal("IdCuentaBancaria");
                        int posNumeroOperacion = datard.GetOrdinal("NumeroOperacion");
                        int posSaldoCuenta = datard.GetOrdinal("SaldoCuenta");
                        int posSaldoIgob = datard.GetOrdinal("SaldoIgob");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posFechaDeposito = datard.GetOrdinal("FechaDeposito");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeRequisicionesLiquidez = new List<beRequisicionesLiquidez>();
                        beRequisicionesLiquidez obeRequisicionesLiquidez;
                        while (datard.Read())
                        {
                            obeRequisicionesLiquidez = new beRequisicionesLiquidez();
                            obeRequisicionesLiquidez.IdRequisicionLiquidez = datard.GetInt32(posIdRequisicionLiquidez);
                            obeRequisicionesLiquidez.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLiquidez.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisicionesLiquidez.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeRequisicionesLiquidez.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeRequisicionesLiquidez.NumeroOperacion = datard.GetString(posNumeroOperacion);
                            obeRequisicionesLiquidez.SaldoCuenta = datard.GetDecimal(posSaldoCuenta);
                            obeRequisicionesLiquidez.SaldoIgob = datard.GetDecimal(posSaldoIgob);
                            obeRequisicionesLiquidez.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeRequisicionesLiquidez.FechaDeposito = datard.GetDateTime(posFechaDeposito);
                            obeRequisicionesLiquidez.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesLiquidez.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            // debe agregar campos de la Vista
                            lbeRequisicionesLiquidez.Add(obeRequisicionesLiquidez);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLiquidez;
            }
        }
        public List<beRequisicionesLiquidez> Listar_RequisicionLiquidez_x_IdRequisicion(SqlConnection Conexion, int idRequisicion)
        {
            string sp = "Proc_RequisicionLiquidez_x_IdRequisicion";
            List<beRequisicionesLiquidez> lbeRequisicionesLiquidez = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = idRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicionLiquidez = datard.GetOrdinal("IdRequisicionLiquidez");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdCuentaBancaria = datard.GetOrdinal("IdCuentaBancaria");
                        int posNumeroOperacion = datard.GetOrdinal("NumeroOperacion");
                        int posSaldoCuenta = datard.GetOrdinal("SaldoCuenta");
                        int posSaldoIgob = datard.GetOrdinal("SaldoIgob");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posFechaDeposito = datard.GetOrdinal("FechaDeposito");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeRequisicionesLiquidez = new List<beRequisicionesLiquidez>();
                        beRequisicionesLiquidez obeRequisicionesLiquidez;
                        while (datard.Read())
                        {
                            obeRequisicionesLiquidez = new beRequisicionesLiquidez();
                            obeRequisicionesLiquidez.IdRequisicionLiquidez = datard.GetInt32(posIdRequisicionLiquidez);
                            obeRequisicionesLiquidez.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLiquidez.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisicionesLiquidez.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeRequisicionesLiquidez.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeRequisicionesLiquidez.NumeroOperacion = datard.GetString(posNumeroOperacion);
                            obeRequisicionesLiquidez.SaldoCuenta = datard.GetDecimal(posSaldoCuenta);
                            obeRequisicionesLiquidez.SaldoIgob = datard.GetDecimal(posSaldoIgob);
                            obeRequisicionesLiquidez.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeRequisicionesLiquidez.FechaDeposito = datard.GetDateTime(posFechaDeposito);
                            obeRequisicionesLiquidez.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesLiquidez.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            lbeRequisicionesLiquidez.Add(obeRequisicionesLiquidez);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLiquidez;
            }
        }

        public List<beRequisicionesLiquidez> RequisicionesLiquidez_Traer_IdRequisicion(SqlConnection Conexion, int idRequisicion)
        {
            string sp = "Proc_RequisicionesLiquidez_Traer_IdRequisicion";
            List<beRequisicionesLiquidez> lbeRequisicionesLiquidez = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = idRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicionLiquidez = datard.GetOrdinal("IdRequisicionLiquidez");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdCuentaBancaria = datard.GetOrdinal("IdCuentaBancaria");
                        int posNumeroOperacion = datard.GetOrdinal("NumeroOperacion");
                        int posSaldoCuenta = datard.GetOrdinal("SaldoCuenta");
                        int posSaldoIgob = datard.GetOrdinal("SaldoIgob");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posFechaDeposito = datard.GetOrdinal("FechaDeposito");
                        int posNumeroCuenta = datard.GetOrdinal("NumeroCuenta");
                        int posNombreCuenta = datard.GetOrdinal("NombreCuenta");
                        int posMontoDisponible = datard.GetOrdinal("MontoDisponible");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posNombreCorto = datard.GetOrdinal("NombreCorto");
                        lbeRequisicionesLiquidez = new List<beRequisicionesLiquidez>();
                        beRequisicionesLiquidez obeRequisicionesLiquidez;
                        while (datard.Read())
                        {
                            obeRequisicionesLiquidez = new beRequisicionesLiquidez();
                            obeRequisicionesLiquidez.IdRequisicionLiquidez = datard.GetInt32(posIdRequisicionLiquidez);
                            obeRequisicionesLiquidez.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLiquidez.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisicionesLiquidez.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeRequisicionesLiquidez.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeRequisicionesLiquidez.NumeroOperacion = datard.GetString(posNumeroOperacion);
                            obeRequisicionesLiquidez.SaldoCuenta = datard.GetDecimal(posSaldoCuenta);
                            obeRequisicionesLiquidez.SaldoIgob = datard.GetDecimal(posSaldoIgob);
                            obeRequisicionesLiquidez.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeRequisicionesLiquidez.FechaDeposito = datard.GetDateTime(posFechaDeposito);
                            obeRequisicionesLiquidez.NumeroCuenta = datard.GetString(posNumeroCuenta);
                            obeRequisicionesLiquidez.NombreCuenta = datard.GetString(posNombreCuenta);
                            obeRequisicionesLiquidez.MontoDisponible = datard.GetDecimal(posMontoDisponible);
                            obeRequisicionesLiquidez.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            obeRequisicionesLiquidez.NombreCorto = datard.GetString(posNombreCorto);
                            lbeRequisicionesLiquidez.Add(obeRequisicionesLiquidez);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLiquidez;
            }
        }

    }
}
