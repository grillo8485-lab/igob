using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposMonedas
 {
	public int guardarTiposMonedas(SqlConnection Conexion, beTiposMonedas obeTiposMonedas)
	{
		int Id=0;
		string sp = "Proc_TiposMonedasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoMoneda", SqlDbType.Int).Value = obeTiposMonedas.IdTipoMoneda;
				cmd.Parameters.Add("@Moneda", SqlDbType.NChar).Value = obeTiposMonedas.Moneda;
				cmd.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = obeTiposMonedas.TipoCambio;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposMonedas.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposMonedas(SqlConnection Conexion, beTiposMonedas obeTiposMonedas)
	{
		string sp = "Proc_TiposMonedasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoMoneda", SqlDbType.Int).Value = obeTiposMonedas.IdTipoMoneda;
				cmd.Parameters.Add("@Moneda", SqlDbType.NChar).Value = obeTiposMonedas.Moneda;
				cmd.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = obeTiposMonedas.TipoCambio;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposMonedas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposMonedas(SqlConnection Conexion,int pIdTipoMoneda)
	{
		string sp = "Proc_TiposMonedasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoMoneda", SqlDbType.Int).Value = pIdTipoMoneda;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposMonedas traerTiposMonedas_x_IdTipoMoneda(SqlConnection Conexion,int IdTipoMoneda)
	{
		string sp = "Proc_TiposMonedas_x_IdTipoMoneda";
		List<beTiposMonedas> lbeTiposMonedas = null;
				beTiposMonedas obeTiposMonedas=new beTiposMonedas();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoMoneda", SqlDbType.Int).Value = IdTipoMoneda;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeTiposMonedas = new List<beTiposMonedas>();
				while (datard.Read())
					{
					 obeTiposMonedas = new beTiposMonedas();
						obeTiposMonedas.IdTipoMoneda =  datard.GetInt32(0);
						obeTiposMonedas.Moneda =  datard.GetString(1);
						obeTiposMonedas.TipoCambio =  datard.GetDecimal(2);
						obeTiposMonedas.Activo =  datard.GetBoolean(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposMonedas;
			}
	}
	public List< beTiposMonedas> listarTodos_TiposMonedas(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposMonedas_Traer_Todos";
		List<beTiposMonedas> lbeTiposMonedas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeTiposMonedas = new List<beTiposMonedas>();
				beTiposMonedas obeTiposMonedas;
				while (datard.Read())
				{
					 obeTiposMonedas = new beTiposMonedas();
					obeTiposMonedas.IdTipoMoneda =  datard.GetInt32(0);
					obeTiposMonedas.Moneda =  datard.GetString(1);
					obeTiposMonedas.TipoCambio =  datard.GetDecimal(2);
					obeTiposMonedas.Activo =  datard.GetBoolean(3);
					lbeTiposMonedas.Add(obeTiposMonedas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposMonedas;
		}
	}
	public DataTable listarTiposMonedas_x_(SqlConnection Conexion,int IdTipoMoneda)
	 {
		string sp = "Proc_TiposMonedas_Traer_Todos";
		DataTable dtTiposMonedas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoMoneda", SqlDbType.Int).Value = IdTipoMoneda;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtTiposMonedas = new DataTable();
				dtTiposMonedas.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtTiposMonedas;
		}
	}
}
}
