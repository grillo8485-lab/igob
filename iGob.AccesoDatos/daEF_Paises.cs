using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daEF_Paises
 {
	public int guardarEF_Paises(SqlConnection Conexion, beEF_Paises obeEF_Paises)
	{
		int Id=0;
		string sp = "Proc_EF_PaisesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = obeEF_Paises.IdPais;
				cmd.Parameters.Add("@Pais", SqlDbType.VarChar).Value = obeEF_Paises.Pais;
				cmd.Parameters.Add("@AbreviacionPais", SqlDbType.Char).Value = obeEF_Paises.AbreviacionPais;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarEF_Paises(SqlConnection Conexion, beEF_Paises obeEF_Paises)
	{
		string sp = "Proc_EF_PaisesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = obeEF_Paises.IdPais;
				cmd.Parameters.Add("@Pais", SqlDbType.VarChar).Value = obeEF_Paises.Pais;
				cmd.Parameters.Add("@AbreviacionPais", SqlDbType.Char).Value = obeEF_Paises.AbreviacionPais;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarEF_Paises(SqlConnection Conexion,int pIdPais)
	{
		string sp = "Proc_EF_PaisesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = pIdPais;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beEF_Paises traerEF_Paises_x_IdPais(SqlConnection Conexion,int IdPais)
	{
		string sp = "Proc_EF_Paises_x_IdPais";
				beEF_Paises obeEF_Paises=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdPais = datard.GetOrdinal("IdPais");
						int posPais = datard.GetOrdinal("Pais");
						int posAbreviacionPais = datard.GetOrdinal("AbreviacionPais");
					 obeEF_Paises = new beEF_Paises();
				while (datard.Read())
					{
						obeEF_Paises.IdPais =  datard.GetInt32(posIdPais);
						obeEF_Paises.Pais =  datard.GetString(posPais);
						obeEF_Paises.AbreviacionPais =  datard.GetString(posAbreviacionPais);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEF_Paises;
			}
	}
	public List< beEF_Paises> listarTodos_EF_Paises(SqlConnection Conexion)
	 {
		string sp = "Proc_EF_Paises_Traer_Todos";
		List<beEF_Paises> lbeEF_Paises = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPais = datard.GetOrdinal("IdPais");
						int posPais = datard.GetOrdinal("Pais");
						int posAbreviacionPais = datard.GetOrdinal("AbreviacionPais");
				lbeEF_Paises = new List<beEF_Paises>();
				beEF_Paises obeEF_Paises;
				while (datard.Read())
				{
					 obeEF_Paises = new beEF_Paises();
					obeEF_Paises.IdPais =  datard.GetInt32(posIdPais);
					obeEF_Paises.Pais =  datard.GetString(posPais);
					obeEF_Paises.AbreviacionPais =  datard.GetString(posAbreviacionPais);
					lbeEF_Paises.Add(obeEF_Paises);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_Paises;
		}
	}
	public List< beEF_Paises> listar_EF_Paises_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_EF_Paises_TraerTodos_GetAll";
		List<beEF_Paises> lbeEF_Paises = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPais = datard.GetOrdinal("IdPais");
						int posPais = datard.GetOrdinal("Pais");
						int posAbreviacionPais = datard.GetOrdinal("AbreviacionPais");
				lbeEF_Paises = new List<beEF_Paises>();
				beEF_Paises obeEF_Paises;
				while (datard.Read())
				{
					 obeEF_Paises = new beEF_Paises();
					obeEF_Paises.IdPais =  datard.GetInt32(posIdPais);
					obeEF_Paises.Pais =  datard.GetString(posPais);
					obeEF_Paises.AbreviacionPais =  datard.GetString(posAbreviacionPais);
			// debe agregar campos de la Vista
					lbeEF_Paises.Add(obeEF_Paises);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_Paises;
		}
	}
}
}
