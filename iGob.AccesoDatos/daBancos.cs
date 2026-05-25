using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daBancos
 {
	public int guardarBancos(SqlConnection Conexion, beBancos obeBancos)
	{
		int Id=0;
		string sp = "Proc_BancosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdBanco", SqlDbType.Int).Value = obeBancos.IdBanco;
				cmd.Parameters.Add("@Clave", SqlDbType.NChar).Value = obeBancos.Clave;
				cmd.Parameters.Add("@NombreCorto", SqlDbType.NVarChar).Value = obeBancos.NombreCorto;
				cmd.Parameters.Add("@NombreRazonSocial", SqlDbType.NVarChar).Value = obeBancos.NombreRazonSocial;
				cmd.Parameters.Add("@RFC", SqlDbType.NVarChar).Value = obeBancos.RFC;
				cmd.Parameters.Add("@Estatus", SqlDbType.NChar).Value = obeBancos.Estatus;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeBancos.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarBancos(SqlConnection Conexion, beBancos obeBancos)
	{
		string sp = "Proc_BancosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdBanco", SqlDbType.Int).Value = obeBancos.IdBanco;
				cmd.Parameters.Add("@Clave", SqlDbType.NChar).Value = obeBancos.Clave;
				cmd.Parameters.Add("@NombreCorto", SqlDbType.NVarChar).Value = obeBancos.NombreCorto;
				cmd.Parameters.Add("@NombreRazonSocial", SqlDbType.NVarChar).Value = obeBancos.NombreRazonSocial;
				cmd.Parameters.Add("@RFC", SqlDbType.NVarChar).Value = obeBancos.RFC;
				cmd.Parameters.Add("@Estatus", SqlDbType.NChar).Value = obeBancos.Estatus;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeBancos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarBancos(SqlConnection Conexion,int pIdBanco)
	{
		string sp = "Proc_BancosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdBanco", SqlDbType.Int).Value = pIdBanco;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beBancos traerBancos_x_IdBanco(SqlConnection Conexion,int IdBanco)
	{
		string sp = "Proc_Bancos_x_IdBanco";
		List<beBancos> lbeBancos = null;
				beBancos obeBancos=new beBancos();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdBanco", SqlDbType.Int).Value = IdBanco;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeBancos = new List<beBancos>();
				while (datard.Read())
					{
					 obeBancos = new beBancos();
						obeBancos.IdBanco =  datard.GetInt32(0);
						obeBancos.Clave =  datard.GetString(1);
						obeBancos.NombreCorto =  datard.GetString(2);
						obeBancos.NombreRazonSocial =  datard.GetString(3);
						obeBancos.RFC =  datard.GetString(4);
						obeBancos.Estatus =  datard.GetString(5);
						obeBancos.Activo =  datard.GetBoolean(6);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeBancos;
			}
	}
	public List< beBancos> listarTodos_Bancos(SqlConnection Conexion)
	 {
		string sp = "Proc_Bancos_Traer_Todos";
		List<beBancos> lbeBancos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeBancos = new List<beBancos>();
				beBancos obeBancos;
				while (datard.Read())
				{
					 obeBancos = new beBancos();
					obeBancos.IdBanco =  datard.GetInt32(0);
					obeBancos.Clave =  datard.GetString(1);
					obeBancos.NombreCorto =  datard.GetString(2);
					obeBancos.NombreRazonSocial =  datard.GetString(3);
					obeBancos.RFC =  datard.GetString(4);
					obeBancos.Estatus =  datard.GetString(5);
					obeBancos.Activo =  datard.GetBoolean(6);
					lbeBancos.Add(obeBancos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeBancos;
		}
	}
	public DataTable listarBancos_x_(SqlConnection Conexion,int IdBanco)
	 {
		string sp = "Proc_Bancos_Traer_Todos";
		DataTable dtBancos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdBanco", SqlDbType.Int).Value = IdBanco;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtBancos = new DataTable();
				dtBancos.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtBancos;
		}
	}
}
}
