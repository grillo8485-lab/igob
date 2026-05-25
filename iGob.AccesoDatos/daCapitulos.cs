using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daCapitulos
 {
	public int guardarCapitulos(SqlConnection Conexion, beCapitulos obeCapitulos)
	{
		int Id=0;
		string sp = "Proc_CapitulosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCapitulo", SqlDbType.Int).Value = obeCapitulos.IdCapitulo;
				cmd.Parameters.Add("@ClaveCapitulo", SqlDbType.Int).Value = obeCapitulos.ClaveCapitulo;
				cmd.Parameters.Add("@Capitulo", SqlDbType.VarChar).Value = obeCapitulos.Capitulo;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeCapitulos.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarCapitulos(SqlConnection Conexion, beCapitulos obeCapitulos)
	{
		string sp = "Proc_CapitulosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCapitulo", SqlDbType.Int).Value = obeCapitulos.IdCapitulo;
				cmd.Parameters.Add("@ClaveCapitulo", SqlDbType.Int).Value = obeCapitulos.ClaveCapitulo;
				cmd.Parameters.Add("@Capitulo", SqlDbType.VarChar).Value = obeCapitulos.Capitulo;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeCapitulos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarCapitulos(SqlConnection Conexion,int pIdCapitulo)
	{
		string sp = "Proc_CapitulosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCapitulo", SqlDbType.Int).Value = pIdCapitulo;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beCapitulos traerCapitulos_x_IdCapitulo(SqlConnection Conexion,int IdCapitulo)
	{
		string sp = "Proc_Capitulos_x_IdCapitulo";
		List<beCapitulos> lbeCapitulos = null;
				beCapitulos obeCapitulos=new beCapitulos();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdCapitulo", SqlDbType.Int).Value = IdCapitulo;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeCapitulos = new List<beCapitulos>();
				while (datard.Read())
					{
					 obeCapitulos = new beCapitulos();
						obeCapitulos.IdCapitulo =  datard.GetInt32(0);
						obeCapitulos.ClaveCapitulo =  datard.GetInt32(1);
						obeCapitulos.Capitulo =  datard.GetString(2);
						obeCapitulos.Activo =  datard.GetBoolean(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeCapitulos;
			}
	}
	public List< beCapitulos> listarTodos_Capitulos(SqlConnection Conexion)
	 {
		string sp = "Proc_Capitulos_Traer_Todos";
		List<beCapitulos> lbeCapitulos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeCapitulos = new List<beCapitulos>();
				beCapitulos obeCapitulos;
				while (datard.Read())
				{
					 obeCapitulos = new beCapitulos();
					obeCapitulos.IdCapitulo =  datard.GetInt32(0);
					obeCapitulos.ClaveCapitulo =  datard.GetInt32(1);
					obeCapitulos.Capitulo =  datard.GetString(2);
					obeCapitulos.Activo =  datard.GetBoolean(3);
					lbeCapitulos.Add(obeCapitulos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeCapitulos;
		}
	}
	public DataTable listarCapitulos_x_(SqlConnection Conexion,int IdCapitulo)
	 {
		string sp = "Proc_Capitulos_Traer_Todos";
		DataTable dtCapitulos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdCapitulo", SqlDbType.Int).Value = IdCapitulo;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtCapitulos = new DataTable();
				dtCapitulos.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtCapitulos;
		}
	}
}
}
