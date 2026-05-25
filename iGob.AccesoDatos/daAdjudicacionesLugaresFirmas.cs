using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesLugaresFirmas
 {
	public int guardarAdjudicacionesLugaresFirmas(SqlConnection Conexion, beAdjudicacionesLugaresFirmas obeAdjudicacionesLugaresFirmas)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesLugaresFirmasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionLugarFirma", SqlDbType.Int).Value = obeAdjudicacionesLugaresFirmas.IdAdjudicacionLugarFirma;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesLugaresFirmas.IdAdjudicacion;
				cmd.Parameters.Add("@IdLugarFirma", SqlDbType.Int).Value = obeAdjudicacionesLugaresFirmas.IdLugarFirma;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesLugaresFirmas(SqlConnection Conexion, beAdjudicacionesLugaresFirmas obeAdjudicacionesLugaresFirmas)
	{
		string sp = "Proc_AdjudicacionesLugaresFirmasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionLugarFirma", SqlDbType.Int).Value = obeAdjudicacionesLugaresFirmas.IdAdjudicacionLugarFirma;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesLugaresFirmas.IdAdjudicacion;
				cmd.Parameters.Add("@IdLugarFirma", SqlDbType.Int).Value = obeAdjudicacionesLugaresFirmas.IdLugarFirma;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesLugaresFirmas(SqlConnection Conexion,int pIdAdjudicacionLugarFirma)
	{
		string sp = "Proc_AdjudicacionesLugaresFirmasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionLugarFirma", SqlDbType.Int).Value = pIdAdjudicacionLugarFirma;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesLugaresFirmas traerAdjudicacionesLugaresFirmas_x_IdAdjudicacionLugarFirma(SqlConnection Conexion,int IdAdjudicacionLugarFirma)
	{
		string sp = "Proc_AdjudicacionesLugaresFirmas_x_IdAdjudicacionLugarFirma";
				beAdjudicacionesLugaresFirmas obeAdjudicacionesLugaresFirmas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdjudicacionLugarFirma", SqlDbType.Int).Value = IdAdjudicacionLugarFirma;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdjudicacionLugarFirma = datard.GetOrdinal("IdAdjudicacionLugarFirma");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdLugarFirma = datard.GetOrdinal("IdLugarFirma");
					 obeAdjudicacionesLugaresFirmas = new beAdjudicacionesLugaresFirmas();
				while (datard.Read())
					{
						obeAdjudicacionesLugaresFirmas.IdAdjudicacionLugarFirma =  datard.GetInt32(posIdAdjudicacionLugarFirma);
						obeAdjudicacionesLugaresFirmas.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
						obeAdjudicacionesLugaresFirmas.IdLugarFirma =  datard.GetInt32(posIdLugarFirma);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesLugaresFirmas;
			}
	}
	public List< beAdjudicacionesLugaresFirmas> listarTodos_AdjudicacionesLugaresFirmas(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesLugaresFirmas_Traer_Todos";
		List<beAdjudicacionesLugaresFirmas> lbeAdjudicacionesLugaresFirmas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionLugarFirma = datard.GetOrdinal("IdAdjudicacionLugarFirma");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdLugarFirma = datard.GetOrdinal("IdLugarFirma");
				lbeAdjudicacionesLugaresFirmas = new List<beAdjudicacionesLugaresFirmas>();
				beAdjudicacionesLugaresFirmas obeAdjudicacionesLugaresFirmas;
				while (datard.Read())
				{
					 obeAdjudicacionesLugaresFirmas = new beAdjudicacionesLugaresFirmas();
					obeAdjudicacionesLugaresFirmas.IdAdjudicacionLugarFirma =  datard.GetInt32(posIdAdjudicacionLugarFirma);
					obeAdjudicacionesLugaresFirmas.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesLugaresFirmas.IdLugarFirma =  datard.GetInt32(posIdLugarFirma);
					lbeAdjudicacionesLugaresFirmas.Add(obeAdjudicacionesLugaresFirmas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesLugaresFirmas;
		}
	}
	public List< beAdjudicacionesLugaresFirmas> listar_AdjudicacionesLugaresFirmas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesLugaresFirmas_TraerTodos_GetAll";
		List<beAdjudicacionesLugaresFirmas> lbeAdjudicacionesLugaresFirmas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionLugarFirma = datard.GetOrdinal("IdAdjudicacionLugarFirma");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdLugarFirma = datard.GetOrdinal("IdLugarFirma");
				lbeAdjudicacionesLugaresFirmas = new List<beAdjudicacionesLugaresFirmas>();
				beAdjudicacionesLugaresFirmas obeAdjudicacionesLugaresFirmas;
				while (datard.Read())
				{
					 obeAdjudicacionesLugaresFirmas = new beAdjudicacionesLugaresFirmas();
					obeAdjudicacionesLugaresFirmas.IdAdjudicacionLugarFirma =  datard.GetInt32(posIdAdjudicacionLugarFirma);
					obeAdjudicacionesLugaresFirmas.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesLugaresFirmas.IdLugarFirma =  datard.GetInt32(posIdLugarFirma);
			// debe agregar campos de la Vista
					lbeAdjudicacionesLugaresFirmas.Add(obeAdjudicacionesLugaresFirmas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesLugaresFirmas;
		}
	}
}
}
