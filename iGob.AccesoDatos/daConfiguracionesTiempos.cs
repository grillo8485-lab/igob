using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daConfiguracionesTiempos
 {
	public int guardarConfiguracionesTiempos(SqlConnection Conexion, beConfiguracionesTiempos obeConfiguracionesTiempos)
	{
		int Id=0;
		string sp = "Proc_ConfiguracionesTiemposInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConfiguracionTiempo", SqlDbType.Int).Value = obeConfiguracionesTiempos.IdConfiguracionTiempo;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeConfiguracionesTiempos.IdGobierno;
				cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeConfiguracionesTiempos.IdTiempo;
				cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = obeConfiguracionesTiempos.IdTipoLicitacion;
				cmd.Parameters.Add("@PublicacionConvocatoriaDia", SqlDbType.Int).Value = obeConfiguracionesTiempos.PublicacionConvocatoriaDia;
				cmd.Parameters.Add("@DisposicionBasesDias", SqlDbType.Int).Value = obeConfiguracionesTiempos.DisposicionBasesDias;
				cmd.Parameters.Add("@LimiteEnvioPreguntasHoras", SqlDbType.Int).Value = obeConfiguracionesTiempos.LimiteEnvioPreguntasHoras;
				cmd.Parameters.Add("@LimiteEnvioRespuestasHoras", SqlDbType.Int).Value = obeConfiguracionesTiempos.LimiteEnvioRespuestasHoras;
				cmd.Parameters.Add("@AclaracionDudasDias", SqlDbType.Int).Value = obeConfiguracionesTiempos.AclaracionDudasDias;
				cmd.Parameters.Add("@EnvioProuestaTecEcoDias", SqlDbType.Int).Value = obeConfiguracionesTiempos.EnvioProuestaTecEcoDias;
				cmd.Parameters.Add("@EntregaDictamenDias", SqlDbType.Int).Value = obeConfiguracionesTiempos.EntregaDictamenDias;
				cmd.Parameters.Add("@FalloDias", SqlDbType.Int).Value = obeConfiguracionesTiempos.FalloDias;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarConfiguracionesTiempos(SqlConnection Conexion, beConfiguracionesTiempos obeConfiguracionesTiempos)
	{
		string sp = "Proc_ConfiguracionesTiemposActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConfiguracionTiempo", SqlDbType.Int).Value = obeConfiguracionesTiempos.IdConfiguracionTiempo;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeConfiguracionesTiempos.IdGobierno;
				cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeConfiguracionesTiempos.IdTiempo;
				cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = obeConfiguracionesTiempos.IdTipoLicitacion;
				cmd.Parameters.Add("@PublicacionConvocatoriaDia", SqlDbType.Int).Value = obeConfiguracionesTiempos.PublicacionConvocatoriaDia;
				cmd.Parameters.Add("@DisposicionBasesDias", SqlDbType.Int).Value = obeConfiguracionesTiempos.DisposicionBasesDias;
				cmd.Parameters.Add("@LimiteEnvioPreguntasHoras", SqlDbType.Int).Value = obeConfiguracionesTiempos.LimiteEnvioPreguntasHoras;
				cmd.Parameters.Add("@LimiteEnvioRespuestasHoras", SqlDbType.Int).Value = obeConfiguracionesTiempos.LimiteEnvioRespuestasHoras;
				cmd.Parameters.Add("@AclaracionDudasDias", SqlDbType.Int).Value = obeConfiguracionesTiempos.AclaracionDudasDias;
				cmd.Parameters.Add("@EnvioProuestaTecEcoDias", SqlDbType.Int).Value = obeConfiguracionesTiempos.EnvioProuestaTecEcoDias;
				cmd.Parameters.Add("@EntregaDictamenDias", SqlDbType.Int).Value = obeConfiguracionesTiempos.EntregaDictamenDias;
				cmd.Parameters.Add("@FalloDias", SqlDbType.Int).Value = obeConfiguracionesTiempos.FalloDias;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarConfiguracionesTiempos(SqlConnection Conexion,int pIdConfiguracionTiempo)
	{
		string sp = "Proc_ConfiguracionesTiemposEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConfiguracionTiempo", SqlDbType.Int).Value = pIdConfiguracionTiempo;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beConfiguracionesTiempos traerConfiguracionesTiempos_x_IdConfiguracionTiempo(SqlConnection Conexion,int IdConfiguracionTiempo)
	{
		string sp = "Proc_ConfiguracionesTiempos_x_IdConfiguracionTiempo";
		List<beConfiguracionesTiempos> lbeConfiguracionesTiempos = null;
				beConfiguracionesTiempos obeConfiguracionesTiempos=new beConfiguracionesTiempos();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdConfiguracionTiempo", SqlDbType.Int).Value = IdConfiguracionTiempo;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeConfiguracionesTiempos = new List<beConfiguracionesTiempos>();
						int posIdConfiguracionTiempo = datard.GetOrdinal("IdConfiguracionTiempo");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posIdTiempo = datard.GetOrdinal("IdTiempo");
						int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						int posPublicacionConvocatoriaDia = datard.GetOrdinal("PublicacionConvocatoriaDia");
						int posDisposicionBasesDias = datard.GetOrdinal("DisposicionBasesDias");
						int posLimiteEnvioPreguntasHoras = datard.GetOrdinal("LimiteEnvioPreguntasHoras");
						int posLimiteEnvioRespuestasHoras = datard.GetOrdinal("LimiteEnvioRespuestasHoras");
						int posAclaracionDudasDias = datard.GetOrdinal("AclaracionDudasDias");
						int posEnvioProuestaTecEcoDias = datard.GetOrdinal("EnvioProuestaTecEcoDias");
						int posEntregaDictamenDias = datard.GetOrdinal("EntregaDictamenDias");
						int posFalloDias = datard.GetOrdinal("FalloDias");
				while (datard.Read())
					{
					 obeConfiguracionesTiempos = new beConfiguracionesTiempos();
						obeConfiguracionesTiempos.IdConfiguracionTiempo =  datard.GetInt32(posIdConfiguracionTiempo);
						obeConfiguracionesTiempos.IdGobierno =  datard.GetInt32(posIdGobierno);
						obeConfiguracionesTiempos.IdTiempo =  datard.GetInt32(posIdTiempo);
						obeConfiguracionesTiempos.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
						obeConfiguracionesTiempos.PublicacionConvocatoriaDia =  datard.GetInt32(posPublicacionConvocatoriaDia);
						obeConfiguracionesTiempos.DisposicionBasesDias =  datard.GetInt32(posDisposicionBasesDias);
						obeConfiguracionesTiempos.LimiteEnvioPreguntasHoras =  datard.GetInt32(posLimiteEnvioPreguntasHoras);
						obeConfiguracionesTiempos.LimiteEnvioRespuestasHoras =  datard.GetInt32(posLimiteEnvioRespuestasHoras);
						obeConfiguracionesTiempos.AclaracionDudasDias =  datard.GetInt32(posAclaracionDudasDias);
						obeConfiguracionesTiempos.EnvioProuestaTecEcoDias =  datard.GetInt32(posEnvioProuestaTecEcoDias);
						obeConfiguracionesTiempos.EntregaDictamenDias =  datard.GetInt32(posEntregaDictamenDias);
						obeConfiguracionesTiempos.FalloDias =  datard.GetInt32(posFalloDias);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeConfiguracionesTiempos;
			}
	}
	public List< beConfiguracionesTiempos> listarTodos_ConfiguracionesTiempos(SqlConnection Conexion)
	 {
		string sp = "Proc_ConfiguracionesTiempos_Traer_Todos";
		List<beConfiguracionesTiempos> lbeConfiguracionesTiempos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdConfiguracionTiempo = datard.GetOrdinal("IdConfiguracionTiempo");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posIdTiempo = datard.GetOrdinal("IdTiempo");
						int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						int posPublicacionConvocatoriaDia = datard.GetOrdinal("PublicacionConvocatoriaDia");
						int posDisposicionBasesDias = datard.GetOrdinal("DisposicionBasesDias");
						int posLimiteEnvioPreguntasHoras = datard.GetOrdinal("LimiteEnvioPreguntasHoras");
						int posLimiteEnvioRespuestasHoras = datard.GetOrdinal("LimiteEnvioRespuestasHoras");
						int posAclaracionDudasDias = datard.GetOrdinal("AclaracionDudasDias");
						int posEnvioProuestaTecEcoDias = datard.GetOrdinal("EnvioProuestaTecEcoDias");
						int posEntregaDictamenDias = datard.GetOrdinal("EntregaDictamenDias");
						int posFalloDias = datard.GetOrdinal("FalloDias");
				lbeConfiguracionesTiempos = new List<beConfiguracionesTiempos>();
				beConfiguracionesTiempos obeConfiguracionesTiempos;
				while (datard.Read())
				{
					 obeConfiguracionesTiempos = new beConfiguracionesTiempos();
					obeConfiguracionesTiempos.IdConfiguracionTiempo =  datard.GetInt32(posIdConfiguracionTiempo);
					obeConfiguracionesTiempos.IdGobierno =  datard.GetInt32(posIdGobierno);
					obeConfiguracionesTiempos.IdTiempo =  datard.GetInt32(posIdTiempo);
					obeConfiguracionesTiempos.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
					obeConfiguracionesTiempos.PublicacionConvocatoriaDia =  datard.GetInt32(posPublicacionConvocatoriaDia);
					obeConfiguracionesTiempos.DisposicionBasesDias =  datard.GetInt32(posDisposicionBasesDias);
					obeConfiguracionesTiempos.LimiteEnvioPreguntasHoras =  datard.GetInt32(posLimiteEnvioPreguntasHoras);
					obeConfiguracionesTiempos.LimiteEnvioRespuestasHoras =  datard.GetInt32(posLimiteEnvioRespuestasHoras);
					obeConfiguracionesTiempos.AclaracionDudasDias =  datard.GetInt32(posAclaracionDudasDias);
					obeConfiguracionesTiempos.EnvioProuestaTecEcoDias =  datard.GetInt32(posEnvioProuestaTecEcoDias);
					obeConfiguracionesTiempos.EntregaDictamenDias =  datard.GetInt32(posEntregaDictamenDias);
					obeConfiguracionesTiempos.FalloDias =  datard.GetInt32(posFalloDias);
					lbeConfiguracionesTiempos.Add(obeConfiguracionesTiempos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConfiguracionesTiempos;
		}
	}
	public List< beConfiguracionesTiempos> listar_ConfiguracionesTiempos_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_ConfiguracionesTiempos_TraerTodos_GetAll";
		List<beConfiguracionesTiempos> lbeConfiguracionesTiempos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdConfiguracionTiempo = datard.GetOrdinal("IdConfiguracionTiempo");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posIdTiempo = datard.GetOrdinal("IdTiempo");
						int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						int posPublicacionConvocatoriaDia = datard.GetOrdinal("PublicacionConvocatoriaDia");
						int posDisposicionBasesDias = datard.GetOrdinal("DisposicionBasesDias");
						int posLimiteEnvioPreguntasHoras = datard.GetOrdinal("LimiteEnvioPreguntasHoras");
						int posLimiteEnvioRespuestasHoras = datard.GetOrdinal("LimiteEnvioRespuestasHoras");
						int posAclaracionDudasDias = datard.GetOrdinal("AclaracionDudasDias");
						int posEnvioProuestaTecEcoDias = datard.GetOrdinal("EnvioProuestaTecEcoDias");
						int posEntregaDictamenDias = datard.GetOrdinal("EntregaDictamenDias");
						int posFalloDias = datard.GetOrdinal("FalloDias");
                        
                        /* Gobierno 24/08/2018 */
                        int posGobierno = datard.GetOrdinal("Gobierno");
				lbeConfiguracionesTiempos = new List<beConfiguracionesTiempos>();
				beConfiguracionesTiempos obeConfiguracionesTiempos;
				while (datard.Read())
				{
					 obeConfiguracionesTiempos = new beConfiguracionesTiempos();
					obeConfiguracionesTiempos.IdConfiguracionTiempo =  datard.GetInt32(posIdConfiguracionTiempo);
					obeConfiguracionesTiempos.IdGobierno =  datard.GetInt32(posIdGobierno);
					obeConfiguracionesTiempos.IdTiempo =  datard.GetInt32(posIdTiempo);
					obeConfiguracionesTiempos.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
					obeConfiguracionesTiempos.PublicacionConvocatoriaDia =  datard.GetInt32(posPublicacionConvocatoriaDia);
					obeConfiguracionesTiempos.DisposicionBasesDias =  datard.GetInt32(posDisposicionBasesDias);
					obeConfiguracionesTiempos.LimiteEnvioPreguntasHoras =  datard.GetInt32(posLimiteEnvioPreguntasHoras);
					obeConfiguracionesTiempos.LimiteEnvioRespuestasHoras =  datard.GetInt32(posLimiteEnvioRespuestasHoras);
					obeConfiguracionesTiempos.AclaracionDudasDias =  datard.GetInt32(posAclaracionDudasDias);
					obeConfiguracionesTiempos.EnvioProuestaTecEcoDias =  datard.GetInt32(posEnvioProuestaTecEcoDias);
					obeConfiguracionesTiempos.EntregaDictamenDias =  datard.GetInt32(posEntregaDictamenDias);
					obeConfiguracionesTiempos.FalloDias =  datard.GetInt32(posFalloDias);

                    /* Gobierno 24/08/2018 */
                    obeConfiguracionesTiempos.Gobierno =  datard.GetString(posGobierno);

			// debe agregar campos de la Vista
					lbeConfiguracionesTiempos.Add(obeConfiguracionesTiempos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConfiguracionesTiempos;
		}
	}
}
}
