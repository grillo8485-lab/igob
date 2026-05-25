using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;


namespace iGob.AccesoDatos
{
    public class daLicitacionesActaFallo
    {
        public beLicitacionesActaFallo traerActaFallo_Licitaciones_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_ActaFallo_Licitaciones_x_IdLicitacion";
            beLicitacionesActaFallo obeLicitaciones = null;
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
                        //int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
                        //int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
                        //int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
                        //int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
                        //int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
                        //int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
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
                        int posDependencias = datard.GetOrdinal("Dependencias");
                        int posPartidas = datard.GetOrdinal("Partidas");
                        int posFolioRequisiciones = datard.GetOrdinal("FolioRequisiciones");
                        
                        obeLicitaciones = new beLicitacionesActaFallo();
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
                            //obeLicitaciones.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
                            //obeLicitaciones.FechaDisposicionBases = datard.GetDateTime(posFechaDisposicionBases);
                            //obeLicitaciones.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
                            //obeLicitaciones.FechaLimiteRespuestas = datard.GetDateTime(posFechaLimiteRespuestas);
                            //obeLicitaciones.FechaHoraAclaracionDudas = datard.GetDateTime(posFechaHoraAclaracionDudas);
                            //obeLicitaciones.FechaEnvioPropuestasTecEco = datard.GetDateTime(posFechaEnvioPropuestasTecEco);
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
                            obeLicitaciones.Dependencias = datard.GetString(posDependencias);
                            obeLicitaciones.Partidas = datard.GetString(posPartidas);
                            obeLicitaciones.FolioRequisiciones = datard.GetString(posFolioRequisiciones);
                            
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

        public List<beLicitacionesActaFallo> traerActaFallo_PropuestasTecnicaEconomica_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_ActaFallo_PropuestasTecnicaEconomica_x_IdLicitacion";
            List<beLicitacionesActaFallo> lbeLicitacionesDictamen = null;
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
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posOfertaTotal = datard.GetOrdinal("OfertaTotal");
                        int posNumLotes = datard.GetOrdinal("NumLotes");
                        int posTotalLotes = datard.GetOrdinal("TotalLotes");
                        int posLotesOfertados = datard.GetOrdinal("LotesOfertados");
                        int posLotesAsignados = datard.GetOrdinal("LotesAsignados");
                        int posMontoAsignado = datard.GetOrdinal("MontoAsignado");

                        int posCartaAdquisicionCumple = datard.GetOrdinal("CartaAdquisicionCumple");
                        int posCondicionEntregaAdquisicionCumple = datard.GetOrdinal("CondicionEntregaAdquisicionCumple");
                        int posCondicionPagoAdquisicionCumple = datard.GetOrdinal("CondicionPagoAdquisicionCumple");
                        int posManifiestoAdquisicionCumple = datard.GetOrdinal("ManifiestoAdquisicionCumple");

                        int posCartasAdqObservacion = datard.GetOrdinal("CartasAdqObservacion");
                        int posCondicionEntregaAdqObservacion = datard.GetOrdinal("CondicionEntregaAdqObservacion");
                        int posCondicionPagoAdqObservacion = datard.GetOrdinal("CondicionPagoAdqObservacion");
                        int posManifiestoAdqObservacion = datard.GetOrdinal("ManifiestoAdqObservacion");

                        lbeLicitacionesDictamen = new List<beLicitacionesActaFallo>();
                        beLicitacionesActaFallo obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesActaFallo();

                            obeLicitaciones.RazonSocial = datard.GetString(posRazonSocial);
                            obeLicitaciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.Dependencia = datard.GetString(posDependencia);
                            obeLicitaciones.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            obeLicitaciones.OfertaTotal = datard[posOfertaTotal] == DBNull.Value ? 0 : datard.GetDecimal(posOfertaTotal);
                            obeLicitaciones.NumLotes = datard[posNumLotes] == DBNull.Value ? 0 : datard.GetInt32(posNumLotes);
                            obeLicitaciones.TotalLotes = datard[posTotalLotes] == DBNull.Value ? 0 : datard.GetInt32(posTotalLotes);
                            obeLicitaciones.LotesOfertados = datard[posLotesOfertados] == DBNull.Value ? "" : datard.GetString(posLotesOfertados);
                            obeLicitaciones.LotesAsignados = datard[posLotesAsignados] == DBNull.Value ? "" : datard.GetString(posLotesAsignados);
                            obeLicitaciones.MontoAsignado = datard[posMontoAsignado] == DBNull.Value ? 0 : datard.GetDecimal(posMontoAsignado);

                            obeLicitaciones.CartaAdquisicionCumple = datard.GetBoolean(posCartaAdquisicionCumple);
                            obeLicitaciones.CondicionEntregaAdquisicionCumple = datard.GetBoolean(posCondicionEntregaAdquisicionCumple);
                            obeLicitaciones.CondicionPagoAdquisicionCumple = datard.GetBoolean(posCondicionPagoAdquisicionCumple);
                            obeLicitaciones.ManifiestoAdquisicionCumple = datard.GetBoolean(posManifiestoAdquisicionCumple);

                            obeLicitaciones.CartasAdqObservacion = datard.GetString(posCartasAdqObservacion);
                            obeLicitaciones.CondicionEntregaAdqObservacion = datard.GetString(posCondicionEntregaAdqObservacion);
                            obeLicitaciones.CondicionPagoAdqObservacion = datard.GetString(posCondicionPagoAdqObservacion);
                            obeLicitaciones.ManifiestoAdqObservacion = datard.GetString(posManifiestoAdqObservacion);

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

