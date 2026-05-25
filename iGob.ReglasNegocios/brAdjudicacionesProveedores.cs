using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesProveedores:brConexion
		 {
	public int guardarAdjudicacionesProveedores(beAdjudicacionesProveedores obeAdjudicacionesProveedores)
	{
		int IdAdjudicacionProveedor;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesProveedores odaAdjudicacionesProveedores= new daAdjudicacionesProveedores();
			IdAdjudicacionProveedor =  odaAdjudicacionesProveedores.guardarAdjudicacionesProveedores(con, obeAdjudicacionesProveedores);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionProveedor;
			}
	}

	public int actualizarAdjudicacionesProveedores(beAdjudicacionesProveedores obeAdjudicacionesProveedores)
	{
		int IdAdjudicacionProveedor;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesProveedores odaAdjudicacionesProveedores= new daAdjudicacionesProveedores();
				IdAdjudicacionProveedor =  odaAdjudicacionesProveedores.actualizarAdjudicacionesProveedores(con, obeAdjudicacionesProveedores);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionProveedor;
			}
	}

	public int eliminarAdjudicacionesProveedores(int IdAdjudicacionProveedor)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesProveedores odaAdjudicacionesProveedores= new daAdjudicacionesProveedores();
				IdAdjudicacionProveedor =  odaAdjudicacionesProveedores.eliminarAdjudicacionesProveedores(con, IdAdjudicacionProveedor);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionProveedor;
			}
	}

	public beAdjudicacionesProveedores traerAdjudicacionesProveedores_x_IdAdjudicacionProveedor (int IdAdjudicacionProveedor)
	{
		beAdjudicacionesProveedores obeAdjudicacionesProveedores=new beAdjudicacionesProveedores();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesProveedores odaAdjudicacionesProveedores= new daAdjudicacionesProveedores();
				 obeAdjudicacionesProveedores =  odaAdjudicacionesProveedores.traerAdjudicacionesProveedores_x_IdAdjudicacionProveedor(con, IdAdjudicacionProveedor);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesProveedores;
			}
	}

	public List<beAdjudicacionesProveedores> listarTodos_AdjudicacionesProveedores()
	 {
		List<beAdjudicacionesProveedores> lbeAdjudicacionesProveedores =new List<beAdjudicacionesProveedores>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesProveedores odaAdjudicacionesProveedores= new daAdjudicacionesProveedores();
				 lbeAdjudicacionesProveedores =  odaAdjudicacionesProveedores.listarTodos_AdjudicacionesProveedores(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesProveedores;
		}
	}
	public List<beAdjudicacionesProveedores> listarTodos_AdjudicacionesProveedores_GetAll()
	 {
		List<beAdjudicacionesProveedores> lbeAdjudicacionesProveedores =new List<beAdjudicacionesProveedores>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesProveedores odaAdjudicacionesProveedores= new daAdjudicacionesProveedores();
				 lbeAdjudicacionesProveedores =  odaAdjudicacionesProveedores.listar_AdjudicacionesProveedores_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesProveedores;
		}
	}

        public List<beAdjudicacionesProveedores> getAllProveedoresAdjudicacion_x_IdAdjudicacion(int IdAdjudicacion, int IdEstatusAdjudicacionProveedor)
        {
            List<beAdjudicacionesProveedores> lbeAdjudicacionesProveedores = new List<beAdjudicacionesProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesProveedores odaAdjudicacionesProveedores = new daAdjudicacionesProveedores();
                    lbeAdjudicacionesProveedores = odaAdjudicacionesProveedores.getAllProveedoresAdjudicacion_x_IdAdjudicacion(con, IdAdjudicacion, IdEstatusAdjudicacionProveedor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesProveedores;
            }
        }

    }
}
