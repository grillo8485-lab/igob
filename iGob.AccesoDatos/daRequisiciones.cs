using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRequisiciones
    {
        public int guardarRequisiciones(SqlConnection Conexion, beRequisiciones obeRequisiciones)
        {
            int Id = 0;
            string sp = "Proc_RequisicionesInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisiciones.IdRequisicion;
                    cmd.Parameters.Add("@IdRequisicionOrigen", SqlDbType.Int).Value = obeRequisiciones.IdRequisicionOrigen;
                    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeRequisiciones.IdDependencia;
                    cmd.Parameters.Add("@IdTipoRequisicion", SqlDbType.Int).Value = obeRequisiciones.IdTipoRequisicion;
                    cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = obeRequisiciones.IdTipoSolicitud;
                    cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeRequisiciones.IdOrigenRecurso;
                    cmd.Parameters.Add("@IdOrigenRecursoAutorizado", SqlDbType.Int).Value = obeRequisiciones.IdOrigenRecursoAutorizado;
                    cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeRequisiciones.IdEstatus;
                    cmd.Parameters.Add("@IdEstatusRequisicion", SqlDbType.Int).Value = obeRequisiciones.IdEstatusRequisicion;
                    cmd.Parameters.Add("@NumeroLicitacion", SqlDbType.Int).Value = obeRequisiciones.NumeroLicitacion;
                    cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeRequisiciones.IdTiempo;
                    cmd.Parameters.Add("@IdFormaAbastecimiento", SqlDbType.Int).Value = obeRequisiciones.IdFormaAbastecimiento;
                    cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obeRequisiciones.IdPartida;
                    cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obeRequisiciones.IdEjercicioFiscal;
                    cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = obeRequisiciones.IdPresupuestoPartida;
                    cmd.Parameters.Add("@FechaRequisicion", SqlDbType.DateTime).Value = obeRequisiciones.FechaRequisicion;
                    cmd.Parameters.Add("@RequisicionFolio", SqlDbType.NVarChar).Value = obeRequisiciones.RequisicionFolio;
                    cmd.Parameters.Add("@ConsecutivoRequisicion", SqlDbType.Int).Value = obeRequisiciones.ConsecutivoRequisicion;
                    cmd.Parameters.Add("@NumeroOficioSolicitud", SqlDbType.VarChar).Value = obeRequisiciones.NumeroOficioSolicitud;
                    cmd.Parameters.Add("@NumeroOficioCertificacion", SqlDbType.VarChar).Value = obeRequisiciones.NumeroOficioCertificacion;
                    cmd.Parameters.Add("@MontoAproximado", SqlDbType.Decimal).Value = obeRequisiciones.MontoAproximado;
                    cmd.Parameters.Add("@MontoAproximadoAutorizado", SqlDbType.Decimal).Value = obeRequisiciones.MontoAproximadoAutorizado;
                    cmd.Parameters.Add("@CantidadLotes", SqlDbType.Int).Value = obeRequisiciones.CantidadLotes;
                    cmd.Parameters.Add("@ImporteTotalLotes", SqlDbType.Decimal).Value = obeRequisiciones.ImporteTotalLotes;
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeRequisiciones.Observaciones;
                    cmd.Parameters.Add("@ObservacionesRechazo", SqlDbType.VarChar).Value = obeRequisiciones.ObservacionesRechazo;
                    cmd.Parameters.Add("@TiempoRestante", SqlDbType.Time).Value = obeRequisiciones.TiempoRestante;
                    cmd.Parameters.Add("@ColorTiempoRestante", SqlDbType.VarChar).Value = obeRequisiciones.ColorTiempoRestante;
                    cmd.Parameters.Add("@SaldoPartida", SqlDbType.Decimal).Value = obeRequisiciones.SaldoPartida;
                    cmd.Parameters.Add("@MontoPresupuestado", SqlDbType.Decimal).Value = obeRequisiciones.MontoPresupuestado;
                    cmd.Parameters.Add("@TotalLiquidez", SqlDbType.Decimal).Value = obeRequisiciones.TotalLiquidez;
                    cmd.Parameters.Add("@IdUsuarioAsignante", SqlDbType.Int).Value = obeRequisiciones.IdUsuarioAsignante;
                    cmd.Parameters.Add("@Acepta2daLicitacion", SqlDbType.Int).Value = obeRequisiciones.Acepta2daLicitacion;
                    cmd.Parameters.Add("@IdUsuarioRevisor", SqlDbType.Int).Value = obeRequisiciones.IdUsuarioRevisor;
                    cmd.Parameters.Add("@FechaAsignaRevisor", SqlDbType.DateTime).Value = obeRequisiciones.FechaAsignaRevisor;
                    cmd.Parameters.Add("@FechaAutorizacion", SqlDbType.DateTime).Value = obeRequisiciones.FechaAutorizacion;
                    cmd.Parameters.Add("@Economia", SqlDbType.Decimal).Value = obeRequisiciones.Economia;
                    cmd.Parameters.Add("@Ejercido", SqlDbType.Decimal).Value = obeRequisiciones.Ejercido;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisiciones.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisiciones.FechaRegistro;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarRequisiciones(SqlConnection Conexion, beRequisiciones obeRequisiciones)
        {
            string sp = "Proc_RequisicionesActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisiciones.IdRequisicion;
                    cmd.Parameters.Add("@IdRequisicionOrigen", SqlDbType.Int).Value = obeRequisiciones.IdRequisicionOrigen;
                    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeRequisiciones.IdDependencia;
                    cmd.Parameters.Add("@IdTipoRequisicion", SqlDbType.Int).Value = obeRequisiciones.IdTipoRequisicion;
                    cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = obeRequisiciones.IdTipoSolicitud;
                    cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeRequisiciones.IdOrigenRecurso;
                    cmd.Parameters.Add("@IdOrigenRecursoAutorizado", SqlDbType.Int).Value = obeRequisiciones.IdOrigenRecursoAutorizado;
                    cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeRequisiciones.IdEstatus;
                    cmd.Parameters.Add("@IdEstatusRequisicion", SqlDbType.Int).Value = obeRequisiciones.IdEstatusRequisicion;
                    cmd.Parameters.Add("@NumeroLicitacion", SqlDbType.Int).Value = obeRequisiciones.NumeroLicitacion;
                    cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeRequisiciones.IdTiempo;
                    cmd.Parameters.Add("@IdFormaAbastecimiento", SqlDbType.Int).Value = obeRequisiciones.IdFormaAbastecimiento;
                    cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obeRequisiciones.IdPartida;
                    cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obeRequisiciones.IdEjercicioFiscal;
                    cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = obeRequisiciones.IdPresupuestoPartida;
                    cmd.Parameters.Add("@FechaRequisicion", SqlDbType.DateTime).Value = obeRequisiciones.FechaRequisicion;
                    cmd.Parameters.Add("@RequisicionFolio", SqlDbType.NVarChar).Value = obeRequisiciones.RequisicionFolio;
                    cmd.Parameters.Add("@ConsecutivoRequisicion", SqlDbType.Int).Value = obeRequisiciones.ConsecutivoRequisicion;
                    cmd.Parameters.Add("@NumeroOficioSolicitud", SqlDbType.VarChar).Value = obeRequisiciones.NumeroOficioSolicitud;
                    cmd.Parameters.Add("@NumeroOficioCertificacion", SqlDbType.VarChar).Value = obeRequisiciones.NumeroOficioCertificacion;
                    cmd.Parameters.Add("@MontoAproximado", SqlDbType.Decimal).Value = obeRequisiciones.MontoAproximado;
                    cmd.Parameters.Add("@MontoAproximadoAutorizado", SqlDbType.Decimal).Value = obeRequisiciones.MontoAproximadoAutorizado;
                    cmd.Parameters.Add("@CantidadLotes", SqlDbType.Int).Value = obeRequisiciones.CantidadLotes;
                    cmd.Parameters.Add("@ImporteTotalLotes", SqlDbType.Decimal).Value = obeRequisiciones.ImporteTotalLotes;
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeRequisiciones.Observaciones;
                    cmd.Parameters.Add("@ObservacionesRechazo", SqlDbType.VarChar).Value = obeRequisiciones.ObservacionesRechazo;
                    cmd.Parameters.Add("@TiempoRestante", SqlDbType.Time).Value = obeRequisiciones.TiempoRestante;
                    cmd.Parameters.Add("@ColorTiempoRestante", SqlDbType.VarChar).Value = obeRequisiciones.ColorTiempoRestante;
                    cmd.Parameters.Add("@SaldoPartida", SqlDbType.Decimal).Value = obeRequisiciones.SaldoPartida;
                    cmd.Parameters.Add("@MontoPresupuestado", SqlDbType.Decimal).Value = obeRequisiciones.MontoPresupuestado;
                    cmd.Parameters.Add("@TotalLiquidez", SqlDbType.Decimal).Value = obeRequisiciones.TotalLiquidez;
                    cmd.Parameters.Add("@IdUsuarioAsignante", SqlDbType.Int).Value = obeRequisiciones.IdUsuarioAsignante;
                    cmd.Parameters.Add("@Acepta2daLicitacion", SqlDbType.Int).Value = obeRequisiciones.Acepta2daLicitacion;
                    cmd.Parameters.Add("@IdUsuarioRevisor", SqlDbType.Int).Value = obeRequisiciones.IdUsuarioRevisor;
                    cmd.Parameters.Add("@FechaAsignaRevisor", SqlDbType.DateTime).Value = obeRequisiciones.FechaAsignaRevisor;
                    cmd.Parameters.Add("@FechaAutorizacion", SqlDbType.DateTime).Value = obeRequisiciones.FechaAutorizacion;
                    cmd.Parameters.Add("@Economia", SqlDbType.Decimal).Value = obeRequisiciones.Economia;
                    cmd.Parameters.Add("@Ejercido", SqlDbType.Decimal).Value = obeRequisiciones.Ejercido;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisiciones.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisiciones.FechaRegistro;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarRequisiciones(SqlConnection Conexion, int pIdRequisicion)
        {
            string sp = "Proc_RequisicionesEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = pIdRequisicion;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beRequisiciones traerRequisiciones_x_IdRequisicion(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_Requisiciones_x_IdRequisicion";
            beRequisiciones obeRequisiciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdRequisicionOrigen = datard.GetOrdinal("IdRequisicionOrigen");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdTipoRequisicion = datard.GetOrdinal("IdTipoRequisicion");
                        int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdEstatusRequisicion = datard.GetOrdinal("IdEstatusRequisicion");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posIdTiempo = datard.GetOrdinal("IdTiempo");
                        int posIdFormaAbastecimiento = datard.GetOrdinal("IdFormaAbastecimiento");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        int posFechaRequisicion = datard.GetOrdinal("FechaRequisicion");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posConsecutivoRequisicion = datard.GetOrdinal("ConsecutivoRequisicion");
                        int posNumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
                        int posNumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
                        int posMontoAproximado = datard.GetOrdinal("MontoAproximado");
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posCantidadLotes = datard.GetOrdinal("CantidadLotes");
                        int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posObservacionesRechazo = datard.GetOrdinal("ObservacionesRechazo");
                        int posTiempoRestante = datard.GetOrdinal("TiempoRestante");
                        int posColorTiempoRestante = datard.GetOrdinal("ColorTiempoRestante");
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
                        
                        obeRequisiciones = new beRequisiciones();
                        while (datard.Read())
                        {
                            obeRequisiciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisiciones.IdRequisicionOrigen = datard.GetInt32(posIdRequisicionOrigen);
                            obeRequisiciones.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeRequisiciones.IdTipoRequisicion = datard.GetInt32(posIdTipoRequisicion);
                            obeRequisiciones.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeRequisiciones.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeRequisiciones.IdOrigenRecursoAutorizado = datard.GetInt32(posIdOrigenRecursoAutorizado);
                            obeRequisiciones.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisiciones.IdEstatusRequisicion = datard.GetInt32(posIdEstatusRequisicion);
                            obeRequisiciones.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            obeRequisiciones.IdTiempo = datard.GetInt32(posIdTiempo);
                            obeRequisiciones.IdFormaAbastecimiento = datard.GetInt32(posIdFormaAbastecimiento);
                            obeRequisiciones.IdPartida = datard.GetInt32(posIdPartida);
                            obeRequisiciones.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obeRequisiciones.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            obeRequisiciones.FechaRequisicion = datard.GetDateTime(posFechaRequisicion);
                            obeRequisiciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeRequisiciones.ConsecutivoRequisicion = datard.GetInt32(posConsecutivoRequisicion);
                            obeRequisiciones.NumeroOficioSolicitud = datard.GetString(posNumeroOficioSolicitud);
                            obeRequisiciones.NumeroOficioCertificacion = datard.GetString(posNumeroOficioCertificacion);
                            obeRequisiciones.MontoAproximado = datard.GetDecimal(posMontoAproximado);
                            obeRequisiciones.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            obeRequisiciones.CantidadLotes = datard.GetInt32(posCantidadLotes);
                            obeRequisiciones.ImporteTotalLotes = datard.GetDecimal(posImporteTotalLotes);
                            obeRequisiciones.Observaciones = datard.GetString(posObservaciones);
                            obeRequisiciones.ObservacionesRechazo = datard.GetString(posObservacionesRechazo);
                            obeRequisiciones.TiempoRestante = datard.GetTimeSpan(posTiempoRestante);
                            obeRequisiciones.ColorTiempoRestante = datard.GetString(posColorTiempoRestante);
                            obeRequisiciones.SaldoPartida = datard.GetDecimal(posSaldoPartida);
                            obeRequisiciones.MontoPresupuestado = datard.GetDecimal(posMontoPresupuestado);
                            obeRequisiciones.TotalLiquidez = datard.GetDecimal(posTotalLiquidez);
                            obeRequisiciones.IdUsuarioAsignante = datard.GetInt32(posIdUsuarioAsignante);
                            obeRequisiciones.Acepta2daLicitacion = datard.GetInt32(posAcepta2daLicitacion);
                            obeRequisiciones.IdUsuarioRevisor = datard.GetInt32(posIdUsuarioRevisor);
                            obeRequisiciones.FechaAsignaRevisor = datard.GetDateTime(posFechaAsignaRevisor);
                            obeRequisiciones.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            obeRequisiciones.Economia = datard.GetDecimal(posEconomia);
                            obeRequisiciones.Ejercido = datard.GetDecimal(posEjercido);
                            obeRequisiciones.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisiciones.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisiciones;
            }
        }
        public List<beRequisiciones> listarTodos_Requisiciones(SqlConnection Conexion)
        {
            string sp = "Proc_Requisiciones_Traer_Todos";
            List<beRequisiciones> lbeRequisiciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdRequisicionOrigen = datard.GetOrdinal("IdRequisicionOrigen");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdTipoRequisicion = datard.GetOrdinal("IdTipoRequisicion");
                        int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdEstatusRequisicion = datard.GetOrdinal("IdEstatusRequisicion");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posIdTiempo = datard.GetOrdinal("IdTiempo");
                        int posIdFormaAbastecimiento = datard.GetOrdinal("IdFormaAbastecimiento");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        int posFechaRequisicion = datard.GetOrdinal("FechaRequisicion");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posConsecutivoRequisicion = datard.GetOrdinal("ConsecutivoRequisicion");
                        int posNumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
                        int posNumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
                        int posMontoAproximado = datard.GetOrdinal("MontoAproximado");
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posCantidadLotes = datard.GetOrdinal("CantidadLotes");
                        int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posObservacionesRechazo = datard.GetOrdinal("ObservacionesRechazo");
                        int posTiempoRestante = datard.GetOrdinal("TiempoRestante");
                        int posColorTiempoRestante = datard.GetOrdinal("ColorTiempoRestante");
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
                        lbeRequisiciones = new List<beRequisiciones>();
                        beRequisiciones obeRequisiciones;
                        while (datard.Read())
                        {
                            obeRequisiciones = new beRequisiciones();
                            obeRequisiciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisiciones.IdRequisicionOrigen = datard.GetInt32(posIdRequisicionOrigen);
                            obeRequisiciones.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeRequisiciones.IdTipoRequisicion = datard.GetInt32(posIdTipoRequisicion);
                            obeRequisiciones.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeRequisiciones.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeRequisiciones.IdOrigenRecursoAutorizado = datard.GetInt32(posIdOrigenRecursoAutorizado);
                            obeRequisiciones.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisiciones.IdEstatusRequisicion = datard.GetInt32(posIdEstatusRequisicion);
                            obeRequisiciones.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            obeRequisiciones.IdTiempo = datard.GetInt32(posIdTiempo);
                            obeRequisiciones.IdFormaAbastecimiento = datard.GetInt32(posIdFormaAbastecimiento);
                            obeRequisiciones.IdPartida = datard.GetInt32(posIdPartida);
                            obeRequisiciones.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obeRequisiciones.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            obeRequisiciones.FechaRequisicion = datard.GetDateTime(posFechaRequisicion);
                            obeRequisiciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeRequisiciones.ConsecutivoRequisicion = datard.GetInt32(posConsecutivoRequisicion);
                            obeRequisiciones.NumeroOficioSolicitud = datard.GetString(posNumeroOficioSolicitud);
                            obeRequisiciones.NumeroOficioCertificacion = datard.GetString(posNumeroOficioCertificacion);
                            obeRequisiciones.MontoAproximado = datard.GetDecimal(posMontoAproximado);
                            obeRequisiciones.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            obeRequisiciones.CantidadLotes = datard.GetInt32(posCantidadLotes);
                            obeRequisiciones.ImporteTotalLotes = datard.GetDecimal(posImporteTotalLotes);
                            obeRequisiciones.Observaciones = datard.GetString(posObservaciones);
                            obeRequisiciones.ObservacionesRechazo = datard.GetString(posObservacionesRechazo);
                            obeRequisiciones.TiempoRestante = datard.GetTimeSpan(posTiempoRestante);
                            obeRequisiciones.ColorTiempoRestante = datard.GetString(posColorTiempoRestante);
                            obeRequisiciones.SaldoPartida = datard.GetDecimal(posSaldoPartida);
                            obeRequisiciones.MontoPresupuestado = datard.GetDecimal(posMontoPresupuestado);
                            obeRequisiciones.TotalLiquidez = datard.GetDecimal(posTotalLiquidez);
                            obeRequisiciones.IdUsuarioAsignante = datard.GetInt32(posIdUsuarioAsignante);
                            obeRequisiciones.Acepta2daLicitacion = datard.GetInt32(posAcepta2daLicitacion);
                            obeRequisiciones.IdUsuarioRevisor = datard.GetInt32(posIdUsuarioRevisor);
                            obeRequisiciones.FechaAsignaRevisor = datard.GetDateTime(posFechaAsignaRevisor);
                            obeRequisiciones.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            obeRequisiciones.Economia = datard.GetDecimal(posEconomia);
                            obeRequisiciones.Ejercido = datard.GetDecimal(posEjercido);
                            obeRequisiciones.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisiciones.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            lbeRequisiciones.Add(obeRequisiciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisiciones;
            }
        }
        public List<beRequisiciones> listar_Requisiciones_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_Requisiciones_TraerTodos_GetAll";
            List<beRequisiciones> lbeRequisiciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdRequisicionOrigen = datard.GetOrdinal("IdRequisicionOrigen");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdTipoRequisicion = datard.GetOrdinal("IdTipoRequisicion");
                        int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdEstatusRequisicion = datard.GetOrdinal("IdEstatusRequisicion");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posIdTiempo = datard.GetOrdinal("IdTiempo");
                        int posIdFormaAbastecimiento = datard.GetOrdinal("IdFormaAbastecimiento");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        int posFechaRequisicion = datard.GetOrdinal("FechaRequisicion");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posConsecutivoRequisicion = datard.GetOrdinal("ConsecutivoRequisicion");
                        int posNumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
                        int posNumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
                        int posMontoAproximado = datard.GetOrdinal("MontoAproximado");
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posCantidadLotes = datard.GetOrdinal("CantidadLotes");
                        int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posObservacionesRechazo = datard.GetOrdinal("ObservacionesRechazo");
                        int posTiempoRestante = datard.GetOrdinal("TiempoRestante");
                        int posColorTiempoRestante = datard.GetOrdinal("ColorTiempoRestante");
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
                        lbeRequisiciones = new List<beRequisiciones>();
                        beRequisiciones obeRequisiciones;
                        while (datard.Read())
                        {
                            obeRequisiciones = new beRequisiciones();
                            obeRequisiciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisiciones.IdRequisicionOrigen = datard.GetInt32(posIdRequisicionOrigen);
                            obeRequisiciones.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeRequisiciones.IdTipoRequisicion = datard.GetInt32(posIdTipoRequisicion);
                            obeRequisiciones.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeRequisiciones.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeRequisiciones.IdOrigenRecursoAutorizado = datard.GetInt32(posIdOrigenRecursoAutorizado);
                            obeRequisiciones.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisiciones.IdEstatusRequisicion = datard.GetInt32(posIdEstatusRequisicion);
                            obeRequisiciones.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            obeRequisiciones.IdTiempo = datard.GetInt32(posIdTiempo);
                            obeRequisiciones.IdFormaAbastecimiento = datard.GetInt32(posIdFormaAbastecimiento);
                            obeRequisiciones.IdPartida = datard.GetInt32(posIdPartida);
                            obeRequisiciones.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obeRequisiciones.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            obeRequisiciones.FechaRequisicion = datard.GetDateTime(posFechaRequisicion);
                            obeRequisiciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeRequisiciones.ConsecutivoRequisicion = datard.GetInt32(posConsecutivoRequisicion);
                            obeRequisiciones.NumeroOficioSolicitud = datard.GetString(posNumeroOficioSolicitud);
                            obeRequisiciones.NumeroOficioCertificacion = datard.GetString(posNumeroOficioCertificacion);
                            obeRequisiciones.MontoAproximado = datard.GetDecimal(posMontoAproximado);
                            obeRequisiciones.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            obeRequisiciones.CantidadLotes = datard.GetInt32(posCantidadLotes);
                            obeRequisiciones.ImporteTotalLotes = datard.GetDecimal(posImporteTotalLotes);
                            obeRequisiciones.Observaciones = datard.GetString(posObservaciones);
                            obeRequisiciones.ObservacionesRechazo = datard.GetString(posObservacionesRechazo);
                            obeRequisiciones.TiempoRestante = datard.GetTimeSpan(posTiempoRestante);
                            obeRequisiciones.ColorTiempoRestante = datard.GetString(posColorTiempoRestante);
                            obeRequisiciones.SaldoPartida = datard.GetDecimal(posSaldoPartida);
                            obeRequisiciones.MontoPresupuestado = datard.GetDecimal(posMontoPresupuestado);
                            obeRequisiciones.TotalLiquidez = datard.GetDecimal(posTotalLiquidez);
                            obeRequisiciones.IdUsuarioAsignante = datard.GetInt32(posIdUsuarioAsignante);
                            obeRequisiciones.Acepta2daLicitacion = datard.GetInt32(posAcepta2daLicitacion);
                            obeRequisiciones.IdUsuarioRevisor = datard.GetInt32(posIdUsuarioRevisor);
                            obeRequisiciones.FechaAsignaRevisor = datard.GetDateTime(posFechaAsignaRevisor);
                            obeRequisiciones.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            obeRequisiciones.Economia = datard.GetDecimal(posEconomia);
                            obeRequisiciones.Ejercido = datard.GetDecimal(posEjercido);
                            obeRequisiciones.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisiciones.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            // debe agregar campos de la Vista
                            lbeRequisiciones.Add(obeRequisiciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisiciones;
            }
        }
    }
}
