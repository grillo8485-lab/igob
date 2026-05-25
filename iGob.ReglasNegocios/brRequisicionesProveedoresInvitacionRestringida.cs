using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRequisicionesProveedoresInvitacionRestringida:brConexion
		 {
	public int guardarRequisicionesProveedoresInvitacionRestringida(beRequisicionesProveedoresInvitacionRestringida obeRequisicionesProveedoresInvitacionRestringida)
	{
		int IdRequisicionProveedorInvitacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRequisicionesProveedoresInvitacionRestringida odaRequisicionesProveedoresInvitacionRestringida= new daRequisicionesProveedoresInvitacionRestringida();
			IdRequisicionProveedorInvitacion =  odaRequisicionesProveedoresInvitacionRestringida.guardarRequisicionesProveedoresInvitacionRestringida(con, obeRequisicionesProveedoresInvitacionRestringida);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionProveedorInvitacion;
			}
	}

	public int actualizarRequisicionesProveedoresInvitacionRestringida(beRequisicionesProveedoresInvitacionRestringida obeRequisicionesProveedoresInvitacionRestringida)
	{
		int IdRequisicionProveedorInvitacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesProveedoresInvitacionRestringida odaRequisicionesProveedoresInvitacionRestringida= new daRequisicionesProveedoresInvitacionRestringida();
				IdRequisicionProveedorInvitacion =  odaRequisicionesProveedoresInvitacionRestringida.actualizarRequisicionesProveedoresInvitacionRestringida(con, obeRequisicionesProveedoresInvitacionRestringida);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionProveedorInvitacion;
			}
	}

	public int eliminarRequisicionesProveedoresInvitacionRestringida(int IdRequisicionProveedorInvitacion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesProveedoresInvitacionRestringida odaRequisicionesProveedoresInvitacionRestringida= new daRequisicionesProveedoresInvitacionRestringida();
				IdRequisicionProveedorInvitacion =  odaRequisicionesProveedoresInvitacionRestringida.eliminarRequisicionesProveedoresInvitacionRestringida(con, IdRequisicionProveedorInvitacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionProveedorInvitacion;
			}
	}

	public beRequisicionesProveedoresInvitacionRestringida traerRequisicionesProveedoresInvitacionRestringida_x_IdRequisicionProveedorInvitacion (int IdRequisicionProveedorInvitacion)
	{
		beRequisicionesProveedoresInvitacionRestringida obeRequisicionesProveedoresInvitacionRestringida=new beRequisicionesProveedoresInvitacionRestringida();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesProveedoresInvitacionRestringida odaRequisicionesProveedoresInvitacionRestringida= new daRequisicionesProveedoresInvitacionRestringida();
				 obeRequisicionesProveedoresInvitacionRestringida =  odaRequisicionesProveedoresInvitacionRestringida.traerRequisicionesProveedoresInvitacionRestringida_x_IdRequisicionProveedorInvitacion(con, IdRequisicionProveedorInvitacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesProveedoresInvitacionRestringida;
			}
	}

	public List<beRequisicionesProveedoresInvitacionRestringida> listarTodos_RequisicionesProveedoresInvitacionRestringida()
	 {
		List<beRequisicionesProveedoresInvitacionRestringida> lbeRequisicionesProveedoresInvitacionRestringida =new List<beRequisicionesProveedoresInvitacionRestringida>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesProveedoresInvitacionRestringida odaRequisicionesProveedoresInvitacionRestringida= new daRequisicionesProveedoresInvitacionRestringida();
				 lbeRequisicionesProveedoresInvitacionRestringida =  odaRequisicionesProveedoresInvitacionRestringida.listarTodos_RequisicionesProveedoresInvitacionRestringida(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesProveedoresInvitacionRestringida;
		}
	}
	public List<beRequisicionesProveedoresInvitacionRestringida> listarTodos_RequisicionesProveedoresInvitacionRestringida_GetAll()
	 {
		List<beRequisicionesProveedoresInvitacionRestringida> lbeRequisicionesProveedoresInvitacionRestringida =new List<beRequisicionesProveedoresInvitacionRestringida>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesProveedoresInvitacionRestringida odaRequisicionesProveedoresInvitacionRestringida= new daRequisicionesProveedoresInvitacionRestringida();
				 lbeRequisicionesProveedoresInvitacionRestringida =  odaRequisicionesProveedoresInvitacionRestringida.listar_RequisicionesProveedoresInvitacionRestringida_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesProveedoresInvitacionRestringida;
		}
	}
}
}
