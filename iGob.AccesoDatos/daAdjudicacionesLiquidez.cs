using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesLiquidez
 {
	public int guardarAdjudicacionesLiquidez(SqlConnection Conexion, beAdjudicacionesLiquidez obeAdjudicacionesLiquidez)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesLiquidezInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionLiquidez", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdAdjudicacionLiquidez;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdAdjudicacion;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdEstatus;
				cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdOrigenRecurso;
				cmd.Parameters.Add("@IdCuentaBancaria", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdCuentaBancaria;
				cmd.Parameters.Add("@NumeroOperacion", SqlDbType.VarChar).Value = obeAdjudicacionesLiquidez.NumeroOperacion;
				cmd.Parameters.Add("@SaldoCuenta", SqlDbType.Decimal).Value = obeAdjudicacionesLiquidez.SaldoCuenta;
				cmd.Parameters.Add("@SaldoIgob", SqlDbType.Decimal).Value = obeAdjudicacionesLiquidez.SaldoIgob;
				cmd.Parameters.Add("@MontoComprometido", SqlDbType.Decimal).Value = obeAdjudicacionesLiquidez.MontoComprometido;
				cmd.Parameters.Add("@FechaDeposito", SqlDbType.DateTime).Value = obeAdjudicacionesLiquidez.FechaDeposito;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesLiquidez.FechaRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesLiquidez(SqlConnection Conexion, beAdjudicacionesLiquidez obeAdjudicacionesLiquidez)
	{
		string sp = "Proc_AdjudicacionesLiquidezActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionLiquidez", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdAdjudicacionLiquidez;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdAdjudicacion;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdEstatus;
				cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdOrigenRecurso;
				cmd.Parameters.Add("@IdCuentaBancaria", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdCuentaBancaria;
				cmd.Parameters.Add("@NumeroOperacion", SqlDbType.VarChar).Value = obeAdjudicacionesLiquidez.NumeroOperacion;
				cmd.Parameters.Add("@SaldoCuenta", SqlDbType.Decimal).Value = obeAdjudicacionesLiquidez.SaldoCuenta;
				cmd.Parameters.Add("@SaldoIgob", SqlDbType.Decimal).Value = obeAdjudicacionesLiquidez.SaldoIgob;
				cmd.Parameters.Add("@MontoComprometido", SqlDbType.Decimal).Value = obeAdjudicacionesLiquidez.MontoComprometido;
				cmd.Parameters.Add("@FechaDeposito", SqlDbType.DateTime).Value = obeAdjudicacionesLiquidez.FechaDeposito;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesLiquidez.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesLiquidez.FechaRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesLiquidez(SqlConnection Conexion,int pIdAdjudicacionLiquidez)
	{
		string sp = "Proc_AdjudicacionesLiquidezEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionLiquidez", SqlDbType.Int).Value = pIdAdjudicacionLiquidez;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesLiquidez traerAdjudicacionesLiquidez_x_IdAdjudicacionLiquidez(SqlConnection Conexion,int IdAdjudicacionLiquidez)
	{
		string sp = "Proc_AdjudicacionesLiquidez_x_IdAdjudicacionLiquidez";
				beAdjudicacionesLiquidez obeAdjudicacionesLiquidez=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdjudicacionLiquidez", SqlDbType.Int).Value = IdAdjudicacionLiquidez;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdjudicacionLiquidez = datard.GetOrdinal("IdAdjudicacionLiquidez");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
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
					 obeAdjudicacionesLiquidez = new beAdjudicacionesLiquidez();
				while (datard.Read())
					{
						obeAdjudicacionesLiquidez.IdAdjudicacionLiquidez =  datard.GetInt32(posIdAdjudicacionLiquidez);
						obeAdjudicacionesLiquidez.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
						obeAdjudicacionesLiquidez.IdEstatus =  datard.GetInt32(posIdEstatus);
						obeAdjudicacionesLiquidez.IdOrigenRecurso =  datard.GetInt32(posIdOrigenRecurso);
						obeAdjudicacionesLiquidez.IdCuentaBancaria =  datard.GetInt32(posIdCuentaBancaria);
						obeAdjudicacionesLiquidez.NumeroOperacion =  datard.GetString(posNumeroOperacion);
						obeAdjudicacionesLiquidez.SaldoCuenta =  datard.GetDecimal(posSaldoCuenta);
						obeAdjudicacionesLiquidez.SaldoIgob =  datard.GetDecimal(posSaldoIgob);
						obeAdjudicacionesLiquidez.MontoComprometido =  datard.GetDecimal(posMontoComprometido);
						obeAdjudicacionesLiquidez.FechaDeposito =  datard.GetDateTime(posFechaDeposito);
						obeAdjudicacionesLiquidez.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeAdjudicacionesLiquidez.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesLiquidez;
			}
	}
	public List< beAdjudicacionesLiquidez> listarTodos_AdjudicacionesLiquidez(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesLiquidez_Traer_Todos";
		List<beAdjudicacionesLiquidez> lbeAdjudicacionesLiquidez = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionLiquidez = datard.GetOrdinal("IdAdjudicacionLiquidez");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
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
				lbeAdjudicacionesLiquidez = new List<beAdjudicacionesLiquidez>();
				beAdjudicacionesLiquidez obeAdjudicacionesLiquidez;
				while (datard.Read())
				{
					 obeAdjudicacionesLiquidez = new beAdjudicacionesLiquidez();
					obeAdjudicacionesLiquidez.IdAdjudicacionLiquidez =  datard.GetInt32(posIdAdjudicacionLiquidez);
					obeAdjudicacionesLiquidez.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesLiquidez.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeAdjudicacionesLiquidez.IdOrigenRecurso =  datard.GetInt32(posIdOrigenRecurso);
					obeAdjudicacionesLiquidez.IdCuentaBancaria =  datard.GetInt32(posIdCuentaBancaria);
					obeAdjudicacionesLiquidez.NumeroOperacion =  datard.GetString(posNumeroOperacion);
					obeAdjudicacionesLiquidez.SaldoCuenta =  datard.GetDecimal(posSaldoCuenta);
					obeAdjudicacionesLiquidez.SaldoIgob =  datard.GetDecimal(posSaldoIgob);
					obeAdjudicacionesLiquidez.MontoComprometido =  datard.GetDecimal(posMontoComprometido);
					obeAdjudicacionesLiquidez.FechaDeposito =  datard.GetDateTime(posFechaDeposito);
					obeAdjudicacionesLiquidez.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeAdjudicacionesLiquidez.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					lbeAdjudicacionesLiquidez.Add(obeAdjudicacionesLiquidez);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesLiquidez;
		}
	}
	public List< beAdjudicacionesLiquidez> listar_AdjudicacionesLiquidez_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesLiquidez_TraerTodos_GetAll";
		List<beAdjudicacionesLiquidez> lbeAdjudicacionesLiquidez = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionLiquidez = datard.GetOrdinal("IdAdjudicacionLiquidez");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
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
				lbeAdjudicacionesLiquidez = new List<beAdjudicacionesLiquidez>();
				beAdjudicacionesLiquidez obeAdjudicacionesLiquidez;
				while (datard.Read())
				{
					 obeAdjudicacionesLiquidez = new beAdjudicacionesLiquidez();
					obeAdjudicacionesLiquidez.IdAdjudicacionLiquidez =  datard.GetInt32(posIdAdjudicacionLiquidez);
					obeAdjudicacionesLiquidez.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesLiquidez.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeAdjudicacionesLiquidez.IdOrigenRecurso =  datard.GetInt32(posIdOrigenRecurso);
					obeAdjudicacionesLiquidez.IdCuentaBancaria =  datard.GetInt32(posIdCuentaBancaria);
					obeAdjudicacionesLiquidez.NumeroOperacion =  datard.GetString(posNumeroOperacion);
					obeAdjudicacionesLiquidez.SaldoCuenta =  datard.GetDecimal(posSaldoCuenta);
					obeAdjudicacionesLiquidez.SaldoIgob =  datard.GetDecimal(posSaldoIgob);
					obeAdjudicacionesLiquidez.MontoComprometido =  datard.GetDecimal(posMontoComprometido);
					obeAdjudicacionesLiquidez.FechaDeposito =  datard.GetDateTime(posFechaDeposito);
					obeAdjudicacionesLiquidez.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeAdjudicacionesLiquidez.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			// debe agregar campos de la Vista
					lbeAdjudicacionesLiquidez.Add(obeAdjudicacionesLiquidez);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesLiquidez;
		}
	}


        public List<beAdjudicacionesLiquidez> AdjudicacionesLiquidez_Traer_IdAdjudicacion(SqlConnection Conexion, int IdAdjudicacion)
        {

            string sp = "Proc_AdjudicacionesLiquidez_Traer_IdAdjudicacion";
            List<beAdjudicacionesLiquidez> lbeAdjudicacionesLiquidez = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAdjudicacionLiquidez = datard.GetOrdinal("IdAdjudicacionLiquidez");
                        int posIdAdjudicacicon = datard.GetOrdinal("IdAdjudicacion");
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
                        lbeAdjudicacionesLiquidez = new List<beAdjudicacionesLiquidez>();
                        beAdjudicacionesLiquidez obeAdjudicacionesLiquidez;

                        while (datard.Read())
                        {
                            obeAdjudicacionesLiquidez = new beAdjudicacionesLiquidez();
                            obeAdjudicacionesLiquidez.IdAdjudicacionLiquidez = datard.GetInt32(posIdAdjudicacionLiquidez);
                            obeAdjudicacionesLiquidez.IdAdjudicacion = datard.GetInt32(posIdAdjudicacicon);
                            obeAdjudicacionesLiquidez.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeAdjudicacionesLiquidez.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeAdjudicacionesLiquidez.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeAdjudicacionesLiquidez.NumeroOperacion = datard.GetString(posNumeroOperacion);
                            obeAdjudicacionesLiquidez.SaldoCuenta = datard.GetDecimal(posSaldoCuenta);
                            obeAdjudicacionesLiquidez.SaldoIgob = datard.GetDecimal(posSaldoIgob);
                            obeAdjudicacionesLiquidez.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeAdjudicacionesLiquidez.FechaDeposito = datard.GetDateTime(posFechaDeposito);
                            obeAdjudicacionesLiquidez.NumeroCuenta = datard.GetString(posNumeroCuenta);
                            obeAdjudicacionesLiquidez.NombreCuenta = datard.GetString(posNombreCuenta);
                            obeAdjudicacionesLiquidez.MontoDisponible = datard.GetDecimal(posMontoDisponible);
                            obeAdjudicacionesLiquidez.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            obeAdjudicacionesLiquidez.NombreCorto = datard.GetString(posNombreCorto);
                            lbeAdjudicacionesLiquidez.Add(obeAdjudicacionesLiquidez);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesLiquidez;
            }
        }

    }
}
