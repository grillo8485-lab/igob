using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daSysUsuarios
 {
	public int guardarSysUsuarios(SqlConnection Conexion, beSysUsuarios obeSysUsuarios)
	{
		int Id=0;
		string sp = "Proc_SysUsuariosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = obeSysUsuarios.IdUsuario;
				cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = obeSysUsuarios.Usuario;
				cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = obeSysUsuarios.Password;
				cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = obeSysUsuarios.Apellidos;
				cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = obeSysUsuarios.Nombres;
				cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeSysUsuarios.IdPerfil;
				cmd.Parameters.Add("@IdEstatusUsuario", SqlDbType.Char).Value = obeSysUsuarios.IdEstatusUsuario;
				cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeSysUsuarios.IdDependencia;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeSysUsuarios.IdProveedor;
				cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = obeSysUsuarios.IdPersona;
				cmd.Parameters.Add("@CorreoElectronico", SqlDbType.NVarChar).Value = obeSysUsuarios.CorreoElectronico;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeSysUsuarios.Activo;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeSysUsuarios.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeSysUsuarios.FechaRegistro;
				cmd.Parameters.Add("@NoToken", SqlDbType.Char).Value = obeSysUsuarios.NoToken;
				cmd.Parameters.Add("@llaveAcceso", SqlDbType.NVarChar).Value = obeSysUsuarios.LlaveAcceso;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarSysUsuarios(SqlConnection Conexion, beSysUsuarios obeSysUsuarios)
	{
		string sp = "Proc_SysUsuariosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = obeSysUsuarios.IdUsuario;
				cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = obeSysUsuarios.Usuario;
				cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = obeSysUsuarios.Password;
				cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = obeSysUsuarios.Apellidos;
				cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = obeSysUsuarios.Nombres;
				cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeSysUsuarios.IdPerfil;
				cmd.Parameters.Add("@IdEstatusUsuario", SqlDbType.Char).Value = obeSysUsuarios.IdEstatusUsuario;
				cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeSysUsuarios.IdDependencia;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeSysUsuarios.IdProveedor;
				cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = obeSysUsuarios.IdPersona;
				cmd.Parameters.Add("@CorreoElectronico", SqlDbType.NVarChar).Value = obeSysUsuarios.CorreoElectronico;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeSysUsuarios.Activo;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeSysUsuarios.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeSysUsuarios.FechaRegistro;
				cmd.Parameters.Add("@NoToken", SqlDbType.Char).Value = obeSysUsuarios.NoToken;
				cmd.Parameters.Add("@llaveAcceso", SqlDbType.NVarChar).Value = obeSysUsuarios.LlaveAcceso;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarSysUsuarios(SqlConnection Conexion,int pIdUsuario)
	{
		string sp = "Proc_SysUsuariosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = pIdUsuario;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beSysUsuarios traerSysUsuarios_x_IdUsuario(SqlConnection Conexion,int IdUsuario)
	{
		string sp = "Proc_SysUsuarios_x_IdUsuario";
				beSysUsuarios obeSysUsuarios=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdUsuario = datard.GetOrdinal("IdUsuario");
						int posUsuario = datard.GetOrdinal("Usuario");
						int posPassword = datard.GetOrdinal("Password");
						int posApellidos = datard.GetOrdinal("Apellidos");
						int posNombres = datard.GetOrdinal("Nombres");
						int posIdPerfil = datard.GetOrdinal("IdPerfil");
						int posIdEstatusUsuario = datard.GetOrdinal("IdEstatusUsuario");
						int posIdDependencia = datard.GetOrdinal("IdDependencia");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdPersona = datard.GetOrdinal("IdPersona");
						int posCorreoElectronico = datard.GetOrdinal("CorreoElectronico");
						int posActivo = datard.GetOrdinal("Activo");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posNoToken = datard.GetOrdinal("NoToken");
						int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
					 obeSysUsuarios = new beSysUsuarios();
				while (datard.Read())
					{
						obeSysUsuarios.IdUsuario =  datard.GetInt32(posIdUsuario);
						obeSysUsuarios.Usuario =  datard.GetString(posUsuario);
						obeSysUsuarios.Password =  datard.GetString(posPassword);
						obeSysUsuarios.Apellidos =  datard.GetString(posApellidos);
						obeSysUsuarios.Nombres =  datard.GetString(posNombres);
						obeSysUsuarios.IdPerfil =  datard.GetInt32(posIdPerfil);
						obeSysUsuarios.IdEstatusUsuario =  datard.GetString(posIdEstatusUsuario);
						obeSysUsuarios.IdDependencia =  datard.GetInt32(posIdDependencia);
						obeSysUsuarios.IdProveedor =  datard.GetInt32(posIdProveedor);
						obeSysUsuarios.IdPersona =  datard.GetInt32(posIdPersona);
						obeSysUsuarios.CorreoElectronico =  datard.GetString(posCorreoElectronico);
						obeSysUsuarios.Activo =  datard.GetBoolean(posActivo);
						obeSysUsuarios.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeSysUsuarios.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
						obeSysUsuarios.NoToken = datard[posNoToken] ==DBNull.Value?"": datard.GetString(posNoToken);
						obeSysUsuarios.LlaveAcceso = datard[posllaveAcceso] == DBNull.Value ? "" : datard.GetString(posllaveAcceso);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeSysUsuarios;
			}
	}
	public List< beSysUsuarios> listarTodos_SysUsuarios(SqlConnection Conexion)
	 {
		string sp = "Proc_SysUsuarios_Traer_Todos";
		List<beSysUsuarios> lbeSysUsuarios = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdUsuario = datard.GetOrdinal("IdUsuario");
						int posUsuario = datard.GetOrdinal("Usuario");
						int posPassword = datard.GetOrdinal("Password");
						int posApellidos = datard.GetOrdinal("Apellidos");
						int posNombres = datard.GetOrdinal("Nombres");
						int posIdPerfil = datard.GetOrdinal("IdPerfil");
						int posIdEstatusUsuario = datard.GetOrdinal("IdEstatusUsuario");
						int posIdDependencia = datard.GetOrdinal("IdDependencia");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdPersona = datard.GetOrdinal("IdPersona");
						int posCorreoElectronico = datard.GetOrdinal("CorreoElectronico");
						int posActivo = datard.GetOrdinal("Activo");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posNoToken = datard.GetOrdinal("NoToken");
						int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
				lbeSysUsuarios = new List<beSysUsuarios>();
				beSysUsuarios obeSysUsuarios;
				while (datard.Read())
				{
					 obeSysUsuarios = new beSysUsuarios();
					obeSysUsuarios.IdUsuario =  datard.GetInt32(posIdUsuario);
					obeSysUsuarios.Usuario =  datard.GetString(posUsuario);
					obeSysUsuarios.Password =  datard.GetString(posPassword);
					obeSysUsuarios.Apellidos =  datard.GetString(posApellidos);
					obeSysUsuarios.Nombres =  datard.GetString(posNombres);
					obeSysUsuarios.IdPerfil =  datard.GetInt32(posIdPerfil);
					obeSysUsuarios.IdEstatusUsuario =  datard.GetString(posIdEstatusUsuario);
					obeSysUsuarios.IdDependencia =  datard.GetInt32(posIdDependencia);
					obeSysUsuarios.IdProveedor =  datard.GetInt32(posIdProveedor);
					obeSysUsuarios.IdPersona =  datard.GetInt32(posIdPersona);
					obeSysUsuarios.CorreoElectronico =  datard.GetString(posCorreoElectronico);
					obeSysUsuarios.Activo =  datard.GetBoolean(posActivo);
					obeSysUsuarios.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeSysUsuarios.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeSysUsuarios.NoToken =  datard.GetString(posNoToken);
					obeSysUsuarios.LlaveAcceso =  datard.GetString(posllaveAcceso);
					lbeSysUsuarios.Add(obeSysUsuarios);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysUsuarios;
		}
	}
	public List< beSysUsuarios> listar_SysUsuarios_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_SysUsuarios_TraerTodos_GetAll";
		List<beSysUsuarios> lbeSysUsuarios = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdUsuario = datard.GetOrdinal("IdUsuario");
						int posUsuario = datard.GetOrdinal("Usuario");
						int posPassword = datard.GetOrdinal("Password");
						int posApellidos = datard.GetOrdinal("Apellidos");
						int posNombres = datard.GetOrdinal("Nombres");
						int posIdPerfil = datard.GetOrdinal("IdPerfil");
						int posIdEstatusUsuario = datard.GetOrdinal("IdEstatusUsuario");
						int posIdDependencia = datard.GetOrdinal("IdDependencia");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdPersona = datard.GetOrdinal("IdPersona");
						int posCorreoElectronico = datard.GetOrdinal("CorreoElectronico");
						int posActivo = datard.GetOrdinal("Activo");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posNoToken = datard.GetOrdinal("NoToken");
						int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
				lbeSysUsuarios = new List<beSysUsuarios>();
				beSysUsuarios obeSysUsuarios;
				while (datard.Read())
				{
					 obeSysUsuarios = new beSysUsuarios();
					obeSysUsuarios.IdUsuario =  datard.GetInt32(posIdUsuario);
					obeSysUsuarios.Usuario =  datard.GetString(posUsuario);
					obeSysUsuarios.Password =  datard.GetString(posPassword);
					obeSysUsuarios.Apellidos =  datard.GetString(posApellidos);
					obeSysUsuarios.Nombres =  datard.GetString(posNombres);
					obeSysUsuarios.IdPerfil =  datard.GetInt32(posIdPerfil);
					obeSysUsuarios.IdEstatusUsuario =  datard.GetString(posIdEstatusUsuario);
					obeSysUsuarios.IdDependencia =  datard.GetInt32(posIdDependencia);
					obeSysUsuarios.IdProveedor =  datard.GetInt32(posIdProveedor);
					obeSysUsuarios.IdPersona =  datard.GetInt32(posIdPersona);
					obeSysUsuarios.CorreoElectronico =  datard.GetString(posCorreoElectronico);
					obeSysUsuarios.Activo =  datard.GetBoolean(posActivo);
					obeSysUsuarios.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeSysUsuarios.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeSysUsuarios.NoToken =  datard.GetString(posNoToken);
					obeSysUsuarios.LlaveAcceso =  datard.GetString(posllaveAcceso);
			// debe agregar campos de la Vista
					lbeSysUsuarios.Add(obeSysUsuarios);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysUsuarios;
		}
	}
        public beSysUsuarios traerSysUsuario_x_Usuario_X_Password(SqlConnection Conexion, string _username, string _password = "")
        {
            string sp = "SysProc_SysUsuarios_TraerUsuarioLogin";
            List<beSysUsuarios> lbeSysUsuarios = null;
            beSysUsuarios obeSysUsuarios = new beSysUsuarios();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = _username;
            if (_password != "")
            {
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = _password;
            }
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdUsuario = datard.GetOrdinal("IdUsuario");
                        int posUsuario = datard.GetOrdinal("Usuario");
                        int posPassword = datard.GetOrdinal("Password");
                        int posApellidos = datard.GetOrdinal("Apellidos");
                        int posNombres = datard.GetOrdinal("Nombres");
                        int posIdPerfil = datard.GetOrdinal("IdPerfil");
                        int posIdEstatusUsuario = datard.GetOrdinal("IdEstatusUsuario");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posIdPersona = datard.GetOrdinal("IdPersona");
                        int posCorreoElectronico = datard.GetOrdinal("CorreoElectronico");
                        int posActivo = datard.GetOrdinal("Activo");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posNoToken = datard.GetOrdinal("NoToken");
                        int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
                        lbeSysUsuarios = new List<beSysUsuarios>();
                        while (datard.Read())
                        {
                            obeSysUsuarios = new beSysUsuarios();
                            obeSysUsuarios.IdUsuario = datard.GetInt32(posIdUsuario);
                            obeSysUsuarios.Usuario = datard.GetString(posUsuario);
                            obeSysUsuarios.Password = datard.GetString(posPassword);
                            obeSysUsuarios.Apellidos = datard.GetString(posApellidos);
                            obeSysUsuarios.Nombres = datard.GetString(posNombres);
                            obeSysUsuarios.IdPerfil = datard.GetInt32(posIdPerfil);
                            obeSysUsuarios.IdEstatusUsuario = datard.GetString(posIdEstatusUsuario);
                            obeSysUsuarios.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeSysUsuarios.IdProveedor = datard.GetInt32(posIdProveedor);
                            obeSysUsuarios.IdPersona = datard.GetInt32(posIdPersona);
                            obeSysUsuarios.CorreoElectronico = datard.GetString(posCorreoElectronico);
                            obeSysUsuarios.Activo = datard.GetBoolean(posActivo);
                            obeSysUsuarios.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeSysUsuarios.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeSysUsuarios.NoToken = datard[posNoToken] == DBNull.Value ? "" : datard.GetString(posNoToken);
                            obeSysUsuarios.LlaveAcceso = datard[posllaveAcceso] == DBNull.Value ? "" : datard.GetString(posllaveAcceso);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeSysUsuarios;
            }
        }

        public List<beSysUsuarios> Usuarios_Traer_IdPerfil(SqlConnection Conexion, int IdPerfil)
        {
            string sp = "SysProc_SysUsuarios_Traer_IdPerfil";
            List<beSysUsuarios> lbeSysUsuarios = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeSysUsuarios = new List<beSysUsuarios>();

                        int posIdUsuario = datard.GetOrdinal("IdUsuario");
                        int posApellidos = datard.GetOrdinal("Apellidos");
                        int posNombres = datard.GetOrdinal("Nombres");
                        int posIdPerfil = datard.GetOrdinal("IdPerfil");
                        int posIdPersona = datard.GetOrdinal("IdPersona");
                        int posNombreCompleto = datard.GetOrdinal("NombreCompleto");
                        int posllaveAcceso = datard.GetOrdinal("llaveAcceso");

                        beSysUsuarios obeSysUsuarios;
                        while (datard.Read())
                        {
                            obeSysUsuarios = new beSysUsuarios();
                            obeSysUsuarios.IdUsuario = datard.GetInt32(posIdUsuario);
                            obeSysUsuarios.Apellidos = datard.GetString(posApellidos);
                            obeSysUsuarios.Nombres = datard.GetString(posNombres);
                            obeSysUsuarios.IdPerfil = datard.GetInt32(posIdPerfil);
                            obeSysUsuarios.IdPersona = datard.GetInt32(posIdPersona);
                            obeSysUsuarios.Usuario = datard.GetString(posNombreCompleto);
                            obeSysUsuarios.LlaveAcceso = datard[posllaveAcceso] == DBNull.Value?"": datard.GetString(posllaveAcceso);
                            lbeSysUsuarios.Add(obeSysUsuarios);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeSysUsuarios;
            }
        }
    }
}
