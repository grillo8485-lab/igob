using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daLicitaciones
 {
	public int guardarLicitaciones(SqlConnection Conexion, beLicitaciones obeLicitaciones)
	{
		int Id=0;
		string sp = "Proc_LicitacionesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = obeLicitaciones.IdLicitacion;
                    //cmd.Parameters.Add("@IdConfiguracionModalidad", SqlDbType.Int).Value = obeLicitaciones.IdConfiguracionModalidad;
                    cmd.Parameters.Add("@IdConfiguracionModalidad", SqlDbType.Int).Value = 44;
                    cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = obeLicitaciones.IdModalidadLicitacion;
                    //cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = 4;
                    cmd.Parameters.Add("@IdEtapaLicitacion", SqlDbType.Int).Value = obeLicitaciones.IdEtapaLicitacion;
                    cmd.Parameters.Add("@FolioOficial", SqlDbType.NVarChar).Value = obeLicitaciones.FolioOficial;
                    //cmd.Parameters.Add("@FolioOficial", SqlDbType.NVarChar).Value = "14-A";
                    cmd.Parameters.Add("@MontoBases", SqlDbType.Decimal).Value = obeLicitaciones.MontoBases;
				cmd.Parameters.Add("@NumeroLicitacion", SqlDbType.Int).Value = obeLicitaciones.NumeroLicitacion;
                    //cmd.Parameters.Add("@FechaAutorizacion", SqlDbType.DateTime).Value = obeLicitaciones.FechaAutorizacion;
                    cmd.Parameters.Add("@FechaAutorizacion", SqlDbType.DateTime).Value = obeLicitaciones.FechaRegistro;
                    cmd.Parameters.Add("@HoraAutorizacion", SqlDbType.Time).Value = obeLicitaciones.HoraAutorizacion;
                    //cmd.Parameters.Add("@FechaPublicacion", SqlDbType.DateTime).Value = obeLicitaciones.FechaPublicacion;
                    //cmd.Parameters.Add("@FechaDisposicionBases", SqlDbType.DateTime).Value = obeLicitaciones.FechaDisposicionBases;
                    //cmd.Parameters.Add("@FechaLimitePreguntas", SqlDbType.DateTime).Value = obeLicitaciones.FechaLimitePreguntas;
                    //cmd.Parameters.Add("@FechaLimiteRespuestas", SqlDbType.DateTime).Value = obeLicitaciones.FechaLimiteRespuestas;
                    //cmd.Parameters.Add("@FechaHoraAclaracionDudas", SqlDbType.DateTime).Value = obeLicitaciones.FechaHoraAclaracionDudas;
                    //cmd.Parameters.Add("@FechaEnvioPropuestasTecEco", SqlDbType.DateTime).Value = obeLicitaciones.FechaEnvioPropuestasTecEco;
                    //cmd.Parameters.Add("@FechaLimiteDictamen", SqlDbType.DateTime).Value = obeLicitaciones.FechaLimiteDictamen;
                    //cmd.Parameters.Add("@FechaFallo", SqlDbType.DateTime).Value = obeLicitaciones.FechaFallo;
                    cmd.Parameters.Add("@FechaPublicacion", SqlDbType.DateTime).Value = obeLicitaciones.FechaRegistro.AddDays(2);
                    cmd.Parameters.Add("@FechaDisposicionBases", SqlDbType.DateTime).Value = obeLicitaciones.FechaRegistro.AddDays(3);
                    cmd.Parameters.Add("@FechaLimitePreguntas", SqlDbType.DateTime).Value = obeLicitaciones.FechaRegistro.AddDays(4);
                    cmd.Parameters.Add("@FechaLimiteRespuestas", SqlDbType.DateTime).Value = obeLicitaciones.FechaRegistro.AddDays(5);
                    cmd.Parameters.Add("@FechaHoraAclaracionDudas", SqlDbType.DateTime).Value = obeLicitaciones.FechaRegistro.AddDays(6);
                    cmd.Parameters.Add("@FechaEnvioPropuestasTecEco", SqlDbType.DateTime).Value = obeLicitaciones.FechaRegistro.AddDays(7);
                    cmd.Parameters.Add("@FechaLimiteDictamen", SqlDbType.DateTime).Value = obeLicitaciones.FechaRegistro.AddDays(8);
                    cmd.Parameters.Add("@FechaFallo", SqlDbType.DateTime).Value = obeLicitaciones.FechaRegistro.AddDays(9);
                    cmd.Parameters.Add("@HoraFallo", SqlDbType.Time).Value = obeLicitaciones.HoraFallo;
				cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = obeLicitaciones.IdTipoLicitacion;
                    //cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeLicitaciones.IdTiempo;
                    cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obeLicitaciones.IdEjercicioFiscal;
				cmd.Parameters.Add("@IdUnidadLicitadora", SqlDbType.Int).Value = obeLicitaciones.IdUnidadLicitadora;
				cmd.Parameters.Add("@IdUsuarioRevisor", SqlDbType.Int).Value = obeLicitaciones.IdUsuarioRevisor;
                    //cmd.Parameters.Add("@IdEstatusLicitacion", SqlDbType.Int).Value = obeLicitaciones.IdEstatusLicitacion;
                    cmd.Parameters.Add("@IdEstatusLicitacion", SqlDbType.Int).Value = 10;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeLicitaciones.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeLicitaciones.FechaRegistro;
				cmd.Parameters.Add("@TiempoPeriodoPujasHrs", SqlDbType.Int).Value = obeLicitaciones.TiempoPeriodoPujasHrs;
				cmd.Parameters.Add("@TiempoAdicionalPujasMin", SqlDbType.Int).Value = obeLicitaciones.TiempoAdicionalPujasMin;
				cmd.Parameters.Add("@TiempoEtapaFinalMin", SqlDbType.Int).Value = obeLicitaciones.TiempoEtapaFinalMin;
				cmd.Parameters.Add("@AplicaNomenclaturaInvolucrados", SqlDbType.Bit).Value = obeLicitaciones.AplicaNomenclaturaInvolucrados;
				cmd.Parameters.Add("@MostrarMontoPropuestaGanando", SqlDbType.Bit).Value = obeLicitaciones.MostrarMontoPropuestaGanando;
				cmd.Parameters.Add("@MostrarLugarProveedor", SqlDbType.Bit).Value = obeLicitaciones.MostrarLugarProveedor;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarLicitaciones(SqlConnection Conexion, beLicitaciones obeLicitaciones)
	{
		string sp = "Proc_LicitacionesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = obeLicitaciones.IdLicitacion;
				cmd.Parameters.Add("@IdConfiguracionModalidad", SqlDbType.Int).Value = obeLicitaciones.IdConfiguracionModalidad;
				cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = obeLicitaciones.IdModalidadLicitacion;
				cmd.Parameters.Add("@IdEtapaLicitacion", SqlDbType.Int).Value = obeLicitaciones.IdEtapaLicitacion;
				cmd.Parameters.Add("@FolioOficial", SqlDbType.NVarChar).Value = obeLicitaciones.FolioOficial;
				cmd.Parameters.Add("@MontoBases", SqlDbType.Decimal).Value = obeLicitaciones.MontoBases;
				cmd.Parameters.Add("@NumeroLicitacion", SqlDbType.Int).Value = obeLicitaciones.NumeroLicitacion;
				cmd.Parameters.Add("@FechaAutorizacion", SqlDbType.DateTime).Value = obeLicitaciones.FechaAutorizacion;
				cmd.Parameters.Add("@HoraAutorizacion", SqlDbType.Time).Value = obeLicitaciones.HoraAutorizacion;
				cmd.Parameters.Add("@FechaPublicacion", SqlDbType.DateTime).Value = obeLicitaciones.FechaPublicacion;
				cmd.Parameters.Add("@FechaDisposicionBases", SqlDbType.DateTime).Value = obeLicitaciones.FechaDisposicionBases;
				cmd.Parameters.Add("@FechaLimitePreguntas", SqlDbType.DateTime).Value = obeLicitaciones.FechaLimitePreguntas;
				cmd.Parameters.Add("@FechaLimiteRespuestas", SqlDbType.DateTime).Value = obeLicitaciones.FechaLimiteRespuestas;
				cmd.Parameters.Add("@FechaHoraAclaracionDudas", SqlDbType.DateTime).Value = obeLicitaciones.FechaHoraAclaracionDudas;
				cmd.Parameters.Add("@FechaEnvioPropuestasTecEco", SqlDbType.DateTime).Value = obeLicitaciones.FechaEnvioPropuestasTecEco;
				cmd.Parameters.Add("@FechaLimiteDictamen", SqlDbType.DateTime).Value = obeLicitaciones.FechaLimiteDictamen;
				cmd.Parameters.Add("@FechaFallo", SqlDbType.DateTime).Value = obeLicitaciones.FechaFallo;
				cmd.Parameters.Add("@HoraFallo", SqlDbType.Time).Value = obeLicitaciones.HoraFallo;
				cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = obeLicitaciones.IdTipoLicitacion;
				cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeLicitaciones.IdTiempo;
				cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obeLicitaciones.IdEjercicioFiscal;
				cmd.Parameters.Add("@IdUnidadLicitadora", SqlDbType.Int).Value = obeLicitaciones.IdUnidadLicitadora;
				cmd.Parameters.Add("@IdUsuarioRevisor", SqlDbType.Int).Value = obeLicitaciones.IdUsuarioRevisor;
				cmd.Parameters.Add("@IdEstatusLicitacion", SqlDbType.Int).Value = obeLicitaciones.IdEstatusLicitacion;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeLicitaciones.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeLicitaciones.FechaRegistro;
				cmd.Parameters.Add("@TiempoPeriodoPujasHrs", SqlDbType.Int).Value = obeLicitaciones.TiempoPeriodoPujasHrs;
				cmd.Parameters.Add("@TiempoAdicionalPujasMin", SqlDbType.Int).Value = obeLicitaciones.TiempoAdicionalPujasMin;
				cmd.Parameters.Add("@TiempoEtapaFinalMin", SqlDbType.Int).Value = obeLicitaciones.TiempoEtapaFinalMin;
				cmd.Parameters.Add("@AplicaNomenclaturaInvolucrados", SqlDbType.Bit).Value = obeLicitaciones.AplicaNomenclaturaInvolucrados;
				cmd.Parameters.Add("@MostrarMontoPropuestaGanando", SqlDbType.Bit).Value = obeLicitaciones.MostrarMontoPropuestaGanando;
				cmd.Parameters.Add("@MostrarLugarProveedor", SqlDbType.Bit).Value = obeLicitaciones.MostrarLugarProveedor;
			
				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarLicitaciones(SqlConnection Conexion,int pIdLicitacion)
	{
		string sp = "Proc_LicitacionesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beLicitaciones traerLicitaciones_x_IdLicitacion(SqlConnection Conexion,int IdLicitacion)
	{
		string sp = "Proc_Licitaciones_x_IdLicitacion";
				beLicitaciones obeLicitaciones=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
						int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
						int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
						int posIdEtapaLicitacion = datard.GetOrdinal("IdEtapaLicitacion");
						int posFolioOficial = datard.GetOrdinal("FolioOficial");
						int posMontoBases = datard.GetOrdinal("MontoBases");
						int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
						int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
						int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
						int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
						int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
						int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
						int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
						int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
						int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
						int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
						int posFechaFallo = datard.GetOrdinal("FechaFallo");
						int posHoraFallo = datard.GetOrdinal("HoraFallo");
						int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						int posIdTiempo = datard.GetOrdinal("IdTiempo");
						int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
						int posIdUnidadLicitadora = datard.GetOrdinal("IdUnidadLicitadora");
						int posIdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
						int posIdEstatusLicitacion = datard.GetOrdinal("IdEstatusLicitacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posTiempoPeriodoPujasHrs = datard.GetOrdinal("TiempoPeriodoPujasHrs");
						int posTiempoAdicionalPujasMin = datard.GetOrdinal("TiempoAdicionalPujasMin");
						int posTiempoEtapaFinalMin = datard.GetOrdinal("TiempoEtapaFinalMin");
						int posAplicaNomenclaturaInvolucrados = datard.GetOrdinal("AplicaNomenclaturaInvolucrados");
						int posMostrarMontoPropuestaGanando = datard.GetOrdinal("MostrarMontoPropuestaGanando");
						int posMostrarLugarProveedor = datard.GetOrdinal("MostrarLugarProveedor");
					 obeLicitaciones = new beLicitaciones();
				while (datard.Read())
					{
						obeLicitaciones.IdLicitacion =  datard.GetInt32(posIdLicitacion);
						obeLicitaciones.IdConfiguracionModalidad =  datard.GetInt32(posIdConfiguracionModalidad);
						obeLicitaciones.IdModalidadLicitacion =  datard.GetInt32(posIdModalidadLicitacion);
						obeLicitaciones.IdEtapaLicitacion =  datard.GetInt32(posIdEtapaLicitacion);
						obeLicitaciones.FolioOficial =  datard.GetString(posFolioOficial);
						obeLicitaciones.MontoBases =  datard.GetDecimal(posMontoBases);
						obeLicitaciones.NumeroLicitacion =  datard.GetInt32(posNumeroLicitacion);
						obeLicitaciones.FechaAutorizacion =  datard.GetDateTime(posFechaAutorizacion);
						obeLicitaciones.HoraAutorizacion =  datard.GetTimeSpan(posHoraAutorizacion);
						obeLicitaciones.FechaPublicacion =  datard.GetDateTime(posFechaPublicacion);
						obeLicitaciones.FechaDisposicionBases =  datard.GetDateTime(posFechaDisposicionBases);
						obeLicitaciones.FechaLimitePreguntas =  datard.GetDateTime(posFechaLimitePreguntas);
						obeLicitaciones.FechaLimiteRespuestas =  datard.GetDateTime(posFechaLimiteRespuestas);
						obeLicitaciones.FechaHoraAclaracionDudas =  datard.GetDateTime(posFechaHoraAclaracionDudas);
						obeLicitaciones.FechaEnvioPropuestasTecEco =  datard.GetDateTime(posFechaEnvioPropuestasTecEco);
						obeLicitaciones.FechaLimiteDictamen =  datard.GetDateTime(posFechaLimiteDictamen);
						obeLicitaciones.FechaFallo =  datard.GetDateTime(posFechaFallo);
						obeLicitaciones.HoraFallo =  datard.GetTimeSpan(posHoraFallo);
						obeLicitaciones.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
						obeLicitaciones.IdTiempo =  datard.GetInt32(posIdTiempo);
						obeLicitaciones.IdEjercicioFiscal =  datard.GetInt32(posIdEjercicioFiscal);
						obeLicitaciones.IdUnidadLicitadora =  datard.GetInt32(posIdUnidadLicitadora);
						obeLicitaciones.IdUsuarioRevisor =  datard.GetInt32(posIdUsuarioRevisor);
						obeLicitaciones.IdEstatusLicitacion =  datard.GetInt32(posIdEstatusLicitacion);
						obeLicitaciones.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeLicitaciones.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
						obeLicitaciones.TiempoPeriodoPujasHrs =  datard.GetInt32(posTiempoPeriodoPujasHrs);
						obeLicitaciones.TiempoAdicionalPujasMin =  datard.GetInt32(posTiempoAdicionalPujasMin);
						obeLicitaciones.TiempoEtapaFinalMin =  datard.GetInt32(posTiempoEtapaFinalMin);
						obeLicitaciones.AplicaNomenclaturaInvolucrados =  datard.GetBoolean(posAplicaNomenclaturaInvolucrados);
						obeLicitaciones.MostrarMontoPropuestaGanando =  datard.GetBoolean(posMostrarMontoPropuestaGanando);
						obeLicitaciones.MostrarLugarProveedor =  datard.GetBoolean(posMostrarLugarProveedor);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeLicitaciones;
			}
	}
	public List< beLicitaciones> listarTodos_Licitaciones(SqlConnection Conexion)
	 {
		string sp = "Proc_Licitaciones_Traer_Todos";
		List<beLicitaciones> lbeLicitaciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
						int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
						int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
						int posIdEtapaLicitacion = datard.GetOrdinal("IdEtapaLicitacion");
						int posFolioOficial = datard.GetOrdinal("FolioOficial");
						int posMontoBases = datard.GetOrdinal("MontoBases");
						int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
						int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
						int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
						int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
						int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
						int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
						int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
						int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
						int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
						int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
						int posFechaFallo = datard.GetOrdinal("FechaFallo");
						int posHoraFallo = datard.GetOrdinal("HoraFallo");
						int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						int posIdTiempo = datard.GetOrdinal("IdTiempo");
						int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
						int posIdUnidadLicitadora = datard.GetOrdinal("IdUnidadLicitadora");
						int posIdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
						int posIdEstatusLicitacion = datard.GetOrdinal("IdEstatusLicitacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posTiempoPeriodoPujasHrs = datard.GetOrdinal("TiempoPeriodoPujasHrs");
						int posTiempoAdicionalPujasMin = datard.GetOrdinal("TiempoAdicionalPujasMin");
						int posTiempoEtapaFinalMin = datard.GetOrdinal("TiempoEtapaFinalMin");
						int posAplicaNomenclaturaInvolucrados = datard.GetOrdinal("AplicaNomenclaturaInvolucrados");
						int posMostrarMontoPropuestaGanando = datard.GetOrdinal("MostrarMontoPropuestaGanando");
						int posMostrarLugarProveedor = datard.GetOrdinal("MostrarLugarProveedor");
				lbeLicitaciones = new List<beLicitaciones>();
				beLicitaciones obeLicitaciones;
				while (datard.Read())
				{
					 obeLicitaciones = new beLicitaciones();
					obeLicitaciones.IdLicitacion =  datard.GetInt32(posIdLicitacion);
					obeLicitaciones.IdConfiguracionModalidad =  datard.GetInt32(posIdConfiguracionModalidad);
					obeLicitaciones.IdModalidadLicitacion =  datard.GetInt32(posIdModalidadLicitacion);
					obeLicitaciones.IdEtapaLicitacion =  datard.GetInt32(posIdEtapaLicitacion);
					obeLicitaciones.FolioOficial =  datard.GetString(posFolioOficial);
					obeLicitaciones.MontoBases =  datard.GetDecimal(posMontoBases);
					obeLicitaciones.NumeroLicitacion =  datard.GetInt32(posNumeroLicitacion);
					obeLicitaciones.FechaAutorizacion =  datard.GetDateTime(posFechaAutorizacion);
					obeLicitaciones.HoraAutorizacion =  datard.GetTimeSpan(posHoraAutorizacion);
					obeLicitaciones.FechaPublicacion =  datard.GetDateTime(posFechaPublicacion);
					obeLicitaciones.FechaDisposicionBases =  datard.GetDateTime(posFechaDisposicionBases);
					obeLicitaciones.FechaLimitePreguntas =  datard.GetDateTime(posFechaLimitePreguntas);
					obeLicitaciones.FechaLimiteRespuestas =  datard.GetDateTime(posFechaLimiteRespuestas);
					obeLicitaciones.FechaHoraAclaracionDudas =  datard.GetDateTime(posFechaHoraAclaracionDudas);
					obeLicitaciones.FechaEnvioPropuestasTecEco =  datard.GetDateTime(posFechaEnvioPropuestasTecEco);
					obeLicitaciones.FechaLimiteDictamen =  datard.GetDateTime(posFechaLimiteDictamen);
					obeLicitaciones.FechaFallo =  datard.GetDateTime(posFechaFallo);
					obeLicitaciones.HoraFallo =  datard.GetTimeSpan(posHoraFallo);
					obeLicitaciones.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
					obeLicitaciones.IdTiempo =  datard.GetInt32(posIdTiempo);
					obeLicitaciones.IdEjercicioFiscal =  datard.GetInt32(posIdEjercicioFiscal);
					obeLicitaciones.IdUnidadLicitadora =  datard.GetInt32(posIdUnidadLicitadora);
					obeLicitaciones.IdUsuarioRevisor =  datard.GetInt32(posIdUsuarioRevisor);
					obeLicitaciones.IdEstatusLicitacion =  datard.GetInt32(posIdEstatusLicitacion);
					obeLicitaciones.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeLicitaciones.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeLicitaciones.TiempoPeriodoPujasHrs =  datard.GetInt32(posTiempoPeriodoPujasHrs);
					obeLicitaciones.TiempoAdicionalPujasMin =  datard.GetInt32(posTiempoAdicionalPujasMin);
					obeLicitaciones.TiempoEtapaFinalMin =  datard.GetInt32(posTiempoEtapaFinalMin);
					obeLicitaciones.AplicaNomenclaturaInvolucrados =  datard.GetBoolean(posAplicaNomenclaturaInvolucrados);
					obeLicitaciones.MostrarMontoPropuestaGanando =  datard.GetBoolean(posMostrarMontoPropuestaGanando);
					obeLicitaciones.MostrarLugarProveedor =  datard.GetBoolean(posMostrarLugarProveedor);
					lbeLicitaciones.Add(obeLicitaciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeLicitaciones;
		}
	}
	public List< beLicitaciones> listar_Licitaciones_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_Licitaciones_TraerTodos_GetAll";
		List<beLicitaciones> lbeLicitaciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
						int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
						int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
						int posIdEtapaLicitacion = datard.GetOrdinal("IdEtapaLicitacion");
						int posFolioOficial = datard.GetOrdinal("FolioOficial");
						int posMontoBases = datard.GetOrdinal("MontoBases");
						int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
						int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
						int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
						int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
						int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
						int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
						int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
						int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
						int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
						int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
						int posFechaFallo = datard.GetOrdinal("FechaFallo");
						int posHoraFallo = datard.GetOrdinal("HoraFallo");
						int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						int posIdTiempo = datard.GetOrdinal("IdTiempo");
						int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
						int posIdUnidadLicitadora = datard.GetOrdinal("IdUnidadLicitadora");
						int posIdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
						int posIdEstatusLicitacion = datard.GetOrdinal("IdEstatusLicitacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posTiempoPeriodoPujasHrs = datard.GetOrdinal("TiempoPeriodoPujasHrs");
						int posTiempoAdicionalPujasMin = datard.GetOrdinal("TiempoAdicionalPujasMin");
						int posTiempoEtapaFinalMin = datard.GetOrdinal("TiempoEtapaFinalMin");
						int posAplicaNomenclaturaInvolucrados = datard.GetOrdinal("AplicaNomenclaturaInvolucrados");
						int posMostrarMontoPropuestaGanando = datard.GetOrdinal("MostrarMontoPropuestaGanando");
						int posMostrarLugarProveedor = datard.GetOrdinal("MostrarLugarProveedor");
				lbeLicitaciones = new List<beLicitaciones>();
				beLicitaciones obeLicitaciones;
				while (datard.Read())
				{
					 obeLicitaciones = new beLicitaciones();
					obeLicitaciones.IdLicitacion =  datard.GetInt32(posIdLicitacion);
					obeLicitaciones.IdConfiguracionModalidad =  datard.GetInt32(posIdConfiguracionModalidad);
					obeLicitaciones.IdModalidadLicitacion =  datard.GetInt32(posIdModalidadLicitacion);
					obeLicitaciones.IdEtapaLicitacion =  datard.GetInt32(posIdEtapaLicitacion);
					obeLicitaciones.FolioOficial =  datard.GetString(posFolioOficial);
					obeLicitaciones.MontoBases =  datard.GetDecimal(posMontoBases);
					obeLicitaciones.NumeroLicitacion =  datard.GetInt32(posNumeroLicitacion);
					obeLicitaciones.FechaAutorizacion =  datard.GetDateTime(posFechaAutorizacion);
					obeLicitaciones.HoraAutorizacion =  datard.GetTimeSpan(posHoraAutorizacion);
					obeLicitaciones.FechaPublicacion =  datard.GetDateTime(posFechaPublicacion);
					obeLicitaciones.FechaDisposicionBases =  datard.GetDateTime(posFechaDisposicionBases);
					obeLicitaciones.FechaLimitePreguntas =  datard.GetDateTime(posFechaLimitePreguntas);
					obeLicitaciones.FechaLimiteRespuestas =  datard.GetDateTime(posFechaLimiteRespuestas);
					obeLicitaciones.FechaHoraAclaracionDudas =  datard.GetDateTime(posFechaHoraAclaracionDudas);
					obeLicitaciones.FechaEnvioPropuestasTecEco =  datard.GetDateTime(posFechaEnvioPropuestasTecEco);
					obeLicitaciones.FechaLimiteDictamen =  datard.GetDateTime(posFechaLimiteDictamen);
					obeLicitaciones.FechaFallo =  datard.GetDateTime(posFechaFallo);
					obeLicitaciones.HoraFallo =  datard.GetTimeSpan(posHoraFallo);
					obeLicitaciones.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
					obeLicitaciones.IdTiempo =  datard.GetInt32(posIdTiempo);
					obeLicitaciones.IdEjercicioFiscal =  datard.GetInt32(posIdEjercicioFiscal);
					obeLicitaciones.IdUnidadLicitadora =  datard.GetInt32(posIdUnidadLicitadora);
					obeLicitaciones.IdUsuarioRevisor =  datard.GetInt32(posIdUsuarioRevisor);
					obeLicitaciones.IdEstatusLicitacion =  datard.GetInt32(posIdEstatusLicitacion);
					obeLicitaciones.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeLicitaciones.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeLicitaciones.TiempoPeriodoPujasHrs =  datard.GetInt32(posTiempoPeriodoPujasHrs);
					obeLicitaciones.TiempoAdicionalPujasMin =  datard.GetInt32(posTiempoAdicionalPujasMin);
					obeLicitaciones.TiempoEtapaFinalMin =  datard.GetInt32(posTiempoEtapaFinalMin);
					obeLicitaciones.AplicaNomenclaturaInvolucrados =  datard.GetBoolean(posAplicaNomenclaturaInvolucrados);
					obeLicitaciones.MostrarMontoPropuestaGanando =  datard.GetBoolean(posMostrarMontoPropuestaGanando);
					obeLicitaciones.MostrarLugarProveedor =  datard.GetBoolean(posMostrarLugarProveedor);
			// debe agregar campos de la Vista
					lbeLicitaciones.Add(obeLicitaciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeLicitaciones;
		}
	}
        public beLicitaciones traerLicitaciones_x_Fecha_IdGobierno(SqlConnection Conexion,DateTime fechaAutorizacion, int IdGobierno,int IdTipoLicitacion,int IdTiempo,int IdModalidadLicitacion)
        {
//            @IdTipoLicitacion int = 1,
//@IdTiempo  int = 1,
//@IdModalidadLicitacion int = 1

            string sp = "Proc_LicitacionCedulaProgramacion";
            beLicitaciones obeLicitaciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FechaAutorizacion", SqlDbType.DateTime).Value = fechaAutorizacion;
            cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = IdGobierno;
            cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = IdTipoLicitacion;
            cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = IdTiempo;
            cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = IdModalidadLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
                        int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posIdEtapaLicitacion = datard.GetOrdinal("IdEtapaLicitacion");
                        int posFolioOficial = datard.GetOrdinal("FolioOficial");
                        int posMontoBases = datard.GetOrdinal("MontoBases");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
                        int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
                        int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
                        int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
                        int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
                        int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
                        int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
                        int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
                        int posFechaFallo = datard.GetOrdinal("FechaFallo");
                        int posHoraFallo = datard.GetOrdinal("HoraFallo");
                        int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
                        int posIdTiempo = datard.GetOrdinal("IdTiempo");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posIdUnidadLicitadora = datard.GetOrdinal("IdUnidadLicitadora");
                        int posIdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
                        int posIdEstatusLicitacion = datard.GetOrdinal("IdEstatusLicitacion");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posTiempoPeriodoPujasHrs = datard.GetOrdinal("TiempoPeriodoPujasHrs");
                        int posTiempoAdicionalPujasMin = datard.GetOrdinal("TiempoAdicionalPujasMin");
                        int posTiempoEtapaFinalMin = datard.GetOrdinal("TiempoEtapaFinalMin");
                        int posAplicaNomenclaturaInvolucrados = datard.GetOrdinal("AplicaNomenclaturaInvolucrados");
                        int posMostrarMontoPropuestaGanando = datard.GetOrdinal("MostrarMontoPropuestaGanando");
                        int posMostrarLugarProveedor = datard.GetOrdinal("MostrarLugarProveedor");
                        obeLicitaciones = new beLicitaciones();
                        while (datard.Read())
                        {
                            obeLicitaciones.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            obeLicitaciones.IdConfiguracionModalidad = datard.GetInt32(posIdConfiguracionModalidad);
                            obeLicitaciones.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeLicitaciones.IdEtapaLicitacion = datard.GetInt32(posIdEtapaLicitacion);
                            obeLicitaciones.FolioOficial = datard.GetString(posFolioOficial);
                            obeLicitaciones.MontoBases = datard.GetDecimal(posMontoBases);
                            obeLicitaciones.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            obeLicitaciones.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            //obeLicitaciones.HoraAutorizacion = datard.GetTimeSpan(posHoraAutorizacion);
                            //obeLicitaciones.HoraAutorizacion = datard.GetString(posHoraAutorizacion);
                            obeLicitaciones.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
                            obeLicitaciones.FechaDisposicionBases = datard.GetDateTime(posFechaDisposicionBases);
                            obeLicitaciones.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
                            obeLicitaciones.FechaLimiteRespuestas = datard.GetDateTime(posFechaLimiteRespuestas);
                            obeLicitaciones.FechaHoraAclaracionDudas = datard.GetDateTime(posFechaHoraAclaracionDudas);
                            obeLicitaciones.FechaEnvioPropuestasTecEco = datard.GetDateTime(posFechaEnvioPropuestasTecEco);
                            obeLicitaciones.FechaLimiteDictamen = datard.GetDateTime(posFechaLimiteDictamen);
                            obeLicitaciones.FechaFallo = datard.GetDateTime(posFechaFallo);
                            obeLicitaciones.HoraFallo = datard.GetTimeSpan(posHoraFallo);
                            obeLicitaciones.IdTipoLicitacion = datard.GetInt32(posIdTipoLicitacion);
                            obeLicitaciones.IdTiempo = datard.GetInt32(posIdTiempo);
                            obeLicitaciones.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obeLicitaciones.IdUnidadLicitadora = datard.GetInt32(posIdUnidadLicitadora);
                            obeLicitaciones.IdUsuarioRevisor = datard.GetInt32(posIdUsuarioRevisor);
                            obeLicitaciones.IdEstatusLicitacion = datard.GetInt32(posIdEstatusLicitacion);
                            obeLicitaciones.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeLicitaciones.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeLicitaciones.TiempoPeriodoPujasHrs = datard.GetInt32(posTiempoPeriodoPujasHrs);
                            obeLicitaciones.TiempoAdicionalPujasMin = datard.GetInt32(posTiempoAdicionalPujasMin);
                            obeLicitaciones.TiempoEtapaFinalMin = datard.GetInt32(posTiempoEtapaFinalMin);
                            obeLicitaciones.AplicaNomenclaturaInvolucrados = datard.GetBoolean(posAplicaNomenclaturaInvolucrados);
                            obeLicitaciones.MostrarMontoPropuestaGanando = datard.GetBoolean(posMostrarMontoPropuestaGanando);
                            obeLicitaciones.MostrarLugarProveedor = datard.GetBoolean(posMostrarLugarProveedor);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }
        public beErrorProceso GenerarActaAdjudicacionProveedores(SqlConnection Conexion, int pIdLicitacion)
        {
            string sp = "Proc_GenerarActaAdjudicacionProveedores_IdLicitacion";
            beErrorProceso error = new beErrorProceso();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posSuccess = datard.GetOrdinal("Success");
                        int errMessage = datard.GetOrdinal("errMessage");

                        while (datard.Read())
                        {
                            error.obeLicitaciones = datard.GetBoolean(posSuccess);
                            error.errMessage = datard[errMessage] == DBNull.Value?"": datard.GetString(errMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return error;
            }
        }
        public beErrorProceso GenerarPedidosLicitaciones_x_IdLicitacion(SqlConnection Conexion, int pIdLicitacion)
        {
            string sp = "GenerarPedidosLicitaciones_x_IdLicitacion";
            beErrorProceso error = new beErrorProceso();
             SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posSuccess = datard.GetOrdinal("Success");
                        int errMessage = datard.GetOrdinal("errMessage");
                        while (datard.Read())
                        {
                            error.obeLicitaciones = datard.GetBoolean(posSuccess);
                            error.errMessage = datard[errMessage] == DBNull.Value ? "" : datard.GetString(errMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return error;
            }
        }
        public beErrorProceso GenerarPedido_x_IdLicitacion(SqlConnection Conexion, int pIdLicitacion)
        {
            string sp = "Proc_GenerarPedidosRequisiciones_x_IdLicitacion";
            beErrorProceso error = new beErrorProceso();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posSuccess = datard.GetOrdinal("Success");
                        int errMessage = datard.GetOrdinal("errMessage");

                        while (datard.Read())
                        {
                            error.obeLicitaciones = datard.GetBoolean(posSuccess);
                            error.errMessage = datard[errMessage] ==DBNull.Value?"": datard.GetString(errMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return error;
            }
        }
        public beErrorProceso GenerarActaDictamen_Publicar_x_IdLicitacion(SqlConnection Conexion, int pIdLicitacion,int pIdEstatusLicitacion)
        {
            string sp = "Proc_LicitacionesActualizarEstatus_x_IdLicitacionEstatus";
            beErrorProceso error = new beErrorProceso();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;
            cmd.Parameters.Add("@IdEstatusLicicitacion", SqlDbType.Int).Value = pIdEstatusLicitacion;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posSuccess = datard.GetOrdinal("Success");
                        int errMessage = datard.GetOrdinal("errMessage");

                        while (datard.Read())
                        {
                            error.obeLicitaciones = datard.GetBoolean(posSuccess);
                            error.errMessage = datard[errMessage] == DBNull.Value ? "" : datard.GetString(errMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return error;
            }
        }
        public beErrorProceso GenerarRequisionesSegundaLicitacion_x_IdLicitacion(SqlConnection Conexion, int pIdLicitacion)
        {
            string sp = "Proc_GenerarRequisionesSegundaLicitacion_x_IdLicitacion";
            beErrorProceso error = new beErrorProceso();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posSuccess = datard.GetOrdinal("Success");
                        int errMessage = datard.GetOrdinal("errMessage");

                        while (datard.Read())
                        {
                            error.obeLicitaciones = datard.GetBoolean(posSuccess);
                            error.errMessage = datard[errMessage] == DBNull.Value ? "" : datard.GetString(errMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return error;
            }
        }
    }
}
