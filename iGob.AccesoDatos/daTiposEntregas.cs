using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposEntregas
 {
	public int guardarTiposEntregas(SqlConnection Conexion, beTiposEntregas obeTiposEntregas)
	{
		int Id=0;
		string sp = "Proc_TiposEntregasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoEntrega", SqlDbType.Int).Value = obeTiposEntregas.IdTipoEntrega;
				cmd.Parameters.Add("@TipoEntrega", SqlDbType.NVarChar).Value = obeTiposEntregas.TipoEntrega;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposEntregas.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposEntregas(SqlConnection Conexion, beTiposEntregas obeTiposEntregas)
	{
		string sp = "Proc_TiposEntregasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoEntrega", SqlDbType.Int).Value = obeTiposEntregas.IdTipoEntrega;
				cmd.Parameters.Add("@TipoEntrega", SqlDbType.NVarChar).Value = obeTiposEntregas.TipoEntrega;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposEntregas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposEntregas(SqlConnection Conexion,int pIdTipoEntrega)
	{
		string sp = "Proc_TiposEntregasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoEntrega", SqlDbType.Int).Value = pIdTipoEntrega;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposEntregas traerTiposEntregas_x_IdTipoEntrega(SqlConnection Conexion,int IdTipoEntrega)
	{
		string sp = "Proc_TiposEntregas_x_IdTipoEntrega";
				beTiposEntregas obeTiposEntregas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoEntrega", SqlDbType.Int).Value = IdTipoEntrega;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
						int posTipoEntrega = datard.GetOrdinal("TipoEntrega");
						int posActivo = datard.GetOrdinal("Activo");
					 obeTiposEntregas = new beTiposEntregas();
				while (datard.Read())
					{
						obeTiposEntregas.IdTipoEntrega =  datard.GetInt32(posIdTipoEntrega);
						obeTiposEntregas.TipoEntrega =  datard.GetString(posTipoEntrega);
						obeTiposEntregas.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposEntregas;
			}
	}
	public List< beTiposEntregas> listarTodos_TiposEntregas(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposEntregas_Traer_Todos";
		List<beTiposEntregas> lbeTiposEntregas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
						int posTipoEntrega = datard.GetOrdinal("TipoEntrega");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposEntregas = new List<beTiposEntregas>();
				beTiposEntregas obeTiposEntregas;
				while (datard.Read())
				{
					 obeTiposEntregas = new beTiposEntregas();
					obeTiposEntregas.IdTipoEntrega =  datard.GetInt32(posIdTipoEntrega);
					obeTiposEntregas.TipoEntrega =  datard.GetString(posTipoEntrega);
					obeTiposEntregas.Activo =  datard.GetBoolean(posActivo);
					lbeTiposEntregas.Add(obeTiposEntregas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposEntregas;
		}
	}
	public List< beTiposEntregas> listar_TiposEntregas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposEntregas_TraerTodos_GetAll";
		List<beTiposEntregas> lbeTiposEntregas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
						int posTipoEntrega = datard.GetOrdinal("TipoEntrega");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposEntregas = new List<beTiposEntregas>();
				beTiposEntregas obeTiposEntregas;
				while (datard.Read())
				{
					 obeTiposEntregas = new beTiposEntregas();
					obeTiposEntregas.IdTipoEntrega =  datard.GetInt32(posIdTipoEntrega);
					obeTiposEntregas.TipoEntrega =  datard.GetString(posTipoEntrega);
					obeTiposEntregas.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeTiposEntregas.Add(obeTiposEntregas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposEntregas;
		}
	}
}
}
