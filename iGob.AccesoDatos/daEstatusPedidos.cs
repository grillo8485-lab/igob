using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daEstatusPedidos
 {
	public int guardarEstatusPedidos(SqlConnection Conexion, beEstatusPedidos obeEstatusPedidos)
	{
		int Id=0;
		string sp = "Proc_EstatusPedidosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPedido", SqlDbType.Int).Value = obeEstatusPedidos.IdEstatusPedido;
				cmd.Parameters.Add("@Estatus", SqlDbType.NChar).Value = obeEstatusPedidos.Estatus;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEstatusPedidos.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarEstatusPedidos(SqlConnection Conexion, beEstatusPedidos obeEstatusPedidos)
	{
		string sp = "Proc_EstatusPedidosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPedido", SqlDbType.Int).Value = obeEstatusPedidos.IdEstatusPedido;
				cmd.Parameters.Add("@Estatus", SqlDbType.NChar).Value = obeEstatusPedidos.Estatus;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEstatusPedidos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarEstatusPedidos(SqlConnection Conexion,int pIdEstatusPedido)
	{
		string sp = "Proc_EstatusPedidosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPedido", SqlDbType.Int).Value = pIdEstatusPedido;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beEstatusPedidos traerEstatusPedidos_x_IdEstatusPedido(SqlConnection Conexion,int IdEstatusPedido)
	{
		string sp = "Proc_EstatusPedidos_x_IdEstatusPedido";
				beEstatusPedidos obeEstatusPedidos=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdEstatusPedido", SqlDbType.Int).Value = IdEstatusPedido;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
					 obeEstatusPedidos = new beEstatusPedidos();
				while (datard.Read())
					{
						obeEstatusPedidos.IdEstatusPedido =  datard.GetInt32(posIdEstatusPedido);
						obeEstatusPedidos.Estatus =  datard.GetString(posEstatus);
						obeEstatusPedidos.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEstatusPedidos;
			}
	}
	public List< beEstatusPedidos> listarTodos_EstatusPedidos(SqlConnection Conexion)
	 {
		string sp = "Proc_EstatusPedidos_Traer_Todos";
		List<beEstatusPedidos> lbeEstatusPedidos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
				lbeEstatusPedidos = new List<beEstatusPedidos>();
				beEstatusPedidos obeEstatusPedidos;
				while (datard.Read())
				{
					 obeEstatusPedidos = new beEstatusPedidos();
					obeEstatusPedidos.IdEstatusPedido =  datard.GetInt32(posIdEstatusPedido);
					obeEstatusPedidos.Estatus =  datard.GetString(posEstatus);
					obeEstatusPedidos.Activo =  datard.GetBoolean(posActivo);
					lbeEstatusPedidos.Add(obeEstatusPedidos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPedidos;
		}
	}
	public List< beEstatusPedidos> listar_EstatusPedidos_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_EstatusPedidos_TraerTodos_GetAll";
		List<beEstatusPedidos> lbeEstatusPedidos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
				lbeEstatusPedidos = new List<beEstatusPedidos>();
				beEstatusPedidos obeEstatusPedidos;
				while (datard.Read())
				{
					 obeEstatusPedidos = new beEstatusPedidos();
					obeEstatusPedidos.IdEstatusPedido =  datard.GetInt32(posIdEstatusPedido);
					obeEstatusPedidos.Estatus =  datard.GetString(posEstatus);
					obeEstatusPedidos.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeEstatusPedidos.Add(obeEstatusPedidos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPedidos;
		}
	}
}
}
