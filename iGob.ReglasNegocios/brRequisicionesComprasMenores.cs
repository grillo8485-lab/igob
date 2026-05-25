using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRequisicionesComprasMenores:brConexion
		 {
	public int guardarRequisicionesComprasMenores(beRequisicionesComprasMenores obeRequisicionesComprasMenores)
	{
		int IdRequisicionCompraMenor;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRequisicionesComprasMenores odaRequisicionesComprasMenores= new daRequisicionesComprasMenores();
			IdRequisicionCompraMenor =  odaRequisicionesComprasMenores.guardarRequisicionesComprasMenores(con, obeRequisicionesComprasMenores);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionCompraMenor;
			}
	}

	public int actualizarRequisicionesComprasMenores(beRequisicionesComprasMenores obeRequisicionesComprasMenores)
	{
		int IdRequisicionCompraMenor;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesComprasMenores odaRequisicionesComprasMenores= new daRequisicionesComprasMenores();
				IdRequisicionCompraMenor =  odaRequisicionesComprasMenores.actualizarRequisicionesComprasMenores(con, obeRequisicionesComprasMenores);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionCompraMenor;
			}
	}

	public int eliminarRequisicionesComprasMenores(int IdRequisicionCompraMenor)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesComprasMenores odaRequisicionesComprasMenores= new daRequisicionesComprasMenores();
				IdRequisicionCompraMenor =  odaRequisicionesComprasMenores.eliminarRequisicionesComprasMenores(con, IdRequisicionCompraMenor);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionCompraMenor;
			}
	}

	public beRequisicionesComprasMenores traerRequisicionesComprasMenores_x_IdRequisicionCompraMenor (int IdRequisicionCompraMenor)
	{
		beRequisicionesComprasMenores obeRequisicionesComprasMenores=new beRequisicionesComprasMenores();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesComprasMenores odaRequisicionesComprasMenores= new daRequisicionesComprasMenores();
				 obeRequisicionesComprasMenores =  odaRequisicionesComprasMenores.traerRequisicionesComprasMenores_x_IdRequisicionCompraMenor(con, IdRequisicionCompraMenor);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesComprasMenores;
			}
	}

        /*
	public List<beRequisicionesComprasMenores> listarTodos_RequisicionesComprasMenores()
	 {
		List<beRequisicionesComprasMenores> lbeRequisicionesComprasMenores =new List<beRequisicionesComprasMenores>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesComprasMenores odaRequisicionesComprasMenores= new daRequisicionesComprasMenores();
				 lbeRequisicionesComprasMenores =  odaRequisicionesComprasMenores.listarTodos_RequisicionesComprasMenores(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesComprasMenores;
		}
	}
        */

    /*
	public List<beRequisicionesComprasMenores> listarTodos_RequisicionesComprasMenores_GetAll()
	 {
		List<beRequisicionesComprasMenores> lbeRequisicionesComprasMenores =new List<beRequisicionesComprasMenores>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesComprasMenores odaRequisicionesComprasMenores= new daRequisicionesComprasMenores();
				 lbeRequisicionesComprasMenores =  odaRequisicionesComprasMenores.listar_RequisicionesComprasMenores_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesComprasMenores;
		}
	}
    */

    public List<beRequisicionesComprasMenores> listarTodos_RequisicionesComprasMenores_Listado(beGenerica oGenerico)
    {
        List<beRequisicionesComprasMenores> lbeRequisicionesComprasMenores = new List<beRequisicionesComprasMenores>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daRequisicionesComprasMenores odaRequisicionesComprasMenores = new daRequisicionesComprasMenores();
                lbeRequisicionesComprasMenores = odaRequisicionesComprasMenores.listar_RequisicionesComprasMenores_Listado(con, oGenerico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeRequisicionesComprasMenores;
        }
    }
    }
}
