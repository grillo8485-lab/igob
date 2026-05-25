using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daLicitacionesDictamen
    {
        public beLicitacionesDictamen traerDictamen_Licitaciones_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Dictamen_Licitaciones_x_IdLicitacion";
            beLicitacionesDictamen obeLicitaciones = null;
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


                        obeLicitaciones = new beLicitacionesDictamen();
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

        public List<beLicitacionesDictamen> traerDictamen_PropuestasTecnicaEconomica_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Dictamen_PropuestasTecnicaEconomica_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
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

                        int posCartaAdquisicionCumple = datard.GetOrdinal("CartaAdquisicionCumple");
                        int posCondicionEntregaAdquisicionCumple = datard.GetOrdinal("CondicionEntregaAdquisicionCumple");
                        int posCondicionPagoAdquisicionCumple = datard.GetOrdinal("CondicionPagoAdquisicionCumple");
                        int posManifiestoAdquisicionCumple = datard.GetOrdinal("ManifiestoAdquisicionCumple");

                        int posCartaFundamento = datard.GetOrdinal("CartaFundamento");
                        int posCondicionEntregaFundamento = datard.GetOrdinal("CondicionEntregaFundamento");
                        int posCondicionPagoFundamento = datard.GetOrdinal("CondicionPagoFundamento");
                        int posManifiestoFundamento = datard.GetOrdinal("ManifiestoFundamento");

                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posOfertaTotal = datard.GetOrdinal("OfertaTotal");

                        int posIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
                        int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
                        int posFechaLimite = datard.GetOrdinal("FechaLimite");
                        int posTipoEntrega = datard.GetOrdinal("TipoEntrega");
                        int posNotaEspecial = datard.GetOrdinal("NotaEspecial");
                        int posPlazozTiempoEntrega = datard.GetOrdinal("PlazozTiempoEntrega");
                        int posTipoDiaEntrega = datard.GetOrdinal("TipoDiaEntrega");
                        int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");

                        int posIdRequisicionCondicionPago = datard.GetOrdinal("IdRequisicionCondicionPago");
                        int posPlazoPagoCantidad = datard.GetOrdinal("PlazoPagoCantidad");
                        int posAnticipo = datard.GetOrdinal("Anticipo");
                        int posPorcentajeAnticipo = datard.GetOrdinal("PorcentajeAnticipo");
                        int posNumeroPagos = datard.GetOrdinal("NumeroPagos");
                        int posImporteAnticipo = datard.GetOrdinal("ImporteAnticipo");
                        int posImporteTotalPagos = datard.GetOrdinal("ImporteTotalPagos");

                        int posTipoCondicionPago = datard.GetOrdinal("TipoCondicionPago");
                        int posPeriodicidad = datard.GetOrdinal("Periodicidad");
                        int posPlazosTiempoPago = datard.GetOrdinal("PlazosTiempoPago");
                        int posTipoDiaPago = datard.GetOrdinal("TipoDiaPago");
                        int posSumaTotalPagos = datard.GetOrdinal("SumaTotalPagos");

                        int posInfraestructura = datard.GetOrdinal("Infraestructura");
                        int posAnnioExperiencia = datard.GetOrdinal("AnnioExperiencia");
                        int posNumeroEmpleados = datard.GetOrdinal("NumeroEmpleados");
                        int posDomicilio = datard.GetOrdinal("Domicilio");
                        int posCapitalContable = datard.GetOrdinal("CapitalContable");


                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.RazonSocial = datard.GetString(posRazonSocial);
                            obeLicitaciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);

                            obeLicitaciones.CartaAdquisicionCumple = datard[posCartaAdquisicionCumple] == DBNull.Value ? false : datard.GetBoolean(posCartaAdquisicionCumple);
                            obeLicitaciones.CondicionEntregaAdquisicionCumple = datard[posCondicionEntregaAdquisicionCumple] == DBNull.Value ? false : datard.GetBoolean(posCondicionEntregaAdquisicionCumple);
                            obeLicitaciones.CondicionPagoAdquisicionCumple = datard[posCondicionPagoAdquisicionCumple] == DBNull.Value ? false : datard.GetBoolean(posCondicionPagoAdquisicionCumple);
                            obeLicitaciones.ManifiestoAdquisicionCumple = datard[posManifiestoAdquisicionCumple] == DBNull.Value ? false : datard.GetBoolean(posManifiestoAdquisicionCumple);

                            obeLicitaciones.CartaFundamento = datard[posCartaFundamento] == DBNull.Value ? "" : datard.GetString(posCartaFundamento);
                            obeLicitaciones.CondicionEntregaFundamento = datard[posCondicionEntregaFundamento] == DBNull.Value ? "" : datard.GetString(posCondicionEntregaFundamento);
                            obeLicitaciones.CondicionPagoFundamento = datard[posCondicionPagoFundamento] == DBNull.Value ? "" : datard.GetString(posCondicionPagoFundamento);
                            obeLicitaciones.ManifiestoFundamento = datard[posManifiestoFundamento] == DBNull.Value ? "" : datard.GetString(posManifiestoFundamento);

                            obeLicitaciones.Dependencia = datard[posDependencia] == DBNull.Value ? "" : datard.GetString(posDependencia);
                            obeLicitaciones.FormaAbastecimiento = datard[posFormaAbastecimiento] == DBNull.Value ? "" : datard.GetString(posFormaAbastecimiento);
                            obeLicitaciones.OfertaTotal = datard[posOfertaTotal] == DBNull.Value ? 0 : datard.GetDecimal(posOfertaTotal);

                            obeLicitaciones.IdRequisicionCondicionEntrega = datard.GetInt32(posIdRequisicionCondicionEntrega);
                            obeLicitaciones.PlazoEntregaCantidad = datard.GetInt32(posPlazoEntregaCantidad);
                            obeLicitaciones.FechaLimite = datard.GetDateTime(posFechaLimite);
                            obeLicitaciones.TipoEntrega = datard.GetString(posTipoEntrega);
                            obeLicitaciones.PlazozTiempoEntrega = datard.GetString(posPlazozTiempoEntrega);
                            obeLicitaciones.NotaEspecial = datard.GetString(posNotaEspecial);
                            obeLicitaciones.TipoDiaEntrega = datard.GetString(posTipoDiaEntrega);
                            obeLicitaciones.PlazoEntrega = datard.GetString(posPlazoEntrega);

                            obeLicitaciones.IdRequisicionCondicionPago = datard.GetInt32(posIdRequisicionCondicionPago);
                            obeLicitaciones.PlazoPagoCantidad = datard.GetInt32(posPlazoPagoCantidad);
                            obeLicitaciones.Anticipo = datard.GetBoolean(posAnticipo);
                            obeLicitaciones.PorcentajeAnticipo = datard.GetDecimal(posPorcentajeAnticipo);
                            obeLicitaciones.NumeroPagos = datard.GetInt32(posNumeroPagos);
                            obeLicitaciones.ImporteAnticipo = datard.GetDecimal(posImporteAnticipo);
                            obeLicitaciones.ImporteTotalPagos = datard.GetDecimal(posImporteTotalPagos);

                            obeLicitaciones.TipoCondicionPago = datard.GetString(posTipoCondicionPago);
                            obeLicitaciones.Periodicidad = datard.GetString(posPeriodicidad);
                            obeLicitaciones.PlazosTiempoPago = datard.GetString(posPlazosTiempoPago);
                            obeLicitaciones.TipoDiaPago = datard.GetString(posTipoDiaPago);
                            obeLicitaciones.SumaTotalPagos = datard.GetDecimal(posSumaTotalPagos);

                            obeLicitaciones.Infraestructura = datard[posInfraestructura] ==DBNull.Value?"": datard.GetString(posInfraestructura);
                            obeLicitaciones.AnnioExperiencia = datard[posAnnioExperiencia] == DBNull.Value ? 0 : datard.GetInt32(posAnnioExperiencia);
                            obeLicitaciones.NumeroEmpleados = datard[posNumeroEmpleados] == DBNull.Value ? 0 : datard.GetInt32(posNumeroEmpleados);
                            obeLicitaciones.Domicilio = datard[posDomicilio] == DBNull.Value ? "" : datard.GetString(posDomicilio);
                            obeLicitaciones.CapitalContable = datard[posCapitalContable] == DBNull.Value ? 0 : datard.GetDecimal(posCapitalContable);

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

        public List<beLicitacionesDictamen> traerDictamen_PropuestasTecnicaEconomicaLotes_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Dictamen_PropuestasTecnicaEconomicaLotes_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPropuestaTecnicaEconomica = datard.GetOrdinal("IdPropuestaTecnicaEconomica");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posLoteOfertado = datard.GetOrdinal("LoteOfertado");
                        int posAdquisicionCumple = datard.GetOrdinal("AdquisicionCumple");
                        int posFundamentoLegal = datard.GetOrdinal("FundamentoLegal");
                        int posImporteOfertado = datard.GetOrdinal("ImporteOfertado");

                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPantone = datard.GetOrdinal("Pantone");

                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.IdPropuestaTecnicaEconomica = datard.GetInt32(posIdPropuestaTecnicaEconomica);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.LoteOfertado = datard.GetBoolean(posLoteOfertado);
                            obeLicitaciones.AdquisicionCumple = datard[posAdquisicionCumple] ==DBNull.Value?false: datard.GetBoolean(posAdquisicionCumple);
                            obeLicitaciones.FundamentoLegal = datard[posAdquisicionCumple] == DBNull.Value ? "" : datard.GetString(posFundamentoLegal);
                            obeLicitaciones.ImporteOfertado = datard.GetDecimal(posImporteOfertado);

                            obeLicitaciones.NoLote = datard.GetInt32(posNoLote);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);
                            obeLicitaciones.Pantone = datard.GetString(posPantone);

                            obeLicitaciones.BienServicio = datard.GetString(posBienServicio);
                            obeLicitaciones.UnidadMedida = datard.GetString(posUnidadMedida);

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

        public List<beLicitacionesDictamen> traerDictamen_Cartas_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Dictamen_Cartas_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdProveedorCarta = datard.GetOrdinal("IdProveedorCarta");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posAceptacionCarta = datard.GetOrdinal("AceptacionCarta");
                        int posInciso = datard.GetOrdinal("Inciso");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCarta = datard.GetOrdinal("Carta");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.IdProveedorCarta = datard.GetInt32(posIdProveedorCarta);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.AceptacionCarta = datard.GetBoolean(posAceptacionCarta);
                            obeLicitaciones.Inciso = datard.GetString(posInciso);
                            obeLicitaciones.Nombre = datard.GetString(posNombre);
                            obeLicitaciones.Carta = datard.GetString(posCarta);

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

        public List<beLicitacionesDictamen> traerDictamen_RequisicionesCondicionesEntregasDetalles_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Dictamen_RequisicionesCondicionesEntregasDetalles_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posLugar = datard.GetOrdinal("Lugar");
                        int posDireccion = datard.GetOrdinal("Direccion");
                        int posNoLote = datard.GetOrdinal("NoLote");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.IdCondicionEntregaDetalle = datard.GetInt32(posIdCondicionEntregaDetalle);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);
                            obeLicitaciones.Lugar = datard.GetString(posLugar);
                            obeLicitaciones.Direccion = datard.GetString(posDireccion);
                            obeLicitaciones.NoLote = datard.GetInt32(posNoLote);

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

        /*
        public List<beLicitacionesDictamen> traerDictamen_RequisicionesCondicionesPagosDetalles_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Dictamen_RequisicionesCondicionesPagosDetalles_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRqCondicionPagoDetalle = datard.GetOrdinal("IdRqCondicionPagoDetalle");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posNumeroPago = datard.GetOrdinal("NumeroPago");
                        int posImportePago = datard.GetOrdinal("ImportePago");                        
                        int posPorcentajePago = datard.GetOrdinal("PorcentajePago");
                        int posFechaPago = datard.GetOrdinal("FechaPago");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.IdRqCondicionPagoDetalle = datard.GetInt32(posIdRqCondicionPagoDetalle);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.NumeroPago = datard.GetInt32(posNumeroPago);
                            obeLicitaciones.ImportePago = datard.GetDecimal(posImportePago);                            
                            obeLicitaciones.PorcentajePago = datard.GetDecimal(posPorcentajePago);
                            obeLicitaciones.FechaPago = datard.GetDateTime(posFechaPago);

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
        */

        public List<beLicitacionesDictamen> traerDictamen_ManifiestoProveedoresClientes_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Dictamen_ManifiestoProveedoresClientes_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posNombreCliente = datard.GetOrdinal("NombreCliente");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posDirecionCliente = datard.GetOrdinal("DirecionCliente");
                        int posTelefonoCliente = datard.GetOrdinal("TelefonoCliente");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.NombreCliente = datard.GetString(posNombreCliente);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.DirecionCliente = datard.GetString(posDirecionCliente);
                            obeLicitaciones.TelefonoCliente = datard.GetString(posTelefonoCliente);

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

        public List<beLicitacionesDictamen> traerDictamen_ManifiestoProveedoresDeclaratorias_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Dictamen_ManifiestoProveedoresDeclaratorias_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posAceptacion = datard.GetOrdinal("Aceptacion");
                        int posManifiesto = datard.GetOrdinal("Manifiesto");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.Aceptacion = datard.GetBoolean(posAceptacion);
                            obeLicitaciones.Manifiesto = datard.GetString(posManifiesto);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);

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

        /* IMPRESIONES */

        public beLicitacionesDictamen traerRep_Dictamen_Licitaciones_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Dictamen_Licitaciones_x_IdLicitacion";
            beLicitacionesDictamen obeLicitaciones = null;
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


                        obeLicitaciones = new beLicitacionesDictamen();
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

        public List<beLicitacionesDictamen> traerRep_Dictamen_PropuestasTecnicaEconomica_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Dictamen_PropuestasTecnicaEconomica_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
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

                        int posCartaAdquisicionCumple = datard.GetOrdinal("CartaAdquisicionCumple");
                        int posCondicionEntregaAdquisicionCumple = datard.GetOrdinal("CondicionEntregaAdquisicionCumple");
                        int posCondicionPagoAdquisicionCumple = datard.GetOrdinal("CondicionPagoAdquisicionCumple");
                        int posManifiestoAdquisicionCumple = datard.GetOrdinal("ManifiestoAdquisicionCumple");

                        int posCartaFundamento = datard.GetOrdinal("CartaFundamento");
                        int posCondicionEntregaFundamento = datard.GetOrdinal("CondicionEntregaFundamento");
                        int posCondicionPagoFundamento = datard.GetOrdinal("CondicionPagoFundamento");
                        int posManifiestoFundamento = datard.GetOrdinal("ManifiestoFundamento");

                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posOfertaTotal = datard.GetOrdinal("OfertaTotal");

                        int posIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
                        int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
                        int posFechaLimite = datard.GetOrdinal("FechaLimite");
                        int posTipoEntrega = datard.GetOrdinal("TipoEntrega");
                        int posNotaEspecial = datard.GetOrdinal("NotaEspecial");
                        int posPlazozTiempoEntrega = datard.GetOrdinal("PlazozTiempoEntrega");
                        int posTipoDiaEntrega = datard.GetOrdinal("TipoDiaEntrega");
                        int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");

                        int posIdRequisicionCondicionPago = datard.GetOrdinal("IdRequisicionCondicionPago");
                        int posPlazoPagoCantidad = datard.GetOrdinal("PlazoPagoCantidad");
                        int posAnticipo = datard.GetOrdinal("Anticipo");
                        int posPorcentajeAnticipo = datard.GetOrdinal("PorcentajeAnticipo");
                        int posNumeroPagos = datard.GetOrdinal("NumeroPagos");
                        int posImporteAnticipo = datard.GetOrdinal("ImporteAnticipo");
                        int posImporteTotalPagos = datard.GetOrdinal("ImporteTotalPagos");

                        int posTipoCondicionPago = datard.GetOrdinal("TipoCondicionPago");
                        int posPeriodicidad = datard.GetOrdinal("Periodicidad");
                        int posPlazosTiempoPago = datard.GetOrdinal("PlazosTiempoPago");
                        int posTipoDiaPago = datard.GetOrdinal("TipoDiaPago");
                        int posSumaTotalPagos = datard.GetOrdinal("SumaTotalPagos");

                        int posInfraestructura = datard.GetOrdinal("Infraestructura");
                        int posAnnioExperiencia = datard.GetOrdinal("AnnioExperiencia");
                        int posNumeroEmpleados = datard.GetOrdinal("NumeroEmpleados");
                        int posDomicilio = datard.GetOrdinal("Domicilio");
                        int posCapitalContable = datard.GetOrdinal("CapitalContable");


                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.RazonSocial = datard.GetString(posRazonSocial);
                            obeLicitaciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);

                            obeLicitaciones.CartaAdquisicionCumple = datard.GetBoolean(posCartaAdquisicionCumple);
                            obeLicitaciones.CondicionEntregaAdquisicionCumple = datard.GetBoolean(posCondicionEntregaAdquisicionCumple);
                            obeLicitaciones.CondicionPagoAdquisicionCumple = datard.GetBoolean(posCondicionPagoAdquisicionCumple);
                            obeLicitaciones.ManifiestoAdquisicionCumple = datard.GetBoolean(posManifiestoAdquisicionCumple);

                            obeLicitaciones.CartaFundamento = datard.GetString(posCartaFundamento);
                            obeLicitaciones.CondicionEntregaFundamento = datard.GetString(posCondicionEntregaFundamento);
                            obeLicitaciones.CondicionPagoFundamento = datard.GetString(posCondicionPagoFundamento);
                            obeLicitaciones.ManifiestoFundamento = datard.GetString(posManifiestoFundamento);

                            obeLicitaciones.Dependencia = datard.GetString(posDependencia);
                            obeLicitaciones.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            obeLicitaciones.OfertaTotal = datard[posOfertaTotal] == DBNull.Value ? 0 : datard.GetDecimal(posOfertaTotal);

                            obeLicitaciones.IdRequisicionCondicionEntrega = datard.GetInt32(posIdRequisicionCondicionEntrega);
                            obeLicitaciones.PlazoEntregaCantidad = datard.GetInt32(posPlazoEntregaCantidad);
                            obeLicitaciones.FechaLimite = datard.GetDateTime(posFechaLimite);
                            obeLicitaciones.TipoEntrega = datard.GetString(posTipoEntrega);
                            obeLicitaciones.PlazozTiempoEntrega = datard.GetString(posPlazozTiempoEntrega);
                            obeLicitaciones.NotaEspecial = datard.GetString(posNotaEspecial);
                            obeLicitaciones.TipoDiaEntrega = datard.GetString(posTipoDiaEntrega);
                            obeLicitaciones.PlazoEntrega = datard.GetString(posPlazoEntrega);

                            obeLicitaciones.IdRequisicionCondicionPago = datard.GetInt32(posIdRequisicionCondicionPago);
                            obeLicitaciones.PlazoPagoCantidad = datard.GetInt32(posPlazoPagoCantidad);
                            obeLicitaciones.Anticipo = datard.GetBoolean(posAnticipo);
                            obeLicitaciones.PorcentajeAnticipo = datard.GetDecimal(posPorcentajeAnticipo);
                            obeLicitaciones.NumeroPagos = datard.GetInt32(posNumeroPagos);
                            obeLicitaciones.ImporteAnticipo = datard.GetDecimal(posImporteAnticipo);
                            obeLicitaciones.ImporteTotalPagos = datard.GetDecimal(posImporteTotalPagos);

                            obeLicitaciones.TipoCondicionPago = datard.GetString(posTipoCondicionPago);
                            obeLicitaciones.Periodicidad = datard.GetString(posPeriodicidad);
                            obeLicitaciones.PlazosTiempoPago = datard.GetString(posPlazosTiempoPago);
                            obeLicitaciones.TipoDiaPago = datard.GetString(posTipoDiaPago);
                            obeLicitaciones.SumaTotalPagos = datard.GetDecimal(posSumaTotalPagos);

                            obeLicitaciones.Infraestructura = datard[posInfraestructura] == DBNull.Value ? "" : datard.GetString(posInfraestructura);
                            obeLicitaciones.AnnioExperiencia = datard[posAnnioExperiencia] == DBNull.Value ? 0 : datard.GetInt32(posAnnioExperiencia);
                            obeLicitaciones.NumeroEmpleados = datard[posNumeroEmpleados] == DBNull.Value ? 0 : datard.GetInt32(posNumeroEmpleados);
                            obeLicitaciones.Domicilio = datard[posDomicilio] == DBNull.Value ? "" : datard.GetString(posDomicilio);
                            obeLicitaciones.CapitalContable = datard[posCapitalContable] == DBNull.Value ? 0 : datard.GetDecimal(posCapitalContable);

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

        public List<beLicitacionesDictamen> traerRep_Dictamen_PropuestasTecnicaEconomicaLotes_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Dictamen_PropuestasTecnicaEconomicaLotes_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPropuestaTecnicaEconomica = datard.GetOrdinal("IdPropuestaTecnicaEconomica");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posLoteOfertado = datard.GetOrdinal("LoteOfertado");
                        int posAdquisicionCumple = datard.GetOrdinal("AdquisicionCumple");
                        int posFundamentoLegal = datard.GetOrdinal("FundamentoLegal");
                        int posImporteOfertado = datard.GetOrdinal("ImporteOfertado");

                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPantone = datard.GetOrdinal("Pantone");

                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.IdPropuestaTecnicaEconomica = datard.GetInt32(posIdPropuestaTecnicaEconomica);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.LoteOfertado = datard.GetBoolean(posLoteOfertado);
                            obeLicitaciones.AdquisicionCumple = datard.GetBoolean(posAdquisicionCumple);
                            obeLicitaciones.FundamentoLegal = datard.GetString(posFundamentoLegal);
                            obeLicitaciones.ImporteOfertado = datard.GetDecimal(posImporteOfertado);

                            obeLicitaciones.NoLote = datard.GetInt32(posNoLote);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);
                            obeLicitaciones.Pantone = datard.GetString(posPantone);

                            obeLicitaciones.BienServicio = datard.GetString(posBienServicio);
                            obeLicitaciones.UnidadMedida = datard.GetString(posUnidadMedida);

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

        public List<beLicitacionesDictamen> traerRep_Dictamen_Cartas_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Dictamen_Cartas_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdProveedorCarta = datard.GetOrdinal("IdProveedorCarta");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posAceptacionCarta = datard.GetOrdinal("AceptacionCarta");
                        int posInciso = datard.GetOrdinal("Inciso");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCarta = datard.GetOrdinal("Carta");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.IdProveedorCarta = datard.GetInt32(posIdProveedorCarta);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.AceptacionCarta = datard.GetBoolean(posAceptacionCarta);
                            obeLicitaciones.Inciso = datard.GetString(posInciso);
                            obeLicitaciones.Nombre = datard.GetString(posNombre);
                            obeLicitaciones.Carta = datard.GetString(posCarta);

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

        public List<beLicitacionesDictamen> traerRep_Dictamen_RequisicionesCondicionesEntregasDetalles_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Dictamen_RequisicionesCondicionesEntregasDetalles_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posLugar = datard.GetOrdinal("Lugar");
                        int posDireccion = datard.GetOrdinal("Direccion");
                        int posNoLote = datard.GetOrdinal("NoLote");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.IdCondicionEntregaDetalle = datard.GetInt32(posIdCondicionEntregaDetalle);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);
                            obeLicitaciones.Lugar = datard.GetString(posLugar);
                            obeLicitaciones.Direccion = datard.GetString(posDireccion);
                            obeLicitaciones.NoLote = datard.GetInt32(posNoLote);

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

        public List<beLicitacionesDictamen> traerRep_Dictamen_RequisicionesCondicionesPagosDetalles_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Dictamen_RequisicionesCondicionesPagosDetalles_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRqCondicionPagoDetalle = datard.GetOrdinal("IdRqCondicionPagoDetalle");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posNumeroPago = datard.GetOrdinal("NumeroPago");
                        int posImportePago = datard.GetOrdinal("ImportePago");
                        int posPorcentajePago = datard.GetOrdinal("PorcentajePago");
                        int posFechaPago = datard.GetOrdinal("FechaPago");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.IdRqCondicionPagoDetalle = datard.GetInt32(posIdRqCondicionPagoDetalle);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.NumeroPago = datard.GetInt32(posNumeroPago);
                            obeLicitaciones.ImportePago = datard.GetDecimal(posImportePago);
                            obeLicitaciones.PorcentajePago = datard.GetDecimal(posPorcentajePago);
                            obeLicitaciones.FechaPago = datard.GetDateTime(posFechaPago);

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

        public List<beLicitacionesDictamen> traerRep_Dictamen_ManifiestoProveedoresClientes_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Dictamen_ManifiestoProveedoresClientes_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posNombreCliente = datard.GetOrdinal("NombreCliente");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posDirecionCliente = datard.GetOrdinal("DirecionCliente");
                        int posTelefonoCliente = datard.GetOrdinal("TelefonoCliente");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.NombreCliente = datard.GetString(posNombreCliente);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeLicitaciones.DirecionCliente = datard.GetString(posDirecionCliente);
                            obeLicitaciones.TelefonoCliente = datard.GetString(posTelefonoCliente);

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

        public List<beLicitacionesDictamen> traerRep_Dictamen_ManifiestoProveedoresDeclaratorias_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Dictamen_ManifiestoProveedoresDeclaratorias_x_IdLicitacion";
            List<beLicitacionesDictamen> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posAceptacion = datard.GetOrdinal("Aceptacion");
                        int posManifiesto = datard.GetOrdinal("Manifiesto");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");

                        lbeLicitacionesDictamen = new List<beLicitacionesDictamen>();
                        beLicitacionesDictamen obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesDictamen();

                            obeLicitaciones.Aceptacion = datard.GetBoolean(posAceptacion);
                            obeLicitaciones.Manifiesto = datard.GetString(posManifiesto);
                            obeLicitaciones.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);

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
