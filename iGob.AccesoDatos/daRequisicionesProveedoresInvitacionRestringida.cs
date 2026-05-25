using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daRequisicionesProveedoresInvitacionRestringida
 {
	public int guardarRequisicionesProveedoresInvitacionRestringida(SqlConnection Conexion, beRequisicionesProveedoresInvitacionRestringida obeRequisicionesProveedoresInvitacionRestringida)
	{
		int Id=0;
		string sp = "Proc_RequisicionesProveedoresInvitacionRestringidaInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRequisicionProveedorInvitacion", SqlDbType.Int).Value = obeRequisicionesProveedoresInvitacionRestringida.IdRequisicionProveedorInvitacion;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesProveedoresInvitacionRestringida.IdRequisicion;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeRequisicionesProveedoresInvitacionRestringida.IdProveedor;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesProveedoresInvitacionRestringida.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesProveedoresInvitacionRestringida.FechaRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarRequisicionesProveedoresInvitacionRestringida(SqlConnection Conexion, beRequisicionesProveedoresInvitacionRestringida obeRequisicionesProveedoresInvitacionRestringida)
	{
		string sp = "Proc_RequisicionesProveedoresInvitacionRestringidaActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRequisicionProveedorInvitacion", SqlDbType.Int).Value = obeRequisicionesProveedoresInvitacionRestringida.IdRequisicionProveedorInvitacion;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesProveedoresInvitacionRestringida.IdRequisicion;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeRequisicionesProveedoresInvitacionRestringida.IdProveedor;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesProveedoresInvitacionRestringida.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesProveedoresInvitacionRestringida.FechaRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarRequisicionesProveedoresInvitacionRestringida(SqlConnection Conexion,int pIdRequisicionProveedorInvitacion)
	{
		string sp = "Proc_RequisicionesProveedoresInvitacionRestringidaEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRequisicionProveedorInvitacion", SqlDbType.Int).Value = pIdRequisicionProveedorInvitacion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beRequisicionesProveedoresInvitacionRestringida traerRequisicionesProveedoresInvitacionRestringida_x_IdRequisicionProveedorInvitacion(SqlConnection Conexion,int IdRequisicionProveedorInvitacion)
	{
		string sp = "Proc_RequisicionesProveedoresInvitacionRestringida_x_IdRequisicionProveedorInvitacion";
				beRequisicionesProveedoresInvitacionRestringida obeRequisicionesProveedoresInvitacionRestringida=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdRequisicionProveedorInvitacion", SqlDbType.Int).Value = IdRequisicionProveedorInvitacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdRequisicionProveedorInvitacion = datard.GetOrdinal("IdRequisicionProveedorInvitacion");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
					 obeRequisicionesProveedoresInvitacionRestringida = new beRequisicionesProveedoresInvitacionRestringida();
				while (datard.Read())
					{
						obeRequisicionesProveedoresInvitacionRestringida.IdRequisicionProveedorInvitacion =  datard.GetInt32(posIdRequisicionProveedorInvitacion);
						obeRequisicionesProveedoresInvitacionRestringida.IdRequisicion =  datard.GetInt32(posIdRequisicion);
						obeRequisicionesProveedoresInvitacionRestringida.IdProveedor =  datard.GetInt32(posIdProveedor);
						obeRequisicionesProveedoresInvitacionRestringida.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeRequisicionesProveedoresInvitacionRestringida.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesProveedoresInvitacionRestringida;
			}
	}
	public List< beRequisicionesProveedoresInvitacionRestringida> listarTodos_RequisicionesProveedoresInvitacionRestringida(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesProveedoresInvitacionRestringida_Traer_Todos";
		List<beRequisicionesProveedoresInvitacionRestringida> lbeRequisicionesProveedoresInvitacionRestringida = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRequisicionProveedorInvitacion = datard.GetOrdinal("IdRequisicionProveedorInvitacion");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeRequisicionesProveedoresInvitacionRestringida = new List<beRequisicionesProveedoresInvitacionRestringida>();
				beRequisicionesProveedoresInvitacionRestringida obeRequisicionesProveedoresInvitacionRestringida;
				while (datard.Read())
				{
					 obeRequisicionesProveedoresInvitacionRestringida = new beRequisicionesProveedoresInvitacionRestringida();
					obeRequisicionesProveedoresInvitacionRestringida.IdRequisicionProveedorInvitacion =  datard.GetInt32(posIdRequisicionProveedorInvitacion);
					obeRequisicionesProveedoresInvitacionRestringida.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeRequisicionesProveedoresInvitacionRestringida.IdProveedor =  datard.GetInt32(posIdProveedor);
					obeRequisicionesProveedoresInvitacionRestringida.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRequisicionesProveedoresInvitacionRestringida.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					lbeRequisicionesProveedoresInvitacionRestringida.Add(obeRequisicionesProveedoresInvitacionRestringida);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesProveedoresInvitacionRestringida;
		}
	}
	public List< beRequisicionesProveedoresInvitacionRestringida> listar_RequisicionesProveedoresInvitacionRestringida_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesProveedoresInvitacionRestringida_TraerTodos_GetAll";
		List<beRequisicionesProveedoresInvitacionRestringida> lbeRequisicionesProveedoresInvitacionRestringida = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRequisicionProveedorInvitacion = datard.GetOrdinal("IdRequisicionProveedorInvitacion");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeRequisicionesProveedoresInvitacionRestringida = new List<beRequisicionesProveedoresInvitacionRestringida>();
				beRequisicionesProveedoresInvitacionRestringida obeRequisicionesProveedoresInvitacionRestringida;
				while (datard.Read())
				{
					 obeRequisicionesProveedoresInvitacionRestringida = new beRequisicionesProveedoresInvitacionRestringida();
					obeRequisicionesProveedoresInvitacionRestringida.IdRequisicionProveedorInvitacion =  datard.GetInt32(posIdRequisicionProveedorInvitacion);
					obeRequisicionesProveedoresInvitacionRestringida.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeRequisicionesProveedoresInvitacionRestringida.IdProveedor =  datard.GetInt32(posIdProveedor);
					obeRequisicionesProveedoresInvitacionRestringida.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRequisicionesProveedoresInvitacionRestringida.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			// debe agregar campos de la Vista
					lbeRequisicionesProveedoresInvitacionRestringida.Add(obeRequisicionesProveedoresInvitacionRestringida);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesProveedoresInvitacionRestringida;
		}
	}
}
}
