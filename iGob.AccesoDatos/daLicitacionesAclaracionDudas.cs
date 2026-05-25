using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daLicitacionesAclaracionDudas
    {
        public beLicitacionesAclaracionDudas traerLicitaciones_x_IdLicitacion_AclaracionDudas(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_AclaracionDudas_Licitaciones_x_IdLicitacion";
            beLicitacionesAclaracionDudas obeLicitaciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
                        //int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
                        //int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        //int posIdEtapaLicitacion = datard.GetOrdinal("IdEtapaLicitacion");
                        int posFolioOficial = datard.GetOrdinal("FolioOficial");
                        //int posMontoBases = datard.GetOrdinal("MontoBases");
                        //int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        //int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        //int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
                        int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
                        //int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
                        //int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
                        //int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
                        //int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
                        //int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
                        //int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
                        //int posFechaFallo = datard.GetOrdinal("FechaFallo");
                        //int posHoraFallo = datard.GetOrdinal("HoraFallo");
                        //int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
                        //int posIdTiempo = datard.GetOrdinal("IdTiempo");
                        //int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        //int posIdUnidadLicitadora = datard.GetOrdinal("IdUnidadLicitadora");
                        //int posIdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
                        //int posIdEstatusLicitacion = datard.GetOrdinal("IdEstatusLicitacion");
                        //int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        //int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        //int posTiempoPeriodoPujasHrs = datard.GetOrdinal("TiempoPeriodoPujasHrs");
                        //int posTiempoAdicionalPujasMin = datard.GetOrdinal("TiempoAdicionalPujasMin");
                        //int posTiempoEtapaFinalMin = datard.GetOrdinal("TiempoEtapaFinalMin");
                        //int posAplicaNomenclaturaInvolucrados = datard.GetOrdinal("AplicaNomenclaturaInvolucrados");
                        //int posMostrarMontoPropuestaGanando = datard.GetOrdinal("MostrarMontoPropuestaGanando");
                        //int posMostrarLugarProveedor = datard.GetOrdinal("MostrarLugarProveedor");

                        int posFechaAclaracionDudas = datard.GetOrdinal("FechaAclaracionDudas");
                        int posHoraAclaracionDudas = datard.GetOrdinal("HoraAclaracionDudas");
                        int posTitulo = datard.GetOrdinal("Titulo");
                        int posDependencias = datard.GetOrdinal("Dependencias");
                        int posPartidas = datard.GetOrdinal("Partidas");
                        int posFolioRequisiciones = datard.GetOrdinal("FolioRequisiciones");
                        int posEmpresasProveedoras = datard.GetOrdinal("EmpresasProveedoras");

                        obeLicitaciones = new beLicitacionesAclaracionDudas();
                        while (datard.Read())
                        {
                            obeLicitaciones.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            //obeLicitaciones.IdConfiguracionModalidad = datard.GetInt32(posIdConfiguracionModalidad);
                            //obeLicitaciones.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            //obeLicitaciones.IdEtapaLicitacion = datard.GetInt32(posIdEtapaLicitacion);
                            obeLicitaciones.FolioOficial = datard.GetString(posFolioOficial);
                            //obeLicitaciones.MontoBases = datard.GetDecimal(posMontoBases);
                            //obeLicitaciones.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            //obeLicitaciones.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            //obeLicitaciones.HoraAutorizacion = datard.GetTimeSpan(posHoraAutorizacion);
                            obeLicitaciones.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
                            //obeLicitaciones.FechaDisposicionBases = datard.GetDateTime(posFechaDisposicionBases);
                            //obeLicitaciones.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
                            //obeLicitaciones.FechaLimiteRespuestas = datard.GetDateTime(posFechaLimiteRespuestas);
                            //obeLicitaciones.FechaHoraAclaracionDudas = datard.GetDateTime(posFechaHoraAclaracionDudas);
                            //obeLicitaciones.FechaEnvioPropuestasTecEco = datard.GetDateTime(posFechaEnvioPropuestasTecEco);
                            //obeLicitaciones.FechaLimiteDictamen = datard.GetDateTime(posFechaLimiteDictamen);
                            //obeLicitaciones.FechaFallo = datard.GetDateTime(posFechaFallo);
                            //obeLicitaciones.HoraFallo = datard.GetTimeSpan(posHoraFallo);
                            //obeLicitaciones.IdTipoLicitacion = datard.GetInt32(posIdTipoLicitacion);
                            //obeLicitaciones.IdTiempo = datard.GetInt32(posIdTiempo);
                            //obeLicitaciones.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            //obeLicitaciones.IdUnidadLicitadora = datard.GetInt32(posIdUnidadLicitadora);
                            //obeLicitaciones.IdUsuarioRevisor = datard.GetInt32(posIdUsuarioRevisor);
                            //obeLicitaciones.IdEstatusLicitacion = datard.GetInt32(posIdEstatusLicitacion);
                            //obeLicitaciones.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            //obeLicitaciones.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            //obeLicitaciones.TiempoPeriodoPujasHrs = datard.GetInt32(posTiempoPeriodoPujasHrs);
                            //obeLicitaciones.TiempoAdicionalPujasMin = datard.GetInt32(posTiempoAdicionalPujasMin);
                            //obeLicitaciones.TiempoEtapaFinalMin = datard.GetInt32(posTiempoEtapaFinalMin);
                            //obeLicitaciones.AplicaNomenclaturaInvolucrados = datard.GetBoolean(posAplicaNomenclaturaInvolucrados);
                            //obeLicitaciones.MostrarMontoPropuestaGanando = datard.GetBoolean(posMostrarMontoPropuestaGanando);
                            //obeLicitaciones.MostrarLugarProveedor = datard.GetBoolean(posMostrarLugarProveedor);

                            obeLicitaciones.FechaAclaracionDudas = datard.GetString(posFechaAclaracionDudas);
                            obeLicitaciones.HoraAclaracionDudas = datard.GetString(posHoraAclaracionDudas);
                            obeLicitaciones.Titulo = datard.GetString(posTitulo);
                            obeLicitaciones.Dependencias = datard.GetString(posDependencias);
                            obeLicitaciones.Partidas = datard.GetString(posPartidas);
                            obeLicitaciones.FolioRequisiciones = datard.GetString(posFolioRequisiciones);
                            obeLicitaciones.EmpresasProveedoras = datard.GetString(posEmpresasProveedoras);

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesAclaracionDudas> traerProveedoresPreguntas_x_IdLicitacion_AclaracionDudas(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_AclaracionDudas_ProveedoresPreguntas_x_IdLicitacion";
            List<beLicitacionesAclaracionDudas> lbeRequisicionesCondicionesEntregasDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posPregunta = datard.GetOrdinal("Pregunta");
                        int posRespuesta = datard.GetOrdinal("Respuesta");

                        lbeRequisicionesCondicionesEntregasDetalles = new List<beLicitacionesAclaracionDudas>();
                        beLicitacionesAclaracionDudas obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesAclaracionDudas();

                            obeLicitaciones.RazonSocial = datard.GetString(posRazonSocial);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeLicitaciones.Partida = datard.GetString(posPartida);
                            obeLicitaciones.Dependencia = datard.GetString(posDependencia);
                            obeLicitaciones.Pregunta = datard.GetString(posPregunta);
                            obeLicitaciones.Respuesta = datard[posRespuesta]==DBNull.Value?"": datard.GetString(posRespuesta);

                            lbeRequisicionesCondicionesEntregasDetalles.Add(obeLicitaciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesEntregasDetalles;
            }
        }
    }
}
