using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daProveedoresRequisicionesCartas
 {
	public int guardarProveedoresRequisicionesCartas(SqlConnection Conexion, beProveedoresRequisicionesCartas obeProveedoresRequisicionesCartas)
	{
		int Id=0;
		string sp = "Proc_ProveedoresRequisicionesCartasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorCarta", SqlDbType.Int).Value = obeProveedoresRequisicionesCartas.IdProveedorCarta;
				cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obeProveedoresRequisicionesCartas.IdProveedorRqInvitacion;
				cmd.Parameters.Add("@IdCarta", SqlDbType.Int).Value = obeProveedoresRequisicionesCartas.IdCarta;
				cmd.Parameters.Add("@AceptacionCarta", SqlDbType.Bit).Value = obeProveedoresRequisicionesCartas.AceptacionCarta;
				cmd.Parameters.Add("@FechaAceptacion", SqlDbType.DateTime).Value = obeProveedoresRequisicionesCartas.FechaAceptacion;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeProveedoresRequisicionesCartas.IdUsuarioRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarProveedoresRequisicionesCartas(SqlConnection Conexion, beProveedoresRequisicionesCartas obeProveedoresRequisicionesCartas)
	{
		string sp = "Proc_ProveedoresRequisicionesCartasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorCarta", SqlDbType.Int).Value = obeProveedoresRequisicionesCartas.IdProveedorCarta;
				cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obeProveedoresRequisicionesCartas.IdProveedorRqInvitacion;
				cmd.Parameters.Add("@IdCarta", SqlDbType.Int).Value = obeProveedoresRequisicionesCartas.IdCarta;
				cmd.Parameters.Add("@AceptacionCarta", SqlDbType.Bit).Value = obeProveedoresRequisicionesCartas.AceptacionCarta;
				cmd.Parameters.Add("@FechaAceptacion", SqlDbType.DateTime).Value = obeProveedoresRequisicionesCartas.FechaAceptacion;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeProveedoresRequisicionesCartas.IdUsuarioRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarProveedoresRequisicionesCartas(SqlConnection Conexion,int pIdProveedorCarta)
	{
		string sp = "Proc_ProveedoresRequisicionesCartasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorCarta", SqlDbType.Int).Value = pIdProveedorCarta;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beProveedoresRequisicionesCartas traerProveedoresRequisicionesCartas_x_IdProveedorCarta(SqlConnection Conexion,int IdProveedorCarta)
	{
		string sp = "Proc_ProveedoresRequisicionesCartas_x_IdProveedorCarta";
				beProveedoresRequisicionesCartas obeProveedoresRequisicionesCartas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdProveedorCarta", SqlDbType.Int).Value = IdProveedorCarta;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdProveedorCarta = datard.GetOrdinal("IdProveedorCarta");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posIdCarta = datard.GetOrdinal("IdCarta");
						int posAceptacionCarta = datard.GetOrdinal("AceptacionCarta");
						int posFechaAceptacion = datard.GetOrdinal("FechaAceptacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
					 obeProveedoresRequisicionesCartas = new beProveedoresRequisicionesCartas();
				while (datard.Read())
					{
						obeProveedoresRequisicionesCartas.IdProveedorCarta =  datard.GetInt32(posIdProveedorCarta);
						obeProveedoresRequisicionesCartas.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
						obeProveedoresRequisicionesCartas.IdCarta =  datard.GetInt32(posIdCarta);
						obeProveedoresRequisicionesCartas.AceptacionCarta =  datard.GetBoolean(posAceptacionCarta);
						obeProveedoresRequisicionesCartas.FechaAceptacion = datard[posFechaAceptacion]== DBNull.Value? DateTime.Now: datard.GetDateTime(posFechaAceptacion);
						obeProveedoresRequisicionesCartas.IdUsuarioRegistro = datard[posIdUsuarioRegistro] == DBNull.Value ? 0 :  datard.GetInt32(posIdUsuarioRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedoresRequisicionesCartas;
			}
	}
	public List< beProveedoresRequisicionesCartas> listarTodos_ProveedoresRequisicionesCartas(SqlConnection Conexion)
	 {
		string sp = "Proc_ProveedoresRequisicionesCartas_Traer_Todos";
		List<beProveedoresRequisicionesCartas> lbeProveedoresRequisicionesCartas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdProveedorCarta = datard.GetOrdinal("IdProveedorCarta");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posIdCarta = datard.GetOrdinal("IdCarta");
						int posAceptacionCarta = datard.GetOrdinal("AceptacionCarta");
						int posFechaAceptacion = datard.GetOrdinal("FechaAceptacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
				lbeProveedoresRequisicionesCartas = new List<beProveedoresRequisicionesCartas>();
				beProveedoresRequisicionesCartas obeProveedoresRequisicionesCartas;
				while (datard.Read())
				{
					 obeProveedoresRequisicionesCartas = new beProveedoresRequisicionesCartas();
					obeProveedoresRequisicionesCartas.IdProveedorCarta =  datard.GetInt32(posIdProveedorCarta);
					obeProveedoresRequisicionesCartas.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
					obeProveedoresRequisicionesCartas.IdCarta =  datard.GetInt32(posIdCarta);
					obeProveedoresRequisicionesCartas.AceptacionCarta =  datard.GetBoolean(posAceptacionCarta);
					obeProveedoresRequisicionesCartas.FechaAceptacion =  datard.GetDateTime(posFechaAceptacion);
					obeProveedoresRequisicionesCartas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					lbeProveedoresRequisicionesCartas.Add(obeProveedoresRequisicionesCartas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresRequisicionesCartas;
		}
	}
	public List< beProveedoresRequisicionesCartas> listar_ProveedoresRequisicionesCartas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_ProveedoresRequisicionesCartas_TraerTodos_GetAll";
		List<beProveedoresRequisicionesCartas> lbeProveedoresRequisicionesCartas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdProveedorCarta = datard.GetOrdinal("IdProveedorCarta");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posIdCarta = datard.GetOrdinal("IdCarta");
						int posAceptacionCarta = datard.GetOrdinal("AceptacionCarta");
						int posFechaAceptacion = datard.GetOrdinal("FechaAceptacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
				lbeProveedoresRequisicionesCartas = new List<beProveedoresRequisicionesCartas>();
				beProveedoresRequisicionesCartas obeProveedoresRequisicionesCartas;
				while (datard.Read())
				{
					 obeProveedoresRequisicionesCartas = new beProveedoresRequisicionesCartas();
					obeProveedoresRequisicionesCartas.IdProveedorCarta =  datard.GetInt32(posIdProveedorCarta);
					obeProveedoresRequisicionesCartas.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
					obeProveedoresRequisicionesCartas.IdCarta =  datard.GetInt32(posIdCarta);
					obeProveedoresRequisicionesCartas.AceptacionCarta =  datard.GetBoolean(posAceptacionCarta);
					obeProveedoresRequisicionesCartas.FechaAceptacion =  datard.GetDateTime(posFechaAceptacion);
					obeProveedoresRequisicionesCartas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
			// debe agregar campos de la Vista
					lbeProveedoresRequisicionesCartas.Add(obeProveedoresRequisicionesCartas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresRequisicionesCartas;
		}
	}
}
}
