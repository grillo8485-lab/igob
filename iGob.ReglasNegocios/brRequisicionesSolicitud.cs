using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brRequisicionesSolicitud:brConexion
    {
        public beRequisicionesSolicitud traerRequisiciones_x_IdRequisicion_Solicitud(int IdRequisicion)
        {
            beRequisicionesSolicitud obeRequisiciones = new beRequisicionesSolicitud();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesSolicitud odaRequisiciones = new daRequisicionesSolicitud();
                    obeRequisiciones = odaRequisiciones.traerRequisiciones_x_IdRequisicion_Solicitud(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisiciones;
            }
        }

        public List<beRequisicionesSolicitud> traerRequisicionesLiquidez_x_IdRequisicion_Solicitud(int IdRequisicion)
        {
            List<beRequisicionesSolicitud> lbeRequisicionesLiquidez = new List<beRequisicionesSolicitud>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesSolicitud odaRequisicionesLiquidez = new daRequisicionesSolicitud();
                    lbeRequisicionesLiquidez = odaRequisicionesLiquidez.traerRequisicionesLiquidez_x_IdRequisicion_Solicitud(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLiquidez;
            }
        }

        public List<beRequisicionesSolicitud> traerRequisicionesLotes_x_IdRequisicion_Solicitud(int IdRequisicion)
        {
            List<beRequisicionesSolicitud> lbeRequisicionesLotes = new List<beRequisicionesSolicitud>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesSolicitud odaRequisicionesLotes = new daRequisicionesSolicitud();
                    lbeRequisicionesLotes = odaRequisicionesLotes.traerRequisicionesLotes_x_IdRequisicion_Solicitud(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }

        public beRequisicionesSolicitud traerRequisicionesCondicionesEntregas_x_IdRequisicion_Solicitud(int IdRequisicion)
        {
            beRequisicionesSolicitud obeRequisicionesCondicionesEntregas = new beRequisicionesSolicitud();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesSolicitud odaRequisicionesCondicionesEntregas = new daRequisicionesSolicitud();
                    obeRequisicionesCondicionesEntregas = odaRequisicionesCondicionesEntregas.traerRequisicionesCondicionesEntregas_x_IdRequisicion_Solicitud(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesCondicionesEntregas;
            }
        }

        public List<beRequisicionesSolicitud> traerRequisicionesCondicionesEntregasDetalles_x_IdRequisicion_Solicitud(int IdRequisicion)
        {
            List<beRequisicionesSolicitud> lbeRequisicionesCondicionesEntregasDetalles = new List<beRequisicionesSolicitud>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesSolicitud odaRequisicionesCondicionesEntregasDetalles = new daRequisicionesSolicitud();
                    lbeRequisicionesCondicionesEntregasDetalles = odaRequisicionesCondicionesEntregasDetalles.traerRequisicionesCondicionesEntregasDetalles_x_IdRequisicion_Solicitud(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesEntregasDetalles;
            }
        }

        public beRequisicionesSolicitud traerRequisicionesCondicionesPagos_x_IdRequisicion_Solicitud(int IdRequisicion)
        {
            beRequisicionesSolicitud obeRequisicionesCondicionesPagos = new beRequisicionesSolicitud();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesSolicitud odaRequisicionesCondicionesPagos = new daRequisicionesSolicitud();
                    obeRequisicionesCondicionesPagos = odaRequisicionesCondicionesPagos.traerRequisicionesCondicionesPagos_x_IdRequisicion_Solicitud(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesCondicionesPagos;
            }
        }

        public List<beRequisicionesSolicitud> traerRequisicionesCondicionesPagosDetalles_x_IdRequisicion_Solicitud(int IdRequisicion)
        {
            List<beRequisicionesSolicitud> lbeRequisicionesCondicionesPagosDetalles = new List<beRequisicionesSolicitud>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesSolicitud odaRequisicionesCondicionesPagosDetalles = new daRequisicionesSolicitud();
                    lbeRequisicionesCondicionesPagosDetalles = odaRequisicionesCondicionesPagosDetalles.traerRequisicionesCondicionesPagosDetalles_x_IdRequisicion_Solicitud(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesPagosDetalles;
            }
        }

        public List<beRequisicionesSolicitud> traerPresupuestosPartidas_x_IdRequisicion_Solicitud(int IdRequisicion)
        {
            List<beRequisicionesSolicitud> lbePresupuestosPartidas = new List<beRequisicionesSolicitud>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesSolicitud odaPresupuestosPartidas = new daRequisicionesSolicitud();
                    lbePresupuestosPartidas = odaPresupuestosPartidas.traerPresupuestosPartidas_x_IdRequisicion_Solicitud(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePresupuestosPartidas;
            }
        }

        public List<beRequisicionesSolicitud> traerRequisicionesCartas_x_IdRequisicion_Solicitud(int IdRequisicion)
        {
            List<beRequisicionesSolicitud> lbeRequisicionesCartas = new List<beRequisicionesSolicitud>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesSolicitud odaRequisicionesCartas = new daRequisicionesSolicitud();
                    lbeRequisicionesCartas = odaRequisicionesCartas.traerRequisicionesCartas_x_IdRequisicion_Solicitud(con, IdRequisicion);
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
