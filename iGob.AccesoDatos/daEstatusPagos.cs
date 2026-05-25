using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daEstatusPagos
 {
	public int guardarEstatusPagos(SqlConnection Conexion, beEstatusPagos obeEstatusPagos)
	{
		int Id=0;
		string sp = "Proc_EstatusPagosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPago", SqlDbType.Int).Value = obeEstatusPagos.IdEstatusPago;
				cmd.Parameters.Add("@Estatus", SqlDbType.NVarChar).Value = obeEstatusPagos.Estatus;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEstatusPagos.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarEstatusPagos(SqlConnection Conexion, beEstatusPagos obeEstatusPagos)
	{
		string sp = "Proc_EstatusPagosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPago", SqlDbType.Int).Value = obeEstatusPagos.IdEstatusPago;
				cmd.Parameters.Add("@Estatus", SqlDbType.NVarChar).Value = obeEstatusPagos.Estatus;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEstatusPagos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarEstatusPagos(SqlConnection Conexion,int pIdEstatusPago)
	{
		string sp = "Proc_EstatusPagosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPago", SqlDbType.Int).Value = pIdEstatusPago;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beEstatusPagos traerEstatusPagos_x_IdEstatusPago(SqlConnection Conexion,int IdEstatusPago)
	{
		string sp = "Proc_EstatusPagos_x_IdEstatusPago";
				beEstatusPagos obeEstatusPagos=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdEstatusPago", SqlDbType.Int).Value = IdEstatusPago;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdEstatusPago = datard.GetOrdinal("IdEstatusPago");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
					 obeEstatusPagos = new beEstatusPagos();
				while (datard.Read())
					{
						obeEstatusPagos.IdEstatusPago =  datard.GetInt32(posIdEstatusPago);
						obeEstatusPagos.Estatus =  datard.GetString(posEstatus);
						obeEstatusPagos.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEstatusPagos;
			}
	}
	public List< beEstatusPagos> listarTodos_EstatusPagos(SqlConnection Conexion)
	 {
		string sp = "Proc_EstatusPagos_Traer_Todos";
		List<beEstatusPagos> lbeEstatusPagos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdEstatusPago = datard.GetOrdinal("IdEstatusPago");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
				lbeEstatusPagos = new List<beEstatusPagos>();
				beEstatusPagos obeEstatusPagos;
				while (datard.Read())
				{
					 obeEstatusPagos = new beEstatusPagos();
					obeEstatusPagos.IdEstatusPago =  datard.GetInt32(posIdEstatusPago);
					obeEstatusPagos.Estatus =  datard.GetString(posEstatus);
					obeEstatusPagos.Activo =  datard.GetBoolean(posActivo);
					lbeEstatusPagos.Add(obeEstatusPagos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPagos;
		}
	}
	public List< beEstatusPagos> listar_EstatusPagos_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_EstatusPagos_TraerTodos_GetAll";
		List<beEstatusPagos> lbeEstatusPagos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdEstatusPago = datard.GetOrdinal("IdEstatusPago");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
				lbeEstatusPagos = new List<beEstatusPagos>();
				beEstatusPagos obeEstatusPagos;
				while (datard.Read())
				{
					 obeEstatusPagos = new beEstatusPagos();
					obeEstatusPagos.IdEstatusPago =  datard.GetInt32(posIdEstatusPago);
					obeEstatusPagos.Estatus =  datard.GetString(posEstatus);
					obeEstatusPagos.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeEstatusPagos.Add(obeEstatusPagos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPagos;
		}
	}
}
}
