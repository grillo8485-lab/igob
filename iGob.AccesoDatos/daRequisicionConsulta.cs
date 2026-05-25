using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.AccesoDatos
{
    public class daRequisicionConsulta
    {
        public List<beRequisicionConsulta> listarRequisicionConsulta(SqlConnection Conexion, beGenerica oGenerico)
        {
            List<beRequisicionConsulta> lbeRequisicionConsulta = new List<beRequisicionConsulta>();
            string sp = "Proc_Requisiciones_Traer_PerfilRequisicionEstatus";
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
                        int IdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int IdRequisicionOrigen = datard.GetOrdinal("IdRequisicionOrigen");
                        int IdDependencia = datard.GetOrdinal("IdDependencia");
                        int IdTipoRequisicion = datard.GetOrdinal("IdTipoRequisicion");
                        int IdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int IdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int IdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
                        int IdEstatus = datard.GetOrdinal("IdEstatus");
                        int IdEstatusRequisicion = datard.GetOrdinal("IdEstatusRequisicion");
                        int NumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int IdTiempo = datard.GetOrdinal("IdTiempo");
                        int IdFormaAbastecimiento = datard.GetOrdinal("IdFormaAbastecimiento");
                        int IdPartida = datard.GetOrdinal("IdPartida");
                        int IdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int FechaRequisicion = datard.GetOrdinal("FechaRequisicion");
                        int RequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int ConsecutivoRequisicion = datard.GetOrdinal("ConsecutivoRequisicion");
                        int NumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
                        int NumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
                        int MontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int MontoAproximado = datard.GetOrdinal("MontoAproximado");
                        int CantidadLotes = datard.GetOrdinal("CantidadLotes");
                        int ImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
                        int Observaciones = datard.GetOrdinal("Observaciones");
                        int ObservacionesRechazo = datard.GetOrdinal("ObservacionesRechazo");
                        int TiempoRestante = datard.GetOrdinal("TiempoRestante");
                        int OrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int DescripcionOrigenRecurso = datard.GetOrdinal("DescripcionOrigenRecurso");
                        int TipoRequisicion = datard.GetOrdinal("TipoRequisicion");
                        int Tiempo = datard.GetOrdinal("Tiempo");
                        int TipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int DescripcionTiposSolicitud = datard.GetOrdinal("DescripcionTiposSolicitud");
                        int AbreviaturaTiposSolicitud = datard.GetOrdinal("AbreviaturaTiposSolicitud");
                        int Estatus = datard.GetOrdinal("Estatus");
                        int Dependencia = datard.GetOrdinal("Dependencia");
                        int AbreviaturaDependencias = datard.GetOrdinal("AbreviaturaDependencias");
                        int IdGobierno = datard.GetOrdinal("IdGobierno");
                        int IdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int Capitulo = datard.GetOrdinal("Capitulo");
                        int Partida = datard.GetOrdinal("Partida");
                        int FormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int Ejercicio = datard.GetOrdinal("Ejercicio");
                        int IdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
                        int IdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int NumeroLicitacionT = datard.GetOrdinal("NumeroLicitacionT");
                        int ColorTiempoRestante = datard.GetOrdinal("ColorTiempoRestante");
                        while (datard.Read())
                        {
                            beRequisicionConsulta obeRequisicionConsulta = new beRequisicionConsulta();
                            obeRequisicionConsulta.IdRequisicion = datard.GetInt32(IdRequisicion);
                            obeRequisicionConsulta.IdRequisicionOrigen = datard.GetInt32(IdRequisicionOrigen);
                            obeRequisicionConsulta.IdDependencia = datard.GetInt32(IdDependencia);
                            obeRequisicionConsulta.IdTipoRequisicion = datard.GetInt32(IdTipoRequisicion);
                            obeRequisicionConsulta.IdTipoSolicitud = datard.GetInt32(IdTipoSolicitud);
                            obeRequisicionConsulta.IdOrigenRecurso = datard.GetInt32(IdOrigenRecurso);
                            obeRequisicionConsulta.IdOrigenRecursoAutorizado = datard.GetInt32(IdOrigenRecursoAutorizado);
                            obeRequisicionConsulta.IdEstatus = datard.GetInt32(IdEstatus);
                            obeRequisicionConsulta.IdEstatusRequisicion = datard.GetInt32(IdEstatusRequisicion);
                            obeRequisicionConsulta.NumeroLicitacion = datard.GetInt32(NumeroLicitacion);
                            obeRequisicionConsulta.IdTiempo = datard.GetInt32(IdTiempo);
                            obeRequisicionConsulta.IdFormaAbastecimiento = datard.GetInt32(IdFormaAbastecimiento);
                            obeRequisicionConsulta.IdPartida = datard.GetInt32(IdPartida);
                            obeRequisicionConsulta.IdEjercicioFiscal = datard.GetInt32(IdEjercicioFiscal);
                            obeRequisicionConsulta.FechaRequisicion = datard.GetDateTime(FechaRequisicion);
                            obeRequisicionConsulta.RequisicionFolio = datard.GetString(RequisicionFolio);
                            obeRequisicionConsulta.ConsecutivoRequisicion = datard.GetInt32(ConsecutivoRequisicion);
                            obeRequisicionConsulta.NumeroOficioSolicitud = datard.GetString(NumeroOficioSolicitud);
                            obeRequisicionConsulta.NumeroOficioSolicitud = datard.GetString(NumeroOficioSolicitud);
                            obeRequisicionConsulta.NumeroOficioCertificacion = datard.GetString(NumeroOficioCertificacion);
                            obeRequisicionConsulta.MontoAproximadoAutorizado = datard.GetDecimal(MontoAproximadoAutorizado);
                            obeRequisicionConsulta.MontoAproximado = datard.GetDecimal(MontoAproximado);
                            obeRequisicionConsulta.CantidadLotes = datard.GetInt32(CantidadLotes); ;
                            obeRequisicionConsulta.ImporteTotalLotes = datard.GetDecimal(ImporteTotalLotes); ;
                            obeRequisicionConsulta.Observaciones = datard.GetString(Observaciones);
                            obeRequisicionConsulta.ObservacionesRechazo = datard.GetString(ObservacionesRechazo);
                            obeRequisicionConsulta.TiempoRestante = datard.GetTimeSpan(TiempoRestante); ;
                            obeRequisicionConsulta.OrigenRecurso = datard.GetString(OrigenRecurso);
                            obeRequisicionConsulta.DescripcionOrigenRecurso = datard.GetString(DescripcionOrigenRecurso);
                            obeRequisicionConsulta.TipoRequisicion = datard.GetString(TipoRequisicion);
                            obeRequisicionConsulta.Tiempo = datard.GetString(Tiempo);
                            obeRequisicionConsulta.TipoSolicitud = datard.GetString(TipoSolicitud);
                            obeRequisicionConsulta.DescripcionTiposSolicitud = datard.GetString(DescripcionTiposSolicitud);
                            obeRequisicionConsulta.AbreviaturaTiposSolicitud = datard.GetString(AbreviaturaTiposSolicitud);
                            obeRequisicionConsulta.Estatus = datard.GetString(Estatus);
                            obeRequisicionConsulta.Dependencia = datard.GetString(Dependencia);
                            obeRequisicionConsulta.AbreviaturaDependencias = datard.GetString(AbreviaturaDependencias);
                            obeRequisicionConsulta.IdGobierno = datard.GetInt32(IdGobierno);
                            obeRequisicionConsulta.IdCapitulo = datard.GetInt32(IdCapitulo);
                            obeRequisicionConsulta.Capitulo = datard.GetString(Capitulo);
                            obeRequisicionConsulta.Partida = datard.GetString(Partida);
                            obeRequisicionConsulta.FormaAbastecimiento = datard.GetString(FormaAbastecimiento);
                            obeRequisicionConsulta.Ejercicio = datard.GetInt32(Ejercicio);
                            obeRequisicionConsulta.IdUsuarioRevisor = datard.GetInt32(IdUsuarioRevisor);
                            obeRequisicionConsulta.IdUsuarioRegistro = datard.GetInt32(IdUsuarioRegistro);
                            obeRequisicionConsulta.NumeroLicitacionT = datard.GetString(NumeroLicitacionT);
                            obeRequisicionConsulta.ColorTiempoRestante = datard.GetString(ColorTiempoRestante);
                            lbeRequisicionConsulta.Add(obeRequisicionConsulta);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionConsulta;
            }
        }
        public List<beRequisicionConsulta> listarRequisicionSegundaVueltaConsulta(SqlConnection Conexion, beGenerica oGenerico)
        {
            List<beRequisicionConsulta> lbeRequisicionConsulta = new List<beRequisicionConsulta>();
            string sp = "Proc_RequisicionesSegundaLicitacion_Traer_PerfilRequisicionEstatus";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = oGenerico.entero;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int IdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int IdRequisicionOrigen = datard.GetOrdinal("IdRequisicionOrigen");
                        int IdDependencia = datard.GetOrdinal("IdDependencia");
                        int IdTipoRequisicion = datard.GetOrdinal("IdTipoRequisicion");
                        int IdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int IdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int IdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
                        int IdEstatus = datard.GetOrdinal("IdEstatus");
                        int IdEstatusRequisicion = datard.GetOrdinal("IdEstatusRequisicion");
                        int NumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int IdTiempo = datard.GetOrdinal("IdTiempo");
                        int IdFormaAbastecimiento = datard.GetOrdinal("IdFormaAbastecimiento");
                        int IdPartida = datard.GetOrdinal("IdPartida");
                        int IdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int FechaRequisicion = datard.GetOrdinal("FechaRequisicion");
                        int RequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int ConsecutivoRequisicion = datard.GetOrdinal("ConsecutivoRequisicion");
                        int NumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
                        int NumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
                        int MontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int MontoAproximado = datard.GetOrdinal("MontoAproximado");
                        int CantidadLotes = datard.GetOrdinal("CantidadLotes");
                        int ImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
                        int Observaciones = datard.GetOrdinal("Observaciones");
                        int ObservacionesRechazo = datard.GetOrdinal("ObservacionesRechazo");
                        int TiempoRestante = datard.GetOrdinal("TiempoRestante");
                        int OrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int DescripcionOrigenRecurso = datard.GetOrdinal("DescripcionOrigenRecurso");
                        int TipoRequisicion = datard.GetOrdinal("TipoRequisicion");
                        int Tiempo = datard.GetOrdinal("Tiempo");
                        int TipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int DescripcionTiposSolicitud = datard.GetOrdinal("DescripcionTiposSolicitud");
                        int AbreviaturaTiposSolicitud = datard.GetOrdinal("AbreviaturaTiposSolicitud");
                        int Estatus = datard.GetOrdinal("Estatus");
                        int Dependencia = datard.GetOrdinal("Dependencia");
                        int AbreviaturaDependencias = datard.GetOrdinal("AbreviaturaDependencias");
                        int IdGobierno = datard.GetOrdinal("IdGobierno");
                        int IdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int Capitulo = datard.GetOrdinal("Capitulo");
                        int Partida = datard.GetOrdinal("Partida");
                        int FormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int Ejercicio = datard.GetOrdinal("Ejercicio");
                        int IdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
                        int IdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int NumeroLicitacionT = datard.GetOrdinal("NumeroLicitacionT");
                        while (datard.Read())
                        {
                            beRequisicionConsulta obeRequisicionConsulta = new beRequisicionConsulta();
                            obeRequisicionConsulta.IdRequisicion = datard.GetInt32(IdRequisicion);
                            obeRequisicionConsulta.IdRequisicionOrigen = datard.GetInt32(IdRequisicionOrigen);
                            obeRequisicionConsulta.IdDependencia = datard.GetInt32(IdDependencia);
                            obeRequisicionConsulta.IdTipoRequisicion = datard.GetInt32(IdTipoRequisicion);
                            obeRequisicionConsulta.IdTipoSolicitud = datard.GetInt32(IdTipoSolicitud);
                            obeRequisicionConsulta.IdOrigenRecurso = datard.GetInt32(IdOrigenRecurso);
                            obeRequisicionConsulta.IdOrigenRecursoAutorizado = datard.GetInt32(IdOrigenRecursoAutorizado);
                            obeRequisicionConsulta.IdEstatus = datard.GetInt32(IdEstatus);
                            obeRequisicionConsulta.IdEstatusRequisicion = datard.GetInt32(IdEstatusRequisicion);
                            obeRequisicionConsulta.NumeroLicitacion = datard.GetInt32(NumeroLicitacion);
                            obeRequisicionConsulta.IdTiempo = datard.GetInt32(IdTiempo);
                            obeRequisicionConsulta.IdFormaAbastecimiento = datard.GetInt32(IdFormaAbastecimiento);
                            obeRequisicionConsulta.IdPartida = datard.GetInt32(IdPartida);
                            obeRequisicionConsulta.IdEjercicioFiscal = datard.GetInt32(IdEjercicioFiscal);
                            obeRequisicionConsulta.FechaRequisicion = datard.GetDateTime(FechaRequisicion);
                            obeRequisicionConsulta.RequisicionFolio = datard.GetString(RequisicionFolio);
                            obeRequisicionConsulta.ConsecutivoRequisicion = datard.GetInt32(ConsecutivoRequisicion);
                            obeRequisicionConsulta.NumeroOficioSolicitud = datard.GetString(NumeroOficioSolicitud);
                            obeRequisicionConsulta.NumeroOficioSolicitud = datard.GetString(NumeroOficioSolicitud);
                            obeRequisicionConsulta.NumeroOficioCertificacion = datard.GetString(NumeroOficioCertificacion);
                            obeRequisicionConsulta.MontoAproximadoAutorizado = datard.GetDecimal(MontoAproximadoAutorizado);
                            obeRequisicionConsulta.MontoAproximado = datard.GetDecimal(MontoAproximado);
                            obeRequisicionConsulta.CantidadLotes = datard.GetInt32(CantidadLotes); ;
                            obeRequisicionConsulta.ImporteTotalLotes = datard.GetDecimal(ImporteTotalLotes); ;
                            obeRequisicionConsulta.Observaciones = datard.GetString(Observaciones);
                            obeRequisicionConsulta.ObservacionesRechazo = datard.GetString(ObservacionesRechazo);
                            obeRequisicionConsulta.TiempoRestante = datard.GetTimeSpan(TiempoRestante); ;
                            obeRequisicionConsulta.OrigenRecurso = datard.GetString(OrigenRecurso);
                            obeRequisicionConsulta.DescripcionOrigenRecurso = datard.GetString(DescripcionOrigenRecurso);
                            obeRequisicionConsulta.TipoRequisicion = datard.GetString(TipoRequisicion);
                            obeRequisicionConsulta.Tiempo = datard.GetString(Tiempo);
                            obeRequisicionConsulta.TipoSolicitud = datard.GetString(TipoSolicitud);
                            obeRequisicionConsulta.DescripcionTiposSolicitud = datard.GetString(DescripcionTiposSolicitud);
                            obeRequisicionConsulta.AbreviaturaTiposSolicitud = datard.GetString(AbreviaturaTiposSolicitud);
                            obeRequisicionConsulta.Estatus = datard.GetString(Estatus);
                            obeRequisicionConsulta.Dependencia = datard.GetString(Dependencia);
                            obeRequisicionConsulta.AbreviaturaDependencias = datard.GetString(AbreviaturaDependencias);
                            obeRequisicionConsulta.IdGobierno = datard.GetInt32(IdGobierno);
                            obeRequisicionConsulta.IdCapitulo = datard.GetInt32(IdCapitulo);
                            obeRequisicionConsulta.Capitulo = datard.GetString(Capitulo);
                            obeRequisicionConsulta.Partida = datard.GetString(Partida);
                            obeRequisicionConsulta.FormaAbastecimiento = datard.GetString(FormaAbastecimiento);
                            obeRequisicionConsulta.Ejercicio = datard.GetInt32(Ejercicio);
                            obeRequisicionConsulta.IdUsuarioRevisor = datard.GetInt32(IdUsuarioRevisor);
                            obeRequisicionConsulta.IdUsuarioRegistro = datard.GetInt32(IdUsuarioRegistro);
                            obeRequisicionConsulta.NumeroLicitacionT = datard.GetString(NumeroLicitacionT);
                            lbeRequisicionConsulta.Add(obeRequisicionConsulta);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionConsulta;
            }
        }
        public List<beRequisicionConsulta> listarRequisicionHistorial(SqlConnection Conexion, beGenerica oGenerico)
        {
            List<beRequisicionConsulta> lbeRequisicionConsulta = new List<beRequisicionConsulta>();
            string sp = "Proc_Requisiciones_Traer_HistorialPerfilEstatus";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = oGenerico.entero;
            cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = oGenerico.entero2;
            
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int IdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int IdRequisicionOrigen = datard.GetOrdinal("IdRequisicionOrigen");
                        int IdDependencia = datard.GetOrdinal("IdDependencia");
                        int IdTipoRequisicion = datard.GetOrdinal("IdTipoRequisicion");
                        int IdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int IdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int IdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
                        int IdEstatus = datard.GetOrdinal("IdEstatus");
                        int IdEstatusRequisicion = datard.GetOrdinal("IdEstatusRequisicion");
                        int NumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int IdTiempo = datard.GetOrdinal("IdTiempo");
                        int IdFormaAbastecimiento = datard.GetOrdinal("IdFormaAbastecimiento");
                        int IdPartida = datard.GetOrdinal("IdPartida");
                        int IdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int FechaRequisicion = datard.GetOrdinal("FechaRequisicion");
                        int RequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int ConsecutivoRequisicion = datard.GetOrdinal("ConsecutivoRequisicion");
                        int NumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
                        int NumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
                        int MontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int MontoAproximado = datard.GetOrdinal("MontoAproximado");
                        int CantidadLotes = datard.GetOrdinal("CantidadLotes");
                        int ImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
                        int Observaciones = datard.GetOrdinal("Observaciones");
                        int ObservacionesRechazo = datard.GetOrdinal("ObservacionesRechazo");
                        int TiempoRestante = datard.GetOrdinal("TiempoRestante");
                        int OrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int DescripcionOrigenRecurso = datard.GetOrdinal("DescripcionOrigenRecurso");
                        int TipoRequisicion = datard.GetOrdinal("TipoRequisicion");
                        int Tiempo = datard.GetOrdinal("Tiempo");
                        int TipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int DescripcionTiposSolicitud = datard.GetOrdinal("DescripcionTiposSolicitud");
                        int AbreviaturaTiposSolicitud = datard.GetOrdinal("AbreviaturaTiposSolicitud");
                        int Estatus = datard.GetOrdinal("Estatus");
                        int Dependencia = datard.GetOrdinal("Dependencia");
                        int AbreviaturaDependencias = datard.GetOrdinal("AbreviaturaDependencias");
                        int IdGobierno = datard.GetOrdinal("IdGobierno");
                        int IdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int Capitulo = datard.GetOrdinal("Capitulo");
                        int Partida = datard.GetOrdinal("Partida");
                        int FormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int Ejercicio = datard.GetOrdinal("Ejercicio");
                        int IdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
                        int IdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int NumeroLicitacionT = datard.GetOrdinal("NumeroLicitacionT");
                        int ColorTiempoRestante = datard.GetOrdinal("ColorTiempoRestante");
                        while (datard.Read())
                        {
                            beRequisicionConsulta obeRequisicionConsulta = new beRequisicionConsulta();
                            obeRequisicionConsulta.IdRequisicion = datard.GetInt32(IdRequisicion);
                            obeRequisicionConsulta.IdRequisicionOrigen = datard.GetInt32(IdRequisicionOrigen);
                            obeRequisicionConsulta.IdDependencia = datard.GetInt32(IdDependencia);
                            obeRequisicionConsulta.IdTipoRequisicion = datard.GetInt32(IdTipoRequisicion);
                            obeRequisicionConsulta.IdTipoSolicitud = datard.GetInt32(IdTipoSolicitud);
                            obeRequisicionConsulta.IdOrigenRecurso = datard.GetInt32(IdOrigenRecurso);
                            obeRequisicionConsulta.IdOrigenRecursoAutorizado = datard.GetInt32(IdOrigenRecursoAutorizado);
                            obeRequisicionConsulta.IdEstatus = datard.GetInt32(IdEstatus);
                            obeRequisicionConsulta.IdEstatusRequisicion = datard.GetInt32(IdEstatusRequisicion);
                            obeRequisicionConsulta.NumeroLicitacion = datard.GetInt32(NumeroLicitacion);
                            obeRequisicionConsulta.IdTiempo = datard.GetInt32(IdTiempo);
                            obeRequisicionConsulta.IdFormaAbastecimiento = datard.GetInt32(IdFormaAbastecimiento);
                            obeRequisicionConsulta.IdPartida = datard.GetInt32(IdPartida);
                            obeRequisicionConsulta.IdEjercicioFiscal = datard.GetInt32(IdEjercicioFiscal);
                            obeRequisicionConsulta.FechaRequisicion = datard.GetDateTime(FechaRequisicion);
                            obeRequisicionConsulta.RequisicionFolio = datard.GetString(RequisicionFolio);
                            obeRequisicionConsulta.ConsecutivoRequisicion = datard.GetInt32(ConsecutivoRequisicion);
                            obeRequisicionConsulta.NumeroOficioSolicitud = datard.GetString(NumeroOficioSolicitud);
                            obeRequisicionConsulta.NumeroOficioSolicitud = datard.GetString(NumeroOficioSolicitud);
                            obeRequisicionConsulta.NumeroOficioCertificacion = datard.GetString(NumeroOficioCertificacion);
                            obeRequisicionConsulta.MontoAproximadoAutorizado = datard.GetDecimal(MontoAproximadoAutorizado);
                            obeRequisicionConsulta.MontoAproximado = datard.GetDecimal(MontoAproximado);
                            obeRequisicionConsulta.CantidadLotes = datard.GetInt32(CantidadLotes); ;
                            obeRequisicionConsulta.ImporteTotalLotes = datard.GetDecimal(ImporteTotalLotes); ;
                            obeRequisicionConsulta.Observaciones = datard.GetString(Observaciones);
                            obeRequisicionConsulta.ObservacionesRechazo = datard.GetString(ObservacionesRechazo);
                            obeRequisicionConsulta.TiempoRestante = datard.GetTimeSpan(TiempoRestante); ;
                            obeRequisicionConsulta.OrigenRecurso = datard.GetString(OrigenRecurso);
                            obeRequisicionConsulta.DescripcionOrigenRecurso = datard.GetString(DescripcionOrigenRecurso);
                            obeRequisicionConsulta.TipoRequisicion = datard.GetString(TipoRequisicion);
                            obeRequisicionConsulta.Tiempo = datard.GetString(Tiempo);
                            obeRequisicionConsulta.TipoSolicitud = datard.GetString(TipoSolicitud);
                            obeRequisicionConsulta.DescripcionTiposSolicitud = datard.GetString(DescripcionTiposSolicitud);
                            obeRequisicionConsulta.AbreviaturaTiposSolicitud = datard.GetString(AbreviaturaTiposSolicitud);
                            obeRequisicionConsulta.Estatus = datard.GetString(Estatus);
                            obeRequisicionConsulta.Dependencia = datard.GetString(Dependencia);
                            obeRequisicionConsulta.AbreviaturaDependencias = datard.GetString(AbreviaturaDependencias);
                            obeRequisicionConsulta.IdGobierno = datard.GetInt32(IdGobierno);
                            obeRequisicionConsulta.IdCapitulo = datard.GetInt32(IdCapitulo);
                            obeRequisicionConsulta.Capitulo = datard.GetString(Capitulo);
                            obeRequisicionConsulta.Partida = datard.GetString(Partida);
                            obeRequisicionConsulta.FormaAbastecimiento = datard.GetString(FormaAbastecimiento);
                            obeRequisicionConsulta.Ejercicio = datard.GetInt32(Ejercicio);
                            obeRequisicionConsulta.IdUsuarioRevisor = datard.GetInt32(IdUsuarioRevisor);
                            obeRequisicionConsulta.IdUsuarioRegistro = datard.GetInt32(IdUsuarioRegistro);
                            obeRequisicionConsulta.NumeroLicitacionT = datard.GetString(NumeroLicitacionT);
                            obeRequisicionConsulta.ColorTiempoRestante = datard.GetString(ColorTiempoRestante);
                            lbeRequisicionConsulta.Add(obeRequisicionConsulta);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionConsulta;
            }
        }
    }
}
