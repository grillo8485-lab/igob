using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brLicitacionesInvitacionProveedores:brConexion
		 {
	public int guardarLicitacionesInvitacionProveedores(beLicitacionesInvitacionProveedores obeLicitacionesInvitacionProveedores)
	{
		int IdInvitacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daLicitacionesInvitacionProveedores odaLicitacionesInvitacionProveedores= new daLicitacionesInvitacionProveedores();
			IdInvitacion =  odaLicitacionesInvitacionProveedores.guardarLicitacionesInvitacionProveedores(con, obeLicitacionesInvitacionProveedores);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdInvitacion;
			}
	}

	public int actualizarLicitacionesInvitacionProveedores(beLicitacionesInvitacionProveedores obeLicitacionesInvitacionProveedores)
	{
		int IdInvitacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daLicitacionesInvitacionProveedores odaLicitacionesInvitacionProveedores= new daLicitacionesInvitacionProveedores();
				IdInvitacion =  odaLicitacionesInvitacionProveedores.actualizarLicitacionesInvitacionProveedores(con, obeLicitacionesInvitacionProveedores);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdInvitacion;
			}
	}

	public int eliminarLicitacionesInvitacionProveedores(int IdInvitacion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daLicitacionesInvitacionProveedores odaLicitacionesInvitacionProveedores= new daLicitacionesInvitacionProveedores();
				IdInvitacion =  odaLicitacionesInvitacionProveedores.eliminarLicitacionesInvitacionProveedores(con, IdInvitacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdInvitacion;
			}
	}

	public beLicitacionesInvitacionProveedores traerLicitacionesInvitacionProveedores_x_IdInvitacion (int IdInvitacion)
	{
		beLicitacionesInvitacionProveedores obeLicitacionesInvitacionProveedores=new beLicitacionesInvitacionProveedores();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daLicitacionesInvitacionProveedores odaLicitacionesInvitacionProveedores= new daLicitacionesInvitacionProveedores();
				 obeLicitacionesInvitacionProveedores =  odaLicitacionesInvitacionProveedores.traerLicitacionesInvitacionProveedores_x_IdInvitacion(con, IdInvitacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeLicitacionesInvitacionProveedores;
			}
	}

	public List<beLicitacionesInvitacionProveedores> listarTodos_LicitacionesInvitacionProveedores()
	 {
		List<beLicitacionesInvitacionProveedores> lbeLicitacionesInvitacionProveedores =new List<beLicitacionesInvitacionProveedores>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daLicitacionesInvitacionProveedores odaLicitacionesInvitacionProveedores= new daLicitacionesInvitacionProveedores();
				 lbeLicitacionesInvitacionProveedores =  odaLicitacionesInvitacionProveedores.listarTodos_LicitacionesInvitacionProveedores(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeLicitacionesInvitacionProveedores;
		}
	}
	public List<beLicitacionesInvitacionProveedores> listarTodos_LicitacionesInvitacionProveedores_GetAll()
	 {
		List<beLicitacionesInvitacionProveedores> lbeLicitacionesInvitacionProveedores =new List<beLicitacionesInvitacionProveedores>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daLicitacionesInvitacionProveedores odaLicitacionesInvitacionProveedores= new daLicitacionesInvitacionProveedores();
				 lbeLicitacionesInvitacionProveedores =  odaLicitacionesInvitacionProveedores.listar_LicitacionesInvitacionProveedores_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeLicitacionesInvitacionProveedores;
		}
	}
}
}
