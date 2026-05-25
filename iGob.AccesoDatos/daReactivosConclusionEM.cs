using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daReactivosConclusionEM
 {
	public int guardarReactivosConclusionEM(SqlConnection Conexion, beReactivosConclusionEM obeReactivosConclusionEM)
	{
		int Id=0;
		string sp = "Proc_ReactivosConclusionEMInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdReactivoConclusionEM", SqlDbType.Int).Value = obeReactivosConclusionEM.IdReactivoConclusionEM;
				cmd.Parameters.Add("@Reactivo", SqlDbType.VarChar).Value = obeReactivosConclusionEM.Reactivo;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeReactivosConclusionEM.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarReactivosConclusionEM(SqlConnection Conexion, beReactivosConclusionEM obeReactivosConclusionEM)
	{
		string sp = "Proc_ReactivosConclusionEMActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdReactivoConclusionEM", SqlDbType.Int).Value = obeReactivosConclusionEM.IdReactivoConclusionEM;
				cmd.Parameters.Add("@Reactivo", SqlDbType.VarChar).Value = obeReactivosConclusionEM.Reactivo;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeReactivosConclusionEM.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarReactivosConclusionEM(SqlConnection Conexion,int pIdReactivoConclusionEM)
	{
		string sp = "Proc_ReactivosConclusionEMEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdReactivoConclusionEM", SqlDbType.Int).Value = pIdReactivoConclusionEM;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beReactivosConclusionEM traerReactivosConclusionEM_x_IdReactivoConclusionEM(SqlConnection Conexion,int IdReactivoConclusionEM)
	{
		string sp = "Proc_ReactivosConclusionEM_x_IdReactivoConclusionEM";
				beReactivosConclusionEM obeReactivosConclusionEM=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdReactivoConclusionEM", SqlDbType.Int).Value = IdReactivoConclusionEM;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdReactivoConclusionEM = datard.GetOrdinal("IdReactivoConclusionEM");
						int posReactivo = datard.GetOrdinal("Reactivo");
						int posActivo = datard.GetOrdinal("Activo");
					 obeReactivosConclusionEM = new beReactivosConclusionEM();
				while (datard.Read())
					{
						obeReactivosConclusionEM.IdReactivoConclusionEM =  datard.GetInt32(posIdReactivoConclusionEM);
						obeReactivosConclusionEM.Reactivo =  datard.GetString(posReactivo);
						obeReactivosConclusionEM.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeReactivosConclusionEM;
			}
	}
	public List< beReactivosConclusionEM> listarTodos_ReactivosConclusionEM(SqlConnection Conexion)
	 {
		string sp = "Proc_ReactivosConclusionEM_Traer_Todos";
		List<beReactivosConclusionEM> lbeReactivosConclusionEM = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdReactivoConclusionEM = datard.GetOrdinal("IdReactivoConclusionEM");
						int posReactivo = datard.GetOrdinal("Reactivo");
						int posActivo = datard.GetOrdinal("Activo");
				lbeReactivosConclusionEM = new List<beReactivosConclusionEM>();
				beReactivosConclusionEM obeReactivosConclusionEM;
				while (datard.Read())
				{
					 obeReactivosConclusionEM = new beReactivosConclusionEM();
					obeReactivosConclusionEM.IdReactivoConclusionEM =  datard.GetInt32(posIdReactivoConclusionEM);
					obeReactivosConclusionEM.Reactivo =  datard.GetString(posReactivo);
					obeReactivosConclusionEM.Activo =  datard.GetBoolean(posActivo);
					lbeReactivosConclusionEM.Add(obeReactivosConclusionEM);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeReactivosConclusionEM;
		}
	}
	public List< beReactivosConclusionEM> listar_ReactivosConclusionEM_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_ReactivosConclusionEM_TraerTodos_GetAll";
		List<beReactivosConclusionEM> lbeReactivosConclusionEM = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdReactivoConclusionEM = datard.GetOrdinal("IdReactivoConclusionEM");
						int posReactivo = datard.GetOrdinal("Reactivo");
						int posActivo = datard.GetOrdinal("Activo");
				lbeReactivosConclusionEM = new List<beReactivosConclusionEM>();
				beReactivosConclusionEM obeReactivosConclusionEM;
				while (datard.Read())
				{
					 obeReactivosConclusionEM = new beReactivosConclusionEM();
					obeReactivosConclusionEM.IdReactivoConclusionEM =  datard.GetInt32(posIdReactivoConclusionEM);
					obeReactivosConclusionEM.Reactivo =  datard.GetString(posReactivo);
					obeReactivosConclusionEM.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeReactivosConclusionEM.Add(obeReactivosConclusionEM);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeReactivosConclusionEM;
		}
	}
}
}
