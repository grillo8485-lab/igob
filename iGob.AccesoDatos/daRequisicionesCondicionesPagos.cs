using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daRequisicionesCondicionesPagos
 {
	public int guardarRequisicionesCondicionesPagos(SqlConnection Conexion, beRequisicionesCondicionesPagos obeRequisicionesCondicionesPagos)
	{
		int Id=0;
		string sp = "Proc_RequisicionesCondicionesPagosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRequisicionCondicionPago", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdRequisicionCondicionPago;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdRequisicion;
				cmd.Parameters.Add("@Anticipo", SqlDbType.Bit).Value = obeRequisicionesCondicionesPagos.Anticipo;
				cmd.Parameters.Add("@IdAnticipo", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdAnticipo;
				cmd.Parameters.Add("@PorcentajeAnticipo", SqlDbType.Decimal).Value = obeRequisicionesCondicionesPagos.PorcentajeAnticipo;
				cmd.Parameters.Add("@ImporteAnticipo", SqlDbType.Decimal).Value = obeRequisicionesCondicionesPagos.ImporteAnticipo;
				cmd.Parameters.Add("@IdPeriodicidad", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdPeriodicidad;
				cmd.Parameters.Add("@FechaInicioPago", SqlDbType.DateTime).Value = obeRequisicionesCondicionesPagos.FechaInicioPago;
				cmd.Parameters.Add("@NumeroPagos", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.NumeroPagos;
				cmd.Parameters.Add("@ImporteTotalPagos", SqlDbType.Decimal).Value = obeRequisicionesCondicionesPagos.ImporteTotalPagos;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdEstatus;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeRequisicionesCondicionesPagos.Observaciones;
				cmd.Parameters.Add("@IdTipoCondicionPago", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdTipoCondicionPago;
				cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdTipoDia;
				cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdPlazoTiempo;
				cmd.Parameters.Add("@IdLugarFirma", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdLugarFirma;
				cmd.Parameters.Add("@PlazoPagoCantidad", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.PlazoPagoCantidad;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesCondicionesPagos.FechaRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarRequisicionesCondicionesPagos(SqlConnection Conexion, beRequisicionesCondicionesPagos obeRequisicionesCondicionesPagos)
	{
		string sp = "Proc_RequisicionesCondicionesPagosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRequisicionCondicionPago", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdRequisicionCondicionPago;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdRequisicion;
				cmd.Parameters.Add("@Anticipo", SqlDbType.Bit).Value = obeRequisicionesCondicionesPagos.Anticipo;
				cmd.Parameters.Add("@IdAnticipo", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdAnticipo;
				cmd.Parameters.Add("@PorcentajeAnticipo", SqlDbType.Decimal).Value = obeRequisicionesCondicionesPagos.PorcentajeAnticipo;
				cmd.Parameters.Add("@ImporteAnticipo", SqlDbType.Decimal).Value = obeRequisicionesCondicionesPagos.ImporteAnticipo;
				cmd.Parameters.Add("@IdPeriodicidad", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdPeriodicidad;
				cmd.Parameters.Add("@FechaInicioPago", SqlDbType.DateTime).Value = obeRequisicionesCondicionesPagos.FechaInicioPago;
				cmd.Parameters.Add("@NumeroPagos", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.NumeroPagos;
				cmd.Parameters.Add("@ImporteTotalPagos", SqlDbType.Decimal).Value = obeRequisicionesCondicionesPagos.ImporteTotalPagos;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdEstatus;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeRequisicionesCondicionesPagos.Observaciones;
				cmd.Parameters.Add("@IdTipoCondicionPago", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdTipoCondicionPago;
				cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdTipoDia;
				cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdPlazoTiempo;
				cmd.Parameters.Add("@IdLugarFirma", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdLugarFirma;
				cmd.Parameters.Add("@PlazoPagoCantidad", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.PlazoPagoCantidad;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesCondicionesPagos.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesCondicionesPagos.FechaRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarRequisicionesCondicionesPagos(SqlConnection Conexion,int pIdRequisicionCondicionPago)
	{
		string sp = "Proc_RequisicionesCondicionesPagosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRequisicionCondicionPago", SqlDbType.Int).Value = pIdRequisicionCondicionPago;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beRequisicionesCondicionesPagos traerRequisicionesCondicionesPagos_x_IdRequisicionCondicionPago(SqlConnection Conexion,int IdRequisicionCondicionPago)
	{
		string sp = "Proc_RequisicionesCondicionesPagos_x_IdRequisicionCondicionPago";
				beRequisicionesCondicionesPagos obeRequisicionesCondicionesPagos=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdRequisicionCondicionPago", SqlDbType.Int).Value = IdRequisicionCondicionPago;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdRequisicionCondicionPago = datard.GetOrdinal("IdRequisicionCondicionPago");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posAnticipo = datard.GetOrdinal("Anticipo");
						int posIdAnticipo = datard.GetOrdinal("IdAnticipo");
						int posPorcentajeAnticipo = datard.GetOrdinal("PorcentajeAnticipo");
						int posImporteAnticipo = datard.GetOrdinal("ImporteAnticipo");
						int posIdPeriodicidad = datard.GetOrdinal("IdPeriodicidad");
						int posFechaInicioPago = datard.GetOrdinal("FechaInicioPago");
						int posNumeroPagos = datard.GetOrdinal("NumeroPagos");
						int posImporteTotalPagos = datard.GetOrdinal("ImporteTotalPagos");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdTipoCondicionPago = datard.GetOrdinal("IdTipoCondicionPago");
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
						int posIdLugarFirma = datard.GetOrdinal("IdLugarFirma");
						int posPlazoPagoCantidad = datard.GetOrdinal("PlazoPagoCantidad");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
					 obeRequisicionesCondicionesPagos = new beRequisicionesCondicionesPagos();
				while (datard.Read())
					{
						obeRequisicionesCondicionesPagos.IdRequisicionCondicionPago =  datard.GetInt32(posIdRequisicionCondicionPago);
						obeRequisicionesCondicionesPagos.IdRequisicion =  datard.GetInt32(posIdRequisicion);
						obeRequisicionesCondicionesPagos.Anticipo =  datard.GetBoolean(posAnticipo);
						obeRequisicionesCondicionesPagos.IdAnticipo =  datard.GetInt32(posIdAnticipo);
						obeRequisicionesCondicionesPagos.PorcentajeAnticipo =  datard.GetDecimal(posPorcentajeAnticipo);
						obeRequisicionesCondicionesPagos.ImporteAnticipo =  datard.GetDecimal(posImporteAnticipo);
						obeRequisicionesCondicionesPagos.IdPeriodicidad =  datard.GetInt32(posIdPeriodicidad);
						obeRequisicionesCondicionesPagos.FechaInicioPago =  datard.GetDateTime(posFechaInicioPago);
						obeRequisicionesCondicionesPagos.NumeroPagos =  datard.GetInt32(posNumeroPagos);
						obeRequisicionesCondicionesPagos.ImporteTotalPagos =  datard.GetDecimal(posImporteTotalPagos);
						obeRequisicionesCondicionesPagos.IdEstatus =  datard.GetInt32(posIdEstatus);
						obeRequisicionesCondicionesPagos.Observaciones =  datard.GetString(posObservaciones);
						obeRequisicionesCondicionesPagos.IdTipoCondicionPago =  datard.GetInt32(posIdTipoCondicionPago);
						obeRequisicionesCondicionesPagos.IdTipoDia =  datard.GetInt32(posIdTipoDia);
						obeRequisicionesCondicionesPagos.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
						obeRequisicionesCondicionesPagos.IdLugarFirma =  datard.GetInt32(posIdLugarFirma);
						obeRequisicionesCondicionesPagos.PlazoPagoCantidad =  datard.GetInt32(posPlazoPagoCantidad);
						obeRequisicionesCondicionesPagos.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeRequisicionesCondicionesPagos.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesCondicionesPagos;
			}
	}
	public List< beRequisicionesCondicionesPagos> listarTodos_RequisicionesCondicionesPagos(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesCondicionesPagos_Traer_Todos";
		List<beRequisicionesCondicionesPagos> lbeRequisicionesCondicionesPagos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRequisicionCondicionPago = datard.GetOrdinal("IdRequisicionCondicionPago");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posAnticipo = datard.GetOrdinal("Anticipo");
						int posIdAnticipo = datard.GetOrdinal("IdAnticipo");
						int posPorcentajeAnticipo = datard.GetOrdinal("PorcentajeAnticipo");
						int posImporteAnticipo = datard.GetOrdinal("ImporteAnticipo");
						int posIdPeriodicidad = datard.GetOrdinal("IdPeriodicidad");
						int posFechaInicioPago = datard.GetOrdinal("FechaInicioPago");
						int posNumeroPagos = datard.GetOrdinal("NumeroPagos");
						int posImporteTotalPagos = datard.GetOrdinal("ImporteTotalPagos");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdTipoCondicionPago = datard.GetOrdinal("IdTipoCondicionPago");
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
						int posIdLugarFirma = datard.GetOrdinal("IdLugarFirma");
						int posPlazoPagoCantidad = datard.GetOrdinal("PlazoPagoCantidad");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeRequisicionesCondicionesPagos = new List<beRequisicionesCondicionesPagos>();
				beRequisicionesCondicionesPagos obeRequisicionesCondicionesPagos;
				while (datard.Read())
				{
					 obeRequisicionesCondicionesPagos = new beRequisicionesCondicionesPagos();
					obeRequisicionesCondicionesPagos.IdRequisicionCondicionPago =  datard.GetInt32(posIdRequisicionCondicionPago);
					obeRequisicionesCondicionesPagos.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeRequisicionesCondicionesPagos.Anticipo =  datard.GetBoolean(posAnticipo);
					obeRequisicionesCondicionesPagos.IdAnticipo =  datard.GetInt32(posIdAnticipo);
					obeRequisicionesCondicionesPagos.PorcentajeAnticipo =  datard.GetDecimal(posPorcentajeAnticipo);
					obeRequisicionesCondicionesPagos.ImporteAnticipo =  datard.GetDecimal(posImporteAnticipo);
					obeRequisicionesCondicionesPagos.IdPeriodicidad =  datard.GetInt32(posIdPeriodicidad);
					obeRequisicionesCondicionesPagos.FechaInicioPago =  datard.GetDateTime(posFechaInicioPago);
					obeRequisicionesCondicionesPagos.NumeroPagos =  datard.GetInt32(posNumeroPagos);
					obeRequisicionesCondicionesPagos.ImporteTotalPagos =  datard.GetDecimal(posImporteTotalPagos);
					obeRequisicionesCondicionesPagos.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeRequisicionesCondicionesPagos.Observaciones =  datard.GetString(posObservaciones);
					obeRequisicionesCondicionesPagos.IdTipoCondicionPago =  datard.GetInt32(posIdTipoCondicionPago);
					obeRequisicionesCondicionesPagos.IdTipoDia =  datard.GetInt32(posIdTipoDia);
					obeRequisicionesCondicionesPagos.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
					obeRequisicionesCondicionesPagos.IdLugarFirma =  datard.GetInt32(posIdLugarFirma);
					obeRequisicionesCondicionesPagos.PlazoPagoCantidad =  datard.GetInt32(posPlazoPagoCantidad);
					obeRequisicionesCondicionesPagos.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRequisicionesCondicionesPagos.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					lbeRequisicionesCondicionesPagos.Add(obeRequisicionesCondicionesPagos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesPagos;
		}
	}
	public List< beRequisicionesCondicionesPagos> listar_RequisicionesCondicionesPagos_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesCondicionesPagos_TraerTodos_GetAll";
		List<beRequisicionesCondicionesPagos> lbeRequisicionesCondicionesPagos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRequisicionCondicionPago = datard.GetOrdinal("IdRequisicionCondicionPago");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posAnticipo = datard.GetOrdinal("Anticipo");
						int posIdAnticipo = datard.GetOrdinal("IdAnticipo");
						int posPorcentajeAnticipo = datard.GetOrdinal("PorcentajeAnticipo");
						int posImporteAnticipo = datard.GetOrdinal("ImporteAnticipo");
						int posIdPeriodicidad = datard.GetOrdinal("IdPeriodicidad");
						int posFechaInicioPago = datard.GetOrdinal("FechaInicioPago");
						int posNumeroPagos = datard.GetOrdinal("NumeroPagos");
						int posImporteTotalPagos = datard.GetOrdinal("ImporteTotalPagos");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdTipoCondicionPago = datard.GetOrdinal("IdTipoCondicionPago");
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
						int posIdLugarFirma = datard.GetOrdinal("IdLugarFirma");
						int posPlazoPagoCantidad = datard.GetOrdinal("PlazoPagoCantidad");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeRequisicionesCondicionesPagos = new List<beRequisicionesCondicionesPagos>();
				beRequisicionesCondicionesPagos obeRequisicionesCondicionesPagos;
				while (datard.Read())
				{
					 obeRequisicionesCondicionesPagos = new beRequisicionesCondicionesPagos();
					obeRequisicionesCondicionesPagos.IdRequisicionCondicionPago =  datard.GetInt32(posIdRequisicionCondicionPago);
					obeRequisicionesCondicionesPagos.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeRequisicionesCondicionesPagos.Anticipo =  datard.GetBoolean(posAnticipo);
					obeRequisicionesCondicionesPagos.IdAnticipo =  datard.GetInt32(posIdAnticipo);
					obeRequisicionesCondicionesPagos.PorcentajeAnticipo =  datard.GetDecimal(posPorcentajeAnticipo);
					obeRequisicionesCondicionesPagos.ImporteAnticipo =  datard.GetDecimal(posImporteAnticipo);
					obeRequisicionesCondicionesPagos.IdPeriodicidad =  datard.GetInt32(posIdPeriodicidad);
					obeRequisicionesCondicionesPagos.FechaInicioPago =  datard.GetDateTime(posFechaInicioPago);
					obeRequisicionesCondicionesPagos.NumeroPagos =  datard.GetInt32(posNumeroPagos);
					obeRequisicionesCondicionesPagos.ImporteTotalPagos =  datard.GetDecimal(posImporteTotalPagos);
					obeRequisicionesCondicionesPagos.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeRequisicionesCondicionesPagos.Observaciones =  datard.GetString(posObservaciones);
					obeRequisicionesCondicionesPagos.IdTipoCondicionPago =  datard.GetInt32(posIdTipoCondicionPago);
					obeRequisicionesCondicionesPagos.IdTipoDia =  datard.GetInt32(posIdTipoDia);
					obeRequisicionesCondicionesPagos.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
					obeRequisicionesCondicionesPagos.IdLugarFirma =  datard.GetInt32(posIdLugarFirma);
					obeRequisicionesCondicionesPagos.PlazoPagoCantidad =  datard.GetInt32(posPlazoPagoCantidad);
					obeRequisicionesCondicionesPagos.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRequisicionesCondicionesPagos.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			// debe agregar campos de la Vista
					lbeRequisicionesCondicionesPagos.Add(obeRequisicionesCondicionesPagos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesPagos;
		}
	}
}
}
