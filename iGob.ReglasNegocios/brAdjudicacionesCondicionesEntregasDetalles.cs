using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesCondicionesEntregasDetalles:brConexion
		 {
	public int guardarAdjudicacionesCondicionesEntregasDetalles(beAdjudicacionesCondicionesEntregasDetalles obeAdjudicacionesCondicionesEntregasDetalles)
	{
		int IdAdCondicionEntregaDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesCondicionesEntregasDetalles odaAdjudicacionesCondicionesEntregasDetalles= new daAdjudicacionesCondicionesEntregasDetalles();
			IdAdCondicionEntregaDetalle =  odaAdjudicacionesCondicionesEntregasDetalles.guardarAdjudicacionesCondicionesEntregasDetalles(con, obeAdjudicacionesCondicionesEntregasDetalles);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdCondicionEntregaDetalle;
			}
	}

	public int actualizarAdjudicacionesCondicionesEntregasDetalles(beAdjudicacionesCondicionesEntregasDetalles obeAdjudicacionesCondicionesEntregasDetalles)
	{
		int IdAdCondicionEntregaDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesEntregasDetalles odaAdjudicacionesCondicionesEntregasDetalles= new daAdjudicacionesCondicionesEntregasDetalles();
				IdAdCondicionEntregaDetalle =  odaAdjudicacionesCondicionesEntregasDetalles.actualizarAdjudicacionesCondicionesEntregasDetalles(con, obeAdjudicacionesCondicionesEntregasDetalles);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdCondicionEntregaDetalle;
			}
	}

	public int eliminarAdjudicacionesCondicionesEntregasDetalles(int IdAdCondicionEntregaDetalle)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesEntregasDetalles odaAdjudicacionesCondicionesEntregasDetalles= new daAdjudicacionesCondicionesEntregasDetalles();
				IdAdCondicionEntregaDetalle =  odaAdjudicacionesCondicionesEntregasDetalles.eliminarAdjudicacionesCondicionesEntregasDetalles(con, IdAdCondicionEntregaDetalle);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdCondicionEntregaDetalle;
			}
	}

	public beAdjudicacionesCondicionesEntregasDetalles traerAdjudicacionesCondicionesEntregasDetalles_x_IdAdCondicionEntregaDetalle (int IdAdCondicionEntregaDetalle)
	{
		beAdjudicacionesCondicionesEntregasDetalles obeAdjudicacionesCondicionesEntregasDetalles=new beAdjudicacionesCondicionesEntregasDetalles();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesEntregasDetalles odaAdjudicacionesCondicionesEntregasDetalles= new daAdjudicacionesCondicionesEntregasDetalles();
				 obeAdjudicacionesCondicionesEntregasDetalles =  odaAdjudicacionesCondicionesEntregasDetalles.traerAdjudicacionesCondicionesEntregasDetalles_x_IdAdCondicionEntregaDetalle(con, IdAdCondicionEntregaDetalle);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesCondicionesEntregasDetalles;
			}
	}

	public List<beAdjudicacionesCondicionesEntregasDetalles> listarTodos_AdjudicacionesCondicionesEntregasDetalles()
	 {
		List<beAdjudicacionesCondicionesEntregasDetalles> lbeAdjudicacionesCondicionesEntregasDetalles =new List<beAdjudicacionesCondicionesEntregasDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesEntregasDetalles odaAdjudicacionesCondicionesEntregasDetalles= new daAdjudicacionesCondicionesEntregasDetalles();
				 lbeAdjudicacionesCondicionesEntregasDetalles =  odaAdjudicacionesCondicionesEntregasDetalles.listarTodos_AdjudicacionesCondicionesEntregasDetalles(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesEntregasDetalles;
		}
	}
	public List<beAdjudicacionesCondicionesEntregasDetalles> listarTodos_AdjudicacionesCondicionesEntregasDetalles_GetAll()
	 {
		List<beAdjudicacionesCondicionesEntregasDetalles> lbeAdjudicacionesCondicionesEntregasDetalles =new List<beAdjudicacionesCondicionesEntregasDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesEntregasDetalles odaAdjudicacionesCondicionesEntregasDetalles= new daAdjudicacionesCondicionesEntregasDetalles();
				 lbeAdjudicacionesCondicionesEntregasDetalles =  odaAdjudicacionesCondicionesEntregasDetalles.listar_AdjudicacionesCondicionesEntregasDetalles_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesEntregasDetalles;
		}
	}

    public List<beAdjudicacionesCondicionesDetallesIdAdjudicacion> listar_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion(int IdAdjudicacion)

    {
        List<beAdjudicacionesCondicionesDetallesIdAdjudicacion> lbeAdjudicacionesCondicionesEntregasDetalles = new List<beAdjudicacionesCondicionesDetallesIdAdjudicacion>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daAdjudicacionesCondicionesEntregasDetalles odaAdjudicacionesCondicionesEntregasDetalles = new daAdjudicacionesCondicionesEntregasDetalles();
                    lbeAdjudicacionesCondicionesEntregasDetalles = odaAdjudicacionesCondicionesEntregasDetalles.listar_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion(con, IdAdjudicacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeAdjudicacionesCondicionesEntregasDetalles;
        }
    }

        public List<beAdjudicacionesCondicionesEntregasDetalles > listar_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacionCondicionEntrega(int IdAdjudicacionCondicionEntrega)

        {
            List<beAdjudicacionesCondicionesEntregasDetalles> lbeAdjudicacionesCondicionesEntregasDetalles = new List<beAdjudicacionesCondicionesEntregasDetalles>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesCondicionesEntregasDetalles  odaAdjudicacionesCondicionesEntregasDetalles = new daAdjudicacionesCondicionesEntregasDetalles();
                    lbeAdjudicacionesCondicionesEntregasDetalles = odaAdjudicacionesCondicionesEntregasDetalles.listar_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacionCondicionEntrega(con, IdAdjudicacionCondicionEntrega);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesCondicionesEntregasDetalles;
            }
        }
    }
}
