using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRequisicionesCondicionesPagosDetalles:brConexion
		 {
	public int guardarRequisicionesCondicionesPagosDetalles(beRequisicionesCondicionesPagosDetalles obeRequisicionesCondicionesPagosDetalles)
	{
		int IdRqCondicionPagoDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRequisicionesCondicionesPagosDetalles odaRequisicionesCondicionesPagosDetalles= new daRequisicionesCondicionesPagosDetalles();
			IdRqCondicionPagoDetalle =  odaRequisicionesCondicionesPagosDetalles.guardarRequisicionesCondicionesPagosDetalles(con, obeRequisicionesCondicionesPagosDetalles);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdRqCondicionPagoDetalle;
			}
	}

	public int actualizarRequisicionesCondicionesPagosDetalles(beRequisicionesCondicionesPagosDetalles obeRequisicionesCondicionesPagosDetalles)
	{
		int IdRqCondicionPagoDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesPagosDetalles odaRequisicionesCondicionesPagosDetalles= new daRequisicionesCondicionesPagosDetalles();
				IdRqCondicionPagoDetalle =  odaRequisicionesCondicionesPagosDetalles.actualizarRequisicionesCondicionesPagosDetalles(con, obeRequisicionesCondicionesPagosDetalles);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRqCondicionPagoDetalle;
			}
	}

	public int eliminarRequisicionesCondicionesPagosDetalles(int IdRqCondicionPagoDetalle)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesPagosDetalles odaRequisicionesCondicionesPagosDetalles= new daRequisicionesCondicionesPagosDetalles();
				IdRqCondicionPagoDetalle =  odaRequisicionesCondicionesPagosDetalles.eliminarRequisicionesCondicionesPagosDetalles(con, IdRqCondicionPagoDetalle);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRqCondicionPagoDetalle;
			}
	}

	public beRequisicionesCondicionesPagosDetalles traerRequisicionesCondicionesPagosDetalles_x_IdRqCondicionPagoDetalle (int IdRqCondicionPagoDetalle)
	{
		beRequisicionesCondicionesPagosDetalles obeRequisicionesCondicionesPagosDetalles=new beRequisicionesCondicionesPagosDetalles();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesPagosDetalles odaRequisicionesCondicionesPagosDetalles= new daRequisicionesCondicionesPagosDetalles();
				 obeRequisicionesCondicionesPagosDetalles =  odaRequisicionesCondicionesPagosDetalles.traerRequisicionesCondicionesPagosDetalles_x_IdRqCondicionPagoDetalle(con, IdRqCondicionPagoDetalle);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesCondicionesPagosDetalles;
			}
	}

	public List<beRequisicionesCondicionesPagosDetalles> listarTodos_RequisicionesCondicionesPagosDetalles()
	 {
		List<beRequisicionesCondicionesPagosDetalles> lbeRequisicionesCondicionesPagosDetalles =new List<beRequisicionesCondicionesPagosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesPagosDetalles odaRequisicionesCondicionesPagosDetalles= new daRequisicionesCondicionesPagosDetalles();
				 lbeRequisicionesCondicionesPagosDetalles =  odaRequisicionesCondicionesPagosDetalles.listarTodos_RequisicionesCondicionesPagosDetalles(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesPagosDetalles;
		}
	}
	public List<beRequisicionesCondicionesPagosDetalles> listarTodos_RequisicionesCondicionesPagosDetalles_GetAll()
	 {
		List<beRequisicionesCondicionesPagosDetalles> lbeRequisicionesCondicionesPagosDetalles =new List<beRequisicionesCondicionesPagosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesPagosDetalles odaRequisicionesCondicionesPagosDetalles= new daRequisicionesCondicionesPagosDetalles();
				 lbeRequisicionesCondicionesPagosDetalles =  odaRequisicionesCondicionesPagosDetalles.listar_RequisicionesCondicionesPagosDetalles_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesPagosDetalles;
		}
	}
        public int eliminarRequisicionesCondicionesPagosDetalles_x_IdRequiscionCondicionPago(int IdRequiscionCondicionPago)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            { int IdRqCondicionPagoDetalle=0;
                try
                {
                    con.Open();
                    daRequisicionesCondicionesPagosDetalles odaRequisicionesCondicionesPagosDetalles = new daRequisicionesCondicionesPagosDetalles();
                    IdRqCondicionPagoDetalle = odaRequisicionesCondicionesPagosDetalles.eliminarRequisicionesCondicionesPagosDetalles(con, IdRequiscionCondicionPago);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdRqCondicionPagoDetalle;
            }
        }
    }
}
