using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brManifiestoProveedoresClientes:brConexion
		 {
	public int guardarManifiestoProveedoresClientes(beManifiestoProveedoresClientes obeManifiestoProveedoresClientes)
	{
		int IdManifiestoProveedorCliente;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daManifiestoProveedoresClientes odaManifiestoProveedoresClientes= new daManifiestoProveedoresClientes();
			IdManifiestoProveedorCliente =  odaManifiestoProveedoresClientes.guardarManifiestoProveedoresClientes(con, obeManifiestoProveedoresClientes);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdManifiestoProveedorCliente;
			}
	}

	public int actualizarManifiestoProveedoresClientes(beManifiestoProveedoresClientes obeManifiestoProveedoresClientes)
	{
		int IdManifiestoProveedorCliente;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daManifiestoProveedoresClientes odaManifiestoProveedoresClientes= new daManifiestoProveedoresClientes();
				IdManifiestoProveedorCliente =  odaManifiestoProveedoresClientes.actualizarManifiestoProveedoresClientes(con, obeManifiestoProveedoresClientes);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdManifiestoProveedorCliente;
			}
	}

	public int eliminarManifiestoProveedoresClientes(int IdManifiestoProveedorCliente)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daManifiestoProveedoresClientes odaManifiestoProveedoresClientes= new daManifiestoProveedoresClientes();
				IdManifiestoProveedorCliente =  odaManifiestoProveedoresClientes.eliminarManifiestoProveedoresClientes(con, IdManifiestoProveedorCliente);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdManifiestoProveedorCliente;
			}
	}

	public beManifiestoProveedoresClientes traerManifiestoProveedoresClientes_x_IdManifiestoProveedorCliente (int IdManifiestoProveedorCliente)
	{
		beManifiestoProveedoresClientes obeManifiestoProveedoresClientes=new beManifiestoProveedoresClientes();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daManifiestoProveedoresClientes odaManifiestoProveedoresClientes= new daManifiestoProveedoresClientes();
				 obeManifiestoProveedoresClientes =  odaManifiestoProveedoresClientes.traerManifiestoProveedoresClientes_x_IdManifiestoProveedorCliente(con, IdManifiestoProveedorCliente);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeManifiestoProveedoresClientes;
			}
	}

	public List<beManifiestoProveedoresClientes> listarTodos_ManifiestoProveedoresClientes()
	 {
		List<beManifiestoProveedoresClientes> lbeManifiestoProveedoresClientes =new List<beManifiestoProveedoresClientes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daManifiestoProveedoresClientes odaManifiestoProveedoresClientes= new daManifiestoProveedoresClientes();
				 lbeManifiestoProveedoresClientes =  odaManifiestoProveedoresClientes.listarTodos_ManifiestoProveedoresClientes(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeManifiestoProveedoresClientes;
		}
	}
	public List<beManifiestoProveedoresClientes> listarTodos_ManifiestoProveedoresClientes_GetAll()
	 {
		List<beManifiestoProveedoresClientes> lbeManifiestoProveedoresClientes =new List<beManifiestoProveedoresClientes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daManifiestoProveedoresClientes odaManifiestoProveedoresClientes= new daManifiestoProveedoresClientes();
				 lbeManifiestoProveedoresClientes =  odaManifiestoProveedoresClientes.listar_ManifiestoProveedoresClientes_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeManifiestoProveedoresClientes;
		}
	}
        public List<beManifiestoProveedoresClientes> getAllManifiestosProveedores_x_IdManifiestoProveedor(int pIdManifiestoProveedor)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                List<beManifiestoProveedoresClientes> lstManifiestoProveedoresClientes = new List<beManifiestoProveedoresClientes>();
                try
                {
                    con.Open();
                    daManifiestoProveedoresClientes odaManifiestoProveedoresClientes = new daManifiestoProveedoresClientes();
                    lstManifiestoProveedoresClientes = odaManifiestoProveedoresClientes.getAllManifiestosProveedores_x_IdManifiestoProveedor(con, pIdManifiestoProveedor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lstManifiestoProveedoresClientes;
            }
        }
    }
}
