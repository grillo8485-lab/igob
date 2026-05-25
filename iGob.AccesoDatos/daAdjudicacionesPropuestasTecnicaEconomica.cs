using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesPropuestasTecnicaEconomica
 {
	public int guardarAdjudicacionesPropuestasTecnicaEconomica(SqlConnection Conexion, beAdjudicacionesPropuestasTecnicaEconomica obeAdjudicacionesPropuestasTecnicaEconomica)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesPropuestasTecnicaEconomicaInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicionPropuestaTecEco", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicionPropuestaTecEco;
				cmd.Parameters.Add("@IdAdjudicacionProveedor", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicacionProveedor;
				cmd.Parameters.Add("@IdLote", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdLote;
				cmd.Parameters.Add("@Mejora", SqlDbType.VarChar).Value = obeAdjudicacionesPropuestasTecnicaEconomica.Mejora;
				cmd.Parameters.Add("@EstatusMejora", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.EstatusMejora;
				cmd.Parameters.Add("@PrecioUnitarioRefencia", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioRefencia;
				cmd.Parameters.Add("@PrecioUnitarioOfertado", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioOfertado;
				cmd.Parameters.Add("@ImporteOfertado", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ImporteOfertado;
				cmd.Parameters.Add("@ImpuestoPorcentaje", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPorcentaje;
				cmd.Parameters.Add("@ImpuestoImporte", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoImporte;
				cmd.Parameters.Add("@TotalOfertado", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.TotalOfertado;
				cmd.Parameters.Add("@IdEstatusPropuesta", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdEstatusPropuesta;
				cmd.Parameters.Add("@URLFileMuestraCatalogo", SqlDbType.Text).Value = obeAdjudicacionesPropuestasTecnicaEconomica.URLFileMuestraCatalogo;
				cmd.Parameters.Add("@URLFileCertificacion", SqlDbType.Text).Value = obeAdjudicacionesPropuestasTecnicaEconomica.URLFileCertificacion;
				cmd.Parameters.Add("@DependenciaCumple", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.DependenciaCumple;
				cmd.Parameters.Add("@FundamentoLegal", SqlDbType.Text).Value = obeAdjudicacionesPropuestasTecnicaEconomica.FundamentoLegal;
				cmd.Parameters.Add("@AdquisicionCumple", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionCumple;
				cmd.Parameters.Add("@AdquisicionObserva", SqlDbType.Text).Value = obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionObserva;
				cmd.Parameters.Add("@ProveedorGanador", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ProveedorGanador;
				cmd.Parameters.Add("@ValidaEconomica", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ValidaEconomica;
				cmd.Parameters.Add("@ImportePeriodo", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ImportePeriodo;
				cmd.Parameters.Add("@ImpuestoPeriodo", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPeriodo;
				cmd.Parameters.Add("@TotalPeriodo", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.TotalPeriodo;
				cmd.Parameters.Add("@IdMesInicial", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdMesInicial;
				cmd.Parameters.Add("@IdMesFinal", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdMesFinal;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesPropuestasTecnicaEconomica(SqlConnection Conexion, beAdjudicacionesPropuestasTecnicaEconomica obeAdjudicacionesPropuestasTecnicaEconomica)
	{
		string sp = "Proc_AdjudicacionesPropuestasTecnicaEconomicaActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicionPropuestaTecEco", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicionPropuestaTecEco;
				cmd.Parameters.Add("@IdAdjudicacionProveedor", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicacionProveedor;
				cmd.Parameters.Add("@IdLote", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdLote;
				cmd.Parameters.Add("@Mejora", SqlDbType.VarChar).Value = obeAdjudicacionesPropuestasTecnicaEconomica.Mejora;
				cmd.Parameters.Add("@EstatusMejora", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.EstatusMejora;
				cmd.Parameters.Add("@PrecioUnitarioRefencia", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioRefencia;
				cmd.Parameters.Add("@PrecioUnitarioOfertado", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioOfertado;
				cmd.Parameters.Add("@ImporteOfertado", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ImporteOfertado;
				cmd.Parameters.Add("@ImpuestoPorcentaje", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPorcentaje;
				cmd.Parameters.Add("@ImpuestoImporte", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoImporte;
				cmd.Parameters.Add("@TotalOfertado", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.TotalOfertado;
				cmd.Parameters.Add("@IdEstatusPropuesta", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdEstatusPropuesta;
				cmd.Parameters.Add("@URLFileMuestraCatalogo", SqlDbType.Text).Value = obeAdjudicacionesPropuestasTecnicaEconomica.URLFileMuestraCatalogo;
				cmd.Parameters.Add("@URLFileCertificacion", SqlDbType.Text).Value = obeAdjudicacionesPropuestasTecnicaEconomica.URLFileCertificacion;
				cmd.Parameters.Add("@DependenciaCumple", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.DependenciaCumple;
				cmd.Parameters.Add("@FundamentoLegal", SqlDbType.Text).Value = obeAdjudicacionesPropuestasTecnicaEconomica.FundamentoLegal;
				cmd.Parameters.Add("@AdquisicionCumple", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionCumple;
				cmd.Parameters.Add("@AdquisicionObserva", SqlDbType.Text).Value = obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionObserva;
				cmd.Parameters.Add("@ProveedorGanador", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ProveedorGanador;
				cmd.Parameters.Add("@ValidaEconomica", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ValidaEconomica;
				cmd.Parameters.Add("@ImportePeriodo", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ImportePeriodo;
				cmd.Parameters.Add("@ImpuestoPeriodo", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPeriodo;
				cmd.Parameters.Add("@TotalPeriodo", SqlDbType.Decimal).Value = obeAdjudicacionesPropuestasTecnicaEconomica.TotalPeriodo;
				cmd.Parameters.Add("@IdMesInicial", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdMesInicial;
				cmd.Parameters.Add("@IdMesFinal", SqlDbType.Int).Value = obeAdjudicacionesPropuestasTecnicaEconomica.IdMesFinal;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesPropuestasTecnicaEconomica(SqlConnection Conexion,int pIdAdjudicionPropuestaTecEco)
	{
		string sp = "Proc_AdjudicacionesPropuestasTecnicaEconomicaEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicionPropuestaTecEco", SqlDbType.Int).Value = pIdAdjudicionPropuestaTecEco;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesPropuestasTecnicaEconomica traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionPropuestaTecEco(SqlConnection Conexion,int IdAdjudicionPropuestaTecEco)
	{
		string sp = "Proc_AdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionPropuestaTecEco";
				beAdjudicacionesPropuestasTecnicaEconomica obeAdjudicacionesPropuestasTecnicaEconomica=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdjudicionPropuestaTecEco", SqlDbType.Int).Value = IdAdjudicionPropuestaTecEco;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdjudicionPropuestaTecEco = datard.GetOrdinal("IdAdjudicionPropuestaTecEco");
						int posIdAdjudicacionProveedor = datard.GetOrdinal("IdAdjudicacionProveedor");
						int posIdLote = datard.GetOrdinal("IdLote");
						int posMejora = datard.GetOrdinal("Mejora");
						int posEstatusMejora = datard.GetOrdinal("EstatusMejora");
						int posPrecioUnitarioRefencia = datard.GetOrdinal("PrecioUnitarioRefencia");
						int posPrecioUnitarioOfertado = datard.GetOrdinal("PrecioUnitarioOfertado");
						int posImporteOfertado = datard.GetOrdinal("ImporteOfertado");
						int posImpuestoPorcentaje = datard.GetOrdinal("ImpuestoPorcentaje");
						int posImpuestoImporte = datard.GetOrdinal("ImpuestoImporte");
						int posTotalOfertado = datard.GetOrdinal("TotalOfertado");
						int posIdEstatusPropuesta = datard.GetOrdinal("IdEstatusPropuesta");
						int posURLFileMuestraCatalogo = datard.GetOrdinal("URLFileMuestraCatalogo");
						int posURLFileCertificacion = datard.GetOrdinal("URLFileCertificacion");
						int posDependenciaCumple = datard.GetOrdinal("DependenciaCumple");
						int posFundamentoLegal = datard.GetOrdinal("FundamentoLegal");
						int posAdquisicionCumple = datard.GetOrdinal("AdquisicionCumple");
						int posAdquisicionObserva = datard.GetOrdinal("AdquisicionObserva");
						int posProveedorGanador = datard.GetOrdinal("ProveedorGanador");
						int posValidaEconomica = datard.GetOrdinal("ValidaEconomica");
						int posImportePeriodo = datard.GetOrdinal("ImportePeriodo");
						int posImpuestoPeriodo = datard.GetOrdinal("ImpuestoPeriodo");
						int posTotalPeriodo = datard.GetOrdinal("TotalPeriodo");
						int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
						int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
					 obeAdjudicacionesPropuestasTecnicaEconomica = new beAdjudicacionesPropuestasTecnicaEconomica();
				while (datard.Read())
					{
						obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicionPropuestaTecEco =  datard.GetInt32(posIdAdjudicionPropuestaTecEco);
						obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicacionProveedor =  datard.GetInt32(posIdAdjudicacionProveedor);
						obeAdjudicacionesPropuestasTecnicaEconomica.IdLote =  datard.GetInt32(posIdLote);
						obeAdjudicacionesPropuestasTecnicaEconomica.Mejora =  datard.GetString(posMejora);
						obeAdjudicacionesPropuestasTecnicaEconomica.EstatusMejora =  datard.GetInt32(posEstatusMejora);
						obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioRefencia =  datard.GetDecimal(posPrecioUnitarioRefencia);
						obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioOfertado =  datard.GetDecimal(posPrecioUnitarioOfertado);
						obeAdjudicacionesPropuestasTecnicaEconomica.ImporteOfertado =  datard.GetDecimal(posImporteOfertado);
						obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPorcentaje =  datard.GetDecimal(posImpuestoPorcentaje);
						obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoImporte =  datard.GetDecimal(posImpuestoImporte);
						obeAdjudicacionesPropuestasTecnicaEconomica.TotalOfertado =  datard.GetDecimal(posTotalOfertado);
						obeAdjudicacionesPropuestasTecnicaEconomica.IdEstatusPropuesta =  datard.GetInt32(posIdEstatusPropuesta);
						obeAdjudicacionesPropuestasTecnicaEconomica.URLFileMuestraCatalogo =  datard.GetString(posURLFileMuestraCatalogo);
						obeAdjudicacionesPropuestasTecnicaEconomica.URLFileCertificacion =  datard.GetString(posURLFileCertificacion);
						obeAdjudicacionesPropuestasTecnicaEconomica.DependenciaCumple =  datard.GetInt32(posDependenciaCumple);
						obeAdjudicacionesPropuestasTecnicaEconomica.FundamentoLegal =  datard.GetString(posFundamentoLegal);
						obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionCumple =  datard.GetInt32(posAdquisicionCumple);
						obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionObserva =  datard.GetString(posAdquisicionObserva);
						obeAdjudicacionesPropuestasTecnicaEconomica.ProveedorGanador =  datard.GetInt32(posProveedorGanador);
						obeAdjudicacionesPropuestasTecnicaEconomica.ValidaEconomica =  datard.GetInt32(posValidaEconomica);
						obeAdjudicacionesPropuestasTecnicaEconomica.ImportePeriodo =  datard.GetDecimal(posImportePeriodo);
						obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPeriodo =  datard.GetDecimal(posImpuestoPeriodo);
						obeAdjudicacionesPropuestasTecnicaEconomica.TotalPeriodo =  datard.GetDecimal(posTotalPeriodo);
						obeAdjudicacionesPropuestasTecnicaEconomica.IdMesInicial =  datard.GetInt32(posIdMesInicial);
						obeAdjudicacionesPropuestasTecnicaEconomica.IdMesFinal =  datard.GetInt32(posIdMesFinal);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesPropuestasTecnicaEconomica;
			}
	}
	public List< beAdjudicacionesPropuestasTecnicaEconomica> listarTodos_AdjudicacionesPropuestasTecnicaEconomica(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesPropuestasTecnicaEconomica_Traer_Todos";
		List<beAdjudicacionesPropuestasTecnicaEconomica> lbeAdjudicacionesPropuestasTecnicaEconomica = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicionPropuestaTecEco = datard.GetOrdinal("IdAdjudicionPropuestaTecEco");
						int posIdAdjudicacionProveedor = datard.GetOrdinal("IdAdjudicacionProveedor");
						int posIdLote = datard.GetOrdinal("IdLote");
						int posMejora = datard.GetOrdinal("Mejora");
						int posEstatusMejora = datard.GetOrdinal("EstatusMejora");
						int posPrecioUnitarioRefencia = datard.GetOrdinal("PrecioUnitarioRefencia");
						int posPrecioUnitarioOfertado = datard.GetOrdinal("PrecioUnitarioOfertado");
						int posImporteOfertado = datard.GetOrdinal("ImporteOfertado");
						int posImpuestoPorcentaje = datard.GetOrdinal("ImpuestoPorcentaje");
						int posImpuestoImporte = datard.GetOrdinal("ImpuestoImporte");
						int posTotalOfertado = datard.GetOrdinal("TotalOfertado");
						int posIdEstatusPropuesta = datard.GetOrdinal("IdEstatusPropuesta");
						int posURLFileMuestraCatalogo = datard.GetOrdinal("URLFileMuestraCatalogo");
						int posURLFileCertificacion = datard.GetOrdinal("URLFileCertificacion");
						int posDependenciaCumple = datard.GetOrdinal("DependenciaCumple");
						int posFundamentoLegal = datard.GetOrdinal("FundamentoLegal");
						int posAdquisicionCumple = datard.GetOrdinal("AdquisicionCumple");
						int posAdquisicionObserva = datard.GetOrdinal("AdquisicionObserva");
						int posProveedorGanador = datard.GetOrdinal("ProveedorGanador");
						int posValidaEconomica = datard.GetOrdinal("ValidaEconomica");
						int posImportePeriodo = datard.GetOrdinal("ImportePeriodo");
						int posImpuestoPeriodo = datard.GetOrdinal("ImpuestoPeriodo");
						int posTotalPeriodo = datard.GetOrdinal("TotalPeriodo");
						int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
						int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
				lbeAdjudicacionesPropuestasTecnicaEconomica = new List<beAdjudicacionesPropuestasTecnicaEconomica>();
				beAdjudicacionesPropuestasTecnicaEconomica obeAdjudicacionesPropuestasTecnicaEconomica;
				while (datard.Read())
				{
					 obeAdjudicacionesPropuestasTecnicaEconomica = new beAdjudicacionesPropuestasTecnicaEconomica();
					obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicionPropuestaTecEco =  datard.GetInt32(posIdAdjudicionPropuestaTecEco);
					obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicacionProveedor =  datard.GetInt32(posIdAdjudicacionProveedor);
					obeAdjudicacionesPropuestasTecnicaEconomica.IdLote =  datard.GetInt32(posIdLote);
					obeAdjudicacionesPropuestasTecnicaEconomica.Mejora =  datard.GetString(posMejora);
					obeAdjudicacionesPropuestasTecnicaEconomica.EstatusMejora =  datard.GetInt32(posEstatusMejora);
					obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioRefencia =  datard.GetDecimal(posPrecioUnitarioRefencia);
					obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioOfertado =  datard.GetDecimal(posPrecioUnitarioOfertado);
					obeAdjudicacionesPropuestasTecnicaEconomica.ImporteOfertado =  datard.GetDecimal(posImporteOfertado);
					obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPorcentaje =  datard.GetDecimal(posImpuestoPorcentaje);
					obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoImporte =  datard.GetDecimal(posImpuestoImporte);
					obeAdjudicacionesPropuestasTecnicaEconomica.TotalOfertado =  datard.GetDecimal(posTotalOfertado);
					obeAdjudicacionesPropuestasTecnicaEconomica.IdEstatusPropuesta =  datard.GetInt32(posIdEstatusPropuesta);
					obeAdjudicacionesPropuestasTecnicaEconomica.URLFileMuestraCatalogo =  datard.GetString(posURLFileMuestraCatalogo);
					obeAdjudicacionesPropuestasTecnicaEconomica.URLFileCertificacion =  datard.GetString(posURLFileCertificacion);
					obeAdjudicacionesPropuestasTecnicaEconomica.DependenciaCumple =  datard.GetInt32(posDependenciaCumple);
					obeAdjudicacionesPropuestasTecnicaEconomica.FundamentoLegal =  datard.GetString(posFundamentoLegal);
					obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionCumple =  datard.GetInt32(posAdquisicionCumple);
					obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionObserva =  datard.GetString(posAdquisicionObserva);
					obeAdjudicacionesPropuestasTecnicaEconomica.ProveedorGanador =  datard.GetInt32(posProveedorGanador);
					obeAdjudicacionesPropuestasTecnicaEconomica.ValidaEconomica =  datard.GetInt32(posValidaEconomica);
					obeAdjudicacionesPropuestasTecnicaEconomica.ImportePeriodo =  datard.GetDecimal(posImportePeriodo);
					obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPeriodo =  datard.GetDecimal(posImpuestoPeriodo);
					obeAdjudicacionesPropuestasTecnicaEconomica.TotalPeriodo =  datard.GetDecimal(posTotalPeriodo);
					obeAdjudicacionesPropuestasTecnicaEconomica.IdMesInicial =  datard.GetInt32(posIdMesInicial);
					obeAdjudicacionesPropuestasTecnicaEconomica.IdMesFinal =  datard.GetInt32(posIdMesFinal);
					lbeAdjudicacionesPropuestasTecnicaEconomica.Add(obeAdjudicacionesPropuestasTecnicaEconomica);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPropuestasTecnicaEconomica;
		}
	}
	public List< beAdjudicacionesPropuestasTecnicaEconomica> listar_AdjudicacionesPropuestasTecnicaEconomica_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesPropuestasTecnicaEconomica_TraerTodos_GetAll";
		List<beAdjudicacionesPropuestasTecnicaEconomica> lbeAdjudicacionesPropuestasTecnicaEconomica = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicionPropuestaTecEco = datard.GetOrdinal("IdAdjudicionPropuestaTecEco");
						int posIdAdjudicacionProveedor = datard.GetOrdinal("IdAdjudicacionProveedor");
						int posIdLote = datard.GetOrdinal("IdLote");
						int posMejora = datard.GetOrdinal("Mejora");
						int posEstatusMejora = datard.GetOrdinal("EstatusMejora");
						int posPrecioUnitarioRefencia = datard.GetOrdinal("PrecioUnitarioRefencia");
						int posPrecioUnitarioOfertado = datard.GetOrdinal("PrecioUnitarioOfertado");
						int posImporteOfertado = datard.GetOrdinal("ImporteOfertado");
						int posImpuestoPorcentaje = datard.GetOrdinal("ImpuestoPorcentaje");
						int posImpuestoImporte = datard.GetOrdinal("ImpuestoImporte");
						int posTotalOfertado = datard.GetOrdinal("TotalOfertado");
						int posIdEstatusPropuesta = datard.GetOrdinal("IdEstatusPropuesta");
						int posURLFileMuestraCatalogo = datard.GetOrdinal("URLFileMuestraCatalogo");
						int posURLFileCertificacion = datard.GetOrdinal("URLFileCertificacion");
						int posDependenciaCumple = datard.GetOrdinal("DependenciaCumple");
						int posFundamentoLegal = datard.GetOrdinal("FundamentoLegal");
						int posAdquisicionCumple = datard.GetOrdinal("AdquisicionCumple");
						int posAdquisicionObserva = datard.GetOrdinal("AdquisicionObserva");
						int posProveedorGanador = datard.GetOrdinal("ProveedorGanador");
						int posValidaEconomica = datard.GetOrdinal("ValidaEconomica");
						int posImportePeriodo = datard.GetOrdinal("ImportePeriodo");
						int posImpuestoPeriodo = datard.GetOrdinal("ImpuestoPeriodo");
						int posTotalPeriodo = datard.GetOrdinal("TotalPeriodo");
						int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
						int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
				lbeAdjudicacionesPropuestasTecnicaEconomica = new List<beAdjudicacionesPropuestasTecnicaEconomica>();
				beAdjudicacionesPropuestasTecnicaEconomica obeAdjudicacionesPropuestasTecnicaEconomica;
				while (datard.Read())
				{
					 obeAdjudicacionesPropuestasTecnicaEconomica = new beAdjudicacionesPropuestasTecnicaEconomica();
					obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicionPropuestaTecEco =  datard.GetInt32(posIdAdjudicionPropuestaTecEco);
					obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicacionProveedor =  datard.GetInt32(posIdAdjudicacionProveedor);
					obeAdjudicacionesPropuestasTecnicaEconomica.IdLote =  datard.GetInt32(posIdLote);
					obeAdjudicacionesPropuestasTecnicaEconomica.Mejora =  datard.GetString(posMejora);
					obeAdjudicacionesPropuestasTecnicaEconomica.EstatusMejora =  datard.GetInt32(posEstatusMejora);
					obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioRefencia =  datard.GetDecimal(posPrecioUnitarioRefencia);
					obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioOfertado =  datard.GetDecimal(posPrecioUnitarioOfertado);
					obeAdjudicacionesPropuestasTecnicaEconomica.ImporteOfertado =  datard.GetDecimal(posImporteOfertado);
					obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPorcentaje =  datard.GetDecimal(posImpuestoPorcentaje);
					obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoImporte =  datard.GetDecimal(posImpuestoImporte);
					obeAdjudicacionesPropuestasTecnicaEconomica.TotalOfertado =  datard.GetDecimal(posTotalOfertado);
					obeAdjudicacionesPropuestasTecnicaEconomica.IdEstatusPropuesta =  datard.GetInt32(posIdEstatusPropuesta);
					obeAdjudicacionesPropuestasTecnicaEconomica.URLFileMuestraCatalogo =  datard.GetString(posURLFileMuestraCatalogo);
					obeAdjudicacionesPropuestasTecnicaEconomica.URLFileCertificacion =  datard.GetString(posURLFileCertificacion);
					obeAdjudicacionesPropuestasTecnicaEconomica.DependenciaCumple =  datard.GetInt32(posDependenciaCumple);
					obeAdjudicacionesPropuestasTecnicaEconomica.FundamentoLegal =  datard.GetString(posFundamentoLegal);
					obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionCumple =  datard.GetInt32(posAdquisicionCumple);
					obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionObserva =  datard.GetString(posAdquisicionObserva);
					obeAdjudicacionesPropuestasTecnicaEconomica.ProveedorGanador =  datard.GetInt32(posProveedorGanador);
					obeAdjudicacionesPropuestasTecnicaEconomica.ValidaEconomica =  datard.GetInt32(posValidaEconomica);
					obeAdjudicacionesPropuestasTecnicaEconomica.ImportePeriodo =  datard.GetDecimal(posImportePeriodo);
					obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPeriodo =  datard.GetDecimal(posImpuestoPeriodo);
					obeAdjudicacionesPropuestasTecnicaEconomica.TotalPeriodo =  datard.GetDecimal(posTotalPeriodo);
					obeAdjudicacionesPropuestasTecnicaEconomica.IdMesInicial =  datard.GetInt32(posIdMesInicial);
					obeAdjudicacionesPropuestasTecnicaEconomica.IdMesFinal =  datard.GetInt32(posIdMesFinal);
			// debe agregar campos de la Vista
					lbeAdjudicacionesPropuestasTecnicaEconomica.Add(obeAdjudicacionesPropuestasTecnicaEconomica);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPropuestasTecnicaEconomica;
		}
	}

        public List<beAdjudicacionesPropuestasTecnicaEconomica> traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionProveedor(SqlConnection Conexion, int IdAdjudicacionProveedor)
        {

            string sp = "Proc_AdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicacionProveedor";
            List<beAdjudicacionesPropuestasTecnicaEconomica> lbeAdjudicacionesPropuestasTecnicaEconomica = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacionProveedor", SqlDbType.Int).Value = IdAdjudicacionProveedor;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
                        int posIdAdjudicacionProveedor = datard.GetOrdinal("IdAdjudicacionProveedor");
                        int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
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
                        int posDescripcionOrigenRecurso = datard.GetOrdinal("DescripcionOrigenRecurso");
                        int posTipoAdjudicacion = datard.GetOrdinal("TipoAdjudicacion");
                        int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int posDescripcionTiposSolicitud = datard.GetOrdinal("DescripcionTiposSolicitud");
                        int posAbreviaturaTiposSolicitud = datard.GetOrdinal("AbreviaturaTiposSolicitud");
                        int posEstatusAdjudicacion = datard.GetOrdinal("EstatusAdjudicacion");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posAbreviaturaDependencias = datard.GetOrdinal("AbreviaturaDependencias");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posIdAdjudicionPropuestaTecEco = datard.GetOrdinal("IdAdjudicionPropuestaTecEco");
						int posIdLote = datard.GetOrdinal("IdLote");
						int posMejora = datard.GetOrdinal("Mejora");
						int posEstatusMejora = datard.GetOrdinal("EstatusMejora");
						int posPrecioUnitarioRefencia = datard.GetOrdinal("PrecioUnitarioRefencia");
						int posPrecioUnitarioOfertado = datard.GetOrdinal("PrecioUnitarioOfertado");
						int posImporteOfertado = datard.GetOrdinal("ImporteOfertado");
						int posImpuestoPorcentaje = datard.GetOrdinal("ImpuestoPorcentaje");
						int posImpuestoImporte = datard.GetOrdinal("ImpuestoImporte");
						int posTotalOfertado = datard.GetOrdinal("TotalOfertado");
						int posIdEstatusPropuesta = datard.GetOrdinal("IdEstatusPropuesta");
						int posURLFileMuestraCatalogo = datard.GetOrdinal("URLFileMuestraCatalogo");
						int posURLFileCertificacion = datard.GetOrdinal("URLFileCertificacion");
						int posDependenciaCumple = datard.GetOrdinal("DependenciaCumple");
						int posFundamentoLegal = datard.GetOrdinal("FundamentoLegal");
						int posAdquisicionCumple = datard.GetOrdinal("AdquisicionCumple");
						int posAdquisicionObserva = datard.GetOrdinal("AdquisicionObserva");
						int posProveedorGanador = datard.GetOrdinal("ProveedorGanador");
						int posValidaEconomica = datard.GetOrdinal("ValidaEconomica");
						int posImportePeriodo = datard.GetOrdinal("ImportePeriodo");
						int posImpuestoPeriodo = datard.GetOrdinal("ImpuestoPeriodo");
						int posTotalPeriodo = datard.GetOrdinal("TotalPeriodo");
						int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
						int posIdMesFinal = datard.GetOrdinal("IdMesFinal");

                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posDescripcionBienServicio = datard.GetOrdinal("Descripcion");
                        int posIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posPantone = datard.GetOrdinal("Pantone");

                    lbeAdjudicacionesPropuestasTecnicaEconomica = new List<beAdjudicacionesPropuestasTecnicaEconomica>();
				    beAdjudicacionesPropuestasTecnicaEconomica obeAdjudicacionesPropuestasTecnicaEconomica;
				    while (datard.Read())
				    {
					     obeAdjudicacionesPropuestasTecnicaEconomica = new beAdjudicacionesPropuestasTecnicaEconomica();

                            obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicacionProveedor = datard.GetInt32(posIdAdjudicacionProveedor);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdProveedor = datard.GetInt32(posIdProveedor);
                            obeAdjudicacionesPropuestasTecnicaEconomica.RazonSocial = datard.GetString(posRazonSocial);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdTipoAdjudicacion = datard.GetInt32(posIdTipoAdjudicacion);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdOrigenRecursoAutorizado = datard.GetInt32(posIdOrigenRecursoAutorizado);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdEstatusAdjudicacion = datard.GetInt32(posIdEstatusAdjudicacion);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdPartida = datard.GetInt32(posIdPartida);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            obeAdjudicacionesPropuestasTecnicaEconomica.DescripcionOrigenRecurso = datard.GetString(posDescripcionOrigenRecurso);
                            obeAdjudicacionesPropuestasTecnicaEconomica.TipoAdjudicacion = datard.GetString(posTipoAdjudicacion);
                            obeAdjudicacionesPropuestasTecnicaEconomica.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            obeAdjudicacionesPropuestasTecnicaEconomica.DescripcionTiposSolicitud = datard.GetString(posDescripcionTiposSolicitud);
                            obeAdjudicacionesPropuestasTecnicaEconomica.AbreviaturaTiposSolicitud = datard.GetString(posAbreviaturaTiposSolicitud);
                            obeAdjudicacionesPropuestasTecnicaEconomica.EstatusAdjudicacion = datard.GetString(posEstatusAdjudicacion);
                            obeAdjudicacionesPropuestasTecnicaEconomica.Dependencia = datard.GetString(posDependencia);
                            obeAdjudicacionesPropuestasTecnicaEconomica.AbreviaturaDependencias = datard.GetString(posAbreviaturaDependencias);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            obeAdjudicacionesPropuestasTecnicaEconomica.Partida = datard.GetString(posPartida);
                            obeAdjudicacionesPropuestasTecnicaEconomica.Capitulo = datard.GetString(posCapitulo);
                            obeAdjudicacionesPropuestasTecnicaEconomica.Ejercicio = datard.GetInt32(posEjercicio);



                            obeAdjudicacionesPropuestasTecnicaEconomica.IdAdjudicionPropuestaTecEco =  datard.GetInt32(posIdAdjudicionPropuestaTecEco);
					        obeAdjudicacionesPropuestasTecnicaEconomica.IdLote =  datard.GetInt32(posIdLote);
					        obeAdjudicacionesPropuestasTecnicaEconomica.Mejora =  datard.GetString(posMejora);
					        obeAdjudicacionesPropuestasTecnicaEconomica.EstatusMejora =  datard.GetInt32(posEstatusMejora);
					        obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioRefencia =  datard.GetDecimal(posPrecioUnitarioRefencia);
					        obeAdjudicacionesPropuestasTecnicaEconomica.PrecioUnitarioOfertado =  datard.GetDecimal(posPrecioUnitarioOfertado);
					        obeAdjudicacionesPropuestasTecnicaEconomica.ImporteOfertado =  datard.GetDecimal(posImporteOfertado);
					        obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPorcentaje =  datard.GetDecimal(posImpuestoPorcentaje);
					        obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoImporte =  datard.GetDecimal(posImpuestoImporte);
					        obeAdjudicacionesPropuestasTecnicaEconomica.TotalOfertado =  datard.GetDecimal(posTotalOfertado);
					        obeAdjudicacionesPropuestasTecnicaEconomica.IdEstatusPropuesta =  datard.GetInt32(posIdEstatusPropuesta);
					        obeAdjudicacionesPropuestasTecnicaEconomica.URLFileMuestraCatalogo =  datard.GetString(posURLFileMuestraCatalogo);
					        obeAdjudicacionesPropuestasTecnicaEconomica.URLFileCertificacion =  datard.GetString(posURLFileCertificacion);
					        obeAdjudicacionesPropuestasTecnicaEconomica.DependenciaCumple =  datard.GetInt32(posDependenciaCumple);
					        obeAdjudicacionesPropuestasTecnicaEconomica.FundamentoLegal =  datard.GetString(posFundamentoLegal);
					        obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionCumple =  datard.GetInt32(posAdquisicionCumple);
					        obeAdjudicacionesPropuestasTecnicaEconomica.AdquisicionObserva =  datard.GetString(posAdquisicionObserva);
					        obeAdjudicacionesPropuestasTecnicaEconomica.ProveedorGanador =  datard.GetInt32(posProveedorGanador);
					        obeAdjudicacionesPropuestasTecnicaEconomica.ValidaEconomica =  datard.GetInt32(posValidaEconomica);
					        obeAdjudicacionesPropuestasTecnicaEconomica.ImportePeriodo =  datard.GetDecimal(posImportePeriodo);
					        obeAdjudicacionesPropuestasTecnicaEconomica.ImpuestoPeriodo =  datard.GetDecimal(posImpuestoPeriodo);
					        obeAdjudicacionesPropuestasTecnicaEconomica.TotalPeriodo =  datard.GetDecimal(posTotalPeriodo);
					        obeAdjudicacionesPropuestasTecnicaEconomica.IdMesInicial =  datard.GetInt32(posIdMesInicial);
					        obeAdjudicacionesPropuestasTecnicaEconomica.IdMesFinal =  datard.GetInt32(posIdMesFinal);

                            obeAdjudicacionesPropuestasTecnicaEconomica.NoLote = datard.GetInt32(posNoLote);
                            obeAdjudicacionesPropuestasTecnicaEconomica.Cantidad = datard.GetDecimal(posCantidad);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeAdjudicacionesPropuestasTecnicaEconomica.BienServicio = datard.GetString(posBienServicio);
                            obeAdjudicacionesPropuestasTecnicaEconomica.DescripcionBienServicio = datard.GetString(posDescripcionBienServicio);
                            obeAdjudicacionesPropuestasTecnicaEconomica.IdUnidadMedida = datard.GetInt32(posIdUnidadMedida);
                            obeAdjudicacionesPropuestasTecnicaEconomica.UnidadMedida = datard.GetString(posUnidadMedida);
                            obeAdjudicacionesPropuestasTecnicaEconomica.Pantone = datard.GetString(posPantone);

                            lbeAdjudicacionesPropuestasTecnicaEconomica.Add(obeAdjudicacionesPropuestasTecnicaEconomica);

                        }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeAdjudicacionesPropuestasTecnicaEconomica;
		    }
        }
    }
}
