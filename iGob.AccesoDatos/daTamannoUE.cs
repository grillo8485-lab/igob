using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTamannoUE
 {
	public int guardarTamannoUE(SqlConnection Conexion, beTamannoUE obeTamannoUE)
	{
		int Id=0;
		string sp = "Proc_TamannoUEInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTamannoUE", SqlDbType.Int).Value = obeTamannoUE.IdTamannoUE;
				cmd.Parameters.Add("@TamanoUE", SqlDbType.NVarChar).Value = obeTamannoUE.TamanoUE;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTamannoUE(SqlConnection Conexion, beTamannoUE obeTamannoUE)
	{
		string sp = "Proc_TamannoUEActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTamannoUE", SqlDbType.Int).Value = obeTamannoUE.IdTamannoUE;
				cmd.Parameters.Add("@TamanoUE", SqlDbType.NVarChar).Value = obeTamannoUE.TamanoUE;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTamannoUE(SqlConnection Conexion,int pIdTamannoUE)
	{
		string sp = "Proc_TamannoUEEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTamannoUE", SqlDbType.Int).Value = pIdTamannoUE;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTamannoUE traerTamannoUE_x_IdTamannoUE(SqlConnection Conexion,int IdTamannoUE)
	{
		string sp = "Proc_TamannoUE_x_IdTamannoUE";
				beTamannoUE obeTamannoUE=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTamannoUE", SqlDbType.Int).Value = IdTamannoUE;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdTamannoUE = datard.GetOrdinal("IdTamannoUE");
						int posTamanoUE = datard.GetOrdinal("TamanoUE");
					 obeTamannoUE = new beTamannoUE();
				while (datard.Read())
					{
						obeTamannoUE.IdTamannoUE =  datard.GetInt32(posIdTamannoUE);
						obeTamannoUE.TamanoUE =  datard.GetString(posTamanoUE);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTamannoUE;
			}
	}
	public List< beTamannoUE> listarTodos_TamannoUE(SqlConnection Conexion)
	 {
		string sp = "Proc_TamannoUE_Traer_Todos";
		List<beTamannoUE> lbeTamannoUE = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTamannoUE = datard.GetOrdinal("IdTamannoUE");
						int posTamanoUE = datard.GetOrdinal("TamanoUE");
				lbeTamannoUE = new List<beTamannoUE>();
				beTamannoUE obeTamannoUE;
				while (datard.Read())
				{
					 obeTamannoUE = new beTamannoUE();
					obeTamannoUE.IdTamannoUE =  datard.GetInt32(posIdTamannoUE);
					obeTamannoUE.TamanoUE =  datard.GetString(posTamanoUE);
					lbeTamannoUE.Add(obeTamannoUE);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTamannoUE;
		}
	}
	public List< beTamannoUE> listar_TamannoUE_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_TamannoUE_TraerTodos_GetAll";
		List<beTamannoUE> lbeTamannoUE = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTamannoUE = datard.GetOrdinal("IdTamannoUE");
						int posTamanoUE = datard.GetOrdinal("TamanoUE");
				lbeTamannoUE = new List<beTamannoUE>();
				beTamannoUE obeTamannoUE;
				while (datard.Read())
				{
					 obeTamannoUE = new beTamannoUE();
					obeTamannoUE.IdTamannoUE =  datard.GetInt32(posIdTamannoUE);
					obeTamannoUE.TamanoUE =  datard.GetString(posTamanoUE);
			// debe agregar campos de la Vista
					lbeTamannoUE.Add(obeTamannoUE);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTamannoUE;
		}
	}
}
}
