using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRequisicionesComprasMenoresLotes:brConexion
		 {
	public int guardarRequisicionesComprasMenoresLotes(beRequisicionesComprasMenoresLotes obeRequisicionesComprasMenoresLotes)
	{
		int IdLoteCompraMenor;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRequisicionesComprasMenoresLotes odaRequisicionesComprasMenoresLotes= new daRequisicionesComprasMenoresLotes();
			IdLoteCompraMenor =  odaRequisicionesComprasMenoresLotes.guardarRequisicionesComprasMenoresLotes(con, obeRequisicionesComprasMenoresLotes);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdLoteCompraMenor;
			}
	}

	public int actualizarRequisicionesComprasMenoresLotes(beRequisicionesComprasMenoresLotes obeRequisicionesComprasMenoresLotes)
	{
		int IdLoteCompraMenor;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesComprasMenoresLotes odaRequisicionesComprasMenoresLotes= new daRequisicionesComprasMenoresLotes();
				IdLoteCompraMenor =  odaRequisicionesComprasMenoresLotes.actualizarRequisicionesComprasMenoresLotes(con, obeRequisicionesComprasMenoresLotes);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdLoteCompraMenor;
			}
	}

	public int eliminarRequisicionesComprasMenoresLotes(int IdLoteCompraMenor)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesComprasMenoresLotes odaRequisicionesComprasMenoresLotes= new daRequisicionesComprasMenoresLotes();
				IdLoteCompraMenor =  odaRequisicionesComprasMenoresLotes.eliminarRequisicionesComprasMenoresLotes(con, IdLoteCompraMenor);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdLoteCompraMenor;
			}
	}

	public beRequisicionesComprasMenoresLotes traerRequisicionesComprasMenoresLotes_x_IdLoteCompraMenor (int IdLoteCompraMenor)
	{
		beRequisicionesComprasMenoresLotes obeRequisicionesComprasMenoresLotes=new beRequisicionesComprasMenoresLotes();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesComprasMenoresLotes odaRequisicionesComprasMenoresLotes= new daRequisicionesComprasMenoresLotes();
				 obeRequisicionesComprasMenoresLotes =  odaRequisicionesComprasMenoresLotes.traerRequisicionesComprasMenoresLotes_x_IdLoteCompraMenor(con, IdLoteCompraMenor);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesComprasMenoresLotes;
			}
	}

	public List<beRequisicionesComprasMenoresLotes> listarTodos_RequisicionesComprasMenoresLotes()
	 {
		List<beRequisicionesComprasMenoresLotes> lbeRequisicionesComprasMenoresLotes =new List<beRequisicionesComprasMenoresLotes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesComprasMenoresLotes odaRequisicionesComprasMenoresLotes= new daRequisicionesComprasMenoresLotes();
				 lbeRequisicionesComprasMenoresLotes =  odaRequisicionesComprasMenoresLotes.listarTodos_RequisicionesComprasMenoresLotes(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesComprasMenoresLotes;
		}
	}
	public List<beRequisicionesComprasMenoresLotes> listarTodos_RequisicionesComprasMenoresLotes_GetAll()
	 {
		List<beRequisicionesComprasMenoresLotes> lbeRequisicionesComprasMenoresLotes =new List<beRequisicionesComprasMenoresLotes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesComprasMenoresLotes odaRequisicionesComprasMenoresLotes= new daRequisicionesComprasMenoresLotes();
				 lbeRequisicionesComprasMenoresLotes =  odaRequisicionesComprasMenoresLotes.listar_RequisicionesComprasMenoresLotes_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesComprasMenoresLotes;
		}
	}
    public List<beRequisicionesComprasMenoresLotes> listarTodos_RequisicionesComprasMenoresLotes_GetAllAll()
    {
        List<beRequisicionesComprasMenoresLotes> lbeRequisicionesComprasMenoresLotes = new List<beRequisicionesComprasMenoresLotes>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daRequisicionesComprasMenoresLotes odaRequisicionesComprasMenoresLotes = new daRequisicionesComprasMenoresLotes();
                lbeRequisicionesComprasMenoresLotes = odaRequisicionesComprasMenoresLotes.listarTodos_RequisicionesComprasMenoresLotesGetAllAll(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeRequisicionesComprasMenoresLotes;
        }
    }
    public List<beRequisicionesComprasMenoresLotes> traerRequisicionesComprasMenoresLotes_x_IdRequisicionCompraMenor(int IdRequisicionCompraMenor)
    {
        List<beRequisicionesComprasMenoresLotes> lbeRequisicionesComprasMenoresLotes = new List<beRequisicionesComprasMenoresLotes>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daRequisicionesComprasMenoresLotes odaRequisicionesComprasMenoresLotes = new daRequisicionesComprasMenoresLotes();
                    lbeRequisicionesComprasMenoresLotes = odaRequisicionesComprasMenoresLotes.traerRequisicionesComprasMenoresLotes_x_IdRequisicionCompraMenor(con, IdRequisicionCompraMenor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeRequisicionesComprasMenoresLotes;
        }
    }
    }
}
