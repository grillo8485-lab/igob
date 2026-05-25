using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brProveedoresGirosComerciales:brConexion
		 {
	public int guardarProveedoresGirosComerciales(beProveedoresGirosComerciales obeProveedoresGirosComerciales)
	{
		int IdProveedorGiroComercial;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daProveedoresGirosComerciales odaProveedoresGirosComerciales= new daProveedoresGirosComerciales();
			IdProveedorGiroComercial =  odaProveedoresGirosComerciales.guardarProveedoresGirosComerciales(con, obeProveedoresGirosComerciales);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorGiroComercial;
			}
	}

	public int actualizarProveedoresGirosComerciales(beProveedoresGirosComerciales obeProveedoresGirosComerciales)
	{
		int IdProveedorGiroComercial;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresGirosComerciales odaProveedoresGirosComerciales= new daProveedoresGirosComerciales();
				IdProveedorGiroComercial =  odaProveedoresGirosComerciales.actualizarProveedoresGirosComerciales(con, obeProveedoresGirosComerciales);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorGiroComercial;
			}
	}

	public int eliminarProveedoresGirosComerciales(int IdProveedorGiroComercial)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresGirosComerciales odaProveedoresGirosComerciales= new daProveedoresGirosComerciales();
				IdProveedorGiroComercial =  odaProveedoresGirosComerciales.eliminarProveedoresGirosComerciales(con, IdProveedorGiroComercial);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorGiroComercial;
			}
	}

	public beProveedoresGirosComerciales traerProveedoresGirosComerciales_x_IdProveedorGiroComercial (int IdProveedorGiroComercial)
	{
		beProveedoresGirosComerciales obeProveedoresGirosComerciales=new beProveedoresGirosComerciales();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresGirosComerciales odaProveedoresGirosComerciales= new daProveedoresGirosComerciales();
				 obeProveedoresGirosComerciales =  odaProveedoresGirosComerciales.traerProveedoresGirosComerciales_x_IdProveedorGiroComercial(con, IdProveedorGiroComercial);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedoresGirosComerciales;
			}
	}

	public List<beProveedoresGirosComerciales> listarTodos_ProveedoresGirosComerciales()
	 {
		List<beProveedoresGirosComerciales> lbeProveedoresGirosComerciales =new List<beProveedoresGirosComerciales>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresGirosComerciales odaProveedoresGirosComerciales= new daProveedoresGirosComerciales();
				 lbeProveedoresGirosComerciales =  odaProveedoresGirosComerciales.listarTodos_ProveedoresGirosComerciales(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresGirosComerciales;
		}
	}
    public List<beProveedoresGirosComerciales> listarTodos_ProveedoresGirosComerciales_GetAll()
    {
        List<beProveedoresGirosComerciales> lbeProveedoresGirosComerciales = new List<beProveedoresGirosComerciales>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daProveedoresGirosComerciales odaProveedoresGirosComerciales = new daProveedoresGirosComerciales();
                lbeProveedoresGirosComerciales = odaProveedoresGirosComerciales.listarTodos_ProveedoresGirosComerciales_GetAll(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeProveedoresGirosComerciales;
        }
    }
    }
}
