using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposCondicionesPagos
 {
	public int guardarTiposCondicionesPagos(SqlConnection Conexion, beTiposCondicionesPagos obeTiposCondicionesPagos)
	{
		int Id=0;
		string sp = "Proc_TiposCondicionesPagosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoCondicionPago", SqlDbType.Int).Value = obeTiposCondicionesPagos.IdTipoCondicionPago;
				cmd.Parameters.Add("@TipoCondicionPago", SqlDbType.NVarChar).Value = obeTiposCondicionesPagos.TipoCondicionPago;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposCondicionesPagos(SqlConnection Conexion, beTiposCondicionesPagos obeTiposCondicionesPagos)
	{
		string sp = "Proc_TiposCondicionesPagosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoCondicionPago", SqlDbType.Int).Value = obeTiposCondicionesPagos.IdTipoCondicionPago;
				cmd.Parameters.Add("@TipoCondicionPago", SqlDbType.NVarChar).Value = obeTiposCondicionesPagos.TipoCondicionPago;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposCondicionesPagos(SqlConnection Conexion,int pIdTipoCondicionPago)
	{
		string sp = "Proc_TiposCondicionesPagosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoCondicionPago", SqlDbType.Int).Value = pIdTipoCondicionPago;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposCondicionesPagos traerTiposCondicionesPagos_x_IdTipoCondicionPago(SqlConnection Conexion,int IdTipoCondicionPago)
	{
		string sp = "Proc_TiposCondicionesPagos_x_IdTipoCondicionPago";
		List<beTiposCondicionesPagos> lbeTiposCondicionesPagos = null;
				beTiposCondicionesPagos obeTiposCondicionesPagos=new beTiposCondicionesPagos();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoCondicionPago", SqlDbType.Int).Value = IdTipoCondicionPago;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeTiposCondicionesPagos = new List<beTiposCondicionesPagos>();
				while (datard.Read())
					{
					 obeTiposCondicionesPagos = new beTiposCondicionesPagos();
						obeTiposCondicionesPagos.IdTipoCondicionPago =  datard.GetInt32(0);
						obeTiposCondicionesPagos.TipoCondicionPago =  datard.GetString(1);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposCondicionesPagos;
			}
	}
	public List< beTiposCondicionesPagos> listarTodos_TiposCondicionesPagos(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposCondicionesPagos_Traer_Todos";
		List<beTiposCondicionesPagos> lbeTiposCondicionesPagos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeTiposCondicionesPagos = new List<beTiposCondicionesPagos>();
				beTiposCondicionesPagos obeTiposCondicionesPagos;
				while (datard.Read())
				{
					 obeTiposCondicionesPagos = new beTiposCondicionesPagos();
					obeTiposCondicionesPagos.IdTipoCondicionPago =  datard.GetInt32(0);
					obeTiposCondicionesPagos.TipoCondicionPago =  datard.GetString(1);
					lbeTiposCondicionesPagos.Add(obeTiposCondicionesPagos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposCondicionesPagos;
		}
	}
	public DataTable listarTiposCondicionesPagos_x_(SqlConnection Conexion,int IdTipoCondicionPago)
	 {
		string sp = "Proc_TiposCondicionesPagos_Traer_Todos";
		DataTable dtTiposCondicionesPagos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoCondicionPago", SqlDbType.Int).Value = IdTipoCondicionPago;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtTiposCondicionesPagos = new DataTable();
				dtTiposCondicionesPagos.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtTiposCondicionesPagos;
		}
	}
}
}
