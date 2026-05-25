using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daFrecuencias
 {
	public int guardarFrecuencias(SqlConnection Conexion, beFrecuencias obeFrecuencias)
	{
		int Id=0;
		string sp = "Proc_FrecuenciasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFrecuencia", SqlDbType.Int).Value = obeFrecuencias.IdFrecuencia;
				cmd.Parameters.Add("@Frecuencia", SqlDbType.NVarChar).Value = obeFrecuencias.Frecuencia;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeFrecuencias.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarFrecuencias(SqlConnection Conexion, beFrecuencias obeFrecuencias)
	{
		string sp = "Proc_FrecuenciasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFrecuencia", SqlDbType.Int).Value = obeFrecuencias.IdFrecuencia;
				cmd.Parameters.Add("@Frecuencia", SqlDbType.NVarChar).Value = obeFrecuencias.Frecuencia;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeFrecuencias.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarFrecuencias(SqlConnection Conexion,int pIdFrecuencia)
	{
		string sp = "Proc_FrecuenciasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFrecuencia", SqlDbType.Int).Value = pIdFrecuencia;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beFrecuencias traerFrecuencias_x_IdFrecuencia(SqlConnection Conexion,int IdFrecuencia)
	{
		string sp = "Proc_Frecuencias_x_IdFrecuencia";
		List<beFrecuencias> lbeFrecuencias = null;
				beFrecuencias obeFrecuencias=new beFrecuencias();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdFrecuencia", SqlDbType.Int).Value = IdFrecuencia;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeFrecuencias = new List<beFrecuencias>();
				while (datard.Read())
					{
					 obeFrecuencias = new beFrecuencias();
						obeFrecuencias.IdFrecuencia =  datard.GetInt32(0);
						obeFrecuencias.Frecuencia =  datard.GetString(1);
						obeFrecuencias.Activo =  datard.GetBoolean(2);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeFrecuencias;
			}
	}
	public List< beFrecuencias> listarTodos_Frecuencias(SqlConnection Conexion)
	 {
		string sp = "Proc_Frecuencias_Traer_Todos";
		List<beFrecuencias> lbeFrecuencias = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeFrecuencias = new List<beFrecuencias>();
				beFrecuencias obeFrecuencias;
				while (datard.Read())
				{
					 obeFrecuencias = new beFrecuencias();
					obeFrecuencias.IdFrecuencia =  datard.GetInt32(0);
					obeFrecuencias.Frecuencia =  datard.GetString(1);
					obeFrecuencias.Activo =  datard.GetBoolean(2);
					lbeFrecuencias.Add(obeFrecuencias);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeFrecuencias;
		}
	}
	public DataTable listarFrecuencias_x_(SqlConnection Conexion,int IdFrecuencia)
	 {
		string sp = "Proc_Frecuencias_Traer_Todos";
		DataTable dtFrecuencias = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdFrecuencia", SqlDbType.Int).Value = IdFrecuencia;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtFrecuencias = new DataTable();
				dtFrecuencias.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtFrecuencias;
		}
	}
}
}
