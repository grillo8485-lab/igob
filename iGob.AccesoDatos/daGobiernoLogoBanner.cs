using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daGobiernoLogoBanner
 {
	public int guardarGobiernoLogoBanner(SqlConnection Conexion, beGobiernoLogoBanner obeGobiernoLogoBanner)
	{
		int Id=0;
		string sp = "Proc_GobiernoLogoBannerInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLogoBanner", SqlDbType.Int).Value = obeGobiernoLogoBanner.IdLogoBanner;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeGobiernoLogoBanner.IdGobierno;
				cmd.Parameters.Add("@Logo", SqlDbType.Text).Value = obeGobiernoLogoBanner.Logo;
				cmd.Parameters.Add("@Banner", SqlDbType.Text).Value = obeGobiernoLogoBanner.Banner;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarGobiernoLogoBanner(SqlConnection Conexion, beGobiernoLogoBanner obeGobiernoLogoBanner)
	{
		string sp = "Proc_GobiernoLogoBannerActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLogoBanner", SqlDbType.Int).Value = obeGobiernoLogoBanner.IdLogoBanner;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeGobiernoLogoBanner.IdGobierno;
				cmd.Parameters.Add("@Logo", SqlDbType.Text).Value = obeGobiernoLogoBanner.Logo;
				cmd.Parameters.Add("@Banner", SqlDbType.Text).Value = obeGobiernoLogoBanner.Banner;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarGobiernoLogoBanner(SqlConnection Conexion,int pIdLogoBanner)
	{
		string sp = "Proc_GobiernoLogoBannerEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLogoBanner", SqlDbType.Int).Value = pIdLogoBanner;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beGobiernoLogoBanner traerGobiernoLogoBanner_x_IdLogoBanner(SqlConnection Conexion,int IdLogoBanner)
	{
		string sp = "Proc_GobiernoLogoBanner_x_IdLogoBanner";
				beGobiernoLogoBanner obeGobiernoLogoBanner=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdLogoBanner", SqlDbType.Int).Value = IdLogoBanner;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdLogoBanner = datard.GetOrdinal("IdLogoBanner");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posLogo = datard.GetOrdinal("Logo");
						int posBanner = datard.GetOrdinal("Banner");
					 obeGobiernoLogoBanner = new beGobiernoLogoBanner();
				while (datard.Read())
					{
						obeGobiernoLogoBanner.IdLogoBanner =  datard.GetInt32(posIdLogoBanner);
						obeGobiernoLogoBanner.IdGobierno =  datard.GetInt32(posIdGobierno);
						obeGobiernoLogoBanner.Logo =  datard.GetString(posLogo);
						obeGobiernoLogoBanner.Banner =  datard.GetString(posBanner);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeGobiernoLogoBanner;
			}
	}
	public List< beGobiernoLogoBanner> listarTodos_GobiernoLogoBanner(SqlConnection Conexion)
	 {
		string sp = "Proc_GobiernoLogoBanner_Traer_Todos";
		List<beGobiernoLogoBanner> lbeGobiernoLogoBanner = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdLogoBanner = datard.GetOrdinal("IdLogoBanner");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posLogo = datard.GetOrdinal("Logo");
						int posBanner = datard.GetOrdinal("Banner");
				lbeGobiernoLogoBanner = new List<beGobiernoLogoBanner>();
				beGobiernoLogoBanner obeGobiernoLogoBanner;
				while (datard.Read())
				{
					 obeGobiernoLogoBanner = new beGobiernoLogoBanner();
					obeGobiernoLogoBanner.IdLogoBanner =  datard.GetInt32(posIdLogoBanner);
					obeGobiernoLogoBanner.IdGobierno =  datard.GetInt32(posIdGobierno);
					obeGobiernoLogoBanner.Logo =  datard.GetString(posLogo);
					obeGobiernoLogoBanner.Banner =  datard.GetString(posBanner);
					lbeGobiernoLogoBanner.Add(obeGobiernoLogoBanner);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeGobiernoLogoBanner;
		}
	}
	public List< beGobiernoLogoBanner> listar_GobiernoLogoBanner_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_GobiernoLogoBanner_TraerTodos_GetAll";
		List<beGobiernoLogoBanner> lbeGobiernoLogoBanner = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdLogoBanner = datard.GetOrdinal("IdLogoBanner");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posLogo = datard.GetOrdinal("Logo");
						int posBanner = datard.GetOrdinal("Banner");
				lbeGobiernoLogoBanner = new List<beGobiernoLogoBanner>();
				beGobiernoLogoBanner obeGobiernoLogoBanner;
				while (datard.Read())
				{
					 obeGobiernoLogoBanner = new beGobiernoLogoBanner();
					obeGobiernoLogoBanner.IdLogoBanner =  datard.GetInt32(posIdLogoBanner);
					obeGobiernoLogoBanner.IdGobierno =  datard.GetInt32(posIdGobierno);
					obeGobiernoLogoBanner.Logo =  datard.GetString(posLogo);
					obeGobiernoLogoBanner.Banner =  datard.GetString(posBanner);
			// debe agregar campos de la Vista
					lbeGobiernoLogoBanner.Add(obeGobiernoLogoBanner);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeGobiernoLogoBanner;
		}
	}
}
}
