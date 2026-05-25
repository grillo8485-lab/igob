using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daLicitacionesInvitacionProveedores
 {
	public int guardarLicitacionesInvitacionProveedores(SqlConnection Conexion, beLicitacionesInvitacionProveedores obeLicitacionesInvitacionProveedores)
	{
		int Id=0;
		string sp = "Proc_LicitacionesInvitacionProveedoresInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdInvitacion", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdInvitacion;
				cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdLicitacion;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdProveedor;
				cmd.Parameters.Add("@IdProveedorGiroComercial", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdProveedorGiroComercial;
				cmd.Parameters.Add("@Aceptacion", SqlDbType.Bit).Value = obeLicitacionesInvitacionProveedores.Aceptacion;
				cmd.Parameters.Add("@FechaAceptacion", SqlDbType.DateTime).Value = obeLicitacionesInvitacionProveedores.FechaAceptacion;
				cmd.Parameters.Add("@FolioPago", SqlDbType.VarChar).Value = obeLicitacionesInvitacionProveedores.FolioPago;
				cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = obeLicitacionesInvitacionProveedores.FechaPago;
				cmd.Parameters.Add("@UrlRecibo", SqlDbType.VarChar).Value = obeLicitacionesInvitacionProveedores.UrlRecibo;
				cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeLicitacionesInvitacionProveedores.Observaciones;
				cmd.Parameters.Add("@IdEstatusPago", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdEstatusPago;
				cmd.Parameters.Add("@FechaValidaPago", SqlDbType.DateTime).Value = obeLicitacionesInvitacionProveedores.FechaValidaPago;
				cmd.Parameters.Add("@TiempoValidaPago", SqlDbType.Time).Value = obeLicitacionesInvitacionProveedores.TiempoValidaPago;
				cmd.Parameters.Add("@IdTipoTiempoValidaPago", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdTipoTiempoValidaPago;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeLicitacionesInvitacionProveedores.FechaRegistro;
				cmd.Parameters.Add("@IdRazonRechazo", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdRazonRechazo;
				cmd.Parameters.Add("@Activo", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarLicitacionesInvitacionProveedores(SqlConnection Conexion, beLicitacionesInvitacionProveedores obeLicitacionesInvitacionProveedores)
	{
		string sp = "Proc_LicitacionesInvitacionProveedoresActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdInvitacion", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdInvitacion;
				cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdLicitacion;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdProveedor;
				cmd.Parameters.Add("@IdProveedorGiroComercial", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdProveedorGiroComercial;
				cmd.Parameters.Add("@Aceptacion", SqlDbType.Bit).Value = obeLicitacionesInvitacionProveedores.Aceptacion;
				cmd.Parameters.Add("@FechaAceptacion", SqlDbType.DateTime).Value = obeLicitacionesInvitacionProveedores.FechaAceptacion;
				cmd.Parameters.Add("@FolioPago", SqlDbType.VarChar).Value = obeLicitacionesInvitacionProveedores.FolioPago;
				cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = obeLicitacionesInvitacionProveedores.FechaPago;
				cmd.Parameters.Add("@UrlRecibo", SqlDbType.VarChar).Value = obeLicitacionesInvitacionProveedores.UrlRecibo;
				cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeLicitacionesInvitacionProveedores.Observaciones;
				cmd.Parameters.Add("@IdEstatusPago", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdEstatusPago;
				cmd.Parameters.Add("@FechaValidaPago", SqlDbType.DateTime).Value = obeLicitacionesInvitacionProveedores.FechaValidaPago;
				cmd.Parameters.Add("@TiempoValidaPago", SqlDbType.Time).Value = obeLicitacionesInvitacionProveedores.TiempoValidaPago;
				cmd.Parameters.Add("@IdTipoTiempoValidaPago", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdTipoTiempoValidaPago;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeLicitacionesInvitacionProveedores.FechaRegistro;
				cmd.Parameters.Add("@IdRazonRechazo", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.IdRazonRechazo;
				cmd.Parameters.Add("@Activo", SqlDbType.Int).Value = obeLicitacionesInvitacionProveedores.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarLicitacionesInvitacionProveedores(SqlConnection Conexion,int pIdInvitacion)
	{
		string sp = "Proc_LicitacionesInvitacionProveedoresEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdInvitacion", SqlDbType.Int).Value = pIdInvitacion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beLicitacionesInvitacionProveedores traerLicitacionesInvitacionProveedores_x_IdInvitacion(SqlConnection Conexion,int IdInvitacion)
	{
		string sp = "Proc_LicitacionesInvitacionProveedores_x_IdInvitacion";
				beLicitacionesInvitacionProveedores obeLicitacionesInvitacionProveedores=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdInvitacion", SqlDbType.Int).Value = IdInvitacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdInvitacion = datard.GetOrdinal("IdInvitacion");
						int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdProveedorGiroComercial = datard.GetOrdinal("IdProveedorGiroComercial");
						int posAceptacion = datard.GetOrdinal("Aceptacion");
						int posFechaAceptacion = datard.GetOrdinal("FechaAceptacion");
						int posFolioPago = datard.GetOrdinal("FolioPago");
						int posFechaPago = datard.GetOrdinal("FechaPago");
						int posUrlRecibo = datard.GetOrdinal("UrlRecibo");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdEstatusPago = datard.GetOrdinal("IdEstatusPago");
						int posFechaValidaPago = datard.GetOrdinal("FechaValidaPago");
						int posTiempoValidaPago = datard.GetOrdinal("TiempoValidaPago");
						int posIdTipoTiempoValidaPago = datard.GetOrdinal("IdTipoTiempoValidaPago");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdRazonRechazo = datard.GetOrdinal("IdRazonRechazo");
						int posActivo = datard.GetOrdinal("Activo");
					 obeLicitacionesInvitacionProveedores = new beLicitacionesInvitacionProveedores();
				while (datard.Read())
					{
						obeLicitacionesInvitacionProveedores.IdInvitacion =  datard.GetInt32(posIdInvitacion);
						obeLicitacionesInvitacionProveedores.IdLicitacion =  datard.GetInt32(posIdLicitacion);
						obeLicitacionesInvitacionProveedores.IdProveedor =  datard.GetInt32(posIdProveedor);
						obeLicitacionesInvitacionProveedores.IdProveedorGiroComercial =  datard.GetInt32(posIdProveedorGiroComercial);
                            obeLicitacionesInvitacionProveedores.Aceptacion = datard[posAceptacion] == DBNull.Value ? false: datard.GetBoolean(posAceptacion);
						obeLicitacionesInvitacionProveedores.FechaAceptacion = datard[posFechaAceptacion] == DBNull.Value ? DateTime.MinValue :datard.GetDateTime(posFechaAceptacion);
						obeLicitacionesInvitacionProveedores.FolioPago = datard[posFolioPago] == DBNull.Value ? string.Empty :  datard.GetString(posFolioPago);
						obeLicitacionesInvitacionProveedores.FechaPago = datard[posFechaPago] == DBNull.Value ? DateTime.MinValue : datard.GetDateTime(posFechaPago);
						obeLicitacionesInvitacionProveedores.UrlRecibo = datard[posUrlRecibo] == DBNull.Value ? string.Empty : datard.GetString(posUrlRecibo);
						obeLicitacionesInvitacionProveedores.Observaciones = datard[posObservaciones] == DBNull.Value ? string.Empty :  datard.GetString(posObservaciones);
						obeLicitacionesInvitacionProveedores.IdEstatusPago =  datard.GetInt32(posIdEstatusPago);
						obeLicitacionesInvitacionProveedores.FechaValidaPago = datard[posFechaValidaPago] == DBNull.Value ? DateTime.MinValue :  datard.GetDateTime(posFechaValidaPago);
						obeLicitacionesInvitacionProveedores.TiempoValidaPago =  datard.GetTimeSpan(posTiempoValidaPago);
						obeLicitacionesInvitacionProveedores.IdTipoTiempoValidaPago =  datard.GetInt32(posIdTipoTiempoValidaPago);
						obeLicitacionesInvitacionProveedores.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeLicitacionesInvitacionProveedores.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
						obeLicitacionesInvitacionProveedores.IdRazonRechazo = datard[posIdRazonRechazo] == DBNull.Value ? 0 : datard.GetInt32(posIdRazonRechazo);
						obeLicitacionesInvitacionProveedores.Activo =  datard.GetInt32(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeLicitacionesInvitacionProveedores;
			}
	}
	public List< beLicitacionesInvitacionProveedores> listarTodos_LicitacionesInvitacionProveedores(SqlConnection Conexion)
	 {
		string sp = "Proc_LicitacionesInvitacionProveedores_Traer_Todos";
		List<beLicitacionesInvitacionProveedores> lbeLicitacionesInvitacionProveedores = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdInvitacion = datard.GetOrdinal("IdInvitacion");
						int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdProveedorGiroComercial = datard.GetOrdinal("IdProveedorGiroComercial");
						int posAceptacion = datard.GetOrdinal("Aceptacion");
						int posFechaAceptacion = datard.GetOrdinal("FechaAceptacion");
						int posFolioPago = datard.GetOrdinal("FolioPago");
						int posFechaPago = datard.GetOrdinal("FechaPago");
						int posUrlRecibo = datard.GetOrdinal("UrlRecibo");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdEstatusPago = datard.GetOrdinal("IdEstatusPago");
						int posFechaValidaPago = datard.GetOrdinal("FechaValidaPago");
						int posTiempoValidaPago = datard.GetOrdinal("TiempoValidaPago");
						int posIdTipoTiempoValidaPago = datard.GetOrdinal("IdTipoTiempoValidaPago");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdRazonRechazo = datard.GetOrdinal("IdRazonRechazo");
						int posActivo = datard.GetOrdinal("Activo");
				lbeLicitacionesInvitacionProveedores = new List<beLicitacionesInvitacionProveedores>();
				beLicitacionesInvitacionProveedores obeLicitacionesInvitacionProveedores;
				while (datard.Read())
				{
					 obeLicitacionesInvitacionProveedores = new beLicitacionesInvitacionProveedores();
					obeLicitacionesInvitacionProveedores.IdInvitacion =  datard.GetInt32(posIdInvitacion);
					obeLicitacionesInvitacionProveedores.IdLicitacion =  datard.GetInt32(posIdLicitacion);
					obeLicitacionesInvitacionProveedores.IdProveedor =  datard.GetInt32(posIdProveedor);
					obeLicitacionesInvitacionProveedores.IdProveedorGiroComercial =  datard.GetInt32(posIdProveedorGiroComercial);
					obeLicitacionesInvitacionProveedores.Aceptacion =  datard.GetBoolean(posAceptacion);
					obeLicitacionesInvitacionProveedores.FechaAceptacion =  datard.GetDateTime(posFechaAceptacion);
					obeLicitacionesInvitacionProveedores.FolioPago =  datard.GetString(posFolioPago);
					obeLicitacionesInvitacionProveedores.FechaPago =  datard.GetDateTime(posFechaPago);
					obeLicitacionesInvitacionProveedores.UrlRecibo =  datard.GetString(posUrlRecibo);
					obeLicitacionesInvitacionProveedores.Observaciones =  datard.GetString(posObservaciones);
					obeLicitacionesInvitacionProveedores.IdEstatusPago =  datard.GetInt32(posIdEstatusPago);
					obeLicitacionesInvitacionProveedores.FechaValidaPago =  datard.GetDateTime(posFechaValidaPago);
					obeLicitacionesInvitacionProveedores.TiempoValidaPago =  datard.GetTimeSpan(posTiempoValidaPago);
					obeLicitacionesInvitacionProveedores.IdTipoTiempoValidaPago =  datard.GetInt32(posIdTipoTiempoValidaPago);
					obeLicitacionesInvitacionProveedores.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeLicitacionesInvitacionProveedores.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeLicitacionesInvitacionProveedores.IdRazonRechazo =  datard.GetInt32(posIdRazonRechazo);
					obeLicitacionesInvitacionProveedores.Activo =  datard.GetInt32(posActivo);
					lbeLicitacionesInvitacionProveedores.Add(obeLicitacionesInvitacionProveedores);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeLicitacionesInvitacionProveedores;
		}
	}
	public List< beLicitacionesInvitacionProveedores> listar_LicitacionesInvitacionProveedores_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_LicitacionesInvitacionProveedores_TraerTodos_GetAll";
		List<beLicitacionesInvitacionProveedores> lbeLicitacionesInvitacionProveedores = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdInvitacion = datard.GetOrdinal("IdInvitacion");
						int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdProveedorGiroComercial = datard.GetOrdinal("IdProveedorGiroComercial");
						int posAceptacion = datard.GetOrdinal("Aceptacion");
						int posFechaAceptacion = datard.GetOrdinal("FechaAceptacion");
						int posFolioPago = datard.GetOrdinal("FolioPago");
						int posFechaPago = datard.GetOrdinal("FechaPago");
						int posUrlRecibo = datard.GetOrdinal("UrlRecibo");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdEstatusPago = datard.GetOrdinal("IdEstatusPago");
						int posFechaValidaPago = datard.GetOrdinal("FechaValidaPago");
						int posTiempoValidaPago = datard.GetOrdinal("TiempoValidaPago");
						int posIdTipoTiempoValidaPago = datard.GetOrdinal("IdTipoTiempoValidaPago");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdRazonRechazo = datard.GetOrdinal("IdRazonRechazo");
						int posActivo = datard.GetOrdinal("Activo");
				lbeLicitacionesInvitacionProveedores = new List<beLicitacionesInvitacionProveedores>();
				beLicitacionesInvitacionProveedores obeLicitacionesInvitacionProveedores;
				while (datard.Read())
				{
					 obeLicitacionesInvitacionProveedores = new beLicitacionesInvitacionProveedores();
					obeLicitacionesInvitacionProveedores.IdInvitacion =  datard.GetInt32(posIdInvitacion);
					obeLicitacionesInvitacionProveedores.IdLicitacion =  datard.GetInt32(posIdLicitacion);
					obeLicitacionesInvitacionProveedores.IdProveedor =  datard.GetInt32(posIdProveedor);
					obeLicitacionesInvitacionProveedores.IdProveedorGiroComercial =  datard.GetInt32(posIdProveedorGiroComercial);
					obeLicitacionesInvitacionProveedores.Aceptacion =  datard.GetBoolean(posAceptacion);
					obeLicitacionesInvitacionProveedores.FechaAceptacion =  datard.GetDateTime(posFechaAceptacion);
					obeLicitacionesInvitacionProveedores.FolioPago =  datard.GetString(posFolioPago);
					obeLicitacionesInvitacionProveedores.FechaPago =  datard.GetDateTime(posFechaPago);
					obeLicitacionesInvitacionProveedores.UrlRecibo =  datard.GetString(posUrlRecibo);
					obeLicitacionesInvitacionProveedores.Observaciones =  datard.GetString(posObservaciones);
					obeLicitacionesInvitacionProveedores.IdEstatusPago =  datard.GetInt32(posIdEstatusPago);
					obeLicitacionesInvitacionProveedores.FechaValidaPago =  datard.GetDateTime(posFechaValidaPago);
					obeLicitacionesInvitacionProveedores.TiempoValidaPago =  datard.GetTimeSpan(posTiempoValidaPago);
					obeLicitacionesInvitacionProveedores.IdTipoTiempoValidaPago =  datard.GetInt32(posIdTipoTiempoValidaPago);
					obeLicitacionesInvitacionProveedores.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeLicitacionesInvitacionProveedores.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeLicitacionesInvitacionProveedores.IdRazonRechazo =  datard.GetInt32(posIdRazonRechazo);
					obeLicitacionesInvitacionProveedores.Activo =  datard.GetInt32(posActivo);
			// debe agregar campos de la Vista
					lbeLicitacionesInvitacionProveedores.Add(obeLicitacionesInvitacionProveedores);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeLicitacionesInvitacionProveedores;
		}
	}
}
}
