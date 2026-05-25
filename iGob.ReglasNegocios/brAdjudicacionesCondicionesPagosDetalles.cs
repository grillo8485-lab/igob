using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesCondicionesPagosDetalles:brConexion
		 {
	public int guardarAdjudicacionesCondicionesPagosDetalles(beAdjudicacionesCondicionesPagosDetalles obeAdjudicacionesCondicionesPagosDetalles)
	{
		int IdAdCondicionPagoDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesCondicionesPagosDetalles odaAdjudicacionesCondicionesPagosDetalles= new daAdjudicacionesCondicionesPagosDetalles();
			IdAdCondicionPagoDetalle =  odaAdjudicacionesCondicionesPagosDetalles.guardarAdjudicacionesCondicionesPagosDetalles(con, obeAdjudicacionesCondicionesPagosDetalles);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdCondicionPagoDetalle;
			}
	}

	public int actualizarAdjudicacionesCondicionesPagosDetalles(beAdjudicacionesCondicionesPagosDetalles obeAdjudicacionesCondicionesPagosDetalles)
	{
		int IdAdCondicionPagoDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesPagosDetalles odaAdjudicacionesCondicionesPagosDetalles= new daAdjudicacionesCondicionesPagosDetalles();
				IdAdCondicionPagoDetalle =  odaAdjudicacionesCondicionesPagosDetalles.actualizarAdjudicacionesCondicionesPagosDetalles(con, obeAdjudicacionesCondicionesPagosDetalles);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdCondicionPagoDetalle;
			}
	}

	public int eliminarAdjudicacionesCondicionesPagosDetalles(int IdAdCondicionPagoDetalle)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesPagosDetalles odaAdjudicacionesCondicionesPagosDetalles= new daAdjudicacionesCondicionesPagosDetalles();
				IdAdCondicionPagoDetalle =  odaAdjudicacionesCondicionesPagosDetalles.eliminarAdjudicacionesCondicionesPagosDetalles(con, IdAdCondicionPagoDetalle);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdCondicionPagoDetalle;
			}
	}

	public beAdjudicacionesCondicionesPagosDetalles traerAdjudicacionesCondicionesPagosDetalles_x_IdAdCondicionPagoDetalle (int IdAdCondicionPagoDetalle)
	{
		beAdjudicacionesCondicionesPagosDetalles obeAdjudicacionesCondicionesPagosDetalles=new beAdjudicacionesCondicionesPagosDetalles();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesPagosDetalles odaAdjudicacionesCondicionesPagosDetalles= new daAdjudicacionesCondicionesPagosDetalles();
				 obeAdjudicacionesCondicionesPagosDetalles =  odaAdjudicacionesCondicionesPagosDetalles.traerAdjudicacionesCondicionesPagosDetalles_x_IdAdCondicionPagoDetalle(con, IdAdCondicionPagoDetalle);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesCondicionesPagosDetalles;
			}
	}

	public List<beAdjudicacionesCondicionesPagosDetalles> listarTodos_AdjudicacionesCondicionesPagosDetalles()
	 {
		List<beAdjudicacionesCondicionesPagosDetalles> lbeAdjudicacionesCondicionesPagosDetalles =new List<beAdjudicacionesCondicionesPagosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesPagosDetalles odaAdjudicacionesCondicionesPagosDetalles= new daAdjudicacionesCondicionesPagosDetalles();
				 lbeAdjudicacionesCondicionesPagosDetalles =  odaAdjudicacionesCondicionesPagosDetalles.listarTodos_AdjudicacionesCondicionesPagosDetalles(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesPagosDetalles;
		}
	}
	public List<beAdjudicacionesCondicionesPagosDetalles> listarTodos_AdjudicacionesCondicionesPagosDetalles_GetAll()
	 {
		List<beAdjudicacionesCondicionesPagosDetalles> lbeAdjudicacionesCondicionesPagosDetalles =new List<beAdjudicacionesCondicionesPagosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesPagosDetalles odaAdjudicacionesCondicionesPagosDetalles= new daAdjudicacionesCondicionesPagosDetalles();
				 lbeAdjudicacionesCondicionesPagosDetalles =  odaAdjudicacionesCondicionesPagosDetalles.listar_AdjudicacionesCondicionesPagosDetalles_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesPagosDetalles;
		}
	}

        public int eliminarAdjudicacionesCondicionesPagosDetalles_x_IdAdjudicacionCondicionPago(int IdAdjudicacionCondicionPago)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                int IdAdjudicacionCondicionPagoDetalle = 0;
                try
                {
                    con.Open();
                    daAdjudicacionesCondicionesPagosDetalles odaAdjudicacionesCondicionesPagosDetalles = new daAdjudicacionesCondicionesPagosDetalles();
                    IdAdjudicacionCondicionPagoDetalle = odaAdjudicacionesCondicionesPagosDetalles.eliminarAdjudicacionesCondicionesPagosDetalles_x_IdAdjudicacionCondicionPago(con, IdAdjudicacionCondicionPago);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdAdjudicacionCondicionPagoDetalle;
            }
        }

        //public List< beAdjudicacionesCondicionesEntregasDetalles > listar_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion(int IdAdjudicacion)
        //{
        //    List<beAdjudicacionesCondicionesEntregasDetalles> lbeAdjudicacionesCondicionesEntregasDetalles = new List<beAdjudicacionesCondicionesEntregasDetalles>();
        //    using (SqlConnection con = new SqlConnection(CadenaConexion))
        //    {
        //        try
        //        {
        //            con.Open();
        //            daAdjudicacionesCondicionesEntregasDetalles odaAdjudicacionesCondicionesEntregasDetalles = new daAdjudicacionesCondicionesEntregasDetalles();
        //            lbeAdjudicacionesCondicionesEntregasDetalles = odaAdjudicacionesCondicionesEntregasDetalles.listar_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion(con, IdAdjudicacion);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return lbeAdjudicacionesCondicionesEntregasDetalles;
        //    }
        //}



    }
}
