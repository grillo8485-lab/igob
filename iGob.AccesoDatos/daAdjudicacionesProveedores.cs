using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesProveedores
 {
	public int guardarAdjudicacionesProveedores(SqlConnection Conexion, beAdjudicacionesProveedores obeAdjudicacionesProveedores)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesProveedoresInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionProveedor", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdAdjudicacionProveedor;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdAdjudicacion;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdProveedor;
				cmd.Parameters.Add("@IdEstatusEnvioPropuestaTecnica", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdEstatusEnvioPropuestaTecnica;
				cmd.Parameters.Add("@IdUsuaroEnviaPropuestaTecnica", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdUsuaroEnviaPropuestaTecnica;
				cmd.Parameters.Add("@FechaEnvioPropuestaTecnica", SqlDbType.DateTime).Value = obeAdjudicacionesProveedores.FechaEnvioPropuestaTecnica;
				cmd.Parameters.Add("@IdEstatusEnvioPropuestaEconomica", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdEstatusEnvioPropuestaEconomica;
				cmd.Parameters.Add("@IdUsuaroEnviaPropuestaEconomica", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdUsuaroEnviaPropuestaEconomica;
				cmd.Parameters.Add("@IdEstatusAdjudicacionProveedor", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdEstatusAdjudicacionProveedor;
				cmd.Parameters.Add("@FechaEnvioPropuestaEconomica", SqlDbType.DateTime).Value = obeAdjudicacionesProveedores.FechaEnvioPropuestaEconomica;
				cmd.Parameters.Add("@CartasDependenciaCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CartasDependenciaCumple;
				cmd.Parameters.Add("@CartaFundamento", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CartaFundamento;
				cmd.Parameters.Add("@CartaAdquisicionCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CartaAdquisicionCumple;
				cmd.Parameters.Add("@CartasAdqObservacion", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CartasAdqObservacion;
				cmd.Parameters.Add("@CondicionEntregaDependenciaCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CondicionEntregaDependenciaCumple;
				cmd.Parameters.Add("@CondicionEntregaFundamento", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CondicionEntregaFundamento;
				cmd.Parameters.Add("@CondicionEntregaAdquisicionCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CondicionEntregaAdquisicionCumple;
				cmd.Parameters.Add("@CondicionEntregaAdqObservacion", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CondicionEntregaAdqObservacion;
				cmd.Parameters.Add("@CondicionPagoDependenciaCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CondicionPagoDependenciaCumple;
				cmd.Parameters.Add("@CondicionPagoFundamento", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CondicionPagoFundamento;
				cmd.Parameters.Add("@CondicionPagoAdquisicionCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CondicionPagoAdquisicionCumple;
				cmd.Parameters.Add("@CondicionPagoAdqObservacion", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CondicionPagoAdqObservacion;
				cmd.Parameters.Add("@ManifiestoDependenciaCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ManifiestoDependenciaCumple;
				cmd.Parameters.Add("@ManifiestoFundamento", SqlDbType.Text).Value = obeAdjudicacionesProveedores.ManifiestoFundamento;
				cmd.Parameters.Add("@ManifiestoAdquisicionCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ManifiestoAdquisicionCumple;
				cmd.Parameters.Add("@ManifiestoAdqObservacion", SqlDbType.Text).Value = obeAdjudicacionesProveedores.ManifiestoAdqObservacion;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesProveedores.FechaRegistro;
				cmd.Parameters.Add("@ValidaLotesRevisor", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ValidaLotesRevisor;
				cmd.Parameters.Add("@ObservacionConEntregaRevisor", SqlDbType.Text).Value = obeAdjudicacionesProveedores.ObservacionConEntregaRevisor;
				cmd.Parameters.Add("@ValidaCondicionEntregaRevisor", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ValidaCondicionEntregaRevisor;
				cmd.Parameters.Add("@ObservacionCondPagoRevisor", SqlDbType.Text).Value = obeAdjudicacionesProveedores.ObservacionCondPagoRevisor;
				cmd.Parameters.Add("@ValidaCondicionPagoRevisor", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ValidaCondicionPagoRevisor;
				cmd.Parameters.Add("@ObservacionDoctosRevisor", SqlDbType.Text).Value = obeAdjudicacionesProveedores.ObservacionDoctosRevisor;
				cmd.Parameters.Add("@ValidaDocumentosRevisor", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ValidaDocumentosRevisor;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesProveedores(SqlConnection Conexion, beAdjudicacionesProveedores obeAdjudicacionesProveedores)
	{
		string sp = "Proc_AdjudicacionesProveedoresActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionProveedor", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdAdjudicacionProveedor;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdAdjudicacion;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdProveedor;
				cmd.Parameters.Add("@IdEstatusEnvioPropuestaTecnica", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdEstatusEnvioPropuestaTecnica;
				cmd.Parameters.Add("@IdUsuaroEnviaPropuestaTecnica", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdUsuaroEnviaPropuestaTecnica;
				cmd.Parameters.Add("@FechaEnvioPropuestaTecnica", SqlDbType.DateTime).Value = obeAdjudicacionesProveedores.FechaEnvioPropuestaTecnica;
				cmd.Parameters.Add("@IdEstatusEnvioPropuestaEconomica", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdEstatusEnvioPropuestaEconomica;
				cmd.Parameters.Add("@IdUsuaroEnviaPropuestaEconomica", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdUsuaroEnviaPropuestaEconomica;
				cmd.Parameters.Add("@IdEstatusAdjudicacionProveedor", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdEstatusAdjudicacionProveedor;
				cmd.Parameters.Add("@FechaEnvioPropuestaEconomica", SqlDbType.DateTime).Value = obeAdjudicacionesProveedores.FechaEnvioPropuestaEconomica;
				cmd.Parameters.Add("@CartasDependenciaCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CartasDependenciaCumple;
				cmd.Parameters.Add("@CartaFundamento", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CartaFundamento;
				cmd.Parameters.Add("@CartaAdquisicionCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CartaAdquisicionCumple;
				cmd.Parameters.Add("@CartasAdqObservacion", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CartasAdqObservacion;
				cmd.Parameters.Add("@CondicionEntregaDependenciaCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CondicionEntregaDependenciaCumple;
				cmd.Parameters.Add("@CondicionEntregaFundamento", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CondicionEntregaFundamento;
				cmd.Parameters.Add("@CondicionEntregaAdquisicionCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CondicionEntregaAdquisicionCumple;
				cmd.Parameters.Add("@CondicionEntregaAdqObservacion", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CondicionEntregaAdqObservacion;
				cmd.Parameters.Add("@CondicionPagoDependenciaCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CondicionPagoDependenciaCumple;
				cmd.Parameters.Add("@CondicionPagoFundamento", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CondicionPagoFundamento;
				cmd.Parameters.Add("@CondicionPagoAdquisicionCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.CondicionPagoAdquisicionCumple;
				cmd.Parameters.Add("@CondicionPagoAdqObservacion", SqlDbType.Text).Value = obeAdjudicacionesProveedores.CondicionPagoAdqObservacion;
				cmd.Parameters.Add("@ManifiestoDependenciaCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ManifiestoDependenciaCumple;
				cmd.Parameters.Add("@ManifiestoFundamento", SqlDbType.Text).Value = obeAdjudicacionesProveedores.ManifiestoFundamento;
				cmd.Parameters.Add("@ManifiestoAdquisicionCumple", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ManifiestoAdquisicionCumple;
				cmd.Parameters.Add("@ManifiestoAdqObservacion", SqlDbType.Text).Value = obeAdjudicacionesProveedores.ManifiestoAdqObservacion;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesProveedores.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesProveedores.FechaRegistro;
				cmd.Parameters.Add("@ValidaLotesRevisor", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ValidaLotesRevisor;
				cmd.Parameters.Add("@ObservacionConEntregaRevisor", SqlDbType.Text).Value = obeAdjudicacionesProveedores.ObservacionConEntregaRevisor;
				cmd.Parameters.Add("@ValidaCondicionEntregaRevisor", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ValidaCondicionEntregaRevisor;
				cmd.Parameters.Add("@ObservacionCondPagoRevisor", SqlDbType.Text).Value = obeAdjudicacionesProveedores.ObservacionCondPagoRevisor;
				cmd.Parameters.Add("@ValidaCondicionPagoRevisor", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ValidaCondicionPagoRevisor;
				cmd.Parameters.Add("@ObservacionDoctosRevisor", SqlDbType.Text).Value = obeAdjudicacionesProveedores.ObservacionDoctosRevisor;
				cmd.Parameters.Add("@ValidaDocumentosRevisor", SqlDbType.Bit).Value = obeAdjudicacionesProveedores.ValidaDocumentosRevisor;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesProveedores(SqlConnection Conexion,int pIdAdjudicacionProveedor)
	{
		string sp = "Proc_AdjudicacionesProveedoresEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionProveedor", SqlDbType.Int).Value = pIdAdjudicacionProveedor;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesProveedores traerAdjudicacionesProveedores_x_IdAdjudicacionProveedor(SqlConnection Conexion,int IdAdjudicacionProveedor)
	{
		string sp = "Proc_AdjudicacionesProveedores_x_IdAdjudicacionProveedor";
				beAdjudicacionesProveedores obeAdjudicacionesProveedores=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
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
						int posIdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
						int posIdUsuaroEnviaPropuestaTecnica = datard.GetOrdinal("IdUsuaroEnviaPropuestaTecnica");
						int posFechaEnvioPropuestaTecnica = datard.GetOrdinal("FechaEnvioPropuestaTecnica");
						int posIdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
						int posIdUsuaroEnviaPropuestaEconomica = datard.GetOrdinal("IdUsuaroEnviaPropuestaEconomica");
						int posIdEstatusAdjudicacionProveedor = datard.GetOrdinal("IdEstatusAdjudicacionProveedor");
						int posFechaEnvioPropuestaEconomica = datard.GetOrdinal("FechaEnvioPropuestaEconomica");
						int posCartasDependenciaCumple = datard.GetOrdinal("CartasDependenciaCumple");
						int posCartaFundamento = datard.GetOrdinal("CartaFundamento");
						int posCartaAdquisicionCumple = datard.GetOrdinal("CartaAdquisicionCumple");
						int posCartasAdqObservacion = datard.GetOrdinal("CartasAdqObservacion");
						int posCondicionEntregaDependenciaCumple = datard.GetOrdinal("CondicionEntregaDependenciaCumple");
						int posCondicionEntregaFundamento = datard.GetOrdinal("CondicionEntregaFundamento");
						int posCondicionEntregaAdquisicionCumple = datard.GetOrdinal("CondicionEntregaAdquisicionCumple");
						int posCondicionEntregaAdqObservacion = datard.GetOrdinal("CondicionEntregaAdqObservacion");
						int posCondicionPagoDependenciaCumple = datard.GetOrdinal("CondicionPagoDependenciaCumple");
						int posCondicionPagoFundamento = datard.GetOrdinal("CondicionPagoFundamento");
						int posCondicionPagoAdquisicionCumple = datard.GetOrdinal("CondicionPagoAdquisicionCumple");
						int posCondicionPagoAdqObservacion = datard.GetOrdinal("CondicionPagoAdqObservacion");
						int posManifiestoDependenciaCumple = datard.GetOrdinal("ManifiestoDependenciaCumple");
						int posManifiestoFundamento = datard.GetOrdinal("ManifiestoFundamento");
						int posManifiestoAdquisicionCumple = datard.GetOrdinal("ManifiestoAdquisicionCumple");
						int posManifiestoAdqObservacion = datard.GetOrdinal("ManifiestoAdqObservacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posValidaLotesRevisor = datard.GetOrdinal("ValidaLotesRevisor");
						int posObservacionConEntregaRevisor = datard.GetOrdinal("ObservacionConEntregaRevisor");
						int posValidaCondicionEntregaRevisor = datard.GetOrdinal("ValidaCondicionEntregaRevisor");
						int posObservacionCondPagoRevisor = datard.GetOrdinal("ObservacionCondPagoRevisor");
						int posValidaCondicionPagoRevisor = datard.GetOrdinal("ValidaCondicionPagoRevisor");
						int posObservacionDoctosRevisor = datard.GetOrdinal("ObservacionDoctosRevisor");
						int posValidaDocumentosRevisor = datard.GetOrdinal("ValidaDocumentosRevisor");
					 obeAdjudicacionesProveedores = new beAdjudicacionesProveedores();
				while (datard.Read())
					{
						obeAdjudicacionesProveedores.IdAdjudicacionProveedor =  datard.GetInt32(posIdAdjudicacionProveedor);
						obeAdjudicacionesProveedores.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
						obeAdjudicacionesProveedores.IdProveedor =  datard.GetInt32(posIdProveedor);
						obeAdjudicacionesProveedores.IdEstatusEnvioPropuestaTecnica =  datard.GetInt32(posIdEstatusEnvioPropuestaTecnica);
						obeAdjudicacionesProveedores.IdUsuaroEnviaPropuestaTecnica =  datard.GetInt32(posIdUsuaroEnviaPropuestaTecnica);
						obeAdjudicacionesProveedores.FechaEnvioPropuestaTecnica =  datard.GetDateTime(posFechaEnvioPropuestaTecnica);
						obeAdjudicacionesProveedores.IdEstatusEnvioPropuestaEconomica =  datard.GetInt32(posIdEstatusEnvioPropuestaEconomica);
						obeAdjudicacionesProveedores.IdUsuaroEnviaPropuestaEconomica =  datard.GetInt32(posIdUsuaroEnviaPropuestaEconomica);
						obeAdjudicacionesProveedores.IdEstatusAdjudicacionProveedor =  datard.GetInt32(posIdEstatusAdjudicacionProveedor);
						obeAdjudicacionesProveedores.FechaEnvioPropuestaEconomica =  datard.GetDateTime(posFechaEnvioPropuestaEconomica);
						obeAdjudicacionesProveedores.CartasDependenciaCumple =  datard.GetBoolean(posCartasDependenciaCumple);
						obeAdjudicacionesProveedores.CartaFundamento =  datard.GetString(posCartaFundamento);
						obeAdjudicacionesProveedores.CartaAdquisicionCumple =  datard.GetBoolean(posCartaAdquisicionCumple);
						obeAdjudicacionesProveedores.CartasAdqObservacion =  datard.GetString(posCartasAdqObservacion);
						obeAdjudicacionesProveedores.CondicionEntregaDependenciaCumple =  datard.GetBoolean(posCondicionEntregaDependenciaCumple);
						obeAdjudicacionesProveedores.CondicionEntregaFundamento =  datard.GetString(posCondicionEntregaFundamento);
						obeAdjudicacionesProveedores.CondicionEntregaAdquisicionCumple =  datard.GetBoolean(posCondicionEntregaAdquisicionCumple);
						obeAdjudicacionesProveedores.CondicionEntregaAdqObservacion =  datard.GetString(posCondicionEntregaAdqObservacion);
						obeAdjudicacionesProveedores.CondicionPagoDependenciaCumple =  datard.GetBoolean(posCondicionPagoDependenciaCumple);
						obeAdjudicacionesProveedores.CondicionPagoFundamento =  datard.GetString(posCondicionPagoFundamento);
						obeAdjudicacionesProveedores.CondicionPagoAdquisicionCumple =  datard.GetBoolean(posCondicionPagoAdquisicionCumple);
						obeAdjudicacionesProveedores.CondicionPagoAdqObservacion =  datard.GetString(posCondicionPagoAdqObservacion);
						obeAdjudicacionesProveedores.ManifiestoDependenciaCumple =  datard.GetBoolean(posManifiestoDependenciaCumple);
						obeAdjudicacionesProveedores.ManifiestoFundamento =  datard.GetString(posManifiestoFundamento);
						obeAdjudicacionesProveedores.ManifiestoAdquisicionCumple =  datard.GetBoolean(posManifiestoAdquisicionCumple);
						obeAdjudicacionesProveedores.ManifiestoAdqObservacion =  datard.GetString(posManifiestoAdqObservacion);
						obeAdjudicacionesProveedores.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeAdjudicacionesProveedores.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
						obeAdjudicacionesProveedores.ValidaLotesRevisor =  datard.GetBoolean(posValidaLotesRevisor);
						obeAdjudicacionesProveedores.ObservacionConEntregaRevisor =  datard.GetString(posObservacionConEntregaRevisor);
						obeAdjudicacionesProveedores.ValidaCondicionEntregaRevisor =  datard.GetBoolean(posValidaCondicionEntregaRevisor);
						obeAdjudicacionesProveedores.ObservacionCondPagoRevisor =  datard.GetString(posObservacionCondPagoRevisor);
						obeAdjudicacionesProveedores.ValidaCondicionPagoRevisor =  datard.GetBoolean(posValidaCondicionPagoRevisor);
						obeAdjudicacionesProveedores.ObservacionDoctosRevisor =  datard.GetString(posObservacionDoctosRevisor);
						obeAdjudicacionesProveedores.ValidaDocumentosRevisor =  datard.GetBoolean(posValidaDocumentosRevisor);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesProveedores;
			}
	}
	public List< beAdjudicacionesProveedores> listarTodos_AdjudicacionesProveedores(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesProveedores_Traer_Todos";
		List<beAdjudicacionesProveedores> lbeAdjudicacionesProveedores = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionProveedor = datard.GetOrdinal("IdAdjudicacionProveedor");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
						int posIdUsuaroEnviaPropuestaTecnica = datard.GetOrdinal("IdUsuaroEnviaPropuestaTecnica");
						int posFechaEnvioPropuestaTecnica = datard.GetOrdinal("FechaEnvioPropuestaTecnica");
						int posIdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
						int posIdUsuaroEnviaPropuestaEconomica = datard.GetOrdinal("IdUsuaroEnviaPropuestaEconomica");
						int posIdEstatusAdjudicacionProveedor = datard.GetOrdinal("IdEstatusAdjudicacionProveedor");
						int posFechaEnvioPropuestaEconomica = datard.GetOrdinal("FechaEnvioPropuestaEconomica");
						int posCartasDependenciaCumple = datard.GetOrdinal("CartasDependenciaCumple");
						int posCartaFundamento = datard.GetOrdinal("CartaFundamento");
						int posCartaAdquisicionCumple = datard.GetOrdinal("CartaAdquisicionCumple");
						int posCartasAdqObservacion = datard.GetOrdinal("CartasAdqObservacion");
						int posCondicionEntregaDependenciaCumple = datard.GetOrdinal("CondicionEntregaDependenciaCumple");
						int posCondicionEntregaFundamento = datard.GetOrdinal("CondicionEntregaFundamento");
						int posCondicionEntregaAdquisicionCumple = datard.GetOrdinal("CondicionEntregaAdquisicionCumple");
						int posCondicionEntregaAdqObservacion = datard.GetOrdinal("CondicionEntregaAdqObservacion");
						int posCondicionPagoDependenciaCumple = datard.GetOrdinal("CondicionPagoDependenciaCumple");
						int posCondicionPagoFundamento = datard.GetOrdinal("CondicionPagoFundamento");
						int posCondicionPagoAdquisicionCumple = datard.GetOrdinal("CondicionPagoAdquisicionCumple");
						int posCondicionPagoAdqObservacion = datard.GetOrdinal("CondicionPagoAdqObservacion");
						int posManifiestoDependenciaCumple = datard.GetOrdinal("ManifiestoDependenciaCumple");
						int posManifiestoFundamento = datard.GetOrdinal("ManifiestoFundamento");
						int posManifiestoAdquisicionCumple = datard.GetOrdinal("ManifiestoAdquisicionCumple");
						int posManifiestoAdqObservacion = datard.GetOrdinal("ManifiestoAdqObservacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posValidaLotesRevisor = datard.GetOrdinal("ValidaLotesRevisor");
						int posObservacionConEntregaRevisor = datard.GetOrdinal("ObservacionConEntregaRevisor");
						int posValidaCondicionEntregaRevisor = datard.GetOrdinal("ValidaCondicionEntregaRevisor");
						int posObservacionCondPagoRevisor = datard.GetOrdinal("ObservacionCondPagoRevisor");
						int posValidaCondicionPagoRevisor = datard.GetOrdinal("ValidaCondicionPagoRevisor");
						int posObservacionDoctosRevisor = datard.GetOrdinal("ObservacionDoctosRevisor");
						int posValidaDocumentosRevisor = datard.GetOrdinal("ValidaDocumentosRevisor");
				lbeAdjudicacionesProveedores = new List<beAdjudicacionesProveedores>();
				beAdjudicacionesProveedores obeAdjudicacionesProveedores;
				while (datard.Read())
				{
					 obeAdjudicacionesProveedores = new beAdjudicacionesProveedores();
					obeAdjudicacionesProveedores.IdAdjudicacionProveedor =  datard.GetInt32(posIdAdjudicacionProveedor);
					obeAdjudicacionesProveedores.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesProveedores.IdProveedor =  datard.GetInt32(posIdProveedor);
					obeAdjudicacionesProveedores.IdEstatusEnvioPropuestaTecnica =  datard.GetInt32(posIdEstatusEnvioPropuestaTecnica);
					obeAdjudicacionesProveedores.IdUsuaroEnviaPropuestaTecnica =  datard.GetInt32(posIdUsuaroEnviaPropuestaTecnica);
					obeAdjudicacionesProveedores.FechaEnvioPropuestaTecnica =  datard.GetDateTime(posFechaEnvioPropuestaTecnica);
					obeAdjudicacionesProveedores.IdEstatusEnvioPropuestaEconomica =  datard.GetInt32(posIdEstatusEnvioPropuestaEconomica);
					obeAdjudicacionesProveedores.IdUsuaroEnviaPropuestaEconomica =  datard.GetInt32(posIdUsuaroEnviaPropuestaEconomica);
					obeAdjudicacionesProveedores.IdEstatusAdjudicacionProveedor =  datard.GetInt32(posIdEstatusAdjudicacionProveedor);
					obeAdjudicacionesProveedores.FechaEnvioPropuestaEconomica =  datard.GetDateTime(posFechaEnvioPropuestaEconomica);
					obeAdjudicacionesProveedores.CartasDependenciaCumple =  datard.GetBoolean(posCartasDependenciaCumple);
					obeAdjudicacionesProveedores.CartaFundamento =  datard.GetString(posCartaFundamento);
					obeAdjudicacionesProveedores.CartaAdquisicionCumple =  datard.GetBoolean(posCartaAdquisicionCumple);
					obeAdjudicacionesProveedores.CartasAdqObservacion =  datard.GetString(posCartasAdqObservacion);
					obeAdjudicacionesProveedores.CondicionEntregaDependenciaCumple =  datard.GetBoolean(posCondicionEntregaDependenciaCumple);
					obeAdjudicacionesProveedores.CondicionEntregaFundamento =  datard.GetString(posCondicionEntregaFundamento);
					obeAdjudicacionesProveedores.CondicionEntregaAdquisicionCumple =  datard.GetBoolean(posCondicionEntregaAdquisicionCumple);
					obeAdjudicacionesProveedores.CondicionEntregaAdqObservacion =  datard.GetString(posCondicionEntregaAdqObservacion);
					obeAdjudicacionesProveedores.CondicionPagoDependenciaCumple =  datard.GetBoolean(posCondicionPagoDependenciaCumple);
					obeAdjudicacionesProveedores.CondicionPagoFundamento =  datard.GetString(posCondicionPagoFundamento);
					obeAdjudicacionesProveedores.CondicionPagoAdquisicionCumple =  datard.GetBoolean(posCondicionPagoAdquisicionCumple);
					obeAdjudicacionesProveedores.CondicionPagoAdqObservacion =  datard.GetString(posCondicionPagoAdqObservacion);
					obeAdjudicacionesProveedores.ManifiestoDependenciaCumple =  datard.GetBoolean(posManifiestoDependenciaCumple);
					obeAdjudicacionesProveedores.ManifiestoFundamento =  datard.GetString(posManifiestoFundamento);
					obeAdjudicacionesProveedores.ManifiestoAdquisicionCumple =  datard.GetBoolean(posManifiestoAdquisicionCumple);
					obeAdjudicacionesProveedores.ManifiestoAdqObservacion =  datard.GetString(posManifiestoAdqObservacion);
					obeAdjudicacionesProveedores.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeAdjudicacionesProveedores.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeAdjudicacionesProveedores.ValidaLotesRevisor =  datard.GetBoolean(posValidaLotesRevisor);
					obeAdjudicacionesProveedores.ObservacionConEntregaRevisor =  datard.GetString(posObservacionConEntregaRevisor);
					obeAdjudicacionesProveedores.ValidaCondicionEntregaRevisor =  datard.GetBoolean(posValidaCondicionEntregaRevisor);
					obeAdjudicacionesProveedores.ObservacionCondPagoRevisor =  datard.GetString(posObservacionCondPagoRevisor);
					obeAdjudicacionesProveedores.ValidaCondicionPagoRevisor =  datard.GetBoolean(posValidaCondicionPagoRevisor);
					obeAdjudicacionesProveedores.ObservacionDoctosRevisor =  datard.GetString(posObservacionDoctosRevisor);
					obeAdjudicacionesProveedores.ValidaDocumentosRevisor =  datard.GetBoolean(posValidaDocumentosRevisor);
					lbeAdjudicacionesProveedores.Add(obeAdjudicacionesProveedores);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesProveedores;
		}
	}
	public List< beAdjudicacionesProveedores> listar_AdjudicacionesProveedores_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesProveedores_TraerTodos_GetAll";
		List<beAdjudicacionesProveedores> lbeAdjudicacionesProveedores = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionProveedor = datard.GetOrdinal("IdAdjudicacionProveedor");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
						int posIdUsuaroEnviaPropuestaTecnica = datard.GetOrdinal("IdUsuaroEnviaPropuestaTecnica");
						int posFechaEnvioPropuestaTecnica = datard.GetOrdinal("FechaEnvioPropuestaTecnica");
						int posIdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
						int posIdUsuaroEnviaPropuestaEconomica = datard.GetOrdinal("IdUsuaroEnviaPropuestaEconomica");
						int posIdEstatusAdjudicacionProveedor = datard.GetOrdinal("IdEstatusAdjudicacionProveedor");
						int posFechaEnvioPropuestaEconomica = datard.GetOrdinal("FechaEnvioPropuestaEconomica");
						int posCartasDependenciaCumple = datard.GetOrdinal("CartasDependenciaCumple");
						int posCartaFundamento = datard.GetOrdinal("CartaFundamento");
						int posCartaAdquisicionCumple = datard.GetOrdinal("CartaAdquisicionCumple");
						int posCartasAdqObservacion = datard.GetOrdinal("CartasAdqObservacion");
						int posCondicionEntregaDependenciaCumple = datard.GetOrdinal("CondicionEntregaDependenciaCumple");
						int posCondicionEntregaFundamento = datard.GetOrdinal("CondicionEntregaFundamento");
						int posCondicionEntregaAdquisicionCumple = datard.GetOrdinal("CondicionEntregaAdquisicionCumple");
						int posCondicionEntregaAdqObservacion = datard.GetOrdinal("CondicionEntregaAdqObservacion");
						int posCondicionPagoDependenciaCumple = datard.GetOrdinal("CondicionPagoDependenciaCumple");
						int posCondicionPagoFundamento = datard.GetOrdinal("CondicionPagoFundamento");
						int posCondicionPagoAdquisicionCumple = datard.GetOrdinal("CondicionPagoAdquisicionCumple");
						int posCondicionPagoAdqObservacion = datard.GetOrdinal("CondicionPagoAdqObservacion");
						int posManifiestoDependenciaCumple = datard.GetOrdinal("ManifiestoDependenciaCumple");
						int posManifiestoFundamento = datard.GetOrdinal("ManifiestoFundamento");
						int posManifiestoAdquisicionCumple = datard.GetOrdinal("ManifiestoAdquisicionCumple");
						int posManifiestoAdqObservacion = datard.GetOrdinal("ManifiestoAdqObservacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posValidaLotesRevisor = datard.GetOrdinal("ValidaLotesRevisor");
						int posObservacionConEntregaRevisor = datard.GetOrdinal("ObservacionConEntregaRevisor");
						int posValidaCondicionEntregaRevisor = datard.GetOrdinal("ValidaCondicionEntregaRevisor");
						int posObservacionCondPagoRevisor = datard.GetOrdinal("ObservacionCondPagoRevisor");
						int posValidaCondicionPagoRevisor = datard.GetOrdinal("ValidaCondicionPagoRevisor");
						int posObservacionDoctosRevisor = datard.GetOrdinal("ObservacionDoctosRevisor");
						int posValidaDocumentosRevisor = datard.GetOrdinal("ValidaDocumentosRevisor");
				lbeAdjudicacionesProveedores = new List<beAdjudicacionesProveedores>();
				beAdjudicacionesProveedores obeAdjudicacionesProveedores;
				while (datard.Read())
				{
					 obeAdjudicacionesProveedores = new beAdjudicacionesProveedores();
					obeAdjudicacionesProveedores.IdAdjudicacionProveedor =  datard.GetInt32(posIdAdjudicacionProveedor);
					obeAdjudicacionesProveedores.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesProveedores.IdProveedor =  datard.GetInt32(posIdProveedor);
					obeAdjudicacionesProveedores.IdEstatusEnvioPropuestaTecnica =  datard.GetInt32(posIdEstatusEnvioPropuestaTecnica);
					obeAdjudicacionesProveedores.IdUsuaroEnviaPropuestaTecnica =  datard.GetInt32(posIdUsuaroEnviaPropuestaTecnica);
					obeAdjudicacionesProveedores.FechaEnvioPropuestaTecnica =  datard.GetDateTime(posFechaEnvioPropuestaTecnica);
					obeAdjudicacionesProveedores.IdEstatusEnvioPropuestaEconomica =  datard.GetInt32(posIdEstatusEnvioPropuestaEconomica);
					obeAdjudicacionesProveedores.IdUsuaroEnviaPropuestaEconomica =  datard.GetInt32(posIdUsuaroEnviaPropuestaEconomica);
					obeAdjudicacionesProveedores.IdEstatusAdjudicacionProveedor =  datard.GetInt32(posIdEstatusAdjudicacionProveedor);
					obeAdjudicacionesProveedores.FechaEnvioPropuestaEconomica =  datard.GetDateTime(posFechaEnvioPropuestaEconomica);
					obeAdjudicacionesProveedores.CartasDependenciaCumple =  datard.GetBoolean(posCartasDependenciaCumple);
					obeAdjudicacionesProveedores.CartaFundamento =  datard.GetString(posCartaFundamento);
					obeAdjudicacionesProveedores.CartaAdquisicionCumple =  datard.GetBoolean(posCartaAdquisicionCumple);
					obeAdjudicacionesProveedores.CartasAdqObservacion =  datard.GetString(posCartasAdqObservacion);
					obeAdjudicacionesProveedores.CondicionEntregaDependenciaCumple =  datard.GetBoolean(posCondicionEntregaDependenciaCumple);
					obeAdjudicacionesProveedores.CondicionEntregaFundamento =  datard.GetString(posCondicionEntregaFundamento);
					obeAdjudicacionesProveedores.CondicionEntregaAdquisicionCumple =  datard.GetBoolean(posCondicionEntregaAdquisicionCumple);
					obeAdjudicacionesProveedores.CondicionEntregaAdqObservacion =  datard.GetString(posCondicionEntregaAdqObservacion);
					obeAdjudicacionesProveedores.CondicionPagoDependenciaCumple =  datard.GetBoolean(posCondicionPagoDependenciaCumple);
					obeAdjudicacionesProveedores.CondicionPagoFundamento =  datard.GetString(posCondicionPagoFundamento);
					obeAdjudicacionesProveedores.CondicionPagoAdquisicionCumple =  datard.GetBoolean(posCondicionPagoAdquisicionCumple);
					obeAdjudicacionesProveedores.CondicionPagoAdqObservacion =  datard.GetString(posCondicionPagoAdqObservacion);
					obeAdjudicacionesProveedores.ManifiestoDependenciaCumple =  datard.GetBoolean(posManifiestoDependenciaCumple);
					obeAdjudicacionesProveedores.ManifiestoFundamento =  datard.GetString(posManifiestoFundamento);
					obeAdjudicacionesProveedores.ManifiestoAdquisicionCumple =  datard.GetBoolean(posManifiestoAdquisicionCumple);
					obeAdjudicacionesProveedores.ManifiestoAdqObservacion =  datard.GetString(posManifiestoAdqObservacion);
					obeAdjudicacionesProveedores.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeAdjudicacionesProveedores.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeAdjudicacionesProveedores.ValidaLotesRevisor =  datard.GetBoolean(posValidaLotesRevisor);
					obeAdjudicacionesProveedores.ObservacionConEntregaRevisor =  datard.GetString(posObservacionConEntregaRevisor);
					obeAdjudicacionesProveedores.ValidaCondicionEntregaRevisor =  datard.GetBoolean(posValidaCondicionEntregaRevisor);
					obeAdjudicacionesProveedores.ObservacionCondPagoRevisor =  datard.GetString(posObservacionCondPagoRevisor);
					obeAdjudicacionesProveedores.ValidaCondicionPagoRevisor =  datard.GetBoolean(posValidaCondicionPagoRevisor);
					obeAdjudicacionesProveedores.ObservacionDoctosRevisor =  datard.GetString(posObservacionDoctosRevisor);
					obeAdjudicacionesProveedores.ValidaDocumentosRevisor =  datard.GetBoolean(posValidaDocumentosRevisor);
			// debe agregar campos de la Vista
					lbeAdjudicacionesProveedores.Add(obeAdjudicacionesProveedores);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesProveedores;
		}
	}


        public List<beAdjudicacionesProveedores> getAllProveedoresAdjudicacion_x_IdAdjudicacion(SqlConnection Conexion, int IdAdjudicacion, int IdEstatusAdjudicacionProveedor)
        {
            string sp = "Proc_AdjudicacionesProveedores_x_IdAdjudicacion";
            List<beAdjudicacionesProveedores> lbeAdjudicacionesProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            cmd.Parameters.Add("@IdEstatusAdjudicacionProveedor", SqlDbType.Int).Value = IdEstatusAdjudicacionProveedor;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
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
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");

                        lbeAdjudicacionesProveedores = new List<beAdjudicacionesProveedores>();
                        beAdjudicacionesProveedores obeAdjudicacionesProveedores;
                        while (datard.Read())
                        {
                            obeAdjudicacionesProveedores = new beAdjudicacionesProveedores();
                            obeAdjudicacionesProveedores.IdAdjudicacionProveedor = datard.GetInt32(posIdAdjudicacionProveedor);
                            obeAdjudicacionesProveedores.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicacionesProveedores.IdProveedor = datard.GetInt32(posIdProveedor);
                            obeAdjudicacionesProveedores.RazonSocial = datard.GetString(posRazonSocial);
                            obeAdjudicacionesProveedores.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeAdjudicacionesProveedores.IdTipoAdjudicacion = datard.GetInt32(posIdTipoAdjudicacion);
                            obeAdjudicacionesProveedores.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeAdjudicacionesProveedores.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeAdjudicacionesProveedores.IdOrigenRecursoAutorizado = datard.GetInt32(posIdOrigenRecursoAutorizado);
                            obeAdjudicacionesProveedores.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeAdjudicacionesProveedores.IdEstatusAdjudicacion = datard.GetInt32(posIdEstatusAdjudicacion);
                            obeAdjudicacionesProveedores.IdPartida = datard.GetInt32(posIdPartida);
                            obeAdjudicacionesProveedores.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obeAdjudicacionesProveedores.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            obeAdjudicacionesProveedores.DescripcionOrigenRecurso = datard.GetString(posDescripcionOrigenRecurso);
                            obeAdjudicacionesProveedores.TipoAdjudicacion = datard.GetString(posTipoAdjudicacion);
                            obeAdjudicacionesProveedores.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            obeAdjudicacionesProveedores.DescripcionTiposSolicitud = datard.GetString(posDescripcionTiposSolicitud);
                            obeAdjudicacionesProveedores.AbreviaturaTiposSolicitud = datard.GetString(posAbreviaturaTiposSolicitud);
                            obeAdjudicacionesProveedores.EstatusAdjudicacion = datard.GetString(posEstatusAdjudicacion);
                            obeAdjudicacionesProveedores.Dependencia = datard.GetString(posDependencia);
                            obeAdjudicacionesProveedores.AbreviaturaDependencias = datard.GetString(posAbreviaturaDependencias);
                            obeAdjudicacionesProveedores.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeAdjudicacionesProveedores.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            obeAdjudicacionesProveedores.Partida = datard.GetString(posPartida);
                            obeAdjudicacionesProveedores.Capitulo = datard.GetString(posCapitulo);
                            obeAdjudicacionesProveedores.Ejercicio = datard.GetInt32(posEjercicio);
                            obeAdjudicacionesProveedores.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            obeAdjudicacionesProveedores.ImporteTotalLotes = datard.GetDecimal(posImporteTotalLotes);
                            // debe agregar campos de la Vista
                            lbeAdjudicacionesProveedores.Add(obeAdjudicacionesProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesProveedores;
            }
        }

        public List<beAdjudicacionesProveedores> listarAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicacion(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_AdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicacion";
            List<beAdjudicacionesProveedores> lbeAdjudicacionesProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
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
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");

                        lbeAdjudicacionesProveedores = new List<beAdjudicacionesProveedores>();
                        beAdjudicacionesProveedores obeAdjudicacionesProveedores;
                        while (datard.Read())
                        {
                            obeAdjudicacionesProveedores = new beAdjudicacionesProveedores();
                            obeAdjudicacionesProveedores.IdAdjudicacionProveedor = datard.GetInt32(posIdAdjudicacionProveedor);
                            obeAdjudicacionesProveedores.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicacionesProveedores.IdProveedor = datard.GetInt32(posIdProveedor);
                            obeAdjudicacionesProveedores.RazonSocial = datard.GetString(posRazonSocial);
                            obeAdjudicacionesProveedores.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeAdjudicacionesProveedores.IdTipoAdjudicacion = datard.GetInt32(posIdTipoAdjudicacion);
                            obeAdjudicacionesProveedores.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeAdjudicacionesProveedores.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeAdjudicacionesProveedores.IdOrigenRecursoAutorizado = datard.GetInt32(posIdOrigenRecursoAutorizado);
                            obeAdjudicacionesProveedores.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeAdjudicacionesProveedores.IdEstatusAdjudicacion = datard.GetInt32(posIdEstatusAdjudicacion);
                            obeAdjudicacionesProveedores.IdPartida = datard.GetInt32(posIdPartida);
                            obeAdjudicacionesProveedores.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obeAdjudicacionesProveedores.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            obeAdjudicacionesProveedores.DescripcionOrigenRecurso = datard.GetString(posDescripcionOrigenRecurso);
                            obeAdjudicacionesProveedores.TipoAdjudicacion = datard.GetString(posTipoAdjudicacion);
                            obeAdjudicacionesProveedores.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            obeAdjudicacionesProveedores.DescripcionTiposSolicitud = datard.GetString(posDescripcionTiposSolicitud);
                            obeAdjudicacionesProveedores.AbreviaturaTiposSolicitud = datard.GetString(posAbreviaturaTiposSolicitud);
                            obeAdjudicacionesProveedores.EstatusAdjudicacion = datard.GetString(posEstatusAdjudicacion);
                            obeAdjudicacionesProveedores.Dependencia = datard.GetString(posDependencia);
                            obeAdjudicacionesProveedores.AbreviaturaDependencias = datard.GetString(posAbreviaturaDependencias);
                            obeAdjudicacionesProveedores.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeAdjudicacionesProveedores.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            obeAdjudicacionesProveedores.Partida = datard.GetString(posPartida);
                            obeAdjudicacionesProveedores.Capitulo = datard.GetString(posCapitulo);
                            obeAdjudicacionesProveedores.Ejercicio = datard.GetInt32(posEjercicio);
                            obeAdjudicacionesProveedores.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            obeAdjudicacionesProveedores.ImporteTotalLotes = datard.GetDecimal(posImporteTotalLotes);
                            // debe agregar campos de la Vista
                            lbeAdjudicacionesProveedores.Add(obeAdjudicacionesProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesProveedores;
            }
        }
    }
}
