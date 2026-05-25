using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daPartidasActividadesEconomicas
 {
	public int guardarPartidasActividadesEconomicas(SqlConnection Conexion, bePartidasActividadesEconomicas obePartidasActividadesEconomicas)
	{
		int Id=0;
		string sp = "Proc_PartidasActividadesEconomicasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPartidaActEconomica", SqlDbType.Int).Value = obePartidasActividadesEconomicas.IdPartidaActEconomica;
				cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obePartidasActividadesEconomicas.IdPartida;
				cmd.Parameters.Add("@IdActividadEconomica", SqlDbType.Int).Value = obePartidasActividadesEconomicas.IdActividadEconomica;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obePartidasActividadesEconomicas.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarPartidasActividadesEconomicas(SqlConnection Conexion, bePartidasActividadesEconomicas obePartidasActividadesEconomicas)
	{
		string sp = "Proc_PartidasActividadesEconomicasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPartidaActEconomica", SqlDbType.Int).Value = obePartidasActividadesEconomicas.IdPartidaActEconomica;
				cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obePartidasActividadesEconomicas.IdPartida;
				cmd.Parameters.Add("@IdActividadEconomica", SqlDbType.Int).Value = obePartidasActividadesEconomicas.IdActividadEconomica;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obePartidasActividadesEconomicas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarPartidasActividadesEconomicas(SqlConnection Conexion,int pIdPartidaActEconomica)
	{
		string sp = "Proc_PartidasActividadesEconomicasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPartidaActEconomica", SqlDbType.Int).Value = pIdPartidaActEconomica;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public bePartidasActividadesEconomicas traerPartidasActividadesEconomicas_x_IdPartidaActEconomica(SqlConnection Conexion,int IdPartidaActEconomica)
	{
		string sp = "Proc_PartidasActividadesEconomicas_x_IdPartidaActEconomica";
				bePartidasActividadesEconomicas obePartidasActividadesEconomicas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPartidaActEconomica", SqlDbType.Int).Value = IdPartidaActEconomica;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdPartidaActEconomica = datard.GetOrdinal("IdPartidaActEconomica");
						int posIdPartida = datard.GetOrdinal("IdPartida");
						int posIdActividadEconomica = datard.GetOrdinal("IdActividadEconomica");
						int posActivo = datard.GetOrdinal("Activo");
					 obePartidasActividadesEconomicas = new bePartidasActividadesEconomicas();
				while (datard.Read())
					{
						obePartidasActividadesEconomicas.IdPartidaActEconomica =  datard.GetInt32(posIdPartidaActEconomica);
						obePartidasActividadesEconomicas.IdPartida =  datard.GetInt32(posIdPartida);
						obePartidasActividadesEconomicas.IdActividadEconomica =  datard.GetInt32(posIdActividadEconomica);
						obePartidasActividadesEconomicas.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePartidasActividadesEconomicas;
			}
	}
	public List< bePartidasActividadesEconomicas> listarTodos_PartidasActividadesEconomicas(SqlConnection Conexion)
	 {
		string sp = "Proc_PartidasActividadesEconomicas_Traer_Todos";
		List<bePartidasActividadesEconomicas> lbePartidasActividadesEconomicas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPartidaActEconomica = datard.GetOrdinal("IdPartidaActEconomica");
						int posIdPartida = datard.GetOrdinal("IdPartida");
						int posIdActividadEconomica = datard.GetOrdinal("IdActividadEconomica");
						int posActivo = datard.GetOrdinal("Activo");
				lbePartidasActividadesEconomicas = new List<bePartidasActividadesEconomicas>();
				bePartidasActividadesEconomicas obePartidasActividadesEconomicas;
				while (datard.Read())
				{
					 obePartidasActividadesEconomicas = new bePartidasActividadesEconomicas();
					obePartidasActividadesEconomicas.IdPartidaActEconomica =  datard.GetInt32(posIdPartidaActEconomica);
					obePartidasActividadesEconomicas.IdPartida =  datard.GetInt32(posIdPartida);
					obePartidasActividadesEconomicas.IdActividadEconomica =  datard.GetInt32(posIdActividadEconomica);
					obePartidasActividadesEconomicas.Activo =  datard.GetBoolean(posActivo);
					lbePartidasActividadesEconomicas.Add(obePartidasActividadesEconomicas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePartidasActividadesEconomicas;
		}
	}
	public List< bePartidasActividadesEconomicas> listar_PartidasActividadesEconomicas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_PartidasActividadesEconomicas_TraerTodos_GetAll";
		List<bePartidasActividadesEconomicas> lbePartidasActividadesEconomicas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPartidaActEconomica = datard.GetOrdinal("IdPartidaActEconomica");
						int posIdPartida = datard.GetOrdinal("IdPartida");
						int posIdActividadEconomica = datard.GetOrdinal("IdActividadEconomica");
						int posActivo = datard.GetOrdinal("Activo");

                        int posPartida = datard.GetOrdinal("Partida");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
				lbePartidasActividadesEconomicas = new List<bePartidasActividadesEconomicas>();
				bePartidasActividadesEconomicas obePartidasActividadesEconomicas;
				while (datard.Read())
				{
					 obePartidasActividadesEconomicas = new bePartidasActividadesEconomicas();
					obePartidasActividadesEconomicas.IdPartidaActEconomica =  datard.GetInt32(posIdPartidaActEconomica);
					obePartidasActividadesEconomicas.IdPartida =  datard.GetInt32(posIdPartida);
					obePartidasActividadesEconomicas.IdActividadEconomica =  datard.GetInt32(posIdActividadEconomica);
					obePartidasActividadesEconomicas.Activo =  datard.GetBoolean(posActivo);

                    obePartidasActividadesEconomicas.Partida = datard.GetString(posPartida);
                    obePartidasActividadesEconomicas.Descripcion = datard.GetString(posDescripcion);
			// debe agregar campos de la Vista
					lbePartidasActividadesEconomicas.Add(obePartidasActividadesEconomicas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePartidasActividadesEconomicas;
		}
	}
}
}
