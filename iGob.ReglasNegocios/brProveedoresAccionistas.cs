using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brProveedoresAccionistas:brConexion
		 {
	public int guardarProveedoresAccionistas(beProveedoresAccionistas obeProveedoresAccionistas)
	{
		int IdProveedorAccionista;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daProveedoresAccionistas odaProveedoresAccionistas= new daProveedoresAccionistas();
			IdProveedorAccionista =  odaProveedoresAccionistas.guardarProveedoresAccionistas(con, obeProveedoresAccionistas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorAccionista;
			}
	}

	public int actualizarProveedoresAccionistas(beProveedoresAccionistas obeProveedoresAccionistas)
	{
		int IdProveedorAccionista;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresAccionistas odaProveedoresAccionistas= new daProveedoresAccionistas();
				IdProveedorAccionista =  odaProveedoresAccionistas.actualizarProveedoresAccionistas(con, obeProveedoresAccionistas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorAccionista;
			}
	}

	public int eliminarProveedoresAccionistas(int IdProveedorAccionista)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresAccionistas odaProveedoresAccionistas= new daProveedoresAccionistas();
				IdProveedorAccionista =  odaProveedoresAccionistas.eliminarProveedoresAccionistas(con, IdProveedorAccionista);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorAccionista;
			}
	}

	public beProveedoresAccionistas traerProveedoresAccionistas_x_IdProveedorAccionista (int IdProveedorAccionista)
	{
		beProveedoresAccionistas obeProveedoresAccionistas=new beProveedoresAccionistas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresAccionistas odaProveedoresAccionistas= new daProveedoresAccionistas();
				 obeProveedoresAccionistas =  odaProveedoresAccionistas.traerProveedoresAccionistas_x_IdProveedorAccionista(con, IdProveedorAccionista);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedoresAccionistas;
			}
	}

	public List<beProveedoresAccionistas> listarTodos_ProveedoresAccionistas()
	 {
		List<beProveedoresAccionistas> lbeProveedoresAccionistas =new List<beProveedoresAccionistas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresAccionistas odaProveedoresAccionistas= new daProveedoresAccionistas();
				 lbeProveedoresAccionistas =  odaProveedoresAccionistas.listarTodos_ProveedoresAccionistas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresAccionistas;
		}
	}

    public List<beProveedoresAccionistas> listarTodos_ProveedoresAccionistas_GetAll()
    {
        List<beProveedoresAccionistas> lbeProveedoresAccionistas = new List<beProveedoresAccionistas>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daProveedoresAccionistas odaProveedoresAccionistas = new daProveedoresAccionistas();
                lbeProveedoresAccionistas = odaProveedoresAccionistas.listarTodos_ProveedoresAccionistas_GetAll(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeProveedoresAccionistas;
        }
    }
    }
}
