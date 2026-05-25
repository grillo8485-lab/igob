using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRequisicionesComprasMenores
    {
	    public int guardarRequisicionesComprasMenores(SqlConnection Conexion, beRequisicionesComprasMenores obeRequisicionesComprasMenores)
	    {
		    int Id=0;
		    string sp = "Proc_RequisicionesComprasMenoresInsertar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			    try
                {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdRequisicionCompraMenor", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdRequisicionCompraMenor;
				    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdDependencia;
				    cmd.Parameters.Add("@IdDepartamento", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdDepartamento;
				    cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdOrigenRecurso;
				    cmd.Parameters.Add("@IdEstatusCM", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdEstatusCM;
				    cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdPartida;
				    cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdEjercicioFiscal;
				    cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdTipoSolicitud;
				    cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdPresupuesto;
				    cmd.Parameters.Add("@FechaRequisicion", SqlDbType.DateTime).Value = obeRequisicionesComprasMenores.FechaRequisicion;
				    cmd.Parameters.Add("@RequisicionFolio", SqlDbType.NVarChar).Value = obeRequisicionesComprasMenores.RequisicionFolio;
				    cmd.Parameters.Add("@ConsecutivoRequisicion", SqlDbType.Int).Value = obeRequisicionesComprasMenores.ConsecutivoRequisicion;
				    cmd.Parameters.Add("@MontoAproximado", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.MontoAproximado;
				    cmd.Parameters.Add("@CantidadLotes", SqlDbType.Int).Value = obeRequisicionesComprasMenores.CantidadLotes;
				    cmd.Parameters.Add("@ImporteTotalLotes", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.ImporteTotalLotes;
				    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeRequisicionesComprasMenores.Observaciones;
				    cmd.Parameters.Add("@Justificacion", SqlDbType.VarChar).Value = obeRequisicionesComprasMenores.Justificacion;
				    cmd.Parameters.Add("@FechaEntrega", SqlDbType.DateTime).Value = obeRequisicionesComprasMenores.FechaEntrega;
				    cmd.Parameters.Add("@IdLugarEntrega", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdLugarEntrega;
				    cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = obeRequisicionesComprasMenores.FechaPago;
				    cmd.Parameters.Add("@IdLugarPago", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdLugarPago;
				    cmd.Parameters.Add("@SaldoPartida", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.SaldoPartida;
				    cmd.Parameters.Add("@MontoPresupuestado", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.MontoPresupuestado;
				    cmd.Parameters.Add("@IdUsuarioAutoriza", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdUsuarioAutoriza;
				    cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdProveedor;
				    cmd.Parameters.Add("@Economia", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.Economia;
				    cmd.Parameters.Add("@Ejercido", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.Ejercido;
				    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdUsuarioRegistro;
				    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesComprasMenores.FechaRegistro;
			
				    Id =(int)cmd.ExecuteScalar();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return Id;
		    }
	    }

	    public int actualizarRequisicionesComprasMenores(SqlConnection Conexion, beRequisicionesComprasMenores obeRequisicionesComprasMenores)
	    {
		    string sp = "Proc_RequisicionesComprasMenoresActualizar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try
                {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdRequisicionCompraMenor", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdRequisicionCompraMenor;
				    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdDependencia;
                    cmd.Parameters.Add("@IdDepartamento", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdDepartamento;
                    cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdOrigenRecurso;
				    cmd.Parameters.Add("@IdEstatusCM", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdEstatusCM;
				    cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdPartida;
				    cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdEjercicioFiscal;
				    cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdTipoSolicitud;
				    cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdPresupuesto;
				    cmd.Parameters.Add("@FechaRequisicion", SqlDbType.DateTime).Value = obeRequisicionesComprasMenores.FechaRequisicion;
				    cmd.Parameters.Add("@RequisicionFolio", SqlDbType.NVarChar).Value = obeRequisicionesComprasMenores.RequisicionFolio;
				    cmd.Parameters.Add("@ConsecutivoRequisicion", SqlDbType.Int).Value = obeRequisicionesComprasMenores.ConsecutivoRequisicion;
				    cmd.Parameters.Add("@MontoAproximado", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.MontoAproximado;
				    cmd.Parameters.Add("@CantidadLotes", SqlDbType.Int).Value = obeRequisicionesComprasMenores.CantidadLotes;
				    cmd.Parameters.Add("@ImporteTotalLotes", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.ImporteTotalLotes;
				    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeRequisicionesComprasMenores.Observaciones;
				    cmd.Parameters.Add("@Justificacion", SqlDbType.VarChar).Value = obeRequisicionesComprasMenores.Justificacion;
				    cmd.Parameters.Add("@FechaEntrega", SqlDbType.DateTime).Value = obeRequisicionesComprasMenores.FechaEntrega;
				    cmd.Parameters.Add("@IdLugarEntrega", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdLugarEntrega;
				    cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = obeRequisicionesComprasMenores.FechaPago;
				    cmd.Parameters.Add("@IdLugarPago", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdLugarPago;
				    cmd.Parameters.Add("@SaldoPartida", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.SaldoPartida;
				    cmd.Parameters.Add("@MontoPresupuestado", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.MontoPresupuestado;
				    cmd.Parameters.Add("@IdUsuarioAutoriza", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdUsuarioAutoriza;
				    cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdProveedor;
				    cmd.Parameters.Add("@Economia", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.Economia;
				    cmd.Parameters.Add("@Ejercido", SqlDbType.Decimal).Value = obeRequisicionesComprasMenores.Ejercido;
				    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesComprasMenores.IdUsuarioRegistro;
				    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesComprasMenores.FechaRegistro;
			
				    cmd.ExecuteNonQuery();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return 0;
			}
	    }

	    public int eliminarRequisicionesComprasMenores(SqlConnection Conexion,int pIdRequisicionCompraMenor)
	    {
		    string sp = "Proc_RequisicionesComprasMenoresEliminar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try
                {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdRequisicionCompraMenor", SqlDbType.Int).Value = pIdRequisicionCompraMenor;
				    cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
				    throw ex;
			    }
			    return 0;
		    }
	    }

	    public beRequisicionesComprasMenores traerRequisicionesComprasMenores_x_IdRequisicionCompraMenor(SqlConnection Conexion,int IdRequisicionCompraMenor)
	    {
		    string sp = "Proc_RequisicionesComprasMenores_x_IdRequisicionCompraMenor";
				    beRequisicionesComprasMenores obeRequisicionesComprasMenores=null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    cmd.Parameters.Add("@IdRequisicionCompraMenor", SqlDbType.Int).Value = IdRequisicionCompraMenor;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
			    try
                {
				    if (datard != null)
				    {
					    int posIdRequisicionCompraMenor = datard.GetOrdinal("IdRequisicionCompraMenor");
					    int posIdDependencia = datard.GetOrdinal("IdDependencia");
					    int posIdDepartamento = datard.GetOrdinal("IdDepartamento");
					    int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
					    int posIdEstatusCM = datard.GetOrdinal("IdEstatusCM");
					    int posIdPartida = datard.GetOrdinal("IdPartida");
					    int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
					    int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
					    int posIdPresupuesto = datard.GetOrdinal("IdPresupuesto");
					    int posFechaRequisicion = datard.GetOrdinal("FechaRequisicion");
					    int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
					    int posConsecutivoRequisicion = datard.GetOrdinal("ConsecutivoRequisicion");
					    int posMontoAproximado = datard.GetOrdinal("MontoAproximado");
					    int posCantidadLotes = datard.GetOrdinal("CantidadLotes");
					    int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
					    int posObservaciones = datard.GetOrdinal("Observaciones");
					    int posJustificacion = datard.GetOrdinal("Justificacion");
					    int posFechaEntrega = datard.GetOrdinal("FechaEntrega");
					    int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
					    int posFechaPago = datard.GetOrdinal("FechaPago");
					    int posIdLugarPago = datard.GetOrdinal("IdLugarPago");
					    int posSaldoPartida = datard.GetOrdinal("SaldoPartida");
					    int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
					    int posIdUsuarioAutoriza = datard.GetOrdinal("IdUsuarioAutoriza");
					    int posIdProveedor = datard.GetOrdinal("IdProveedor");
					    int posEconomia = datard.GetOrdinal("Economia");
					    int posEjercido = datard.GetOrdinal("Ejercido");
					    int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
					    int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
					    obeRequisicionesComprasMenores = new beRequisicionesComprasMenores();
				        while (datard.Read())
					    {
						    obeRequisicionesComprasMenores.IdRequisicionCompraMenor =  datard.GetInt32(posIdRequisicionCompraMenor);
						    obeRequisicionesComprasMenores.IdDependencia =  datard.GetInt32(posIdDependencia);
						    obeRequisicionesComprasMenores.IdDepartamento =  datard.GetInt32(posIdDepartamento);
						    obeRequisicionesComprasMenores.IdOrigenRecurso =  datard.GetInt32(posIdOrigenRecurso);
						    obeRequisicionesComprasMenores.IdEstatusCM =  datard.GetInt32(posIdEstatusCM);
						    obeRequisicionesComprasMenores.IdPartida =  datard.GetInt32(posIdPartida);
						    obeRequisicionesComprasMenores.IdEjercicioFiscal =  datard.GetInt32(posIdEjercicioFiscal);
						    obeRequisicionesComprasMenores.IdTipoSolicitud =  datard.GetInt32(posIdTipoSolicitud);
						    obeRequisicionesComprasMenores.IdPresupuesto =  datard.GetInt32(posIdPresupuesto);
						    obeRequisicionesComprasMenores.FechaRequisicion =  datard.GetDateTime(posFechaRequisicion);
						    obeRequisicionesComprasMenores.RequisicionFolio =  datard.GetString(posRequisicionFolio);
						    obeRequisicionesComprasMenores.ConsecutivoRequisicion =  datard.GetInt32(posConsecutivoRequisicion);
						    obeRequisicionesComprasMenores.MontoAproximado =  datard.GetDecimal(posMontoAproximado);
						    obeRequisicionesComprasMenores.CantidadLotes =  datard.GetInt32(posCantidadLotes);
						    obeRequisicionesComprasMenores.ImporteTotalLotes =  datard.GetDecimal(posImporteTotalLotes);
						    obeRequisicionesComprasMenores.Observaciones =  datard.GetString(posObservaciones);
						    obeRequisicionesComprasMenores.Justificacion =  datard.GetString(posJustificacion);
						    obeRequisicionesComprasMenores.FechaEntrega =  datard.GetDateTime(posFechaEntrega);
						    obeRequisicionesComprasMenores.IdLugarEntrega =  datard.GetInt32(posIdLugarEntrega);
						    obeRequisicionesComprasMenores.FechaPago =  datard.GetDateTime(posFechaPago);
						    obeRequisicionesComprasMenores.IdLugarPago =  datard.GetInt32(posIdLugarPago);
						    obeRequisicionesComprasMenores.SaldoPartida =  datard.GetDecimal(posSaldoPartida);
						    obeRequisicionesComprasMenores.MontoPresupuestado =  datard.GetDecimal(posMontoPresupuestado);
						    obeRequisicionesComprasMenores.IdUsuarioAutoriza =  datard.GetInt32(posIdUsuarioAutoriza);
						    obeRequisicionesComprasMenores.IdProveedor =  datard.GetInt32(posIdProveedor);
						    obeRequisicionesComprasMenores.Economia =  datard.GetDecimal(posEconomia);
						    obeRequisicionesComprasMenores.Ejercido =  datard.GetDecimal(posEjercido);
						    obeRequisicionesComprasMenores.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						    obeRequisicionesComprasMenores.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					    }
				    }
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obeRequisicionesComprasMenores;
		    }
	    }
        /*
	    public List< beRequisicionesComprasMenores> listarTodos_RequisicionesComprasMenores(SqlConnection Conexion)
	     {
		    string sp = "Proc_RequisicionesComprasMenores_Traer_Todos";
		    List<beRequisicionesComprasMenores> lbeRequisicionesComprasMenores = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdRequisicionCompraMenor = datard.GetOrdinal("IdRequisicionCompraMenor");
						    int posIdDependencia = datard.GetOrdinal("IdDependencia");
						    int posDepartamento = datard.GetOrdinal("Departamento");
						    int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
						    int posIdEstatusCM = datard.GetOrdinal("IdEstatusCM");
						    int posIdPartida = datard.GetOrdinal("IdPartida");
						    int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
						    int posIdPresupuesto = datard.GetOrdinal("IdPresupuesto");
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
						    int posSaldoPartida = datard.GetOrdinal("SaldoPartida");
						    int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
						    int posIdUsuarioAutoriza = datard.GetOrdinal("IdUsuarioAutoriza");
						    int posIdProveedor = datard.GetOrdinal("IdProveedor");
						    int posEconomia = datard.GetOrdinal("Economia");
						    int posEjercido = datard.GetOrdinal("Ejercido");
						    int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						    int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				    lbeRequisicionesComprasMenores = new List<beRequisicionesComprasMenores>();
				    beRequisicionesComprasMenores obeRequisicionesComprasMenores;
				    while (datard.Read())
				    {
					     obeRequisicionesComprasMenores = new beRequisicionesComprasMenores();
					    obeRequisicionesComprasMenores.IdRequisicionCompraMenor =  datard.GetInt32(posIdRequisicionCompraMenor);
					    obeRequisicionesComprasMenores.IdDependencia =  datard.GetInt32(posIdDependencia);
					    obeRequisicionesComprasMenores.Departamento =  datard.GetString(posDepartamento);
					    obeRequisicionesComprasMenores.IdOrigenRecurso =  datard.GetInt32(posIdOrigenRecurso);
					    obeRequisicionesComprasMenores.IdEstatusCM =  datard.GetInt32(posIdEstatusCM);
					    obeRequisicionesComprasMenores.IdPartida =  datard.GetInt32(posIdPartida);
					    obeRequisicionesComprasMenores.IdEjercicioFiscal =  datard.GetInt32(posIdEjercicioFiscal);
					    obeRequisicionesComprasMenores.IdPresupuesto =  datard.GetInt32(posIdPresupuesto);
					    obeRequisicionesComprasMenores.FechaRequisicion =  datard.GetDateTime(posFechaRequisicion);
					    obeRequisicionesComprasMenores.RequisicionFolio =  datard.GetString(posRequisicionFolio);
					    obeRequisicionesComprasMenores.ConsecutivoRequisicion =  datard.GetInt32(posConsecutivoRequisicion);
					    obeRequisicionesComprasMenores.MontoAproximado =  datard.GetDecimal(posMontoAproximado);
					    obeRequisicionesComprasMenores.CantidadLotes =  datard.GetInt32(posCantidadLotes);
					    obeRequisicionesComprasMenores.ImporteTotalLotes =  datard.GetDecimal(posImporteTotalLotes);
					    obeRequisicionesComprasMenores.Observaciones =  datard.GetString(posObservaciones);
					    obeRequisicionesComprasMenores.Justificacion =  datard.GetString(posJustificacion);
					    obeRequisicionesComprasMenores.FechaEntrega =  datard.GetDateTime(posFechaEntrega);
					    obeRequisicionesComprasMenores.LugarEntrega =  datard.GetString(posLugarEntrega);
					    obeRequisicionesComprasMenores.FechaPago =  datard.GetDateTime(posFechaPago);
					    obeRequisicionesComprasMenores.LugarPago =  datard.GetString(posLugarPago);
					    obeRequisicionesComprasMenores.SaldoPartida =  datard.GetDecimal(posSaldoPartida);
					    obeRequisicionesComprasMenores.MontoPresupuestado =  datard.GetDecimal(posMontoPresupuestado);
					    obeRequisicionesComprasMenores.IdUsuarioAutoriza =  datard.GetInt32(posIdUsuarioAutoriza);
					    obeRequisicionesComprasMenores.IdProveedor =  datard.GetInt32(posIdProveedor);
					    obeRequisicionesComprasMenores.Economia =  datard.GetDecimal(posEconomia);
					    obeRequisicionesComprasMenores.Ejercido =  datard.GetDecimal(posEjercido);
					    obeRequisicionesComprasMenores.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					    obeRequisicionesComprasMenores.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					    lbeRequisicionesComprasMenores.Add(obeRequisicionesComprasMenores);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeRequisicionesComprasMenores;
		    }
	    }
        */
        /*
	    public List< beRequisicionesComprasMenores> listar_RequisicionesComprasMenores_GetAll(SqlConnection Conexion)
	     {
		    string sp = "Proc_RequisicionesComprasMenores_TraerTodos_GetAll";
		    List<beRequisicionesComprasMenores> lbeRequisicionesComprasMenores = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdRequisicionCompraMenor = datard.GetOrdinal("IdRequisicionCompraMenor");
						    int posIdDependencia = datard.GetOrdinal("IdDependencia");
						    int posDepartamento = datard.GetOrdinal("Departamento");
						    int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
						    int posIdEstatusCM = datard.GetOrdinal("IdEstatusCM");
						    int posIdPartida = datard.GetOrdinal("IdPartida");
						    int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
						    int posIdPresupuesto = datard.GetOrdinal("IdPresupuesto");
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
						    int posSaldoPartida = datard.GetOrdinal("SaldoPartida");
						    int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
						    int posIdUsuarioAutoriza = datard.GetOrdinal("IdUsuarioAutoriza");
						    int posIdProveedor = datard.GetOrdinal("IdProveedor");
						    int posEconomia = datard.GetOrdinal("Economia");
						    int posEjercido = datard.GetOrdinal("Ejercido");
						    int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						    int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

                            int posDependencia = datard.GetOrdinal("Dependencia");
                            int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                            int posPartida = datard.GetOrdinal("Partida");
                            int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                            int posCapitulo = datard.GetOrdinal("Capitulo");
                            int posEjercicio = datard.GetOrdinal("Ejercicio");
                            int posRazonSocial = datard.GetOrdinal("RazonSocial");
                            lbeRequisicionesComprasMenores = new List<beRequisicionesComprasMenores>();
				    beRequisicionesComprasMenores obeRequisicionesComprasMenores;
				    while (datard.Read())
				    {
					     obeRequisicionesComprasMenores = new beRequisicionesComprasMenores();
					    obeRequisicionesComprasMenores.IdRequisicionCompraMenor =  datard.GetInt32(posIdRequisicionCompraMenor);
					    obeRequisicionesComprasMenores.IdDependencia =  datard.GetInt32(posIdDependencia);
					    obeRequisicionesComprasMenores.Departamento =  datard.GetString(posDepartamento);
					    obeRequisicionesComprasMenores.IdOrigenRecurso =  datard.GetInt32(posIdOrigenRecurso);
					    obeRequisicionesComprasMenores.IdEstatusCM =  datard.GetInt32(posIdEstatusCM);
					    obeRequisicionesComprasMenores.IdPartida =  datard.GetInt32(posIdPartida);
					    obeRequisicionesComprasMenores.IdEjercicioFiscal =  datard.GetInt32(posIdEjercicioFiscal);
					    obeRequisicionesComprasMenores.IdPresupuesto =  datard.GetInt32(posIdPresupuesto);
					    obeRequisicionesComprasMenores.FechaRequisicion =  datard.GetDateTime(posFechaRequisicion);
					    obeRequisicionesComprasMenores.RequisicionFolio =  datard.GetString(posRequisicionFolio);
					    obeRequisicionesComprasMenores.ConsecutivoRequisicion =  datard.GetInt32(posConsecutivoRequisicion);
					    obeRequisicionesComprasMenores.MontoAproximado =  datard.GetDecimal(posMontoAproximado);
					    obeRequisicionesComprasMenores.CantidadLotes =  datard.GetInt32(posCantidadLotes);
					    obeRequisicionesComprasMenores.ImporteTotalLotes =  datard.GetDecimal(posImporteTotalLotes);
					    obeRequisicionesComprasMenores.Observaciones =  datard.GetString(posObservaciones);
					    obeRequisicionesComprasMenores.Justificacion =  datard.GetString(posJustificacion);
					    obeRequisicionesComprasMenores.FechaEntrega =  datard.GetDateTime(posFechaEntrega);
					    obeRequisicionesComprasMenores.LugarEntrega =  datard.GetString(posLugarEntrega);
					    obeRequisicionesComprasMenores.FechaPago =  datard.GetDateTime(posFechaPago);
					    obeRequisicionesComprasMenores.LugarPago =  datard.GetString(posLugarPago);
					    obeRequisicionesComprasMenores.SaldoPartida =  datard.GetDecimal(posSaldoPartida);
					    obeRequisicionesComprasMenores.MontoPresupuestado =  datard.GetDecimal(posMontoPresupuestado);
					    obeRequisicionesComprasMenores.IdUsuarioAutoriza =  datard.GetInt32(posIdUsuarioAutoriza);
					    obeRequisicionesComprasMenores.IdProveedor =  datard.GetInt32(posIdProveedor);
					    obeRequisicionesComprasMenores.Economia =  datard.GetDecimal(posEconomia);
					    obeRequisicionesComprasMenores.Ejercido =  datard.GetDecimal(posEjercido);
					    obeRequisicionesComprasMenores.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					    obeRequisicionesComprasMenores.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			    // debe agregar campos de la Vista
                        obeRequisicionesComprasMenores.Dependencia =  datard.GetString(posDependencia);
                        obeRequisicionesComprasMenores.OrigenRecurso =  datard.GetString(posOrigenRecurso);
                        obeRequisicionesComprasMenores.Partida =  datard.GetString(posPartida);
                        obeRequisicionesComprasMenores.IdCapitulo =  datard.GetInt32(posIdCapitulo);
                        obeRequisicionesComprasMenores.Capitulo =  datard.GetString(posCapitulo);
                        obeRequisicionesComprasMenores.Ejercicio =  datard.GetInt32(posEjercicio);
                        obeRequisicionesComprasMenores.RazonSocial =  datard.GetString(posRazonSocial);
					    lbeRequisicionesComprasMenores.Add(obeRequisicionesComprasMenores);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeRequisicionesComprasMenores;
		    }
	    }
        */

        public List<beRequisicionesComprasMenores> listar_RequisicionesComprasMenores_Listado(SqlConnection Conexion, beGenerica oGenerico)
        {
            string sp = "Proc_RequisicionesComprasMenores_Traer_PerfilEstatusCM";
            List<beRequisicionesComprasMenores> lbeRequisicionesComprasMenores = new List<beRequisicionesComprasMenores>();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = oGenerico.entero;
            cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = oGenerico.entero2;
            cmd.Parameters.Add("@Lista", SqlDbType.Int).Value = oGenerico.entero3;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdRequisicionCompraMenor = datard.GetOrdinal("IdRequisicionCompraMenor");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdDepartamento = datard.GetOrdinal("IdDepartamento");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdEstatusCM = datard.GetOrdinal("IdEstatusCM");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int posIdPresupuesto = datard.GetOrdinal("IdPresupuesto");
                        int posFechaRequisicion = datard.GetOrdinal("FechaRequisicion");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posConsecutivoRequisicion = datard.GetOrdinal("ConsecutivoRequisicion");
                        int posMontoAproximado = datard.GetOrdinal("MontoAproximado");
                        int posCantidadLotes = datard.GetOrdinal("CantidadLotes");
                        int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posJustificacion = datard.GetOrdinal("Justificacion");
                        int posFechaEntrega = datard.GetOrdinal("FechaEntrega");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posFechaPago = datard.GetOrdinal("FechaPago");
                        int posIdLugarPago = datard.GetOrdinal("IdLugarPago");
                        int posSaldoPartida = datard.GetOrdinal("SaldoPartida");
                        int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                        int posIdUsuarioAutoriza = datard.GetOrdinal("IdUsuarioAutoriza");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posEconomia = datard.GetOrdinal("Economia");
                        int posEjercido = datard.GetOrdinal("Ejercido");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posEstatus = datard.GetOrdinal("Estatus");
                        lbeRequisicionesComprasMenores = new List<beRequisicionesComprasMenores>();
                        beRequisicionesComprasMenores obeRequisicionesComprasMenores;
                        while (datard.Read())
                        {
                            obeRequisicionesComprasMenores = new beRequisicionesComprasMenores();
                            obeRequisicionesComprasMenores.IdRequisicionCompraMenor = datard.GetInt32(posIdRequisicionCompraMenor);
                            obeRequisicionesComprasMenores.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeRequisicionesComprasMenores.IdDepartamento = datard.GetInt32(posIdDepartamento);
                            obeRequisicionesComprasMenores.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeRequisicionesComprasMenores.IdEstatusCM = datard.GetInt32(posIdEstatusCM);
                            obeRequisicionesComprasMenores.IdPartida = datard.GetInt32(posIdPartida);
                            obeRequisicionesComprasMenores.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obeRequisicionesComprasMenores.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeRequisicionesComprasMenores.IdPresupuesto = datard.GetInt32(posIdPresupuesto);
                            obeRequisicionesComprasMenores.FechaRequisicion = datard.GetDateTime(posFechaRequisicion);
                            obeRequisicionesComprasMenores.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeRequisicionesComprasMenores.ConsecutivoRequisicion = datard.GetInt32(posConsecutivoRequisicion);
                            obeRequisicionesComprasMenores.MontoAproximado = datard.GetDecimal(posMontoAproximado);
                            obeRequisicionesComprasMenores.CantidadLotes = datard.GetInt32(posCantidadLotes);
                            obeRequisicionesComprasMenores.ImporteTotalLotes = datard.GetDecimal(posImporteTotalLotes);
                            obeRequisicionesComprasMenores.Observaciones = datard.GetString(posObservaciones);
                            obeRequisicionesComprasMenores.Justificacion = datard.GetString(posJustificacion);
                            obeRequisicionesComprasMenores.FechaEntrega = datard.GetDateTime(posFechaEntrega);
                            obeRequisicionesComprasMenores.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeRequisicionesComprasMenores.FechaPago = datard.GetDateTime(posFechaPago);
                            obeRequisicionesComprasMenores.IdLugarPago = datard.GetInt32(posIdLugarPago);
                            obeRequisicionesComprasMenores.SaldoPartida = datard.GetDecimal(posSaldoPartida);
                            obeRequisicionesComprasMenores.MontoPresupuestado = datard.GetDecimal(posMontoPresupuestado);
                            obeRequisicionesComprasMenores.IdUsuarioAutoriza = datard.GetInt32(posIdUsuarioAutoriza);
                            obeRequisicionesComprasMenores.IdProveedor = datard.GetInt32(posIdProveedor);
                            obeRequisicionesComprasMenores.Economia = datard.GetDecimal(posEconomia);
                            obeRequisicionesComprasMenores.Ejercido = datard.GetDecimal(posEjercido);
                            obeRequisicionesComprasMenores.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesComprasMenores.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            // debe agregar campos de la Vista
                            obeRequisicionesComprasMenores.Dependencia = datard.GetString(posDependencia);
                            obeRequisicionesComprasMenores.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            obeRequisicionesComprasMenores.Partida = datard.GetString(posPartida);
                            obeRequisicionesComprasMenores.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            obeRequisicionesComprasMenores.Capitulo = datard.GetString(posCapitulo);
                            obeRequisicionesComprasMenores.Ejercicio = datard.GetInt32(posEjercicio);
                            obeRequisicionesComprasMenores.RazonSocial = datard.GetString(posRazonSocial);
                            obeRequisicionesComprasMenores.Estatus = datard.GetString(posEstatus);
                            lbeRequisicionesComprasMenores.Add(obeRequisicionesComprasMenores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesComprasMenores;
            }
        }
    }
}
