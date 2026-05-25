using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daPeriodicidad
 {
	public int guardarPeriodicidad(SqlConnection Conexion, bePeriodicidad obePeriodicidad)
	{
		int Id=0;
		string sp = "Proc_PeriodicidadInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPeriodicidad", SqlDbType.Int).Value = obePeriodicidad.IdPeriodicidad;
				cmd.Parameters.Add("@Periodicidad", SqlDbType.NVarChar).Value = obePeriodicidad.Periodicidad;
				cmd.Parameters.Add("@Dias", SqlDbType.Int).Value = obePeriodicidad.Dias;
				cmd.Parameters.Add("@Meses", SqlDbType.Int).Value = obePeriodicidad.Meses;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obePeriodicidad.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarPeriodicidad(SqlConnection Conexion, bePeriodicidad obePeriodicidad)
	{
		string sp = "Proc_PeriodicidadActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPeriodicidad", SqlDbType.Int).Value = obePeriodicidad.IdPeriodicidad;
				cmd.Parameters.Add("@Periodicidad", SqlDbType.NVarChar).Value = obePeriodicidad.Periodicidad;
				cmd.Parameters.Add("@Dias", SqlDbType.Int).Value = obePeriodicidad.Dias;
				cmd.Parameters.Add("@Meses", SqlDbType.Int).Value = obePeriodicidad.Meses;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obePeriodicidad.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarPeriodicidad(SqlConnection Conexion,int pIdPeriodicidad)
	{
		string sp = "Proc_PeriodicidadEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPeriodicidad", SqlDbType.Int).Value = pIdPeriodicidad;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public bePeriodicidad traerPeriodicidad_x_IdPeriodicidad(SqlConnection Conexion,int IdPeriodicidad)
	{
		string sp = "Proc_Periodicidad_x_IdPeriodicidad";
				bePeriodicidad obePeriodicidad=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPeriodicidad", SqlDbType.Int).Value = IdPeriodicidad;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdPeriodicidad = datard.GetOrdinal("IdPeriodicidad");
						int posPeriodicidad = datard.GetOrdinal("Periodicidad");
						int posDias = datard.GetOrdinal("Dias");
						int posMeses = datard.GetOrdinal("Meses");
						int posActivo = datard.GetOrdinal("Activo");
					 obePeriodicidad = new bePeriodicidad();
				while (datard.Read())
					{
						obePeriodicidad.IdPeriodicidad =  datard.GetInt32(posIdPeriodicidad);
						obePeriodicidad.Periodicidad =  datard.GetString(posPeriodicidad);
						obePeriodicidad.Dias =  datard.GetInt32(posDias);
						obePeriodicidad.Meses =  datard.GetInt32(posMeses);
						obePeriodicidad.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePeriodicidad;
			}
	}
	public List< bePeriodicidad> listarTodos_Periodicidad(SqlConnection Conexion)
	 {
		string sp = "Proc_Periodicidad_Traer_Todos";
		List<bePeriodicidad> lbePeriodicidad = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPeriodicidad = datard.GetOrdinal("IdPeriodicidad");
						int posPeriodicidad = datard.GetOrdinal("Periodicidad");
						int posDias = datard.GetOrdinal("Dias");
						int posMeses = datard.GetOrdinal("Meses");
						int posActivo = datard.GetOrdinal("Activo");
				lbePeriodicidad = new List<bePeriodicidad>();
				bePeriodicidad obePeriodicidad;
				while (datard.Read())
				{
					 obePeriodicidad = new bePeriodicidad();
					obePeriodicidad.IdPeriodicidad =  datard.GetInt32(posIdPeriodicidad);
					obePeriodicidad.Periodicidad =  datard.GetString(posPeriodicidad);
					obePeriodicidad.Dias =  datard.GetInt32(posDias);
					obePeriodicidad.Meses =  datard.GetInt32(posMeses);
					obePeriodicidad.Activo =  datard.GetBoolean(posActivo);
					lbePeriodicidad.Add(obePeriodicidad);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePeriodicidad;
		}
	}
	public List< bePeriodicidad> listar_Periodicidad_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_Periodicidad_TraerTodos_GetAll";
		List<bePeriodicidad> lbePeriodicidad = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPeriodicidad = datard.GetOrdinal("IdPeriodicidad");
						int posPeriodicidad = datard.GetOrdinal("Periodicidad");
						int posDias = datard.GetOrdinal("Dias");
						int posMeses = datard.GetOrdinal("Meses");
						int posActivo = datard.GetOrdinal("Activo");
				lbePeriodicidad = new List<bePeriodicidad>();
				bePeriodicidad obePeriodicidad;
				while (datard.Read())
				{
					 obePeriodicidad = new bePeriodicidad();
					obePeriodicidad.IdPeriodicidad =  datard.GetInt32(posIdPeriodicidad);
					obePeriodicidad.Periodicidad =  datard.GetString(posPeriodicidad);
					obePeriodicidad.Dias =  datard.GetInt32(posDias);
					obePeriodicidad.Meses =  datard.GetInt32(posMeses);
					obePeriodicidad.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbePeriodicidad.Add(obePeriodicidad);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePeriodicidad;
		}
	}
}
}
