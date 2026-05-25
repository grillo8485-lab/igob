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
        public class daAdjudicacionConsulta
        {
            public List< beAdjudicacionConsulta > listarAdjudicacionConsulta(SqlConnection Conexion, beGenerica oGenerico)
            {
                List<beAdjudicacionConsulta> lbeAdjudicacionConsulta = new List<beAdjudicacionConsulta>();
                string sp = "Proc_Adjudicaciones_Traer_PerfilAdjudicacionEstatus";
                SqlCommand cmd = new SqlCommand(sp, Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = oGenerico.entero;
                cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = oGenerico.entero2;
                cmd.Parameters.Add("@Lista", SqlDbType.Int).Value = oGenerico.entero3;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    try
                    {
                        if (datard != null)
                        {
                            int IdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                            int IdDependencia = datard.GetOrdinal("IdDependencia");
                            int IdTipoAdjudicacion = datard.GetOrdinal("IdTipoAdjudicacion");
                            int IdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                            int IdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                            int IdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
                            int IdEstatus = datard.GetOrdinal("IdEstatus");
                            int IdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
                            int IdPartida = datard.GetOrdinal("IdPartida");
                            int IdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                            int IdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                            int FechaAdjudicacion = datard.GetOrdinal("FechaAdjudicacion");
                            int AdjudicacionFolio = datard.GetOrdinal("AdjudicacionFolio");
                            int ConsecutivoAdjudicacion = datard.GetOrdinal("ConsecutivoAdjudicacion");
                            int NumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
                            int NumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
                            int MontoAproximado = datard.GetOrdinal("MontoAproximado");
                            int MontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                            int CantidadLotes = datard.GetOrdinal("CantidadLotes");
                            int ImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
                            int Observaciones = datard.GetOrdinal("Observaciones");
                            int Justificacion = datard.GetOrdinal("Justificacion");
                            int SaldoPartida = datard.GetOrdinal("SaldoPartida");
                            int MontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                            int IdUsuarioAsignante = datard.GetOrdinal("IdUsuarioAsignante");
                            int Acepta2daLicitacion = datard.GetOrdinal("Acepta2daLicitacion");
                            int IdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
                            int FechaAsignaRevisor = datard.GetOrdinal("FechaAsignaRevisor");
                            int FechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                            int Economia = datard.GetOrdinal("Economia");
                            int Ejercido = datard.GetOrdinal("Ejercido");
                            int OrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                            int DescripcionOrigenRecurso = datard.GetOrdinal("DescripcionOrigenRecurso");
                            int TipoAdjudicacion = datard.GetOrdinal("TipoAdjudicacion");
                            int TipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                            int DescripcionTiposSolicitud = datard.GetOrdinal("DescripcionTiposSolicitud");
                            int AbreviaturaTiposSolicitud = datard.GetOrdinal("AbreviaturaTiposSolicitud");
                            int Estatus = datard.GetOrdinal("EstatusAdjudicacion");
                            int Dependencia = datard.GetOrdinal("Dependencia");
                            int AbreviaturaDependencias = datard.GetOrdinal("AbreviaturaDependencias");
                            int IdGobierno = datard.GetOrdinal("IdGobierno");
                            int IdCapitulo = datard.GetOrdinal("IdCapitulo");                            
                            int Partida = datard.GetOrdinal("Partida");
                            int Capitulo = datard.GetOrdinal("Capitulo");
                            int Ejercicio = datard.GetOrdinal("Ejercicio");

                            while (datard.Read())
                            {
                                beAdjudicacionConsulta obeAdjudicacionConsulta = new beAdjudicacionConsulta();
                                obeAdjudicacionConsulta.IdAdjudicacion = datard.GetInt32(IdAdjudicacion);
                                obeAdjudicacionConsulta.IdDependencia = datard.GetInt32(IdDependencia);
                                obeAdjudicacionConsulta.IdTipoAdjudicacion = datard.GetInt32(IdTipoAdjudicacion);
                                obeAdjudicacionConsulta.IdTipoSolicitud = datard.GetInt32(IdTipoSolicitud);
                                obeAdjudicacionConsulta.IdOrigenRecurso = datard.GetInt32(IdOrigenRecurso);
                                obeAdjudicacionConsulta.IdOrigenRecursoAutorizado = datard.GetInt32(IdOrigenRecursoAutorizado);
                                obeAdjudicacionConsulta.IdEstatus = datard.GetInt32(IdEstatus);
                                obeAdjudicacionConsulta.IdEstatusAdjudicacion = datard.GetInt32(IdEstatusAdjudicacion);
                                obeAdjudicacionConsulta.IdPartida = datard.GetInt32(IdPartida);
                                obeAdjudicacionConsulta.IdEjercicioFiscal = datard.GetInt32(IdEjercicioFiscal);
                                obeAdjudicacionConsulta.IdPresupuestoPartida = datard.GetInt32(IdPresupuestoPartida);
                                obeAdjudicacionConsulta.FechaAdjudicacion = datard.GetDateTime(FechaAdjudicacion);
                                obeAdjudicacionConsulta.AdjudicacionFolio = datard.GetString(AdjudicacionFolio);
                                obeAdjudicacionConsulta.ConsecutivoAdjudicacion = datard.GetInt32(ConsecutivoAdjudicacion);
                                obeAdjudicacionConsulta.NumeroOficioSolicitud = datard.GetString(NumeroOficioSolicitud);
                                obeAdjudicacionConsulta.NumeroOficioCertificacion = datard.GetString(NumeroOficioCertificacion);
                                obeAdjudicacionConsulta.MontoAproximado = datard.GetDecimal(MontoAproximado);
                                obeAdjudicacionConsulta.MontoAproximadoAutorizado = datard.GetDecimal(MontoAproximadoAutorizado);
                                obeAdjudicacionConsulta.CantidadLotes = datard.GetInt32(CantidadLotes);
                                obeAdjudicacionConsulta.ImporteTotalLotes = datard.GetDecimal(ImporteTotalLotes);
                                obeAdjudicacionConsulta.Observaciones = datard.GetString(Observaciones);
                                obeAdjudicacionConsulta.Justificacion = datard.GetString(Justificacion);
                                obeAdjudicacionConsulta.SaldoPartida = datard.GetDecimal(SaldoPartida);
                                obeAdjudicacionConsulta.MontoPresupuestado = datard.GetDecimal(MontoPresupuestado);
                                obeAdjudicacionConsulta.IdUsuarioAsignante = datard.GetInt32(IdUsuarioAsignante);
                                obeAdjudicacionConsulta.Acepta2daLicitacion = datard.GetInt32(Acepta2daLicitacion);
                                obeAdjudicacionConsulta.IdUsuarioRevisor = datard.GetInt32(IdUsuarioRevisor);
                                obeAdjudicacionConsulta.FechaAsignaRevisor = datard.GetDateTime(FechaAsignaRevisor);
                                obeAdjudicacionConsulta.FechaAutorizacion = datard.GetDateTime(FechaAutorizacion);
                                obeAdjudicacionConsulta.Economia = datard.GetDecimal(Economia);
                                obeAdjudicacionConsulta.Ejercido = datard.GetDecimal(Ejercido);
                                obeAdjudicacionConsulta.OrigenRecurso = datard.GetString(OrigenRecurso);
                                obeAdjudicacionConsulta.DescripcionOrigenRecurso = datard.GetString(DescripcionOrigenRecurso);
                                obeAdjudicacionConsulta.TipoAdjudicacion = datard.GetString(TipoAdjudicacion);
                                obeAdjudicacionConsulta.TipoSolicitud = datard.GetString(TipoSolicitud);
                                obeAdjudicacionConsulta.DescripcionTiposSolicitud = datard.GetString(DescripcionTiposSolicitud);
                                obeAdjudicacionConsulta.AbreviaturaTiposSolicitud = datard.GetString(AbreviaturaTiposSolicitud);
                                obeAdjudicacionConsulta.Estatus = datard.GetString(Estatus);
                                obeAdjudicacionConsulta.Dependencia = datard.GetString(Dependencia);
                                obeAdjudicacionConsulta.AbreviaturaDependencias = datard.GetString(AbreviaturaDependencias);
                                obeAdjudicacionConsulta.IdGobierno = datard.GetInt32(IdGobierno);
                                obeAdjudicacionConsulta.IdCapitulo = datard.GetInt32(IdCapitulo);
                                obeAdjudicacionConsulta.Partida = datard.GetString(Partida);
                                obeAdjudicacionConsulta.Capitulo = datard.GetString(Capitulo);
                                obeAdjudicacionConsulta.Ejercicio = datard.GetInt32(Ejercicio);
                                lbeAdjudicacionConsulta.Add(obeAdjudicacionConsulta);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return lbeAdjudicacionConsulta;
                }
            }

        public List<beAdjudicacionConsulta> listarAdjudicacionConsultaProveedores(SqlConnection Conexion, int IdProveedor, int pIdTipoAdjudicacion)
        {
            List<beAdjudicacionConsulta> lbeAdjudicacionConsulta = new List<beAdjudicacionConsulta>();
            string sp = "Proc_AdjudicacionesProveedor_x_IdProveedor";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor;
            cmd.Parameters.Add("@IdTipoAdjudicacion", SqlDbType.Int).Value = pIdTipoAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int IdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int IdDependencia = datard.GetOrdinal("IdDependencia");
                        int IdTipoAdjudicacion = datard.GetOrdinal("IdTipoAdjudicacion");
                        int IdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int IdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int IdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
                        int IdEstatus = datard.GetOrdinal("IdEstatus");
                        int IdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
                        int IdPartida = datard.GetOrdinal("IdPartida");
                        int IdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int IdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        int FechaAdjudicacion = datard.GetOrdinal("FechaAdjudicacion");
                        int AdjudicacionFolio = datard.GetOrdinal("AdjudicacionFolio");
                        int ConsecutivoAdjudicacion = datard.GetOrdinal("ConsecutivoAdjudicacion");
                        int NumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
                        int NumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
                        int MontoAproximado = datard.GetOrdinal("MontoAproximado");
                        int MontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int CantidadLotes = datard.GetOrdinal("CantidadLotes");
                        int ImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
                        int Observaciones = datard.GetOrdinal("Observaciones");
                        int Justificacion = datard.GetOrdinal("Justificacion");
                        int SaldoPartida = datard.GetOrdinal("SaldoPartida");
                        int MontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                        int IdUsuarioAsignante = datard.GetOrdinal("IdUsuarioAsignante");
                        int Acepta2daLicitacion = datard.GetOrdinal("Acepta2daLicitacion");
                        int IdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
                        int FechaAsignaRevisor = datard.GetOrdinal("FechaAsignaRevisor");
                        int FechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int Economia = datard.GetOrdinal("Economia");
                        int Ejercido = datard.GetOrdinal("Ejercido");
                        int OrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int DescripcionOrigenRecurso = datard.GetOrdinal("DescripcionOrigenRecurso");
                        int TipoAdjudicacion = datard.GetOrdinal("TipoAdjudicacion");
                        int TipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int DescripcionTiposSolicitud = datard.GetOrdinal("DescripcionTiposSolicitud");
                        int AbreviaturaTiposSolicitud = datard.GetOrdinal("AbreviaturaTiposSolicitud");
                        int Estatus = datard.GetOrdinal("EstatusAdjudicacion");
                        int Dependencia = datard.GetOrdinal("Dependencia");
                        int AbreviaturaDependencias = datard.GetOrdinal("AbreviaturaDependencias");
                        int IdGobierno = datard.GetOrdinal("IdGobierno");
                        int IdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int Partida = datard.GetOrdinal("Partida");
                        int Capitulo = datard.GetOrdinal("Capitulo");
                        int Ejercicio = datard.GetOrdinal("Ejercicio");
                        int IdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
                        int IdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");

                        while (datard.Read())
                        {
                            beAdjudicacionConsulta obeAdjudicacionConsulta = new beAdjudicacionConsulta();
                            obeAdjudicacionConsulta.IdAdjudicacion = datard.GetInt32(IdAdjudicacion);
                            obeAdjudicacionConsulta.IdDependencia = datard.GetInt32(IdDependencia);
                            obeAdjudicacionConsulta.IdTipoAdjudicacion = datard.GetInt32(IdTipoAdjudicacion);
                            obeAdjudicacionConsulta.IdTipoSolicitud = datard.GetInt32(IdTipoSolicitud);
                            obeAdjudicacionConsulta.IdOrigenRecurso = datard.GetInt32(IdOrigenRecurso);
                            obeAdjudicacionConsulta.IdOrigenRecursoAutorizado = datard.GetInt32(IdOrigenRecursoAutorizado);
                            obeAdjudicacionConsulta.IdEstatus = datard.GetInt32(IdEstatus);
                            obeAdjudicacionConsulta.IdEstatusAdjudicacion = datard.GetInt32(IdEstatusAdjudicacion);
                            obeAdjudicacionConsulta.IdPartida = datard.GetInt32(IdPartida);
                            obeAdjudicacionConsulta.IdEjercicioFiscal = datard.GetInt32(IdEjercicioFiscal);
                            obeAdjudicacionConsulta.IdPresupuestoPartida = datard.GetInt32(IdPresupuestoPartida);
                            obeAdjudicacionConsulta.FechaAdjudicacion = datard.GetDateTime(FechaAdjudicacion);
                            obeAdjudicacionConsulta.AdjudicacionFolio = datard.GetString(AdjudicacionFolio);
                            obeAdjudicacionConsulta.ConsecutivoAdjudicacion = datard.GetInt32(ConsecutivoAdjudicacion);
                            obeAdjudicacionConsulta.NumeroOficioSolicitud = datard.GetString(NumeroOficioSolicitud);
                            obeAdjudicacionConsulta.NumeroOficioCertificacion = datard.GetString(NumeroOficioCertificacion);
                            obeAdjudicacionConsulta.MontoAproximado = datard.GetDecimal(MontoAproximado);
                            obeAdjudicacionConsulta.MontoAproximadoAutorizado = datard.GetDecimal(MontoAproximadoAutorizado);
                            obeAdjudicacionConsulta.CantidadLotes = datard.GetInt32(CantidadLotes);
                            obeAdjudicacionConsulta.ImporteTotalLotes = datard.GetDecimal(ImporteTotalLotes);
                            obeAdjudicacionConsulta.Observaciones = datard.GetString(Observaciones);
                            obeAdjudicacionConsulta.Justificacion = datard.GetString(Justificacion);
                            obeAdjudicacionConsulta.SaldoPartida = datard.GetDecimal(SaldoPartida);
                            obeAdjudicacionConsulta.MontoPresupuestado = datard.GetDecimal(MontoPresupuestado);
                            obeAdjudicacionConsulta.IdUsuarioAsignante = datard.GetInt32(IdUsuarioAsignante);
                            obeAdjudicacionConsulta.Acepta2daLicitacion = datard.GetInt32(Acepta2daLicitacion);
                            obeAdjudicacionConsulta.IdUsuarioRevisor = datard.GetInt32(IdUsuarioRevisor);
                            obeAdjudicacionConsulta.FechaAsignaRevisor = datard.GetDateTime(FechaAsignaRevisor);
                            obeAdjudicacionConsulta.FechaAutorizacion = datard.GetDateTime(FechaAutorizacion);
                            obeAdjudicacionConsulta.Economia = datard.GetDecimal(Economia);
                            obeAdjudicacionConsulta.Ejercido = datard.GetDecimal(Ejercido);
                            obeAdjudicacionConsulta.OrigenRecurso = datard.GetString(OrigenRecurso);
                            obeAdjudicacionConsulta.DescripcionOrigenRecurso = datard.GetString(DescripcionOrigenRecurso);
                            obeAdjudicacionConsulta.TipoAdjudicacion = datard.GetString(TipoAdjudicacion);
                            obeAdjudicacionConsulta.TipoSolicitud = datard.GetString(TipoSolicitud);
                            obeAdjudicacionConsulta.DescripcionTiposSolicitud = datard.GetString(DescripcionTiposSolicitud);
                            obeAdjudicacionConsulta.AbreviaturaTiposSolicitud = datard.GetString(AbreviaturaTiposSolicitud);
                            obeAdjudicacionConsulta.Estatus = datard.GetString(Estatus);
                            obeAdjudicacionConsulta.Dependencia = datard.GetString(Dependencia);
                            obeAdjudicacionConsulta.AbreviaturaDependencias = datard.GetString(AbreviaturaDependencias);
                            obeAdjudicacionConsulta.IdGobierno = datard.GetInt32(IdGobierno);
                            obeAdjudicacionConsulta.IdCapitulo = datard.GetInt32(IdCapitulo);
                            obeAdjudicacionConsulta.Partida = datard.GetString(Partida);
                            obeAdjudicacionConsulta.Capitulo = datard.GetString(Capitulo);
                            obeAdjudicacionConsulta.Ejercicio = datard.GetInt32(Ejercicio);
                            obeAdjudicacionConsulta.IdEstatusEnvioPropuestaTecnica = datard.GetInt32(IdEstatusEnvioPropuestaTecnica);
                            obeAdjudicacionConsulta.IdEstatusEnvioPropuestaEconomica = datard.GetInt32(IdEstatusEnvioPropuestaEconomica);
                            
                            lbeAdjudicacionConsulta.Add(obeAdjudicacionConsulta);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionConsulta;
            }
        }

        public List<beAdjudicacionConsulta> ListarAdjudicacionPerfilAdjudicacionEstatusAutorizadas(SqlConnection Conexion, int pIdLista, int pIdPerfil, int pIdDependencia)
        {
            List<beAdjudicacionConsulta> lbeAdjudicacionConsulta = new List<beAdjudicacionConsulta>();
            string sp = "Proc_Adjudicaciones_Traer_PerfilAdjudicacionEstatusAutorizadas";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = pIdDependencia;
            cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = pIdPerfil;
            cmd.Parameters.Add("@Lista", SqlDbType.Int).Value = pIdLista;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int IdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int IdDependencia = datard.GetOrdinal("IdDependencia");
                        int IdTipoAdjudicacion = datard.GetOrdinal("IdTipoAdjudicacion");
                        int IdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int IdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int IdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
                        int IdEstatus = datard.GetOrdinal("IdEstatus");
                        int IdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
                        int IdPartida = datard.GetOrdinal("IdPartida");
                        int IdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int IdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        int FechaAdjudicacion = datard.GetOrdinal("FechaAdjudicacion");
                        int AdjudicacionFolio = datard.GetOrdinal("AdjudicacionFolio");
                        int ConsecutivoAdjudicacion = datard.GetOrdinal("ConsecutivoAdjudicacion");
                        int NumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
                        int NumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
                        int MontoAproximado = datard.GetOrdinal("MontoAproximado");
                        int MontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int CantidadLotes = datard.GetOrdinal("CantidadLotes");
                        int ImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
                        int Observaciones = datard.GetOrdinal("Observaciones");
                        int Justificacion = datard.GetOrdinal("Justificacion");
                        int SaldoPartida = datard.GetOrdinal("SaldoPartida");
                        int MontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                        int IdUsuarioAsignante = datard.GetOrdinal("IdUsuarioAsignante");
                        int Acepta2daLicitacion = datard.GetOrdinal("Acepta2daLicitacion");
                        int IdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
                        int FechaAsignaRevisor = datard.GetOrdinal("FechaAsignaRevisor");
                        int FechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int Economia = datard.GetOrdinal("Economia");
                        int Ejercido = datard.GetOrdinal("Ejercido");
                        int OrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int DescripcionOrigenRecurso = datard.GetOrdinal("DescripcionOrigenRecurso");
                        int TipoAdjudicacion = datard.GetOrdinal("TipoAdjudicacion");
                        int TipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int DescripcionTiposSolicitud = datard.GetOrdinal("DescripcionTiposSolicitud");
                        int AbreviaturaTiposSolicitud = datard.GetOrdinal("AbreviaturaTiposSolicitud");
                        int Estatus = datard.GetOrdinal("EstatusAdjudicacion");
                        int Dependencia = datard.GetOrdinal("Dependencia");
                        int AbreviaturaDependencias = datard.GetOrdinal("AbreviaturaDependencias");
                        int IdGobierno = datard.GetOrdinal("IdGobierno");
                        int IdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int Partida = datard.GetOrdinal("Partida");
                        int Capitulo = datard.GetOrdinal("Capitulo");
                        int Ejercicio = datard.GetOrdinal("Ejercicio");

                        while (datard.Read())
                        {
                            beAdjudicacionConsulta obeAdjudicacionConsulta = new beAdjudicacionConsulta();
                            obeAdjudicacionConsulta.IdAdjudicacion = datard.GetInt32(IdAdjudicacion);
                            obeAdjudicacionConsulta.IdDependencia = datard.GetInt32(IdDependencia);
                            obeAdjudicacionConsulta.IdTipoAdjudicacion = datard.GetInt32(IdTipoAdjudicacion);
                            obeAdjudicacionConsulta.IdTipoSolicitud = datard.GetInt32(IdTipoSolicitud);
                            obeAdjudicacionConsulta.IdOrigenRecurso = datard.GetInt32(IdOrigenRecurso);
                            obeAdjudicacionConsulta.IdOrigenRecursoAutorizado = datard.GetInt32(IdOrigenRecursoAutorizado);
                            obeAdjudicacionConsulta.IdEstatus = datard.GetInt32(IdEstatus);
                            obeAdjudicacionConsulta.IdEstatusAdjudicacion = datard.GetInt32(IdEstatusAdjudicacion);
                            obeAdjudicacionConsulta.IdPartida = datard.GetInt32(IdPartida);
                            obeAdjudicacionConsulta.IdEjercicioFiscal = datard.GetInt32(IdEjercicioFiscal);
                            obeAdjudicacionConsulta.IdPresupuestoPartida = datard.GetInt32(IdPresupuestoPartida);
                            obeAdjudicacionConsulta.FechaAdjudicacion = datard.GetDateTime(FechaAdjudicacion);
                            obeAdjudicacionConsulta.AdjudicacionFolio = datard.GetString(AdjudicacionFolio);
                            obeAdjudicacionConsulta.ConsecutivoAdjudicacion = datard.GetInt32(ConsecutivoAdjudicacion);
                            obeAdjudicacionConsulta.NumeroOficioSolicitud = datard.GetString(NumeroOficioSolicitud);
                            obeAdjudicacionConsulta.NumeroOficioCertificacion = datard.GetString(NumeroOficioCertificacion);
                            obeAdjudicacionConsulta.MontoAproximado = datard.GetDecimal(MontoAproximado);
                            obeAdjudicacionConsulta.MontoAproximadoAutorizado = datard.GetDecimal(MontoAproximadoAutorizado);
                            obeAdjudicacionConsulta.CantidadLotes = datard.GetInt32(CantidadLotes);
                            obeAdjudicacionConsulta.ImporteTotalLotes = datard.GetDecimal(ImporteTotalLotes);
                            obeAdjudicacionConsulta.Observaciones = datard.GetString(Observaciones);
                            obeAdjudicacionConsulta.Justificacion = datard.GetString(Justificacion);
                            obeAdjudicacionConsulta.SaldoPartida = datard.GetDecimal(SaldoPartida);
                            obeAdjudicacionConsulta.MontoPresupuestado = datard.GetDecimal(MontoPresupuestado);
                            obeAdjudicacionConsulta.IdUsuarioAsignante = datard.GetInt32(IdUsuarioAsignante);
                            obeAdjudicacionConsulta.Acepta2daLicitacion = datard.GetInt32(Acepta2daLicitacion);
                            obeAdjudicacionConsulta.IdUsuarioRevisor = datard.GetInt32(IdUsuarioRevisor);
                            obeAdjudicacionConsulta.FechaAsignaRevisor = datard.GetDateTime(FechaAsignaRevisor);
                            obeAdjudicacionConsulta.FechaAutorizacion = datard.GetDateTime(FechaAutorizacion);
                            obeAdjudicacionConsulta.Economia = datard.GetDecimal(Economia);
                            obeAdjudicacionConsulta.Ejercido = datard.GetDecimal(Ejercido);
                            obeAdjudicacionConsulta.OrigenRecurso = datard.GetString(OrigenRecurso);
                            obeAdjudicacionConsulta.DescripcionOrigenRecurso = datard.GetString(DescripcionOrigenRecurso);
                            obeAdjudicacionConsulta.TipoAdjudicacion = datard.GetString(TipoAdjudicacion);
                            obeAdjudicacionConsulta.TipoSolicitud = datard.GetString(TipoSolicitud);
                            obeAdjudicacionConsulta.DescripcionTiposSolicitud = datard.GetString(DescripcionTiposSolicitud);
                            obeAdjudicacionConsulta.AbreviaturaTiposSolicitud = datard.GetString(AbreviaturaTiposSolicitud);
                            obeAdjudicacionConsulta.Estatus = datard.GetString(Estatus);
                            obeAdjudicacionConsulta.Dependencia = datard.GetString(Dependencia);
                            obeAdjudicacionConsulta.AbreviaturaDependencias = datard.GetString(AbreviaturaDependencias);
                            obeAdjudicacionConsulta.IdGobierno = datard.GetInt32(IdGobierno);
                            obeAdjudicacionConsulta.IdCapitulo = datard.GetInt32(IdCapitulo);
                            obeAdjudicacionConsulta.Partida = datard.GetString(Partida);
                            obeAdjudicacionConsulta.Capitulo = datard.GetString(Capitulo);
                            obeAdjudicacionConsulta.Ejercicio = datard.GetInt32(Ejercicio);
                            lbeAdjudicacionConsulta.Add(obeAdjudicacionConsulta);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionConsulta;
            }
        }
    }

}
