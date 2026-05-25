using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daProveedoresRequisicionesInvitacion
 {
	public int guardarProveedoresRequisicionesInvitacion(SqlConnection Conexion, beProveedoresRequisicionesInvitacion obeProveedoresRequisicionesInvitacion)
	{
		int Id=0;
		string sp = "Proc_ProveedoresRequisicionesInvitacionInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdProveedorRqInvitacion;
				cmd.Parameters.Add("@IdInvitacion", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdInvitacion;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdRequisicion;
				cmd.Parameters.Add("@IdEstatusEnvioPropuestaTecnica", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica;
				cmd.Parameters.Add("@IdUsuaroEnviaPropuestaTecnica", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdUsuaroEnviaPropuestaTecnica;
				cmd.Parameters.Add("@FechaEnvioPropuestaTecnica", SqlDbType.DateTime).Value = obeProveedoresRequisicionesInvitacion.FechaEnvioPropuestaTecnica;
				cmd.Parameters.Add("@IdEstatusEnvioPropuestaEconomica", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaEconomica;
				cmd.Parameters.Add("@IdUsuaroEnviaPropuestaEconomica", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdUsuaroEnviaPropuestaEconomica;
				cmd.Parameters.Add("@FechaEnvioPropuestaEconomica", SqlDbType.DateTime).Value = obeProveedoresRequisicionesInvitacion.FechaEnvioPropuestaEconomica;
				cmd.Parameters.Add("@CartasDependenciaCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CartasDependenciaCumple;
				cmd.Parameters.Add("@CartaFundamento", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CartaFundamento;
				cmd.Parameters.Add("@CartaAdquisicionCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CartaAdquisicionCumple;
				cmd.Parameters.Add("@CartasAdqObservacion", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CartasAdqObservacion;
				cmd.Parameters.Add("@CondicionEntregaDependenciaCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CondicionEntregaDependenciaCumple;
				cmd.Parameters.Add("@CondicionEntregaFundamento", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CondicionEntregaFundamento;
				cmd.Parameters.Add("@CondicionEntregaAdquisicionCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CondicionEntregaAdquisicionCumple;
				cmd.Parameters.Add("@CondicionEntregaAdqObservacion", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CondicionEntregaAdqObservacion;
				cmd.Parameters.Add("@CondicionPagoDependenciaCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CondicionPagoDependenciaCumple;
				cmd.Parameters.Add("@CondicionPagoFundamento", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CondicionPagoFundamento;
				cmd.Parameters.Add("@CondicionPagoAdquisicionCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CondicionPagoAdquisicionCumple;
				cmd.Parameters.Add("@CondicionPagoAdqObservacion", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CondicionPagoAdqObservacion;
				cmd.Parameters.Add("@ManifiestoDependenciaCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.ManifiestoDependenciaCumple;
				cmd.Parameters.Add("@ManifiestoFundamento", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.ManifiestoFundamento;
				cmd.Parameters.Add("@ManifiestoAdquisicionCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.ManifiestoAdquisicionCumple;
				cmd.Parameters.Add("@ManifiestoAdqObservacion", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.ManifiestoAdqObservacion;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeProveedoresRequisicionesInvitacion.FechaRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarProveedoresRequisicionesInvitacion(SqlConnection Conexion, beProveedoresRequisicionesInvitacion obeProveedoresRequisicionesInvitacion)
	{
		string sp = "Proc_ProveedoresRequisicionesInvitacionActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdProveedorRqInvitacion;
				cmd.Parameters.Add("@IdInvitacion", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdInvitacion;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdRequisicion;
				cmd.Parameters.Add("@IdEstatusEnvioPropuestaTecnica", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica;
				cmd.Parameters.Add("@IdUsuaroEnviaPropuestaTecnica", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdUsuaroEnviaPropuestaTecnica;
				cmd.Parameters.Add("@FechaEnvioPropuestaTecnica", SqlDbType.DateTime).Value = obeProveedoresRequisicionesInvitacion.FechaEnvioPropuestaTecnica;
				cmd.Parameters.Add("@IdEstatusEnvioPropuestaEconomica", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaEconomica;
				cmd.Parameters.Add("@IdUsuaroEnviaPropuestaEconomica", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdUsuaroEnviaPropuestaEconomica;
				cmd.Parameters.Add("@FechaEnvioPropuestaEconomica", SqlDbType.DateTime).Value = obeProveedoresRequisicionesInvitacion.FechaEnvioPropuestaEconomica;
				cmd.Parameters.Add("@CartasDependenciaCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CartasDependenciaCumple;
				cmd.Parameters.Add("@CartaFundamento", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CartaFundamento;
				cmd.Parameters.Add("@CartaAdquisicionCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CartaAdquisicionCumple;
				cmd.Parameters.Add("@CartasAdqObservacion", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CartasAdqObservacion;
				cmd.Parameters.Add("@CondicionEntregaDependenciaCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CondicionEntregaDependenciaCumple;
				cmd.Parameters.Add("@CondicionEntregaFundamento", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CondicionEntregaFundamento;
				cmd.Parameters.Add("@CondicionEntregaAdquisicionCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CondicionEntregaAdquisicionCumple;
				cmd.Parameters.Add("@CondicionEntregaAdqObservacion", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CondicionEntregaAdqObservacion;
				cmd.Parameters.Add("@CondicionPagoDependenciaCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CondicionPagoDependenciaCumple;
				cmd.Parameters.Add("@CondicionPagoFundamento", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CondicionPagoFundamento;
				cmd.Parameters.Add("@CondicionPagoAdquisicionCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.CondicionPagoAdquisicionCumple;
				cmd.Parameters.Add("@CondicionPagoAdqObservacion", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.CondicionPagoAdqObservacion;
				cmd.Parameters.Add("@ManifiestoDependenciaCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.ManifiestoDependenciaCumple;
				cmd.Parameters.Add("@ManifiestoFundamento", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.ManifiestoFundamento;
				cmd.Parameters.Add("@ManifiestoAdquisicionCumple", SqlDbType.Bit).Value = obeProveedoresRequisicionesInvitacion.ManifiestoAdquisicionCumple;
				cmd.Parameters.Add("@ManifiestoAdqObservacion", SqlDbType.Text).Value = obeProveedoresRequisicionesInvitacion.ManifiestoAdqObservacion;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeProveedoresRequisicionesInvitacion.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeProveedoresRequisicionesInvitacion.FechaRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarProveedoresRequisicionesInvitacion(SqlConnection Conexion,int pIdProveedorRqInvitacion)
	{
		string sp = "Proc_ProveedoresRequisicionesInvitacionEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = pIdProveedorRqInvitacion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beProveedoresRequisicionesInvitacion traerProveedoresRequisicionesInvitacion_x_IdProveedorRqInvitacion(SqlConnection Conexion,int IdProveedorRqInvitacion)
	{
		string sp = "Proc_ProveedoresRequisicionesInvitacion_x_IdProveedorRqInvitacion";
				beProveedoresRequisicionesInvitacion obeProveedoresRequisicionesInvitacion=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = IdProveedorRqInvitacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posIdInvitacion = datard.GetOrdinal("IdInvitacion");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
						int posIdUsuaroEnviaPropuestaTecnica = datard.GetOrdinal("IdUsuaroEnviaPropuestaTecnica");
						int posFechaEnvioPropuestaTecnica = datard.GetOrdinal("FechaEnvioPropuestaTecnica");
						int posIdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
						int posIdUsuaroEnviaPropuestaEconomica = datard.GetOrdinal("IdUsuaroEnviaPropuestaEconomica");
						int posFechaEnvioPropuestaEconomica = datard.GetOrdinal("FechaEnvioPropuestaEconomica");
						int posCartasDependenciaCumple = datard.GetOrdinal("CartasDependenciaCumple");
						int posCartaFundamento = datard.GetOrdinal("CartaFundamento");
						int posCartaAdquisicionCumple = datard.GetOrdinal("CartaAdquisicionCumple");
						int posCartasAdqObservacion = datard.GetOrdinal("CartasAdqObservacion");
						int posCondicionEntregaDependenciaCumple = datard.GetOrdinal("CondicionEntregaDependenciaCumple");
						int posCondicionEntregaFundamento = datard.GetOrdinal("CondicionEntregaFundamento");
						int posCondicionEntregaAdquisicionCumple = datard.GetOrdinal("CondicionEntregaAdquisicionCumple");
						int posCondicionEntregaAdqObservacion = datard.GetOrdinal("CondicionEntregaAdqObservacion");
						int posCondicionPagoDependenciaCumple = datard.GetOrdinal("CondicionPagoDependenciaCumple");
						int posCondicionPagoFundamento = datard.GetOrdinal("CondicionPagoFundamento");
						int posCondicionPagoAdquisicionCumple = datard.GetOrdinal("CondicionPagoAdquisicionCumple");
						int posCondicionPagoAdqObservacion = datard.GetOrdinal("CondicionPagoAdqObservacion");
						int posManifiestoDependenciaCumple = datard.GetOrdinal("ManifiestoDependenciaCumple");
						int posManifiestoFundamento = datard.GetOrdinal("ManifiestoFundamento");
						int posManifiestoAdquisicionCumple = datard.GetOrdinal("ManifiestoAdquisicionCumple");
						int posManifiestoAdqObservacion = datard.GetOrdinal("ManifiestoAdqObservacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
					 obeProveedoresRequisicionesInvitacion = new beProveedoresRequisicionesInvitacion();
				while (datard.Read())
					{
						obeProveedoresRequisicionesInvitacion.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
						obeProveedoresRequisicionesInvitacion.IdInvitacion = datard[posIdInvitacion] ==DBNull.Value?0:  datard.GetInt32(posIdInvitacion);
						obeProveedoresRequisicionesInvitacion.IdRequisicion = datard[posIdRequisicion] == DBNull.Value ? 0 : datard.GetInt32(posIdRequisicion);
						obeProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica = datard[posIdEstatusEnvioPropuestaTecnica] == DBNull.Value ? 0 : datard.GetInt32(posIdEstatusEnvioPropuestaTecnica);
						obeProveedoresRequisicionesInvitacion.IdUsuaroEnviaPropuestaTecnica = datard[posIdUsuaroEnviaPropuestaTecnica] == DBNull.Value ? 0 : datard.GetInt32(posIdUsuaroEnviaPropuestaTecnica);
						obeProveedoresRequisicionesInvitacion.FechaEnvioPropuestaTecnica = datard[posFechaEnvioPropuestaTecnica] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaEnvioPropuestaTecnica);
						obeProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaEconomica =  datard.GetInt32(posIdEstatusEnvioPropuestaEconomica);
						obeProveedoresRequisicionesInvitacion.IdUsuaroEnviaPropuestaEconomica = datard[posIdUsuaroEnviaPropuestaEconomica] == DBNull.Value ? 0: datard.GetInt32(posIdUsuaroEnviaPropuestaEconomica);
						obeProveedoresRequisicionesInvitacion.FechaEnvioPropuestaEconomica = datard[posFechaEnvioPropuestaEconomica] == DBNull.Value ? DateTime.Now :  datard.GetDateTime(posFechaEnvioPropuestaEconomica);
						obeProveedoresRequisicionesInvitacion.CartasDependenciaCumple = datard[posCartasDependenciaCumple] == DBNull.Value ? false : datard.GetBoolean(posCartasDependenciaCumple);
						obeProveedoresRequisicionesInvitacion.CartaFundamento = datard[posCartaFundamento] == DBNull.Value ? "" : datard.GetString(posCartaFundamento);
						obeProveedoresRequisicionesInvitacion.CartaAdquisicionCumple = datard[posCartaAdquisicionCumple] == DBNull.Value ? false : datard.GetBoolean(posCartaAdquisicionCumple);
						obeProveedoresRequisicionesInvitacion.CartasAdqObservacion = datard[posCartasAdqObservacion] == DBNull.Value ? "" : datard.GetString(posCartasAdqObservacion);
						obeProveedoresRequisicionesInvitacion.CondicionEntregaDependenciaCumple = datard[posCondicionEntregaDependenciaCumple] == DBNull.Value ? false : datard.GetBoolean(posCondicionEntregaDependenciaCumple);
						obeProveedoresRequisicionesInvitacion.CondicionEntregaFundamento = datard[posCondicionEntregaFundamento] == DBNull.Value ? "" : datard.GetString(posCondicionEntregaFundamento);
						obeProveedoresRequisicionesInvitacion.CondicionEntregaAdquisicionCumple = datard[posCondicionEntregaAdquisicionCumple] == DBNull.Value ? false : datard.GetBoolean(posCondicionEntregaAdquisicionCumple);
						obeProveedoresRequisicionesInvitacion.CondicionEntregaAdqObservacion = datard[posCondicionEntregaAdqObservacion] == DBNull.Value ? "" : datard.GetString(posCondicionEntregaAdqObservacion);
						obeProveedoresRequisicionesInvitacion.CondicionPagoDependenciaCumple = datard[posCondicionPagoDependenciaCumple] == DBNull.Value ? false : datard.GetBoolean(posCondicionPagoDependenciaCumple);
						obeProveedoresRequisicionesInvitacion.CondicionPagoFundamento = datard[posCondicionPagoFundamento] == DBNull.Value ? "" : datard.GetString(posCondicionPagoFundamento);
						obeProveedoresRequisicionesInvitacion.CondicionPagoAdquisicionCumple = datard[posCondicionPagoAdquisicionCumple] == DBNull.Value ? false : datard.GetBoolean(posCondicionPagoAdquisicionCumple);
						obeProveedoresRequisicionesInvitacion.CondicionPagoAdqObservacion = datard[posCondicionPagoAdqObservacion] == DBNull.Value ? "" : datard.GetString(posCondicionPagoAdqObservacion);
						obeProveedoresRequisicionesInvitacion.ManifiestoDependenciaCumple = datard[posManifiestoDependenciaCumple] == DBNull.Value ? false : datard.GetBoolean(posManifiestoDependenciaCumple);
						obeProveedoresRequisicionesInvitacion.ManifiestoFundamento = datard[posManifiestoFundamento] == DBNull.Value ? "" : datard.GetString(posManifiestoFundamento);
						obeProveedoresRequisicionesInvitacion.ManifiestoAdquisicionCumple = datard[posManifiestoAdquisicionCumple] == DBNull.Value ? false : datard.GetBoolean(posManifiestoAdquisicionCumple);
						obeProveedoresRequisicionesInvitacion.ManifiestoAdqObservacion = datard[posManifiestoAdqObservacion] == DBNull.Value ? "" : datard.GetString(posManifiestoAdqObservacion);
						obeProveedoresRequisicionesInvitacion.IdUsuarioRegistro = datard[posIdUsuarioRegistro] == DBNull.Value ? 0 : datard.GetInt32(posIdUsuarioRegistro);
						obeProveedoresRequisicionesInvitacion.FechaRegistro = datard[posFechaRegistro] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedoresRequisicionesInvitacion;
			}
	}
	public List< beProveedoresRequisicionesInvitacion> listarTodos_ProveedoresRequisicionesInvitacion(SqlConnection Conexion)
	 {
		string sp = "Proc_ProveedoresRequisicionesInvitacion_Traer_Todos";
		List<beProveedoresRequisicionesInvitacion> lbeProveedoresRequisicionesInvitacion = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posIdInvitacion = datard.GetOrdinal("IdInvitacion");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
						int posIdUsuaroEnviaPropuestaTecnica = datard.GetOrdinal("IdUsuaroEnviaPropuestaTecnica");
						int posFechaEnvioPropuestaTecnica = datard.GetOrdinal("FechaEnvioPropuestaTecnica");
						int posIdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
						int posIdUsuaroEnviaPropuestaEconomica = datard.GetOrdinal("IdUsuaroEnviaPropuestaEconomica");
						int posFechaEnvioPropuestaEconomica = datard.GetOrdinal("FechaEnvioPropuestaEconomica");
						int posCartasDependenciaCumple = datard.GetOrdinal("CartasDependenciaCumple");
						int posCartaFundamento = datard.GetOrdinal("CartaFundamento");
						int posCartaAdquisicionCumple = datard.GetOrdinal("CartaAdquisicionCumple");
						int posCartasAdqObservacion = datard.GetOrdinal("CartasAdqObservacion");
						int posCondicionEntregaDependenciaCumple = datard.GetOrdinal("CondicionEntregaDependenciaCumple");
						int posCondicionEntregaFundamento = datard.GetOrdinal("CondicionEntregaFundamento");
						int posCondicionEntregaAdquisicionCumple = datard.GetOrdinal("CondicionEntregaAdquisicionCumple");
						int posCondicionEntregaAdqObservacion = datard.GetOrdinal("CondicionEntregaAdqObservacion");
						int posCondicionPagoDependenciaCumple = datard.GetOrdinal("CondicionPagoDependenciaCumple");
						int posCondicionPagoFundamento = datard.GetOrdinal("CondicionPagoFundamento");
						int posCondicionPagoAdquisicionCumple = datard.GetOrdinal("CondicionPagoAdquisicionCumple");
						int posCondicionPagoAdqObservacion = datard.GetOrdinal("CondicionPagoAdqObservacion");
						int posManifiestoDependenciaCumple = datard.GetOrdinal("ManifiestoDependenciaCumple");
						int posManifiestoFundamento = datard.GetOrdinal("ManifiestoFundamento");
						int posManifiestoAdquisicionCumple = datard.GetOrdinal("ManifiestoAdquisicionCumple");
						int posManifiestoAdqObservacion = datard.GetOrdinal("ManifiestoAdqObservacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeProveedoresRequisicionesInvitacion = new List<beProveedoresRequisicionesInvitacion>();
				beProveedoresRequisicionesInvitacion obeProveedoresRequisicionesInvitacion;
				while (datard.Read())
				{
					 obeProveedoresRequisicionesInvitacion = new beProveedoresRequisicionesInvitacion();
					obeProveedoresRequisicionesInvitacion.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
					obeProveedoresRequisicionesInvitacion.IdInvitacion =  datard.GetInt32(posIdInvitacion);
					obeProveedoresRequisicionesInvitacion.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica =  datard.GetInt32(posIdEstatusEnvioPropuestaTecnica);
					obeProveedoresRequisicionesInvitacion.IdUsuaroEnviaPropuestaTecnica =  datard.GetInt32(posIdUsuaroEnviaPropuestaTecnica);
					obeProveedoresRequisicionesInvitacion.FechaEnvioPropuestaTecnica =  datard.GetDateTime(posFechaEnvioPropuestaTecnica);
					obeProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaEconomica =  datard.GetInt32(posIdEstatusEnvioPropuestaEconomica);
					obeProveedoresRequisicionesInvitacion.IdUsuaroEnviaPropuestaEconomica =  datard.GetInt32(posIdUsuaroEnviaPropuestaEconomica);
					obeProveedoresRequisicionesInvitacion.FechaEnvioPropuestaEconomica =  datard.GetDateTime(posFechaEnvioPropuestaEconomica);
					obeProveedoresRequisicionesInvitacion.CartasDependenciaCumple =  datard.GetBoolean(posCartasDependenciaCumple);
					obeProveedoresRequisicionesInvitacion.CartaFundamento =  datard.GetString(posCartaFundamento);
					obeProveedoresRequisicionesInvitacion.CartaAdquisicionCumple =  datard.GetBoolean(posCartaAdquisicionCumple);
					obeProveedoresRequisicionesInvitacion.CartasAdqObservacion =  datard.GetString(posCartasAdqObservacion);
					obeProveedoresRequisicionesInvitacion.CondicionEntregaDependenciaCumple =  datard.GetBoolean(posCondicionEntregaDependenciaCumple);
					obeProveedoresRequisicionesInvitacion.CondicionEntregaFundamento =  datard.GetString(posCondicionEntregaFundamento);
					obeProveedoresRequisicionesInvitacion.CondicionEntregaAdquisicionCumple =  datard.GetBoolean(posCondicionEntregaAdquisicionCumple);
					obeProveedoresRequisicionesInvitacion.CondicionEntregaAdqObservacion =  datard.GetString(posCondicionEntregaAdqObservacion);
					obeProveedoresRequisicionesInvitacion.CondicionPagoDependenciaCumple =  datard.GetBoolean(posCondicionPagoDependenciaCumple);
					obeProveedoresRequisicionesInvitacion.CondicionPagoFundamento =  datard.GetString(posCondicionPagoFundamento);
					obeProveedoresRequisicionesInvitacion.CondicionPagoAdquisicionCumple =  datard.GetBoolean(posCondicionPagoAdquisicionCumple);
					obeProveedoresRequisicionesInvitacion.CondicionPagoAdqObservacion =  datard.GetString(posCondicionPagoAdqObservacion);
					obeProveedoresRequisicionesInvitacion.ManifiestoDependenciaCumple =  datard.GetBoolean(posManifiestoDependenciaCumple);
					obeProveedoresRequisicionesInvitacion.ManifiestoFundamento =  datard.GetString(posManifiestoFundamento);
					obeProveedoresRequisicionesInvitacion.ManifiestoAdquisicionCumple =  datard.GetBoolean(posManifiestoAdquisicionCumple);
					obeProveedoresRequisicionesInvitacion.ManifiestoAdqObservacion =  datard.GetString(posManifiestoAdqObservacion);
					obeProveedoresRequisicionesInvitacion.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeProveedoresRequisicionesInvitacion.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					lbeProveedoresRequisicionesInvitacion.Add(obeProveedoresRequisicionesInvitacion);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresRequisicionesInvitacion;
		}
	}
	public List< beProveedoresRequisicionesInvitacion> listar_ProveedoresRequisicionesInvitacion_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_ProveedoresRequisicionesInvitacion_TraerTodos_GetAll";
		List<beProveedoresRequisicionesInvitacion> lbeProveedoresRequisicionesInvitacion = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posIdInvitacion = datard.GetOrdinal("IdInvitacion");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
						int posIdUsuaroEnviaPropuestaTecnica = datard.GetOrdinal("IdUsuaroEnviaPropuestaTecnica");
						int posFechaEnvioPropuestaTecnica = datard.GetOrdinal("FechaEnvioPropuestaTecnica");
						int posIdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
						int posIdUsuaroEnviaPropuestaEconomica = datard.GetOrdinal("IdUsuaroEnviaPropuestaEconomica");
						int posFechaEnvioPropuestaEconomica = datard.GetOrdinal("FechaEnvioPropuestaEconomica");
						int posCartasDependenciaCumple = datard.GetOrdinal("CartasDependenciaCumple");
						int posCartaFundamento = datard.GetOrdinal("CartaFundamento");
						int posCartaAdquisicionCumple = datard.GetOrdinal("CartaAdquisicionCumple");
						int posCartasAdqObservacion = datard.GetOrdinal("CartasAdqObservacion");
						int posCondicionEntregaDependenciaCumple = datard.GetOrdinal("CondicionEntregaDependenciaCumple");
						int posCondicionEntregaFundamento = datard.GetOrdinal("CondicionEntregaFundamento");
						int posCondicionEntregaAdquisicionCumple = datard.GetOrdinal("CondicionEntregaAdquisicionCumple");
						int posCondicionEntregaAdqObservacion = datard.GetOrdinal("CondicionEntregaAdqObservacion");
						int posCondicionPagoDependenciaCumple = datard.GetOrdinal("CondicionPagoDependenciaCumple");
						int posCondicionPagoFundamento = datard.GetOrdinal("CondicionPagoFundamento");
						int posCondicionPagoAdquisicionCumple = datard.GetOrdinal("CondicionPagoAdquisicionCumple");
						int posCondicionPagoAdqObservacion = datard.GetOrdinal("CondicionPagoAdqObservacion");
						int posManifiestoDependenciaCumple = datard.GetOrdinal("ManifiestoDependenciaCumple");
						int posManifiestoFundamento = datard.GetOrdinal("ManifiestoFundamento");
						int posManifiestoAdquisicionCumple = datard.GetOrdinal("ManifiestoAdquisicionCumple");
						int posManifiestoAdqObservacion = datard.GetOrdinal("ManifiestoAdqObservacion");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeProveedoresRequisicionesInvitacion = new List<beProveedoresRequisicionesInvitacion>();
				beProveedoresRequisicionesInvitacion obeProveedoresRequisicionesInvitacion;
				while (datard.Read())
				{
					 obeProveedoresRequisicionesInvitacion = new beProveedoresRequisicionesInvitacion();
					obeProveedoresRequisicionesInvitacion.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
					obeProveedoresRequisicionesInvitacion.IdInvitacion =  datard.GetInt32(posIdInvitacion);
					obeProveedoresRequisicionesInvitacion.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica =  datard.GetInt32(posIdEstatusEnvioPropuestaTecnica);
					obeProveedoresRequisicionesInvitacion.IdUsuaroEnviaPropuestaTecnica =  datard.GetInt32(posIdUsuaroEnviaPropuestaTecnica);
					obeProveedoresRequisicionesInvitacion.FechaEnvioPropuestaTecnica =  datard.GetDateTime(posFechaEnvioPropuestaTecnica);
					obeProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaEconomica =  datard.GetInt32(posIdEstatusEnvioPropuestaEconomica);
					obeProveedoresRequisicionesInvitacion.IdUsuaroEnviaPropuestaEconomica =  datard.GetInt32(posIdUsuaroEnviaPropuestaEconomica);
					obeProveedoresRequisicionesInvitacion.FechaEnvioPropuestaEconomica =  datard.GetDateTime(posFechaEnvioPropuestaEconomica);
					obeProveedoresRequisicionesInvitacion.CartasDependenciaCumple =  datard.GetBoolean(posCartasDependenciaCumple);
					obeProveedoresRequisicionesInvitacion.CartaFundamento =  datard.GetString(posCartaFundamento);
					obeProveedoresRequisicionesInvitacion.CartaAdquisicionCumple =  datard.GetBoolean(posCartaAdquisicionCumple);
					obeProveedoresRequisicionesInvitacion.CartasAdqObservacion =  datard.GetString(posCartasAdqObservacion);
					obeProveedoresRequisicionesInvitacion.CondicionEntregaDependenciaCumple =  datard.GetBoolean(posCondicionEntregaDependenciaCumple);
					obeProveedoresRequisicionesInvitacion.CondicionEntregaFundamento =  datard.GetString(posCondicionEntregaFundamento);
					obeProveedoresRequisicionesInvitacion.CondicionEntregaAdquisicionCumple =  datard.GetBoolean(posCondicionEntregaAdquisicionCumple);
					obeProveedoresRequisicionesInvitacion.CondicionEntregaAdqObservacion =  datard.GetString(posCondicionEntregaAdqObservacion);
					obeProveedoresRequisicionesInvitacion.CondicionPagoDependenciaCumple =  datard.GetBoolean(posCondicionPagoDependenciaCumple);
					obeProveedoresRequisicionesInvitacion.CondicionPagoFundamento =  datard.GetString(posCondicionPagoFundamento);
					obeProveedoresRequisicionesInvitacion.CondicionPagoAdquisicionCumple =  datard.GetBoolean(posCondicionPagoAdquisicionCumple);
					obeProveedoresRequisicionesInvitacion.CondicionPagoAdqObservacion =  datard.GetString(posCondicionPagoAdqObservacion);
					obeProveedoresRequisicionesInvitacion.ManifiestoDependenciaCumple =  datard.GetBoolean(posManifiestoDependenciaCumple);
					obeProveedoresRequisicionesInvitacion.ManifiestoFundamento =  datard.GetString(posManifiestoFundamento);
					obeProveedoresRequisicionesInvitacion.ManifiestoAdquisicionCumple =  datard.GetBoolean(posManifiestoAdquisicionCumple);
					obeProveedoresRequisicionesInvitacion.ManifiestoAdqObservacion =  datard.GetString(posManifiestoAdqObservacion);
					obeProveedoresRequisicionesInvitacion.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeProveedoresRequisicionesInvitacion.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			// debe agregar campos de la Vista
					lbeProveedoresRequisicionesInvitacion.Add(obeProveedoresRequisicionesInvitacion);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresRequisicionesInvitacion;
		}
	}
}
}
