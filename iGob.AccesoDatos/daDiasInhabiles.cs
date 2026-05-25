using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daDiasInhabiles
 {
	public int guardarDiasInhabiles(SqlConnection Conexion, beDiasInhabiles obeDiasInhabiles)
	{
		int Id=0;
		string sp = "Proc_DiasInhabilesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDiaInhabil", SqlDbType.Int).Value = obeDiasInhabiles.IdDiaInhabil;
				cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = obeDiasInhabiles.Fecha;
				cmd.Parameters.Add("@Evento", SqlDbType.NVarChar).Value = obeDiasInhabiles.Evento;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeDiasInhabiles.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarDiasInhabiles(SqlConnection Conexion, beDiasInhabiles obeDiasInhabiles)
	{
		string sp = "Proc_DiasInhabilesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDiaInhabil", SqlDbType.Int).Value = obeDiasInhabiles.IdDiaInhabil;
				cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = obeDiasInhabiles.Fecha;
				cmd.Parameters.Add("@Evento", SqlDbType.NVarChar).Value = obeDiasInhabiles.Evento;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeDiasInhabiles.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarDiasInhabiles(SqlConnection Conexion,int pIdDiaInhabil)
	{
		string sp = "Proc_DiasInhabilesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDiaInhabil", SqlDbType.Int).Value = pIdDiaInhabil;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beDiasInhabiles traerDiasInhabiles_x_IdDiaInhabil(SqlConnection Conexion,int IdDiaInhabil)
	{
		string sp = "Proc_DiasInhabiles_x_IdDiaInhabil";
		List<beDiasInhabiles> lbeDiasInhabiles = null;
				beDiasInhabiles obeDiasInhabiles=new beDiasInhabiles();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdDiaInhabil", SqlDbType.Int).Value = IdDiaInhabil;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeDiasInhabiles = new List<beDiasInhabiles>();
						int posIdDiaInhabil = datard.GetOrdinal("IdDiaInhabil");
						int posFecha = datard.GetOrdinal("Fecha");
						int posEvento = datard.GetOrdinal("Evento");
						int posActivo = datard.GetOrdinal("Activo");
				while (datard.Read())
					{
					 obeDiasInhabiles = new beDiasInhabiles();
						obeDiasInhabiles.IdDiaInhabil =  datard.GetInt32(posIdDiaInhabil);
						obeDiasInhabiles.Fecha =  datard.GetDateTime(posFecha);
						obeDiasInhabiles.Evento =  datard.GetString(posEvento);
						obeDiasInhabiles.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeDiasInhabiles;
			}
	}
	public List< beDiasInhabiles> listarTodos_DiasInhabiles(SqlConnection Conexion)
	 {
		string sp = "Proc_DiasInhabiles_Traer_Todos";
		List<beDiasInhabiles> lbeDiasInhabiles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdDiaInhabil = datard.GetOrdinal("IdDiaInhabil");
						int posFecha = datard.GetOrdinal("Fecha");
						int posEvento = datard.GetOrdinal("Evento");
						int posActivo = datard.GetOrdinal("Activo");
				lbeDiasInhabiles = new List<beDiasInhabiles>();
				beDiasInhabiles obeDiasInhabiles;
				while (datard.Read())
				{
					 obeDiasInhabiles = new beDiasInhabiles();
					obeDiasInhabiles.IdDiaInhabil =  datard.GetInt32(posIdDiaInhabil);
					obeDiasInhabiles.Fecha =  datard.GetDateTime(posFecha);
					obeDiasInhabiles.Evento =  datard.GetString(posEvento);
					obeDiasInhabiles.Activo =  datard.GetBoolean(posActivo);
					lbeDiasInhabiles.Add(obeDiasInhabiles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDiasInhabiles;
		}
	}
	public List< beDiasInhabiles> listar_DiasInhabiles_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_DiasInhabiles_TraerTodos_GetAll";
		List<beDiasInhabiles> lbeDiasInhabiles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdDiaInhabil = datard.GetOrdinal("IdDiaInhabil");
						int posFecha = datard.GetOrdinal("Fecha");
						int posEvento = datard.GetOrdinal("Evento");
						int posActivo = datard.GetOrdinal("Activo");
				lbeDiasInhabiles = new List<beDiasInhabiles>();
				beDiasInhabiles obeDiasInhabiles;
				while (datard.Read())
				{
					 obeDiasInhabiles = new beDiasInhabiles();
					obeDiasInhabiles.IdDiaInhabil =  datard.GetInt32(posIdDiaInhabil);
					obeDiasInhabiles.Fecha =  datard.GetDateTime(posFecha);
					obeDiasInhabiles.Evento =  datard.GetString(posEvento);
					obeDiasInhabiles.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeDiasInhabiles.Add(obeDiasInhabiles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDiasInhabiles;
		}
	}
}
}
