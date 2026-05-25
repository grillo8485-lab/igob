using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daDependencias
 {
	public int guardarDependencias(SqlConnection Conexion, beDependencias obeDependencias)
	{
		int Id=0;
		string sp = "Proc_DependenciasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeDependencias.IdDependencia;
				cmd.Parameters.Add("@Dependencia", SqlDbType.NVarChar).Value = obeDependencias.Dependencia;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeDependencias.Abreviatura;
				cmd.Parameters.Add("@Sitiooficial", SqlDbType.NVarChar).Value = obeDependencias.Sitiooficial;
				cmd.Parameters.Add("@Titular", SqlDbType.NVarChar).Value = obeDependencias.Titular;
				cmd.Parameters.Add("@Rfc", SqlDbType.NVarChar).Value = obeDependencias.Rfc;
				cmd.Parameters.Add("@Calle", SqlDbType.NVarChar).Value = obeDependencias.Calle;
				cmd.Parameters.Add("@NoExterior", SqlDbType.Char).Value = obeDependencias.NoExterior;
				cmd.Parameters.Add("@NoInterior", SqlDbType.Char).Value = obeDependencias.NoInterior;
				cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeDependencias.IdMunicipio;
				cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = obeDependencias.Colonia;
				cmd.Parameters.Add("@CodigoPostal", SqlDbType.Char).Value = obeDependencias.CodigoPostal;
				cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = obeDependencias.Telefono;
				cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = obeDependencias.Email;
				cmd.Parameters.Add("@Logo", SqlDbType.NVarChar).Value = obeDependencias.Logo;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeDependencias.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeDependencias.FechaRegistro;
				cmd.Parameters.Add("@localidad", SqlDbType.NVarChar).Value = obeDependencias.Localidad;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeDependencias.IdGobierno;

                    Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarDependencias(SqlConnection Conexion, beDependencias obeDependencias)
	{
		string sp = "Proc_DependenciasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeDependencias.IdDependencia;
				cmd.Parameters.Add("@Dependencia", SqlDbType.NVarChar).Value = obeDependencias.Dependencia;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeDependencias.Abreviatura;
				cmd.Parameters.Add("@Sitiooficial", SqlDbType.NVarChar).Value = obeDependencias.Sitiooficial;
				cmd.Parameters.Add("@Titular", SqlDbType.NVarChar).Value = obeDependencias.Titular;
				cmd.Parameters.Add("@Rfc", SqlDbType.NVarChar).Value = obeDependencias.Rfc;
				cmd.Parameters.Add("@Calle", SqlDbType.NVarChar).Value = obeDependencias.Calle;
				cmd.Parameters.Add("@NoExterior", SqlDbType.Char).Value = obeDependencias.NoExterior;
				cmd.Parameters.Add("@NoInterior", SqlDbType.Char).Value = obeDependencias.NoInterior;
				cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeDependencias.IdMunicipio;
				cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = obeDependencias.Colonia;
				cmd.Parameters.Add("@CodigoPostal", SqlDbType.Char).Value = obeDependencias.CodigoPostal;
				cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = obeDependencias.Telefono;
				cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = obeDependencias.Email;
				cmd.Parameters.Add("@Logo", SqlDbType.NVarChar).Value = obeDependencias.Logo;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeDependencias.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeDependencias.FechaRegistro;
				cmd.Parameters.Add("@localidad", SqlDbType.NVarChar).Value = obeDependencias.Localidad;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeDependencias.IdGobierno;

                    cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarDependencias(SqlConnection Conexion,int pIdDependencia)
	{
		string sp = "Proc_DependenciasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = pIdDependencia;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beDependencias traerDependencias_x_IdDependencia(SqlConnection Conexion,int IdDependencia)
	{
		string sp = "Proc_Dependencias_x_IdDependencia";
		List<beDependencias> lbeDependencias = null;
				beDependencias obeDependencias=new beDependencias();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = IdDependencia;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeDependencias = new List<beDependencias>();
				while (datard.Read())
					{
					 obeDependencias = new beDependencias();
						obeDependencias.IdDependencia = datard["IdDependencia"] as int? ?? default(int);
						obeDependencias.Dependencia = datard["Dependencia"].ToString();
						obeDependencias.Abreviatura = datard["Abreviatura"].ToString();
						obeDependencias.Sitiooficial = datard["Sitiooficial"].ToString();
						obeDependencias.Titular = datard["Titular"].ToString();
						obeDependencias.Rfc = datard["Rfc"].ToString();
						obeDependencias.Calle = datard["Calle"].ToString();
						obeDependencias.NoExterior = datard["NoExterior"].ToString();
						obeDependencias.NoInterior = datard["NoInterior"].ToString();
						obeDependencias.Localidad = datard["Localidad"].ToString();
						obeDependencias.IdMunicipio = datard["IdMunicipio"].ToString();
						obeDependencias.Colonia = datard["Colonia"].ToString();
						obeDependencias.CodigoPostal = datard["CodigoPostal"].ToString();
						obeDependencias.Telefono = datard["Telefono"].ToString();
						obeDependencias.Email = datard["Email"].ToString();
						obeDependencias.Logo = datard["Logo"].ToString();
						obeDependencias.IdUsuarioRegistro = datard["IdUsuarioRegistro"] as int? ?? default(int);
                        obeDependencias.FechaRegistro = DateTime.Parse(datard["FechaRegistro"].ToString());
                        obeDependencias.IdGobierno = datard["IdGobierno"] as int? ?? default(int);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeDependencias;
			}
	}
	public List< beDependencias> listarTodos_Dependencias(SqlConnection Conexion)
	 {
		string sp = "Proc_Dependencias_Traer_Todos";
		List<beDependencias> lbeDependencias = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeDependencias = new List<beDependencias>();
				beDependencias obeDependencias;
				while (datard.Read())
				{
					 obeDependencias = new beDependencias();
					obeDependencias.IdDependencia =  datard.GetInt32(0);
					obeDependencias.Dependencia =  datard.GetString(1);
					obeDependencias.Abreviatura =  datard.GetString(2);
					obeDependencias.Sitiooficial =  datard.GetString(3);
					obeDependencias.Titular =  datard.GetString(4);
					obeDependencias.Rfc =  datard.GetString(5);
					obeDependencias.Calle =  datard.GetString(6);
					obeDependencias.NoExterior =  datard.GetString(7);
					obeDependencias.NoInterior =  datard.GetString(8);
					obeDependencias.Localidad =  datard.GetString(9);
					obeDependencias.IdMunicipio =  datard.GetString(10);
					obeDependencias.Colonia =  datard.GetString(11);
					obeDependencias.CodigoPostal =  datard.GetString(12);
					obeDependencias.Telefono =  datard.GetString(13);
					obeDependencias.Email =  datard.GetString(14);
					obeDependencias.Logo =  datard.GetString(15);
					obeDependencias.IdUsuarioRegistro =  datard.GetInt32(16);
					obeDependencias.FechaRegistro =  datard.GetDateTime(17);
					obeDependencias.IdGobierno =  datard.GetInt32(18);
					lbeDependencias.Add(obeDependencias);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDependencias;
		}
	}

        public List<beDependencias> Listar_Dependencias_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_Dependencias_TraerTodos_GetAll";
            List<beDependencias> lbeDependencias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeDependencias = new List<beDependencias>();
                        beDependencias obeDependencias;
                        while (datard.Read())
                        {
                            obeDependencias = new beDependencias();
                            obeDependencias.IdDependencia = datard.GetInt32(0);
                            obeDependencias.Dependencia = datard.GetString(1);
                            obeDependencias.Abreviatura = datard.GetString(2);
                            obeDependencias.Sitiooficial = datard.GetString(3);
                            obeDependencias.Titular = datard.GetString(4);
                            obeDependencias.Rfc = datard.GetString(5);
                            obeDependencias.Calle = datard.GetString(6);
                            obeDependencias.NoExterior = datard.GetString(7);
                            obeDependencias.NoInterior = datard.GetString(8);
                            obeDependencias.Localidad = datard.GetString(9);
                            obeDependencias.IdMunicipio = datard.GetString(10);
                            obeDependencias.Colonia = datard.GetString(11);
                            obeDependencias.CodigoPostal = datard.GetString(12);
                            obeDependencias.Telefono = datard.GetString(13);
                            obeDependencias.Email = datard.GetString(14);
                            obeDependencias.Logo = datard.GetString(15);
                            obeDependencias.IdUsuarioRegistro = datard.GetInt32(16);
                            obeDependencias.FechaRegistro = datard.GetDateTime(17);
                            obeDependencias.IdGobierno = datard.GetInt32(18);
                            obeDependencias.Municipio = datard.GetString(19);
                            obeDependencias.ClaveEstado = datard.GetString(20);
                            obeDependencias.Estado = datard.GetString(21);
                            lbeDependencias.Add(obeDependencias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeDependencias;
            }
        }

    }
}
