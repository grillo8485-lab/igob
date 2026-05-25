using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daMeses
 {
	public int guardarMeses(SqlConnection Conexion, beMeses obeMeses)
	{
		int Id=0;
		string sp = "Proc_MesesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdMes", SqlDbType.Int).Value = obeMeses.IdMes;
				cmd.Parameters.Add("@Mes", SqlDbType.NChar).Value = obeMeses.Mes;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarMeses(SqlConnection Conexion, beMeses obeMeses)
	{
		string sp = "Proc_MesesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdMes", SqlDbType.Int).Value = obeMeses.IdMes;
				cmd.Parameters.Add("@Mes", SqlDbType.NChar).Value = obeMeses.Mes;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarMeses(SqlConnection Conexion,int pIdMes)
	{
		string sp = "Proc_MesesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdMes", SqlDbType.Int).Value = pIdMes;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beMeses traerMeses_x_IdMes(SqlConnection Conexion,int IdMes)
	{
		string sp = "Proc_Meses_x_IdMes";
		List<beMeses> lbeMeses = null;
				beMeses obeMeses=new beMeses();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdMes", SqlDbType.Int).Value = IdMes;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeMeses = new List<beMeses>();
				while (datard.Read())
					{
					 obeMeses = new beMeses();
						obeMeses.IdMes =  datard.GetInt32(0);
						obeMeses.Mes =  datard.GetString(1);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeMeses;
			}
	}
	public List< beMeses> listarTodos_Meses(SqlConnection Conexion)
	 {
		string sp = "Proc_Meses_Traer_Todos";
		List<beMeses> lbeMeses = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeMeses = new List<beMeses>();
				beMeses obeMeses;
				while (datard.Read())
				{
					 obeMeses = new beMeses();
					obeMeses.IdMes =  datard.GetInt32(0);
					obeMeses.Mes =  datard.GetString(1);
					lbeMeses.Add(obeMeses);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeMeses;
		}
	}
	public DataTable listarMeses_x_(SqlConnection Conexion,int IdMes)
	 {
		string sp = "Proc_Meses_Traer_Todos";
		DataTable dtMeses = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdMes", SqlDbType.Int).Value = IdMes;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtMeses = new DataTable();
				dtMeses.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtMeses;
		}
	}
}
}
