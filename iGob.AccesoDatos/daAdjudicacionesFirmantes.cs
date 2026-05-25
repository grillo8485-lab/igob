using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesFirmantes
 {
	public int guardarAdjudicacionesFirmantes(SqlConnection Conexion, beAdjudicacionesFirmantes obeAdjudicacionesFirmantes)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesFirmantesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionFirmante", SqlDbType.Int).Value = obeAdjudicacionesFirmantes.IdAdjudicacionFirmante;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesFirmantes.IdAdjudicacion;
				cmd.Parameters.Add("@IdEstatusAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesFirmantes.IdEstatusAdjudicacion;
				cmd.Parameters.Add("@IdUsuarioSolicitante", SqlDbType.Int).Value = obeAdjudicacionesFirmantes.IdUsuarioSolicitante;
				cmd.Parameters.Add("@IdUsuarioAutoriza", SqlDbType.Int).Value = obeAdjudicacionesFirmantes.IdUsuarioAutoriza;
				cmd.Parameters.Add("@ValidaLotes", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaLotes;
				cmd.Parameters.Add("@ObservacionLotes", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionLotes;
				cmd.Parameters.Add("@ValidaCondicionEntrega", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaCondicionEntrega;
				cmd.Parameters.Add("@OnservacionCondicionEntrega", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.OnservacionCondicionEntrega;
				cmd.Parameters.Add("@ValidaCondicionPago", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaCondicionPago;
				cmd.Parameters.Add("@ObservacionCondicionPago", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionCondicionPago;
				cmd.Parameters.Add("@ObservacionLotesRevisor", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionLotesRevisor;
				cmd.Parameters.Add("@ValidaLotesRevisor", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaLotesRevisor;
				cmd.Parameters.Add("@ObservacionConEntregaRevisor", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionConEntregaRevisor;
				cmd.Parameters.Add("@ValidaCondicionEntregaRevisor", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaCondicionEntregaRevisor;
				cmd.Parameters.Add("@ObservacionCondPagoRevisor", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionCondPagoRevisor;
				cmd.Parameters.Add("@ValidaCondicionPagoRevisor", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaCondicionPagoRevisor;
				cmd.Parameters.Add("@ObservacionDoctosRevisor", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionDoctosRevisor;
				cmd.Parameters.Add("@ValidaDocumentosRevisor", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaDocumentosRevisor;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesFirmantes(SqlConnection Conexion, beAdjudicacionesFirmantes obeAdjudicacionesFirmantes)
	{
		string sp = "Proc_AdjudicacionesFirmantesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionFirmante", SqlDbType.Int).Value = obeAdjudicacionesFirmantes.IdAdjudicacionFirmante;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesFirmantes.IdAdjudicacion;
				cmd.Parameters.Add("@IdEstatusAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesFirmantes.IdEstatusAdjudicacion;
				cmd.Parameters.Add("@IdUsuarioSolicitante", SqlDbType.Int).Value = obeAdjudicacionesFirmantes.IdUsuarioSolicitante;
				cmd.Parameters.Add("@IdUsuarioAutoriza", SqlDbType.Int).Value = obeAdjudicacionesFirmantes.IdUsuarioAutoriza;
				cmd.Parameters.Add("@ValidaLotes", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaLotes;
				cmd.Parameters.Add("@ObservacionLotes", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionLotes;
				cmd.Parameters.Add("@ValidaCondicionEntrega", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaCondicionEntrega;
				cmd.Parameters.Add("@OnservacionCondicionEntrega", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.OnservacionCondicionEntrega;
				cmd.Parameters.Add("@ValidaCondicionPago", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaCondicionPago;
				cmd.Parameters.Add("@ObservacionCondicionPago", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionCondicionPago;
				cmd.Parameters.Add("@ObservacionLotesRevisor", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionLotesRevisor;
				cmd.Parameters.Add("@ValidaLotesRevisor", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaLotesRevisor;
				cmd.Parameters.Add("@ObservacionConEntregaRevisor", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionConEntregaRevisor;
				cmd.Parameters.Add("@ValidaCondicionEntregaRevisor", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaCondicionEntregaRevisor;
				cmd.Parameters.Add("@ObservacionCondPagoRevisor", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionCondPagoRevisor;
				cmd.Parameters.Add("@ValidaCondicionPagoRevisor", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaCondicionPagoRevisor;
				cmd.Parameters.Add("@ObservacionDoctosRevisor", SqlDbType.Text).Value = obeAdjudicacionesFirmantes.ObservacionDoctosRevisor;
				cmd.Parameters.Add("@ValidaDocumentosRevisor", SqlDbType.Bit).Value = obeAdjudicacionesFirmantes.ValidaDocumentosRevisor;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesFirmantes(SqlConnection Conexion,int pIdAdjudicacionFirmante)
	{
		string sp = "Proc_AdjudicacionesFirmantesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionFirmante", SqlDbType.Int).Value = pIdAdjudicacionFirmante;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesFirmantes traerAdjudicacionesFirmantes_x_IdAdjudicacionFirmante(SqlConnection Conexion,int IdAdjudicacionFirmante)
	{
		string sp = "Proc_AdjudicacionesFirmantes_x_IdAdjudicacionFirmante";
				beAdjudicacionesFirmantes obeAdjudicacionesFirmantes=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdjudicacionFirmante", SqlDbType.Int).Value = IdAdjudicacionFirmante;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdjudicacionFirmante = datard.GetOrdinal("IdAdjudicacionFirmante");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
						int posIdUsuarioSolicitante = datard.GetOrdinal("IdUsuarioSolicitante");
						int posIdUsuarioAutoriza = datard.GetOrdinal("IdUsuarioAutoriza");
						int posValidaLotes = datard.GetOrdinal("ValidaLotes");
						int posObservacionLotes = datard.GetOrdinal("ObservacionLotes");
						int posValidaCondicionEntrega = datard.GetOrdinal("ValidaCondicionEntrega");
						int posOnservacionCondicionEntrega = datard.GetOrdinal("OnservacionCondicionEntrega");
						int posValidaCondicionPago = datard.GetOrdinal("ValidaCondicionPago");
						int posObservacionCondicionPago = datard.GetOrdinal("ObservacionCondicionPago");
						int posObservacionLotesRevisor = datard.GetOrdinal("ObservacionLotesRevisor");
						int posValidaLotesRevisor = datard.GetOrdinal("ValidaLotesRevisor");
						int posObservacionConEntregaRevisor = datard.GetOrdinal("ObservacionConEntregaRevisor");
						int posValidaCondicionEntregaRevisor = datard.GetOrdinal("ValidaCondicionEntregaRevisor");
						int posObservacionCondPagoRevisor = datard.GetOrdinal("ObservacionCondPagoRevisor");
						int posValidaCondicionPagoRevisor = datard.GetOrdinal("ValidaCondicionPagoRevisor");
						int posObservacionDoctosRevisor = datard.GetOrdinal("ObservacionDoctosRevisor");
						int posValidaDocumentosRevisor = datard.GetOrdinal("ValidaDocumentosRevisor");
					 obeAdjudicacionesFirmantes = new beAdjudicacionesFirmantes();
				while (datard.Read())
					{
						obeAdjudicacionesFirmantes.IdAdjudicacionFirmante =  datard.GetInt32(posIdAdjudicacionFirmante);
						obeAdjudicacionesFirmantes.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
						obeAdjudicacionesFirmantes.IdEstatusAdjudicacion =  datard.GetInt32(posIdEstatusAdjudicacion);
						obeAdjudicacionesFirmantes.IdUsuarioSolicitante =  datard.GetInt32(posIdUsuarioSolicitante);
						obeAdjudicacionesFirmantes.IdUsuarioAutoriza =  datard.GetInt32(posIdUsuarioAutoriza);
						obeAdjudicacionesFirmantes.ValidaLotes =  datard.GetBoolean(posValidaLotes);
						obeAdjudicacionesFirmantes.ObservacionLotes =  datard.GetString(posObservacionLotes);
						obeAdjudicacionesFirmantes.ValidaCondicionEntrega =  datard.GetBoolean(posValidaCondicionEntrega);
						obeAdjudicacionesFirmantes.OnservacionCondicionEntrega =  datard.GetString(posOnservacionCondicionEntrega);
						obeAdjudicacionesFirmantes.ValidaCondicionPago =  datard.GetBoolean(posValidaCondicionPago);
						obeAdjudicacionesFirmantes.ObservacionCondicionPago =  datard.GetString(posObservacionCondicionPago);
						obeAdjudicacionesFirmantes.ObservacionLotesRevisor =  datard.GetString(posObservacionLotesRevisor);
						obeAdjudicacionesFirmantes.ValidaLotesRevisor =  datard.GetBoolean(posValidaLotesRevisor);
						obeAdjudicacionesFirmantes.ObservacionConEntregaRevisor =  datard.GetString(posObservacionConEntregaRevisor);
						obeAdjudicacionesFirmantes.ValidaCondicionEntregaRevisor =  datard.GetBoolean(posValidaCondicionEntregaRevisor);
						obeAdjudicacionesFirmantes.ObservacionCondPagoRevisor =  datard.GetString(posObservacionCondPagoRevisor);
						obeAdjudicacionesFirmantes.ValidaCondicionPagoRevisor =  datard.GetBoolean(posValidaCondicionPagoRevisor);
						obeAdjudicacionesFirmantes.ObservacionDoctosRevisor =  datard.GetString(posObservacionDoctosRevisor);
						obeAdjudicacionesFirmantes.ValidaDocumentosRevisor =  datard.GetBoolean(posValidaDocumentosRevisor);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesFirmantes;
			}
	}
	public List< beAdjudicacionesFirmantes> listarTodos_AdjudicacionesFirmantes(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesFirmantes_Traer_Todos";
		List<beAdjudicacionesFirmantes> lbeAdjudicacionesFirmantes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionFirmante = datard.GetOrdinal("IdAdjudicacionFirmante");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
						int posIdUsuarioSolicitante = datard.GetOrdinal("IdUsuarioSolicitante");
						int posIdUsuarioAutoriza = datard.GetOrdinal("IdUsuarioAutoriza");
						int posValidaLotes = datard.GetOrdinal("ValidaLotes");
						int posObservacionLotes = datard.GetOrdinal("ObservacionLotes");
						int posValidaCondicionEntrega = datard.GetOrdinal("ValidaCondicionEntrega");
						int posOnservacionCondicionEntrega = datard.GetOrdinal("OnservacionCondicionEntrega");
						int posValidaCondicionPago = datard.GetOrdinal("ValidaCondicionPago");
						int posObservacionCondicionPago = datard.GetOrdinal("ObservacionCondicionPago");
						int posObservacionLotesRevisor = datard.GetOrdinal("ObservacionLotesRevisor");
						int posValidaLotesRevisor = datard.GetOrdinal("ValidaLotesRevisor");
						int posObservacionConEntregaRevisor = datard.GetOrdinal("ObservacionConEntregaRevisor");
						int posValidaCondicionEntregaRevisor = datard.GetOrdinal("ValidaCondicionEntregaRevisor");
						int posObservacionCondPagoRevisor = datard.GetOrdinal("ObservacionCondPagoRevisor");
						int posValidaCondicionPagoRevisor = datard.GetOrdinal("ValidaCondicionPagoRevisor");
						int posObservacionDoctosRevisor = datard.GetOrdinal("ObservacionDoctosRevisor");
						int posValidaDocumentosRevisor = datard.GetOrdinal("ValidaDocumentosRevisor");
				lbeAdjudicacionesFirmantes = new List<beAdjudicacionesFirmantes>();
				beAdjudicacionesFirmantes obeAdjudicacionesFirmantes;
				while (datard.Read())
				{
					 obeAdjudicacionesFirmantes = new beAdjudicacionesFirmantes();
					obeAdjudicacionesFirmantes.IdAdjudicacionFirmante =  datard.GetInt32(posIdAdjudicacionFirmante);
					obeAdjudicacionesFirmantes.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesFirmantes.IdEstatusAdjudicacion =  datard.GetInt32(posIdEstatusAdjudicacion);
					obeAdjudicacionesFirmantes.IdUsuarioSolicitante =  datard.GetInt32(posIdUsuarioSolicitante);
					obeAdjudicacionesFirmantes.IdUsuarioAutoriza =  datard.GetInt32(posIdUsuarioAutoriza);
					obeAdjudicacionesFirmantes.ValidaLotes =  datard.GetBoolean(posValidaLotes);
					obeAdjudicacionesFirmantes.ObservacionLotes =  datard.GetString(posObservacionLotes);
					obeAdjudicacionesFirmantes.ValidaCondicionEntrega =  datard.GetBoolean(posValidaCondicionEntrega);
					obeAdjudicacionesFirmantes.OnservacionCondicionEntrega =  datard.GetString(posOnservacionCondicionEntrega);
					obeAdjudicacionesFirmantes.ValidaCondicionPago =  datard.GetBoolean(posValidaCondicionPago);
					obeAdjudicacionesFirmantes.ObservacionCondicionPago =  datard.GetString(posObservacionCondicionPago);
					obeAdjudicacionesFirmantes.ObservacionLotesRevisor =  datard.GetString(posObservacionLotesRevisor);
					obeAdjudicacionesFirmantes.ValidaLotesRevisor =  datard.GetBoolean(posValidaLotesRevisor);
					obeAdjudicacionesFirmantes.ObservacionConEntregaRevisor =  datard.GetString(posObservacionConEntregaRevisor);
					obeAdjudicacionesFirmantes.ValidaCondicionEntregaRevisor =  datard.GetBoolean(posValidaCondicionEntregaRevisor);
					obeAdjudicacionesFirmantes.ObservacionCondPagoRevisor =  datard.GetString(posObservacionCondPagoRevisor);
					obeAdjudicacionesFirmantes.ValidaCondicionPagoRevisor =  datard.GetBoolean(posValidaCondicionPagoRevisor);
					obeAdjudicacionesFirmantes.ObservacionDoctosRevisor =  datard.GetString(posObservacionDoctosRevisor);
					obeAdjudicacionesFirmantes.ValidaDocumentosRevisor =  datard.GetBoolean(posValidaDocumentosRevisor);
					lbeAdjudicacionesFirmantes.Add(obeAdjudicacionesFirmantes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesFirmantes;
		}
	}
	public List< beAdjudicacionesFirmantes> listar_AdjudicacionesFirmantes_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesFirmantes_TraerTodos_GetAll";
		List<beAdjudicacionesFirmantes> lbeAdjudicacionesFirmantes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionFirmante = datard.GetOrdinal("IdAdjudicacionFirmante");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
						int posIdUsuarioSolicitante = datard.GetOrdinal("IdUsuarioSolicitante");
						int posIdUsuarioAutoriza = datard.GetOrdinal("IdUsuarioAutoriza");
						int posValidaLotes = datard.GetOrdinal("ValidaLotes");
						int posObservacionLotes = datard.GetOrdinal("ObservacionLotes");
						int posValidaCondicionEntrega = datard.GetOrdinal("ValidaCondicionEntrega");
						int posOnservacionCondicionEntrega = datard.GetOrdinal("OnservacionCondicionEntrega");
						int posValidaCondicionPago = datard.GetOrdinal("ValidaCondicionPago");
						int posObservacionCondicionPago = datard.GetOrdinal("ObservacionCondicionPago");
						int posObservacionLotesRevisor = datard.GetOrdinal("ObservacionLotesRevisor");
						int posValidaLotesRevisor = datard.GetOrdinal("ValidaLotesRevisor");
						int posObservacionConEntregaRevisor = datard.GetOrdinal("ObservacionConEntregaRevisor");
						int posValidaCondicionEntregaRevisor = datard.GetOrdinal("ValidaCondicionEntregaRevisor");
						int posObservacionCondPagoRevisor = datard.GetOrdinal("ObservacionCondPagoRevisor");
						int posValidaCondicionPagoRevisor = datard.GetOrdinal("ValidaCondicionPagoRevisor");
						int posObservacionDoctosRevisor = datard.GetOrdinal("ObservacionDoctosRevisor");
						int posValidaDocumentosRevisor = datard.GetOrdinal("ValidaDocumentosRevisor");
				lbeAdjudicacionesFirmantes = new List<beAdjudicacionesFirmantes>();
				beAdjudicacionesFirmantes obeAdjudicacionesFirmantes;
				while (datard.Read())
				{
					 obeAdjudicacionesFirmantes = new beAdjudicacionesFirmantes();
					obeAdjudicacionesFirmantes.IdAdjudicacionFirmante =  datard.GetInt32(posIdAdjudicacionFirmante);
					obeAdjudicacionesFirmantes.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesFirmantes.IdEstatusAdjudicacion =  datard.GetInt32(posIdEstatusAdjudicacion);
					obeAdjudicacionesFirmantes.IdUsuarioSolicitante =  datard.GetInt32(posIdUsuarioSolicitante);
					obeAdjudicacionesFirmantes.IdUsuarioAutoriza =  datard.GetInt32(posIdUsuarioAutoriza);
					obeAdjudicacionesFirmantes.ValidaLotes =  datard.GetBoolean(posValidaLotes);
					obeAdjudicacionesFirmantes.ObservacionLotes =  datard.GetString(posObservacionLotes);
					obeAdjudicacionesFirmantes.ValidaCondicionEntrega =  datard.GetBoolean(posValidaCondicionEntrega);
					obeAdjudicacionesFirmantes.OnservacionCondicionEntrega =  datard.GetString(posOnservacionCondicionEntrega);
					obeAdjudicacionesFirmantes.ValidaCondicionPago =  datard.GetBoolean(posValidaCondicionPago);
					obeAdjudicacionesFirmantes.ObservacionCondicionPago =  datard.GetString(posObservacionCondicionPago);
					obeAdjudicacionesFirmantes.ObservacionLotesRevisor =  datard.GetString(posObservacionLotesRevisor);
					obeAdjudicacionesFirmantes.ValidaLotesRevisor =  datard.GetBoolean(posValidaLotesRevisor);
					obeAdjudicacionesFirmantes.ObservacionConEntregaRevisor =  datard.GetString(posObservacionConEntregaRevisor);
					obeAdjudicacionesFirmantes.ValidaCondicionEntregaRevisor =  datard.GetBoolean(posValidaCondicionEntregaRevisor);
					obeAdjudicacionesFirmantes.ObservacionCondPagoRevisor =  datard.GetString(posObservacionCondPagoRevisor);
					obeAdjudicacionesFirmantes.ValidaCondicionPagoRevisor =  datard.GetBoolean(posValidaCondicionPagoRevisor);
					obeAdjudicacionesFirmantes.ObservacionDoctosRevisor =  datard.GetString(posObservacionDoctosRevisor);
					obeAdjudicacionesFirmantes.ValidaDocumentosRevisor =  datard.GetBoolean(posValidaDocumentosRevisor);
			// debe agregar campos de la Vista
					lbeAdjudicacionesFirmantes.Add(obeAdjudicacionesFirmantes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesFirmantes;
		}
	}
}
}
