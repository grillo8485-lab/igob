using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daPlazosEntregas
 {
	public int guardarPlazosEntregas(SqlConnection Conexion, bePlazosEntregas obePlazosEntregas)
	{
		int Id=0;
		string sp = "Proc_PlazosEntregasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPlazoEntrega", SqlDbType.Int).Value = obePlazosEntregas.IdPlazoEntrega;
				cmd.Parameters.Add("@PlazoEntrega", SqlDbType.NVarChar).Value = obePlazosEntregas.PlazoEntrega;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obePlazosEntregas.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarPlazosEntregas(SqlConnection Conexion, bePlazosEntregas obePlazosEntregas)
	{
		string sp = "Proc_PlazosEntregasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPlazoEntrega", SqlDbType.Int).Value = obePlazosEntregas.IdPlazoEntrega;
				cmd.Parameters.Add("@PlazoEntrega", SqlDbType.NVarChar).Value = obePlazosEntregas.PlazoEntrega;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obePlazosEntregas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarPlazosEntregas(SqlConnection Conexion,int pIdPlazoEntrega)
	{
		string sp = "Proc_PlazosEntregasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPlazoEntrega", SqlDbType.Int).Value = pIdPlazoEntrega;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public bePlazosEntregas traerPlazosEntregas_x_IdPlazoEntrega(SqlConnection Conexion,int IdPlazoEntrega)
	{
		string sp = "Proc_PlazosEntregas_x_IdPlazoEntrega";
				bePlazosEntregas obePlazosEntregas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPlazoEntrega", SqlDbType.Int).Value = IdPlazoEntrega;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdPlazoEntrega = datard.GetOrdinal("IdPlazoEntrega");
						int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");
						int posActivo = datard.GetOrdinal("Activo");
					 obePlazosEntregas = new bePlazosEntregas();
				while (datard.Read())
					{
						obePlazosEntregas.IdPlazoEntrega =  datard.GetInt32(posIdPlazoEntrega);
						obePlazosEntregas.PlazoEntrega =  datard.GetString(posPlazoEntrega);
						obePlazosEntregas.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePlazosEntregas;
			}
	}
	public List< bePlazosEntregas> listarTodos_PlazosEntregas(SqlConnection Conexion)
	 {
		string sp = "Proc_PlazosEntregas_Traer_Todos";
		List<bePlazosEntregas> lbePlazosEntregas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPlazoEntrega = datard.GetOrdinal("IdPlazoEntrega");
						int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");
						int posActivo = datard.GetOrdinal("Activo");
				lbePlazosEntregas = new List<bePlazosEntregas>();
				bePlazosEntregas obePlazosEntregas;
				while (datard.Read())
				{
					 obePlazosEntregas = new bePlazosEntregas();
					obePlazosEntregas.IdPlazoEntrega =  datard.GetInt32(posIdPlazoEntrega);
					obePlazosEntregas.PlazoEntrega =  datard.GetString(posPlazoEntrega);
					obePlazosEntregas.Activo =  datard.GetBoolean(posActivo);
					lbePlazosEntregas.Add(obePlazosEntregas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePlazosEntregas;
		}
	}
	public List< bePlazosEntregas> listar_PlazosEntregas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_PlazosEntregas_TraerTodos_GetAll";
		List<bePlazosEntregas> lbePlazosEntregas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPlazoEntrega = datard.GetOrdinal("IdPlazoEntrega");
						int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");
						int posActivo = datard.GetOrdinal("Activo");
				lbePlazosEntregas = new List<bePlazosEntregas>();
				bePlazosEntregas obePlazosEntregas;
				while (datard.Read())
				{
					 obePlazosEntregas = new bePlazosEntregas();
					obePlazosEntregas.IdPlazoEntrega =  datard.GetInt32(posIdPlazoEntrega);
					obePlazosEntregas.PlazoEntrega =  datard.GetString(posPlazoEntrega);
					obePlazosEntregas.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbePlazosEntregas.Add(obePlazosEntregas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePlazosEntregas;
		}
	}
}
}
