using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRequisicionesSolicitud
    {
        public beRequisicionesSolicitud traerRequisiciones_x_IdRequisicion_Solicitud(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_Rep_Solicitud_Requisiciones_x_IdRequisicion";
            beRequisicionesSolicitud obeRequisiciones = new beRequisicionesSolicitud(); ;
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

                        //get all 2018-09-11
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posRfc = datard.GetOrdinal("Rfc");
                        int posCalle = datard.GetOrdinal("Calle");
                        int posNoExterior = datard.GetOrdinal("NoExterior");
                        int posNoInterior = datard.GetOrdinal("NoInterior");
                        int posColonia = datard.GetOrdinal("Colonia");
                        int posLocalidad = datard.GetOrdinal("Localidad");
                        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int posEmail = datard.GetOrdinal("Email");
                        int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
                        int posMunicipio = datard.GetOrdinal("Municipio");
                        int posClaveEstado = datard.GetOrdinal("ClaveEstado");
                        int posEstado = datard.GetOrdinal("Estado");
                        int posIdPais = datard.GetOrdinal("IdPais");
                        int posPais = datard.GetOrdinal("Pais");
                        int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posFormaAbastecimiento = datard.GetOrdinal("FormaAbastecimiento");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        
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

                            //get all 2018-09-11
                            obeRequisiciones.Dependencia = datard.GetString(posDependencia);
                            obeRequisiciones.Rfc = datard.GetString(posRfc);
                            obeRequisiciones.Calle = datard.GetString(posCalle);
                            obeRequisiciones.NoExterior = datard.GetString(posNoExterior);
                            obeRequisiciones.NoInterior = datard.GetString(posNoInterior);
                            obeRequisiciones.Colonia = datard.GetString(posColonia);
                            obeRequisiciones.Localidad = datard.GetString(posLocalidad);
                            obeRequisiciones.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeRequisiciones.Email = datard.GetString(posEmail);
                            obeRequisiciones.IdMunicipio = datard.GetString(posIdMunicipio);
                            obeRequisiciones.Municipio = datard.GetString(posMunicipio);
                            obeRequisiciones.ClaveEstado = datard.GetString(posClaveEstado);
                            obeRequisiciones.Estado = datard.GetString(posEstado);
                            obeRequisiciones.IdPais = datard.GetInt32(posIdPais);
                            obeRequisiciones.Pais = datard.GetString(posPais);
                            obeRequisiciones.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            obeRequisiciones.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            obeRequisiciones.Tiempo = datard.GetString(posTiempo);
                            obeRequisiciones.FormaAbastecimiento = datard.GetString(posFormaAbastecimiento);
                            obeRequisiciones.Partida = datard.GetString(posPartida);
                            obeRequisiciones.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            obeRequisiciones.Capitulo = datard.GetString(posCapitulo);
                            obeRequisiciones.Ejercicio = datard.GetInt32(posEjercicio);
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

        public List<beRequisicionesSolicitud> traerRequisicionesLiquidez_x_IdRequisicion_Solicitud(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_Rep_Solicitud_RequisicionesLiquidez_x_IdRequisicion";
            List<beRequisicionesSolicitud> lbeRequisicionesLiquidez = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicionLiquidez = datard.GetOrdinal("IdRequisicionLiquidez");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdCuentaBancaria = datard.GetOrdinal("IdCuentaBancaria");
                        int posNumeroOperacion = datard.GetOrdinal("NumeroOperacion");
                        int posSaldoCuenta = datard.GetOrdinal("SaldoCuenta");
                        int posSaldoIgob = datard.GetOrdinal("SaldoIgob");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posFechaDeposito = datard.GetOrdinal("FechaDeposito");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

                        int posNumeroCuenta = datard.GetOrdinal("NumeroCuenta");
                        int posNombreCuenta = datard.GetOrdinal("NombreCuenta");
                        int posMontoDisponible = datard.GetOrdinal("MontoDisponible");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posIdBanco = datard.GetOrdinal("IdBanco");
                        int posNombreCorto = datard.GetOrdinal("NombreCorto");

                        lbeRequisicionesLiquidez = new List<beRequisicionesSolicitud>();
                        beRequisicionesSolicitud obeRequisicionesLiquidez;
                        while (datard.Read())
                        {
                            obeRequisicionesLiquidez = new beRequisicionesSolicitud();
                            obeRequisicionesLiquidez.IdRequisicionLiquidez = datard.GetInt32(posIdRequisicionLiquidez);
                            obeRequisicionesLiquidez.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLiquidez.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisicionesLiquidez.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeRequisicionesLiquidez.IdCuentaBancaria = datard.GetInt32(posIdCuentaBancaria);
                            obeRequisicionesLiquidez.NumeroOperacion = datard.GetString(posNumeroOperacion);
                            obeRequisicionesLiquidez.SaldoCuenta = datard.GetDecimal(posSaldoCuenta);
                            obeRequisicionesLiquidez.SaldoIgob = datard.GetDecimal(posSaldoIgob);
                            obeRequisicionesLiquidez.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeRequisicionesLiquidez.FechaDeposito = datard.GetDateTime(posFechaDeposito);
                            obeRequisicionesLiquidez.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesLiquidez.FechaRegistro = datard.GetDateTime(posFechaRegistro);

                            obeRequisicionesLiquidez.NumeroCuenta = datard.GetString(posNumeroCuenta);
                            obeRequisicionesLiquidez.NombreCuenta = datard.GetString(posNombreCuenta);
                            obeRequisicionesLiquidez.MontoDisponible = datard.GetDecimal(posMontoDisponible);
                            obeRequisicionesLiquidez.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            obeRequisicionesLiquidez.IdBanco = datard.GetInt32(posIdBanco);
                            obeRequisicionesLiquidez.NombreCorto = datard.GetString(posNombreCorto);

                            lbeRequisicionesLiquidez.Add(obeRequisicionesLiquidez);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLiquidez;
            }
        }

        public List<beRequisicionesSolicitud> traerRequisicionesLotes_x_IdRequisicion_Solicitud(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_Rep_Solicitud_RequisicionesLotes_x_IdRequisicion";
            List<beRequisicionesSolicitud> lbeRequisicionesLotes = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPantone = datard.GetOrdinal("Pantone");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posImporteMesnsualCImpuesto = datard.GetOrdinal("ImporteMesnsualCImpuesto");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");
                        int posTotal = datard.GetOrdinal("Total");
                        int posMesInicial = datard.GetOrdinal("MesInicial");
                        int posMesFinal = datard.GetOrdinal("MesFinal");
                        int posFrecuencia = datard.GetOrdinal("Frecuencia");
                        int posIdMuestra = datard.GetOrdinal("IdMuestra");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");

                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIdTipoProducto = datard.GetOrdinal("IdTipoProducto");
                        int posTipoProducto = datard.GetOrdinal("TipoProducto");
                        int posIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        lbeRequisicionesLotes = new List<beRequisicionesSolicitud>();
                        beRequisicionesSolicitud obeRequisicionesLotes;
                        while (datard.Read())
                        {
                            obeRequisicionesLotes = new beRequisicionesSolicitud();
                            obeRequisicionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeRequisicionesLotes.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeRequisicionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeRequisicionesLotes.Pantone = datard.GetString(posPantone);
                            obeRequisicionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeRequisicionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeRequisicionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeRequisicionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeRequisicionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeRequisicionesLotes.ImporteMesnsualCImpuesto = datard.GetDecimal(posImporteMesnsualCImpuesto);
                            obeRequisicionesLotes.MesesServicio = datard.GetInt32(posMesesServicio);
                            obeRequisicionesLotes.Total = datard.GetDecimal(posTotal);
                            obeRequisicionesLotes.MesInicial = datard.GetInt32(posMesInicial);
                            obeRequisicionesLotes.MesFinal = datard.GetInt32(posMesFinal);
                            obeRequisicionesLotes.Frecuencia = datard.GetInt32(posFrecuencia);
                            obeRequisicionesLotes.IdMuestra = datard.GetInt32(posIdMuestra);
                            obeRequisicionesLotes.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRequisicionesLotes.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);

                            obeRequisicionesLotes.Descripcion = datard.GetString(posDescripcion);
                            obeRequisicionesLotes.IdTipoProducto = datard.GetInt32(posIdTipoProducto);
                            obeRequisicionesLotes.TipoProducto = datard.GetString(posTipoProducto);
                            obeRequisicionesLotes.IdUnidadMedida = datard.GetInt32(posIdUnidadMedida);
                            obeRequisicionesLotes.UnidadMedida = datard.GetString(posUnidadMedida);

                            lbeRequisicionesLotes.Add(obeRequisicionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }

        public beRequisicionesSolicitud traerRequisicionesCondicionesEntregas_x_IdRequisicion_Solicitud(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_Rep_Solicitud_RequisicionesCondicionesEntregas_x_IdRequisicion";
            beRequisicionesSolicitud obeRequisicionesCondicionesEntregas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
                        int posIdPlazoEntegra = datard.GetOrdinal("IdPlazoEntegra");
                        int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
                        int posFechaLimite = datard.GetOrdinal("FechaLimite");
                        int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posNotaEspecial = datard.GetOrdinal("NotaEspecial");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");

                        int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");

                        obeRequisicionesCondicionesEntregas = new beRequisicionesSolicitud();
                        while (datard.Read())
                        {
                            obeRequisicionesCondicionesEntregas.IdRequisicionCondicionEntrega = datard.GetInt32(posIdRequisicionCondicionEntrega);
                            obeRequisicionesCondicionesEntregas.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesCondicionesEntregas.IdTipoDia = datard.GetInt32(posIdTipoDia);
                            obeRequisicionesCondicionesEntregas.IdPlazoEntegra = datard.GetInt32(posIdPlazoEntegra);
                            obeRequisicionesCondicionesEntregas.PlazoEntregaCantidad = datard.GetInt32(posPlazoEntregaCantidad);
                            obeRequisicionesCondicionesEntregas.FechaLimite = datard.GetDateTime(posFechaLimite);
                            obeRequisicionesCondicionesEntregas.IdTipoEntrega = datard.GetInt32(posIdTipoEntrega);
                            obeRequisicionesCondicionesEntregas.Observaciones = datard.GetString(posObservaciones);
                            obeRequisicionesCondicionesEntregas.NotaEspecial = datard.GetString(posNotaEspecial);
                            obeRequisicionesCondicionesEntregas.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisicionesCondicionesEntregas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesCondicionesEntregas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRequisicionesCondicionesEntregas.IdPlazoTiempo = datard.GetInt32(posIdPlazoTiempo);

                            obeRequisicionesCondicionesEntregas.PlazoEntrega = datard.GetString(posPlazoEntrega);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesCondicionesEntregas;
            }
        }

        public List<beRequisicionesSolicitud> traerRequisicionesCondicionesEntregasDetalles_x_IdRequisicion_Solicitud(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_Rep_Solicitud_RequisicionesCondicionesEntregasDetalles_x_IdRequisicion";
            List<beRequisicionesSolicitud> lbeRequisicionesCondicionesEntregasDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        int posIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posNumeroEntrega = datard.GetOrdinal("NumeroEntrega");
                        int posIdRequisicionLote = datard.GetOrdinal("IdRequisicionLote");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posHorarioInicio = datard.GetOrdinal("HorarioInicio");
                        int posHorarioFinal = datard.GetOrdinal("HorarioFinal");
                        int posLunes = datard.GetOrdinal("Lunes");
                        int posMartes = datard.GetOrdinal("Martes");
                        int posMiercoles = datard.GetOrdinal("Miercoles");
                        int posJueves = datard.GetOrdinal("Jueves");
                        int posViernes = datard.GetOrdinal("Viernes");
                        int posSabado = datard.GetOrdinal("Sabado");
                        int posDomingo = datard.GetOrdinal("Domingo");

                        int posLugar = datard.GetOrdinal("Lugar");
                        int posDireccion = datard.GetOrdinal("Direccion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        lbeRequisicionesCondicionesEntregasDetalles = new List<beRequisicionesSolicitud>();
                        beRequisicionesSolicitud obeRequisicionesCondicionesEntregasDetalles;
                        while (datard.Read())
                        {
                            obeRequisicionesCondicionesEntregasDetalles = new beRequisicionesSolicitud();
                            obeRequisicionesCondicionesEntregasDetalles.IdCondicionEntregaDetalle = datard.GetInt32(posIdCondicionEntregaDetalle);
                            obeRequisicionesCondicionesEntregasDetalles.IdRequisicionCondicionEntrega = datard.GetInt32(posIdRequisicionCondicionEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.NumeroEntrega = datard.GetInt32(posNumeroEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.IdRequisicionLote = datard.GetInt32(posIdRequisicionLote);
                            obeRequisicionesCondicionesEntregasDetalles.Cantidad = datard.GetDecimal(posCantidad);
                            obeRequisicionesCondicionesEntregasDetalles.HorarioInicio = datard.GetTimeSpan(posHorarioInicio);
                            obeRequisicionesCondicionesEntregasDetalles.HorarioFinal = datard.GetTimeSpan(posHorarioFinal);
                            obeRequisicionesCondicionesEntregasDetalles.Lunes = datard.GetByte(posLunes);
                            obeRequisicionesCondicionesEntregasDetalles.Martes = datard.GetByte(posMartes);
                            obeRequisicionesCondicionesEntregasDetalles.Miercoles = datard.GetByte(posMiercoles);
                            obeRequisicionesCondicionesEntregasDetalles.Jueves = datard.GetByte(posJueves);
                            obeRequisicionesCondicionesEntregasDetalles.Viernes = datard.GetByte(posViernes);
                            obeRequisicionesCondicionesEntregasDetalles.Sabado = datard.GetByte(posSabado);
                            obeRequisicionesCondicionesEntregasDetalles.Domingo = datard.GetByte(posDomingo);

                            obeRequisicionesCondicionesEntregasDetalles.Lugar = datard.GetString(posLugar);
                            obeRequisicionesCondicionesEntregasDetalles.Direccion = datard.GetString(posDireccion);
                            obeRequisicionesCondicionesEntregasDetalles.NoLote = datard.GetInt32(posNoLote);

                            lbeRequisicionesCondicionesEntregasDetalles.Add(obeRequisicionesCondicionesEntregasDetalles);
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

        public beRequisicionesSolicitud traerRequisicionesCondicionesPagos_x_IdRequisicion_Solicitud(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_Rep_Solicitud_RequisicionesCondicionesPagos_x_IdRequisicion";
            beRequisicionesSolicitud obeRequisicionesCondicionesPagos = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicionCondicionPago = datard.GetOrdinal("IdRequisicionCondicionPago");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posAnticipo = datard.GetOrdinal("Anticipo");
                        int posPorcentajeAnticipo = datard.GetOrdinal("PorcentajeAnticipo");
                        int posImporteAnticipo = datard.GetOrdinal("ImporteAnticipo");
                        int posIdPeriodicidad = datard.GetOrdinal("IdPeriodicidad");
                        int posNumeroPagos = datard.GetOrdinal("NumeroPagos");
                        int posImporteTotalPagos = datard.GetOrdinal("ImporteTotalPagos");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdTipoCondicionPago = datard.GetOrdinal("IdTipoCondicionPago");
                        int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
                        int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
                        int posIdLugarFirma = datard.GetOrdinal("IdLugarFirma");
                        int posPlazoPagoCantidad = datard.GetOrdinal("PlazoPagoCantidad");

                        int posPeriodicidad = datard.GetOrdinal("Periodicidad");
                        int posTipoCondicionPago = datard.GetOrdinal("TipoCondicionPago");
                        int posTipoDia = datard.GetOrdinal("TipoDia");
                        int posPlazozTiempo = datard.GetOrdinal("PlazozTiempo");
                        obeRequisicionesCondicionesPagos = new beRequisicionesSolicitud();
                        while (datard.Read())
                        {
                            obeRequisicionesCondicionesPagos.IdRequisicionCondicionPago = datard.GetInt32(posIdRequisicionCondicionPago);
                            obeRequisicionesCondicionesPagos.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesCondicionesPagos.Anticipo = datard.GetBoolean(posAnticipo);
                            obeRequisicionesCondicionesPagos.PorcentajeAnticipo = datard.GetDecimal(posPorcentajeAnticipo);
                            obeRequisicionesCondicionesPagos.ImporteAnticipo = datard.GetDecimal(posImporteAnticipo);
                            obeRequisicionesCondicionesPagos.IdPeriodicidad = datard.GetInt32(posIdPeriodicidad);
                            obeRequisicionesCondicionesPagos.NumeroPagos = datard.GetInt32(posNumeroPagos);
                            obeRequisicionesCondicionesPagos.ImporteTotalPagos = datard.GetDecimal(posImporteTotalPagos);
                            obeRequisicionesCondicionesPagos.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisicionesCondicionesPagos.Observaciones = datard.GetString(posObservaciones);
                            obeRequisicionesCondicionesPagos.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesCondicionesPagos.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRequisicionesCondicionesPagos.IdTipoCondicionPago = datard.GetInt32(posIdTipoCondicionPago);
                            obeRequisicionesCondicionesPagos.IdTipoDia = datard.GetInt32(posIdTipoDia);
                            obeRequisicionesCondicionesPagos.IdPlazoTiempo = datard.GetInt32(posIdPlazoTiempo);
                            obeRequisicionesCondicionesPagos.IdLugarFirma = datard.GetInt32(posIdLugarFirma);
                            obeRequisicionesCondicionesPagos.PlazoPagoCantidad = datard.GetInt32(posPlazoPagoCantidad);

                            obeRequisicionesCondicionesPagos.Periodicidad = datard.GetString(posPeriodicidad);
                            obeRequisicionesCondicionesPagos.TipoCondicionPago = datard.GetString(posTipoCondicionPago);
                            obeRequisicionesCondicionesPagos.TipoDia = datard.GetString(posTipoDia);
                            obeRequisicionesCondicionesPagos.PlazozTiempo = datard.GetString(posPlazozTiempo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesCondicionesPagos;
            }
        }

        public List<beRequisicionesSolicitud> traerRequisicionesCondicionesPagosDetalles_x_IdRequisicion_Solicitud(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_Rep_Solicitud_RequisicionesCondicionesPagosDetalles_x_IdRequisicion";
            List<beRequisicionesSolicitud> lbeRequisicionesCondicionesPagosDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRqCondicionPagoDetalle = datard.GetOrdinal("IdRqCondicionPagoDetalle");
                        int posIdRequiscionCondicionPago = datard.GetOrdinal("IdRequiscionCondicionPago");
                        int posFechaPago = datard.GetOrdinal("FechaPago");
                        int posPorcentajePago = datard.GetOrdinal("PorcentajePago");
                        int posNumeroPago = datard.GetOrdinal("NumeroPago");
                        int posImportePago = datard.GetOrdinal("ImportePago");

                        lbeRequisicionesCondicionesPagosDetalles = new List<beRequisicionesSolicitud>();
                        beRequisicionesSolicitud obeRequisicionesCondicionesPagosDetalles;
                        while (datard.Read())
                        {
                            obeRequisicionesCondicionesPagosDetalles = new beRequisicionesSolicitud();
                            obeRequisicionesCondicionesPagosDetalles.IdRqCondicionPagoDetalle = datard.GetInt32(posIdRqCondicionPagoDetalle);
                            obeRequisicionesCondicionesPagosDetalles.IdRequiscionCondicionPago = datard.GetInt32(posIdRequiscionCondicionPago);
                            obeRequisicionesCondicionesPagosDetalles.FechaPago = datard.GetDateTime(posFechaPago);
                            obeRequisicionesCondicionesPagosDetalles.PorcentajePago = datard.GetDecimal(posPorcentajePago);
                            obeRequisicionesCondicionesPagosDetalles.NumeroPago = datard.GetInt32(posNumeroPago);
                            obeRequisicionesCondicionesPagosDetalles.ImportePago = datard.GetDecimal(posImportePago);
                            
                            lbeRequisicionesCondicionesPagosDetalles.Add(obeRequisicionesCondicionesPagosDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesPagosDetalles;
            }
        }

        public List<beRequisicionesSolicitud> traerPresupuestosPartidas_x_IdRequisicion_Solicitud(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_Rep_Solicitud_PresupuestosPartidas_Traer_Requisicion";
            List<beRequisicionesSolicitud> lbePresupuestosPartidas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posMontoPresupuesto = datard.GetOrdinal("MontoPresupuesto");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posMontoEjecutadoTotal = datard.GetOrdinal("MontoEjecutadoTotal");
                        int posMontoSaldo = datard.GetOrdinal("MontoSaldo");
                        int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
                        int posNumeroMinistracion = datard.GetOrdinal("NumeroMinistracion");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

                        int posIdMesInicio = datard.GetOrdinal("IdMesInicio");
                        int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
                        int posClavePresupuestal = datard.GetOrdinal("ClavePresupuestal");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");
                        int posMesInicio = datard.GetOrdinal("MesInicio");
                        int posMesFin = datard.GetOrdinal("MesFin");
                        lbePresupuestosPartidas = new List<beRequisicionesSolicitud>();
                        beRequisicionesSolicitud obePresupuestosPartidas;
                        while (datard.Read())
                        {
                            obePresupuestosPartidas = new beRequisicionesSolicitud();
                            obePresupuestosPartidas.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            obePresupuestosPartidas.IdDependencia = datard.GetInt32(posIdDependencia);
                            obePresupuestosPartidas.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obePresupuestosPartidas.IdPartida = datard.GetInt32(posIdPartida);
                            obePresupuestosPartidas.MontoPresupuesto = datard.GetDecimal(posMontoPresupuesto);
                            obePresupuestosPartidas.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obePresupuestosPartidas.MontoEjecutadoTotal = datard.GetDecimal(posMontoEjecutadoTotal);
                            obePresupuestosPartidas.MontoSaldo = datard.GetDecimal(posMontoSaldo);
                            obePresupuestosPartidas.MontoEconomia = datard.GetDecimal(posMontoEconomia);
                            obePresupuestosPartidas.NumeroMinistracion = datard.GetString(posNumeroMinistracion);
                            obePresupuestosPartidas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obePresupuestosPartidas.FechaRegistro = datard.GetDateTime(posFechaRegistro);

                            obePresupuestosPartidas.IdMesInicio = datard.GetInt32(posIdMesInicio);
                            obePresupuestosPartidas.IdMesFinal = datard.GetInt32(posIdMesFinal);
                            obePresupuestosPartidas.ClavePresupuestal = datard.GetString(posClavePresupuestal);
                            obePresupuestosPartidas.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obePresupuestosPartidas.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            obePresupuestosPartidas.MesInicio = datard.GetString(posMesInicio);
                            obePresupuestosPartidas.MesFin = datard.GetString(posMesFin);

                            lbePresupuestosPartidas.Add(obePresupuestosPartidas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePresupuestosPartidas;
            }
        }

        public List<beRequisicionesSolicitud> traerRequisicionesCartas_x_IdRequisicion_Solicitud(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_Rep_Solicitud_RequisicionesCartas_x_IdRequisicion";
            List<beRequisicionesSolicitud> lbeRequisicionesCartas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posNumero = datard.GetOrdinal("Numero");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCarta = datard.GetOrdinal("Carta");

                        lbeRequisicionesCartas = new List<beRequisicionesSolicitud>();
                        beRequisicionesSolicitud obeRequisicionesCartas;
                        while (datard.Read())
                        {
                            obeRequisicionesCartas = new beRequisicionesSolicitud();
                            obeRequisicionesCartas.Numero = datard.GetInt32(posNumero);
                            obeRequisicionesCartas.Nombre = datard.GetString(posNombre);
                            obeRequisicionesCartas.Carta = datard.GetString(posCarta);

                            lbeRequisicionesCartas.Add(obeRequisicionesCartas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCartas;
            }
        }
    }
}
