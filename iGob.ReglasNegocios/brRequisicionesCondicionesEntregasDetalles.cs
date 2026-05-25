using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRequisicionesCondicionesEntregasDetalles:brConexion
		 {
	public int guardarRequisicionesCondicionesEntregasDetalles(beRequisicionesCondicionesEntregasDetalles obeRequisicionesCondicionesEntregasDetalles)
	{
		int IdCondicionEntregaDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRequisicionesCondicionesEntregasDetalles odaRequisicionesCondicionesEntregasDetalles= new daRequisicionesCondicionesEntregasDetalles();
			IdCondicionEntregaDetalle =  odaRequisicionesCondicionesEntregasDetalles.guardarRequisicionesCondicionesEntregasDetalles(con, obeRequisicionesCondicionesEntregasDetalles);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdCondicionEntregaDetalle;
			}
	}

	public int actualizarRequisicionesCondicionesEntregasDetalles(beRequisicionesCondicionesEntregasDetalles obeRequisicionesCondicionesEntregasDetalles)
	{
		int IdCondicionEntregaDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesEntregasDetalles odaRequisicionesCondicionesEntregasDetalles= new daRequisicionesCondicionesEntregasDetalles();
				IdCondicionEntregaDetalle =  odaRequisicionesCondicionesEntregasDetalles.actualizarRequisicionesCondicionesEntregasDetalles(con, obeRequisicionesCondicionesEntregasDetalles);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdCondicionEntregaDetalle;
			}
	}

	public int eliminarRequisicionesCondicionesEntregasDetalles(int IdCondicionEntregaDetalle)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesEntregasDetalles odaRequisicionesCondicionesEntregasDetalles= new daRequisicionesCondicionesEntregasDetalles();
				IdCondicionEntregaDetalle =  odaRequisicionesCondicionesEntregasDetalles.eliminarRequisicionesCondicionesEntregasDetalles(con, IdCondicionEntregaDetalle);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdCondicionEntregaDetalle;
			}
	}

	public beRequisicionesCondicionesEntregasDetalles traerRequisicionesCondicionesEntregasDetalles_x_IdCondicionEntregaDetalle (int IdCondicionEntregaDetalle)
	{
		beRequisicionesCondicionesEntregasDetalles obeRequisicionesCondicionesEntregasDetalles=new beRequisicionesCondicionesEntregasDetalles();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesEntregasDetalles odaRequisicionesCondicionesEntregasDetalles= new daRequisicionesCondicionesEntregasDetalles();
				 obeRequisicionesCondicionesEntregasDetalles =  odaRequisicionesCondicionesEntregasDetalles.traerRequisicionesCondicionesEntregasDetalles_x_IdCondicionEntregaDetalle(con, IdCondicionEntregaDetalle);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesCondicionesEntregasDetalles;
			}
	}

	public List<beRequisicionesCondicionesEntregasDetalles> listarTodos_RequisicionesCondicionesEntregasDetalles()
	 {
		List<beRequisicionesCondicionesEntregasDetalles> lbeRequisicionesCondicionesEntregasDetalles =new List<beRequisicionesCondicionesEntregasDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesEntregasDetalles odaRequisicionesCondicionesEntregasDetalles= new daRequisicionesCondicionesEntregasDetalles();
				 lbeRequisicionesCondicionesEntregasDetalles =  odaRequisicionesCondicionesEntregasDetalles.listarTodos_RequisicionesCondicionesEntregasDetalles(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesEntregasDetalles;
		}
	}
	public List<beRequisicionesCondicionesEntregasDetalles> listarTodos_RequisicionesCondicionesEntregasDetalles_GetAll()
	 {
		List<beRequisicionesCondicionesEntregasDetalles> lbeRequisicionesCondicionesEntregasDetalles =new List<beRequisicionesCondicionesEntregasDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesEntregasDetalles odaRequisicionesCondicionesEntregasDetalles= new daRequisicionesCondicionesEntregasDetalles();
				 lbeRequisicionesCondicionesEntregasDetalles =  odaRequisicionesCondicionesEntregasDetalles.listar_RequisicionesCondicionesEntregasDetalles_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesEntregasDetalles;
		}
	}
        public List<beRequisiciconesCondicionesDetallesIdRequisicion> listar_RequisicionesCondicionesEntregasDetalles_x_IdRequisicion(int IdRequisicion)

     {
            List<beRequisiciconesCondicionesDetallesIdRequisicion> lbeRequisicionesCondicionesEntregasDetalles = new List<beRequisiciconesCondicionesDetallesIdRequisicion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesCondicionesEntregasDetalles odaRequisicionesCondicionesEntregasDetalles = new daRequisicionesCondicionesEntregasDetalles();
                    lbeRequisicionesCondicionesEntregasDetalles = odaRequisicionesCondicionesEntregasDetalles.listar_RequisicionesCondicionesEntregasDetalles_x_IdRequisicion(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesEntregasDetalles;
            }
        }
        public List<beRequisicionCondicionesEntregaDetalleConsulta> listar_RequisicionesCondicionesEntregasDetalles_x_IdRequisicionCondicionEntrega(int IdRequisicionCondicionEntrega)

        {
            List<beRequisicionCondicionesEntregaDetalleConsulta> lbeRequisicionesCondicionesEntregasDetalles = new List<beRequisicionCondicionesEntregaDetalleConsulta>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesCondicionesEntregasDetalles odaRequisicionesCondicionesEntregasDetalles = new daRequisicionesCondicionesEntregasDetalles();
                    lbeRequisicionesCondicionesEntregasDetalles = odaRequisicionesCondicionesEntregasDetalles.listar_RequisicionesCondicionesEntregasDetalles_x_IdRequisicionCondicionEntrega(con, IdRequisicionCondicionEntrega);
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
