using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicaciones
 {
	public int guardarAdjudicaciones(SqlConnection Conexion, beAdjudicaciones obeAdjudicaciones)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicaciones.IdAdjudicacion;
				cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeAdjudicaciones.IdDependencia;
				cmd.Parameters.Add("@IdTipoAdjudicacion", SqlDbType.Int).Value = obeAdjudicaciones.IdTipoAdjudicacion;
				cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = obeAdjudicaciones.IdTipoSolicitud;
				cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeAdjudicaciones.IdOrigenRecurso;
				cmd.Parameters.Add("@IdOrigenRecursoAutorizado", SqlDbType.Int).Value = obeAdjudicaciones.IdOrigenRecursoAutorizado;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeAdjudicaciones.IdEstatus;
				cmd.Parameters.Add("@IdEstatusAdjudicacion", SqlDbType.Int).Value = obeAdjudicaciones.IdEstatusAdjudicacion;
				cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obeAdjudicaciones.IdPartida;
				cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obeAdjudicaciones.IdEjercicioFiscal;
				cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = obeAdjudicaciones.IdPresupuestoPartida;
				cmd.Parameters.Add("@FechaAdjudicacion", SqlDbType.DateTime).Value = obeAdjudicaciones.FechaAdjudicacion;
				cmd.Parameters.Add("@AdjudicacionFolio", SqlDbType.NVarChar).Value = obeAdjudicaciones.AdjudicacionFolio;
				cmd.Parameters.Add("@ConsecutivoAdjudicacion", SqlDbType.Int).Value = obeAdjudicaciones.ConsecutivoAdjudicacion;
				cmd.Parameters.Add("@NumeroOficioSolicitud", SqlDbType.VarChar).Value = obeAdjudicaciones.NumeroOficioSolicitud;
				cmd.Parameters.Add("@NumeroOficioCertificacion", SqlDbType.VarChar).Value = obeAdjudicaciones.NumeroOficioCertificacion;
				cmd.Parameters.Add("@MontoAproximado", SqlDbType.Decimal).Value = obeAdjudicaciones.MontoAproximado;
				cmd.Parameters.Add("@MontoAproximadoAutorizado", SqlDbType.Decimal).Value = obeAdjudicaciones.MontoAproximadoAutorizado;
				cmd.Parameters.Add("@CantidadLotes", SqlDbType.Int).Value = obeAdjudicaciones.CantidadLotes;
				cmd.Parameters.Add("@ImporteTotalLotes", SqlDbType.Decimal).Value = obeAdjudicaciones.ImporteTotalLotes;
				cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeAdjudicaciones.Observaciones;
				cmd.Parameters.Add("@Justificacion", SqlDbType.VarChar).Value = obeAdjudicaciones.Justificacion;
				cmd.Parameters.Add("@SaldoPartida", SqlDbType.Decimal).Value = obeAdjudicaciones.SaldoPartida;
				cmd.Parameters.Add("@MontoPresupuestado", SqlDbType.Decimal).Value = obeAdjudicaciones.MontoPresupuestado;
                cmd.Parameters.Add("@TotalLiquidez", SqlDbType.Decimal).Value = obeAdjudicaciones.TotalLiquidez;
				cmd.Parameters.Add("@IdUsuarioAsignante", SqlDbType.Int).Value = obeAdjudicaciones.IdUsuarioAsignante;
				cmd.Parameters.Add("@Acepta2daLicitacion", SqlDbType.Int).Value = obeAdjudicaciones.Acepta2daLicitacion;
				cmd.Parameters.Add("@IdUsuarioRevisor", SqlDbType.Int).Value = obeAdjudicaciones.IdUsuarioRevisor;
				cmd.Parameters.Add("@FechaAsignaRevisor", SqlDbType.DateTime).Value = obeAdjudicaciones.FechaAsignaRevisor;
				cmd.Parameters.Add("@FechaAutorizacion", SqlDbType.DateTime).Value = obeAdjudicaciones.FechaAutorizacion;
				cmd.Parameters.Add("@Economia", SqlDbType.Decimal).Value = obeAdjudicaciones.Economia;
				cmd.Parameters.Add("@Ejercido", SqlDbType.Decimal).Value = obeAdjudicaciones.Ejercido;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicaciones.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicaciones.FechaRegistro;
                cmd.Parameters.Add("@AcuerdoAutorizacionComite", SqlDbType.Text).Value = obeAdjudicaciones.AcuerdoAutorizacionComite;
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicaciones(SqlConnection Conexion, beAdjudicaciones obeAdjudicaciones)
	{
		string sp = "Proc_AdjudicacionesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicaciones.IdAdjudicacion;
				cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeAdjudicaciones.IdDependencia;
				cmd.Parameters.Add("@IdTipoAdjudicacion", SqlDbType.Int).Value = obeAdjudicaciones.IdTipoAdjudicacion;
				cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = obeAdjudicaciones.IdTipoSolicitud;
				cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeAdjudicaciones.IdOrigenRecurso;
				cmd.Parameters.Add("@IdOrigenRecursoAutorizado", SqlDbType.Int).Value = obeAdjudicaciones.IdOrigenRecursoAutorizado;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeAdjudicaciones.IdEstatus;
				cmd.Parameters.Add("@IdEstatusAdjudicacion", SqlDbType.Int).Value = obeAdjudicaciones.IdEstatusAdjudicacion;
				cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obeAdjudicaciones.IdPartida;
				cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obeAdjudicaciones.IdEjercicioFiscal;
				cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = obeAdjudicaciones.IdPresupuestoPartida;
				cmd.Parameters.Add("@FechaAdjudicacion", SqlDbType.DateTime).Value = obeAdjudicaciones.FechaAdjudicacion;
				cmd.Parameters.Add("@AdjudicacionFolio", SqlDbType.NVarChar).Value = obeAdjudicaciones.AdjudicacionFolio;
				cmd.Parameters.Add("@ConsecutivoAdjudicacion", SqlDbType.Int).Value = obeAdjudicaciones.ConsecutivoAdjudicacion;
				cmd.Parameters.Add("@NumeroOficioSolicitud", SqlDbType.VarChar).Value = obeAdjudicaciones.NumeroOficioSolicitud;
				cmd.Parameters.Add("@NumeroOficioCertificacion", SqlDbType.VarChar).Value = obeAdjudicaciones.NumeroOficioCertificacion;
				cmd.Parameters.Add("@MontoAproximado", SqlDbType.Decimal).Value = obeAdjudicaciones.MontoAproximado;
				cmd.Parameters.Add("@MontoAproximadoAutorizado", SqlDbType.Decimal).Value = obeAdjudicaciones.MontoAproximadoAutorizado;
				cmd.Parameters.Add("@CantidadLotes", SqlDbType.Int).Value = obeAdjudicaciones.CantidadLotes;
				cmd.Parameters.Add("@ImporteTotalLotes", SqlDbType.Decimal).Value = obeAdjudicaciones.ImporteTotalLotes;
				cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeAdjudicaciones.Observaciones;
				cmd.Parameters.Add("@Justificacion", SqlDbType.VarChar).Value = obeAdjudicaciones.Justificacion;
				cmd.Parameters.Add("@SaldoPartida", SqlDbType.Decimal).Value = obeAdjudicaciones.SaldoPartida;
				cmd.Parameters.Add("@MontoPresupuestado", SqlDbType.Decimal).Value = obeAdjudicaciones.MontoPresupuestado;
                cmd.Parameters.Add("@TotalLiquidez", SqlDbType.Decimal).Value = obeAdjudicaciones.TotalLiquidez;
                cmd.Parameters.Add("@IdUsuarioAsignante", SqlDbType.Int).Value = obeAdjudicaciones.IdUsuarioAsignante;
				cmd.Parameters.Add("@Acepta2daLicitacion", SqlDbType.Int).Value = obeAdjudicaciones.Acepta2daLicitacion;
				cmd.Parameters.Add("@IdUsuarioRevisor", SqlDbType.Int).Value = obeAdjudicaciones.IdUsuarioRevisor;
				cmd.Parameters.Add("@FechaAsignaRevisor", SqlDbType.DateTime).Value = obeAdjudicaciones.FechaAsignaRevisor;
				cmd.Parameters.Add("@FechaAutorizacion", SqlDbType.DateTime).Value = obeAdjudicaciones.FechaAutorizacion;
				cmd.Parameters.Add("@Economia", SqlDbType.Decimal).Value = obeAdjudicaciones.Economia;
				cmd.Parameters.Add("@Ejercido", SqlDbType.Decimal).Value = obeAdjudicaciones.Ejercido;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicaciones.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicaciones.FechaRegistro;
                cmd.Parameters.Add("@AcuerdoAutorizacionComite", SqlDbType.Text).Value = obeAdjudicaciones.AcuerdoAutorizacionComite;

                    cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicaciones(SqlConnection Conexion,int pIdAdjudicacion)
	{
		string sp = "Proc_AdjudicacionesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = pIdAdjudicacion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicaciones traerAdjudicaciones_x_IdAdjudicacion(SqlConnection Conexion,int IdAdjudicacion)
	{
		string sp = "Proc_Adjudicaciones_x_IdAdjudicacion";
				beAdjudicaciones obeAdjudicaciones=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdDependencia = datard.GetOrdinal("IdDependencia");
						int posIdTipoAdjudicacion = datard.GetOrdinal("IdTipoAdjudicacion");
						int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
						int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
						int posIdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posIdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
						int posIdPartida = datard.GetOrdinal("IdPartida");
						int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
						int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
						int posFechaAdjudicacion = datard.GetOrdinal("FechaAdjudicacion");
						int posAdjudicacionFolio = datard.GetOrdinal("AdjudicacionFolio");
						int posConsecutivoAdjudicacion = datard.GetOrdinal("ConsecutivoAdjudicacion");
						int posNumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
						int posNumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
						int posMontoAproximado = datard.GetOrdinal("MontoAproximado");
						int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
						int posCantidadLotes = datard.GetOrdinal("CantidadLotes");
						int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posJustificacion = datard.GetOrdinal("Justificacion");
						int posSaldoPartida = datard.GetOrdinal("SaldoPartida");
						int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                        int posTotalLiquidez = datard.GetOrdinal("TotalLiquidez");
						int posIdUsuarioAsignante = datard.GetOrdinal("IdUsuarioAsignante");
						int posAcepta2daLicitacion = datard.GetOrdinal("Acepta2daLicitacion");
						int posIdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
						int posFechaAsignaRevisor = datard.GetOrdinal("FechaAsignaRevisor");
						int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
						int posEconomia = datard.GetOrdinal("Economia");
						int posEjercido = datard.GetOrdinal("Ejercido");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posAcuerdoAutorizacionComite = datard.GetOrdinal("AcuerdoAutorizacionComite");

                        obeAdjudicaciones = new beAdjudicaciones();
				while (datard.Read())
					{
						obeAdjudicaciones.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
						obeAdjudicaciones.IdDependencia =  datard.GetInt32(posIdDependencia);
						obeAdjudicaciones.IdTipoAdjudicacion =  datard.GetInt32(posIdTipoAdjudicacion);
						obeAdjudicaciones.IdTipoSolicitud =  datard.GetInt32(posIdTipoSolicitud);
						obeAdjudicaciones.IdOrigenRecurso =  datard.GetInt32(posIdOrigenRecurso);
						obeAdjudicaciones.IdOrigenRecursoAutorizado =  datard.GetInt32(posIdOrigenRecursoAutorizado);
						obeAdjudicaciones.IdEstatus =  datard.GetInt32(posIdEstatus);
						obeAdjudicaciones.IdEstatusAdjudicacion =  datard.GetInt32(posIdEstatusAdjudicacion);
						obeAdjudicaciones.IdPartida =  datard.GetInt32(posIdPartida);
						obeAdjudicaciones.IdEjercicioFiscal =  datard.GetInt32(posIdEjercicioFiscal);
						obeAdjudicaciones.IdPresupuestoPartida =  datard.GetInt32(posIdPresupuestoPartida);
						obeAdjudicaciones.FechaAdjudicacion =  datard.GetDateTime(posFechaAdjudicacion);
						obeAdjudicaciones.AdjudicacionFolio =  datard.GetString(posAdjudicacionFolio);
						obeAdjudicaciones.ConsecutivoAdjudicacion =  datard.GetInt32(posConsecutivoAdjudicacion);
						obeAdjudicaciones.NumeroOficioSolicitud =  datard.GetString(posNumeroOficioSolicitud);
						obeAdjudicaciones.NumeroOficioCertificacion =  datard.GetString(posNumeroOficioCertificacion);
						obeAdjudicaciones.MontoAproximado =  datard.GetDecimal(posMontoAproximado);
						obeAdjudicaciones.MontoAproximadoAutorizado =  datard.GetDecimal(posMontoAproximadoAutorizado);
						obeAdjudicaciones.CantidadLotes =  datard.GetInt32(posCantidadLotes);
						obeAdjudicaciones.ImporteTotalLotes =  datard.GetDecimal(posImporteTotalLotes);
						obeAdjudicaciones.Observaciones =  datard.GetString(posObservaciones);
						obeAdjudicaciones.Justificacion =  datard.GetString(posJustificacion);
						obeAdjudicaciones.SaldoPartida =  datard.GetDecimal(posSaldoPartida);
						obeAdjudicaciones.MontoPresupuestado =  datard.GetDecimal(posMontoPresupuestado);
                        obeAdjudicaciones.TotalLiquidez = datard.GetDecimal(posTotalLiquidez);
						obeAdjudicaciones.IdUsuarioAsignante =  datard.GetInt32(posIdUsuarioAsignante);
						obeAdjudicaciones.Acepta2daLicitacion =  datard.GetInt32(posAcepta2daLicitacion);
						obeAdjudicaciones.IdUsuarioRevisor =  datard.GetInt32(posIdUsuarioRevisor);
						obeAdjudicaciones.FechaAsignaRevisor =  datard.GetDateTime(posFechaAsignaRevisor);
						obeAdjudicaciones.FechaAutorizacion =  datard.GetDateTime(posFechaAutorizacion);
						obeAdjudicaciones.Economia =  datard.GetDecimal(posEconomia);
						obeAdjudicaciones.Ejercido =  datard.GetDecimal(posEjercido);
						obeAdjudicaciones.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeAdjudicaciones.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
                        obeAdjudicaciones.AcuerdoAutorizacionComite = datard.GetString(posAcuerdoAutorizacionComite);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicaciones;
			}
	}
	public List< beAdjudicaciones> listarTodos_Adjudicaciones(SqlConnection Conexion)
	 {
		string sp = "Proc_Adjudicaciones_Traer_Todos";
		List<beAdjudicaciones> lbeAdjudicaciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdDependencia = datard.GetOrdinal("IdDependencia");
						int posIdTipoAdjudicacion = datard.GetOrdinal("IdTipoAdjudicacion");
						int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
						int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
						int posIdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posIdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
						int posIdPartida = datard.GetOrdinal("IdPartida");
						int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
						int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
						int posFechaAdjudicacion = datard.GetOrdinal("FechaAdjudicacion");
						int posAdjudicacionFolio = datard.GetOrdinal("AdjudicacionFolio");
						int posConsecutivoAdjudicacion = datard.GetOrdinal("ConsecutivoAdjudicacion");
						int posNumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
						int posNumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
						int posMontoAproximado = datard.GetOrdinal("MontoAproximado");
						int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
						int posCantidadLotes = datard.GetOrdinal("CantidadLotes");
						int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posJustificacion = datard.GetOrdinal("Justificacion");
						int posSaldoPartida = datard.GetOrdinal("SaldoPartida");
						int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                        int posTotalLiquidez = datard.GetOrdinal("TotalLiquidez");
                        int posIdUsuarioAsignante = datard.GetOrdinal("IdUsuarioAsignante");
						int posAcepta2daLicitacion = datard.GetOrdinal("Acepta2daLicitacion");
						int posIdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
						int posFechaAsignaRevisor = datard.GetOrdinal("FechaAsignaRevisor");
						int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
						int posEconomia = datard.GetOrdinal("Economia");
						int posEjercido = datard.GetOrdinal("Ejercido");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posAcuerdoAutorizacionComite = datard.GetOrdinal("AcuerdoAutorizacionComite");

                        lbeAdjudicaciones = new List<beAdjudicaciones>();
				beAdjudicaciones obeAdjudicaciones;
				while (datard.Read())
				{
					 obeAdjudicaciones = new beAdjudicaciones();
					obeAdjudicaciones.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicaciones.IdDependencia =  datard.GetInt32(posIdDependencia);
					obeAdjudicaciones.IdTipoAdjudicacion =  datard.GetInt32(posIdTipoAdjudicacion);
					obeAdjudicaciones.IdTipoSolicitud =  datard.GetInt32(posIdTipoSolicitud);
					obeAdjudicaciones.IdOrigenRecurso =  datard.GetInt32(posIdOrigenRecurso);
					obeAdjudicaciones.IdOrigenRecursoAutorizado =  datard.GetInt32(posIdOrigenRecursoAutorizado);
					obeAdjudicaciones.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeAdjudicaciones.IdEstatusAdjudicacion =  datard.GetInt32(posIdEstatusAdjudicacion);
					obeAdjudicaciones.IdPartida =  datard.GetInt32(posIdPartida);
					obeAdjudicaciones.IdEjercicioFiscal =  datard.GetInt32(posIdEjercicioFiscal);
					obeAdjudicaciones.IdPresupuestoPartida =  datard.GetInt32(posIdPresupuestoPartida);
					obeAdjudicaciones.FechaAdjudicacion =  datard.GetDateTime(posFechaAdjudicacion);
					obeAdjudicaciones.AdjudicacionFolio =  datard.GetString(posAdjudicacionFolio);
					obeAdjudicaciones.ConsecutivoAdjudicacion =  datard.GetInt32(posConsecutivoAdjudicacion);
					obeAdjudicaciones.NumeroOficioSolicitud =  datard.GetString(posNumeroOficioSolicitud);
					obeAdjudicaciones.NumeroOficioCertificacion =  datard.GetString(posNumeroOficioCertificacion);
					obeAdjudicaciones.MontoAproximado =  datard.GetDecimal(posMontoAproximado);
					obeAdjudicaciones.MontoAproximadoAutorizado =  datard.GetDecimal(posMontoAproximadoAutorizado);
					obeAdjudicaciones.CantidadLotes =  datard.GetInt32(posCantidadLotes);
					obeAdjudicaciones.ImporteTotalLotes =  datard.GetDecimal(posImporteTotalLotes);
					obeAdjudicaciones.Observaciones =  datard.GetString(posObservaciones);
					obeAdjudicaciones.Justificacion =  datard.GetString(posJustificacion);
					obeAdjudicaciones.SaldoPartida =  datard.GetDecimal(posSaldoPartida);
				    obeAdjudicaciones.MontoPresupuestado =  datard.GetDecimal(posMontoPresupuestado);
                    obeAdjudicaciones.TotalLiquidez = datard.GetDecimal(posTotalLiquidez);
                    obeAdjudicaciones.IdUsuarioAsignante =  datard.GetInt32(posIdUsuarioAsignante);
					obeAdjudicaciones.Acepta2daLicitacion =  datard.GetInt32(posAcepta2daLicitacion);
					obeAdjudicaciones.IdUsuarioRevisor =  datard.GetInt32(posIdUsuarioRevisor);
					obeAdjudicaciones.FechaAsignaRevisor =  datard.GetDateTime(posFechaAsignaRevisor);
					obeAdjudicaciones.FechaAutorizacion =  datard.GetDateTime(posFechaAutorizacion);
					obeAdjudicaciones.Economia =  datard.GetDecimal(posEconomia);
					obeAdjudicaciones.Ejercido =  datard.GetDecimal(posEjercido);
					obeAdjudicaciones.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeAdjudicaciones.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
                    obeAdjudicaciones.AcuerdoAutorizacionComite = datard.GetString(posAcuerdoAutorizacionComite);

                            lbeAdjudicaciones.Add(obeAdjudicaciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicaciones;
		}
	}
	public List< beAdjudicaciones> listar_Adjudicaciones_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_Adjudicaciones_TraerTodos_GetAll";
		List<beAdjudicaciones> lbeAdjudicaciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdDependencia = datard.GetOrdinal("IdDependencia");
						int posIdTipoAdjudicacion = datard.GetOrdinal("IdTipoAdjudicacion");
						int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
						int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
						int posIdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posIdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
						int posIdPartida = datard.GetOrdinal("IdPartida");
						int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
						int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
						int posFechaAdjudicacion = datard.GetOrdinal("FechaAdjudicacion");
						int posAdjudicacionFolio = datard.GetOrdinal("AdjudicacionFolio");
						int posConsecutivoAdjudicacion = datard.GetOrdinal("ConsecutivoAdjudicacion");
						int posNumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
						int posNumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
						int posMontoAproximado = datard.GetOrdinal("MontoAproximado");
						int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
						int posCantidadLotes = datard.GetOrdinal("CantidadLotes");
						int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posJustificacion = datard.GetOrdinal("Justificacion");
						int posSaldoPartida = datard.GetOrdinal("SaldoPartida");
						int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                        int posTotalLiquidez = datard.GetOrdinal("TotalLiquidez");
                        int posIdUsuarioAsignante = datard.GetOrdinal("IdUsuarioAsignante");
						int posAcepta2daLicitacion = datard.GetOrdinal("Acepta2daLicitacion");
						int posIdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
						int posFechaAsignaRevisor = datard.GetOrdinal("FechaAsignaRevisor");
						int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
						int posEconomia = datard.GetOrdinal("Economia");
						int posEjercido = datard.GetOrdinal("Ejercido");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posAcuerdoAutorizacionComite = datard.GetOrdinal("AcuerdoAutorizacionComite");

                        lbeAdjudicaciones = new List<beAdjudicaciones>();
				beAdjudicaciones obeAdjudicaciones;
				while (datard.Read())
				{
					 obeAdjudicaciones = new beAdjudicaciones();
					obeAdjudicaciones.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicaciones.IdDependencia =  datard.GetInt32(posIdDependencia);
					obeAdjudicaciones.IdTipoAdjudicacion =  datard.GetInt32(posIdTipoAdjudicacion);
					obeAdjudicaciones.IdTipoSolicitud =  datard.GetInt32(posIdTipoSolicitud);
					obeAdjudicaciones.IdOrigenRecurso =  datard.GetInt32(posIdOrigenRecurso);
					obeAdjudicaciones.IdOrigenRecursoAutorizado =  datard.GetInt32(posIdOrigenRecursoAutorizado);
					obeAdjudicaciones.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeAdjudicaciones.IdEstatusAdjudicacion =  datard.GetInt32(posIdEstatusAdjudicacion);
					obeAdjudicaciones.IdPartida =  datard.GetInt32(posIdPartida);
					obeAdjudicaciones.IdEjercicioFiscal =  datard.GetInt32(posIdEjercicioFiscal);
					obeAdjudicaciones.IdPresupuestoPartida =  datard.GetInt32(posIdPresupuestoPartida);
					obeAdjudicaciones.FechaAdjudicacion =  datard.GetDateTime(posFechaAdjudicacion);
					obeAdjudicaciones.AdjudicacionFolio =  datard.GetString(posAdjudicacionFolio);
					obeAdjudicaciones.ConsecutivoAdjudicacion =  datard.GetInt32(posConsecutivoAdjudicacion);
					obeAdjudicaciones.NumeroOficioSolicitud =  datard.GetString(posNumeroOficioSolicitud);
					obeAdjudicaciones.NumeroOficioCertificacion =  datard.GetString(posNumeroOficioCertificacion);
					obeAdjudicaciones.MontoAproximado =  datard.GetDecimal(posMontoAproximado);
					obeAdjudicaciones.MontoAproximadoAutorizado =  datard.GetDecimal(posMontoAproximadoAutorizado);
					obeAdjudicaciones.CantidadLotes =  datard.GetInt32(posCantidadLotes);
					obeAdjudicaciones.ImporteTotalLotes =  datard.GetDecimal(posImporteTotalLotes);
					obeAdjudicaciones.Observaciones =  datard.GetString(posObservaciones);
					obeAdjudicaciones.Justificacion =  datard.GetString(posJustificacion);
					obeAdjudicaciones.SaldoPartida =  datard.GetDecimal(posSaldoPartida);
					obeAdjudicaciones.MontoPresupuestado =  datard.GetDecimal(posMontoPresupuestado);
                    obeAdjudicaciones.TotalLiquidez = datard.GetDecimal(posTotalLiquidez);
                    obeAdjudicaciones.IdUsuarioAsignante =  datard.GetInt32(posIdUsuarioAsignante);
					obeAdjudicaciones.Acepta2daLicitacion =  datard.GetInt32(posAcepta2daLicitacion);
					obeAdjudicaciones.IdUsuarioRevisor =  datard.GetInt32(posIdUsuarioRevisor);
					obeAdjudicaciones.FechaAsignaRevisor =  datard.GetDateTime(posFechaAsignaRevisor);
					obeAdjudicaciones.FechaAutorizacion =  datard.GetDateTime(posFechaAutorizacion);
					obeAdjudicaciones.Economia =  datard.GetDecimal(posEconomia);
					obeAdjudicaciones.Ejercido =  datard.GetDecimal(posEjercido);
					obeAdjudicaciones.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeAdjudicaciones.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
                    obeAdjudicaciones.AcuerdoAutorizacionComite = datard.GetString(posAcuerdoAutorizacionComite);

                            // debe agregar campos de la Vista
                            lbeAdjudicaciones.Add(obeAdjudicaciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicaciones;
		}
	}
}
}
