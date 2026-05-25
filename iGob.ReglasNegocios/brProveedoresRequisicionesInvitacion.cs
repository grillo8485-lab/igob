using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brProveedoresRequisicionesInvitacion:brConexion
		 {
	public int guardarProveedoresRequisicionesInvitacion(beProveedoresRequisicionesInvitacion obeProveedoresRequisicionesInvitacion)
	{
		int IdProveedorRqInvitacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daProveedoresRequisicionesInvitacion odaProveedoresRequisicionesInvitacion= new daProveedoresRequisicionesInvitacion();
			IdProveedorRqInvitacion =  odaProveedoresRequisicionesInvitacion.guardarProveedoresRequisicionesInvitacion(con, obeProveedoresRequisicionesInvitacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorRqInvitacion;
			}
	}

	public int actualizarProveedoresRequisicionesInvitacion(beProveedoresRequisicionesInvitacion obeProveedoresRequisicionesInvitacion)
	{
		int IdProveedorRqInvitacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresRequisicionesInvitacion odaProveedoresRequisicionesInvitacion= new daProveedoresRequisicionesInvitacion();
				IdProveedorRqInvitacion =  odaProveedoresRequisicionesInvitacion.actualizarProveedoresRequisicionesInvitacion(con, obeProveedoresRequisicionesInvitacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorRqInvitacion;
			}
	}

	public int eliminarProveedoresRequisicionesInvitacion(int IdProveedorRqInvitacion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresRequisicionesInvitacion odaProveedoresRequisicionesInvitacion= new daProveedoresRequisicionesInvitacion();
				IdProveedorRqInvitacion =  odaProveedoresRequisicionesInvitacion.eliminarProveedoresRequisicionesInvitacion(con, IdProveedorRqInvitacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorRqInvitacion;
			}
	}

	public beProveedoresRequisicionesInvitacion traerProveedoresRequisicionesInvitacion_x_IdProveedorRqInvitacion (int IdProveedorRqInvitacion)
	{
		beProveedoresRequisicionesInvitacion obeProveedoresRequisicionesInvitacion=new beProveedoresRequisicionesInvitacion();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresRequisicionesInvitacion odaProveedoresRequisicionesInvitacion= new daProveedoresRequisicionesInvitacion();
				 obeProveedoresRequisicionesInvitacion =  odaProveedoresRequisicionesInvitacion.traerProveedoresRequisicionesInvitacion_x_IdProveedorRqInvitacion(con, IdProveedorRqInvitacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedoresRequisicionesInvitacion;
			}
	}

	public List<beProveedoresRequisicionesInvitacion> listarTodos_ProveedoresRequisicionesInvitacion()
	 {
		List<beProveedoresRequisicionesInvitacion> lbeProveedoresRequisicionesInvitacion =new List<beProveedoresRequisicionesInvitacion>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresRequisicionesInvitacion odaProveedoresRequisicionesInvitacion= new daProveedoresRequisicionesInvitacion();
				 lbeProveedoresRequisicionesInvitacion =  odaProveedoresRequisicionesInvitacion.listarTodos_ProveedoresRequisicionesInvitacion(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresRequisicionesInvitacion;
		}
	}
	public List<beProveedoresRequisicionesInvitacion> listarTodos_ProveedoresRequisicionesInvitacion_GetAll()
	 {
		List<beProveedoresRequisicionesInvitacion> lbeProveedoresRequisicionesInvitacion =new List<beProveedoresRequisicionesInvitacion>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresRequisicionesInvitacion odaProveedoresRequisicionesInvitacion= new daProveedoresRequisicionesInvitacion();
				 lbeProveedoresRequisicionesInvitacion =  odaProveedoresRequisicionesInvitacion.listar_ProveedoresRequisicionesInvitacion_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresRequisicionesInvitacion;
		}
	}
}
}
