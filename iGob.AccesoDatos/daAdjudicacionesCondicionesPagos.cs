using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesCondicionesPagos
 {
	public int guardarAdjudicacionesCondicionesPagos(SqlConnection Conexion, beAdjudicacionesCondicionesPagos obeAdjudicacionesCondicionesPagos)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesCondicionesPagosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionCondicionPago", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdAdjudicacionCondicionPago;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdAdjudicacion;
				cmd.Parameters.Add("@Anticipo", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.Anticipo;
				cmd.Parameters.Add("@PorcentajeAnticipo", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesPagos.PorcentajeAnticipo;
				cmd.Parameters.Add("@ImporteAnticipo", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesPagos.ImporteAnticipo;
				cmd.Parameters.Add("@IdPeriodicidad", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdPeriodicidad;
				cmd.Parameters.Add("@FechaInicioPago", SqlDbType.DateTime).Value = obeAdjudicacionesCondicionesPagos.FechaInicioPago;
				cmd.Parameters.Add("@NumeroPagos", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.NumeroPagos;
				cmd.Parameters.Add("@ImporteTotalPagos", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesPagos.ImporteTotalPagos;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdEstatus;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeAdjudicacionesCondicionesPagos.Observaciones;
				cmd.Parameters.Add("@IdTipoCondicionPago", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdTipoCondicionPago;
				cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdTipoDia;
				cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdPlazoTiempo;
				cmd.Parameters.Add("@IdLugarFirma", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdLugarFirma;
				cmd.Parameters.Add("@PlazoPagoCantidad", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.PlazoPagoCantidad;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesCondicionesPagos.FechaRegistro;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdUsuarioRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesCondicionesPagos(SqlConnection Conexion, beAdjudicacionesCondicionesPagos obeAdjudicacionesCondicionesPagos)
	{
		string sp = "Proc_AdjudicacionesCondicionesPagosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionCondicionPago", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdAdjudicacionCondicionPago;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdAdjudicacion;
				cmd.Parameters.Add("@Anticipo", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.Anticipo;
				cmd.Parameters.Add("@PorcentajeAnticipo", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesPagos.PorcentajeAnticipo;
				cmd.Parameters.Add("@ImporteAnticipo", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesPagos.ImporteAnticipo;
				cmd.Parameters.Add("@IdPeriodicidad", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdPeriodicidad;
				cmd.Parameters.Add("@FechaInicioPago", SqlDbType.DateTime).Value = obeAdjudicacionesCondicionesPagos.FechaInicioPago;
				cmd.Parameters.Add("@NumeroPagos", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.NumeroPagos;
				cmd.Parameters.Add("@ImporteTotalPagos", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesPagos.ImporteTotalPagos;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdEstatus;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeAdjudicacionesCondicionesPagos.Observaciones;
				cmd.Parameters.Add("@IdTipoCondicionPago", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdTipoCondicionPago;
				cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdTipoDia;
				cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdPlazoTiempo;
				cmd.Parameters.Add("@IdLugarFirma", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdLugarFirma;
				cmd.Parameters.Add("@PlazoPagoCantidad", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.PlazoPagoCantidad;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesCondicionesPagos.FechaRegistro;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagos.IdUsuarioRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesCondicionesPagos(SqlConnection Conexion,int pIdAdjudicacionCondicionPago)
	{
		string sp = "Proc_AdjudicacionesCondicionesPagosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionCondicionPago", SqlDbType.Int).Value = pIdAdjudicacionCondicionPago;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesCondicionesPagos traerAdjudicacionesCondicionesPagos_x_IdAdjudicacionCondicionPago(SqlConnection Conexion,int IdAdjudicacionCondicionPago)
	{
		string sp = "Proc_AdjudicacionesCondicionesPagos_x_IdAdjudicacionCondicionPago";
				beAdjudicacionesCondicionesPagos obeAdjudicacionesCondicionesPagos=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdjudicacionCondicionPago", SqlDbType.Int).Value = IdAdjudicacionCondicionPago;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdjudicacionCondicionPago = datard.GetOrdinal("IdAdjudicacionCondicionPago");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posAnticipo = datard.GetOrdinal("Anticipo");
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
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
					 obeAdjudicacionesCondicionesPagos = new beAdjudicacionesCondicionesPagos();
				while (datard.Read())
					{
						obeAdjudicacionesCondicionesPagos.IdAdjudicacionCondicionPago =  datard.GetInt32(posIdAdjudicacionCondicionPago);
						obeAdjudicacionesCondicionesPagos.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
						obeAdjudicacionesCondicionesPagos.Anticipo =  datard.GetInt32(posAnticipo);
						obeAdjudicacionesCondicionesPagos.PorcentajeAnticipo =  datard.GetDecimal(posPorcentajeAnticipo);
						obeAdjudicacionesCondicionesPagos.ImporteAnticipo =  datard.GetDecimal(posImporteAnticipo);
						obeAdjudicacionesCondicionesPagos.IdPeriodicidad =  datard.GetInt32(posIdPeriodicidad);
						obeAdjudicacionesCondicionesPagos.FechaInicioPago =  datard.GetDateTime(posFechaInicioPago);
						obeAdjudicacionesCondicionesPagos.NumeroPagos =  datard.GetInt32(posNumeroPagos);
						obeAdjudicacionesCondicionesPagos.ImporteTotalPagos =  datard.GetDecimal(posImporteTotalPagos);
						obeAdjudicacionesCondicionesPagos.IdEstatus =  datard.GetInt32(posIdEstatus);
						obeAdjudicacionesCondicionesPagos.Observaciones =  datard.GetString(posObservaciones);
						obeAdjudicacionesCondicionesPagos.IdTipoCondicionPago =  datard.GetInt32(posIdTipoCondicionPago);
						obeAdjudicacionesCondicionesPagos.IdTipoDia =  datard.GetInt32(posIdTipoDia);
						obeAdjudicacionesCondicionesPagos.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
						obeAdjudicacionesCondicionesPagos.IdLugarFirma =  datard.GetInt32(posIdLugarFirma);
						obeAdjudicacionesCondicionesPagos.PlazoPagoCantidad =  datard.GetInt32(posPlazoPagoCantidad);
						obeAdjudicacionesCondicionesPagos.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
						obeAdjudicacionesCondicionesPagos.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesCondicionesPagos;
			}
	}
	public List< beAdjudicacionesCondicionesPagos> listarTodos_AdjudicacionesCondicionesPagos(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesCondicionesPagos_Traer_Todos";
		List<beAdjudicacionesCondicionesPagos> lbeAdjudicacionesCondicionesPagos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionCondicionPago = datard.GetOrdinal("IdAdjudicacionCondicionPago");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posAnticipo = datard.GetOrdinal("Anticipo");
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
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
				lbeAdjudicacionesCondicionesPagos = new List<beAdjudicacionesCondicionesPagos>();
				beAdjudicacionesCondicionesPagos obeAdjudicacionesCondicionesPagos;
				while (datard.Read())
				{
					 obeAdjudicacionesCondicionesPagos = new beAdjudicacionesCondicionesPagos();
					obeAdjudicacionesCondicionesPagos.IdAdjudicacionCondicionPago =  datard.GetInt32(posIdAdjudicacionCondicionPago);
					obeAdjudicacionesCondicionesPagos.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesCondicionesPagos.Anticipo =  datard.GetInt32(posAnticipo);
					obeAdjudicacionesCondicionesPagos.PorcentajeAnticipo =  datard.GetDecimal(posPorcentajeAnticipo);
					obeAdjudicacionesCondicionesPagos.ImporteAnticipo =  datard.GetDecimal(posImporteAnticipo);
					obeAdjudicacionesCondicionesPagos.IdPeriodicidad =  datard.GetInt32(posIdPeriodicidad);
					obeAdjudicacionesCondicionesPagos.FechaInicioPago =  datard.GetDateTime(posFechaInicioPago);
					obeAdjudicacionesCondicionesPagos.NumeroPagos =  datard.GetInt32(posNumeroPagos);
					obeAdjudicacionesCondicionesPagos.ImporteTotalPagos =  datard.GetDecimal(posImporteTotalPagos);
					obeAdjudicacionesCondicionesPagos.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeAdjudicacionesCondicionesPagos.Observaciones =  datard.GetString(posObservaciones);
					obeAdjudicacionesCondicionesPagos.IdTipoCondicionPago =  datard.GetInt32(posIdTipoCondicionPago);
					obeAdjudicacionesCondicionesPagos.IdTipoDia =  datard.GetInt32(posIdTipoDia);
					obeAdjudicacionesCondicionesPagos.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
					obeAdjudicacionesCondicionesPagos.IdLugarFirma =  datard.GetInt32(posIdLugarFirma);
					obeAdjudicacionesCondicionesPagos.PlazoPagoCantidad =  datard.GetInt32(posPlazoPagoCantidad);
					obeAdjudicacionesCondicionesPagos.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeAdjudicacionesCondicionesPagos.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					lbeAdjudicacionesCondicionesPagos.Add(obeAdjudicacionesCondicionesPagos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesPagos;
		}
	}
	public List< beAdjudicacionesCondicionesPagos> listar_AdjudicacionesCondicionesPagos_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesCondicionesPagos_TraerTodos_GetAll";
		List<beAdjudicacionesCondicionesPagos> lbeAdjudicacionesCondicionesPagos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionCondicionPago = datard.GetOrdinal("IdAdjudicacionCondicionPago");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posAnticipo = datard.GetOrdinal("Anticipo");
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
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
				lbeAdjudicacionesCondicionesPagos = new List<beAdjudicacionesCondicionesPagos>();
				beAdjudicacionesCondicionesPagos obeAdjudicacionesCondicionesPagos;
				while (datard.Read())
				{
					 obeAdjudicacionesCondicionesPagos = new beAdjudicacionesCondicionesPagos();
					obeAdjudicacionesCondicionesPagos.IdAdjudicacionCondicionPago =  datard.GetInt32(posIdAdjudicacionCondicionPago);
					obeAdjudicacionesCondicionesPagos.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesCondicionesPagos.Anticipo =  datard.GetInt32(posAnticipo);
					obeAdjudicacionesCondicionesPagos.PorcentajeAnticipo =  datard.GetDecimal(posPorcentajeAnticipo);
					obeAdjudicacionesCondicionesPagos.ImporteAnticipo =  datard.GetDecimal(posImporteAnticipo);
					obeAdjudicacionesCondicionesPagos.IdPeriodicidad =  datard.GetInt32(posIdPeriodicidad);
					obeAdjudicacionesCondicionesPagos.FechaInicioPago =  datard.GetDateTime(posFechaInicioPago);
					obeAdjudicacionesCondicionesPagos.NumeroPagos =  datard.GetInt32(posNumeroPagos);
					obeAdjudicacionesCondicionesPagos.ImporteTotalPagos =  datard.GetDecimal(posImporteTotalPagos);
					obeAdjudicacionesCondicionesPagos.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeAdjudicacionesCondicionesPagos.Observaciones =  datard.GetString(posObservaciones);
					obeAdjudicacionesCondicionesPagos.IdTipoCondicionPago =  datard.GetInt32(posIdTipoCondicionPago);
					obeAdjudicacionesCondicionesPagos.IdTipoDia =  datard.GetInt32(posIdTipoDia);
					obeAdjudicacionesCondicionesPagos.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
					obeAdjudicacionesCondicionesPagos.IdLugarFirma =  datard.GetInt32(posIdLugarFirma);
					obeAdjudicacionesCondicionesPagos.PlazoPagoCantidad =  datard.GetInt32(posPlazoPagoCantidad);
					obeAdjudicacionesCondicionesPagos.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeAdjudicacionesCondicionesPagos.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
			// debe agregar campos de la Vista
					lbeAdjudicacionesCondicionesPagos.Add(obeAdjudicacionesCondicionesPagos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesPagos;
		}
	}
}
}
