using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposCartas
 {
	public int guardarTiposCartas(SqlConnection Conexion, beTiposCartas obeTiposCartas)
	{
		int Id=0;
		string sp = "Proc_TiposCartasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoCarta", SqlDbType.Int).Value = obeTiposCartas.IdTipoCarta;
				cmd.Parameters.Add("@TipoCarta", SqlDbType.NChar).Value = obeTiposCartas.TipoCarta;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposCartas.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposCartas(SqlConnection Conexion, beTiposCartas obeTiposCartas)
	{
		string sp = "Proc_TiposCartasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoCarta", SqlDbType.Int).Value = obeTiposCartas.IdTipoCarta;
				cmd.Parameters.Add("@TipoCarta", SqlDbType.NChar).Value = obeTiposCartas.TipoCarta;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposCartas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposCartas(SqlConnection Conexion,int pIdTipoCarta)
	{
		string sp = "Proc_TiposCartasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoCarta", SqlDbType.Int).Value = pIdTipoCarta;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposCartas traerTiposCartas_x_IdTipoCarta(SqlConnection Conexion,int IdTipoCarta)
	{
		string sp = "Proc_TiposCartas_x_IdTipoCarta";
		List<beTiposCartas> lbeTiposCartas = null;
				beTiposCartas obeTiposCartas=new beTiposCartas();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoCarta", SqlDbType.Int).Value = IdTipoCarta;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeTiposCartas = new List<beTiposCartas>();
				while (datard.Read())
					{
					 obeTiposCartas = new beTiposCartas();
						obeTiposCartas.IdTipoCarta =  datard.GetInt32(0);
						obeTiposCartas.TipoCarta =  datard.GetString(1);
						obeTiposCartas.Activo =  datard.GetBoolean(2);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposCartas;
			}
	}
	public List< beTiposCartas> listarTodos_TiposCartas(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposCartas_Traer_Todos";
		List<beTiposCartas> lbeTiposCartas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeTiposCartas = new List<beTiposCartas>();
				beTiposCartas obeTiposCartas;
				while (datard.Read())
				{
					 obeTiposCartas = new beTiposCartas();
					obeTiposCartas.IdTipoCarta =  datard.GetInt32(0);
					obeTiposCartas.TipoCarta =  datard.GetString(1);
					obeTiposCartas.Activo =  datard.GetBoolean(2);
					lbeTiposCartas.Add(obeTiposCartas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposCartas;
		}
	}
	public DataTable listarTiposCartas_x_(SqlConnection Conexion,int IdTipoCarta)
	 {
		string sp = "Proc_TiposCartas_Traer_Todos";
		DataTable dtTiposCartas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoCarta", SqlDbType.Int).Value = IdTipoCarta;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtTiposCartas = new DataTable();
				dtTiposCartas.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtTiposCartas;
		}
	}
}
}