        public beLicitacionesActaFallo traerRep_ActaFallo_Licitaciones_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_ActaFallo_Licitaciones_x_IdLicitacion";
            beLicitacionesActaFallo obeLicitaciones = null;
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
                        //int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
                        //int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
                        //int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
                        //int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
                        //int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
                        //int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
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
                        int posDependencias = datard.GetOrdinal("Dependencias");
                        int posPartidas = datard.GetOrdinal("Partidas");
                        int posFolioRequisiciones = datard.GetOrdinal("FolioRequisiciones");

                        obeLicitaciones = new beLicitacionesActaFallo();
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
                            //obeLicitaciones.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
                            //obeLicitaciones.FechaDisposicionBases = datard.GetDateTime(posFechaDisposicionBases);
                            //obeLicitaciones.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
                            //obeLicitaciones.FechaLimiteRespuestas = datard.GetDateTime(posFechaLimiteRespuestas);
                            //obeLicitaciones.FechaHoraAclaracionDudas = datard.GetDateTime(posFechaHoraAclaracionDudas);
                            //obeLicitaciones.FechaEnvioPropuestasTecEco = datard.GetDateTime(posFechaEnvioPropuestasTecEco);
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
                            obeLicitaciones.Dependencias = datard.GetString(posDependencias);
                            obeLicitaciones.Partidas = datard.GetString(posPartidas);
                            obeLicitaciones.FolioRequisiciones = datard.GetString(posFolioRequisiciones);

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

        public List<beLicitacionesActaFallo> traerRep_ActaFallo_PropuestasTecnicaEconomica_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_ActaFallo_PropuestasTecnicaEconomica_x_IdLicitacion";
            List<beLicitacionesActaFallo> lbeLicitacionesDictamen = null;
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
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posOfertaTotal = datard.GetOrdinal("OfertaTotal");
                        int posNumLotes = datard.GetOrdinal("NumLotes");
                        int posTotalLotes = datard.GetOrdinal("TotalLotes");
                        int posLotesOfertados = datard.GetOrdinal("LotesOfertados");
                        int posLotesAsignados = datard.GetOrdinal("LotesAsignados");
                        int posMontoAsignado = datard.GetOrdinal("MontoAsignado");

                        int posCartaAdquisicionCumple = datard.GetOrdinal("CartaAdquisicionCumple");
                        int posCondicionEntregaAdquisicionCumple = datard.GetOrdinal("CondicionEntregaAdquisicionCumple");
                        int posCondicionPagoAdquisicionCumple = datard.GetOrdinal("CondicionPagoAdquisicionCumple");
                        int posManifiestoAdquisicionCumple = datard.GetOrdinal("ManifiestoAdquisicionCumple");

                        int posCartasAdqObservacion = datard.GetOrdinal("CartasAdqObservacion");
                        int posCondicionEntregaAdqObservacion = datard.GetOrdinal("CondicionEntregaAdqObservacion");
                        int posCondicionPagoAdqObservacion = datard.GetOrdinal("CondicionPagoAdqObservacion");
                        int posManifiestoAdqObservacion = datard.GetOrdinal("ManifiestoAdqObservacion");

                        lbeLicitacionesDictamen = new List<beLicitacionesActaFallo>();
                        beLicitacionesActaFallo obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesActaFallo();

                            obeLicitaciones.RazonSocial = datard.GetString(posRazonSocial);
                            obeLicitaciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.Dependencia = datard.GetString(posDependencia);
                            obeLicitaciones.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            obeLicitaciones.OfertaTotal = datard[posOfertaTotal] == DBNull.Value ? 0 : datard.GetDecimal(posOfertaTotal);
                            obeLicitaciones.NumLotes = datard[posNumLotes] == DBNull.Value ? 0 : datard.GetInt32(posNumLotes);
                            obeLicitaciones.TotalLotes = datard[posTotalLotes] == DBNull.Value ? 0 : datard.GetInt32(posTotalLotes);
                            obeLicitaciones.LotesOfertados = datard[posLotesOfertados] == DBNull.Value ? "" : datard.GetString(posLotesOfertados);
                            obeLicitaciones.LotesAsignados = datard[posLotesAsignados] == DBNull.Value ? "" : datard.GetString(posLotesAsignados);
                            obeLicitaciones.MontoAsignado = datard[posMontoAsignado] == DBNull.Value ? 0 : datard.GetDecimal(posMontoAsignado);

                            obeLicitaciones.CartaAdquisicionCumple = datard.GetBoolean(posCartaAdquisicionCumple);
                            obeLicitaciones.CondicionEntregaAdquisicionCumple = datard.GetBoolean(posCondicionEntregaAdquisicionCumple);
                            obeLicitaciones.CondicionPagoAdquisicionCumple = datard.GetBoolean(posCondicionPagoAdquisicionCumple);
                            obeLicitaciones.ManifiestoAdquisicionCumple = datard.GetBoolean(posManifiestoAdquisicionCumple);

                            obeLicitaciones.CartasAdqObservacion = datard.GetString(posCartasAdqObservacion);
                            obeLicitaciones.CondicionEntregaAdqObservacion = datard.GetString(posCondicionEntregaAdqObservacion);
                            obeLicitaciones.CondicionPagoAdqObservacion = datard.GetString(posCondicionPagoAdqObservacion);
                            obeLicitaciones.ManifiestoAdqObservacion = datard.GetString(posManifiestoAdqObservacion);

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
