using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposPersonas
 {
	public int guardarTiposPersonas(SqlConnection Conexion, beTiposPersonas obeTiposPersonas)
	{
		int Id=0;
		string sp = "Proc_TiposPersonasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoPersona", SqlDbType.Int).Value = obeTiposPersonas.IdTipoPersona;
				cmd.Parameters.Add("@TipoPersona", SqlDbType.VarChar).Value = obeTiposPersonas.TipoPersona;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposPersonas.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposPersonas(SqlConnection Conexion, beTiposPersonas obeTiposPersonas)
	{
		string sp = "Proc_TiposPersonasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoPersona", SqlDbType.Int).Value = obeTiposPersonas.IdTipoPersona;
				cmd.Parameters.Add("@TipoPersona", SqlDbType.VarChar).Value = obeTiposPersonas.TipoPersona;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposPersonas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposPersonas(SqlConnection Conexion,int pIdTipoPersona)
	{
		string sp = "Proc_TiposPersonasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoPersona", SqlDbType.Int).Value = pIdTipoPersona;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposPersonas traerTiposPersonas_x_IdTipoPersona(SqlConnection Conexion,int IdTipoPersona)
	{
		string sp = "Proc_TiposPersonas_x_IdTipoPersona";
				beTiposPersonas obeTiposPersonas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoPersona", SqlDbType.Int).Value = IdTipoPersona;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdTipoPersona = datard.GetOrdinal("IdTipoPersona");
						int posTipoPersona = datard.GetOrdinal("TipoPersona");
						int posActivo = datard.GetOrdinal("Activo");
					 obeTiposPersonas = new beTiposPersonas();
				while (datard.Read())
					{
						obeTiposPersonas.IdTipoPersona =  datard.GetInt32(posIdTipoPersona);
						obeTiposPersonas.TipoPersona =  datard.GetString(posTipoPersona);
						obeTiposPersonas.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposPersonas;
			}
	}
	public List< beTiposPersonas> listarTodos_TiposPersonas(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposPersonas_Traer_Todos";
		List<beTiposPersonas> lbeTiposPersonas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoPersona = datard.GetOrdinal("IdTipoPersona");
						int posTipoPersona = datard.GetOrdinal("TipoPersona");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposPersonas = new List<beTiposPersonas>();
				beTiposPersonas obeTiposPersonas;
				while (datard.Read())
				{
					 obeTiposPersonas = new beTiposPersonas();
					obeTiposPersonas.IdTipoPersona =  datard.GetInt32(posIdTipoPersona);
					obeTiposPersonas.TipoPersona =  datard.GetString(posTipoPersona);
					obeTiposPersonas.Activo =  datard.GetBoolean(posActivo);
					lbeTiposPersonas.Add(obeTiposPersonas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposPersonas;
		}
	}
	public List< beTiposPersonas> listar_TiposPersonas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposPersonas_TraerTodos_GetAll";
		List<beTiposPersonas> lbeTiposPersonas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoPersona = datard.GetOrdinal("IdTipoPersona");
						int posTipoPersona = datard.GetOrdinal("TipoPersona");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposPersonas = new List<beTiposPersonas>();
				beTiposPersonas obeTiposPersonas;
				while (datard.Read())
				{
					 obeTiposPersonas = new beTiposPersonas();
					obeTiposPersonas.IdTipoPersona =  datard.GetInt32(posIdTipoPersona);
					obeTiposPersonas.TipoPersona =  datard.GetString(posTipoPersona);
					obeTiposPersonas.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeTiposPersonas.Add(obeTiposPersonas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposPersonas;
		}
	}
}
}
