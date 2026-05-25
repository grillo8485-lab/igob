using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daLicitacionesActaAdjudicacion
    {
        public beLicitacionesActaAdjudicacion traerActaAdjudicacion_Licitaciones_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_ActaAdjudicacion_Licitaciones_x_IdLicitacion";
            beLicitacionesActaAdjudicacion obeLicitaciones = null;
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
                        int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
                        //int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
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

                        int posTitulo = datard.GetOrdinal("Titulo");


                        obeLicitaciones = new beLicitacionesActaAdjudicacion();
                        while (datard.Read())
                        {
                            obeLicitaciones.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            //obeLicitaciones.IdConfiguracionModalidad = datard.GetInt32(posIdConfiguracionModalidad);
                            //obeLicitaciones.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            //obeLicitaciones.IdEtapaLicitacion = datard.GetInt32(posIdEtapaLicitacion);
                            obeLicitaciones.FolioOficial = datard.GetString(posFolioOficial);
                            //obeLicitaciones.MontoBases = datard.GetDecimal(posMontoBases);
                            //obeLicitaciones.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            obeLicitaciones.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            obeLicitaciones.HoraAutorizacion = datard.GetTimeSpan(posHoraAutorizacion);
                            //obeLicitaciones.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
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

                            obeLicitaciones.Titulo = datard.GetString(posTitulo);

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

        public List<beLicitacionesActaAdjudicacion> traerActaAdjudicacion_Requisiciones_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_ActaAdjudicacion_Requisiciones_x_IdLicitacion";
            List<beLicitacionesActaAdjudicacion> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posMontoEjercido = datard.GetOrdinal("MontoEjercido");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posMontoTotalAdjudicado = datard.GetOrdinal("MontoTotalAdjudicado");

                        lbeLicitacionesDictamen = new List<beLicitacionesActaAdjudicacion>();
                        beLicitacionesActaAdjudicacion obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesActaAdjudicacion();

                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeLicitaciones.Dependencia = datard.GetString(posDependencia);
                            obeLicitaciones.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            obeLicitaciones.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            obeLicitaciones.MontoEjercido = datard.GetDecimal(posMontoEjercido);
                            obeLicitaciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeLicitaciones.MontoTotalAdjudicado = datard.GetDecimal(posMontoTotalAdjudicado);

                            lbeLicitacionesDictamen.Add(obeLicitaciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesActaAdjudicacion> traerActaAdjudicacion_Lotes_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_ActaAdjudicacion_Lotes_x_IdLicitacion";
            List<beLicitacionesActaAdjudicacion> lbeLicitacionesDictamen = null;
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
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posPrecioUnitarioOfertado = datard.GetOrdinal("PrecioUnitarioOfertado");
                        int posImpuestoPorcentaje = datard.GetOrdinal("ImpuestoPorcentaje");
                        int posImpuestoPeriodo = datard.GetOrdinal("ImpuestoPeriodo");
                        int posImportePeriodo = datard.GetOrdinal("ImportePeriodo");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");

                        lbeLicitacionesDictamen = new List<beLicitacionesActaAdjudicacion>();
                        beLicitacionesActaAdjudicacion obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesActaAdjudicacion();

                            obeLicitaciones.NoLote = datard.GetInt32(posNoLote);
                            obeLicitaciones.BienServicio = datard.GetString(posBienServicio);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);
                            obeLicitaciones.UnidadMedida = datard.GetString(posUnidadMedida);
                            obeLicitaciones.PrecioUnitarioOfertado = datard.GetDecimal(posPrecioUnitarioOfertado);
                            obeLicitaciones.ImpuestoPorcentaje = datard.GetDecimal(posImpuestoPorcentaje);
                            obeLicitaciones.ImpuestoPeriodo = datard.GetDecimal(posImpuestoPeriodo);
                            obeLicitaciones.ImportePeriodo = datard.GetDecimal(posImportePeriodo);
                            obeLicitaciones.IdProveedor = datard.GetInt32(posIdProveedor);
                            obeLicitaciones.RazonSocial = datard.GetString(posRazonSocial);
                            obeLicitaciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeLicitaciones.MesesServicio = datard.GetInt32(posMesesServicio);

                            lbeLicitacionesDictamen.Add(obeLicitaciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public beLicitacionesActaAdjudicacion traerRep_ActaAdjudicacion_Licitaciones_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_ActaAdjudicacion_Licitaciones_x_IdLicitacion";
            beLicitacionesActaAdjudicacion obeLicitaciones = null;
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
                        int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int posHoraAutorizacion = datard.GetOrdinal("HoraAutorizacion");
                        //int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
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

                        int posTitulo = datard.GetOrdinal("Titulo");


                        obeLicitaciones = new beLicitacionesActaAdjudicacion();
                        while (datard.Read())
                        {
                            obeLicitaciones.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            //obeLicitaciones.IdConfiguracionModalidad = datard.GetInt32(posIdConfiguracionModalidad);
                            //obeLicitaciones.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            //obeLicitaciones.IdEtapaLicitacion = datard.GetInt32(posIdEtapaLicitacion);
                            obeLicitaciones.FolioOficial = datard.GetString(posFolioOficial);
                            //obeLicitaciones.MontoBases = datard.GetDecimal(posMontoBases);
                            //obeLicitaciones.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            obeLicitaciones.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            obeLicitaciones.HoraAutorizacion = datard.GetTimeSpan(posHoraAutorizacion);
                            //obeLicitaciones.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
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

                            obeLicitaciones.Titulo = datard.GetString(posTitulo);

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

        public List<beLicitacionesActaAdjudicacion> traerRep_ActaAdjudicacion_Requisiciones_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_ActaAdjudicacion_Requisiciones_x_IdLicitacion";
            List<beLicitacionesActaAdjudicacion> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posMontoEjercido = datard.GetOrdinal("MontoEjercido");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posMontoTotalAdjudicado = datard.GetOrdinal("MontoTotalAdjudicado");

                        lbeLicitacionesDictamen = new List<beLicitacionesActaAdjudicacion>();
                        beLicitacionesActaAdjudicacion obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesActaAdjudicacion();

                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeLicitaciones.Dependencia = datard.GetString(posDependencia);
                            obeLicitaciones.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            obeLicitaciones.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            obeLicitaciones.MontoEjercido = datard.GetDecimal(posMontoEjercido);
                            obeLicitaciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeLicitaciones.MontoTotalAdjudicado = datard.GetDecimal(posMontoTotalAdjudicado);

                            lbeLicitacionesDictamen.Add(obeLicitaciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }

        public List<beLicitacionesActaAdjudicacion> traerRep_ActaAdjudicacion_Lotes_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_ActaAdjudicacion_Lotes_x_IdLicitacion";
            List<beLicitacionesActaAdjudicacion> lbeLicitacionesDictamen = null;
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
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posPrecioUnitarioOfertado = datard.GetOrdinal("PrecioUnitarioOfertado");
                        int posImpuestoPorcentaje = datard.GetOrdinal("ImpuestoPorcentaje");
                        int posImpuestoPeriodo = datard.GetOrdinal("ImpuestoPeriodo");
                        int posImportePeriodo = datard.GetOrdinal("ImportePeriodo");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");

                        lbeLicitacionesDictamen = new List<beLicitacionesActaAdjudicacion>();
                        beLicitacionesActaAdjudicacion obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesActaAdjudicacion();

                            obeLicitaciones.NoLote = datard.GetInt32(posNoLote);
                            obeLicitaciones.BienServicio = datard.GetString(posBienServicio);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);
                            obeLicitaciones.UnidadMedida = datard.GetString(posUnidadMedida);
                            obeLicitaciones.PrecioUnitarioOfertado = datard.GetDecimal(posPrecioUnitarioOfertado);
                            obeLicitaciones.ImpuestoPorcentaje = datard.GetDecimal(posImpuestoPorcentaje);
                            obeLicitaciones.ImpuestoPeriodo = datard.GetDecimal(posImpuestoPeriodo);
                            obeLicitaciones.ImportePeriodo = datard.GetDecimal(posImportePeriodo);
                            obeLicitaciones.IdProveedor = datard.GetInt32(posIdProveedor);
                            obeLicitaciones.RazonSocial = datard.GetString(posRazonSocial);
                            obeLicitaciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeLicitaciones.MesesServicio = datard.GetInt32(posMesesServicio);

                            lbeLicitacionesDictamen.Add(obeLicitaciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }
    }
}
