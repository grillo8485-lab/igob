using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daRequisicionesFirmantes
 {
	public int guardarRequisicionesFirmantes(SqlConnection Conexion, beRequisicionesFirmantes obeRequisicionesFirmantes)
	{
		int Id=0;
		string sp = "Proc_RequisicionesFirmantesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRqFirmante", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdRqFirmante;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdRequisicion;
				cmd.Parameters.Add("@IdEstatusRequisicion", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdEstatusRequisicion;
				cmd.Parameters.Add("@IdUsuarioSolicitante", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdUsuarioSolicitante;
				cmd.Parameters.Add("@IdUsuarioAutoriza", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdUsuarioAutoriza;
				cmd.Parameters.Add("@ValidaLotes", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaLotes;
				cmd.Parameters.Add("@ObservacionLotes", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionLotes;
				cmd.Parameters.Add("@ValidaCondicionEntrega", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaCondicionEntrega;
				cmd.Parameters.Add("@OnservacionCondicionEntrega", SqlDbType.Text).Value = obeRequisicionesFirmantes.OnservacionCondicionEntrega;
				cmd.Parameters.Add("@ValidaCondicionPago", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaCondicionPago;
				cmd.Parameters.Add("@ObservacionCondicionPago", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionCondicionPago;
				cmd.Parameters.Add("@ObservacionLotesRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionLotesRevisor;
				cmd.Parameters.Add("@ValidaLotesRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaLotesRevisor;
				cmd.Parameters.Add("@ObservacionConEntregaRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionConEntregaRevisor;
				cmd.Parameters.Add("@ValidaCondicionEntregaRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaCondicionEntregaRevisor;
				cmd.Parameters.Add("@ObservacionCondPagoRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionCondPagoRevisor;
				cmd.Parameters.Add("@ValidaCondicionPagoRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaCondicionPagoRevisor;
				cmd.Parameters.Add("@ObservacionDoctosRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionDoctosRevisor;
				cmd.Parameters.Add("@ValidaDocumentosRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaDocumentosRevisor;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarRequisicionesFirmantes(SqlConnection Conexion, beRequisicionesFirmantes obeRequisicionesFirmantes)
	{
		string sp = "Proc_RequisicionesFirmantesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRqFirmante", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdRqFirmante;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdRequisicion;
				cmd.Parameters.Add("@IdEstatusRequisicion", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdEstatusRequisicion;
				cmd.Parameters.Add("@IdUsuarioSolicitante", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdUsuarioSolicitante;
				cmd.Parameters.Add("@IdUsuarioAutoriza", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdUsuarioAutoriza;
				cmd.Parameters.Add("@ValidaLotes", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaLotes;
				cmd.Parameters.Add("@ObservacionLotes", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionLotes;
				cmd.Parameters.Add("@ValidaCondicionEntrega", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaCondicionEntrega;
				cmd.Parameters.Add("@OnservacionCondicionEntrega", SqlDbType.Text).Value = obeRequisicionesFirmantes.OnservacionCondicionEntrega;
				cmd.Parameters.Add("@ValidaCondicionPago", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaCondicionPago;
				cmd.Parameters.Add("@ObservacionCondicionPago", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionCondicionPago;
				cmd.Parameters.Add("@ObservacionLotesRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionLotesRevisor;
				cmd.Parameters.Add("@ValidaLotesRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaLotesRevisor;
				cmd.Parameters.Add("@ObservacionConEntregaRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionConEntregaRevisor;
				cmd.Parameters.Add("@ValidaCondicionEntregaRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaCondicionEntregaRevisor;
				cmd.Parameters.Add("@ObservacionCondPagoRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionCondPagoRevisor;
				cmd.Parameters.Add("@ValidaCondicionPagoRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaCondicionPagoRevisor;
				cmd.Parameters.Add("@ObservacionDoctosRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionDoctosRevisor;
				cmd.Parameters.Add("@ValidaDocumentosRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaDocumentosRevisor;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarRequisicionesFirmantes(SqlConnection Conexion,int pIdRqFirmante)
	{
		string sp = "Proc_RequisicionesFirmantesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRqFirmante", SqlDbType.Int).Value = pIdRqFirmante;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beRequisicionesFirmantes traerRequisicionesFirmantes_x_IdRqFirmante(SqlConnection Conexion,int IdRqFirmante)
	{
		string sp = "Proc_RequisicionesFirmantes_x_IdRqFirmante";
				beRequisicionesFirmantes obeRequisicionesFirmantes=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdRqFirmante", SqlDbType.Int).Value = IdRqFirmante;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdRqFirmante = datard.GetOrdinal("IdRqFirmante");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdEstatusRequisicion = datard.GetOrdinal("IdEstatusRequisicion");
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
					 obeRequisicionesFirmantes = new beRequisicionesFirmantes();
				while (datard.Read())
					{
						obeRequisicionesFirmantes.IdRqFirmante =  datard.GetInt32(posIdRqFirmante);
						obeRequisicionesFirmantes.IdRequisicion =  datard.GetInt32(posIdRequisicion);
						obeRequisicionesFirmantes.IdEstatusRequisicion =  datard.GetInt32(posIdEstatusRequisicion);
						obeRequisicionesFirmantes.IdUsuarioSolicitante =  datard.GetInt32(posIdUsuarioSolicitante);
						obeRequisicionesFirmantes.IdUsuarioAutoriza =  datard.GetInt32(posIdUsuarioAutoriza);
						obeRequisicionesFirmantes.ValidaLotes =  datard.GetBoolean(posValidaLotes);
						obeRequisicionesFirmantes.ObservacionLotes =  datard.GetString(posObservacionLotes);
						obeRequisicionesFirmantes.ValidaCondicionEntrega =  datard.GetBoolean(posValidaCondicionEntrega);
						obeRequisicionesFirmantes.OnservacionCondicionEntrega =  datard.GetString(posOnservacionCondicionEntrega);
						obeRequisicionesFirmantes.ValidaCondicionPago =  datard.GetBoolean(posValidaCondicionPago);
						obeRequisicionesFirmantes.ObservacionCondicionPago =  datard.GetString(posObservacionCondicionPago);
						obeRequisicionesFirmantes.ObservacionLotesRevisor =  datard.GetString(posObservacionLotesRevisor);
						obeRequisicionesFirmantes.ValidaLotesRevisor =  datard.GetBoolean(posValidaLotesRevisor);
						obeRequisicionesFirmantes.ObservacionConEntregaRevisor =  datard.GetString(posObservacionConEntregaRevisor);
						obeRequisicionesFirmantes.ValidaCondicionEntregaRevisor =  datard.GetBoolean(posValidaCondicionEntregaRevisor);
						obeRequisicionesFirmantes.ObservacionCondPagoRevisor =  datard.GetString(posObservacionCondPagoRevisor);
						obeRequisicionesFirmantes.ValidaCondicionPagoRevisor =  datard.GetBoolean(posValidaCondicionPagoRevisor);
						obeRequisicionesFirmantes.ObservacionDoctosRevisor =  datard.GetString(posObservacionDoctosRevisor);
						obeRequisicionesFirmantes.ValidaDocumentosRevisor =  datard.GetBoolean(posValidaDocumentosRevisor);
                            obeRequisicionesFirmantes.isNUll = true;
                        }
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesFirmantes;
			}
	}
	public List< beRequisicionesFirmantes> listarTodos_RequisicionesFirmantes(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesFirmantes_Traer_Todos";
		List<beRequisicionesFirmantes> lbeRequisicionesFirmantes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRqFirmante = datard.GetOrdinal("IdRqFirmante");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdEstatusRequisicion = datard.GetOrdinal("IdEstatusRequisicion");
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
				lbeRequisicionesFirmantes = new List<beRequisicionesFirmantes>();
				beRequisicionesFirmantes obeRequisicionesFirmantes;
				while (datard.Read())
				{
					 obeRequisicionesFirmantes = new beRequisicionesFirmantes();
					obeRequisicionesFirmantes.IdRqFirmante =  datard.GetInt32(posIdRqFirmante);
					obeRequisicionesFirmantes.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeRequisicionesFirmantes.IdEstatusRequisicion =  datard.GetInt32(posIdEstatusRequisicion);
					obeRequisicionesFirmantes.IdUsuarioSolicitante =  datard.GetInt32(posIdUsuarioSolicitante);
					obeRequisicionesFirmantes.IdUsuarioAutoriza =  datard.GetInt32(posIdUsuarioAutoriza);
					obeRequisicionesFirmantes.ValidaLotes =  datard.GetBoolean(posValidaLotes);
					obeRequisicionesFirmantes.ObservacionLotes =  datard.GetString(posObservacionLotes);
					obeRequisicionesFirmantes.ValidaCondicionEntrega =  datard.GetBoolean(posValidaCondicionEntrega);
					obeRequisicionesFirmantes.OnservacionCondicionEntrega =  datard.GetString(posOnservacionCondicionEntrega);
					obeRequisicionesFirmantes.ValidaCondicionPago =  datard.GetBoolean(posValidaCondicionPago);
					obeRequisicionesFirmantes.ObservacionCondicionPago =  datard.GetString(posObservacionCondicionPago);
					obeRequisicionesFirmantes.ObservacionLotesRevisor =  datard.GetString(posObservacionLotesRevisor);
					obeRequisicionesFirmantes.ValidaLotesRevisor =  datard.GetBoolean(posValidaLotesRevisor);
					obeRequisicionesFirmantes.ObservacionConEntregaRevisor =  datard.GetString(posObservacionConEntregaRevisor);
					obeRequisicionesFirmantes.ValidaCondicionEntregaRevisor =  datard.GetBoolean(posValidaCondicionEntregaRevisor);
					obeRequisicionesFirmantes.ObservacionCondPagoRevisor =  datard.GetString(posObservacionCondPagoRevisor);
					obeRequisicionesFirmantes.ValidaCondicionPagoRevisor =  datard.GetBoolean(posValidaCondicionPagoRevisor);
					obeRequisicionesFirmantes.ObservacionDoctosRevisor =  datard.GetString(posObservacionDoctosRevisor);
					obeRequisicionesFirmantes.ValidaDocumentosRevisor =  datard.GetBoolean(posValidaDocumentosRevisor);
                            obeRequisicionesFirmantes.isNUll = true;

                    lbeRequisicionesFirmantes.Add(obeRequisicionesFirmantes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesFirmantes;
		}
	}
	public List< beRequisicionesFirmantes> listar_RequisicionesFirmantes_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesFirmantes_TraerTodos_GetAll";
		List<beRequisicionesFirmantes> lbeRequisicionesFirmantes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRqFirmante = datard.GetOrdinal("IdRqFirmante");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdEstatusRequisicion = datard.GetOrdinal("IdEstatusRequisicion");
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
				lbeRequisicionesFirmantes = new List<beRequisicionesFirmantes>();
				beRequisicionesFirmantes obeRequisicionesFirmantes;
				while (datard.Read())
				{
					 obeRequisicionesFirmantes = new beRequisicionesFirmantes();
					obeRequisicionesFirmantes.IdRqFirmante =  datard.GetInt32(posIdRqFirmante);
					obeRequisicionesFirmantes.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeRequisicionesFirmantes.IdEstatusRequisicion =  datard.GetInt32(posIdEstatusRequisicion);
					obeRequisicionesFirmantes.IdUsuarioSolicitante =  datard.GetInt32(posIdUsuarioSolicitante);
					obeRequisicionesFirmantes.IdUsuarioAutoriza =  datard.GetInt32(posIdUsuarioAutoriza);
					obeRequisicionesFirmantes.ValidaLotes =  datard.GetBoolean(posValidaLotes);
					obeRequisicionesFirmantes.ObservacionLotes =  datard.GetString(posObservacionLotes);
					obeRequisicionesFirmantes.ValidaCondicionEntrega =  datard.GetBoolean(posValidaCondicionEntrega);
					obeRequisicionesFirmantes.OnservacionCondicionEntrega =  datard.GetString(posOnservacionCondicionEntrega);
					obeRequisicionesFirmantes.ValidaCondicionPago =  datard.GetBoolean(posValidaCondicionPago);
					obeRequisicionesFirmantes.ObservacionCondicionPago =  datard.GetString(posObservacionCondicionPago);
					obeRequisicionesFirmantes.ObservacionLotesRevisor =  datard.GetString(posObservacionLotesRevisor);
					obeRequisicionesFirmantes.ValidaLotesRevisor =  datard.GetBoolean(posValidaLotesRevisor);
					obeRequisicionesFirmantes.ObservacionConEntregaRevisor =  datard.GetString(posObservacionConEntregaRevisor);
					obeRequisicionesFirmantes.ValidaCondicionEntregaRevisor =  datard.GetBoolean(posValidaCondicionEntregaRevisor);
					obeRequisicionesFirmantes.ObservacionCondPagoRevisor =  datard.GetString(posObservacionCondPagoRevisor);
					obeRequisicionesFirmantes.ValidaCondicionPagoRevisor =  datard.GetBoolean(posValidaCondicionPagoRevisor);
					obeRequisicionesFirmantes.ObservacionDoctosRevisor =  datard.GetString(posObservacionDoctosRevisor);
					obeRequisicionesFirmantes.ValidaDocumentosRevisor =  datard.GetBoolean(posValidaDocumentosRevisor);
                            obeRequisicionesFirmantes.isNUll = true;
                            // debe agregar campos de la Vista
                            lbeRequisicionesFirmantes.Add(obeRequisicionesFirmantes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesFirmantes;
		}
	}
	
	 public int actualizarRequisicionesFirmantes_Revisor(SqlConnection Conexion, beRequisicionesFirmantes obeRequisicionesFirmantes)
        {
            string sp = "Proc_RequisicionesFirmantesActualizar_Revisor";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRqFirmante", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdRqFirmante;
                    cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesFirmantes.IdRequisicion;
                    cmd.Parameters.Add("@ObservacionLotesRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionLotesRevisor;
                    cmd.Parameters.Add("@ValidaLotesRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaLotesRevisor;
                    cmd.Parameters.Add("@ObservacionConEntregaRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionConEntregaRevisor;
                    cmd.Parameters.Add("@ValidaCondicionEntregaRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaCondicionEntregaRevisor;
                    cmd.Parameters.Add("@ObservacionCondPagoRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionCondPagoRevisor;
                    cmd.Parameters.Add("@ValidaCondicionPagoRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaCondicionPagoRevisor;
                    cmd.Parameters.Add("@ObservacionDoctosRevisor", SqlDbType.Text).Value = obeRequisicionesFirmantes.ObservacionDoctosRevisor;
                    cmd.Parameters.Add("@ValidaDocumentosRevisor", SqlDbType.Bit).Value = obeRequisicionesFirmantes.ValidaDocumentosRevisor;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
	
	
	
	
}
}
