using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brAdjudicacionesSolicitud:brConexion
    {
        public beAdjudicacionesSolicitud traerAdjudicaciones_x_IdAdjudicacion_Solicitud(int IdAdjudicacion)
        {
            beAdjudicacionesSolicitud obeAdjudicaciones = new beAdjudicacionesSolicitud();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesSolicitud odaAdjudicaciones = new daAdjudicacionesSolicitud();
                    obeAdjudicaciones = odaAdjudicaciones.traerAdjudicaciones_x_IdAdjudicacion_Solicitud(con, IdAdjudicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeAdjudicaciones;
            }
        }

        public List<beAdjudicacionesSolicitud> traerAdjudicacionesLotes_x_IdAdjudicacion_Solicitud(int IdAdjudicacion)
        {
            List<beAdjudicacionesSolicitud> lbeAdjudicacionesLotes = new List<beAdjudicacionesSolicitud>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesSolicitud odaAdjudicacionesLotes = new daAdjudicacionesSolicitud();
                    lbeAdjudicacionesLotes = odaAdjudicacionesLotes.traerAdjudicacionesLotes_x_IdAdjudicacion_Solicitud(con, IdAdjudicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesLotes;
            }
        }

        public beAdjudicacionesSolicitud traerAdjudicacionesCondicionesEntregas_x_IdAdjudicacion(int IdAdjudicacion)
        {
            beAdjudicacionesSolicitud obeAdjudicacionesCondicionesEntregas = new beAdjudicacionesSolicitud();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesSolicitud odaAdjudicacionesCondicionesEntregas = new daAdjudicacionesSolicitud();
                    obeAdjudicacionesCondicionesEntregas = odaAdjudicacionesCondicionesEntregas.traerAdjudicacionesCondicionesEntregas_x_IdAdjudicacion(con, IdAdjudicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeAdjudicacionesCondicionesEntregas;
            }
        }

        public List<beAdjudicacionesSolicitud> traerAdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion_Solicitud(int IdAdjudicacion)
        {
            List<beAdjudicacionesSolicitud> lbeAdjudicacionesCondicionesEntregasDetalles = new List<beAdjudicacionesSolicitud>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesSolicitud odaAdjudicacionesCondicionesEntregasDetalles = new daAdjudicacionesSolicitud();
                    lbeAdjudicacionesCondicionesEntregasDetalles = odaAdjudicacionesCondicionesEntregasDetalles.traerAdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion_Solicitud(con, IdAdjudicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesCondicionesEntregasDetalles;
            }
        }

        public beAdjudicacionesSolicitud traerAdjudicacionesCondicionesPagos_x_IdAdjudicacion_Solicitud(int IdAdjudicacion)
        {
            beAdjudicacionesSolicitud obeAdjudicacionesCondicionesPagos = new beAdjudicacionesSolicitud();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesSolicitud odaAdjudicacionesCondicionesPagos = new daAdjudicacionesSolicitud();
                    obeAdjudicacionesCondicionesPagos = odaAdjudicacionesCondicionesPagos.traerAdjudicacionesCondicionesPagos_x_IdAdjudicacion_Solicitud(con, IdAdjudicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeAdjudicacionesCondicionesPagos;
            }
        }

        public List<beAdjudicacionesSolicitud> traerAdjudicacionesCondicionesPagosDetalles_x_IdAdjudicacion_Solicitud(int IdAdjudicacion)
        {
            List<beAdjudicacionesSolicitud> lbeAdjudicacionesCondicionesPagosDetalles = new List<beAdjudicacionesSolicitud>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesSolicitud odaAdjudicacionesCondicionesPagosDetalles = new daAdjudicacionesSolicitud();
                    lbeAdjudicacionesCondicionesPagosDetalles = odaAdjudicacionesCondicionesPagosDetalles.traerAdjudicacionesCondicionesPagosDetalles_x_IdAdjudicacion_Solicitud(con, IdAdjudicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesCondicionesPagosDetalles;
            }
        }

        public List<beAdjudicacionesSolicitud> traerPresupuestosPartidas_x_IdAdjudicacion_Solicitud(int IdAdjudicacion)
        {
            List<beAdjudicacionesSolicitud> lbePresupuestosPartidas = new List<beAdjudicacionesSolicitud>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesSolicitud odaPresupuestosPartidas = new daAdjudicacionesSolicitud();
                    lbePresupuestosPartidas = odaPresupuestosPartidas.traerPresupuestosPartidas_x_IdAdjudicacion_Solicitud(con, IdAdjudicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePresupuestosPartidas;
            }
        }

        public List<beAdjudicacionesSolicitud> traerAdjudicacionesCartas_x_IdAdjudicacion_Solicitud(int IdAdjudicacion)
        {
            List<beAdjudicacionesSolicitud> lbeAdjudicacionesCartas = new List<beAdjudicacionesSolicitud>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesSolicitud odaAdjudicacionesCartas = new daAdjudicacionesSolicitud();
                    lbeAdjudicacionesCartas = odaAdjudicacionesCartas.traerAdjudicacionesCartas_x_IdAdjudicacion_Solicitud(con, IdAdjudicacion);
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
