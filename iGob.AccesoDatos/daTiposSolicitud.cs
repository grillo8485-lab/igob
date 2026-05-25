using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposSolicitud
 {
	public int guardarTiposSolicitud(SqlConnection Conexion, beTiposSolicitud obeTiposSolicitud)
	{
		int Id=0;
		string sp = "Proc_TiposSolicitudInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = obeTiposSolicitud.IdTipoSolicitud;
				cmd.Parameters.Add("@TipoSolicitud", SqlDbType.VarChar).Value = obeTiposSolicitud.TipoSolicitud;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeTiposSolicitud.Descripcion;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.Char).Value = obeTiposSolicitud.Abreviatura;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposSolicitud.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposSolicitud(SqlConnection Conexion, beTiposSolicitud obeTiposSolicitud)
	{
		string sp = "Proc_TiposSolicitudActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = obeTiposSolicitud.IdTipoSolicitud;
				cmd.Parameters.Add("@TipoSolicitud", SqlDbType.VarChar).Value = obeTiposSolicitud.TipoSolicitud;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeTiposSolicitud.Descripcion;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.Char).Value = obeTiposSolicitud.Abreviatura;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposSolicitud.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposSolicitud(SqlConnection Conexion,int pIdTipoSolicitud)
	{
		string sp = "Proc_TiposSolicitudEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = pIdTipoSolicitud;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposSolicitud traerTiposSolicitud_x_IdTipoSolicitud(SqlConnection Conexion,int IdTipoSolicitud)
	{
		string sp = "Proc_TiposSolicitud_x_IdTipoSolicitud";
				beTiposSolicitud obeTiposSolicitud=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = IdTipoSolicitud;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
						int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
						int posDescripcion = datard.GetOrdinal("Descripcion");
						int posAbreviatura = datard.GetOrdinal("Abreviatura");
						int posActivo = datard.GetOrdinal("Activo");
					 obeTiposSolicitud = new beTiposSolicitud();
				while (datard.Read())
					{
						obeTiposSolicitud.IdTipoSolicitud =  datard.GetInt32(posIdTipoSolicitud);
						obeTiposSolicitud.TipoSolicitud =  datard.GetString(posTipoSolicitud);
						obeTiposSolicitud.Descripcion =  datard.GetString(posDescripcion);
						obeTiposSolicitud.Abreviatura =  datard.GetString(posAbreviatura);
						obeTiposSolicitud.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposSolicitud;
			}
	}
	public List< beTiposSolicitud> listarTodos_TiposSolicitud(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposSolicitud_Traer_Todos";
		List<beTiposSolicitud> lbeTiposSolicitud = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
						int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
						int posDescripcion = datard.GetOrdinal("Descripcion");
						int posAbreviatura = datard.GetOrdinal("Abreviatura");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposSolicitud = new List<beTiposSolicitud>();
				beTiposSolicitud obeTiposSolicitud;
				while (datard.Read())
				{
					 obeTiposSolicitud = new beTiposSolicitud();
					obeTiposSolicitud.IdTipoSolicitud =  datard.GetInt32(posIdTipoSolicitud);
					obeTiposSolicitud.TipoSolicitud =  datard.GetString(posTipoSolicitud);
					obeTiposSolicitud.Descripcion =  datard.GetString(posDescripcion);
					obeTiposSolicitud.Abreviatura =  datard.GetString(posAbreviatura);
					obeTiposSolicitud.Activo =  datard.GetBoolean(posActivo);
					lbeTiposSolicitud.Add(obeTiposSolicitud);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposSolicitud;
		}
	}
	public List< beTiposSolicitud> listar_TiposSolicitud_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposSolicitud_TraerTodos_GetAll";
		List<beTiposSolicitud> lbeTiposSolicitud = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
						int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
						int posDescripcion = datard.GetOrdinal("Descripcion");
						int posAbreviatura = datard.GetOrdinal("Abreviatura");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposSolicitud = new List<beTiposSolicitud>();
				beTiposSolicitud obeTiposSolicitud;
				while (datard.Read())
				{
					 obeTiposSolicitud = new beTiposSolicitud();
					obeTiposSolicitud.IdTipoSolicitud =  datard.GetInt32(posIdTipoSolicitud);
					obeTiposSolicitud.TipoSolicitud =  datard.GetString(posTipoSolicitud);
					obeTiposSolicitud.Descripcion =  datard.GetString(posDescripcion);
					obeTiposSolicitud.Abreviatura =  datard.GetString(posAbreviatura);
					obeTiposSolicitud.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeTiposSolicitud.Add(obeTiposSolicitud);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposSolicitud;
		}
	}
}
}
