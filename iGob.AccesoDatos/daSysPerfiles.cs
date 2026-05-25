using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daSysPerfiles
 {
	public int guardarSysPerfiles(SqlConnection Conexion, beSysPerfiles obeSysPerfiles)
	{
		int Id=0;
		string sp = "SysProc_SysPerfilesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeSysPerfiles.IdPerfil;
				cmd.Parameters.Add("@Perfil", SqlDbType.VarChar).Value = obeSysPerfiles.Perfil;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeSysPerfiles.Descripcion;
				cmd.Parameters.Add("@CodigoPerfil", SqlDbType.NChar).Value = obeSysPerfiles.CodigoPerfil;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeSysPerfiles.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarSysPerfiles(SqlConnection Conexion, beSysPerfiles obeSysPerfiles)
	{
		string sp = "SysProc_SysPerfilesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeSysPerfiles.IdPerfil;
				cmd.Parameters.Add("@Perfil", SqlDbType.VarChar).Value = obeSysPerfiles.Perfil;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeSysPerfiles.Descripcion;
				cmd.Parameters.Add("@CodigoPerfil", SqlDbType.NChar).Value = obeSysPerfiles.CodigoPerfil;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeSysPerfiles.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarSysPerfiles(SqlConnection Conexion,int pIdPerfil)
	{
		string sp = "SysProc_SysPerfilesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = pIdPerfil;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beSysPerfiles traerSysPerfiles_x_IdPerfil(SqlConnection Conexion,int IdPerfil)
	{
		string sp = "SysProc_SysPerfiles_x_IdPerfil";
		List<beSysPerfiles> lbeSysPerfiles = null;
				beSysPerfiles obeSysPerfiles=new beSysPerfiles();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeSysPerfiles = new List<beSysPerfiles>();
				while (datard.Read())
					{
					 obeSysPerfiles = new beSysPerfiles();
						obeSysPerfiles.IdPerfil =  datard.GetInt32(0);
						obeSysPerfiles.Perfil =  datard.GetString(1);
						obeSysPerfiles.Descripcion =  datard.GetString(2);
						obeSysPerfiles.CodigoPerfil =  datard.GetString(3);
						obeSysPerfiles.Activo =  datard.GetBoolean(4);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeSysPerfiles;
			}
	}
	public List< beSysPerfiles> listarTodos_SysPerfiles(SqlConnection Conexion)
	 {
		string sp = "SysProc_SysPerfiles_Traer_Todos";
		List<beSysPerfiles> lbeSysPerfiles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeSysPerfiles = new List<beSysPerfiles>();
				beSysPerfiles obeSysPerfiles;
				while (datard.Read())
				{
					 obeSysPerfiles = new beSysPerfiles();
					obeSysPerfiles.IdPerfil =  datard.GetInt32(0);
					obeSysPerfiles.Perfil =  datard.GetString(1);
					obeSysPerfiles.Descripcion =  datard.GetString(2);
					obeSysPerfiles.CodigoPerfil =  datard.GetString(3);
					obeSysPerfiles.Activo =  datard.GetBoolean(4);
					lbeSysPerfiles.Add(obeSysPerfiles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysPerfiles;
		}
	}
	public DataTable listarSysPerfiles_GetAll(SqlConnection Conexion)
	 {
		string sp = "SysProc_SysPerfiles_Traer_Todos_GetAll";
		DataTable dtSysPerfiles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtSysPerfiles = new DataTable();
				dtSysPerfiles.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtSysPerfiles;
		}
	}
}
}
