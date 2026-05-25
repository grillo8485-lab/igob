using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daMuestras
 {
	public int guardarMuestras(SqlConnection Conexion, beMuestras obeMuestras)
	{
		int Id=0;
		string sp = "Proc_MuestrasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdMuestra", SqlDbType.Int).Value = obeMuestras.IdMuestra;
				cmd.Parameters.Add("@Muestra", SqlDbType.NChar).Value = obeMuestras.Muestra;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeMuestras.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarMuestras(SqlConnection Conexion, beMuestras obeMuestras)
	{
		string sp = "Proc_MuestrasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdMuestra", SqlDbType.Int).Value = obeMuestras.IdMuestra;
				cmd.Parameters.Add("@Muestra", SqlDbType.NChar).Value = obeMuestras.Muestra;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeMuestras.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarMuestras(SqlConnection Conexion,int pIdMuestra)
	{
		string sp = "Proc_MuestrasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdMuestra", SqlDbType.Int).Value = pIdMuestra;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beMuestras traerMuestras_x_IdMuestra(SqlConnection Conexion,int IdMuestra)
	{
		string sp = "Proc_Muestras_x_IdMuestra";
		List<beMuestras> lbeMuestras = null;
				beMuestras obeMuestras=new beMuestras();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdMuestra", SqlDbType.Int).Value = IdMuestra;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeMuestras = new List<beMuestras>();
				while (datard.Read())
					{
					 obeMuestras = new beMuestras();
						obeMuestras.IdMuestra =  datard.GetInt32(0);
						obeMuestras.Muestra =  datard.GetString(1);
						obeMuestras.Activo =  datard.GetBoolean(2);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeMuestras;
			}
	}
	public List< beMuestras> listarTodos_Muestras(SqlConnection Conexion)
	 {
		string sp = "Proc_Muestras_Traer_Todos";
		List<beMuestras> lbeMuestras = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeMuestras = new List<beMuestras>();
				beMuestras obeMuestras;
				while (datard.Read())
				{
					 obeMuestras = new beMuestras();
					obeMuestras.IdMuestra =  datard.GetInt32(0);
					obeMuestras.Muestra =  datard.GetString(1);
					obeMuestras.Activo =  datard.GetBoolean(2);
					lbeMuestras.Add(obeMuestras);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeMuestras;
		}
	}
	public DataTable listarMuestras_x_(SqlConnection Conexion,int IdMuestra)
	 {
		string sp = "Proc_Muestras_Traer_Todos";
		DataTable dtMuestras = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdMuestra", SqlDbType.Int).Value = IdMuestra;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtMuestras = new DataTable();
				dtMuestras.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtMuestras;
		}
	}
}
}
