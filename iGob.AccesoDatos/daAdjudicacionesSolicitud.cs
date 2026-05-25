using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daAdjudicacionesSolicitud
    {
        public beAdjudicacionesSolicitud traerAdjudicaciones_x_IdAdjudicacion_Solicitud(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_Rep_Solicitud_Adjudicaciones_x_IdAdjudicacion";
            beAdjudicacionesSolicitud obeAdjudicaciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdTipoAdjudicacion = datard.GetOrdinal("IdTipoAdjudicacion");
                        int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        int posFechaAdjudicacion = datard.GetOrdinal("FechaAdjudicacion");
                        int posAdjudicacionFolio = datard.GetOrdinal("AdjudicacionFolio");
                        int posConsecutivoAdjudicacion = datard.GetOrdinal("ConsecutivoAdjudicacion");
                        int posNumeroOficioSolicitud = datard.GetOrdinal("NumeroOficioSolicitud");
                        int posNumeroOficioCertificacion = datard.GetOrdinal("NumeroOficioCertificacion");
                        int posMontoAproximado = datard.GetOrdinal("MontoAproximado");
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posCantidadLotes = datard.GetOrdinal("CantidadLotes");
                        int posImporteTotalLotes = datard.GetOrdinal("ImporteTotalLotes");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posJustificacion = datard.GetOrdinal("Justificacion");
                        int posSaldoPartida = datard.GetOrdinal("SaldoPartida");
                        int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                        int posIdUsuarioAsignante = datard.GetOrdinal("IdUsuarioAsignante");
                        int posAcepta2daLicitacion = datard.GetOrdinal("Acepta2daLicitacion");
                        int posIdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
                        int posFechaAsignaRevisor = datard.GetOrdinal("FechaAsignaRevisor");
                        int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int posEconomia = datard.GetOrdinal("Economia");
                        int posEjercido = datard.GetOrdinal("Ejercido");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

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
                        int posPartida = datard.GetOrdinal("Partida");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");

                        obeAdjudicaciones = new beAdjudicacionesSolicitud();
                        while (datard.Read())
                        {
                            obeAdjudicaciones.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicaciones.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeAdjudicaciones.IdTipoAdjudicacion = datard.GetInt32(posIdTipoAdjudicacion);
                            obeAdjudicaciones.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeAdjudicaciones.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeAdjudicaciones.IdOrigenRecursoAutorizado = datard.GetInt32(posIdOrigenRecursoAutorizado);
                            obeAdjudicaciones.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeAdjudicaciones.IdEstatusAdjudicacion = datard.GetInt32(posIdEstatusAdjudicacion);
                            obeAdjudicaciones.IdPartida = datard.GetInt32(posIdPartida);
                            obeAdjudicaciones.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obeAdjudicaciones.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            obeAdjudicaciones.FechaAdjudicacion = datard.GetDateTime(posFechaAdjudicacion);
                            obeAdjudicaciones.AdjudicacionFolio = datard.GetString(posAdjudicacionFolio);
                            obeAdjudicaciones.ConsecutivoAdjudicacion = datard.GetInt32(posConsecutivoAdjudicacion);
                            obeAdjudicaciones.NumeroOficioSolicitud = datard.GetString(posNumeroOficioSolicitud);
                            obeAdjudicaciones.NumeroOficioCertificacion = datard.GetString(posNumeroOficioCertificacion);
                            obeAdjudicaciones.MontoAproximado = datard.GetDecimal(posMontoAproximado);
                            obeAdjudicaciones.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            obeAdjudicaciones.CantidadLotes = datard.GetInt32(posCantidadLotes);
                            obeAdjudicaciones.ImporteTotalLotes = datard.GetDecimal(posImporteTotalLotes);
                            obeAdjudicaciones.Observaciones = datard.GetString(posObservaciones);
                            obeAdjudicaciones.Justificacion = datard.GetString(posJustificacion);
                            obeAdjudicaciones.SaldoPartida = datard.GetDecimal(posSaldoPartida);
                            obeAdjudicaciones.MontoPresupuestado = datard.GetDecimal(posMontoPresupuestado);
                            obeAdjudicaciones.IdUsuarioAsignante = datard.GetInt32(posIdUsuarioAsignante);
                            obeAdjudicaciones.Acepta2daLicitacion = datard.GetInt32(posAcepta2daLicitacion);
                            obeAdjudicaciones.IdUsuarioRevisor = datard.GetInt32(posIdUsuarioRevisor);
                            obeAdjudicaciones.FechaAsignaRevisor = datard.GetDateTime(posFechaAsignaRevisor);
                            obeAdjudicaciones.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            obeAdjudicaciones.Economia = datard.GetDecimal(posEconomia);
                            obeAdjudicaciones.Ejercido = datard.GetDecimal(posEjercido);
                            obeAdjudicaciones.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeAdjudicaciones.FechaRegistro = datard.GetDateTime(posFechaRegistro);

                            obeAdjudicaciones.Dependencia = datard.GetString(posDependencia);
                            obeAdjudicaciones.Rfc = datard.GetString(posRfc);
                            obeAdjudicaciones.Calle = datard.GetString(posCalle);
                            obeAdjudicaciones.NoExterior = datard.GetString(posNoExterior);
                            obeAdjudicaciones.NoInterior = datard.GetString(posNoInterior);
                            obeAdjudicaciones.Colonia = datard.GetString(posColonia);
                            obeAdjudicaciones.Localidad = datard.GetString(posLocalidad);
                            obeAdjudicaciones.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeAdjudicaciones.Email = datard.GetString(posEmail);
                            obeAdjudicaciones.IdMunicipio = datard.GetString(posIdMunicipio);
                            obeAdjudicaciones.Municipio = datard.GetString(posMunicipio);
                            obeAdjudicaciones.ClaveEstado = datard.GetString(posClaveEstado);
                            obeAdjudicaciones.Estado = datard.GetString(posEstado);
                            obeAdjudicaciones.IdPais = datard.GetInt32(posIdPais);
                            obeAdjudicaciones.Pais = datard.GetString(posPais);
                            obeAdjudicaciones.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            obeAdjudicaciones.OrigenRecurso = datard.GetString(posOrigenRecurso);
                            obeAdjudicaciones.Partida = datard.GetString(posPartida);
                            obeAdjudicaciones.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            obeAdjudicaciones.Capitulo = datard.GetString(posCapitulo);
                            obeAdjudicaciones.Ejercicio = datard.GetInt32(posEjercicio);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeAdjudicaciones;
            }
        }

        public List<beAdjudicacionesSolicitud> traerAdjudicacionesLotes_x_IdAdjudicacion_Solicitud(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_Rep_Solicitud_AdjudicacionesLotes_x_IdAdjudicacion";
            List<beAdjudicacionesSolicitud> lbeAdjudicacionesLotes = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posTotal = datard.GetOrdinal("Total");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");

                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIdTipoProducto = datard.GetOrdinal("IdTipoProducto");
                        int posTipoProducto = datard.GetOrdinal("TipoProducto");
                        int posIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");

                        lbeAdjudicacionesLotes = new List<beAdjudicacionesSolicitud>();
                        beAdjudicacionesSolicitud obeAdjudicacionesLotes;
                        while (datard.Read())
                        {
                            obeAdjudicacionesLotes = new beAdjudicacionesSolicitud();
                            obeAdjudicacionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeAdjudicacionesLotes.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicacionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeAdjudicacionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeAdjudicacionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeAdjudicacionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeAdjudicacionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeAdjudicacionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeAdjudicacionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeAdjudicacionesLotes.Total = datard.GetDecimal(posTotal);
                            obeAdjudicacionesLotes.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeAdjudicacionesLotes.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);

                            obeAdjudicacionesLotes.Descripcion = datard.GetString(posDescripcion);
                            obeAdjudicacionesLotes.IdTipoProducto = datard.GetInt32(posIdTipoProducto);
                            obeAdjudicacionesLotes.TipoProducto = datard.GetString(posTipoProducto);
                            obeAdjudicacionesLotes.IdUnidadMedida = datard.GetInt32(posIdUnidadMedida);
                            obeAdjudicacionesLotes.UnidadMedida = datard.GetString(posUnidadMedida);

                            lbeAdjudicacionesLotes.Add(obeAdjudicacionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesLotes;
            }
        }

        public beAdjudicacionesSolicitud traerAdjudicacionesCondicionesEntregas_x_IdAdjudicacion(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_Rep_Solicitud_AdjudicacionesCondicionesEntregas_x_IdAdjudicacion";
            beAdjudicacionesSolicitud obeAdjudicacionesCondicionesEntregas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAdjudicacionCondicionEntrega = datard.GetOrdinal("IdAdjudicacionCondicionEntrega");
                        int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
                        int posIdPlazoEntegra = datard.GetOrdinal("IdPlazoEntegra");
                        int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
                        int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
                        int posFechaLimite = datard.GetOrdinal("FechaLimite");
                        int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posNotaEspecial = datard.GetOrdinal("NotaEspecial");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

                        int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");

                        obeAdjudicacionesCondicionesEntregas = new beAdjudicacionesSolicitud();
                        while (datard.Read())
                        {
                            obeAdjudicacionesCondicionesEntregas.IdAdjudicacionCondicionEntrega = datard.GetInt32(posIdAdjudicacionCondicionEntrega);
                            obeAdjudicacionesCondicionesEntregas.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicacionesCondicionesEntregas.IdTipoDia = datard.GetInt32(posIdTipoDia);
                            obeAdjudicacionesCondicionesEntregas.IdPlazoEntegra = datard.GetInt32(posIdPlazoEntegra);
                            obeAdjudicacionesCondicionesEntregas.IdPlazoTiempo = datard.GetInt32(posIdPlazoTiempo);
                            obeAdjudicacionesCondicionesEntregas.PlazoEntregaCantidad = datard.GetInt32(posPlazoEntregaCantidad);
                            obeAdjudicacionesCondicionesEntregas.FechaLimite = datard.GetDateTime(posFechaLimite);
                            obeAdjudicacionesCondicionesEntregas.IdTipoEntrega = datard.GetInt32(posIdTipoEntrega);
                            obeAdjudicacionesCondicionesEntregas.Observaciones = datard.GetString(posObservaciones);
                            obeAdjudicacionesCondicionesEntregas.NotaEspecial = datard.GetString(posNotaEspecial);
                            obeAdjudicacionesCondicionesEntregas.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeAdjudicacionesCondicionesEntregas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeAdjudicacionesCondicionesEntregas.FechaRegistro = datard.GetDateTime(posFechaRegistro);

                            obeAdjudicacionesCondicionesEntregas.PlazoEntrega = datard.GetString(posPlazoEntrega);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeAdjudicacionesCondicionesEntregas;
            }
        }

        public List<beAdjudicacionesSolicitud> traerAdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion_Solicitud(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_Rep_Solicitud_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion";
            List<beAdjudicacionesSolicitud> lbeAdjudicacionesCondicionesEntregasDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAdCondicionEntregaDetalle = datard.GetOrdinal("IdAdCondicionEntregaDetalle");
                        int posIdAdjudicacionCondicionEntrega = datard.GetOrdinal("IdAdjudicacionCondicionEntrega");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posNumeroEntrega = datard.GetOrdinal("NumeroEntrega");
                        int posIdAdjudicacionLote = datard.GetOrdinal("IdAdjudicacionLote");
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

                        lbeAdjudicacionesCondicionesEntregasDetalles = new List<beAdjudicacionesSolicitud>();
                        beAdjudicacionesSolicitud obeAdjudicacionesCondicionesEntregasDetalles;
                        while (datard.Read())
                        {
                            obeAdjudicacionesCondicionesEntregasDetalles = new beAdjudicacionesSolicitud();
                            obeAdjudicacionesCondicionesEntregasDetalles.IdAdCondicionEntregaDetalle = datard.GetInt32(posIdAdCondicionEntregaDetalle);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionCondicionEntrega = datard.GetInt32(posIdAdjudicacionCondicionEntrega);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeAdjudicacionesCondicionesEntregasDetalles.NumeroEntrega = datard.GetInt32(posNumeroEntrega);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionLote = datard.GetInt32(posIdAdjudicacionLote);
                            obeAdjudicacionesCondicionesEntregasDetalles.Cantidad = datard.GetDecimal(posCantidad);
                            obeAdjudicacionesCondicionesEntregasDetalles.HorarioInicio = datard.GetTimeSpan(posHorarioInicio);
                            obeAdjudicacionesCondicionesEntregasDetalles.HorarioFinal = datard.GetTimeSpan(posHorarioFinal);
                            obeAdjudicacionesCondicionesEntregasDetalles.Lunes = datard.GetByte(posLunes);
                            obeAdjudicacionesCondicionesEntregasDetalles.Martes = datard.GetByte(posMartes);
                            obeAdjudicacionesCondicionesEntregasDetalles.Miercoles = datard.GetByte(posMiercoles);
                            obeAdjudicacionesCondicionesEntregasDetalles.Jueves = datard.GetByte(posJueves);
                            obeAdjudicacionesCondicionesEntregasDetalles.Viernes = datard.GetByte(posViernes);
                            obeAdjudicacionesCondicionesEntregasDetalles.Sabado = datard.GetByte(posSabado);
                            obeAdjudicacionesCondicionesEntregasDetalles.Domingo = datard.GetByte(posDomingo);

                            obeAdjudicacionesCondicionesEntregasDetalles.Lugar = datard.GetString(posLugar);
                            obeAdjudicacionesCondicionesEntregasDetalles.Direccion = datard.GetString(posDireccion);
                            obeAdjudicacionesCondicionesEntregasDetalles.NoLote = datard.GetInt32(posNoLote);

                            lbeAdjudicacionesCondicionesEntregasDetalles.Add(obeAdjudicacionesCondicionesEntregasDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesCondicionesEntregasDetalles;
            }
        }

        public beAdjudicacionesSolicitud traerAdjudicacionesCondicionesPagos_x_IdAdjudicacion_Solicitud(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_Rep_Solicitud_AdjudicacionesCondicionesPagos_x_IdAdjudicacion";
            beAdjudicacionesSolicitud obeAdjudicacionesCondicionesPagos = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAdjudicacionCondicionPago = datard.GetOrdinal("IdAdjudicacionCondicionPago");
                        int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
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
                        obeAdjudicacionesCondicionesPagos = new beAdjudicacionesSolicitud();
                        while (datard.Read())
                        {
                            obeAdjudicacionesCondicionesPagos.IdAdjudicacionCondicionPago = datard.GetInt32(posIdAdjudicacionCondicionPago);
                            obeAdjudicacionesCondicionesPagos.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicacionesCondicionesPagos.Anticipo = datard.GetInt32(posAnticipo);
                            obeAdjudicacionesCondicionesPagos.PorcentajeAnticipo = datard.GetDecimal(posPorcentajeAnticipo);
                            obeAdjudicacionesCondicionesPagos.ImporteAnticipo = datard.GetDecimal(posImporteAnticipo);
                            obeAdjudicacionesCondicionesPagos.IdPeriodicidad = datard.GetInt32(posIdPeriodicidad);
                            obeAdjudicacionesCondicionesPagos.NumeroPagos = datard.GetInt32(posNumeroPagos);
                            obeAdjudicacionesCondicionesPagos.ImporteTotalPagos = datard.GetDecimal(posImporteTotalPagos);
                            obeAdjudicacionesCondicionesPagos.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeAdjudicacionesCondicionesPagos.Observaciones = datard.GetString(posObservaciones);
                            obeAdjudicacionesCondicionesPagos.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeAdjudicacionesCondicionesPagos.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeAdjudicacionesCondicionesPagos.IdTipoCondicionPago = datard.GetInt32(posIdTipoCondicionPago);
                            obeAdjudicacionesCondicionesPagos.IdTipoDia = datard.GetInt32(posIdTipoDia);
                            obeAdjudicacionesCondicionesPagos.IdPlazoTiempo = datard.GetInt32(posIdPlazoTiempo);
                            obeAdjudicacionesCondicionesPagos.IdLugarFirma = datard.GetInt32(posIdLugarFirma);
                            obeAdjudicacionesCondicionesPagos.PlazoPagoCantidad = datard.GetInt32(posPlazoPagoCantidad);

                            obeAdjudicacionesCondicionesPagos.Periodicidad = datard.GetString(posPeriodicidad);
                            obeAdjudicacionesCondicionesPagos.TipoCondicionPago = datard.GetString(posTipoCondicionPago);
                            obeAdjudicacionesCondicionesPagos.TipoDia = datard.GetString(posTipoDia);
                            obeAdjudicacionesCondicionesPagos.PlazozTiempo = datard.GetString(posPlazozTiempo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeAdjudicacionesCondicionesPagos;
            }
        }

        public List<beAdjudicacionesSolicitud> traerAdjudicacionesCondicionesPagosDetalles_x_IdAdjudicacion_Solicitud(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_Rep_Solicitud_AdjudicacionesCondicionesPagosDetalles_x_IdAdjudicacion";
            List<beAdjudicacionesSolicitud> lbeAdjudicacionesCondicionesPagosDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAdCondicionPagoDetalle = datard.GetOrdinal("IdAdCondicionPagoDetalle");
                        int posIdAdjudicacionCondicionPago = datard.GetOrdinal("IdAdjudicacionCondicionPago");
                        int posFechaPago = datard.GetOrdinal("FechaPago");
                        int posPorcentajePago = datard.GetOrdinal("PorcentajePago");
                        int posNumeroPago = datard.GetOrdinal("NumeroPago");
                        int posImportePago = datard.GetOrdinal("ImportePago");
                        lbeAdjudicacionesCondicionesPagosDetalles = new List<beAdjudicacionesSolicitud>();
                        beAdjudicacionesSolicitud obeAdjudicacionesCondicionesPagosDetalles;
                        while (datard.Read())
                        {
                            obeAdjudicacionesCondicionesPagosDetalles = new beAdjudicacionesSolicitud();
                            obeAdjudicacionesCondicionesPagosDetalles.IdAdCondicionPagoDetalle = datard.GetInt32(posIdAdCondicionPagoDetalle);
                            obeAdjudicacionesCondicionesPagosDetalles.IdAdjudicacionCondicionPago = datard.GetInt32(posIdAdjudicacionCondicionPago);
                            obeAdjudicacionesCondicionesPagosDetalles.FechaPago = datard.GetDateTime(posFechaPago);
                            obeAdjudicacionesCondicionesPagosDetalles.PorcentajePago = datard.GetDecimal(posPorcentajePago);
                            obeAdjudicacionesCondicionesPagosDetalles.NumeroPago = datard.GetInt32(posNumeroPago);
                            obeAdjudicacionesCondicionesPagosDetalles.ImportePago = datard.GetDecimal(posImportePago);
                            lbeAdjudicacionesCondicionesPagosDetalles.Add(obeAdjudicacionesCondicionesPagosDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesCondicionesPagosDetalles;
            }
        }

        public List<beAdjudicacionesSolicitud> traerPresupuestosPartidas_x_IdAdjudicacion_Solicitud(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_Rep_Solicitud_PresupuestosPartidas_x_IdAdjudicacion";
            List<beAdjudicacionesSolicitud> lbePresupuestosPartidas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
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
                        lbePresupuestosPartidas = new List<beAdjudicacionesSolicitud>();
                        beAdjudicacionesSolicitud obePresupuestosPartidas;
                        while (datard.Read())
                        {
                            obePresupuestosPartidas = new beAdjudicacionesSolicitud();
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

        public List<beAdjudicacionesSolicitud> traerAdjudicacionesCartas_x_IdAdjudicacion_Solicitud(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_Rep_Solicitud_AdjudicacionesCartas_x_IdAdjudicacion";
            List<beAdjudicacionesSolicitud> lbeAdjudicacionesCartas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posNumero = datard.GetOrdinal("Numero");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCarta = datard.GetOrdinal("Carta");

                        lbeAdjudicacionesCartas = new List<beAdjudicacionesSolicitud>();
                        beAdjudicacionesSolicitud obeAjudicacionesCartas;
                        while (datard.Read())
                        {
                            obeAjudicacionesCartas = new beAdjudicacionesSolicitud();
                            obeAjudicacionesCartas.Numero = datard.GetInt32(posNumero);
                            obeAjudicacionesCartas.Nombre = datard.GetString(posNombre);
                            obeAjudicacionesCartas.Carta = datard.GetString(posCarta);

                            lbeAdjudicacionesCartas.Add(obeAjudicacionesCartas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesCartas;
            }
        }
    }
}
