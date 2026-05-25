using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposProcesos
 {
	public int guardarTiposProcesos(SqlConnection Conexion, beTiposProcesos obeTiposProcesos)
	{
		int Id=0;
		string sp = "Proc_TiposProcesosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoProceso", SqlDbType.Int).Value = obeTiposProcesos.IdTipoProceso;
				cmd.Parameters.Add("@TipoProceso", SqlDbType.VarChar).Value = obeTiposProcesos.TipoProceso;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposProcesos.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposProcesos(SqlConnection Conexion, beTiposProcesos obeTiposProcesos)
	{
		string sp = "Proc_TiposProcesosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoProceso", SqlDbType.Int).Value = obeTiposProcesos.IdTipoProceso;
				cmd.Parameters.Add("@TipoProceso", SqlDbType.VarChar).Value = obeTiposProcesos.TipoProceso;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposProcesos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposProcesos(SqlConnection Conexion,int pIdTipoProceso)
	{
		string sp = "Proc_TiposProcesosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoProceso", SqlDbType.Int).Value = pIdTipoProceso;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposProcesos traerTiposProcesos_x_IdTipoProceso(SqlConnection Conexion,int IdTipoProceso)
	{
		string sp = "Proc_TiposProcesos_x_IdTipoProceso";
				beTiposProcesos obeTiposProcesos=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoProceso", SqlDbType.Int).Value = IdTipoProceso;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdTipoProceso = datard.GetOrdinal("IdTipoProceso");
						int posTipoProceso = datard.GetOrdinal("TipoProceso");
						int posActivo = datard.GetOrdinal("Activo");
					 obeTiposProcesos = new beTiposProcesos();
				while (datard.Read())
					{
						obeTiposProcesos.IdTipoProceso =  datard.GetInt32(posIdTipoProceso);
						obeTiposProcesos.TipoProceso =  datard.GetString(posTipoProceso);
						obeTiposProcesos.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposProcesos;
			}
	}
	public List< beTiposProcesos> listarTodos_TiposProcesos(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposProcesos_Traer_Todos";
		List<beTiposProcesos> lbeTiposProcesos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoProceso = datard.GetOrdinal("IdTipoProceso");
						int posTipoProceso = datard.GetOrdinal("TipoProceso");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposProcesos = new List<beTiposProcesos>();
				beTiposProcesos obeTiposProcesos;
				while (datard.Read())
				{
					 obeTiposProcesos = new beTiposProcesos();
					obeTiposProcesos.IdTipoProceso =  datard.GetInt32(posIdTipoProceso);
					obeTiposProcesos.TipoProceso =  datard.GetString(posTipoProceso);
					obeTiposProcesos.Activo =  datard.GetBoolean(posActivo);
					lbeTiposProcesos.Add(obeTiposProcesos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposProcesos;
		}
	}
	public List< beTiposProcesos> listar_TiposProcesos_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposProcesos_TraerTodos_GetAll";
		List<beTiposProcesos> lbeTiposProcesos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoProceso = datard.GetOrdinal("IdTipoProceso");
						int posTipoProceso = datard.GetOrdinal("TipoProceso");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposProcesos = new List<beTiposProcesos>();
				beTiposProcesos obeTiposProcesos;
				while (datard.Read())
				{
					 obeTiposProcesos = new beTiposProcesos();
					obeTiposProcesos.IdTipoProceso =  datard.GetInt32(posIdTipoProceso);
					obeTiposProcesos.TipoProceso =  datard.GetString(posTipoProceso);
					obeTiposProcesos.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeTiposProcesos.Add(obeTiposProcesos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposProcesos;
		}
	}
}
}
