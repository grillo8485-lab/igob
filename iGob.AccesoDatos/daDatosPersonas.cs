using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daDatosPersonas
    {
        public int guardarDatosPersonas(SqlConnection Conexion, beDatosPersonas obeDatosPersonas)
        {
            int Id = 0;
            string sp = "Proc_DatosPersonasInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = obeDatosPersonas.IdPersona;
                    cmd.Parameters.Add("@Apellidos", SqlDbType.NVarChar).Value = obeDatosPersonas.Apellidos;
                    cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar).Value = obeDatosPersonas.Nombres;
                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = obeDatosPersonas.FechaNacimiento;
                    cmd.Parameters.Add("@Sexo", SqlDbType.NChar).Value = obeDatosPersonas.Sexo;
                    cmd.Parameters.Add("@EntFedNacimiento", SqlDbType.NChar).Value = obeDatosPersonas.EntFedNacimiento;
                    cmd.Parameters.Add("@Curp", SqlDbType.NChar).Value = obeDatosPersonas.Curp;
                    cmd.Parameters.Add("@Rfc", SqlDbType.NChar).Value = obeDatosPersonas.Rfc;
                    cmd.Parameters.Add("@Telefono", SqlDbType.NChar).Value = obeDatosPersonas.Telefono;
                    cmd.Parameters.Add("@Celular", SqlDbType.NChar).Value = obeDatosPersonas.Celular;
                    cmd.Parameters.Add("@CorreoElectronico", SqlDbType.NChar).Value = obeDatosPersonas.CorreoElectronico;
                    cmd.Parameters.Add("@Calle", SqlDbType.NChar).Value = obeDatosPersonas.Calle;
                    cmd.Parameters.Add("@NoExterior", SqlDbType.NChar).Value = obeDatosPersonas.NoExterior;
                    cmd.Parameters.Add("@NoInterior", SqlDbType.NChar).Value = obeDatosPersonas.NoInterior;
                    cmd.Parameters.Add("@Localidad", SqlDbType.NVarChar).Value = obeDatosPersonas.Localidad;
                    cmd.Parameters.Add("@IdColonia", SqlDbType.Char).Value = obeDatosPersonas.IdColonia;
                    cmd.Parameters.Add("@CodigoPostal", SqlDbType.NChar).Value = obeDatosPersonas.CodigoPostal;
                    cmd.Parameters.Add("@EstadoCivil", SqlDbType.Char).Value = obeDatosPersonas.EstadoCivil;
                    cmd.Parameters.Add("@Nacionalidad", SqlDbType.NChar).Value = obeDatosPersonas.Nacionalidad;
                    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeDatosPersonas.IdDependencia;
                    cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeDatosPersonas.IdProveedor;
                    cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeDatosPersonas.IdEstatus;
                    cmd.Parameters.Add("@IdTipoPersona", SqlDbType.Int).Value = obeDatosPersonas.IdTipoPersona;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeDatosPersonas.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeDatosPersonas.FechaRegistro;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarDatosPersonas(SqlConnection Conexion, beDatosPersonas obeDatosPersonas)
        {
            string sp = "Proc_DatosPersonasActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = obeDatosPersonas.IdPersona;
                    cmd.Parameters.Add("@Apellidos", SqlDbType.NVarChar).Value = obeDatosPersonas.Apellidos;
                    cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar).Value = obeDatosPersonas.Nombres;
                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = obeDatosPersonas.FechaNacimiento;
                    cmd.Parameters.Add("@Sexo", SqlDbType.NChar).Value = obeDatosPersonas.Sexo;
                    cmd.Parameters.Add("@EntFedNacimiento", SqlDbType.NChar).Value = obeDatosPersonas.EntFedNacimiento;
                    cmd.Parameters.Add("@Curp", SqlDbType.NChar).Value = obeDatosPersonas.Curp;
                    cmd.Parameters.Add("@Rfc", SqlDbType.NChar).Value = obeDatosPersonas.Rfc;
                    cmd.Parameters.Add("@Telefono", SqlDbType.NChar).Value = obeDatosPersonas.Telefono;
                    cmd.Parameters.Add("@Celular", SqlDbType.NChar).Value = obeDatosPersonas.Celular;
                    cmd.Parameters.Add("@CorreoElectronico", SqlDbType.NChar).Value = obeDatosPersonas.CorreoElectronico;
                    cmd.Parameters.Add("@Calle", SqlDbType.NChar).Value = obeDatosPersonas.Calle;
                    cmd.Parameters.Add("@NoExterior", SqlDbType.NChar).Value = obeDatosPersonas.NoExterior;
                    cmd.Parameters.Add("@NoInterior", SqlDbType.NChar).Value = obeDatosPersonas.NoInterior;
                    cmd.Parameters.Add("@Localidad", SqlDbType.NVarChar).Value = obeDatosPersonas.Localidad;
                    cmd.Parameters.Add("@IdColonia", SqlDbType.Char).Value = obeDatosPersonas.IdColonia;
                    cmd.Parameters.Add("@CodigoPostal", SqlDbType.NChar).Value = obeDatosPersonas.CodigoPostal;
                    cmd.Parameters.Add("@EstadoCivil", SqlDbType.Char).Value = obeDatosPersonas.EstadoCivil;
                    cmd.Parameters.Add("@Nacionalidad", SqlDbType.NChar).Value = obeDatosPersonas.Nacionalidad;
                    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeDatosPersonas.IdDependencia;
                    cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeDatosPersonas.IdProveedor;
                    cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeDatosPersonas.IdEstatus;
                    cmd.Parameters.Add("@IdTipoPersona", SqlDbType.Int).Value = obeDatosPersonas.IdTipoPersona;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeDatosPersonas.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeDatosPersonas.FechaRegistro;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarDatosPersonas(SqlConnection Conexion, int pIdPersona)
        {
            string sp = "Proc_DatosPersonasEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = pIdPersona;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beDatosPersonas traerDatosPersonas_x_IdPersona(SqlConnection Conexion, int IdPersona)
        {
            string sp = "Proc_DatosPersonas_x_IdPersona";
            beDatosPersonas obeDatosPersonas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = IdPersona;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPersona = datard.GetOrdinal("IdPersona");
                        int posApellidos = datard.GetOrdinal("Apellidos");
                        int posNombres = datard.GetOrdinal("Nombres");
                        int posFechaNacimiento = datard.GetOrdinal("FechaNacimiento");
                        int posSexo = datard.GetOrdinal("Sexo");
                        int posEntFedNacimiento = datard.GetOrdinal("EntFedNacimiento");
                        int posCurp = datard.GetOrdinal("Curp");
                        int posRfc = datard.GetOrdinal("Rfc");
                        int posTelefono = datard.GetOrdinal("Telefono");
                        int posCelular = datard.GetOrdinal("Celular");
                        int posCorreoElectronico = datard.GetOrdinal("CorreoElectronico");
                        int posCalle = datard.GetOrdinal("Calle");
                        int posNoExterior = datard.GetOrdinal("NoExterior");
                        int posNoInterior = datard.GetOrdinal("NoInterior");
                        int posLocalidad = datard.GetOrdinal("Localidad");
                        int posIdColonia = datard.GetOrdinal("IdColonia");
                        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int posEstadoCivil = datard.GetOrdinal("EstadoCivil");
                        int posNacionalidad = datard.GetOrdinal("Nacionalidad");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdTipoPersona = datard.GetOrdinal("IdTipoPersona");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        obeDatosPersonas = new beDatosPersonas();
                        while (datard.Read())
                        {
                            obeDatosPersonas.IdPersona = datard.GetInt32(posIdPersona);
                            obeDatosPersonas.Apellidos = datard.GetString(posApellidos);
                            obeDatosPersonas.Nombres = datard.GetString(posNombres);
                            obeDatosPersonas.FechaNacimiento = datard.GetDateTime(posFechaNacimiento);
                            obeDatosPersonas.Sexo = datard.GetString(posSexo);
                            obeDatosPersonas.EntFedNacimiento = datard.GetString(posEntFedNacimiento);
                            obeDatosPersonas.Curp = datard.GetString(posCurp);
                            obeDatosPersonas.Rfc = datard.GetString(posRfc);
                            obeDatosPersonas.Telefono = datard.GetString(posTelefono);
                            obeDatosPersonas.Celular = datard.GetString(posCelular);
                            obeDatosPersonas.CorreoElectronico = datard.GetString(posCorreoElectronico);
                            obeDatosPersonas.Calle = datard.GetString(posCalle);
                            obeDatosPersonas.NoExterior = datard.GetString(posNoExterior);
                            obeDatosPersonas.NoInterior = datard.GetString(posNoInterior);
                            obeDatosPersonas.Localidad = datard.GetString(posLocalidad);
                            obeDatosPersonas.IdColonia = datard.GetString(posIdColonia);
                            obeDatosPersonas.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeDatosPersonas.EstadoCivil = datard.GetString(posEstadoCivil);
                            obeDatosPersonas.Nacionalidad = datard.GetString(posNacionalidad);
                            obeDatosPersonas.IdDependencia = datard[posIdDependencia] == DBNull.Value ? 0 : datard.GetInt32(posIdDependencia);
                            obeDatosPersonas.IdProveedor = datard[posIdProveedor] == DBNull.Value ? 0 : datard.GetInt32(posIdProveedor);
                            obeDatosPersonas.IdEstatus = datard[posIdEstatus] == DBNull.Value ? 0 : datard.GetInt32(posIdEstatus);
                            obeDatosPersonas.IdTipoPersona = datard.GetInt32(posIdTipoPersona);
                            obeDatosPersonas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeDatosPersonas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeDatosPersonas;
            }
        }
        public List<beDatosPersonas> listarTodos_DatosPersonas(SqlConnection Conexion)
        {
            string sp = "Proc_DatosPersonas_Traer_Todos";
            List<beDatosPersonas> lbeDatosPersonas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPersona = datard.GetOrdinal("IdPersona");
                        int posApellidos = datard.GetOrdinal("Apellidos");
                        int posNombres = datard.GetOrdinal("Nombres");
                        int posFechaNacimiento = datard.GetOrdinal("FechaNacimiento");
                        int posSexo = datard.GetOrdinal("Sexo");
                        int posEntFedNacimiento = datard.GetOrdinal("EntFedNacimiento");
                        int posCurp = datard.GetOrdinal("Curp");
                        int posRfc = datard.GetOrdinal("Rfc");
                        int posTelefono = datard.GetOrdinal("Telefono");
                        int posCelular = datard.GetOrdinal("Celular");
                        int posCorreoElectronico = datard.GetOrdinal("CorreoElectronico");
                        int posCalle = datard.GetOrdinal("Calle");
                        int posNoExterior = datard.GetOrdinal("NoExterior");
                        int posNoInterior = datard.GetOrdinal("NoInterior");
                        int posLocalidad = datard.GetOrdinal("Localidad");
                        int posIdColonia = datard.GetOrdinal("IdColonia");
                        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int posEstadoCivil = datard.GetOrdinal("EstadoCivil");
                        int posNacionalidad = datard.GetOrdinal("Nacionalidad");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdTipoPersona = datard.GetOrdinal("IdTipoPersona");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeDatosPersonas = new List<beDatosPersonas>();
                        beDatosPersonas obeDatosPersonas;
                        while (datard.Read())
                        {
                            obeDatosPersonas = new beDatosPersonas();
                            obeDatosPersonas.IdPersona = datard.GetInt32(posIdPersona);
                            obeDatosPersonas.Apellidos = datard.GetString(posApellidos);
                            obeDatosPersonas.Nombres = datard.GetString(posNombres);
                            obeDatosPersonas.FechaNacimiento = datard.GetDateTime(posFechaNacimiento);
                            obeDatosPersonas.Sexo = datard.GetString(posSexo);
                            obeDatosPersonas.EntFedNacimiento = datard.GetString(posEntFedNacimiento);
                            obeDatosPersonas.Curp = datard.GetString(posCurp);
                            obeDatosPersonas.Rfc = datard.GetString(posRfc);
                            obeDatosPersonas.Telefono = datard.GetString(posTelefono);
                            obeDatosPersonas.Celular = datard.GetString(posCelular);
                            obeDatosPersonas.CorreoElectronico = datard.GetString(posCorreoElectronico);
                            obeDatosPersonas.Calle = datard.GetString(posCalle);
                            obeDatosPersonas.NoExterior = datard.GetString(posNoExterior);
                            obeDatosPersonas.NoInterior = datard.GetString(posNoInterior);
                            obeDatosPersonas.Localidad = datard.GetString(posLocalidad);
                            obeDatosPersonas.IdColonia = datard.GetString(posIdColonia);
                            obeDatosPersonas.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeDatosPersonas.EstadoCivil = datard.GetString(posEstadoCivil);
                            obeDatosPersonas.Nacionalidad = datard.GetString(posNacionalidad);
                            obeDatosPersonas.IdDependencia = datard[posIdDependencia] == DBNull.Value ? 0 : datard.GetInt32(posIdDependencia);
                            obeDatosPersonas.IdProveedor = datard[posIdProveedor] == DBNull.Value ? 0 : datard.GetInt32(posIdProveedor);
                            obeDatosPersonas.IdEstatus = datard[posIdEstatus] == DBNull.Value ? 0 : datard.GetInt32(posIdEstatus);
                            obeDatosPersonas.IdTipoPersona = datard.GetInt32(posIdTipoPersona);
                            obeDatosPersonas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeDatosPersonas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            lbeDatosPersonas.Add(obeDatosPersonas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeDatosPersonas;
            }
        }
        public List<beDatosPersonas> listar_DatosPersonas_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_DatosPersonas_TraerTodos_GetAll";
            List<beDatosPersonas> lbeDatosPersonas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPersona = datard.GetOrdinal("IdPersona");
                        int posApellidos = datard.GetOrdinal("Apellidos");
                        int posNombres = datard.GetOrdinal("Nombres");
                        int posFechaNacimiento = datard.GetOrdinal("FechaNacimiento");
                        int posSexo = datard.GetOrdinal("Sexo");
                        int posEntFedNacimiento = datard.GetOrdinal("EntFedNacimiento");
                        int posCurp = datard.GetOrdinal("Curp");
                        int posRfc = datard.GetOrdinal("Rfc");
                        int posTelefono = datard.GetOrdinal("Telefono");
                        int posCelular = datard.GetOrdinal("Celular");
                        int posCorreoElectronico = datard.GetOrdinal("CorreoElectronico");
                        int posCalle = datard.GetOrdinal("Calle");
                        int posNoExterior = datard.GetOrdinal("NoExterior");
                        int posNoInterior = datard.GetOrdinal("NoInterior");
                        int posLocalidad = datard.GetOrdinal("Localidad");
                        int posIdColonia = datard.GetOrdinal("IdColonia");
                        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int posEstadoCivil = datard.GetOrdinal("EstadoCivil");
                        int posNacionalidad = datard.GetOrdinal("Nacionalidad");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdTipoPersona = datard.GetOrdinal("IdTipoPersona");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeDatosPersonas = new List<beDatosPersonas>();
                        beDatosPersonas obeDatosPersonas;
                        while (datard.Read())
                        {
                            obeDatosPersonas = new beDatosPersonas();
                            obeDatosPersonas.IdPersona = datard.GetInt32(posIdPersona);
                            obeDatosPersonas.Apellidos = datard.GetString(posApellidos);
                            obeDatosPersonas.Nombres = datard.GetString(posNombres);
                            obeDatosPersonas.FechaNacimiento = datard.GetDateTime(posFechaNacimiento);
                            obeDatosPersonas.Sexo = datard.GetString(posSexo);
                            obeDatosPersonas.EntFedNacimiento = datard.GetString(posEntFedNacimiento);
                            obeDatosPersonas.Curp = datard.GetString(posCurp);
                            obeDatosPersonas.Rfc = datard.GetString(posRfc);
                            obeDatosPersonas.Telefono = datard.GetString(posTelefono);
                            obeDatosPersonas.Celular = datard.GetString(posCelular);
                            obeDatosPersonas.CorreoElectronico = datard.GetString(posCorreoElectronico);
                            obeDatosPersonas.Calle = datard.GetString(posCalle);
                            obeDatosPersonas.NoExterior = datard.GetString(posNoExterior);
                            obeDatosPersonas.NoInterior = datard.GetString(posNoInterior);
                            obeDatosPersonas.Localidad = datard.GetString(posLocalidad);
                            obeDatosPersonas.IdColonia = datard.GetString(posIdColonia);
                            obeDatosPersonas.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeDatosPersonas.EstadoCivil = datard.GetString(posEstadoCivil);
                            obeDatosPersonas.Nacionalidad = datard.GetString(posNacionalidad);
                            obeDatosPersonas.IdDependencia = datard[posIdDependencia] == DBNull.Value ? 0 : datard.GetInt32(posIdDependencia);
                            obeDatosPersonas.IdProveedor = datard[posIdProveedor] == DBNull.Value ? 0 : datard.GetInt32(posIdProveedor);
                            obeDatosPersonas.IdEstatus = datard[posIdEstatus] == DBNull.Value ? 0 : datard.GetInt32(posIdEstatus);
                            obeDatosPersonas.IdTipoPersona = datard.GetInt32(posIdTipoPersona);
                            obeDatosPersonas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeDatosPersonas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            // debe agregar campos de la Vista
                            lbeDatosPersonas.Add(obeDatosPersonas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeDatosPersonas;
            }
        }

        public List<beDatosPersonas> listarTodos_DatosPersonas_x_RfcNombreCompleto(SqlConnection Conexion, string rfcNombreCompleto)
        {
            string sp = "Proc_DatosPersonas_x_RFCNombreCompleto";
            List<beDatosPersonas> lbeDatosPersonas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RfcNombreCompleto", SqlDbType.NVarChar).Value = rfcNombreCompleto;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeDatosPersonas = new List<beDatosPersonas>();
                        beDatosPersonas obeDatosPersonas;
                        int posIdPersona = datard.GetOrdinal("IdPersona");
                        int posApellidos = datard.GetOrdinal("Apellidos");
                        int posNombres = datard.GetOrdinal("Nombres");
                        int posFechaNacimiento = datard.GetOrdinal("FechaNacimiento");
                        int posSexo = datard.GetOrdinal("Sexo");
                        int posEntFedNacimiento = datard.GetOrdinal("EntFedNacimiento");
                        int posCurp = datard.GetOrdinal("Curp");
                        int posRfc = datard.GetOrdinal("Rfc");
                        int posTelefono = datard.GetOrdinal("Telefono");
                        int posCelular = datard.GetOrdinal("Celular");
                        int posCorreoElectronico = datard.GetOrdinal("CorreoElectronico");
                        int posCalle = datard.GetOrdinal("Calle");
                        int posNoExterior = datard.GetOrdinal("NoExterior");
                        int posNoInterior = datard.GetOrdinal("NoInterior");
                        int posLocalidad = datard.GetOrdinal("Localidad");
                        int posIdColonia = datard.GetOrdinal("IdColonia");
                        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int posEstadoCivil = datard.GetOrdinal("EstadoCivil");
                        int posNacionalidad = datard.GetOrdinal("Nacionalidad");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdTipoPersona = datard.GetOrdinal("IdTipoPersona");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeDatosPersonas = new List<beDatosPersonas>();

                        while (datard.Read())
                        {
                            obeDatosPersonas = new beDatosPersonas();
                            obeDatosPersonas.IdPersona = datard.GetInt32(posIdPersona);
                            obeDatosPersonas.Apellidos = datard.GetString(posApellidos);
                            obeDatosPersonas.Nombres = datard.GetString(posNombres);
                            obeDatosPersonas.FechaNacimiento = datard.GetDateTime(posFechaNacimiento);
                            obeDatosPersonas.Sexo = datard.GetString(posSexo);
                            obeDatosPersonas.EntFedNacimiento = datard.GetString(posEntFedNacimiento);
                            obeDatosPersonas.Curp = datard.GetString(posCurp);
                            obeDatosPersonas.Rfc = datard.GetString(posRfc);
                            obeDatosPersonas.Telefono = datard.GetString(posTelefono);
                            obeDatosPersonas.Celular = datard.GetString(posCelular);
                            obeDatosPersonas.CorreoElectronico = datard.GetString(posCorreoElectronico);
                            obeDatosPersonas.Calle = datard.GetString(posCalle);
                            obeDatosPersonas.NoExterior = datard.GetString(posNoExterior);
                            obeDatosPersonas.NoInterior = datard.GetString(posNoInterior);
                            obeDatosPersonas.Localidad = datard.GetString(posLocalidad);
                            obeDatosPersonas.IdColonia = datard.GetString(posIdColonia);
                            obeDatosPersonas.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeDatosPersonas.EstadoCivil = datard.GetString(posEstadoCivil);
                            obeDatosPersonas.Nacionalidad = datard.GetString(posNacionalidad);
                            obeDatosPersonas.IdDependencia = datard[posIdDependencia] == DBNull.Value ? 0 : datard.GetInt32(posIdDependencia);
                            obeDatosPersonas.IdProveedor = datard[posIdProveedor] == DBNull.Value ? 0 : datard.GetInt32(posIdProveedor);
                            obeDatosPersonas.IdEstatus = datard[posIdEstatus] == DBNull.Value ? 0 : datard.GetInt32(posIdEstatus);
                            obeDatosPersonas.IdTipoPersona = datard.GetInt32(posIdTipoPersona);
                            obeDatosPersonas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeDatosPersonas.FechaRegistro = datard.GetDateTime(posFechaRegistro);

                            lbeDatosPersonas.Add(obeDatosPersonas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeDatosPersonas;
            }
        }
    }
}
