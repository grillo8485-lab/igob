using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daCondicionesPedidos
 {
	public int guardarCondicionesPedidos(SqlConnection Conexion, beCondicionesPedidos obeCondicionesPedidos)
	{
		int Id=0;
		string sp = "Proc_CondicionesPedidosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCondicionPedido", SqlDbType.Int).Value = obeCondicionesPedidos.IdCondicionPedido;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeCondicionesPedidos.IdGobierno;
				cmd.Parameters.Add("@Consecutivo", SqlDbType.Int).Value = obeCondicionesPedidos.Consecutivo;
				cmd.Parameters.Add("@CondicionPedido", SqlDbType.NVarChar).Value = obeCondicionesPedidos.CondicionPedido;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeCondicionesPedidos.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarCondicionesPedidos(SqlConnection Conexion, beCondicionesPedidos obeCondicionesPedidos)
	{
		string sp = "Proc_CondicionesPedidosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCondicionPedido", SqlDbType.Int).Value = obeCondicionesPedidos.IdCondicionPedido;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeCondicionesPedidos.IdGobierno;
				cmd.Parameters.Add("@Consecutivo", SqlDbType.Int).Value = obeCondicionesPedidos.Consecutivo;
				cmd.Parameters.Add("@CondicionPedido", SqlDbType.NVarChar).Value = obeCondicionesPedidos.CondicionPedido;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeCondicionesPedidos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarCondicionesPedidos(SqlConnection Conexion,int pIdCondicionPedido)
	{
		string sp = "Proc_CondicionesPedidosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCondicionPedido", SqlDbType.Int).Value = pIdCondicionPedido;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beCondicionesPedidos traerCondicionesPedidos_x_IdCondicionPedido(SqlConnection Conexion,int IdCondicionPedido)
	{
		string sp = "Proc_CondicionesPedidos_x_IdCondicionPedido";
		List<beCondicionesPedidos> lbeCondicionesPedidos = null;
				beCondicionesPedidos obeCondicionesPedidos=new beCondicionesPedidos();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdCondicionPedido", SqlDbType.Int).Value = IdCondicionPedido;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeCondicionesPedidos = new List<beCondicionesPedidos>();
						int posIdCondicionPedido = datard.GetOrdinal("IdCondicionPedido");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posConsecutivo = datard.GetOrdinal("Consecutivo");
						int posCondicionPedido = datard.GetOrdinal("CondicionPedido");
						int posActivo = datard.GetOrdinal("Activo");
				while (datard.Read())
					{
					 obeCondicionesPedidos = new beCondicionesPedidos();
						obeCondicionesPedidos.IdCondicionPedido =  datard.GetInt32(posIdCondicionPedido);
						obeCondicionesPedidos.IdGobierno =  datard.GetInt32(posIdGobierno);
						obeCondicionesPedidos.Consecutivo =  datard.GetInt32(posConsecutivo);
						obeCondicionesPedidos.CondicionPedido =  datard.GetString(posCondicionPedido);
						obeCondicionesPedidos.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeCondicionesPedidos;
			}
	}
	public List< beCondicionesPedidos> listarTodos_CondicionesPedidos(SqlConnection Conexion)
	 {
		string sp = "Proc_CondicionesPedidos_Traer_Todos";
		List<beCondicionesPedidos> lbeCondicionesPedidos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdCondicionPedido = datard.GetOrdinal("IdCondicionPedido");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posConsecutivo = datard.GetOrdinal("Consecutivo");
						int posCondicionPedido = datard.GetOrdinal("CondicionPedido");
						int posActivo = datard.GetOrdinal("Activo");
				lbeCondicionesPedidos = new List<beCondicionesPedidos>();
				beCondicionesPedidos obeCondicionesPedidos;
				while (datard.Read())
				{
					 obeCondicionesPedidos = new beCondicionesPedidos();
					obeCondicionesPedidos.IdCondicionPedido =  datard.GetInt32(posIdCondicionPedido);
					obeCondicionesPedidos.IdGobierno =  datard.GetInt32(posIdGobierno);
					obeCondicionesPedidos.Consecutivo =  datard.GetInt32(posConsecutivo);
					obeCondicionesPedidos.CondicionPedido =  datard.GetString(posCondicionPedido);
					obeCondicionesPedidos.Activo =  datard.GetBoolean(posActivo);
					lbeCondicionesPedidos.Add(obeCondicionesPedidos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeCondicionesPedidos;
		}
	}
	public List< beCondicionesPedidos> listar_CondicionesPedidos_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_CondicionesPedidos_TraerTodos_GetAll";
		List<beCondicionesPedidos> lbeCondicionesPedidos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdCondicionPedido = datard.GetOrdinal("IdCondicionPedido");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posConsecutivo = datard.GetOrdinal("Consecutivo");
						int posCondicionPedido = datard.GetOrdinal("CondicionPedido");
						int posActivo = datard.GetOrdinal("Activo");

                        /* Gobierno 24/08/2018 */
                        int posGobierno = datard.GetOrdinal("Gobierno");
				lbeCondicionesPedidos = new List<beCondicionesPedidos>();
				beCondicionesPedidos obeCondicionesPedidos;
				while (datard.Read())
				{
					 obeCondicionesPedidos = new beCondicionesPedidos();
					obeCondicionesPedidos.IdCondicionPedido =  datard.GetInt32(posIdCondicionPedido);
					obeCondicionesPedidos.IdGobierno =  datard.GetInt32(posIdGobierno);
					obeCondicionesPedidos.Consecutivo =  datard.GetInt32(posConsecutivo);
					obeCondicionesPedidos.CondicionPedido =  datard.GetString(posCondicionPedido);
					obeCondicionesPedidos.Activo =  datard.GetBoolean(posActivo);
                    
                    /* Gobierno 24/08/2018 */
                    obeCondicionesPedidos.Gobierno =  datard.GetString(posGobierno);
			// debe agregar campos de la Vista
					lbeCondicionesPedidos.Add(obeCondicionesPedidos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeCondicionesPedidos;
		}
	}
}
}
