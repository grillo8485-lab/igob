using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposAdjudicacion
 {
	public int guardarTiposAdjudicacion(SqlConnection Conexion, beTiposAdjudicacion obeTiposAdjudicacion)
	{
		int Id=0;
		string sp = "Proc_TiposAdjudicacionInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoAdjudicacion", SqlDbType.Int).Value = obeTiposAdjudicacion.IdTipoAdjudicacion;
				cmd.Parameters.Add("@TipoAdjudicacion", SqlDbType.NVarChar).Value = obeTiposAdjudicacion.TipoAdjudicacion;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeTiposAdjudicacion.Abreviatura;
				cmd.Parameters.Add("@MontoMinimo", SqlDbType.Decimal).Value = obeTiposAdjudicacion.MontoMinimo;
				cmd.Parameters.Add("@MontoMaximo", SqlDbType.Decimal).Value = obeTiposAdjudicacion.MontoMaximo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposAdjudicacion(SqlConnection Conexion, beTiposAdjudicacion obeTiposAdjudicacion)
	{
		string sp = "Proc_TiposAdjudicacionActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoAdjudicacion", SqlDbType.Int).Value = obeTiposAdjudicacion.IdTipoAdjudicacion;
				cmd.Parameters.Add("@TipoAdjudicacion", SqlDbType.NVarChar).Value = obeTiposAdjudicacion.TipoAdjudicacion;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeTiposAdjudicacion.Abreviatura;
				cmd.Parameters.Add("@MontoMinimo", SqlDbType.Decimal).Value = obeTiposAdjudicacion.MontoMinimo;
				cmd.Parameters.Add("@MontoMaximo", SqlDbType.Decimal).Value = obeTiposAdjudicacion.MontoMaximo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposAdjudicacion(SqlConnection Conexion,int pIdTipoAdjudicacion)
	{
		string sp = "Proc_TiposAdjudicacionEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoAdjudicacion", SqlDbType.Int).Value = pIdTipoAdjudicacion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposAdjudicacion traerTiposAdjudicacion_x_IdTipoAdjudicacion(SqlConnection Conexion,int IdTipoAdjudicacion)
	{
		string sp = "Proc_TiposAdjudicacion_x_IdTipoAdjudicacion";
				beTiposAdjudicacion obeTiposAdjudicacion=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoAdjudicacion", SqlDbType.Int).Value = IdTipoAdjudicacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdTipoAdjudicacion = datard.GetOrdinal("IdTipoAdjudicacion");
						int posTipoAdjudicacion = datard.GetOrdinal("TipoAdjudicacion");
						int posAbreviatura = datard.GetOrdinal("Abreviatura");
						int posMontoMinimo = datard.GetOrdinal("MontoMinimo");
						int posMontoMaximo = datard.GetOrdinal("MontoMaximo");
					 obeTiposAdjudicacion = new beTiposAdjudicacion();
				while (datard.Read())
					{
						obeTiposAdjudicacion.IdTipoAdjudicacion =  datard.GetInt32(posIdTipoAdjudicacion);
						obeTiposAdjudicacion.TipoAdjudicacion =  datard.GetString(posTipoAdjudicacion);
						obeTiposAdjudicacion.Abreviatura =  datard.GetString(posAbreviatura);
						obeTiposAdjudicacion.MontoMinimo =  datard.GetDecimal(posMontoMinimo);
						obeTiposAdjudicacion.MontoMaximo =  datard.GetDecimal(posMontoMaximo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposAdjudicacion;
			}
	}
	public List< beTiposAdjudicacion> listarTodos_TiposAdjudicacion(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposAdjudicacion_Traer_Todos";
		List<beTiposAdjudicacion> lbeTiposAdjudicacion = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoAdjudicacion = datard.GetOrdinal("IdTipoAdjudicacion");
						int posTipoAdjudicacion = datard.GetOrdinal("TipoAdjudicacion");
						int posAbreviatura = datard.GetOrdinal("Abreviatura");
						int posMontoMinimo = datard.GetOrdinal("MontoMinimo");
						int posMontoMaximo = datard.GetOrdinal("MontoMaximo");
				lbeTiposAdjudicacion = new List<beTiposAdjudicacion>();
				beTiposAdjudicacion obeTiposAdjudicacion;
				while (datard.Read())
				{
					 obeTiposAdjudicacion = new beTiposAdjudicacion();
					obeTiposAdjudicacion.IdTipoAdjudicacion =  datard.GetInt32(posIdTipoAdjudicacion);
					obeTiposAdjudicacion.TipoAdjudicacion =  datard.GetString(posTipoAdjudicacion);
					obeTiposAdjudicacion.Abreviatura =  datard.GetString(posAbreviatura);
					obeTiposAdjudicacion.MontoMinimo =  datard.GetDecimal(posMontoMinimo);
					obeTiposAdjudicacion.MontoMaximo =  datard.GetDecimal(posMontoMaximo);
					lbeTiposAdjudicacion.Add(obeTiposAdjudicacion);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposAdjudicacion;
		}
	}
	public List< beTiposAdjudicacion> listar_TiposAdjudicacion_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposAdjudicacion_TraerTodos_GetAll";
		List<beTiposAdjudicacion> lbeTiposAdjudicacion = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoAdjudicacion = datard.GetOrdinal("IdTipoAdjudicacion");
						int posTipoAdjudicacion = datard.GetOrdinal("TipoAdjudicacion");
						int posAbreviatura = datard.GetOrdinal("Abreviatura");
						int posMontoMinimo = datard.GetOrdinal("MontoMinimo");
						int posMontoMaximo = datard.GetOrdinal("MontoMaximo");
				lbeTiposAdjudicacion = new List<beTiposAdjudicacion>();
				beTiposAdjudicacion obeTiposAdjudicacion;
				while (datard.Read())
				{
					 obeTiposAdjudicacion = new beTiposAdjudicacion();
					obeTiposAdjudicacion.IdTipoAdjudicacion =  datard.GetInt32(posIdTipoAdjudicacion);
					obeTiposAdjudicacion.TipoAdjudicacion =  datard.GetString(posTipoAdjudicacion);
					obeTiposAdjudicacion.Abreviatura =  datard.GetString(posAbreviatura);
					obeTiposAdjudicacion.MontoMinimo =  datard.GetDecimal(posMontoMinimo);
					obeTiposAdjudicacion.MontoMaximo =  datard.GetDecimal(posMontoMaximo);
			// debe agregar campos de la Vista
					lbeTiposAdjudicacion.Add(obeTiposAdjudicacion);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposAdjudicacion;
		}
	}
}
}
