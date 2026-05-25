using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daEstatusPersonas
 {
	public int guardarEstatusPersonas(SqlConnection Conexion, beEstatusPersonas obeEstatusPersonas)
	{
		int Id=0;
		string sp = "Proc_EstatusPersonasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPersona", SqlDbType.Int).Value = obeEstatusPersonas.IdEstatusPersona;
				cmd.Parameters.Add("@Estatus", SqlDbType.NVarChar).Value = obeEstatusPersonas.Estatus;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEstatusPersonas.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarEstatusPersonas(SqlConnection Conexion, beEstatusPersonas obeEstatusPersonas)
	{
		string sp = "Proc_EstatusPersonasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPersona", SqlDbType.Int).Value = obeEstatusPersonas.IdEstatusPersona;
				cmd.Parameters.Add("@Estatus", SqlDbType.NVarChar).Value = obeEstatusPersonas.Estatus;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEstatusPersonas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarEstatusPersonas(SqlConnection Conexion,int pIdEstatusPersona)
	{
		string sp = "Proc_EstatusPersonasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPersona", SqlDbType.Int).Value = pIdEstatusPersona;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beEstatusPersonas traerEstatusPersonas_x_IdEstatusPersona(SqlConnection Conexion,int IdEstatusPersona)
	{
		string sp = "Proc_EstatusPersonas_x_IdEstatusPersona";
				beEstatusPersonas obeEstatusPersonas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdEstatusPersona", SqlDbType.Int).Value = IdEstatusPersona;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdEstatusPersona = datard.GetOrdinal("IdEstatusPersona");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
					 obeEstatusPersonas = new beEstatusPersonas();
				while (datard.Read())
					{
						obeEstatusPersonas.IdEstatusPersona =  datard.GetInt32(posIdEstatusPersona);
						obeEstatusPersonas.Estatus =  datard.GetString(posEstatus);
						obeEstatusPersonas.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEstatusPersonas;
			}
	}
	public List< beEstatusPersonas> listarTodos_EstatusPersonas(SqlConnection Conexion)
	 {
		string sp = "Proc_EstatusPersonas_Traer_Todos";
		List<beEstatusPersonas> lbeEstatusPersonas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdEstatusPersona = datard.GetOrdinal("IdEstatusPersona");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
				lbeEstatusPersonas = new List<beEstatusPersonas>();
				beEstatusPersonas obeEstatusPersonas;
				while (datard.Read())
				{
					 obeEstatusPersonas = new beEstatusPersonas();
					obeEstatusPersonas.IdEstatusPersona =  datard.GetInt32(posIdEstatusPersona);
					obeEstatusPersonas.Estatus =  datard.GetString(posEstatus);
					obeEstatusPersonas.Activo =  datard.GetBoolean(posActivo);
					lbeEstatusPersonas.Add(obeEstatusPersonas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPersonas;
		}
	}
	public List< beEstatusPersonas> listar_EstatusPersonas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_EstatusPersonas_TraerTodos_GetAll";
		List<beEstatusPersonas> lbeEstatusPersonas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdEstatusPersona = datard.GetOrdinal("IdEstatusPersona");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
				lbeEstatusPersonas = new List<beEstatusPersonas>();
				beEstatusPersonas obeEstatusPersonas;
				while (datard.Read())
				{
					 obeEstatusPersonas = new beEstatusPersonas();
					obeEstatusPersonas.IdEstatusPersona =  datard.GetInt32(posIdEstatusPersona);
					obeEstatusPersonas.Estatus =  datard.GetString(posEstatus);
					obeEstatusPersonas.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeEstatusPersonas.Add(obeEstatusPersonas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPersonas;
		}
	}
}
}
