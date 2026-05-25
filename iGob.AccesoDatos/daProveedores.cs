using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daProveedores
    {
        public int guardarProveedores(SqlConnection Conexion, beProveedores obeProveedores)
        {
            int Id = 0;
            string sp = "Proc_ProveedoresInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeProveedores.IdProveedor;
                    cmd.Parameters.Add("@RazonSocial", SqlDbType.NVarChar).Value = obeProveedores.RazonSocial;
                    cmd.Parameters.Add("@NombreComercial", SqlDbType.NVarChar).Value = obeProveedores.NombreComercial;
                    cmd.Parameters.Add("@TipoPersona", SqlDbType.Int).Value = obeProveedores.TipoPersona;
                    cmd.Parameters.Add("@Rfc", SqlDbType.NVarChar).Value = obeProveedores.Rfc;
                    cmd.Parameters.Add("@Curp", SqlDbType.NVarChar).Value = obeProveedores.Curp;
                    cmd.Parameters.Add("@Calle", SqlDbType.NVarChar).Value = obeProveedores.Calle;
                    cmd.Parameters.Add("@NoExterior", SqlDbType.Char).Value = obeProveedores.NoExterior;
                    cmd.Parameters.Add("@NoInterior", SqlDbType.Char).Value = obeProveedores.NoInterior == null ? "0" : obeProveedores.NoInterior;
                    cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeProveedores.IdMunicipio;
                    cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = obeProveedores.Colonia;
                    cmd.Parameters.Add("@CodigoPostal", SqlDbType.Char).Value = obeProveedores.CodigoPostal;
                    cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = obeProveedores.Telefono;
                    cmd.Parameters.Add("@NombreContacto", SqlDbType.NVarChar).Value = obeProveedores.NombreContacto;
                    cmd.Parameters.Add("@CelularContacto", SqlDbType.NVarChar).Value = obeProveedores.CelularContacto;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = obeProveedores.Email;
                    cmd.Parameters.Add("@Sitiooficial", SqlDbType.NVarChar).Value = obeProveedores.Sitiooficial;
                    cmd.Parameters.Add("@TipoProveedor", SqlDbType.Int).Value = obeProveedores.TipoProveedor;
                    cmd.Parameters.Add("@IdBanco", SqlDbType.Int).Value = obeProveedores.IdBanco;
                    cmd.Parameters.Add("@Cuenta", SqlDbType.NVarChar).Value = obeProveedores.Cuenta;
                    cmd.Parameters.Add("@Titular", SqlDbType.NVarChar).Value = obeProveedores.Titular;
                    cmd.Parameters.Add("@CLABE", SqlDbType.NVarChar).Value = obeProveedores.CLABE;
                    cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeProveedores.IdGobierno;
                    cmd.Parameters.Add("@EstatusProveedor", SqlDbType.Int).Value = obeProveedores.EstatusProveedor;

                    Id = (int)cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarProveedores(SqlConnection Conexion, beProveedores obeProveedores)
        {
            string sp = "Proc_ProveedoresActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeProveedores.IdProveedor;
                    cmd.Parameters.Add("@RazonSocial", SqlDbType.NVarChar).Value = obeProveedores.RazonSocial;
                    cmd.Parameters.Add("@NombreComercial", SqlDbType.NVarChar).Value = obeProveedores.NombreComercial;
                    cmd.Parameters.Add("@TipoPersona", SqlDbType.Int).Value = obeProveedores.TipoPersona;
                    cmd.Parameters.Add("@Rfc", SqlDbType.NVarChar).Value = obeProveedores.Rfc;
                    cmd.Parameters.Add("@Curp", SqlDbType.NVarChar).Value = obeProveedores.Curp;
                    cmd.Parameters.Add("@Calle", SqlDbType.NVarChar).Value = obeProveedores.Calle;
                    cmd.Parameters.Add("@NoExterior", SqlDbType.Char).Value = obeProveedores.NoExterior;
                    cmd.Parameters.Add("@NoInterior", SqlDbType.Char).Value = obeProveedores.NoInterior;
                    cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeProveedores.IdMunicipio;
                    cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = obeProveedores.Colonia;
                    cmd.Parameters.Add("@CodigoPostal", SqlDbType.Char).Value = obeProveedores.CodigoPostal;
                    cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = obeProveedores.Telefono;
                    cmd.Parameters.Add("@NombreContacto", SqlDbType.NVarChar).Value = obeProveedores.NombreContacto;
                    cmd.Parameters.Add("@CelularContacto", SqlDbType.NVarChar).Value = obeProveedores.CelularContacto;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = obeProveedores.Email;
                    cmd.Parameters.Add("@Sitiooficial", SqlDbType.NVarChar).Value = obeProveedores.Sitiooficial;
                    cmd.Parameters.Add("@TipoProveedor", SqlDbType.Int).Value = obeProveedores.TipoProveedor;
                    cmd.Parameters.Add("@IdBanco", SqlDbType.Int).Value = obeProveedores.IdBanco;
                    cmd.Parameters.Add("@Cuenta", SqlDbType.NVarChar).Value = obeProveedores.Cuenta;
                    cmd.Parameters.Add("@Titular", SqlDbType.NVarChar).Value = obeProveedores.Titular;
                    cmd.Parameters.Add("@CLABE", SqlDbType.NVarChar).Value = obeProveedores.CLABE;
                    cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeProveedores.IdGobierno;
                    cmd.Parameters.Add("@EstatusProveedor", SqlDbType.Int).Value = obeProveedores.EstatusProveedor;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarProveedores(SqlConnection Conexion, int pIdProveedor)
        {
            string sp = "Proc_ProveedoresEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = pIdProveedor;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beProveedores traerProveedores_x_IdProveedor(SqlConnection Conexion, int IdProveedor)
        {
            string sp = "Proc_Proveedores_x_IdProveedor";
            List<beProveedores> lbeProveedores = null;
            beProveedores obeProveedores = new beProveedores();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeProveedores = new List<beProveedores>();
                        while (datard.Read())
                        {
                            obeProveedores = new beProveedores();
                            obeProveedores.IdProveedor = datard.GetInt32(0);
                            obeProveedores.RazonSocial = datard.GetString(1);
                            obeProveedores.NombreComercial = datard.GetString(2);
                            obeProveedores.TipoPersona = datard.GetInt32(3);
                            obeProveedores.Rfc = datard.GetString(4);
                            obeProveedores.Curp = datard.GetString(5);
                            obeProveedores.Calle = datard.GetString(6);
                            obeProveedores.NoExterior = datard.GetString(7);
                            obeProveedores.NoInterior = datard.GetString(8);
                            obeProveedores.IdMunicipio = datard.GetString(9);
                            obeProveedores.Colonia = datard.GetString(10);
                            obeProveedores.CodigoPostal = datard.GetString(11);
                            obeProveedores.Telefono = datard.GetString(12);
                            obeProveedores.NombreContacto = datard.GetString(13);
                            obeProveedores.CelularContacto = datard.GetString(14);
                            obeProveedores.Email = datard.GetString(15);
                            obeProveedores.Sitiooficial = datard.GetString(16);
                            obeProveedores.TipoProveedor = datard.GetInt32(17);
                            obeProveedores.IdBanco = datard.GetInt32(18);
                            obeProveedores.Cuenta = datard.GetString(19);
                            obeProveedores.Titular = datard.GetString(20);
                            obeProveedores.CLABE = datard.GetString(21);
                            obeProveedores.IdGobierno = datard.GetInt32(22);
                            obeProveedores.EstatusProveedor = datard.GetInt32(23);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeProveedores;
            }
        }
        public List<beProveedores> listarTodos_Proveedores(SqlConnection Conexion)
        {
            string sp = "Proc_Proveedores_Traer_Todos";
            List<beProveedores> lbeProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeProveedores = new List<beProveedores>();
                        beProveedores obeProveedores;
                        while (datard.Read())
                        {
                            obeProveedores = new beProveedores();
                            obeProveedores.IdProveedor = datard.GetInt32(0);
                            obeProveedores.RazonSocial = datard.GetString(1);
                            obeProveedores.NombreComercial = datard.GetString(2);
                            obeProveedores.TipoPersona = datard.GetInt32(3);
                            obeProveedores.Rfc = datard.GetString(4);
                            obeProveedores.Curp = datard.GetString(5);
                            obeProveedores.Calle = datard.GetString(6);
                            obeProveedores.NoExterior = datard.GetString(7);
                            obeProveedores.NoInterior = datard.GetString(8);
                            obeProveedores.IdMunicipio = datard.GetString(9);
                            obeProveedores.Colonia = datard.GetString(10);
                            obeProveedores.CodigoPostal = datard.GetString(11);
                            obeProveedores.Telefono = datard.GetString(12);
                            obeProveedores.NombreContacto = datard.GetString(13);
                            obeProveedores.CelularContacto = datard.GetString(14);
                            obeProveedores.Email = datard.GetString(15);
                            obeProveedores.Sitiooficial = datard.GetString(16);
                            obeProveedores.TipoProveedor = datard.GetInt32(17);
                            obeProveedores.IdBanco = datard.GetInt32(18);
                            obeProveedores.Cuenta = datard.GetString(19);
                            obeProveedores.Titular = datard.GetString(20);
                            obeProveedores.CLABE = datard.GetString(21);
                            obeProveedores.IdGobierno = datard.GetInt32(22);
                            obeProveedores.EstatusProveedor = datard.GetInt32(23);
                            lbeProveedores.Add(obeProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeProveedores;
            }
        }
        public DataTable listarProveedores_x_(SqlConnection Conexion, int IdProveedor)
        {
            string sp = "Proc_Proveedores_Traer_Todos";
            DataTable dtProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        dtProveedores = new DataTable();
                        dtProveedores.Load(datard);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dtProveedores;
            }
        }
        /* Get All 28/08/2018 */
        public List<beProveedores> listarTodos_Proveedores_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_Proveedores_TraerTodos_GetAll";
            List<beProveedores> lbeProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeProveedores = new List<beProveedores>();
                        beProveedores obeProveedores;
                        while (datard.Read())
                        {
                            obeProveedores = new beProveedores();
                            obeProveedores.IdProveedor = datard.GetInt32(0);
                            obeProveedores.RazonSocial = datard.GetString(1);
                            obeProveedores.NombreComercial = datard.GetString(2);
                            obeProveedores.TipoPersona = datard.GetInt32(3);
                            obeProveedores.Rfc = datard.GetString(4);
                            obeProveedores.Curp = datard.GetString(5);
                            obeProveedores.Calle = datard.GetString(6);
                            obeProveedores.NoExterior = datard.GetString(7);
                            obeProveedores.NoInterior = datard.GetString(8);
                            obeProveedores.IdMunicipio = datard.GetString(9);
                            obeProveedores.Colonia = datard.GetString(10);
                            obeProveedores.CodigoPostal = datard.GetString(11);
                            obeProveedores.Telefono = datard.GetString(12);
                            obeProveedores.NombreContacto = datard.GetString(13);
                            obeProveedores.CelularContacto = datard.GetString(14);
                            obeProveedores.Email = datard.GetString(15);
                            obeProveedores.Sitiooficial = datard.GetString(16);
                            obeProveedores.TipoProveedor = datard.GetInt32(17);
                            obeProveedores.IdBanco = datard.GetInt32(18);
                            obeProveedores.Cuenta = datard.GetString(19);
                            obeProveedores.Titular = datard.GetString(20);
                            obeProveedores.CLABE = datard.GetString(21);
                            obeProveedores.IdGobierno = datard.GetInt32(22);
                            //obeProveedores.EstatusProveedor = datard.GetInt32(23);

                            obeProveedores.Municipio = datard.GetString(23);
                            obeProveedores.ClaveEstado = datard.GetString(24);
                            obeProveedores.Estado = datard.GetString(25);
                            obeProveedores.Gobierno = datard.GetString(26);
                            lbeProveedores.Add(obeProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeProveedores;
            }
        }
        /* Compras menores 28/08/2018 */
        public List<beProveedores> listarTodos_Proveedores_CM(SqlConnection Conexion)
        {
            string sp = "Proc_Proveedores_ComprasMenores_GetAll";
            List<beProveedores> lbeProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeProveedores = new List<beProveedores>();
                        beProveedores obeProveedores;
                        while (datard.Read())
                        {
                            obeProveedores = new beProveedores();
                            obeProveedores.IdProveedor = datard.GetInt32(0);
                            obeProveedores.RazonSocial = datard.GetString(1);
                            obeProveedores.NombreComercial = datard.GetString(2);
                            obeProveedores.TipoPersona = datard.GetInt32(3);
                            obeProveedores.Rfc = datard.GetString(4);
                            obeProveedores.Curp = datard.GetString(5);
                            obeProveedores.Calle = datard.GetString(6);
                            obeProveedores.NoExterior = datard.GetString(7);
                            obeProveedores.NoInterior = datard.GetString(8);
                            obeProveedores.IdMunicipio = datard.GetString(9);
                            obeProveedores.Colonia = datard.GetString(10);
                            obeProveedores.CodigoPostal = datard.GetString(11);
                            obeProveedores.Telefono = datard.GetString(12);
                            obeProveedores.NombreContacto = datard.GetString(13);
                            obeProveedores.CelularContacto = datard.GetString(14);
                            obeProveedores.Email = datard.GetString(15);
                            obeProveedores.Sitiooficial = datard.GetString(16);
                            obeProveedores.TipoProveedor = datard.GetInt32(17);
                            obeProveedores.IdBanco = datard.GetInt32(18);
                            obeProveedores.Cuenta = datard.GetString(19);
                            obeProveedores.Titular = datard.GetString(20);
                            obeProveedores.CLABE = datard.GetString(21);
                            obeProveedores.IdGobierno = datard.GetInt32(22);
                            obeProveedores.EstatusProveedor = datard.GetInt32(23);

                            obeProveedores.Municipio = datard.GetString(24);
                            obeProveedores.ClaveEstado = datard.GetString(25);
                            obeProveedores.Estado = datard.GetString(26);
                            obeProveedores.Gobierno = datard.GetString(27);
                            lbeProveedores.Add(obeProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeProveedores;
            }
        }

        public List<beProveedores> getAllProveedores_x_IdAdjudicacion(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_ProveedoresPartidas_x_IdAdjudicacion";
            List<beProveedores> lbeProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeProveedores = new List<beProveedores>();
                        beProveedores obeProveedores;
                        while (datard.Read())
                        {
                            obeProveedores = new beProveedores();
                            obeProveedores.IdAdjudicacion = datard.GetInt32(0);
                            obeProveedores.IdAdjudicacionProveedor = datard.GetInt32(1);
                            obeProveedores.IdProveedor = datard.GetInt32(2);
                            obeProveedores.RazonSocial = datard.GetString(3);
                            obeProveedores.NombreComercial = datard.GetString(4);
                            obeProveedores.TipoPersona = datard.GetInt32(5);
                            obeProveedores.Rfc = datard.GetString(6);
                            obeProveedores.Curp = datard.GetString(7);
                            obeProveedores.Calle = datard.GetString(8);
                            obeProveedores.NoExterior = datard.GetString(9);
                            obeProveedores.NoInterior = datard.GetString(10);
                            obeProveedores.IdMunicipio = datard.GetString(11);
                            obeProveedores.Colonia = datard.GetString(12);
                            obeProveedores.CodigoPostal = datard.GetString(13);
                            obeProveedores.Telefono = datard.GetString(14);
                            obeProveedores.NombreContacto = datard.GetString(15);
                            obeProveedores.CelularContacto = datard.GetString(16);
                            obeProveedores.Email = datard.GetString(17);
                            obeProveedores.Seleccion = datard.GetInt32(18);
                            //obeProveedores.Sitiooficial = datard.GetString(16);
                            //obeProveedores.TipoProveedor = datard.GetInt32(17);
                            //obeProveedores.IdBanco = datard.GetInt32(18);
                            //obeProveedores.Cuenta = datard.GetString(19);
                            //obeProveedores.Titular = datard.GetString(20);
                            //obeProveedores.CLABE = datard.GetString(21);
                            //obeProveedores.IdGobierno = datard.GetInt32(22);
                            //obeProveedores.EstatusProveedor = datard.GetInt32(23);

                            //obeProveedores.Municipio = datard.GetString(24);
                            //obeProveedores.ClaveEstado = datard.GetString(25);
                            //obeProveedores.Estado = datard.GetString(26);
                            //obeProveedores.Gobierno = datard.GetString(27);
                            lbeProveedores.Add(obeProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeProveedores;
            }
        }

        public List<beProveedores> getAllProveedores_x_IdPartida(SqlConnection Conexion, int IdPartida)
        {
            string sp = "Proc_Proveedores_x_IdPartida";
            List<beProveedores> lbeProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = IdPartida;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeProveedores = new List<beProveedores>();
                        beProveedores obeProveedores;
                        while (datard.Read())
                        {
                            obeProveedores = new beProveedores();
                            obeProveedores.IdProveedor = datard.GetInt32(0);
                            obeProveedores.RazonSocial = datard.GetString(1);
                            obeProveedores.NombreComercial = datard.GetString(2);
                            obeProveedores.TipoPersona = datard.GetInt32(3);
                            obeProveedores.Rfc = datard.GetString(4);
                            obeProveedores.Curp = datard.GetString(5);
                            obeProveedores.Calle = datard.GetString(6);
                            obeProveedores.NoExterior = datard.GetString(7);
                            obeProveedores.NoInterior = datard.GetString(8);
                            obeProveedores.IdMunicipio = datard.GetString(9);
                            obeProveedores.Colonia = datard.GetString(10);
                            obeProveedores.CodigoPostal = datard.GetString(11);
                            obeProveedores.Telefono = datard.GetString(12);
                            obeProveedores.NombreContacto = datard.GetString(13);
                            obeProveedores.CelularContacto = datard.GetString(14);
                            obeProveedores.Email = datard.GetString(15);
                            //obeProveedores.Sitiooficial = datard.GetString(16);
                            //obeProveedores.TipoProveedor = datard.GetInt32(17);
                            //obeProveedores.IdBanco = datard.GetInt32(18);
                            //obeProveedores.Cuenta = datard.GetString(19);
                            //obeProveedores.Titular = datard.GetString(20);
                            //obeProveedores.CLABE = datard.GetString(21);
                            //obeProveedores.IdGobierno = datard.GetInt32(22);
                            //obeProveedores.EstatusProveedor = datard.GetInt32(23);

                            //obeProveedores.Municipio = datard.GetString(24);
                            //obeProveedores.ClaveEstado = datard.GetString(25);
                            //obeProveedores.Estado = datard.GetString(26);
                            //obeProveedores.Gobierno = datard.GetString(27);
                            lbeProveedores.Add(obeProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeProveedores;
            }
        }
        public List<beProveedores> getAllProveedores_x_IdRequisicion(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_RequisicionesProveedoresInvitacionRestringida_x_IdRequisicion";
            List<beProveedores> lbeProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeProveedores = new List<beProveedores>();
                        beProveedores obeProveedores;
                        while (datard.Read())
                        {
                            obeProveedores = new beProveedores();
                            obeProveedores.IdAdjudicacion = datard.GetInt32(datard.GetOrdinal("IdRequisicion"));
                            obeProveedores.IdAdjudicacionProveedor = datard.GetInt32(datard.GetOrdinal("IdRequisicionProveedorInvitacion"));
                            obeProveedores.IdProveedor = datard.GetInt32(datard.GetOrdinal("IdProveedor"));
                            obeProveedores.RazonSocial = datard.GetString(datard.GetOrdinal("RazonSocial"));
                            obeProveedores.NombreComercial = datard.GetString(datard.GetOrdinal("NombreComercial"));
                            obeProveedores.TipoPersona = datard.GetInt32(datard.GetOrdinal("TipoPersona"));
                            obeProveedores.Rfc = datard.GetString(datard.GetOrdinal("Rfc"));
                            obeProveedores.Curp = datard.GetString(datard.GetOrdinal("Curp"));
                            obeProveedores.Calle = datard.GetString(datard.GetOrdinal("Calle"));
                            obeProveedores.NoExterior = datard.GetString(datard.GetOrdinal("NoExterior"));
                            obeProveedores.NoInterior = datard.GetString(datard.GetOrdinal("NoInterior"));
                            obeProveedores.IdMunicipio = datard.GetString(datard.GetOrdinal("IdMunicipio"));
                            obeProveedores.Colonia = datard.GetString(datard.GetOrdinal("Colonia"));
                            obeProveedores.CodigoPostal = datard.GetString(datard.GetOrdinal("CodigoPostal"));
                            obeProveedores.Telefono = datard.GetString(datard.GetOrdinal("Telefono"));
                            obeProveedores.NombreContacto = datard.GetString(datard.GetOrdinal("NombreContacto"));
                            obeProveedores.CelularContacto = datard.GetString(datard.GetOrdinal("CelularContacto"));
                            obeProveedores.Email = datard.GetString(datard.GetOrdinal("Email"));
                            obeProveedores.Seleccion = datard.GetInt32(datard.GetOrdinal("Seleccion"));
                            //obeProveedores.Sitiooficial = datard.GetString(16);
                            //obeProveedores.TipoProveedor = datard.GetInt32(17);
                            //obeProveedores.IdBanco = datard.GetInt32(18);
                            //obeProveedores.Cuenta = datard.GetString(19);
                            //obeProveedores.Titular = datard.GetString(20);
                            //obeProveedores.CLABE = datard.GetString(21);
                            //obeProveedores.IdGobierno = datard.GetInt32(22);
                            //obeProveedores.EstatusProveedor = datard.GetInt32(23);

                            //obeProveedores.Municipio = datard.GetString(24);
                            //obeProveedores.ClaveEstado = datard.GetString(25);
                            //obeProveedores.Estado = datard.GetString(26);
                            //obeProveedores.Gobierno = datard.GetString(27);
                            lbeProveedores.Add(obeProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeProveedores;
            }
        }
    }
}
