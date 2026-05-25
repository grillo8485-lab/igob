using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daLugaresEntregasPagosCM
    {
	    public int guardarLugaresEntregasPagosCM(SqlConnection Conexion, beLugaresEntregasPagosCM obeLugaresEntregasPagosCM)
	    {
		    int Id=0;
		    string sp = "Proc_LugaresEntregasPagosCMInsertar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdLugarEntregaPago", SqlDbType.Int).Value = obeLugaresEntregasPagosCM.IdLugarEntregaPago;
				    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeLugaresEntregasPagosCM.IdDependencia;
				    cmd.Parameters.Add("@Lugar", SqlDbType.NVarChar).Value = obeLugaresEntregasPagosCM.Lugar;
				    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = obeLugaresEntregasPagosCM.Direccion;
				    cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = obeLugaresEntregasPagosCM.Colonia;
				    cmd.Parameters.Add("@CodigoPostal", SqlDbType.NChar).Value = obeLugaresEntregasPagosCM.CodigoPostal;
				    cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeLugaresEntregasPagosCM.IdMunicipio;
				    cmd.Parameters.Add("@Telefono", SqlDbType.NChar).Value = obeLugaresEntregasPagosCM.Telefono;
				    cmd.Parameters.Add("@LocalizacionGoogle", SqlDbType.NVarChar).Value = obeLugaresEntregasPagosCM.LocalizacionGoogle;
				    cmd.Parameters.Add("@IdTipoLugarCM", SqlDbType.Int).Value = obeLugaresEntregasPagosCM.IdTipoLugarCM;
				    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeLugaresEntregasPagosCM.IdUsuarioRegistro;
				    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeLugaresEntregasPagosCM.FechaRegistro;
			
				    Id =(int)cmd.ExecuteScalar();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return Id;
			}
	    }

	    public int actualizarLugaresEntregasPagosCM(SqlConnection Conexion, beLugaresEntregasPagosCM obeLugaresEntregasPagosCM)
	    {
		    string sp = "Proc_LugaresEntregasPagosCMActualizar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdLugarEntregaPago", SqlDbType.Int).Value = obeLugaresEntregasPagosCM.IdLugarEntregaPago;
				    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeLugaresEntregasPagosCM.IdDependencia;
				    cmd.Parameters.Add("@Lugar", SqlDbType.NVarChar).Value = obeLugaresEntregasPagosCM.Lugar;
				    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = obeLugaresEntregasPagosCM.Direccion;
				    cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = obeLugaresEntregasPagosCM.Colonia;
				    cmd.Parameters.Add("@CodigoPostal", SqlDbType.NChar).Value = obeLugaresEntregasPagosCM.CodigoPostal;
				    cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeLugaresEntregasPagosCM.IdMunicipio;
				    cmd.Parameters.Add("@Telefono", SqlDbType.NChar).Value = obeLugaresEntregasPagosCM.Telefono;
				    cmd.Parameters.Add("@LocalizacionGoogle", SqlDbType.NVarChar).Value = obeLugaresEntregasPagosCM.LocalizacionGoogle;
				    cmd.Parameters.Add("@IdTipoLugarCM", SqlDbType.Int).Value = obeLugaresEntregasPagosCM.IdTipoLugarCM;
				    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeLugaresEntregasPagosCM.IdUsuarioRegistro;
				    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeLugaresEntregasPagosCM.FechaRegistro;
			
				    cmd.ExecuteNonQuery();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return 0;
			}
	    }

	    public int eliminarLugaresEntregasPagosCM(SqlConnection Conexion,int pIdLugarEntregaPago)
	    {
		    string sp = "Proc_LugaresEntregasPagosCMEliminar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdLugarEntregaPago", SqlDbType.Int).Value = pIdLugarEntregaPago;
				    cmd.ExecuteNonQuery();
				    }
				    catch (Exception ex) {
					    throw ex;
				    }
			    return 0;
			}
	    }
	    public beLugaresEntregasPagosCM traerLugaresEntregasPagosCM_x_IdLugarEntregaPago(SqlConnection Conexion,int IdLugarEntregaPago)
	    {
		    string sp = "Proc_LugaresEntregasPagosCM_x_IdLugarEntregaPago";
				    beLugaresEntregasPagosCM obeLugaresEntregasPagosCM=null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    cmd.Parameters.Add("@IdLugarEntregaPago", SqlDbType.Int).Value = IdLugarEntregaPago;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
			    try {
				    if (datard != null)
				    {
						    int posIdLugarEntregaPago = datard.GetOrdinal("IdLugarEntregaPago");
						    int posIdDependencia = datard.GetOrdinal("IdDependencia");
						    int posLugar = datard.GetOrdinal("Lugar");
						    int posDireccion = datard.GetOrdinal("Direccion");
						    int posColonia = datard.GetOrdinal("Colonia");
						    int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
						    int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
						    int posTelefono = datard.GetOrdinal("Telefono");
						    int posLocalizacionGoogle = datard.GetOrdinal("LocalizacionGoogle");
						    int posIdTipoLugarCM = datard.GetOrdinal("IdTipoLugarCM");
						    int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						    int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
					     obeLugaresEntregasPagosCM = new beLugaresEntregasPagosCM();
				    while (datard.Read())
					    {
						    obeLugaresEntregasPagosCM.IdLugarEntregaPago =  datard.GetInt32(posIdLugarEntregaPago);
						    obeLugaresEntregasPagosCM.IdDependencia =  datard.GetInt32(posIdDependencia);
						    obeLugaresEntregasPagosCM.Lugar =  datard.GetString(posLugar);
						    obeLugaresEntregasPagosCM.Direccion =  datard.GetString(posDireccion);
						    obeLugaresEntregasPagosCM.Colonia =  datard.GetString(posColonia);
						    obeLugaresEntregasPagosCM.CodigoPostal =  datard.GetString(posCodigoPostal);
						    obeLugaresEntregasPagosCM.IdMunicipio =  datard.GetString(posIdMunicipio);
						    obeLugaresEntregasPagosCM.Telefono =  datard.GetString(posTelefono);
						    obeLugaresEntregasPagosCM.LocalizacionGoogle =  datard.GetString(posLocalizacionGoogle);
						    obeLugaresEntregasPagosCM.IdTipoLugarCM =  datard.GetInt32(posIdTipoLugarCM);
						    obeLugaresEntregasPagosCM.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						    obeLugaresEntregasPagosCM.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					    }
				    }
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obeLugaresEntregasPagosCM;
			}
	    }
	    public List< beLugaresEntregasPagosCM> listarTodos_LugaresEntregasPagosCM(SqlConnection Conexion)
	    {
		    string sp = "Proc_LugaresEntregasPagosCM_Traer_Todos";
		    List<beLugaresEntregasPagosCM> lbeLugaresEntregasPagosCM = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		        try
                {
			        if (datard != null)
			        {
						        int posIdLugarEntregaPago = datard.GetOrdinal("IdLugarEntregaPago");
						        int posIdDependencia = datard.GetOrdinal("IdDependencia");
						        int posLugar = datard.GetOrdinal("Lugar");
						        int posDireccion = datard.GetOrdinal("Direccion");
						        int posColonia = datard.GetOrdinal("Colonia");
						        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
						        int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
						        int posTelefono = datard.GetOrdinal("Telefono");
						        int posLocalizacionGoogle = datard.GetOrdinal("LocalizacionGoogle");
						        int posIdTipoLugarCM = datard.GetOrdinal("IdTipoLugarCM");
						        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				        lbeLugaresEntregasPagosCM = new List<beLugaresEntregasPagosCM>();
				        beLugaresEntregasPagosCM obeLugaresEntregasPagosCM;
				        while (datard.Read())
				        {
					         obeLugaresEntregasPagosCM = new beLugaresEntregasPagosCM();
					        obeLugaresEntregasPagosCM.IdLugarEntregaPago =  datard.GetInt32(posIdLugarEntregaPago);
					        obeLugaresEntregasPagosCM.IdDependencia =  datard.GetInt32(posIdDependencia);
					        obeLugaresEntregasPagosCM.Lugar =  datard.GetString(posLugar);
					        obeLugaresEntregasPagosCM.Direccion =  datard.GetString(posDireccion);
					        obeLugaresEntregasPagosCM.Colonia =  datard.GetString(posColonia);
					        obeLugaresEntregasPagosCM.CodigoPostal =  datard.GetString(posCodigoPostal);
					        obeLugaresEntregasPagosCM.IdMunicipio =  datard.GetString(posIdMunicipio);
					        obeLugaresEntregasPagosCM.Telefono =  datard.GetString(posTelefono);
					        obeLugaresEntregasPagosCM.LocalizacionGoogle =  datard.GetString(posLocalizacionGoogle);
					        obeLugaresEntregasPagosCM.IdTipoLugarCM =  datard.GetInt32(posIdTipoLugarCM);
					        obeLugaresEntregasPagosCM.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					        obeLugaresEntregasPagosCM.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					        lbeLugaresEntregasPagosCM.Add(obeLugaresEntregasPagosCM);
				        }
			        }
			    }
			    catch (Exception ex) {
			        throw ex;
			    }
			    return lbeLugaresEntregasPagosCM;
		    }
	    }
	    public List< beLugaresEntregasPagosCM> listar_LugaresEntregasPagosCM_GetAll(SqlConnection Conexion)
	     {
		    string sp = "Proc_LugaresEntregasPagosCM_TraerTodos_GetAll";
		    List<beLugaresEntregasPagosCM> lbeLugaresEntregasPagosCM = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdLugarEntregaPago = datard.GetOrdinal("IdLugarEntregaPago");
						    int posIdDependencia = datard.GetOrdinal("IdDependencia");
						    int posLugar = datard.GetOrdinal("Lugar");
						    int posDireccion = datard.GetOrdinal("Direccion");
						    int posColonia = datard.GetOrdinal("Colonia");
						    int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
						    int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
						    int posTelefono = datard.GetOrdinal("Telefono");
						    int posLocalizacionGoogle = datard.GetOrdinal("LocalizacionGoogle");
						    int posIdTipoLugarCM = datard.GetOrdinal("IdTipoLugarCM");
						    int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						    int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				    lbeLugaresEntregasPagosCM = new List<beLugaresEntregasPagosCM>();
				    beLugaresEntregasPagosCM obeLugaresEntregasPagosCM;
				    while (datard.Read())
				    {
					     obeLugaresEntregasPagosCM = new beLugaresEntregasPagosCM();
					    obeLugaresEntregasPagosCM.IdLugarEntregaPago =  datard.GetInt32(posIdLugarEntregaPago);
					    obeLugaresEntregasPagosCM.IdDependencia =  datard.GetInt32(posIdDependencia);
					    obeLugaresEntregasPagosCM.Lugar =  datard.GetString(posLugar);
					    obeLugaresEntregasPagosCM.Direccion =  datard.GetString(posDireccion);
					    obeLugaresEntregasPagosCM.Colonia =  datard.GetString(posColonia);
					    obeLugaresEntregasPagosCM.CodigoPostal =  datard.GetString(posCodigoPostal);
					    obeLugaresEntregasPagosCM.IdMunicipio =  datard.GetString(posIdMunicipio);
					    obeLugaresEntregasPagosCM.Telefono =  datard.GetString(posTelefono);
					    obeLugaresEntregasPagosCM.LocalizacionGoogle =  datard.GetString(posLocalizacionGoogle);
					    obeLugaresEntregasPagosCM.IdTipoLugarCM =  datard.GetInt32(posIdTipoLugarCM);
					    obeLugaresEntregasPagosCM.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					    obeLugaresEntregasPagosCM.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			    // debe agregar campos de la Vista
					    lbeLugaresEntregasPagosCM.Add(obeLugaresEntregasPagosCM);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeLugaresEntregasPagosCM;
		    }
	    }

        public List<beLugaresEntregasPagosCM> traerLugaresPagosCM_x_IdDependencia(SqlConnection Conexion, int IdDependencia)
        {
            string sp = "Proc_LugaresPagosCM_Traer_IdDependencia";
            List<beLugaresEntregasPagosCM> lbeLugaresEntregasPagosCM = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = IdDependencia;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLugarEntregaPago = datard.GetOrdinal("IdLugarEntregaPago");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posLugar = datard.GetOrdinal("Lugar");
                        int posDireccion = datard.GetOrdinal("Direccion");
                        int posColonia = datard.GetOrdinal("Colonia");
                        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
                        int posTelefono = datard.GetOrdinal("Telefono");
                        int posLocalizacionGoogle = datard.GetOrdinal("LocalizacionGoogle");
                        int posIdTipoLugarCM = datard.GetOrdinal("IdTipoLugarCM");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posMunicipio = datard.GetOrdinal("Municipio");
                        int posClaveEstado = datard.GetOrdinal("ClaveEstado");
                        int posEstado = datard.GetOrdinal("Estado");

                        lbeLugaresEntregasPagosCM = new List<beLugaresEntregasPagosCM>();
                        beLugaresEntregasPagosCM obeLugaresEntregasPagosCM;
                        while (datard.Read())
                        {
                            obeLugaresEntregasPagosCM = new beLugaresEntregasPagosCM();
                            obeLugaresEntregasPagosCM.IdLugarEntregaPago = datard.GetInt32(posIdLugarEntregaPago);
                            obeLugaresEntregasPagosCM.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeLugaresEntregasPagosCM.Lugar = datard.GetString(posLugar);
                            obeLugaresEntregasPagosCM.Direccion = datard.GetString(posDireccion);
                            obeLugaresEntregasPagosCM.Colonia = datard.GetString(posColonia);
                            obeLugaresEntregasPagosCM.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeLugaresEntregasPagosCM.IdMunicipio = datard.GetString(posIdMunicipio);
                            obeLugaresEntregasPagosCM.Telefono = datard.GetString(posTelefono);
                            obeLugaresEntregasPagosCM.LocalizacionGoogle = datard.GetString(posLocalizacionGoogle);
                            obeLugaresEntregasPagosCM.IdTipoLugarCM = datard.GetInt32(posIdTipoLugarCM);
                            obeLugaresEntregasPagosCM.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeLugaresEntregasPagosCM.FechaRegistro = datard.GetDateTime(posFechaRegistro);

                            obeLugaresEntregasPagosCM.Dependencia = datard.GetString(posDependencia);
                            obeLugaresEntregasPagosCM.Municipio = datard.GetString(posMunicipio);
                            obeLugaresEntregasPagosCM.ClaveEstado = datard.GetString(posClaveEstado);
                            obeLugaresEntregasPagosCM.Estado = datard.GetString(posEstado);

                            lbeLugaresEntregasPagosCM.Add(obeLugaresEntregasPagosCM);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregasPagosCM;
            }
        }

        public List<beLugaresEntregasPagosCM> traerLugaresEntregasCM_x_IdDependencia(SqlConnection Conexion, int IdDependencia)
        {
            string sp = "Proc_LugaresEntregasCM_Traer_IdDependencia";
            List<beLugaresEntregasPagosCM> lbeLugaresEntregasPagosCM = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = IdDependencia;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLugarEntregaPago = datard.GetOrdinal("IdLugarEntregaPago");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posLugar = datard.GetOrdinal("Lugar");
                        int posDireccion = datard.GetOrdinal("Direccion");
                        int posColonia = datard.GetOrdinal("Colonia");
                        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
                        int posTelefono = datard.GetOrdinal("Telefono");
                        int posLocalizacionGoogle = datard.GetOrdinal("LocalizacionGoogle");
                        int posIdTipoLugarCM = datard.GetOrdinal("IdTipoLugarCM");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posMunicipio = datard.GetOrdinal("Municipio");
                        int posClaveEstado = datard.GetOrdinal("ClaveEstado");
                        int posEstado = datard.GetOrdinal("Estado");

                        lbeLugaresEntregasPagosCM = new List<beLugaresEntregasPagosCM>();
                        beLugaresEntregasPagosCM obeLugaresEntregasPagosCM;
                        while (datard.Read())
                        {
                            obeLugaresEntregasPagosCM = new beLugaresEntregasPagosCM();
                            obeLugaresEntregasPagosCM.IdLugarEntregaPago = datard.GetInt32(posIdLugarEntregaPago);
                            obeLugaresEntregasPagosCM.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeLugaresEntregasPagosCM.Lugar = datard.GetString(posLugar);
                            obeLugaresEntregasPagosCM.Direccion = datard.GetString(posDireccion);
                            obeLugaresEntregasPagosCM.Colonia = datard.GetString(posColonia);
                            obeLugaresEntregasPagosCM.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeLugaresEntregasPagosCM.IdMunicipio = datard.GetString(posIdMunicipio);
                            obeLugaresEntregasPagosCM.Telefono = datard.GetString(posTelefono);
                            obeLugaresEntregasPagosCM.LocalizacionGoogle = datard.GetString(posLocalizacionGoogle);
                            obeLugaresEntregasPagosCM.IdTipoLugarCM = datard.GetInt32(posIdTipoLugarCM);
                            obeLugaresEntregasPagosCM.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeLugaresEntregasPagosCM.FechaRegistro = datard.GetDateTime(posFechaRegistro);

                            obeLugaresEntregasPagosCM.Dependencia = datard.GetString(posDependencia);
                            obeLugaresEntregasPagosCM.Municipio = datard.GetString(posMunicipio);
                            obeLugaresEntregasPagosCM.ClaveEstado = datard.GetString(posClaveEstado);
                            obeLugaresEntregasPagosCM.Estado = datard.GetString(posEstado);

                            lbeLugaresEntregasPagosCM.Add(obeLugaresEntregasPagosCM);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregasPagosCM;
            }
        }

        public List<beLugaresEntregasPagosCM> traerLugaresEntregasPagosCM_x_IdDependencia(SqlConnection Conexion, int IdDependencia)
        {
            string sp = "Proc_LugaresEntregasPagosCM_Traer_IdDependencia";
            List<beLugaresEntregasPagosCM> lbeLugaresEntregasPagosCM = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = IdDependencia;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLugarEntregaPago = datard.GetOrdinal("IdLugarEntregaPago");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posLugar = datard.GetOrdinal("Lugar");
                        int posDireccion = datard.GetOrdinal("Direccion");
                        int posColonia = datard.GetOrdinal("Colonia");
                        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
                        int posTelefono = datard.GetOrdinal("Telefono");
                        int posLocalizacionGoogle = datard.GetOrdinal("LocalizacionGoogle");
                        int posIdTipoLugarCM = datard.GetOrdinal("IdTipoLugarCM");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posMunicipio = datard.GetOrdinal("Municipio");
                        int posClaveEstado = datard.GetOrdinal("ClaveEstado");
                        int posEstado = datard.GetOrdinal("Estado");
                        int posTipoLugar = datard.GetOrdinal("TipoLugar");

                        lbeLugaresEntregasPagosCM = new List<beLugaresEntregasPagosCM>();
                        beLugaresEntregasPagosCM obeLugaresEntregasPagosCM;
                        while (datard.Read())
                        {
                            obeLugaresEntregasPagosCM = new beLugaresEntregasPagosCM();
                            obeLugaresEntregasPagosCM.IdLugarEntregaPago = datard.GetInt32(posIdLugarEntregaPago);
                            obeLugaresEntregasPagosCM.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeLugaresEntregasPagosCM.Lugar = datard.GetString(posLugar);
                            obeLugaresEntregasPagosCM.Direccion = datard.GetString(posDireccion);
                            obeLugaresEntregasPagosCM.Colonia = datard.GetString(posColonia);
                            obeLugaresEntregasPagosCM.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeLugaresEntregasPagosCM.IdMunicipio = datard.GetString(posIdMunicipio);
                            obeLugaresEntregasPagosCM.Telefono = datard.GetString(posTelefono);
                            obeLugaresEntregasPagosCM.LocalizacionGoogle = datard.GetString(posLocalizacionGoogle);
                            obeLugaresEntregasPagosCM.IdTipoLugarCM = datard.GetInt32(posIdTipoLugarCM);
                            obeLugaresEntregasPagosCM.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeLugaresEntregasPagosCM.FechaRegistro = datard.GetDateTime(posFechaRegistro);

                            obeLugaresEntregasPagosCM.Dependencia = datard.GetString(posDependencia);
                            obeLugaresEntregasPagosCM.Municipio = datard.GetString(posMunicipio);
                            obeLugaresEntregasPagosCM.ClaveEstado = datard.GetString(posClaveEstado);
                            obeLugaresEntregasPagosCM.Estado = datard.GetString(posEstado);
                            obeLugaresEntregasPagosCM.TipoLugar = datard.GetString(posTipoLugar);

                            lbeLugaresEntregasPagosCM.Add(obeLugaresEntregasPagosCM);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregasPagosCM;
            }
        }
    }
}
