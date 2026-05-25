using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daHistotialPreciosBienServicio
 {
	public int guardarHistotialPreciosBienServicio(SqlConnection Conexion, beHistotialPreciosBienServicio obeHistotialPreciosBienServicio)
	{
		int Id=0;
		string sp = "Proc_HistotialPreciosBienServicioInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdHistorialPrecioBienServicio", SqlDbType.Int).Value = obeHistotialPreciosBienServicio.IdHistorialPrecioBienServicio;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeHistotialPreciosBienServicio.IdBienServicio;
				cmd.Parameters.Add("@PrecioUnitarioActual", SqlDbType.Decimal).Value = obeHistotialPreciosBienServicio.PrecioUnitarioActual;
				cmd.Parameters.Add("@PrecioUnitarioAnterior", SqlDbType.Decimal).Value = obeHistotialPreciosBienServicio.PrecioUnitarioAnterior;
				cmd.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = obeHistotialPreciosBienServicio.FechaActualizacion;
				cmd.Parameters.Add("@IdDatoEstudioMercado", SqlDbType.Int).Value = obeHistotialPreciosBienServicio.IdDatoEstudioMercado;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarHistotialPreciosBienServicio(SqlConnection Conexion, beHistotialPreciosBienServicio obeHistotialPreciosBienServicio)
	{
		string sp = "Proc_HistotialPreciosBienServicioActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdHistorialPrecioBienServicio", SqlDbType.Int).Value = obeHistotialPreciosBienServicio.IdHistorialPrecioBienServicio;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeHistotialPreciosBienServicio.IdBienServicio;
				cmd.Parameters.Add("@PrecioUnitarioActual", SqlDbType.Decimal).Value = obeHistotialPreciosBienServicio.PrecioUnitarioActual;
				cmd.Parameters.Add("@PrecioUnitarioAnterior", SqlDbType.Decimal).Value = obeHistotialPreciosBienServicio.PrecioUnitarioAnterior;
				cmd.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = obeHistotialPreciosBienServicio.FechaActualizacion;
				cmd.Parameters.Add("@IdDatoEstudioMercado", SqlDbType.Int).Value = obeHistotialPreciosBienServicio.IdDatoEstudioMercado;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarHistotialPreciosBienServicio(SqlConnection Conexion,int pIdHistorialPrecioBienServicio)
	{
		string sp = "Proc_HistotialPreciosBienServicioEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdHistorialPrecioBienServicio", SqlDbType.Int).Value = pIdHistorialPrecioBienServicio;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beHistotialPreciosBienServicio traerHistotialPreciosBienServicio_x_IdHistorialPrecioBienServicio(SqlConnection Conexion,int IdHistorialPrecioBienServicio)
	{
		string sp = "Proc_HistotialPreciosBienServicio_x_IdHistorialPrecioBienServicio";
				beHistotialPreciosBienServicio obeHistotialPreciosBienServicio=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdHistorialPrecioBienServicio", SqlDbType.Int).Value = IdHistorialPrecioBienServicio;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdHistorialPrecioBienServicio = datard.GetOrdinal("IdHistorialPrecioBienServicio");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posPrecioUnitarioActual = datard.GetOrdinal("PrecioUnitarioActual");
						int posPrecioUnitarioAnterior = datard.GetOrdinal("PrecioUnitarioAnterior");
						int posFechaActualizacion = datard.GetOrdinal("FechaActualizacion");
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
					 obeHistotialPreciosBienServicio = new beHistotialPreciosBienServicio();
				while (datard.Read())
					{
						obeHistotialPreciosBienServicio.IdHistorialPrecioBienServicio =  datard.GetInt32(posIdHistorialPrecioBienServicio);
						obeHistotialPreciosBienServicio.IdBienServicio =  datard.GetInt32(posIdBienServicio);
						obeHistotialPreciosBienServicio.PrecioUnitarioActual =  datard.GetDecimal(posPrecioUnitarioActual);
						obeHistotialPreciosBienServicio.PrecioUnitarioAnterior =  datard.GetDecimal(posPrecioUnitarioAnterior);
						obeHistotialPreciosBienServicio.FechaActualizacion =  datard.GetDateTime(posFechaActualizacion);
						obeHistotialPreciosBienServicio.IdDatoEstudioMercado =  datard.GetInt32(posIdDatoEstudioMercado);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeHistotialPreciosBienServicio;
			}
	}
	public List< beHistotialPreciosBienServicio> listarTodos_HistotialPreciosBienServicio(SqlConnection Conexion)
	 {
		string sp = "Proc_HistotialPreciosBienServicio_Traer_Todos";
		List<beHistotialPreciosBienServicio> lbeHistotialPreciosBienServicio = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdHistorialPrecioBienServicio = datard.GetOrdinal("IdHistorialPrecioBienServicio");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posPrecioUnitarioActual = datard.GetOrdinal("PrecioUnitarioActual");
						int posPrecioUnitarioAnterior = datard.GetOrdinal("PrecioUnitarioAnterior");
						int posFechaActualizacion = datard.GetOrdinal("FechaActualizacion");
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
				lbeHistotialPreciosBienServicio = new List<beHistotialPreciosBienServicio>();
				beHistotialPreciosBienServicio obeHistotialPreciosBienServicio;
				while (datard.Read())
				{
					 obeHistotialPreciosBienServicio = new beHistotialPreciosBienServicio();
					obeHistotialPreciosBienServicio.IdHistorialPrecioBienServicio =  datard.GetInt32(posIdHistorialPrecioBienServicio);
					obeHistotialPreciosBienServicio.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obeHistotialPreciosBienServicio.PrecioUnitarioActual =  datard.GetDecimal(posPrecioUnitarioActual);
					obeHistotialPreciosBienServicio.PrecioUnitarioAnterior =  datard.GetDecimal(posPrecioUnitarioAnterior);
					obeHistotialPreciosBienServicio.FechaActualizacion =  datard.GetDateTime(posFechaActualizacion);
					obeHistotialPreciosBienServicio.IdDatoEstudioMercado =  datard.GetInt32(posIdDatoEstudioMercado);
					lbeHistotialPreciosBienServicio.Add(obeHistotialPreciosBienServicio);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeHistotialPreciosBienServicio;
		}
	}
	public List< beHistotialPreciosBienServicio> listar_HistotialPreciosBienServicio_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_HistotialPreciosBienServicio_TraerTodos_GetAll";
		List<beHistotialPreciosBienServicio> lbeHistotialPreciosBienServicio = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdHistorialPrecioBienServicio = datard.GetOrdinal("IdHistorialPrecioBienServicio");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posPrecioUnitarioActual = datard.GetOrdinal("PrecioUnitarioActual");
						int posPrecioUnitarioAnterior = datard.GetOrdinal("PrecioUnitarioAnterior");
						int posFechaActualizacion = datard.GetOrdinal("FechaActualizacion");
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
				lbeHistotialPreciosBienServicio = new List<beHistotialPreciosBienServicio>();
				beHistotialPreciosBienServicio obeHistotialPreciosBienServicio;
				while (datard.Read())
				{
					 obeHistotialPreciosBienServicio = new beHistotialPreciosBienServicio();
					obeHistotialPreciosBienServicio.IdHistorialPrecioBienServicio =  datard.GetInt32(posIdHistorialPrecioBienServicio);
					obeHistotialPreciosBienServicio.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obeHistotialPreciosBienServicio.PrecioUnitarioActual =  datard.GetDecimal(posPrecioUnitarioActual);
					obeHistotialPreciosBienServicio.PrecioUnitarioAnterior =  datard.GetDecimal(posPrecioUnitarioAnterior);
					obeHistotialPreciosBienServicio.FechaActualizacion =  datard.GetDateTime(posFechaActualizacion);
					obeHistotialPreciosBienServicio.IdDatoEstudioMercado =  datard.GetInt32(posIdDatoEstudioMercado);
			// debe agregar campos de la Vista
					lbeHistotialPreciosBienServicio.Add(obeHistotialPreciosBienServicio);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeHistotialPreciosBienServicio;
		}
	}
}
}
