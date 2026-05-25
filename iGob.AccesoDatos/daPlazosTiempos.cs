using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daPlazosTiempos
 {
	public int guardarPlazosTiempos(SqlConnection Conexion, bePlazosTiempos obePlazosTiempos)
	{
		int Id=0;
		string sp = "Proc_PlazosTiemposInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = obePlazosTiempos.IdPlazoTiempo;
				cmd.Parameters.Add("@PlazozTiempo", SqlDbType.NChar).Value = obePlazosTiempos.PlazozTiempo;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obePlazosTiempos.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarPlazosTiempos(SqlConnection Conexion, bePlazosTiempos obePlazosTiempos)
	{
		string sp = "Proc_PlazosTiemposActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = obePlazosTiempos.IdPlazoTiempo;
				cmd.Parameters.Add("@PlazozTiempo", SqlDbType.NChar).Value = obePlazosTiempos.PlazozTiempo;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obePlazosTiempos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarPlazosTiempos(SqlConnection Conexion,int pIdPlazoTiempo)
	{
		string sp = "Proc_PlazosTiemposEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = pIdPlazoTiempo;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public bePlazosTiempos traerPlazosTiempos_x_IdPlazoTiempo(SqlConnection Conexion,int IdPlazoTiempo)
	{
		string sp = "Proc_PlazosTiempos_x_IdPlazoTiempo";
				bePlazosTiempos obePlazosTiempos=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = IdPlazoTiempo;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
						int posPlazozTiempo = datard.GetOrdinal("PlazozTiempo");
						int posActivo = datard.GetOrdinal("Activo");
					 obePlazosTiempos = new bePlazosTiempos();
				while (datard.Read())
					{
						obePlazosTiempos.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
						obePlazosTiempos.PlazozTiempo =  datard.GetString(posPlazozTiempo);
						obePlazosTiempos.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePlazosTiempos;
			}
	}
	public List< bePlazosTiempos> listarTodos_PlazosTiempos(SqlConnection Conexion)
	 {
		string sp = "Proc_PlazosTiempos_Traer_Todos";
		List<bePlazosTiempos> lbePlazosTiempos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
						int posPlazozTiempo = datard.GetOrdinal("PlazozTiempo");
						int posActivo = datard.GetOrdinal("Activo");
				lbePlazosTiempos = new List<bePlazosTiempos>();
				bePlazosTiempos obePlazosTiempos;
				while (datard.Read())
				{
					 obePlazosTiempos = new bePlazosTiempos();
					obePlazosTiempos.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
					obePlazosTiempos.PlazozTiempo =  datard.GetString(posPlazozTiempo);
					obePlazosTiempos.Activo =  datard.GetBoolean(posActivo);
					lbePlazosTiempos.Add(obePlazosTiempos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePlazosTiempos;
		}
	}
	public List< bePlazosTiempos> listar_PlazosTiempos_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_PlazosTiempos_TraerTodos_GetAll";
		List<bePlazosTiempos> lbePlazosTiempos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
						int posPlazozTiempo = datard.GetOrdinal("PlazozTiempo");
						int posActivo = datard.GetOrdinal("Activo");
				lbePlazosTiempos = new List<bePlazosTiempos>();
				bePlazosTiempos obePlazosTiempos;
				while (datard.Read())
				{
					 obePlazosTiempos = new bePlazosTiempos();
					obePlazosTiempos.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
					obePlazosTiempos.PlazozTiempo =  datard.GetString(posPlazozTiempo);
					obePlazosTiempos.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbePlazosTiempos.Add(obePlazosTiempos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePlazosTiempos;
		}
	}
}
}
