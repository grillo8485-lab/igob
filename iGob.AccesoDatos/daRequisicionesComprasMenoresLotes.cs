using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daRequisicionesComprasMenoresLotes
 {
	public int guardarRequisicionesComprasMenoresLotes(SqlConnection Conexion, beRequisicionesComprasMenoresLotes obeRequisicionesComprasMenoresLotes)
	{
		int Id=0;
		string sp = "Proc_RequisicionesComprasMenoresLotesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLoteCompraMenor", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.IdLoteCompraMenor;
				cmd.Parameters.Add("@IdRequisicionCompraMenor", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.IdRequisicionCompraMenor;
				cmd.Parameters.Add("@NoLote", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.NoLote;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.IdBienServicio;
				cmd.Parameters.Add("@Concepto", SqlDbType.VarChar).Value = obeRequisicionesComprasMenoresLotes.Concepto;
				cmd.Parameters.Add("@IdTipoBienServicio", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.IdTipoBienServicio;
				cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.Cantidad;
				cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.PrecioUnitario;
				cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.Importe;
				cmd.Parameters.Add("@PorcentajeImpuesto", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.PorcentajeImpuesto;
				cmd.Parameters.Add("@ImporteImpuesto", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.ImporteImpuesto;
				cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.Total;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesComprasMenoresLotes.FechaRegistro;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.IdUsuarioRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarRequisicionesComprasMenoresLotes(SqlConnection Conexion, beRequisicionesComprasMenoresLotes obeRequisicionesComprasMenoresLotes)
	{
		string sp = "Proc_RequisicionesComprasMenoresLotesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLoteCompraMenor", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.IdLoteCompraMenor;
				cmd.Parameters.Add("@IdRequisicionCompraMenor", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.IdRequisicionCompraMenor;
				cmd.Parameters.Add("@NoLote", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.NoLote;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.IdBienServicio;
				cmd.Parameters.Add("@Concepto", SqlDbType.VarChar).Value = obeRequisicionesComprasMenoresLotes.Concepto;
				cmd.Parameters.Add("@IdTipoBienServicio", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.IdTipoBienServicio;
				cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.Cantidad;
				cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.PrecioUnitario;
				cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.Importe;
				cmd.Parameters.Add("@PorcentajeImpuesto", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.PorcentajeImpuesto;
				cmd.Parameters.Add("@ImporteImpuesto", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.ImporteImpuesto;
				cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeRequisicionesComprasMenoresLotes.Total;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesComprasMenoresLotes.FechaRegistro;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesComprasMenoresLotes.IdUsuarioRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarRequisicionesComprasMenoresLotes(SqlConnection Conexion,int pIdLoteCompraMenor)
	{
		string sp = "Proc_RequisicionesComprasMenoresLotesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLoteCompraMenor", SqlDbType.Int).Value = pIdLoteCompraMenor;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beRequisicionesComprasMenoresLotes traerRequisicionesComprasMenoresLotes_x_IdLoteCompraMenor(SqlConnection Conexion,int IdLoteCompraMenor)
	{
		string sp = "Proc_RequisicionesComprasMenoresLotes_x_IdLoteCompraMenor";
				beRequisicionesComprasMenoresLotes obeRequisicionesComprasMenoresLotes=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdLoteCompraMenor", SqlDbType.Int).Value = IdLoteCompraMenor;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdLoteCompraMenor = datard.GetOrdinal("IdLoteCompraMenor");
						int posIdRequisicionCompraMenor = datard.GetOrdinal("IdRequisicionCompraMenor");
						int posNoLote = datard.GetOrdinal("NoLote");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posConcepto = datard.GetOrdinal("Concepto");
						int posIdTipoBienServicio = datard.GetOrdinal("IdTipoBienServicio");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
						int posImporte = datard.GetOrdinal("Importe");
						int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
						int posImporteImpuesto = datard.GetOrdinal("ImporteImpuesto");
						int posTotal = datard.GetOrdinal("Total");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
					 obeRequisicionesComprasMenoresLotes = new beRequisicionesComprasMenoresLotes();
				while (datard.Read())
					{
						obeRequisicionesComprasMenoresLotes.IdLoteCompraMenor =  datard.GetInt32(posIdLoteCompraMenor);
						obeRequisicionesComprasMenoresLotes.IdRequisicionCompraMenor =  datard.GetInt32(posIdRequisicionCompraMenor);
						obeRequisicionesComprasMenoresLotes.NoLote =  datard.GetInt32(posNoLote);
						obeRequisicionesComprasMenoresLotes.IdBienServicio =  datard.GetInt32(posIdBienServicio);
						obeRequisicionesComprasMenoresLotes.Concepto =  datard.GetString(posConcepto);
						obeRequisicionesComprasMenoresLotes.IdTipoBienServicio =  datard.GetInt32(posIdTipoBienServicio);
						obeRequisicionesComprasMenoresLotes.Cantidad =  datard.GetDecimal(posCantidad);
						obeRequisicionesComprasMenoresLotes.PrecioUnitario =  datard.GetDecimal(posPrecioUnitario);
						obeRequisicionesComprasMenoresLotes.Importe =  datard.GetDecimal(posImporte);
						obeRequisicionesComprasMenoresLotes.PorcentajeImpuesto =  datard.GetDecimal(posPorcentajeImpuesto);
						obeRequisicionesComprasMenoresLotes.ImporteImpuesto =  datard.GetDecimal(posImporteImpuesto);
						obeRequisicionesComprasMenoresLotes.Total =  datard.GetDecimal(posTotal);
						obeRequisicionesComprasMenoresLotes.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
						obeRequisicionesComprasMenoresLotes.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesComprasMenoresLotes;
			}
	}
	public List< beRequisicionesComprasMenoresLotes> listarTodos_RequisicionesComprasMenoresLotes(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesComprasMenoresLotes_Traer_Todos";
		List<beRequisicionesComprasMenoresLotes> lbeRequisicionesComprasMenoresLotes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdLoteCompraMenor = datard.GetOrdinal("IdLoteCompraMenor");
						int posIdRequisicionCompraMenor = datard.GetOrdinal("IdRequisicionCompraMenor");
						int posNoLote = datard.GetOrdinal("NoLote");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posConcepto = datard.GetOrdinal("Concepto");
						int posIdTipoBienServicio = datard.GetOrdinal("IdTipoBienServicio");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
						int posImporte = datard.GetOrdinal("Importe");
						int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
						int posImporteImpuesto = datard.GetOrdinal("ImporteImpuesto");
						int posTotal = datard.GetOrdinal("Total");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
				lbeRequisicionesComprasMenoresLotes = new List<beRequisicionesComprasMenoresLotes>();
				beRequisicionesComprasMenoresLotes obeRequisicionesComprasMenoresLotes;
				while (datard.Read())
				{
					 obeRequisicionesComprasMenoresLotes = new beRequisicionesComprasMenoresLotes();
					obeRequisicionesComprasMenoresLotes.IdLoteCompraMenor =  datard.GetInt32(posIdLoteCompraMenor);
					obeRequisicionesComprasMenoresLotes.IdRequisicionCompraMenor =  datard.GetInt32(posIdRequisicionCompraMenor);
					obeRequisicionesComprasMenoresLotes.NoLote =  datard.GetInt32(posNoLote);
					obeRequisicionesComprasMenoresLotes.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obeRequisicionesComprasMenoresLotes.Concepto =  datard.GetString(posConcepto);
					obeRequisicionesComprasMenoresLotes.IdTipoBienServicio =  datard.GetInt32(posIdTipoBienServicio);
					obeRequisicionesComprasMenoresLotes.Cantidad =  datard.GetDecimal(posCantidad);
					obeRequisicionesComprasMenoresLotes.PrecioUnitario =  datard.GetDecimal(posPrecioUnitario);
					obeRequisicionesComprasMenoresLotes.Importe =  datard.GetDecimal(posImporte);
					obeRequisicionesComprasMenoresLotes.PorcentajeImpuesto =  datard.GetDecimal(posPorcentajeImpuesto);
					obeRequisicionesComprasMenoresLotes.ImporteImpuesto =  datard.GetDecimal(posImporteImpuesto);
					obeRequisicionesComprasMenoresLotes.Total =  datard.GetDecimal(posTotal);
					obeRequisicionesComprasMenoresLotes.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeRequisicionesComprasMenoresLotes.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					lbeRequisicionesComprasMenoresLotes.Add(obeRequisicionesComprasMenoresLotes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesComprasMenoresLotes;
		}
	}
	public List< beRequisicionesComprasMenoresLotes> listar_RequisicionesComprasMenoresLotes_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesComprasMenoresLotes_TraerTodos_GetAll";
		List<beRequisicionesComprasMenoresLotes> lbeRequisicionesComprasMenoresLotes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdLoteCompraMenor = datard.GetOrdinal("IdLoteCompraMenor");
						int posIdRequisicionCompraMenor = datard.GetOrdinal("IdRequisicionCompraMenor");
						int posNoLote = datard.GetOrdinal("NoLote");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posConcepto = datard.GetOrdinal("Concepto");
						int posIdTipoBienServicio = datard.GetOrdinal("IdTipoBienServicio");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
						int posImporte = datard.GetOrdinal("Importe");
						int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
						int posImporteImpuesto = datard.GetOrdinal("ImporteImpuesto");
						int posTotal = datard.GetOrdinal("Total");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");

                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
				lbeRequisicionesComprasMenoresLotes = new List<beRequisicionesComprasMenoresLotes>();
				beRequisicionesComprasMenoresLotes obeRequisicionesComprasMenoresLotes;
				while (datard.Read())
				{
					 obeRequisicionesComprasMenoresLotes = new beRequisicionesComprasMenoresLotes();
					obeRequisicionesComprasMenoresLotes.IdLoteCompraMenor =  datard.GetInt32(posIdLoteCompraMenor);
					obeRequisicionesComprasMenoresLotes.IdRequisicionCompraMenor =  datard.GetInt32(posIdRequisicionCompraMenor);
					obeRequisicionesComprasMenoresLotes.NoLote =  datard.GetInt32(posNoLote);
					obeRequisicionesComprasMenoresLotes.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obeRequisicionesComprasMenoresLotes.Concepto =  datard.GetString(posConcepto);
					obeRequisicionesComprasMenoresLotes.IdTipoBienServicio =  datard.GetInt32(posIdTipoBienServicio);
					obeRequisicionesComprasMenoresLotes.Cantidad =  datard.GetDecimal(posCantidad);
					obeRequisicionesComprasMenoresLotes.PrecioUnitario =  datard.GetDecimal(posPrecioUnitario);
					obeRequisicionesComprasMenoresLotes.Importe =  datard.GetDecimal(posImporte);
					obeRequisicionesComprasMenoresLotes.PorcentajeImpuesto =  datard.GetDecimal(posPorcentajeImpuesto);
					obeRequisicionesComprasMenoresLotes.ImporteImpuesto =  datard.GetDecimal(posImporteImpuesto);
					obeRequisicionesComprasMenoresLotes.Total =  datard.GetDecimal(posTotal);
					obeRequisicionesComprasMenoresLotes.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeRequisicionesComprasMenoresLotes.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
			// debe agregar campos de la Vista
                    obeRequisicionesComprasMenoresLotes.RequisicionFolio =  datard.GetString(posRequisicionFolio);
                    obeRequisicionesComprasMenoresLotes.IdEjercicioFiscal =  datard.GetInt32(posIdEjercicioFiscal);
                    obeRequisicionesComprasMenoresLotes.Ejercicio =  datard.GetString(posEjercicio);
                    obeRequisicionesComprasMenoresLotes.IdOrigenRecurso =  datard.GetInt32(posIdOrigenRecurso);
                    obeRequisicionesComprasMenoresLotes.OrigenRecurso =  datard.GetString(posOrigenRecurso);

					lbeRequisicionesComprasMenoresLotes.Add(obeRequisicionesComprasMenoresLotes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesComprasMenoresLotes;
		}
	}
    /* Get All All 29/08/2018 */
    public List<beRequisicionesComprasMenoresLotes> listarTodos_RequisicionesComprasMenoresLotesGetAllAll(SqlConnection Conexion)
    {
        string sp = "Proc_RequisicionesComprasMenoresLotes_TraerTodos_GetAllAll";
        List<beRequisicionesComprasMenoresLotes> lbeRequisicionesComprasMenoresLotes = null;
        SqlCommand cmd = new SqlCommand(sp, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            try
            {
                if (datard != null)
                {
                    int posIdLoteCompraMenor = datard.GetOrdinal("IdLoteCompraMenor");
                    int posIdRequisicionCompraMenor = datard.GetOrdinal("IdRequisicionCompraMenor");
                    int posNoLote = datard.GetOrdinal("NoLote");
                    int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                    int posConcepto = datard.GetOrdinal("Concepto");
                    int posIdTipoBienServicio = datard.GetOrdinal("IdTipoBienServicio");
                    int posCantidad = datard.GetOrdinal("Cantidad");
                    int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                    int posImporte = datard.GetOrdinal("Importe");
                    int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                    int posImporteImpuesto = datard.GetOrdinal("ImporteImpuesto");
                    int posTotal = datard.GetOrdinal("Total");
                    int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                    int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");

					int posIdDependencia = datard.GetOrdinal("IdDependencia");
					int posDepartamento = datard.GetOrdinal("Departamento");
					int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
					int posIdEstatusRequisicion = datard.GetOrdinal("IdEstatusRequisicion");
					int posIdPartida = datard.GetOrdinal("IdPartida");
					int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
					int posIdClavePresupuestal = datard.GetOrdinal("IdClavePresupuestal");
					int posFechaRequisicion = datard.GetOrdinal("FechaRequisicion");
					int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
					int posConsecutivoRequisicion = datard.GetOrdinal("ConsecutivoRequisicion");
					int posMontoAproximado = datard.GetOrdinal("MontoAproximado");
					int posCantidadLotes = datard.GetOrdinal("CantidadLotes");
					int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
					int posObservaciones = datard.GetOrdinal("Observaciones");
					int posJustificacion = datard.GetOrdinal("Justificacion");
					int posFechaEntrega = datard.GetOrdinal("FechaEntrega");
					int posLugarEntrega = datard.GetOrdinal("LugarEntrega");
					int posFechaPago = datard.GetOrdinal("FechaPago");
					int posLugarPago = datard.GetOrdinal("LugarPago");
					
                    int posDependencia = datard.GetOrdinal("Dependencia");
                    int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                    int posPartida = datard.GetOrdinal("Partida");
                    int posEjercicio = datard.GetOrdinal("Ejercicio");
                    int posRazonSocial = datard.GetOrdinal("RazonSocial");
                    lbeRequisicionesComprasMenoresLotes = new List<beRequisicionesComprasMenoresLotes>();
                    beRequisicionesComprasMenoresLotes obeRequisicionesComprasMenoresLotes;
                    while (datard.Read())
                    {
                        obeRequisicionesComprasMenoresLotes = new beRequisicionesComprasMenoresLotes();
                        obeRequisicionesComprasMenoresLotes.IdLoteCompraMenor = datard.GetInt32(posIdLoteCompraMenor);
                        obeRequisicionesComprasMenoresLotes.IdRequisicionCompraMenor = datard.GetInt32(posIdRequisicionCompraMenor);
                        obeRequisicionesComprasMenoresLotes.NoLote = datard.GetInt32(posNoLote);
                        obeRequisicionesComprasMenoresLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                        obeRequisicionesComprasMenoresLotes.Concepto = datard.GetString(posConcepto);
                        obeRequisicionesComprasMenoresLotes.IdTipoBienServicio = datard.GetInt32(posIdTipoBienServicio);
                        obeRequisicionesComprasMenoresLotes.Cantidad = datard.GetDecimal(posCantidad);
                        obeRequisicionesComprasMenoresLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                        obeRequisicionesComprasMenoresLotes.Importe = datard.GetDecimal(posImporte);
                        obeRequisicionesComprasMenoresLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                        obeRequisicionesComprasMenoresLotes.ImporteImpuesto = datard.GetDecimal(posImporteImpuesto);
                        obeRequisicionesComprasMenoresLotes.Total = datard.GetDecimal(posTotal);
                        obeRequisicionesComprasMenoresLotes.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        obeRequisicionesComprasMenoresLotes.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                        
                        obeRequisicionesComprasMenoresLotes.IdDependencia =  datard.GetInt32(posIdDependencia);
                        obeRequisicionesComprasMenoresLotes.Departamento =  datard.GetString(posDepartamento);
                        obeRequisicionesComprasMenoresLotes.IdOrigenRecurso =  datard.GetInt32(posIdOrigenRecurso);
                        obeRequisicionesComprasMenoresLotes.IdEstatusRequisicion =  datard.GetInt32(posIdEstatusRequisicion);
                        obeRequisicionesComprasMenoresLotes.IdPartida =  datard.GetInt32(posIdPartida);
                        obeRequisicionesComprasMenoresLotes.IdEjercicioFiscal =  datard.GetInt32(posIdEjercicioFiscal);
                        obeRequisicionesComprasMenoresLotes.IdClavePresupuestal =  datard.GetInt32(posIdClavePresupuestal);
                        obeRequisicionesComprasMenoresLotes.FechaRequisicion =  datard.GetDateTime(posFechaRequisicion);
                        obeRequisicionesComprasMenoresLotes.RequisicionFolio =  datard.GetString(posRequisicionFolio);
                        obeRequisicionesComprasMenoresLotes.ConsecutivoRequisicion =  datard.GetInt32(posConsecutivoRequisicion);
                        obeRequisicionesComprasMenoresLotes.MontoAproximado =  datard.GetDecimal(posMontoAproximado);
                        obeRequisicionesComprasMenoresLotes.CantidadLotes =  datard.GetInt32(posCantidadLotes);
                        obeRequisicionesComprasMenoresLotes.ImporteTotalLotes =  datard.GetDecimal(posImporteTotalLotes);
                        obeRequisicionesComprasMenoresLotes.Observaciones =  datard.GetString(posObservaciones);
                        obeRequisicionesComprasMenoresLotes.Justificacion =  datard.GetString(posJustificacion);
                        obeRequisicionesComprasMenoresLotes.FechaEntrega =  datard.GetDateTime(posFechaEntrega);
                        obeRequisicionesComprasMenoresLotes.LugarEntrega =  datard.GetString(posLugarEntrega);
                        obeRequisicionesComprasMenoresLotes.FechaPago =  datard.GetDateTime(posFechaPago);
                        obeRequisicionesComprasMenoresLotes.LugarPago =  datard.GetString(posLugarPago);
                        
                        obeRequisicionesComprasMenoresLotes.Dependencia =  datard.GetString(posDependencia);
                        obeRequisicionesComprasMenoresLotes.OrigenRecurso =  datard.GetString(posOrigenRecurso);
                        obeRequisicionesComprasMenoresLotes.Partida =  datard.GetString(posPartida);
                        obeRequisicionesComprasMenoresLotes.Ejercicio =  datard.GetString(posEjercicio);
                        obeRequisicionesComprasMenoresLotes.RazonSocial =  datard.GetString(posRazonSocial);
                        
                        lbeRequisicionesComprasMenoresLotes.Add(obeRequisicionesComprasMenoresLotes);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeRequisicionesComprasMenoresLotes;
        }
    }

    public List<beRequisicionesComprasMenoresLotes> traerRequisicionesComprasMenoresLotes_x_IdRequisicionCompraMenor(SqlConnection Conexion, int IdRequisicionCompraMenor)
    {
        string sp = "Proc_RequisicionesComprasMenoresLotes_x_IdRequisicionCompraMenor";
        List<beRequisicionesComprasMenoresLotes> lbeRequisicionesComprasMenoresLotes = null;
        SqlCommand cmd = new SqlCommand(sp, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@IdRequisicionCompraMenor", SqlDbType.Int).Value = IdRequisicionCompraMenor;
        using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            try
            {
                if (datard != null)
                {
                    int posIdLoteCompraMenor = datard.GetOrdinal("IdLoteCompraMenor");
                    int posIdRequisicionCompraMenor = datard.GetOrdinal("IdRequisicionCompraMenor");
                    int posNoLote = datard.GetOrdinal("NoLote");
                    int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                    int posConcepto = datard.GetOrdinal("Concepto");
                    int posIdTipoBienServicio = datard.GetOrdinal("IdTipoBienServicio");
                    int posCantidad = datard.GetOrdinal("Cantidad");
                    int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                    int posImporte = datard.GetOrdinal("Importe");
                    int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                    int posImporteImpuesto = datard.GetOrdinal("ImporteImpuesto");
                    int posTotal = datard.GetOrdinal("Total");
                    int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                    int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                    lbeRequisicionesComprasMenoresLotes = new List<beRequisicionesComprasMenoresLotes>();
                    beRequisicionesComprasMenoresLotes obeRequisicionesComprasMenoresLotes;
                    while (datard.Read())
                    {
                        obeRequisicionesComprasMenoresLotes = new beRequisicionesComprasMenoresLotes();
                        obeRequisicionesComprasMenoresLotes.IdLoteCompraMenor = datard.GetInt32(posIdLoteCompraMenor);
                        obeRequisicionesComprasMenoresLotes.IdRequisicionCompraMenor = datard.GetInt32(posIdRequisicionCompraMenor);
                        obeRequisicionesComprasMenoresLotes.NoLote = datard.GetInt32(posNoLote);
                        obeRequisicionesComprasMenoresLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                        obeRequisicionesComprasMenoresLotes.Concepto = datard.GetString(posConcepto);
                        obeRequisicionesComprasMenoresLotes.IdTipoBienServicio = datard.GetInt32(posIdTipoBienServicio);
                        obeRequisicionesComprasMenoresLotes.Cantidad = datard.GetDecimal(posCantidad);
                        obeRequisicionesComprasMenoresLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                        obeRequisicionesComprasMenoresLotes.Importe = datard.GetDecimal(posImporte);
                        obeRequisicionesComprasMenoresLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                        obeRequisicionesComprasMenoresLotes.ImporteImpuesto = datard.GetDecimal(posImporteImpuesto);
                        obeRequisicionesComprasMenoresLotes.Total = datard.GetDecimal(posTotal);
                        obeRequisicionesComprasMenoresLotes.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        obeRequisicionesComprasMenoresLotes.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                        lbeRequisicionesComprasMenoresLotes.Add(obeRequisicionesComprasMenoresLotes);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeRequisicionesComprasMenoresLotes;
        }
    }
    }
}
