using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daPropuestasTecnicaEconomicaLotes
 {
	public int guardarPropuestasTecnicaEconomicaLotes(SqlConnection Conexion, bePropuestasTecnicaEconomicaLotes obePropuestasTecnicaEconomicaLotes)
	{
		int Id=0;
		string sp = "Proc_PropuestasTecnicaEconomicaLotesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPropuestaTecnicaEconomica", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdPropuestaTecnicaEconomica;
				cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdProveedorRqInvitacion;
				cmd.Parameters.Add("@LoteOfertado", SqlDbType.Bit).Value = obePropuestasTecnicaEconomicaLotes.LoteOfertado;
				cmd.Parameters.Add("@IdLote", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdLote;
				cmd.Parameters.Add("@Mejora", SqlDbType.VarChar).Value = obePropuestasTecnicaEconomicaLotes.Mejora;
				cmd.Parameters.Add("@EstatusMejora", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.EstatusMejora;
				cmd.Parameters.Add("@PrecioUnitarioRefencia", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.PrecioUnitarioRefencia;
				cmd.Parameters.Add("@PrecioUnitarioOfertado", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.PrecioUnitarioOfertado;
				cmd.Parameters.Add("@ImporteOfertado", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.ImporteOfertado;
				cmd.Parameters.Add("@ImpuestoPorcentaje", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.ImpuestoPorcentaje;
				cmd.Parameters.Add("@ImpuestoImporte", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.ImpuestoImporte;
				cmd.Parameters.Add("@TotalOfertado", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.TotalOfertado;
				cmd.Parameters.Add("@URLFileMuestraCatalogo", SqlDbType.Text).Value = obePropuestasTecnicaEconomicaLotes.URLFileMuestraCatalogo;
				cmd.Parameters.Add("@URLFileCertificacion", SqlDbType.Text).Value = obePropuestasTecnicaEconomicaLotes.URLFileCertificacion;
				cmd.Parameters.Add("@DependenciaCumple", SqlDbType.Bit).Value = obePropuestasTecnicaEconomicaLotes.DependenciaCumple;
				cmd.Parameters.Add("@FundamentoLegal", SqlDbType.Text).Value = obePropuestasTecnicaEconomicaLotes.FundamentoLegal;
				cmd.Parameters.Add("@AdquisicionCumple", SqlDbType.Bit).Value = obePropuestasTecnicaEconomicaLotes.AdquisicionCumple;
				cmd.Parameters.Add("@AdquisicionObserva", SqlDbType.Text).Value = obePropuestasTecnicaEconomicaLotes.AdquisicionObserva;
				cmd.Parameters.Add("@ValidaEconomica", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.ValidaEconomica;
				cmd.Parameters.Add("@ImportePeriodo", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.ImportePeriodo;
				cmd.Parameters.Add("@ImpuestoPeriodo", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.ImpuestoPeriodo;
				cmd.Parameters.Add("@TotalPeriodo", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.TotalPeriodo;
				cmd.Parameters.Add("@IdMesInicial", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdMesInicial;
				cmd.Parameters.Add("@IdMesFinal", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdMesFinal;
				cmd.Parameters.Add("@IdEstatusPropuesta", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdEstatusPropuesta;
				cmd.Parameters.Add("@PropuestaGanadora", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.PropuestaGanadora;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarPropuestasTecnicaEconomicaLotes(SqlConnection Conexion, bePropuestasTecnicaEconomicaLotes obePropuestasTecnicaEconomicaLotes)
	{
		string sp = "Proc_PropuestasTecnicaEconomicaLotesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPropuestaTecnicaEconomica", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdPropuestaTecnicaEconomica;
				cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdProveedorRqInvitacion;
				cmd.Parameters.Add("@LoteOfertado", SqlDbType.Bit).Value = obePropuestasTecnicaEconomicaLotes.LoteOfertado;
				cmd.Parameters.Add("@IdLote", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdLote;
				cmd.Parameters.Add("@Mejora", SqlDbType.VarChar).Value = obePropuestasTecnicaEconomicaLotes.Mejora;
				cmd.Parameters.Add("@EstatusMejora", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.EstatusMejora;
				cmd.Parameters.Add("@PrecioUnitarioRefencia", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.PrecioUnitarioRefencia;
				cmd.Parameters.Add("@PrecioUnitarioOfertado", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.PrecioUnitarioOfertado;
				cmd.Parameters.Add("@ImporteOfertado", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.ImporteOfertado;
				cmd.Parameters.Add("@ImpuestoPorcentaje", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.ImpuestoPorcentaje;
				cmd.Parameters.Add("@ImpuestoImporte", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.ImpuestoImporte;
				cmd.Parameters.Add("@TotalOfertado", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.TotalOfertado;
				cmd.Parameters.Add("@URLFileMuestraCatalogo", SqlDbType.Text).Value = obePropuestasTecnicaEconomicaLotes.URLFileMuestraCatalogo;
				cmd.Parameters.Add("@URLFileCertificacion", SqlDbType.Text).Value = obePropuestasTecnicaEconomicaLotes.URLFileCertificacion;
				cmd.Parameters.Add("@DependenciaCumple", SqlDbType.Bit).Value = obePropuestasTecnicaEconomicaLotes.DependenciaCumple;
				cmd.Parameters.Add("@FundamentoLegal", SqlDbType.Text).Value = obePropuestasTecnicaEconomicaLotes.FundamentoLegal;
				cmd.Parameters.Add("@AdquisicionCumple", SqlDbType.Bit).Value = obePropuestasTecnicaEconomicaLotes.AdquisicionCumple;
				cmd.Parameters.Add("@AdquisicionObserva", SqlDbType.Text).Value = obePropuestasTecnicaEconomicaLotes.AdquisicionObserva;
				cmd.Parameters.Add("@ValidaEconomica", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.ValidaEconomica;
				cmd.Parameters.Add("@ImportePeriodo", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.ImportePeriodo;
				cmd.Parameters.Add("@ImpuestoPeriodo", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.ImpuestoPeriodo;
				cmd.Parameters.Add("@TotalPeriodo", SqlDbType.Decimal).Value = obePropuestasTecnicaEconomicaLotes.TotalPeriodo;
				cmd.Parameters.Add("@IdMesInicial", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdMesInicial;
				cmd.Parameters.Add("@IdMesFinal", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdMesFinal;
				cmd.Parameters.Add("@IdEstatusPropuesta", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.IdEstatusPropuesta;
				cmd.Parameters.Add("@PropuestaGanadora", SqlDbType.Int).Value = obePropuestasTecnicaEconomicaLotes.PropuestaGanadora;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarPropuestasTecnicaEconomicaLotes(SqlConnection Conexion,int pIdPropuestaTecnicaEconomica)
	{
		string sp = "Proc_PropuestasTecnicaEconomicaLotesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPropuestaTecnicaEconomica", SqlDbType.Int).Value = pIdPropuestaTecnicaEconomica;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public bePropuestasTecnicaEconomicaLotes traerPropuestasTecnicaEconomicaLotes_x_IdPropuestaTecnicaEconomica(SqlConnection Conexion,int IdPropuestaTecnicaEconomica)
	{
		string sp = "Proc_PropuestasTecnicaEconomicaLotes_x_IdPropuestaTecnicaEconomica";
				bePropuestasTecnicaEconomicaLotes obePropuestasTecnicaEconomicaLotes=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPropuestaTecnicaEconomica", SqlDbType.Int).Value = IdPropuestaTecnicaEconomica;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdPropuestaTecnicaEconomica = datard.GetOrdinal("IdPropuestaTecnicaEconomica");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posLoteOfertado = datard.GetOrdinal("LoteOfertado");
						int posIdLote = datard.GetOrdinal("IdLote");
						int posMejora = datard.GetOrdinal("Mejora");
						int posEstatusMejora = datard.GetOrdinal("EstatusMejora");
						int posPrecioUnitarioRefencia = datard.GetOrdinal("PrecioUnitarioRefencia");
						int posPrecioUnitarioOfertado = datard.GetOrdinal("PrecioUnitarioOfertado");
						int posImporteOfertado = datard.GetOrdinal("ImporteOfertado");
						int posImpuestoPorcentaje = datard.GetOrdinal("ImpuestoPorcentaje");
						int posImpuestoImporte = datard.GetOrdinal("ImpuestoImporte");
						int posTotalOfertado = datard.GetOrdinal("TotalOfertado");
						int posURLFileMuestraCatalogo = datard.GetOrdinal("URLFileMuestraCatalogo");
						int posURLFileCertificacion = datard.GetOrdinal("URLFileCertificacion");
						int posDependenciaCumple = datard.GetOrdinal("DependenciaCumple");
						int posFundamentoLegal = datard.GetOrdinal("FundamentoLegal");
						int posAdquisicionCumple = datard.GetOrdinal("AdquisicionCumple");
						int posAdquisicionObserva = datard.GetOrdinal("AdquisicionObserva");
						int posValidaEconomica = datard.GetOrdinal("ValidaEconomica");
						int posImportePeriodo = datard.GetOrdinal("ImportePeriodo");
						int posImpuestoPeriodo = datard.GetOrdinal("ImpuestoPeriodo");
						int posTotalPeriodo = datard.GetOrdinal("TotalPeriodo");
						int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
						int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
						int posIdEstatusPropuesta = datard.GetOrdinal("IdEstatusPropuesta");
						int posPropuestaGanadora = datard.GetOrdinal("PropuestaGanadora");
					 obePropuestasTecnicaEconomicaLotes = new bePropuestasTecnicaEconomicaLotes();
				while (datard.Read())
					{
						obePropuestasTecnicaEconomicaLotes.IdPropuestaTecnicaEconomica =  datard.GetInt32(posIdPropuestaTecnicaEconomica);
						obePropuestasTecnicaEconomicaLotes.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
						obePropuestasTecnicaEconomicaLotes.LoteOfertado =  datard.GetBoolean(posLoteOfertado);
						obePropuestasTecnicaEconomicaLotes.IdLote =  datard.GetInt32(posIdLote);
						obePropuestasTecnicaEconomicaLotes.Mejora = datard[posMejora]==DBNull.Value?"": datard.GetString(posMejora);
						obePropuestasTecnicaEconomicaLotes.EstatusMejora = datard[posEstatusMejora] == DBNull.Value ? 0: datard.GetInt32(posEstatusMejora);
						obePropuestasTecnicaEconomicaLotes.PrecioUnitarioRefencia =  datard.GetDecimal(posPrecioUnitarioRefencia);
						obePropuestasTecnicaEconomicaLotes.PrecioUnitarioOfertado =  datard.GetDecimal(posPrecioUnitarioOfertado);
						obePropuestasTecnicaEconomicaLotes.ImporteOfertado =  datard.GetDecimal(posImporteOfertado);
						obePropuestasTecnicaEconomicaLotes.ImpuestoPorcentaje =  datard.GetDecimal(posImpuestoPorcentaje);
						obePropuestasTecnicaEconomicaLotes.ImpuestoImporte =  datard.GetDecimal(posImpuestoImporte);
						obePropuestasTecnicaEconomicaLotes.TotalOfertado =  datard.GetDecimal(posTotalOfertado);
						obePropuestasTecnicaEconomicaLotes.URLFileMuestraCatalogo = datard[posURLFileMuestraCatalogo] == DBNull.Value ? "" : datard.GetString(posURLFileMuestraCatalogo);
						obePropuestasTecnicaEconomicaLotes.URLFileCertificacion = datard[posURLFileCertificacion] == DBNull.Value ? "" : datard.GetString(posURLFileCertificacion);
						obePropuestasTecnicaEconomicaLotes.DependenciaCumple = datard[posDependenciaCumple] == DBNull.Value ? false :  datard.GetBoolean(posDependenciaCumple);
						obePropuestasTecnicaEconomicaLotes.FundamentoLegal = datard[posFundamentoLegal] == DBNull.Value ? "" : datard.GetString(posFundamentoLegal);
						obePropuestasTecnicaEconomicaLotes.AdquisicionCumple = datard[posAdquisicionCumple] == DBNull.Value ? false : datard.GetBoolean(posAdquisicionCumple);
						obePropuestasTecnicaEconomicaLotes.AdquisicionObserva = datard[posAdquisicionObserva] == DBNull.Value ? "" : datard.GetString(posAdquisicionObserva);
						obePropuestasTecnicaEconomicaLotes.ValidaEconomica = datard[posValidaEconomica] == DBNull.Value ? 0 :  datard.GetInt32(posValidaEconomica);
						obePropuestasTecnicaEconomicaLotes.ImportePeriodo =  datard.GetDecimal(posImportePeriodo);
						obePropuestasTecnicaEconomicaLotes.ImpuestoPeriodo =  datard.GetDecimal(posImpuestoPeriodo);
						obePropuestasTecnicaEconomicaLotes.TotalPeriodo =  datard.GetDecimal(posTotalPeriodo);
						obePropuestasTecnicaEconomicaLotes.IdMesInicial =  datard.GetInt32(posIdMesInicial);
						obePropuestasTecnicaEconomicaLotes.IdMesFinal =  datard.GetInt32(posIdMesFinal);
						obePropuestasTecnicaEconomicaLotes.IdEstatusPropuesta =  datard.GetInt32(posIdEstatusPropuesta);
						obePropuestasTecnicaEconomicaLotes.PropuestaGanadora =  datard.GetInt32(posPropuestaGanadora);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePropuestasTecnicaEconomicaLotes;
			}
	}
	public List< bePropuestasTecnicaEconomicaLotes> listarTodos_PropuestasTecnicaEconomicaLotes(SqlConnection Conexion)
	 {
		string sp = "Proc_PropuestasTecnicaEconomicaLotes_Traer_Todos";
		List<bePropuestasTecnicaEconomicaLotes> lbePropuestasTecnicaEconomicaLotes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPropuestaTecnicaEconomica = datard.GetOrdinal("IdPropuestaTecnicaEconomica");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posLoteOfertado = datard.GetOrdinal("LoteOfertado");
						int posIdLote = datard.GetOrdinal("IdLote");
						int posMejora = datard.GetOrdinal("Mejora");
						int posEstatusMejora = datard.GetOrdinal("EstatusMejora");
						int posPrecioUnitarioRefencia = datard.GetOrdinal("PrecioUnitarioRefencia");
						int posPrecioUnitarioOfertado = datard.GetOrdinal("PrecioUnitarioOfertado");
						int posImporteOfertado = datard.GetOrdinal("ImporteOfertado");
						int posImpuestoPorcentaje = datard.GetOrdinal("ImpuestoPorcentaje");
						int posImpuestoImporte = datard.GetOrdinal("ImpuestoImporte");
						int posTotalOfertado = datard.GetOrdinal("TotalOfertado");
						int posURLFileMuestraCatalogo = datard.GetOrdinal("URLFileMuestraCatalogo");
						int posURLFileCertificacion = datard.GetOrdinal("URLFileCertificacion");
						int posDependenciaCumple = datard.GetOrdinal("DependenciaCumple");
						int posFundamentoLegal = datard.GetOrdinal("FundamentoLegal");
						int posAdquisicionCumple = datard.GetOrdinal("AdquisicionCumple");
						int posAdquisicionObserva = datard.GetOrdinal("AdquisicionObserva");
						int posValidaEconomica = datard.GetOrdinal("ValidaEconomica");
						int posImportePeriodo = datard.GetOrdinal("ImportePeriodo");
						int posImpuestoPeriodo = datard.GetOrdinal("ImpuestoPeriodo");
						int posTotalPeriodo = datard.GetOrdinal("TotalPeriodo");
						int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
						int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
						int posIdEstatusPropuesta = datard.GetOrdinal("IdEstatusPropuesta");
						int posPropuestaGanadora = datard.GetOrdinal("PropuestaGanadora");
				lbePropuestasTecnicaEconomicaLotes = new List<bePropuestasTecnicaEconomicaLotes>();
				bePropuestasTecnicaEconomicaLotes obePropuestasTecnicaEconomicaLotes;
				while (datard.Read())
				{
					 obePropuestasTecnicaEconomicaLotes = new bePropuestasTecnicaEconomicaLotes();
					obePropuestasTecnicaEconomicaLotes.IdPropuestaTecnicaEconomica =  datard.GetInt32(posIdPropuestaTecnicaEconomica);
					obePropuestasTecnicaEconomicaLotes.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
					obePropuestasTecnicaEconomicaLotes.LoteOfertado =  datard.GetBoolean(posLoteOfertado);
					obePropuestasTecnicaEconomicaLotes.IdLote =  datard.GetInt32(posIdLote);
					obePropuestasTecnicaEconomicaLotes.Mejora =  datard.GetString(posMejora);
					obePropuestasTecnicaEconomicaLotes.EstatusMejora =  datard.GetInt32(posEstatusMejora);
					obePropuestasTecnicaEconomicaLotes.PrecioUnitarioRefencia =  datard.GetDecimal(posPrecioUnitarioRefencia);
					obePropuestasTecnicaEconomicaLotes.PrecioUnitarioOfertado =  datard.GetDecimal(posPrecioUnitarioOfertado);
					obePropuestasTecnicaEconomicaLotes.ImporteOfertado =  datard.GetDecimal(posImporteOfertado);
					obePropuestasTecnicaEconomicaLotes.ImpuestoPorcentaje =  datard.GetDecimal(posImpuestoPorcentaje);
					obePropuestasTecnicaEconomicaLotes.ImpuestoImporte =  datard.GetDecimal(posImpuestoImporte);
					obePropuestasTecnicaEconomicaLotes.TotalOfertado =  datard.GetDecimal(posTotalOfertado);
					obePropuestasTecnicaEconomicaLotes.URLFileMuestraCatalogo =  datard.GetString(posURLFileMuestraCatalogo);
					obePropuestasTecnicaEconomicaLotes.URLFileCertificacion =  datard.GetString(posURLFileCertificacion);
					obePropuestasTecnicaEconomicaLotes.DependenciaCumple =  datard.GetBoolean(posDependenciaCumple);
					obePropuestasTecnicaEconomicaLotes.FundamentoLegal =  datard.GetString(posFundamentoLegal);
					obePropuestasTecnicaEconomicaLotes.AdquisicionCumple =  datard.GetBoolean(posAdquisicionCumple);
					obePropuestasTecnicaEconomicaLotes.AdquisicionObserva =  datard.GetString(posAdquisicionObserva);
					obePropuestasTecnicaEconomicaLotes.ValidaEconomica =  datard.GetInt32(posValidaEconomica);
					obePropuestasTecnicaEconomicaLotes.ImportePeriodo =  datard.GetDecimal(posImportePeriodo);
					obePropuestasTecnicaEconomicaLotes.ImpuestoPeriodo =  datard.GetDecimal(posImpuestoPeriodo);
					obePropuestasTecnicaEconomicaLotes.TotalPeriodo =  datard.GetDecimal(posTotalPeriodo);
					obePropuestasTecnicaEconomicaLotes.IdMesInicial =  datard.GetInt32(posIdMesInicial);
					obePropuestasTecnicaEconomicaLotes.IdMesFinal =  datard.GetInt32(posIdMesFinal);
					obePropuestasTecnicaEconomicaLotes.IdEstatusPropuesta =  datard.GetInt32(posIdEstatusPropuesta);
					obePropuestasTecnicaEconomicaLotes.PropuestaGanadora =  datard.GetInt32(posPropuestaGanadora);
					lbePropuestasTecnicaEconomicaLotes.Add(obePropuestasTecnicaEconomicaLotes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePropuestasTecnicaEconomicaLotes;
		}
	}
	public List< bePropuestasTecnicaEconomicaLotes> listar_PropuestasTecnicaEconomicaLotes_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_PropuestasTecnicaEconomicaLotes_TraerTodos_GetAll";
		List<bePropuestasTecnicaEconomicaLotes> lbePropuestasTecnicaEconomicaLotes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPropuestaTecnicaEconomica = datard.GetOrdinal("IdPropuestaTecnicaEconomica");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posLoteOfertado = datard.GetOrdinal("LoteOfertado");
						int posIdLote = datard.GetOrdinal("IdLote");
						int posMejora = datard.GetOrdinal("Mejora");
						int posEstatusMejora = datard.GetOrdinal("EstatusMejora");
						int posPrecioUnitarioRefencia = datard.GetOrdinal("PrecioUnitarioRefencia");
						int posPrecioUnitarioOfertado = datard.GetOrdinal("PrecioUnitarioOfertado");
						int posImporteOfertado = datard.GetOrdinal("ImporteOfertado");
						int posImpuestoPorcentaje = datard.GetOrdinal("ImpuestoPorcentaje");
						int posImpuestoImporte = datard.GetOrdinal("ImpuestoImporte");
						int posTotalOfertado = datard.GetOrdinal("TotalOfertado");
						int posURLFileMuestraCatalogo = datard.GetOrdinal("URLFileMuestraCatalogo");
						int posURLFileCertificacion = datard.GetOrdinal("URLFileCertificacion");
						int posDependenciaCumple = datard.GetOrdinal("DependenciaCumple");
						int posFundamentoLegal = datard.GetOrdinal("FundamentoLegal");
						int posAdquisicionCumple = datard.GetOrdinal("AdquisicionCumple");
						int posAdquisicionObserva = datard.GetOrdinal("AdquisicionObserva");
						int posValidaEconomica = datard.GetOrdinal("ValidaEconomica");
						int posImportePeriodo = datard.GetOrdinal("ImportePeriodo");
						int posImpuestoPeriodo = datard.GetOrdinal("ImpuestoPeriodo");
						int posTotalPeriodo = datard.GetOrdinal("TotalPeriodo");
						int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
						int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
						int posIdEstatusPropuesta = datard.GetOrdinal("IdEstatusPropuesta");
						int posPropuestaGanadora = datard.GetOrdinal("PropuestaGanadora");
				lbePropuestasTecnicaEconomicaLotes = new List<bePropuestasTecnicaEconomicaLotes>();
				bePropuestasTecnicaEconomicaLotes obePropuestasTecnicaEconomicaLotes;
				while (datard.Read())
				{
					 obePropuestasTecnicaEconomicaLotes = new bePropuestasTecnicaEconomicaLotes();
					obePropuestasTecnicaEconomicaLotes.IdPropuestaTecnicaEconomica =  datard.GetInt32(posIdPropuestaTecnicaEconomica);
					obePropuestasTecnicaEconomicaLotes.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
					obePropuestasTecnicaEconomicaLotes.LoteOfertado =  datard.GetBoolean(posLoteOfertado);
					obePropuestasTecnicaEconomicaLotes.IdLote =  datard.GetInt32(posIdLote);
					obePropuestasTecnicaEconomicaLotes.Mejora =  datard.GetString(posMejora);
					obePropuestasTecnicaEconomicaLotes.EstatusMejora =  datard.GetInt32(posEstatusMejora);
					obePropuestasTecnicaEconomicaLotes.PrecioUnitarioRefencia =  datard.GetDecimal(posPrecioUnitarioRefencia);
					obePropuestasTecnicaEconomicaLotes.PrecioUnitarioOfertado =  datard.GetDecimal(posPrecioUnitarioOfertado);
					obePropuestasTecnicaEconomicaLotes.ImporteOfertado =  datard.GetDecimal(posImporteOfertado);
					obePropuestasTecnicaEconomicaLotes.ImpuestoPorcentaje =  datard.GetDecimal(posImpuestoPorcentaje);
					obePropuestasTecnicaEconomicaLotes.ImpuestoImporte =  datard.GetDecimal(posImpuestoImporte);
					obePropuestasTecnicaEconomicaLotes.TotalOfertado =  datard.GetDecimal(posTotalOfertado);
					obePropuestasTecnicaEconomicaLotes.URLFileMuestraCatalogo =  datard.GetString(posURLFileMuestraCatalogo);
					obePropuestasTecnicaEconomicaLotes.URLFileCertificacion =  datard.GetString(posURLFileCertificacion);
					obePropuestasTecnicaEconomicaLotes.DependenciaCumple =  datard.GetBoolean(posDependenciaCumple);
					obePropuestasTecnicaEconomicaLotes.FundamentoLegal =  datard.GetString(posFundamentoLegal);
					obePropuestasTecnicaEconomicaLotes.AdquisicionCumple =  datard.GetBoolean(posAdquisicionCumple);
					obePropuestasTecnicaEconomicaLotes.AdquisicionObserva =  datard.GetString(posAdquisicionObserva);
					obePropuestasTecnicaEconomicaLotes.ValidaEconomica =  datard.GetInt32(posValidaEconomica);
					obePropuestasTecnicaEconomicaLotes.ImportePeriodo =  datard.GetDecimal(posImportePeriodo);
					obePropuestasTecnicaEconomicaLotes.ImpuestoPeriodo =  datard.GetDecimal(posImpuestoPeriodo);
					obePropuestasTecnicaEconomicaLotes.TotalPeriodo =  datard.GetDecimal(posTotalPeriodo);
					obePropuestasTecnicaEconomicaLotes.IdMesInicial =  datard.GetInt32(posIdMesInicial);
					obePropuestasTecnicaEconomicaLotes.IdMesFinal =  datard.GetInt32(posIdMesFinal);
					obePropuestasTecnicaEconomicaLotes.IdEstatusPropuesta =  datard.GetInt32(posIdEstatusPropuesta);
					obePropuestasTecnicaEconomicaLotes.PropuestaGanadora =  datard.GetInt32(posPropuestaGanadora);
			// debe agregar campos de la Vista
					lbePropuestasTecnicaEconomicaLotes.Add(obePropuestasTecnicaEconomicaLotes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePropuestasTecnicaEconomicaLotes;
		}
	}
}
}
