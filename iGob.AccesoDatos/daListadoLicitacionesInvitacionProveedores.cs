using iGob.Entidades;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.AccesoDatos
{
    public class daListadoLicitacionesInvitacionProveedores
    {
        public List<beListadoLicitacionesInvitacionProveedores> ListadoGenerarLicitacion(SqlConnection Conexion, int IdProveedor)
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoLicitacionesInvitacionProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            string sp = "Proc_LicitacionesInvitaciones_x_IdProveedor";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdInvitacion = datard.GetOrdinal("IdInvitacion");
                        int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posAceptacion = datard.GetOrdinal("Aceptacion");
                        int posFechaAceptacion = datard.GetOrdinal("FechaAceptacion");
                        int posUrlRecibo = datard.GetOrdinal("UrlRecibo");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdEstatusPago = datard.GetOrdinal("IdEstatusPago");
                        int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
                        int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
                        int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
                        int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
                        int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
                        int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
                        int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
                        int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
                        int posFechaFallo = datard.GetOrdinal("FechaFallo");
                        int posHoraFallo = datard.GetOrdinal("HoraFallo");
                        int posFolioOficial = datard.GetOrdinal("FolioOficial");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posPartidas = datard.GetOrdinal("Partidas");
                        int posDependencias = datard.GetOrdinal("Dependencias");


                        while (datard.Read())
                        {
                            beListadoLicitacionesInvitacionProveedores ObeListadoInvitacionProveedores = new beListadoLicitacionesInvitacionProveedores();
                            ObeListadoInvitacionProveedores.IdInvitacion = datard.GetInt32(posIdInvitacion);
                            ObeListadoInvitacionProveedores.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            ObeListadoInvitacionProveedores.IdProveedor = datard.GetInt32(posIdProveedor);
                            ObeListadoInvitacionProveedores.Aceptacion = datard[posAceptacion] == DBNull.Value ? false : datard.GetBoolean(posAceptacion);
                            ObeListadoInvitacionProveedores.FechaAceptacion = datard[posFechaAceptacion] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaAceptacion);
                            ObeListadoInvitacionProveedores.UrlRecibo = datard[posUrlRecibo] == DBNull.Value ? string.Empty : datard.GetString(posUrlRecibo);
                            ObeListadoInvitacionProveedores.Observaciones = datard[posObservaciones] == DBNull.Value ? string.Empty : datard.GetString(posObservaciones);
                            ObeListadoInvitacionProveedores.IdEstatusPago = datard.GetInt32(posIdEstatusPago);
                            ObeListadoInvitacionProveedores.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            ObeListadoInvitacionProveedores.HoraAutorizacion = datard.GetTimeSpan(posHoraAutorizacion);
                            ObeListadoInvitacionProveedores.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
                            ObeListadoInvitacionProveedores.FechaDisposicionBases = datard.GetDateTime(posFechaDisposicionBases);
                            ObeListadoInvitacionProveedores.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
                            ObeListadoInvitacionProveedores.FechaLimiteRespuestas = datard.GetDateTime(posFechaLimiteRespuestas);
                            ObeListadoInvitacionProveedores.FechaHoraAclaracionDudas = datard.GetDateTime(posFechaHoraAclaracionDudas);
                            ObeListadoInvitacionProveedores.FechaEnvioPropuestasTecEco = datard.GetDateTime(posFechaEnvioPropuestasTecEco);
                            ObeListadoInvitacionProveedores.FechaLimiteDictamen = datard.GetDateTime(posFechaLimiteDictamen);
                            ObeListadoInvitacionProveedores.FechaFallo = datard.GetDateTime(posFechaFallo);
                            ObeListadoInvitacionProveedores.HoraFallo = datard.GetTimeSpan(posHoraFallo);
                            ObeListadoInvitacionProveedores.FolioOficial = datard[posFolioOficial] == DBNull.Value ? string.Empty : datard.GetString(posFolioOficial);
                            ObeListadoInvitacionProveedores.Tiempo = datard.GetString(posTiempo);
                            ObeListadoInvitacionProveedores.Ejercicio = datard.GetInt32(posEjercicio);
                            ObeListadoInvitacionProveedores.Partidas = datard.GetString(posPartidas);
                            ObeListadoInvitacionProveedores.Dependencias = datard.GetString(posDependencias);
                            listadoLicitacionesInvitacionProveedores.Add(ObeListadoInvitacionProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoLicitacionesInvitacionProveedores;
            }
        }
        public List<beListadoLicitacionesInvitacionProveedores> ListadoLicitacionesAceptadasProveedor(SqlConnection Conexion, int IdProveedor)
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoLicitacionesInvitacionProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            string sp = "Proc_LicitacionesInvitaciones_x_IdProveedorAceptadas";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdInvitacion = datard.GetOrdinal("IdInvitacion");
                        int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posAceptacion = datard.GetOrdinal("Aceptacion");
                        int posFechaAceptacion = datard.GetOrdinal("FechaAceptacion");
                        int posUrlRecibo = datard.GetOrdinal("UrlRecibo");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdEstatusPago = datard.GetOrdinal("IdEstatusPago");
                        int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
                        int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
                        int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
                        int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
                        int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
                        int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
                        int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
                        int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
                        int posFechaFallo = datard.GetOrdinal("FechaFallo");
                        int posHoraFallo = datard.GetOrdinal("HoraFallo");
                        int posFolioOficial = datard.GetOrdinal("FolioOficial");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posModalidadLicitacion = datard.GetOrdinal("ModalidadLicitacion");
                        int posLicitacion = datard.GetOrdinal("Licitacion");
                        int IdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
                        int IdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
                        int IdEstatusLicitacion = datard.GetOrdinal("IdEstatusLicitacion");
                        int EstatusLicitacion = datard.GetOrdinal("EstatusLicitacion");
                        int FolioNumero = datard.GetOrdinal("FolioNumero");
                        while (datard.Read())
                        {
                            beListadoLicitacionesInvitacionProveedores ObeListadoInvitacionProveedores = new beListadoLicitacionesInvitacionProveedores();
                            ObeListadoInvitacionProveedores.IdInvitacion = datard.GetInt32(posIdInvitacion);
                            ObeListadoInvitacionProveedores.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            ObeListadoInvitacionProveedores.IdProveedor = datard.GetInt32(posIdProveedor);
                            ObeListadoInvitacionProveedores.Aceptacion = datard[posAceptacion] == DBNull.Value ? false : datard.GetBoolean(posAceptacion);
                            ObeListadoInvitacionProveedores.FechaAceptacion = datard[posFechaAceptacion] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaAceptacion);
                            ObeListadoInvitacionProveedores.UrlRecibo = datard[posUrlRecibo] == DBNull.Value ? string.Empty : datard.GetString(posUrlRecibo);
                            ObeListadoInvitacionProveedores.Observaciones = datard[posObservaciones] == DBNull.Value ? string.Empty : datard.GetString(posObservaciones);
                            ObeListadoInvitacionProveedores.IdEstatusPago = datard.GetInt32(posIdEstatusPago);
                            ObeListadoInvitacionProveedores.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            ObeListadoInvitacionProveedores.HoraAutorizacion = datard.GetTimeSpan(posHoraAutorizacion);
                            ObeListadoInvitacionProveedores.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
                            ObeListadoInvitacionProveedores.FechaDisposicionBases = datard.GetDateTime(posFechaDisposicionBases);
                            ObeListadoInvitacionProveedores.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
                            ObeListadoInvitacionProveedores.FechaLimiteRespuestas = datard.GetDateTime(posFechaLimiteRespuestas);
                            ObeListadoInvitacionProveedores.FechaHoraAclaracionDudas = datard.GetDateTime(posFechaHoraAclaracionDudas);
                            ObeListadoInvitacionProveedores.FechaEnvioPropuestasTecEco = datard.GetDateTime(posFechaEnvioPropuestasTecEco);
                            ObeListadoInvitacionProveedores.FechaLimiteDictamen = datard.GetDateTime(posFechaLimiteDictamen);
                            ObeListadoInvitacionProveedores.FechaFallo = datard.GetDateTime(posFechaFallo);
                            ObeListadoInvitacionProveedores.HoraFallo = datard.GetTimeSpan(posHoraFallo);
                            ObeListadoInvitacionProveedores.FolioOficial = datard[posFolioOficial] == DBNull.Value ? string.Empty : datard.GetString(posFolioOficial);
                            ObeListadoInvitacionProveedores.Tiempo = datard.GetString(posTiempo);
                            ObeListadoInvitacionProveedores.Ejercicio = datard.GetInt32(posEjercicio);
                            ObeListadoInvitacionProveedores.ModalidadLicitacion = datard.GetString(posModalidadLicitacion);
                            ObeListadoInvitacionProveedores.Licitacion = datard.GetString(posLicitacion);
                            ObeListadoInvitacionProveedores.IdEstatusEnvioPropuestaEconomica = datard.GetInt32(IdEstatusEnvioPropuestaEconomica);
                            ObeListadoInvitacionProveedores.IdEstatusEnvioPropuestaTecnica = datard.GetInt32(IdEstatusEnvioPropuestaTecnica);
                            ObeListadoInvitacionProveedores.IdEstatusLicitacion = datard.GetInt32(IdEstatusLicitacion);
                            ObeListadoInvitacionProveedores.EstatusLicitacion = datard.GetString(EstatusLicitacion);
                            ObeListadoInvitacionProveedores.FolioNumero = datard.GetInt32(FolioNumero);

                            ObeListadoInvitacionProveedores.IsNUllPago = ObeListadoInvitacionProveedores.IdEstatusPago == 1 ? true : false;

                            if (ObeListadoInvitacionProveedores.FechaHoraAclaracionDudas > DateTime.Now)
                            {
                                ObeListadoInvitacionProveedores.IsNUllFechaJuntaAclaracionDudas = true;
                            }
                            //ObeListadoInvitacionProveedores.IsNUllFechaJuntaAclaracionDudas = false;
                            listadoLicitacionesInvitacionProveedores.Add(ObeListadoInvitacionProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoLicitacionesInvitacionProveedores;
            }
        }
        public List<beListadoLicitacionesInvitacionProveedores> Licitaciones_x_Revisor(SqlConnection Conexion, int pIdUsuario)
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoLicitacionesInvitacionProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            string sp = "Proc_Licitaciones_x_Revisor";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdUsurioRevisor", SqlDbType.Int).Value = pIdUsuario;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        //int posIdInvitacion = datard.GetOrdinal("IdInvitacion");
                        int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
                        //int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        //int posAceptacion = datard.GetOrdinal("Aceptacion");
                        //int posFechaAceptacion = datard.GetOrdinal("FechaAceptacion");
                        //int posUrlRecibo = datard.GetOrdinal("UrlRecibo");
                        //int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdEstatusLicitacion = datard.GetOrdinal("IdEstatusLicitacion");
                        int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
                        int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
                        int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
                        int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
                        int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
                        int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
                        int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
                        int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
                        int posFechaFallo = datard.GetOrdinal("FechaFallo");
                        int posHoraFallo = datard.GetOrdinal("HoraFallo");
                        int posFolioOficial = datard.GetOrdinal("FolioOficial");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posEstatus = datard.GetOrdinal("Estatus");
                        //int posDependencias = datard.GetOrdinal("Dependencias");
                        int posModalidadLicitacion = datard.GetOrdinal("ModalidadLicitacion");
                        int posLicitacion = datard.GetOrdinal("Licitacion");

                        while (datard.Read())
                        {
                            beListadoLicitacionesInvitacionProveedores ObeListadoInvitacionProveedores = new beListadoLicitacionesInvitacionProveedores();
                            //ObeListadoInvitacionProveedores.IdInvitacion = datard.GetInt32(posIdInvitacion);
                            ObeListadoInvitacionProveedores.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            //ObeListadoInvitacionProveedores.IdProveedor = datard.GetInt32(posIdProveedor);
                            //ObeListadoInvitacionProveedores.Aceptacion = datard[posAceptacion] == DBNull.Value ? false : datard.GetBoolean(posAceptacion);
                            //ObeListadoInvitacionProveedores.FechaAceptacion = datard[posFechaAceptacion] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaAceptacion);
                            //ObeListadoInvitacionProveedores.UrlRecibo = datard[posUrlRecibo] == DBNull.Value ? string.Empty : datard.GetString(posUrlRecibo);
                            //ObeListadoInvitacionProveedores.Observaciones = datard[posObservaciones] == DBNull.Value ? string.Empty : datard.GetString(posObservaciones);
                            //ObeListadoInvitacionProveedores.IdEstatusPago = datard.GetInt32(posIdEstatusPago);
                            ObeListadoInvitacionProveedores.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            ObeListadoInvitacionProveedores.HoraAutorizacion = datard.GetTimeSpan(posHoraAutorizacion);
                            ObeListadoInvitacionProveedores.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
                            ObeListadoInvitacionProveedores.FechaDisposicionBases = datard.GetDateTime(posFechaDisposicionBases);
                            ObeListadoInvitacionProveedores.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
                            ObeListadoInvitacionProveedores.FechaLimiteRespuestas = datard.GetDateTime(posFechaLimiteRespuestas);
                            ObeListadoInvitacionProveedores.FechaHoraAclaracionDudas = datard.GetDateTime(posFechaHoraAclaracionDudas);
                            ObeListadoInvitacionProveedores.FechaEnvioPropuestasTecEco = datard.GetDateTime(posFechaEnvioPropuestasTecEco);
                            ObeListadoInvitacionProveedores.FechaLimiteDictamen = datard.GetDateTime(posFechaLimiteDictamen);
                            ObeListadoInvitacionProveedores.FechaFallo = datard.GetDateTime(posFechaFallo);
                            ObeListadoInvitacionProveedores.HoraFallo = datard.GetTimeSpan(posHoraFallo);
                            ObeListadoInvitacionProveedores.FolioOficial = datard[posFolioOficial] == DBNull.Value ? string.Empty : datard.GetString(posFolioOficial);
                            ObeListadoInvitacionProveedores.Tiempo = datard.GetString(posTiempo);
                            ObeListadoInvitacionProveedores.Ejercicio = datard.GetInt32(posEjercicio);
                            //ObeListadoInvitacionProveedores.Partidas = datard.GetString(posPartidas);
                            ObeListadoInvitacionProveedores.IdEstatusLicitacion = datard.GetInt32(posIdEstatusLicitacion);
                            ObeListadoInvitacionProveedores.ModalidadLicitacion = datard.GetString(posModalidadLicitacion);
                            ObeListadoInvitacionProveedores.Licitacion = datard.GetString(posLicitacion);
                            ObeListadoInvitacionProveedores.Estatus = datard.GetString(posEstatus);
                            listadoLicitacionesInvitacionProveedores.Add(ObeListadoInvitacionProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoLicitacionesInvitacionProveedores;
            }
        }
        public List<beListadoLicitacionesInvitacionProveedores> Licitacion_Requisiciones_Revisor(SqlConnection Conexion, int pLisitacion)
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoLicitacionesInvitacionProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            string sp = "Proc_LicitacionesRecibosPagos_x_PendientesLicitacion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pLisitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdInvitacion = datard.GetOrdinal("IdInvitacion");
                        int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posFolioPago = datard.GetOrdinal("FolioPago");
                        int posFechaPago = datard.GetOrdinal("FechaPago");
                        int posUrlRecibo = datard.GetOrdinal("UrlRecibo");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdEstatusPago = datard.GetOrdinal("IdEstatusPago");
                        int posFechaValidoPago = datard.GetOrdinal("FechaValidaPago");
                        int posEstatus = datard.GetOrdinal("Estatus");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");

                        while (datard.Read())
                        {
                            beListadoLicitacionesInvitacionProveedores ObeListadoInvitacionProveedores = new beListadoLicitacionesInvitacionProveedores();
                            ObeListadoInvitacionProveedores.IdInvitacion = datard.GetInt32(posIdInvitacion);
                            ObeListadoInvitacionProveedores.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            ObeListadoInvitacionProveedores.IdProveedor = datard.GetInt32(posIdProveedor);
                            ObeListadoInvitacionProveedores.FolioPago = datard.GetString(posFolioPago);
                            ObeListadoInvitacionProveedores.FechaPago = datard[posFechaPago] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaPago);
                            ObeListadoInvitacionProveedores.UrlRecibo = datard[posUrlRecibo] == DBNull.Value ? string.Empty : datard.GetString(posUrlRecibo);
                            ObeListadoInvitacionProveedores.Observaciones = datard[posObservaciones] == DBNull.Value ? string.Empty : datard.GetString(posObservaciones);
                            ObeListadoInvitacionProveedores.IdEstatusPago = datard.GetInt32(posIdEstatusPago);
                            ObeListadoInvitacionProveedores.FechaValidoPago = datard.GetDateTime(posFechaValidoPago);
                            ObeListadoInvitacionProveedores.Estatus = datard.GetString(posEstatus);
                            ObeListadoInvitacionProveedores.RazonSocial = datard.GetString(posRazonSocial);
                            listadoLicitacionesInvitacionProveedores.Add(ObeListadoInvitacionProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoLicitacionesInvitacionProveedores;
            }
        }

        public List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion(SqlConnection Conexion, int IdInvitacion)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            string sp = "Proc_RequisicionesProveedoresInvitaciones_x_IdInvitacion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdInvitacion", SqlDbType.Int).Value = IdInvitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posNumeroLicitacionT = datard.GetOrdinal("NumeroLicitacionT");
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
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posClavePartida = datard.GetOrdinal("ClavePartida");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posClaveCapitulo = datard.GetOrdinal("ClaveCapitulo");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int IdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
                        int IdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");

                        while (datard.Read())
                        {
                            beListadoRequisicionLicitacion RequisicionLicitacion = new beListadoRequisicionLicitacion();

                            RequisicionLicitacion.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            RequisicionLicitacion.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            RequisicionLicitacion.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            RequisicionLicitacion.NumeroLicitacionT = datard[posNumeroLicitacionT]==DBNull.Value ? string.Empty : datard.GetString(posNumeroLicitacionT);
                            RequisicionLicitacion.IdTiempo = datard.GetInt32(posIdTiempo);
                            RequisicionLicitacion.IdFormaAbastecimiento = datard.GetInt32(posIdFormaAbastecimiento);
                            RequisicionLicitacion.IdPartida = datard.GetInt32(posIdPartida);
                            RequisicionLicitacion.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            RequisicionLicitacion.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            RequisicionLicitacion.FechaRequisicion = datard.GetDateTime(posFechaRequisicion);
                            RequisicionLicitacion.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            RequisicionLicitacion.ConsecutivoRequisicion = datard.GetInt32(posConsecutivoRequisicion);
                            RequisicionLicitacion.NumeroOficioSolicitud = datard.GetString(posNumeroOficioSolicitud);
                            RequisicionLicitacion.NumeroOficioCertificacion = datard.GetString(posNumeroOficioCertificacion);
                            RequisicionLicitacion.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            RequisicionLicitacion.ClavePartida = datard.GetString(posClavePartida);
                            RequisicionLicitacion.Partida = datard.GetString(posPartida);
                            RequisicionLicitacion.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            RequisicionLicitacion.ClaveCapitulo = datard.GetInt32(posClaveCapitulo);
                            RequisicionLicitacion.Capitulo = datard.GetString(posCapitulo);
                            RequisicionLicitacion.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            RequisicionLicitacion.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            RequisicionLicitacion.Tiempo = datard.GetString(posTiempo);
                            RequisicionLicitacion.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            RequisicionLicitacion.Ejercicio = datard.GetInt32(posEjercicio);
                            RequisicionLicitacion.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);

                            RequisicionLicitacion.IdEstatusEnvioPropuestaEconomica = datard.GetInt32(IdEstatusEnvioPropuestaEconomica);
                            RequisicionLicitacion.IdEstatusEnvioPropuestaTecnica = datard.GetInt32(IdEstatusEnvioPropuestaTecnica);

                            ListadoRequisicionLicitacion.Add(RequisicionLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        public List<beListadoLicitacionesInvitacionProveedores> Licitaciones_x_SolictanteDependencia(SqlConnection Conexion, int pIdDependencia)
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoLicitacionesInvitacionProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            string sp = "Proc_Licitaciones_x_PerfilSolicitanteDependencia";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = pIdDependencia;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
                        int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
                        int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
                        int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
                        int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
                        int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
                        int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
                        int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
                        int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
                        int posFechaFallo = datard.GetOrdinal("FechaFallo");
                        int posHoraFallo = datard.GetOrdinal("HoraFallo");
                        int posFolioOficial = datard.GetOrdinal("FolioOficial");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posEstatus = datard.GetOrdinal("Estatus");
                        int posIdEstatusLicitacion = datard.GetOrdinal("IdEstatusLicitacion");
                        int posModalidadLicitacion = datard.GetOrdinal("ModalidadLicitacion");
                        int posLicitacion = datard.GetOrdinal("Licitacion");
                        int posPagoRecepcionado = datard.GetOrdinal("PagoRecepcionado");
                        while (datard.Read())
                        {
                            beListadoLicitacionesInvitacionProveedores ObeListadoInvitacionProveedores = new beListadoLicitacionesInvitacionProveedores();
                            ObeListadoInvitacionProveedores.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            ObeListadoInvitacionProveedores.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            ObeListadoInvitacionProveedores.HoraAutorizacion = datard.GetTimeSpan(posHoraAutorizacion);
                            ObeListadoInvitacionProveedores.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
                            ObeListadoInvitacionProveedores.FechaDisposicionBases = datard.GetDateTime(posFechaDisposicionBases);
                            ObeListadoInvitacionProveedores.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
                            ObeListadoInvitacionProveedores.FechaLimiteRespuestas = datard.GetDateTime(posFechaLimiteRespuestas);
                            ObeListadoInvitacionProveedores.FechaHoraAclaracionDudas = datard.GetDateTime(posFechaHoraAclaracionDudas);
                            ObeListadoInvitacionProveedores.FechaEnvioPropuestasTecEco = datard.GetDateTime(posFechaEnvioPropuestasTecEco);
                            ObeListadoInvitacionProveedores.FechaLimiteDictamen = datard.GetDateTime(posFechaLimiteDictamen);
                            ObeListadoInvitacionProveedores.FechaFallo = datard.GetDateTime(posFechaFallo);
                            ObeListadoInvitacionProveedores.HoraFallo = datard.GetTimeSpan(posHoraFallo);
                            ObeListadoInvitacionProveedores.FolioOficial = datard[posFolioOficial] == DBNull.Value ? string.Empty : datard.GetString(posFolioOficial);
                            ObeListadoInvitacionProveedores.Tiempo = datard.GetString(posTiempo);
                            ObeListadoInvitacionProveedores.Ejercicio = datard.GetInt32(posEjercicio);
                            ObeListadoInvitacionProveedores.ModalidadLicitacion = datard.GetString(posModalidadLicitacion);
                            ObeListadoInvitacionProveedores.Licitacion = datard.GetString(posLicitacion);
                            ObeListadoInvitacionProveedores.Estatus = datard.GetString(posEstatus);
                            ObeListadoInvitacionProveedores.IdEstatusLicitacion = datard.GetInt32(posIdEstatusLicitacion);
                            ObeListadoInvitacionProveedores.PagoRecepcionado = datard.GetInt32(posPagoRecepcionado);
                            listadoLicitacionesInvitacionProveedores.Add(ObeListadoInvitacionProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoLicitacionesInvitacionProveedores;
            }
        }
        public List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacionSolictanteDependencia(SqlConnection Conexion, int pIdLicitacion, int pIdDependencia)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            string sp = "Proc_RequisicionesPreguntas_x_IdLicitacionDependencia";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = pIdDependencia;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posNumeroLicitacionT = datard.GetOrdinal("NumeroLicitacionT");
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
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posClavePartida = datard.GetOrdinal("ClavePartida");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posClaveCapitulo = datard.GetOrdinal("ClaveCapitulo");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");

                        while (datard.Read())
                        {
                            beListadoRequisicionLicitacion RequisicionLicitacion = new beListadoRequisicionLicitacion();

                            RequisicionLicitacion.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            RequisicionLicitacion.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            RequisicionLicitacion.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            RequisicionLicitacion.NumeroLicitacionT = datard[posNumeroLicitacionT] == DBNull.Value ? string.Empty  : datard.GetString(posNumeroLicitacionT);
                            RequisicionLicitacion.IdTiempo = datard.GetInt32(posIdTiempo);
                            RequisicionLicitacion.IdFormaAbastecimiento = datard.GetInt32(posIdFormaAbastecimiento);
                            RequisicionLicitacion.IdPartida = datard.GetInt32(posIdPartida);
                            RequisicionLicitacion.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            RequisicionLicitacion.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            RequisicionLicitacion.FechaRequisicion = datard.GetDateTime(posFechaRequisicion);
                            RequisicionLicitacion.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            RequisicionLicitacion.ConsecutivoRequisicion = datard.GetInt32(posConsecutivoRequisicion);
                            RequisicionLicitacion.NumeroOficioSolicitud = datard.GetString(posNumeroOficioSolicitud);
                            RequisicionLicitacion.NumeroOficioCertificacion = datard.GetString(posNumeroOficioCertificacion);
                            RequisicionLicitacion.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            RequisicionLicitacion.ClavePartida = datard.GetString(posClavePartida);
                            RequisicionLicitacion.Partida = datard.GetString(posPartida);
                            RequisicionLicitacion.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            RequisicionLicitacion.ClaveCapitulo = datard.GetInt32(posClaveCapitulo);
                            RequisicionLicitacion.Capitulo = datard.GetString(posCapitulo);
                            RequisicionLicitacion.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            RequisicionLicitacion.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            RequisicionLicitacion.Tiempo = datard.GetString(posTiempo);
                            RequisicionLicitacion.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            RequisicionLicitacion.Ejercicio = datard.GetInt32(posEjercicio);
                            ListadoRequisicionLicitacion.Add(RequisicionLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        public List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacionRevisor_x_IdLicitacion(SqlConnection Conexion, int pIdLicitacion)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            string sp = "Proc_RequisicionesPreguntasRevisor_x_IdLicitacion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posNumeroLicitacionT = datard.GetOrdinal("NumeroLicitacionT");
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
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posClavePartida = datard.GetOrdinal("ClavePartida");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posClaveCapitulo = datard.GetOrdinal("ClaveCapitulo");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        //int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        while (datard.Read())
                        {
                            beListadoRequisicionLicitacion RequisicionLicitacion = new beListadoRequisicionLicitacion();

                            RequisicionLicitacion.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            RequisicionLicitacion.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            RequisicionLicitacion.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            RequisicionLicitacion.NumeroLicitacionT = datard[posNumeroLicitacionT] == DBNull.Value ? string.Empty : datard.GetString(posNumeroLicitacionT);
                            RequisicionLicitacion.IdTiempo = datard.GetInt32(posIdTiempo);
                            RequisicionLicitacion.IdFormaAbastecimiento = datard.GetInt32(posIdFormaAbastecimiento);
                            RequisicionLicitacion.IdPartida = datard.GetInt32(posIdPartida);
                            RequisicionLicitacion.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            RequisicionLicitacion.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            RequisicionLicitacion.FechaRequisicion = datard.GetDateTime(posFechaRequisicion);
                            RequisicionLicitacion.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            RequisicionLicitacion.ConsecutivoRequisicion = datard.GetInt32(posConsecutivoRequisicion);
                            RequisicionLicitacion.NumeroOficioSolicitud = datard.GetString(posNumeroOficioSolicitud);
                            RequisicionLicitacion.NumeroOficioCertificacion = datard.GetString(posNumeroOficioCertificacion);
                            RequisicionLicitacion.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            RequisicionLicitacion.ClavePartida = datard.GetString(posClavePartida);
                            RequisicionLicitacion.Partida = datard.GetString(posPartida);
                            RequisicionLicitacion.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            RequisicionLicitacion.ClaveCapitulo = datard.GetInt32(posClaveCapitulo);
                            RequisicionLicitacion.Capitulo = datard.GetString(posCapitulo);
                            RequisicionLicitacion.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            RequisicionLicitacion.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            RequisicionLicitacion.Tiempo = datard.GetString(posTiempo);
                            RequisicionLicitacion.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            RequisicionLicitacion.Ejercicio = datard.GetInt32(posEjercicio);
                            //RequisicionLicitacion.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            ListadoRequisicionLicitacion.Add(RequisicionLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        //Revisor
        public List<beListadoRequisicionLicitacion> PropuestasTecnicasRevisor_IdLicitacion(SqlConnection Conexion, int pIdLicitacion)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            string sp = "Proc_PropuestasTecnicasRevisor_IdLicitacion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posNumeroLicitacionT = datard.GetOrdinal("NumeroLicitacionT");
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
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posClavePartida = datard.GetOrdinal("ClavePartida");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posClaveCapitulo = datard.GetOrdinal("ClaveCapitulo");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");

                        int posIdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
                        int posIdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posEstatusPropuestaTecnica = datard.GetOrdinal("EstatusPropuestaTecnica");
                        int posEstatusPropuestaEconomica = datard.GetOrdinal("EstatusPropuestaEconomica");
                        
                        while (datard.Read())
                        {
                            beListadoRequisicionLicitacion RequisicionLicitacion = new beListadoRequisicionLicitacion();

                            RequisicionLicitacion.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            RequisicionLicitacion.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            RequisicionLicitacion.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            RequisicionLicitacion.NumeroLicitacionT = datard[posNumeroLicitacionT] == DBNull.Value ? string.Empty : datard.GetString(posNumeroLicitacionT);
                            RequisicionLicitacion.IdTiempo = datard.GetInt32(posIdTiempo);
                            RequisicionLicitacion.IdFormaAbastecimiento = datard.GetInt32(posIdFormaAbastecimiento);
                            RequisicionLicitacion.IdPartida = datard.GetInt32(posIdPartida);
                            RequisicionLicitacion.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            RequisicionLicitacion.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            RequisicionLicitacion.FechaRequisicion = datard.GetDateTime(posFechaRequisicion);
                            RequisicionLicitacion.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            RequisicionLicitacion.ConsecutivoRequisicion = datard.GetInt32(posConsecutivoRequisicion);
                            RequisicionLicitacion.NumeroOficioSolicitud = datard.GetString(posNumeroOficioSolicitud);
                            RequisicionLicitacion.NumeroOficioCertificacion = datard.GetString(posNumeroOficioCertificacion);
                            RequisicionLicitacion.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            RequisicionLicitacion.ClavePartida = datard.GetString(posClavePartida);
                            RequisicionLicitacion.Partida = datard.GetString(posPartida);
                            RequisicionLicitacion.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            RequisicionLicitacion.ClaveCapitulo = datard.GetInt32(posClaveCapitulo);
                            RequisicionLicitacion.Capitulo = datard.GetString(posCapitulo);
                            RequisicionLicitacion.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            RequisicionLicitacion.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            RequisicionLicitacion.Tiempo = datard.GetString(posTiempo);
                            RequisicionLicitacion.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            RequisicionLicitacion.Ejercicio = datard.GetInt32(posEjercicio);
                            RequisicionLicitacion.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);

                            RequisicionLicitacion.IdEstatusEnvioPropuestaEconomica = datard.GetInt32(posIdEstatusEnvioPropuestaEconomica);
                            RequisicionLicitacion.IdEstatusEnvioPropuestaTecnica = datard.GetInt32(posIdEstatusEnvioPropuestaTecnica);
                            RequisicionLicitacion.IdProveedor = datard.GetInt32(posIdProveedor);
                            RequisicionLicitacion.RazonSocial = datard.GetString(posRazonSocial);
                            RequisicionLicitacion.EstatusPropuestaTecnica = datard.GetString(posEstatusPropuestaTecnica);
                            RequisicionLicitacion.EstatusPropuestaEconomica = datard.GetString(posEstatusPropuestaEconomica);
                            
                            ListadoRequisicionLicitacion.Add(RequisicionLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }

        //Solicitante
        public List<beListadoRequisicionLicitacion> PropuestasTecnicasSolicitante_IdRequisicion(SqlConnection Conexion, int pIdLicitacion)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            string sp = "Proc_PropuestasTecnicasSolicitante_IdRequisicion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posNumeroLicitacionT = datard.GetOrdinal("NumeroLicitacionT");
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
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posClavePartida = datard.GetOrdinal("ClavePartida");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posClaveCapitulo = datard.GetOrdinal("ClaveCapitulo");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");

                        int posIdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
                        int posIdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posEstatusPropuestaTecnica = datard.GetOrdinal("EstatusPropuestaTecnica");
                        int posEstatusPropuestaEconomica = datard.GetOrdinal("EstatusPropuestaEconomica");

                        while (datard.Read())
                        {
                            beListadoRequisicionLicitacion RequisicionLicitacion = new beListadoRequisicionLicitacion();

                            RequisicionLicitacion.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            RequisicionLicitacion.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            RequisicionLicitacion.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            RequisicionLicitacion.NumeroLicitacionT = datard[posNumeroLicitacionT] == DBNull.Value ? string.Empty : datard.GetString(posNumeroLicitacionT);
                            RequisicionLicitacion.IdTiempo = datard.GetInt32(posIdTiempo);
                            RequisicionLicitacion.IdFormaAbastecimiento = datard.GetInt32(posIdFormaAbastecimiento);
                            RequisicionLicitacion.IdPartida = datard.GetInt32(posIdPartida);
                            RequisicionLicitacion.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            RequisicionLicitacion.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            RequisicionLicitacion.FechaRequisicion = datard.GetDateTime(posFechaRequisicion);
                            RequisicionLicitacion.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            RequisicionLicitacion.ConsecutivoRequisicion = datard.GetInt32(posConsecutivoRequisicion);
                            RequisicionLicitacion.NumeroOficioSolicitud = datard.GetString(posNumeroOficioSolicitud);
                            RequisicionLicitacion.NumeroOficioCertificacion = datard.GetString(posNumeroOficioCertificacion);
                            RequisicionLicitacion.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            RequisicionLicitacion.ClavePartida = datard.GetString(posClavePartida);
                            RequisicionLicitacion.Partida = datard.GetString(posPartida);
                            RequisicionLicitacion.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            RequisicionLicitacion.ClaveCapitulo = datard.GetInt32(posClaveCapitulo);
                            RequisicionLicitacion.Capitulo = datard.GetString(posCapitulo);
                            RequisicionLicitacion.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            RequisicionLicitacion.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            RequisicionLicitacion.Tiempo = datard.GetString(posTiempo);
                            RequisicionLicitacion.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            RequisicionLicitacion.Ejercicio = datard.GetInt32(posEjercicio);
                            RequisicionLicitacion.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);

                            RequisicionLicitacion.IdEstatusEnvioPropuestaEconomica = datard.GetInt32(posIdEstatusEnvioPropuestaEconomica);
                            RequisicionLicitacion.IdEstatusEnvioPropuestaTecnica = datard.GetInt32(posIdEstatusEnvioPropuestaTecnica);
                            RequisicionLicitacion.IdProveedor = datard.GetInt32(posIdProveedor);
                            RequisicionLicitacion.RazonSocial = datard.GetString(posRazonSocial);
                            RequisicionLicitacion.EstatusPropuestaTecnica = datard.GetString(posEstatusPropuestaTecnica);
                            RequisicionLicitacion.EstatusPropuestaEconomica = datard.GetString(posEstatusPropuestaEconomica);

                            ListadoRequisicionLicitacion.Add(RequisicionLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        public List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacionSolictanteDependenciaDictamenTecnico(SqlConnection Conexion, int pIdLicitacion, int pIdDependencia)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            string sp = "Proc_RequisicionesPropuestasTecnicasSolicitante_IdLicitacionDependencia";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = pIdDependencia;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posNumeroLicitacionT = datard.GetOrdinal("NumeroLicitacionT");
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
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posClavePartida = datard.GetOrdinal("ClavePartida");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posClaveCapitulo = datard.GetOrdinal("ClaveCapitulo");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");

                        while (datard.Read())
                        {
                            beListadoRequisicionLicitacion RequisicionLicitacion = new beListadoRequisicionLicitacion();

                            RequisicionLicitacion.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            RequisicionLicitacion.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            RequisicionLicitacion.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            RequisicionLicitacion.NumeroLicitacionT = datard[posNumeroLicitacionT] == DBNull.Value ? string.Empty : datard.GetString(posNumeroLicitacionT);
                            RequisicionLicitacion.IdTiempo = datard.GetInt32(posIdTiempo);
                            RequisicionLicitacion.IdFormaAbastecimiento = datard.GetInt32(posIdFormaAbastecimiento);
                            RequisicionLicitacion.IdPartida = datard.GetInt32(posIdPartida);
                            RequisicionLicitacion.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            RequisicionLicitacion.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            RequisicionLicitacion.FechaRequisicion = datard.GetDateTime(posFechaRequisicion);
                            RequisicionLicitacion.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            RequisicionLicitacion.ConsecutivoRequisicion = datard.GetInt32(posConsecutivoRequisicion);
                            RequisicionLicitacion.NumeroOficioSolicitud = datard.GetString(posNumeroOficioSolicitud);
                            RequisicionLicitacion.NumeroOficioCertificacion = datard.GetString(posNumeroOficioCertificacion);
                            RequisicionLicitacion.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            RequisicionLicitacion.ClavePartida = datard.GetString(posClavePartida);
                            RequisicionLicitacion.Partida = datard.GetString(posPartida);
                            RequisicionLicitacion.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            RequisicionLicitacion.ClaveCapitulo = datard.GetInt32(posClaveCapitulo);
                            RequisicionLicitacion.Capitulo = datard.GetString(posCapitulo);
                            RequisicionLicitacion.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            RequisicionLicitacion.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            RequisicionLicitacion.Tiempo = datard.GetString(posTiempo);
                            RequisicionLicitacion.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            RequisicionLicitacion.Ejercicio = datard.GetInt32(posEjercicio);
                            RequisicionLicitacion.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            RequisicionLicitacion.RazonSocial = datard.GetString(posRazonSocial);
                            ListadoRequisicionLicitacion.Add(RequisicionLicitacion);

                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        //Revisor
        public List<beListadoRequisicionLicitacion> DictamenPropuestasTecnicasRevisor_IdLicitacion_IdEstatus(SqlConnection Conexion, int pIdLicitacion, int pIdEstatus)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            string sp = "Proc_PropuestasTecnicasDictamenRevisor_IdLicitacion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;
            cmd.Parameters.Add("@IdEstatusPropuesta", SqlDbType.Int).Value = pIdEstatus;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posNumeroLicitacionT = datard.GetOrdinal("NumeroLicitacionT");
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
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posClavePartida = datard.GetOrdinal("ClavePartida");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posClaveCapitulo = datard.GetOrdinal("ClaveCapitulo");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");

                        int posIdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
                        int posIdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posEstatusPropuestaTecnica = datard.GetOrdinal("EstatusPropuestaTecnica");
                        int posEstatusPropuestaEconomica = datard.GetOrdinal("EstatusPropuestaEconomica");

                        while (datard.Read())
                        {
                            beListadoRequisicionLicitacion RequisicionLicitacion = new beListadoRequisicionLicitacion();

                            RequisicionLicitacion.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            RequisicionLicitacion.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            RequisicionLicitacion.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            RequisicionLicitacion.NumeroLicitacionT = datard[posNumeroLicitacionT] == DBNull.Value ? string.Empty : datard.GetString(posNumeroLicitacionT);
                            RequisicionLicitacion.IdTiempo = datard.GetInt32(posIdTiempo);
                            RequisicionLicitacion.IdFormaAbastecimiento = datard.GetInt32(posIdFormaAbastecimiento);
                            RequisicionLicitacion.IdPartida = datard.GetInt32(posIdPartida);
                            RequisicionLicitacion.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            RequisicionLicitacion.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            RequisicionLicitacion.FechaRequisicion = datard.GetDateTime(posFechaRequisicion);
                            RequisicionLicitacion.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            RequisicionLicitacion.ConsecutivoRequisicion = datard.GetInt32(posConsecutivoRequisicion);
                            RequisicionLicitacion.NumeroOficioSolicitud = datard.GetString(posNumeroOficioSolicitud);
                            RequisicionLicitacion.NumeroOficioCertificacion = datard.GetString(posNumeroOficioCertificacion);
                            RequisicionLicitacion.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            RequisicionLicitacion.ClavePartida = datard.GetString(posClavePartida);
                            RequisicionLicitacion.Partida = datard.GetString(posPartida);
                            RequisicionLicitacion.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            RequisicionLicitacion.ClaveCapitulo = datard.GetInt32(posClaveCapitulo);
                            RequisicionLicitacion.Capitulo = datard.GetString(posCapitulo);
                            RequisicionLicitacion.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            RequisicionLicitacion.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            RequisicionLicitacion.Tiempo = datard.GetString(posTiempo);
                            RequisicionLicitacion.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            RequisicionLicitacion.Ejercicio = datard.GetInt32(posEjercicio);
                            RequisicionLicitacion.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);

                            RequisicionLicitacion.IdEstatusEnvioPropuestaEconomica = datard.GetInt32(posIdEstatusEnvioPropuestaEconomica);
                            RequisicionLicitacion.IdEstatusEnvioPropuestaTecnica = datard.GetInt32(posIdEstatusEnvioPropuestaTecnica);
                            RequisicionLicitacion.IdProveedor = datard.GetInt32(posIdProveedor);
                            RequisicionLicitacion.RazonSocial = datard.GetString(posRazonSocial);
                            RequisicionLicitacion.EstatusPropuestaTecnica = datard.GetString(posEstatusPropuestaTecnica);
                            RequisicionLicitacion.EstatusPropuestaEconomica = datard.GetString(posEstatusPropuestaEconomica);

                            ListadoRequisicionLicitacion.Add(RequisicionLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }

        //Revisor
        public List<bePedidosLicitaciones> LiberarPedido_IdLicitacion(SqlConnection Conexion, int pIdLicitacion,int pIdPerfil)
        {
            List<bePedidosLicitaciones> ListadoRequisicionLicitacion = new List<bePedidosLicitaciones>();
            string sp = "Proc_PedidosLicitaciones_x_IdLicitacion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;
            cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = pIdPerfil;
            
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int IdPedido = datard.GetOrdinal("IdPedido");
                        int Folio = datard.GetOrdinal("Folio");
                        int FolioNumero = datard.GetOrdinal("FolioNumero");
                        int IdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
                        int IdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int RequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int Rfc = datard.GetOrdinal("Rfc");
                        int RazonSocial = datard.GetOrdinal("RazonSocial");
                        int IdLicitacion = datard.GetOrdinal("IdLicitacion");
                        int EstatusPedido = datard.GetOrdinal("EstatusPedido");
                        int IdProveedor = datard.GetOrdinal("IdProveedor");
                        int EstatusFirmaPedido = datard.GetOrdinal("EstatusFirmaPedido");
                        while (datard.Read())
                        {
                            bePedidosLicitaciones RequisicionLicitacion = new bePedidosLicitaciones();
                            RequisicionLicitacion.IdPedido = datard.GetInt32(IdPedido);
                            RequisicionLicitacion.Folio = datard.GetString(Folio);
                            RequisicionLicitacion.FolioNumero = datard.GetInt32(FolioNumero);
                            RequisicionLicitacion.IdEstatusPedido = datard.GetInt32(IdEstatusPedido);
                            RequisicionLicitacion.IdRequisicion = datard.GetInt32(IdRequisicion);
                            RequisicionLicitacion.RequisicionFolio = datard.GetString(RequisicionFolio);
                            RequisicionLicitacion.Rfc = datard.GetString(Rfc);
                            RequisicionLicitacion.RazonSocial = datard.GetString(RazonSocial);
                            RequisicionLicitacion.IdLicitacion = datard.GetInt32(IdLicitacion);
                            RequisicionLicitacion.EstatusPedido = datard.GetString(EstatusPedido);
                            RequisicionLicitacion.IdProveedor = datard.GetInt32(IdProveedor);
                            RequisicionLicitacion.EstatusFirmaPedido = datard.GetString(EstatusFirmaPedido);
                            ListadoRequisicionLicitacion.Add(RequisicionLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        //Revisor
        public List<bePedidosFirmantesLiberar> getAllPedidosFirmantes_IdPedido(SqlConnection Conexion, int pIdPedido)
        {
            List<bePedidosFirmantesLiberar> ListadoRequisicionLicitacion = new List<bePedidosFirmantesLiberar>();
            string sp = "Proc_PedidosFirmantes_x_IdPedido";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = pIdPedido;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    { 

                    int IdPedidoFirmante = datard.GetOrdinal("IdPedidoFirmante");
                    int IdPedido = datard.GetOrdinal("IdPedido");
                    int IdPerfil = datard.GetOrdinal("IdPerfil");
                    int Ordenamiento = datard.GetOrdinal("Ordenamiento");
                    int Cargo = datard.GetOrdinal("Cargo");
                    int IdEstatusFirmaPedido = datard.GetOrdinal("IdEstatusFirmaPedido");
                    int IdUsuarioFirmante = datard.GetOrdinal("IdUsuarioFirmante");
                    int FechaFirma = datard.GetOrdinal("FechaFirma");
                    int Perfil = datard.GetOrdinal("Perfil");
                    int IdPersona = datard.GetOrdinal("IdPersona");
                    int NombreCompleto = datard.GetOrdinal("NombreCompleto");
                    int EstatusFirmaPedido = datard.GetOrdinal("EstatusFirmaPedido");
                        while (datard.Read())
                        {
                            bePedidosFirmantesLiberar RequisicionLicitacion = new bePedidosFirmantesLiberar();
                            RequisicionLicitacion.IdPedidoFirmante = datard.GetInt32(IdPedidoFirmante);
                            RequisicionLicitacion.IdPedido = datard.GetInt32(IdPedido);
                            RequisicionLicitacion.IdPerfil = datard.GetInt32(IdPerfil);
                            RequisicionLicitacion.Ordenamiento = datard.GetInt32(Ordenamiento);
                            RequisicionLicitacion.Cargo = datard.GetString(Cargo);
                            RequisicionLicitacion.IdEstatusFirmaPedido = datard.GetInt32(IdEstatusFirmaPedido);
                            RequisicionLicitacion.IdUsuarioFirmante = datard[IdUsuarioFirmante]==DBNull.Value?0: datard.GetInt32(IdUsuarioFirmante);
                            RequisicionLicitacion.FechaFirma = datard[FechaFirma] == DBNull.Value ? DateTime.MinValue : datard.GetDateTime(FechaFirma);
                            RequisicionLicitacion.Perfil = datard.GetString(Perfil);
                            RequisicionLicitacion.IdPersona = datard[IdPersona] == DBNull.Value ? 0: datard.GetInt32(IdPersona);
                            RequisicionLicitacion.NombreCompleto = datard.GetString(NombreCompleto);
                            RequisicionLicitacion.EstatusFirmaPedido = datard.GetString(EstatusFirmaPedido);
                            ListadoRequisicionLicitacion.Add(RequisicionLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        //Solicitante
        public List<bePedidosLicitaciones> LiberarPedido_IdLicitacion_IdDependencia(SqlConnection Conexion, int pIdLicitacion, int pIdDependencia,int pIdPerfil)
        {
            List<bePedidosLicitaciones> ListadoRequisicionLicitacion = new List<bePedidosLicitaciones>();
            string sp = "Proc_PedidosLicitaciones_x_IdLicitacionDependencia";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = pIdDependencia;
            cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = pIdPerfil;
            
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int IdPedido = datard.GetOrdinal("IdPedido");
                        int Folio = datard.GetOrdinal("Folio");
                        int FolioNumero = datard.GetOrdinal("FolioNumero");
                        int IdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
                        int IdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int RequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int Rfc = datard.GetOrdinal("Rfc");
                        int RazonSocial = datard.GetOrdinal("RazonSocial");
                        int IdLicitacion = datard.GetOrdinal("IdLicitacion");
                        int EstatusPedido = datard.GetOrdinal("EstatusPedido");
                        int IdProveedor = datard.GetOrdinal("IdProveedor");
                        int EstatusFirmaPedido = datard.GetOrdinal("EstatusFirmaPedido");
                        while (datard.Read())
                        {
                            bePedidosLicitaciones RequisicionLicitacion = new bePedidosLicitaciones();
                            RequisicionLicitacion.IdPedido = datard.GetInt32(IdPedido);
                            RequisicionLicitacion.Folio = datard.GetString(Folio);
                            RequisicionLicitacion.FolioNumero = datard.GetInt32(FolioNumero);
                            RequisicionLicitacion.IdEstatusPedido = datard.GetInt32(IdEstatusPedido);
                            RequisicionLicitacion.IdRequisicion = datard.GetInt32(IdRequisicion);
                            RequisicionLicitacion.RequisicionFolio = datard.GetString(RequisicionFolio);
                            RequisicionLicitacion.Rfc = datard.GetString(Rfc);
                            RequisicionLicitacion.RazonSocial = datard.GetString(RazonSocial);
                            RequisicionLicitacion.IdLicitacion = datard.GetInt32(IdLicitacion);
                            RequisicionLicitacion.EstatusPedido = datard.GetString(EstatusPedido);
                            RequisicionLicitacion.IdProveedor = datard.GetInt32(IdProveedor);
                            RequisicionLicitacion.EstatusFirmaPedido = datard.GetString(EstatusFirmaPedido);
                            ListadoRequisicionLicitacion.Add(RequisicionLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        //4.	Director adquisiciones
        public List<beListadoLicitacionesInvitacionProveedores> getAllDirectorAdquisiciones(SqlConnection Conexion)
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoLicitacionesInvitacionProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            string sp = "Proc_Licitaciones_x_LiberarPedidos";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        //int posIdInvitacion = datard.GetOrdinal("IdInvitacion");
                        int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
                        //int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        //int posAceptacion = datard.GetOrdinal("Aceptacion");
                        //int posFechaAceptacion = datard.GetOrdinal("FechaAceptacion");
                        //int posUrlRecibo = datard.GetOrdinal("UrlRecibo");
                        //int posObservaciones = datard.GetOrdinal("Observaciones");
                        int postFolioNumero = datard.GetOrdinal("FolioNumero");
                        int posIdEstatusLicitacion = datard.GetOrdinal("IdEstatusLicitacion");
                        int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
                        int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
                        int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
                        int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
                        int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
                        int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
                        int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
                        int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
                        int posFechaFallo = datard.GetOrdinal("FechaFallo");
                        int posHoraFallo = datard.GetOrdinal("HoraFallo");
                        int posFolioOficial = datard.GetOrdinal("FolioOficial");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posEstatus = datard.GetOrdinal("Estatus");
                        //int posDependencias = datard.GetOrdinal("Dependencias");
                        int posModalidadLicitacion = datard.GetOrdinal("ModalidadLicitacion");
                        int posLicitacion = datard.GetOrdinal("Licitacion");

                        while (datard.Read())
                        {
                            beListadoLicitacionesInvitacionProveedores ObeListadoInvitacionProveedores = new beListadoLicitacionesInvitacionProveedores();
                            //ObeListadoInvitacionProveedores.IdInvitacion = datard.GetInt32(posIdInvitacion);
                            ObeListadoInvitacionProveedores.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            //ObeListadoInvitacionProveedores.IdProveedor = datard.GetInt32(posIdProveedor);
                            //ObeListadoInvitacionProveedores.Aceptacion = datard[posAceptacion] == DBNull.Value ? false : datard.GetBoolean(posAceptacion);
                            //ObeListadoInvitacionProveedores.FechaAceptacion = datard[posFechaAceptacion] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaAceptacion);
                            //ObeListadoInvitacionProveedores.UrlRecibo = datard[posUrlRecibo] == DBNull.Value ? string.Empty : datard.GetString(posUrlRecibo);
                            //ObeListadoInvitacionProveedores.Observaciones = datard[posObservaciones] == DBNull.Value ? string.Empty : datard.GetString(posObservaciones);
                            //ObeListadoInvitacionProveedores.IdEstatusPago = datard.GetInt32(posIdEstatusPago);
                            ObeListadoInvitacionProveedores.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            ObeListadoInvitacionProveedores.HoraAutorizacion = datard.GetTimeSpan(posHoraAutorizacion);
                            ObeListadoInvitacionProveedores.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
                            ObeListadoInvitacionProveedores.FechaDisposicionBases = datard.GetDateTime(posFechaDisposicionBases);
                            ObeListadoInvitacionProveedores.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
                            ObeListadoInvitacionProveedores.FechaLimiteRespuestas = datard.GetDateTime(posFechaLimiteRespuestas);
                            ObeListadoInvitacionProveedores.FechaHoraAclaracionDudas = datard.GetDateTime(posFechaHoraAclaracionDudas);
                            ObeListadoInvitacionProveedores.FechaEnvioPropuestasTecEco = datard.GetDateTime(posFechaEnvioPropuestasTecEco);
                            ObeListadoInvitacionProveedores.FechaLimiteDictamen = datard.GetDateTime(posFechaLimiteDictamen);
                            ObeListadoInvitacionProveedores.FechaFallo = datard.GetDateTime(posFechaFallo);
                            ObeListadoInvitacionProveedores.HoraFallo = datard.GetTimeSpan(posHoraFallo);
                            ObeListadoInvitacionProveedores.FolioOficial = datard[posFolioOficial] == DBNull.Value ? string.Empty : datard.GetString(posFolioOficial);
                            ObeListadoInvitacionProveedores.Tiempo = datard.GetString(posTiempo);
                            ObeListadoInvitacionProveedores.Ejercicio = datard.GetInt32(posEjercicio);
                            //ObeListadoInvitacionProveedores.Partidas = datard.GetString(posPartidas);
                            ObeListadoInvitacionProveedores.IdEstatusLicitacion = datard.GetInt32(posIdEstatusLicitacion);
                            ObeListadoInvitacionProveedores.ModalidadLicitacion = datard.GetString(posModalidadLicitacion);
                            ObeListadoInvitacionProveedores.Licitacion = datard.GetString(posLicitacion);
                            ObeListadoInvitacionProveedores.Estatus = datard.GetString(posEstatus);
                            ObeListadoInvitacionProveedores.FolioNumero = datard.GetInt32(postFolioNumero);
                            listadoLicitacionesInvitacionProveedores.Add(ObeListadoInvitacionProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoLicitacionesInvitacionProveedores;
            }
        }
        //Proveedor
        public List<bePedidosLicitaciones> LiberarPedido_Proveedor(SqlConnection Conexion, int pIdLicitacion, int pIdProveedor,int IdPerfil)
        {
            List<bePedidosLicitaciones> ListadoRequisicionLicitacion = new List<bePedidosLicitaciones>();
            string sp = "Proc_PedidosLicitaciones_x_IdLicitacionProveedor";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = pIdLicitacion;
            cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = pIdProveedor;
            cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
            
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int IdPedido = datard.GetOrdinal("IdPedido");
                        int Folio = datard.GetOrdinal("Folio");
                        int FolioNumero = datard.GetOrdinal("FolioNumero");
                        int IdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
                        int IdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int RequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int Rfc = datard.GetOrdinal("Rfc");
                        int RazonSocial = datard.GetOrdinal("RazonSocial");
                        int IdLicitacion = datard.GetOrdinal("IdLicitacion");
                        int EstatusPedido = datard.GetOrdinal("EstatusPedido");
                        int IdProveedor = datard.GetOrdinal("IdProveedor");
                        int EstatusFirmaPedido = datard.GetOrdinal("EstatusFirmaPedido");

                        while (datard.Read())
                        {
                            bePedidosLicitaciones RequisicionLicitacion = new bePedidosLicitaciones();
                            RequisicionLicitacion.IdPedido = datard.GetInt32(IdPedido);
                            RequisicionLicitacion.Folio = datard.GetString(Folio);
                            RequisicionLicitacion.FolioNumero = datard.GetInt32(FolioNumero);
                            RequisicionLicitacion.IdEstatusPedido = datard.GetInt32(IdEstatusPedido);
                            RequisicionLicitacion.IdRequisicion = datard.GetInt32(IdRequisicion);
                            RequisicionLicitacion.RequisicionFolio = datard.GetString(RequisicionFolio);
                            RequisicionLicitacion.Rfc = datard.GetString(Rfc);
                            RequisicionLicitacion.RazonSocial = datard.GetString(RazonSocial);
                            RequisicionLicitacion.IdLicitacion = datard.GetInt32(IdLicitacion);
                            RequisicionLicitacion.EstatusPedido = datard.GetString(EstatusPedido);
                            RequisicionLicitacion.IdProveedor = datard.GetInt32(IdProveedor);
                            RequisicionLicitacion.EstatusFirmaPedido = datard.GetString(EstatusFirmaPedido);
                            ListadoRequisicionLicitacion.Add(RequisicionLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
    }
}
