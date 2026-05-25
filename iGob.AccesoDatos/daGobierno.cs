using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daGobierno
 {
	public int guardarGobierno(SqlConnection Conexion, beGobierno obeGobierno)
	{
		int Id=0;
		string sp = "Proc_GobiernoInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeGobierno.IdGobierno;
				cmd.Parameters.Add("@Gobierno", SqlDbType.NVarChar).Value = obeGobierno.Gobierno;
				cmd.Parameters.Add("@RepertirAccionistas", SqlDbType.Bit).Value = obeGobierno.RepertirAccionistas;
				cmd.Parameters.Add("@LimiteGirosProveedor", SqlDbType.Int).Value = obeGobierno.LimiteGirosProveedor;
				cmd.Parameters.Add("@Cobrobases", SqlDbType.Bit).Value = obeGobierno.Cobrobases;
				cmd.Parameters.Add("@MontoBases", SqlDbType.Decimal).Value = obeGobierno.MontoBases;
				cmd.Parameters.Add("@HorarioLaboralInicio", SqlDbType.Time).Value = obeGobierno.HorarioLaboralInicio;
				cmd.Parameters.Add("@HorarioLaboralFin", SqlDbType.Time).Value = obeGobierno.HorarioLaboralFin;
				cmd.Parameters.Add("@AlertaVerde", SqlDbType.Time).Value = obeGobierno.AlertaVerde;
				cmd.Parameters.Add("@AlertaAmarilla", SqlDbType.Time).Value = obeGobierno.AlertaAmarilla;
				cmd.Parameters.Add("@AlertaRoja", SqlDbType.Time).Value = obeGobierno.AlertaRoja;
				cmd.Parameters.Add("@DiasEnvioCorreo2daVuelta", SqlDbType.Int).Value = obeGobierno.DiasEnvioCorreo2daVuelta;
				cmd.Parameters.Add("@DiasCancelarNoAtendida", SqlDbType.Int).Value = obeGobierno.DiasCancelarNoAtendida;
				cmd.Parameters.Add("@TiempoValidaPago", SqlDbType.Time).Value = obeGobierno.TiempoValidaPago;
				cmd.Parameters.Add("@TiempoExtraValidaPago", SqlDbType.Time).Value = obeGobierno.TiempoExtraValidaPago;
				cmd.Parameters.Add("@AplicarRestriccionCedula", SqlDbType.Int).Value = obeGobierno.AplicarRestriccionCedula;
				cmd.Parameters.Add("@UrlBanner", SqlDbType.NVarChar).Value = obeGobierno.UrlBanner;
				cmd.Parameters.Add("@UrlLogo", SqlDbType.NVarChar).Value = obeGobierno.UrlLogo;
				cmd.Parameters.Add("@AplicarFechasCedula", SqlDbType.Bit).Value = obeGobierno.AplicarFechasCedula;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeGobierno.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeGobierno.FechaRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarGobierno(SqlConnection Conexion, beGobierno obeGobierno)
	{
		string sp = "Proc_GobiernoActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeGobierno.IdGobierno;
				cmd.Parameters.Add("@Gobierno", SqlDbType.NVarChar).Value = obeGobierno.Gobierno;
				cmd.Parameters.Add("@RepertirAccionistas", SqlDbType.Bit).Value = obeGobierno.RepertirAccionistas;
				cmd.Parameters.Add("@LimiteGirosProveedor", SqlDbType.Int).Value = obeGobierno.LimiteGirosProveedor;
				cmd.Parameters.Add("@Cobrobases", SqlDbType.Bit).Value = obeGobierno.Cobrobases;
				cmd.Parameters.Add("@MontoBases", SqlDbType.Decimal).Value = obeGobierno.MontoBases;
				cmd.Parameters.Add("@HorarioLaboralInicio", SqlDbType.Time).Value = obeGobierno.HorarioLaboralInicio;
				cmd.Parameters.Add("@HorarioLaboralFin", SqlDbType.Time).Value = obeGobierno.HorarioLaboralFin;
				cmd.Parameters.Add("@AlertaVerde", SqlDbType.Time).Value = obeGobierno.AlertaVerde;
				cmd.Parameters.Add("@AlertaAmarilla", SqlDbType.Time).Value = obeGobierno.AlertaAmarilla;
				cmd.Parameters.Add("@AlertaRoja", SqlDbType.Time).Value = obeGobierno.AlertaRoja;
				cmd.Parameters.Add("@DiasEnvioCorreo2daVuelta", SqlDbType.Int).Value = obeGobierno.DiasEnvioCorreo2daVuelta;
				cmd.Parameters.Add("@DiasCancelarNoAtendida", SqlDbType.Int).Value = obeGobierno.DiasCancelarNoAtendida;
				cmd.Parameters.Add("@TiempoValidaPago", SqlDbType.Time).Value = obeGobierno.TiempoValidaPago;
				cmd.Parameters.Add("@TiempoExtraValidaPago", SqlDbType.Time).Value = obeGobierno.TiempoExtraValidaPago;
				cmd.Parameters.Add("@AplicarRestriccionCedula", SqlDbType.Int).Value = obeGobierno.AplicarRestriccionCedula;
				cmd.Parameters.Add("@UrlBanner", SqlDbType.NVarChar).Value = obeGobierno.UrlBanner;
				cmd.Parameters.Add("@UrlLogo", SqlDbType.NVarChar).Value = obeGobierno.UrlLogo;
				cmd.Parameters.Add("@AplicarFechasCedula", SqlDbType.Bit).Value = obeGobierno.AplicarFechasCedula;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeGobierno.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeGobierno.FechaRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarGobierno(SqlConnection Conexion,int pIdGobierno)
	{
		string sp = "Proc_GobiernoEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = pIdGobierno;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beGobierno traerGobierno_x_IdGobierno(SqlConnection Conexion,int IdGobierno)
	{
		string sp = "Proc_Gobierno_x_IdGobierno";
		List<beGobierno> lbeGobierno = null;
				beGobierno obeGobierno=new beGobierno();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = IdGobierno;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeGobierno = new List<beGobierno>();
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posGobierno = datard.GetOrdinal("Gobierno");
						int posRepertirAccionistas = datard.GetOrdinal("RepertirAccionistas");
						int posLimiteGirosProveedor = datard.GetOrdinal("LimiteGirosProveedor");
						int posCobrobases = datard.GetOrdinal("Cobrobases");
						int posMontoBases = datard.GetOrdinal("MontoBases");
						int posHorarioLaboralInicio = datard.GetOrdinal("HorarioLaboralInicio");
						int posHorarioLaboralFin = datard.GetOrdinal("HorarioLaboralFin");
						int posAlertaVerde = datard.GetOrdinal("AlertaVerde");
						int posAlertaAmarilla = datard.GetOrdinal("AlertaAmarilla");
						int posAlertaRoja = datard.GetOrdinal("AlertaRoja");
						int posDiasEnvioCorreo2daVuelta = datard.GetOrdinal("DiasEnvioCorreo2daVuelta");
						int posDiasCancelarNoAtendida = datard.GetOrdinal("DiasCancelarNoAtendida");
						int posTiempoValidaPago = datard.GetOrdinal("TiempoValidaPago");
						int posTiempoExtraValidaPago = datard.GetOrdinal("TiempoExtraValidaPago");
						int posAplicarRestriccionCedula = datard.GetOrdinal("AplicarRestriccionCedula");
						int posUrlBanner = datard.GetOrdinal("UrlBanner");
						int posUrlLogo = datard.GetOrdinal("UrlLogo");
						int posAplicarFechasCedula = datard.GetOrdinal("AplicarFechasCedula");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				while (datard.Read())
					{
					 obeGobierno = new beGobierno();
						obeGobierno.IdGobierno =  datard.GetInt32(posIdGobierno);
						obeGobierno.Gobierno =  datard.GetString(posGobierno);
						obeGobierno.RepertirAccionistas =  datard.GetBoolean(posRepertirAccionistas);
						obeGobierno.LimiteGirosProveedor =  datard.GetInt32(posLimiteGirosProveedor);
						obeGobierno.Cobrobases =  datard.GetBoolean(posCobrobases);
						obeGobierno.MontoBases =  datard.GetDecimal(posMontoBases);
						obeGobierno.HorarioLaboralInicio =  datard.GetTimeSpan(posHorarioLaboralInicio);
						obeGobierno.HorarioLaboralFin =  datard.GetTimeSpan(posHorarioLaboralFin);
						obeGobierno.AlertaVerde =  datard.GetTimeSpan(posAlertaVerde);
						obeGobierno.AlertaAmarilla =  datard.GetTimeSpan(posAlertaAmarilla);
						obeGobierno.AlertaRoja =  datard.GetTimeSpan(posAlertaRoja);
						obeGobierno.DiasEnvioCorreo2daVuelta =  datard.GetInt32(posDiasEnvioCorreo2daVuelta);
						obeGobierno.DiasCancelarNoAtendida =  datard.GetInt32(posDiasCancelarNoAtendida);
						obeGobierno.TiempoValidaPago =  datard.GetTimeSpan(posTiempoValidaPago);
						obeGobierno.TiempoExtraValidaPago =  datard.GetTimeSpan(posTiempoExtraValidaPago);
						obeGobierno.AplicarRestriccionCedula =  datard.GetInt32(posAplicarRestriccionCedula);
						obeGobierno.UrlBanner =  datard.GetString(posUrlBanner);
						obeGobierno.UrlLogo =  datard.GetString(posUrlLogo);
						obeGobierno.AplicarFechasCedula =  datard.GetBoolean(posAplicarFechasCedula);
						obeGobierno.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeGobierno.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeGobierno;
			}
	}
	public List< beGobierno> listarTodos_Gobierno(SqlConnection Conexion)
	 {
		string sp = "Proc_Gobierno_Traer_Todos";
		List<beGobierno> lbeGobierno = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posGobierno = datard.GetOrdinal("Gobierno");
						int posRepertirAccionistas = datard.GetOrdinal("RepertirAccionistas");
						int posLimiteGirosProveedor = datard.GetOrdinal("LimiteGirosProveedor");
						int posCobrobases = datard.GetOrdinal("Cobrobases");
						int posMontoBases = datard.GetOrdinal("MontoBases");
						int posHorarioLaboralInicio = datard.GetOrdinal("HorarioLaboralInicio");
						int posHorarioLaboralFin = datard.GetOrdinal("HorarioLaboralFin");
						int posAlertaVerde = datard.GetOrdinal("AlertaVerde");
						int posAlertaAmarilla = datard.GetOrdinal("AlertaAmarilla");
						int posAlertaRoja = datard.GetOrdinal("AlertaRoja");
						int posDiasEnvioCorreo2daVuelta = datard.GetOrdinal("DiasEnvioCorreo2daVuelta");
						int posDiasCancelarNoAtendida = datard.GetOrdinal("DiasCancelarNoAtendida");
						int posTiempoValidaPago = datard.GetOrdinal("TiempoValidaPago");
						int posTiempoExtraValidaPago = datard.GetOrdinal("TiempoExtraValidaPago");
						int posAplicarRestriccionCedula = datard.GetOrdinal("AplicarRestriccionCedula");
						int posUrlBanner = datard.GetOrdinal("UrlBanner");
						int posUrlLogo = datard.GetOrdinal("UrlLogo");
						int posAplicarFechasCedula = datard.GetOrdinal("AplicarFechasCedula");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeGobierno = new List<beGobierno>();
				beGobierno obeGobierno;
				while (datard.Read())
				{
					 obeGobierno = new beGobierno();
					obeGobierno.IdGobierno =  datard.GetInt32(posIdGobierno);
					obeGobierno.Gobierno =  datard.GetString(posGobierno);
					obeGobierno.RepertirAccionistas =  datard.GetBoolean(posRepertirAccionistas);
					obeGobierno.LimiteGirosProveedor =  datard.GetInt32(posLimiteGirosProveedor);
					obeGobierno.Cobrobases =  datard.GetBoolean(posCobrobases);
					obeGobierno.MontoBases =  datard.GetDecimal(posMontoBases);
					obeGobierno.HorarioLaboralInicio =  datard.GetTimeSpan(posHorarioLaboralInicio);
					obeGobierno.HorarioLaboralFin =  datard.GetTimeSpan(posHorarioLaboralFin);
					obeGobierno.AlertaVerde =  datard.GetTimeSpan(posAlertaVerde);
					obeGobierno.AlertaAmarilla =  datard.GetTimeSpan(posAlertaAmarilla);
					obeGobierno.AlertaRoja =  datard.GetTimeSpan(posAlertaRoja);
					obeGobierno.DiasEnvioCorreo2daVuelta =  datard.GetInt32(posDiasEnvioCorreo2daVuelta);
					obeGobierno.DiasCancelarNoAtendida =  datard.GetInt32(posDiasCancelarNoAtendida);
					obeGobierno.TiempoValidaPago =  datard.GetTimeSpan(posTiempoValidaPago);
					obeGobierno.TiempoExtraValidaPago =  datard.GetTimeSpan(posTiempoExtraValidaPago);
					obeGobierno.AplicarRestriccionCedula =  datard.GetInt32(posAplicarRestriccionCedula);
					obeGobierno.UrlBanner =  datard.GetString(posUrlBanner);
					obeGobierno.UrlLogo =  datard.GetString(posUrlLogo);
					obeGobierno.AplicarFechasCedula =  datard.GetBoolean(posAplicarFechasCedula);
					obeGobierno.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeGobierno.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					lbeGobierno.Add(obeGobierno);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeGobierno;
		}
	}
	public List< beGobierno> listar_Gobierno_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_Gobierno_TraerTodos_GetAll";
		List<beGobierno> lbeGobierno = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posGobierno = datard.GetOrdinal("Gobierno");
						int posRepertirAccionistas = datard.GetOrdinal("RepertirAccionistas");
						int posLimiteGirosProveedor = datard.GetOrdinal("LimiteGirosProveedor");
						int posCobrobases = datard.GetOrdinal("Cobrobases");
						int posMontoBases = datard.GetOrdinal("MontoBases");
						int posHorarioLaboralInicio = datard.GetOrdinal("HorarioLaboralInicio");
						int posHorarioLaboralFin = datard.GetOrdinal("HorarioLaboralFin");
						int posAlertaVerde = datard.GetOrdinal("AlertaVerde");
						int posAlertaAmarilla = datard.GetOrdinal("AlertaAmarilla");
						int posAlertaRoja = datard.GetOrdinal("AlertaRoja");
						int posDiasEnvioCorreo2daVuelta = datard.GetOrdinal("DiasEnvioCorreo2daVuelta");
						int posDiasCancelarNoAtendida = datard.GetOrdinal("DiasCancelarNoAtendida");
						int posTiempoValidaPago = datard.GetOrdinal("TiempoValidaPago");
						int posTiempoExtraValidaPago = datard.GetOrdinal("TiempoExtraValidaPago");
						int posAplicarRestriccionCedula = datard.GetOrdinal("AplicarRestriccionCedula");
						int posUrlBanner = datard.GetOrdinal("UrlBanner");
						int posUrlLogo = datard.GetOrdinal("UrlLogo");
						int posAplicarFechasCedula = datard.GetOrdinal("AplicarFechasCedula");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeGobierno = new List<beGobierno>();
				beGobierno obeGobierno;
				while (datard.Read())
				{
					 obeGobierno = new beGobierno();
					obeGobierno.IdGobierno =  datard.GetInt32(posIdGobierno);
					obeGobierno.Gobierno =  datard.GetString(posGobierno);
					obeGobierno.RepertirAccionistas =  datard.GetBoolean(posRepertirAccionistas);
					obeGobierno.LimiteGirosProveedor =  datard.GetInt32(posLimiteGirosProveedor);
					obeGobierno.Cobrobases =  datard.GetBoolean(posCobrobases);
					obeGobierno.MontoBases =  datard.GetDecimal(posMontoBases);
					obeGobierno.HorarioLaboralInicio =  datard.GetTimeSpan(posHorarioLaboralInicio);
					obeGobierno.HorarioLaboralFin =  datard.GetTimeSpan(posHorarioLaboralFin);
					obeGobierno.AlertaVerde =  datard.GetTimeSpan(posAlertaVerde);
					obeGobierno.AlertaAmarilla =  datard.GetTimeSpan(posAlertaAmarilla);
					obeGobierno.AlertaRoja =  datard.GetTimeSpan(posAlertaRoja);
					obeGobierno.DiasEnvioCorreo2daVuelta =  datard.GetInt32(posDiasEnvioCorreo2daVuelta);
					obeGobierno.DiasCancelarNoAtendida =  datard.GetInt32(posDiasCancelarNoAtendida);
					obeGobierno.TiempoValidaPago =  datard.GetTimeSpan(posTiempoValidaPago);
					obeGobierno.TiempoExtraValidaPago =  datard.GetTimeSpan(posTiempoExtraValidaPago);
					obeGobierno.AplicarRestriccionCedula =  datard.GetInt32(posAplicarRestriccionCedula);
					obeGobierno.UrlBanner =  datard.GetString(posUrlBanner);
					obeGobierno.UrlLogo =  datard.GetString(posUrlLogo);
					obeGobierno.AplicarFechasCedula =  datard.GetBoolean(posAplicarFechasCedula);
					obeGobierno.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeGobierno.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			// debe agregar campos de la Vista
					lbeGobierno.Add(obeGobierno);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeGobierno;
		}
	}
}
}
