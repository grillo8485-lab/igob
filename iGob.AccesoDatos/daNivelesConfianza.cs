using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daNivelesConfianza
 {
	public int guardarNivelesConfianza(SqlConnection Conexion, beNivelesConfianza obeNivelesConfianza)
	{
		int Id=0;
		string sp = "Proc_NivelesConfianzaInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdNivelConfianza", SqlDbType.Int).Value = obeNivelesConfianza.IdNivelConfianza;
				cmd.Parameters.Add("@NivelConfianza", SqlDbType.Decimal).Value = obeNivelesConfianza.NivelConfianza;
				cmd.Parameters.Add("@ValorConfianza", SqlDbType.Decimal).Value = obeNivelesConfianza.ValorConfianza;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarNivelesConfianza(SqlConnection Conexion, beNivelesConfianza obeNivelesConfianza)
	{
		string sp = "Proc_NivelesConfianzaActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdNivelConfianza", SqlDbType.Int).Value = obeNivelesConfianza.IdNivelConfianza;
				cmd.Parameters.Add("@NivelConfianza", SqlDbType.Decimal).Value = obeNivelesConfianza.NivelConfianza;
				cmd.Parameters.Add("@ValorConfianza", SqlDbType.Decimal).Value = obeNivelesConfianza.ValorConfianza;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarNivelesConfianza(SqlConnection Conexion,int pIdNivelConfianza)
	{
		string sp = "Proc_NivelesConfianzaEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdNivelConfianza", SqlDbType.Int).Value = pIdNivelConfianza;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beNivelesConfianza traerNivelesConfianza_x_IdNivelConfianza(SqlConnection Conexion,int IdNivelConfianza)
	{
		string sp = "Proc_NivelesConfianza_x_IdNivelConfianza";
				beNivelesConfianza obeNivelesConfianza=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdNivelConfianza", SqlDbType.Int).Value = IdNivelConfianza;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdNivelConfianza = datard.GetOrdinal("IdNivelConfianza");
						int posNivelConfianza = datard.GetOrdinal("NivelConfianza");
						int posValorConfianza = datard.GetOrdinal("ValorConfianza");
					 obeNivelesConfianza = new beNivelesConfianza();
				while (datard.Read())
					{
						obeNivelesConfianza.IdNivelConfianza =  datard.GetInt32(posIdNivelConfianza);
						obeNivelesConfianza.NivelConfianza =  datard.GetDecimal(posNivelConfianza);
						obeNivelesConfianza.ValorConfianza =  datard.GetDecimal(posValorConfianza);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeNivelesConfianza;
			}
	}
	public List< beNivelesConfianza> listarTodos_NivelesConfianza(SqlConnection Conexion)
	 {
		string sp = "Proc_NivelesConfianza_Traer_Todos";
		List<beNivelesConfianza> lbeNivelesConfianza = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdNivelConfianza = datard.GetOrdinal("IdNivelConfianza");
						int posNivelConfianza = datard.GetOrdinal("NivelConfianza");
						int posValorConfianza = datard.GetOrdinal("ValorConfianza");
				lbeNivelesConfianza = new List<beNivelesConfianza>();
				beNivelesConfianza obeNivelesConfianza;
				while (datard.Read())
				{
					 obeNivelesConfianza = new beNivelesConfianza();
					obeNivelesConfianza.IdNivelConfianza =  datard.GetInt32(posIdNivelConfianza);
					obeNivelesConfianza.NivelConfianza =  datard.GetDecimal(posNivelConfianza);
					obeNivelesConfianza.ValorConfianza =  datard.GetDecimal(posValorConfianza);
					lbeNivelesConfianza.Add(obeNivelesConfianza);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeNivelesConfianza;
		}
	}
	public List< beNivelesConfianza> listar_NivelesConfianza_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_NivelesConfianza_TraerTodos_GetAll";
		List<beNivelesConfianza> lbeNivelesConfianza = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdNivelConfianza = datard.GetOrdinal("IdNivelConfianza");
						int posNivelConfianza = datard.GetOrdinal("NivelConfianza");
						int posValorConfianza = datard.GetOrdinal("ValorConfianza");
				lbeNivelesConfianza = new List<beNivelesConfianza>();
				beNivelesConfianza obeNivelesConfianza;
				while (datard.Read())
				{
					 obeNivelesConfianza = new beNivelesConfianza();
					obeNivelesConfianza.IdNivelConfianza =  datard.GetInt32(posIdNivelConfianza);
					obeNivelesConfianza.NivelConfianza =  datard.GetDecimal(posNivelConfianza);
					obeNivelesConfianza.ValorConfianza =  datard.GetDecimal(posValorConfianza);
			// debe agregar campos de la Vista
					lbeNivelesConfianza.Add(obeNivelesConfianza);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeNivelesConfianza;
		}
	}
}
}
