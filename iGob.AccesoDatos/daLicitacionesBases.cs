using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daLicitacionesBases
    {
        public beLicitacionesBases traerLicitaciones_x_IdLicitacion_Bases(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Bases_Licitaciones_x_IdLicitacion";
            beLicitacionesBases obeLicitaciones = null;
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
                        int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
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

                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posTitulo = datard.GetOrdinal("Titulo");
                        int posDependencias = datard.GetOrdinal("Dependencias");
                        int posPartidas = datard.GetOrdinal("Partidas");
                        int posDescripcionPartidas = datard.GetOrdinal("DescripcionPartidas");
                        int posClavePartidas = datard.GetOrdinal("ClavePartidas");
                        int posFolioRequisiciones = datard.GetOrdinal("FolioRequisiciones");
                        int posPlazosEntrega = datard.GetOrdinal("PlazosEntrega");
                        int posPlazosPago = datard.GetOrdinal("PlazosPago");
                        int posDependenciasAbreviaturas = datard.GetOrdinal("DependenciasAbreviaturas");
                        int posDatosFacturacion = datard.GetOrdinal("DatosFacturacion");
                        int posLugarFirmaPedido = datard.GetOrdinal("LugarFirmaPedido");
                        

                        obeLicitaciones = new beLicitacionesBases();
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
                            obeLicitaciones.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
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

                            obeLicitaciones.Tiempo = datard.GetString(posTiempo);
                            obeLicitaciones.Titulo = datard.GetString(posTitulo);
                            obeLicitaciones.Dependencias = datard.GetString(posDependencias);
                            obeLicitaciones.Partidas = datard.GetString(posPartidas);
                            obeLicitaciones.DescripcionPartidas = datard.GetString(posDescripcionPartidas);
                            obeLicitaciones.ClavePartidas = datard.GetString(posClavePartidas);
                            obeLicitaciones.FolioRequisiciones = datard.GetString(posFolioRequisiciones);
                            obeLicitaciones.PlazosEntrega = datard.GetString(posPlazosEntrega);
                            obeLicitaciones.PlazosPago = datard.GetString(posPlazosPago);
                            obeLicitaciones.DependenciasAbreviaturas = datard.GetString(posDependenciasAbreviaturas);
                            obeLicitaciones.DatosFacturacion = datard.GetString(posDatosFacturacion);
                            obeLicitaciones.LugarFirmaPedido = datard.GetString(posLugarFirmaPedido);
                            

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
        
        public List<beLicitacionesBases> traerRequisicionesCondicionesEntregasDetalles_x_IdLicitacion_Bases(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Bases_RequisicionesCondicionesEntregasDetalles_x_IdLicitacion";
            List<beLicitacionesBases> lbeRequisicionesCondicionesEntregasDetalles = null;
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
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posHorario = datard.GetOrdinal("Horario");
                        int posDias = datard.GetOrdinal("Dias");
                        int posLugarEntrega = datard.GetOrdinal("LugarEntrega");

                        lbeRequisicionesCondicionesEntregasDetalles = new List<beLicitacionesBases>();
                        beLicitacionesBases obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesBases();

                            obeLicitaciones.IdCondicionEntregaDetalle = datard.GetInt32(posIdCondicionEntregaDetalle);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);
                            obeLicitaciones.NoLote = datard.GetInt32(posNoLote);
                            obeLicitaciones.Horario = datard.GetString(posHorario);
                            obeLicitaciones.Dias = datard.GetString(posDias);
                            obeLicitaciones.LugarEntrega = datard.GetString(posLugarEntrega);

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

        public List<beLicitacionesBases> traerRequisicionesCartas_x_IdLicitacion_Bases(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Bases_RequisicionesCartas_x_IdLicitacion";
            List<beLicitacionesBases> lbeRequisicionesCondicionesEntregasDetalles = null;
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
                        int posCarta = datard.GetOrdinal("Carta");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posNumero = datard.GetOrdinal("Numero");
                        int posInciso = datard.GetOrdinal("Inciso");

                        lbeRequisicionesCondicionesEntregasDetalles = new List<beLicitacionesBases>();
                        beLicitacionesBases obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesBases();

                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeLicitaciones.Carta = datard.GetString(posCarta);
                            obeLicitaciones.Nombre = datard.GetString(posNombre);
                            obeLicitaciones.Numero = datard.GetInt32(posNumero);
                            obeLicitaciones.Inciso = datard.GetString(posInciso);

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
