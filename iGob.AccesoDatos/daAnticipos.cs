using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAnticipos
 {
	public int guardarAnticipos(SqlConnection Conexion, beAnticipos obeAnticipos)
	{
		int Id=0;
		string sp = "Proc_AnticiposInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAnticipo", SqlDbType.Int).Value = obeAnticipos.IdAnticipo;
				cmd.Parameters.Add("@AnticipoPorcentaje", SqlDbType.NChar).Value = obeAnticipos.AnticipoPorcentaje;
				cmd.Parameters.Add("@PorcentajeValor", SqlDbType.Decimal).Value = obeAnticipos.PorcentajeValor;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAnticipos(SqlConnection Conexion, beAnticipos obeAnticipos)
	{
		string sp = "Proc_AnticiposActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAnticipo", SqlDbType.Int).Value = obeAnticipos.IdAnticipo;
				cmd.Parameters.Add("@AnticipoPorcentaje", SqlDbType.NChar).Value = obeAnticipos.AnticipoPorcentaje;
				cmd.Parameters.Add("@PorcentajeValor", SqlDbType.Decimal).Value = obeAnticipos.PorcentajeValor;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAnticipos(SqlConnection Conexion,int pIdAnticipo)
	{
		string sp = "Proc_AnticiposEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAnticipo", SqlDbType.Int).Value = pIdAnticipo;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAnticipos traerAnticipos_x_IdAnticipo(SqlConnection Conexion,int IdAnticipo)
	{
		string sp = "Proc_Anticipos_x_IdAnticipo";
				beAnticipos obeAnticipos=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAnticipo", SqlDbType.Int).Value = IdAnticipo;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAnticipo = datard.GetOrdinal("IdAnticipo");
						int posAnticipoPorcentaje = datard.GetOrdinal("AnticipoPorcentaje");
						int posPorcentajeValor = datard.GetOrdinal("PorcentajeValor");
					 obeAnticipos = new beAnticipos();
				while (datard.Read())
					{
						obeAnticipos.IdAnticipo =  datard.GetInt32(posIdAnticipo);
						obeAnticipos.AnticipoPorcentaje =  datard.GetString(posAnticipoPorcentaje);
						obeAnticipos.PorcentajeValor =  datard.GetDecimal(posPorcentajeValor);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAnticipos;
			}
	}
	public List< beAnticipos> listarTodos_Anticipos(SqlConnection Conexion)
	 {
		string sp = "Proc_Anticipos_Traer_Todos";
		List<beAnticipos> lbeAnticipos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAnticipo = datard.GetOrdinal("IdAnticipo");
						int posAnticipoPorcentaje = datard.GetOrdinal("AnticipoPorcentaje");
						int posPorcentajeValor = datard.GetOrdinal("PorcentajeValor");
				lbeAnticipos = new List<beAnticipos>();
				beAnticipos obeAnticipos;
				while (datard.Read())
				{
					 obeAnticipos = new beAnticipos();
					obeAnticipos.IdAnticipo =  datard.GetInt32(posIdAnticipo);
					obeAnticipos.AnticipoPorcentaje =  datard.GetString(posAnticipoPorcentaje);
					obeAnticipos.PorcentajeValor =  datard.GetDecimal(posPorcentajeValor);
					lbeAnticipos.Add(obeAnticipos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAnticipos;
		}
	}
	public List< beAnticipos> listar_Anticipos_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_Anticipos_TraerTodos_GetAll";
		List<beAnticipos> lbeAnticipos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAnticipo = datard.GetOrdinal("IdAnticipo");
						int posAnticipoPorcentaje = datard.GetOrdinal("AnticipoPorcentaje");
						int posPorcentajeValor = datard.GetOrdinal("PorcentajeValor");
				lbeAnticipos = new List<beAnticipos>();
				beAnticipos obeAnticipos;
				while (datard.Read())
				{
					 obeAnticipos = new beAnticipos();
					obeAnticipos.IdAnticipo =  datard.GetInt32(posIdAnticipo);
					obeAnticipos.AnticipoPorcentaje =  datard.GetString(posAnticipoPorcentaje);
					obeAnticipos.PorcentajeValor =  datard.GetDecimal(posPorcentajeValor);
			// debe agregar campos de la Vista
					lbeAnticipos.Add(obeAnticipos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAnticipos;
		}
	}
}
}
