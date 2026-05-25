using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRecepcionesPedidosDetalles:brConexion
		 {
	public int guardarRecepcionesPedidosDetalles(beRecepcionesPedidosDetalles obeRecepcionesPedidosDetalles)
	{
		int IdRecepcionDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRecepcionesPedidosDetalles odaRecepcionesPedidosDetalles= new daRecepcionesPedidosDetalles();
			IdRecepcionDetalle =  odaRecepcionesPedidosDetalles.guardarRecepcionesPedidosDetalles(con, obeRecepcionesPedidosDetalles);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdRecepcionDetalle;
			}
	}

	public int actualizarRecepcionesPedidosDetalles(beRecepcionesPedidosDetalles obeRecepcionesPedidosDetalles)
	{
		int IdRecepcionDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRecepcionesPedidosDetalles odaRecepcionesPedidosDetalles= new daRecepcionesPedidosDetalles();
				IdRecepcionDetalle =  odaRecepcionesPedidosDetalles.actualizarRecepcionesPedidosDetalles(con, obeRecepcionesPedidosDetalles);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRecepcionDetalle;
			}
	}

	public int eliminarRecepcionesPedidosDetalles(int IdRecepcionDetalle)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRecepcionesPedidosDetalles odaRecepcionesPedidosDetalles= new daRecepcionesPedidosDetalles();
				IdRecepcionDetalle =  odaRecepcionesPedidosDetalles.eliminarRecepcionesPedidosDetalles(con, IdRecepcionDetalle);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRecepcionDetalle;
			}
	}

	public beRecepcionesPedidosDetalles traerRecepcionesPedidosDetalles_x_IdRecepcionDetalle (int IdRecepcionDetalle)
	{
		beRecepcionesPedidosDetalles obeRecepcionesPedidosDetalles=new beRecepcionesPedidosDetalles();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRecepcionesPedidosDetalles odaRecepcionesPedidosDetalles= new daRecepcionesPedidosDetalles();
				 obeRecepcionesPedidosDetalles =  odaRecepcionesPedidosDetalles.traerRecepcionesPedidosDetalles_x_IdRecepcionDetalle(con, IdRecepcionDetalle);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRecepcionesPedidosDetalles;
			}
	}

	public List<beRecepcionesPedidosDetalles> listarTodos_RecepcionesPedidosDetalles()
	 {
		List<beRecepcionesPedidosDetalles> lbeRecepcionesPedidosDetalles =new List<beRecepcionesPedidosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRecepcionesPedidosDetalles odaRecepcionesPedidosDetalles= new daRecepcionesPedidosDetalles();
				 lbeRecepcionesPedidosDetalles =  odaRecepcionesPedidosDetalles.listarTodos_RecepcionesPedidosDetalles(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRecepcionesPedidosDetalles;
		}
	}
	public List<beRecepcionesPedidosDetalles> listarTodos_RecepcionesPedidosDetalles_GetAll()
	 {
		List<beRecepcionesPedidosDetalles> lbeRecepcionesPedidosDetalles =new List<beRecepcionesPedidosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRecepcionesPedidosDetalles odaRecepcionesPedidosDetalles= new daRecepcionesPedidosDetalles();
				 lbeRecepcionesPedidosDetalles =  odaRecepcionesPedidosDetalles.listar_RecepcionesPedidosDetalles_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRecepcionesPedidosDetalles;
		}
	}

        public List<beListadoPedidosLicitaciones> listarTodos_RecepcionesPedidos_Licitacion(int pIdDependnecia)
        {
            List<beListadoPedidosLicitaciones> lbeRecepcionesPedidos = new List<beListadoPedidosLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRecepcionesPedidosDetalles odaRecepcionesPedidos = new daRecepcionesPedidosDetalles();
                    lbeRecepcionesPedidos = odaRecepcionesPedidos.listarTodos_RecepcionesPedidos_Licitacion(con, pIdDependnecia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcionesPedidos;
            }
        }

        public List<beListadoPedidosLicitaciones> ListadoPedidosLicitaciones_IdPedido(int pIdPedido)
        {
            List<beListadoPedidosLicitaciones> lbeRecepcionesPedidos = new List<beListadoPedidosLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRecepcionesPedidosDetalles odaRecepcionesPedidos = new daRecepcionesPedidosDetalles();
                    lbeRecepcionesPedidos = odaRecepcionesPedidos.ListadoPedidosLicitaciones_IdPedido(con, pIdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcionesPedidos;
            }
        }
        public bePedidoDetalleCabezera getCabezeraPedidoDetalles(int pIdPedido)
        {
            bePedidoDetalleCabezera lbeRecepcionesPedidos = new bePedidoDetalleCabezera();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRecepcionesPedidosDetalles odaRecepcionesPedidos = new daRecepcionesPedidosDetalles();
                    lbeRecepcionesPedidos = odaRecepcionesPedidos.getCabezeraPedidoDetalles(con, pIdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcionesPedidos;
            }
        }
        public List<beListadoPedidosLicitaciones> getDetallePedidoLotes(int pIdPedido)
        {
            List<beListadoPedidosLicitaciones> lbeRecepcionesPedidos = new List<beListadoPedidosLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRecepcionesPedidosDetalles odaRecepcionesPedidos = new daRecepcionesPedidosDetalles();
                    lbeRecepcionesPedidos = odaRecepcionesPedidos.getDetallePedidoLotes(con, pIdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcionesPedidos;
            }
        }
    }
}
