using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daLicitacionesConvocatoria
    {
        public beLicitacionesConvocatoria traerLicitaciones_x_IdLicitacion_Convocatoria(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Convocatoria_Licitaciones_x_IdLicitacion";
            beLicitacionesConvocatoria obeLicitaciones = null;
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
                        //int posFolioOficial = datard.GetOrdinal("FolioOficial");
                        int posMontoBases = datard.GetOrdinal("MontoBases");
                        //int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        //int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        //int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
                        int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
                        int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
                        //int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
                        //int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
                        int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
                        int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
                        //int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
                        int posFechaFallo = datard.GetOrdinal("FechaFallo");
                        int posHoraFallo = datard.GetOrdinal("HoraFallo");
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

                        int posTitulo = datard.GetOrdinal("Titulo");
                        int posPartidas = datard.GetOrdinal("Partidas");

                        obeLicitaciones = new beLicitacionesConvocatoria();
                        while (datard.Read())
                        {
                            obeLicitaciones.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            //obeLicitaciones.IdConfiguracionModalidad = datard.GetInt32(posIdConfiguracionModalidad);
                            //obeLicitaciones.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            //obeLicitaciones.IdEtapaLicitacion = datard.GetInt32(posIdEtapaLicitacion);
                            //obeLicitaciones.FolioOficial = datard.GetString(posFolioOficial);
                            obeLicitaciones.MontoBases = datard.GetDecimal(posMontoBases);
                            //obeLicitaciones.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            //obeLicitaciones.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            //obeLicitaciones.HoraAutorizacion = datard.GetTimeSpan(posHoraAutorizacion);
                            obeLicitaciones.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
                            obeLicitaciones.FechaDisposicionBases = datard.GetDateTime(posFechaDisposicionBases);
                            //obeLicitaciones.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
                            //obeLicitaciones.FechaLimiteRespuestas = datard.GetDateTime(posFechaLimiteRespuestas);
                            obeLicitaciones.FechaHoraAclaracionDudas = datard.GetDateTime(posFechaHoraAclaracionDudas);
                            obeLicitaciones.FechaEnvioPropuestasTecEco = datard.GetDateTime(posFechaEnvioPropuestasTecEco);
                            //obeLicitaciones.FechaLimiteDictamen = datard.GetDateTime(posFechaLimiteDictamen);
                            obeLicitaciones.FechaFallo = datard.GetDateTime(posFechaFallo);
                            obeLicitaciones.HoraFallo = datard.GetTimeSpan(posHoraFallo);
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

                            obeLicitaciones.Titulo = datard.GetString(posTitulo);
                            obeLicitaciones.Partidas = datard.GetString(posPartidas);

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

        public List<beLicitacionesConvocatoria> traerRequisicionesLotes_x_IdLicitacion_Convocatoria(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Convocatoria_RequisicionesLotes_x_IdLicitacion";
            List<beLicitacionesConvocatoria> lbeRequisicionesCondicionesEntregasDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posCantidad = datard.GetOrdinal("Cantidad");

                        lbeRequisicionesCondicionesEntregasDetalles = new List<beLicitacionesConvocatoria>();
                        beLicitacionesConvocatoria obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesConvocatoria();

                            obeLicitaciones.NoLote = datard.GetInt32(posNoLote);
                            obeLicitaciones.BienServicio = datard.GetString(posBienServicio);
                            obeLicitaciones.UnidadMedida = datard.GetString(posUnidadMedida);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);

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
