using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daEstatusEstudioMercado
 {
	public int guardarEstatusEstudioMercado(SqlConnection Conexion, beEstatusEstudioMercado obeEstatusEstudioMercado)
	{
		int Id=0;
		string sp = "Proc_EstatusEstudioMercadoInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusEstudioMercado", SqlDbType.Int).Value = obeEstatusEstudioMercado.IdEstatusEstudioMercado;
				cmd.Parameters.Add("@EstatusEstudioMercado", SqlDbType.VarChar).Value = obeEstatusEstudioMercado.EstatusEstudioMercado;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEstatusEstudioMercado.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarEstatusEstudioMercado(SqlConnection Conexion, beEstatusEstudioMercado obeEstatusEstudioMercado)
	{
		string sp = "Proc_EstatusEstudioMercadoActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusEstudioMercado", SqlDbType.Int).Value = obeEstatusEstudioMercado.IdEstatusEstudioMercado;
				cmd.Parameters.Add("@EstatusEstudioMercado", SqlDbType.VarChar).Value = obeEstatusEstudioMercado.EstatusEstudioMercado;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEstatusEstudioMercado.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarEstatusEstudioMercado(SqlConnection Conexion,int pIdEstatusEstudioMercado)
	{
		string sp = "Proc_EstatusEstudioMercadoEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusEstudioMercado", SqlDbType.Int).Value = pIdEstatusEstudioMercado;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beEstatusEstudioMercado traerEstatusEstudioMercado_x_IdEstatusEstudioMercado(SqlConnection Conexion,int IdEstatusEstudioMercado)
	{
		string sp = "Proc_EstatusEstudioMercado_x_IdEstatusEstudioMercado";
				beEstatusEstudioMercado obeEstatusEstudioMercado=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdEstatusEstudioMercado", SqlDbType.Int).Value = IdEstatusEstudioMercado;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdEstatusEstudioMercado = datard.GetOrdinal("IdEstatusEstudioMercado");
						int posEstatusEstudioMercado = datard.GetOrdinal("EstatusEstudioMercado");
						int posActivo = datard.GetOrdinal("Activo");
					 obeEstatusEstudioMercado = new beEstatusEstudioMercado();
				while (datard.Read())
					{
						obeEstatusEstudioMercado.IdEstatusEstudioMercado =  datard.GetInt32(posIdEstatusEstudioMercado);
						obeEstatusEstudioMercado.EstatusEstudioMercado =  datard.GetString(posEstatusEstudioMercado);
						obeEstatusEstudioMercado.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEstatusEstudioMercado;
			}
	}
	public List< beEstatusEstudioMercado> listarTodos_EstatusEstudioMercado(SqlConnection Conexion)
	 {
		string sp = "Proc_EstatusEstudioMercado_Traer_Todos";
		List<beEstatusEstudioMercado> lbeEstatusEstudioMercado = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdEstatusEstudioMercado = datard.GetOrdinal("IdEstatusEstudioMercado");
						int posEstatusEstudioMercado = datard.GetOrdinal("EstatusEstudioMercado");
						int posActivo = datard.GetOrdinal("Activo");
				lbeEstatusEstudioMercado = new List<beEstatusEstudioMercado>();
				beEstatusEstudioMercado obeEstatusEstudioMercado;
				while (datard.Read())
				{
					 obeEstatusEstudioMercado = new beEstatusEstudioMercado();
					obeEstatusEstudioMercado.IdEstatusEstudioMercado =  datard.GetInt32(posIdEstatusEstudioMercado);
					obeEstatusEstudioMercado.EstatusEstudioMercado =  datard.GetString(posEstatusEstudioMercado);
					obeEstatusEstudioMercado.Activo =  datard.GetBoolean(posActivo);
					lbeEstatusEstudioMercado.Add(obeEstatusEstudioMercado);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusEstudioMercado;
		}
	}
	public List< beEstatusEstudioMercado> listar_EstatusEstudioMercado_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_EstatusEstudioMercado_TraerTodos_GetAll";
		List<beEstatusEstudioMercado> lbeEstatusEstudioMercado = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdEstatusEstudioMercado = datard.GetOrdinal("IdEstatusEstudioMercado");
						int posEstatusEstudioMercado = datard.GetOrdinal("EstatusEstudioMercado");
						int posActivo = datard.GetOrdinal("Activo");
				lbeEstatusEstudioMercado = new List<beEstatusEstudioMercado>();
				beEstatusEstudioMercado obeEstatusEstudioMercado;
				while (datard.Read())
				{
					 obeEstatusEstudioMercado = new beEstatusEstudioMercado();
					obeEstatusEstudioMercado.IdEstatusEstudioMercado =  datard.GetInt32(posIdEstatusEstudioMercado);
					obeEstatusEstudioMercado.EstatusEstudioMercado =  datard.GetString(posEstatusEstudioMercado);
					obeEstatusEstudioMercado.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeEstatusEstudioMercado.Add(obeEstatusEstudioMercado);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusEstudioMercado;
		}
	}
}
}
