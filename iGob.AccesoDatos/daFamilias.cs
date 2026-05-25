using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daFamilias
 {
	public int guardarFamilias(SqlConnection Conexion, beFamilias obeFamilias)
	{
		int Id=0;
		string sp = "Proc_FamiliasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = obeFamilias.IdFamilia;
				cmd.Parameters.Add("@Familia", SqlDbType.NVarChar).Value = obeFamilias.Familia;
				cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = obeFamilias.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeFamilias.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarFamilias(SqlConnection Conexion, beFamilias obeFamilias)
	{
		string sp = "Proc_FamiliasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = obeFamilias.IdFamilia;
				cmd.Parameters.Add("@Familia", SqlDbType.NVarChar).Value = obeFamilias.Familia;
				cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = obeFamilias.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeFamilias.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarFamilias(SqlConnection Conexion,int pIdFamilia)
	{
		string sp = "Proc_FamiliasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = pIdFamilia;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beFamilias traerFamilias_x_IdFamilia(SqlConnection Conexion,int IdFamilia)
	{
		string sp = "Proc_Familias_x_IdFamilia";
		List<beFamilias> lbeFamilias = null;
				beFamilias obeFamilias=new beFamilias();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = IdFamilia;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeFamilias = new List<beFamilias>();
				while (datard.Read())
					{
					 obeFamilias = new beFamilias();
						obeFamilias.IdFamilia =  datard.GetInt32(0);
						obeFamilias.Familia =  datard.GetString(1);
						obeFamilias.Descripcion =  datard.GetString(2);
						obeFamilias.Activo =  datard.GetBoolean(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeFamilias;
			}
	}
	public List< beFamilias> listarTodos_Familias(SqlConnection Conexion)
	 {
		string sp = "Proc_Familias_Traer_Todos";
		List<beFamilias> lbeFamilias = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeFamilias = new List<beFamilias>();
				beFamilias obeFamilias;
				while (datard.Read())
				{
					 obeFamilias = new beFamilias();
					obeFamilias.IdFamilia =  datard.GetInt32(0);
					obeFamilias.Familia =  datard.GetString(1);
					obeFamilias.Descripcion =  datard.GetString(2);
					obeFamilias.Activo =  datard.GetBoolean(3);
					lbeFamilias.Add(obeFamilias);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeFamilias;
		}
	}
	public DataTable listarFamilias_x_(SqlConnection Conexion,int IdFamilia)
	 {
		string sp = "Proc_Familias_Traer_Todos";
		DataTable dtFamilias = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = IdFamilia;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtFamilias = new DataTable();
				dtFamilias.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtFamilias;
		}
	}
}
}
