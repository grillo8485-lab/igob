using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daCartas
    {
        public int guardarCartas(SqlConnection Conexion, beCartas obeCartas)
        {
            int Id = 0;
            string sp = "Proc_CartasInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCarta", SqlDbType.Int).Value = obeCartas.IdCarta;
                    cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = obeCartas.IdTipoSolicitud;
                    cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = obeCartas.Numero;
                    cmd.Parameters.Add("@Inciso", SqlDbType.Char).Value = obeCartas.Inciso;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = obeCartas.Nombre;
                    cmd.Parameters.Add("@Carta", SqlDbType.Text).Value = obeCartas.Carta;
                    cmd.Parameters.Add("@Solicitada", SqlDbType.Text).Value = obeCartas.Solicitada;
                    cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeCartas.IdEstatus;
                    cmd.Parameters.Add("@IdTipoCarta", SqlDbType.Int).Value = obeCartas.IdTipoCarta;
                    cmd.Parameters.Add("@Obligada", SqlDbType.Int).Value = obeCartas.Obligada;
                    cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeCartas.IdGobierno;//idGobierno
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeCartas.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeCartas.FechaRegistro;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarCartas(SqlConnection Conexion, beCartas obeCartas)
        {
            string sp = "Proc_CartasActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCarta", SqlDbType.Int).Value = obeCartas.IdCarta;
                    cmd.Parameters.Add("@IdTipoSolicitud", SqlDbType.Int).Value = obeCartas.IdTipoSolicitud;
                    cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = obeCartas.Numero;
                    cmd.Parameters.Add("@Inciso", SqlDbType.Char).Value = obeCartas.Inciso;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = obeCartas.Nombre;
                    cmd.Parameters.Add("@Carta", SqlDbType.Text).Value = obeCartas.Carta;
                    cmd.Parameters.Add("@Solicitada", SqlDbType.Text).Value = obeCartas.Solicitada;
                    cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeCartas.IdEstatus;
                    cmd.Parameters.Add("@IdTipoCarta", SqlDbType.Int).Value = obeCartas.IdTipoCarta;
                    cmd.Parameters.Add("@Obligada", SqlDbType.Int).Value = obeCartas.Obligada;
                    cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeCartas.IdGobierno;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeCartas.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeCartas.FechaRegistro;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarCartas(SqlConnection Conexion, int pIdCarta)
        {
            string sp = "Proc_CartasEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCarta", SqlDbType.Int).Value = pIdCarta;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beCartas traerCartas_x_IdCarta(SqlConnection Conexion, int IdCarta)
        {
            string sp = "Proc_Cartas_x_IdCarta";
            beCartas obeCartas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCarta", SqlDbType.Int).Value = IdCarta;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCarta = datard.GetOrdinal("IdCarta");
                        int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int posNumero = datard.GetOrdinal("Numero");
                        int posInciso = datard.GetOrdinal("Inciso");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCarta = datard.GetOrdinal("Carta");
                        int posSolicitada = datard.GetOrdinal("Solicitada");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdTipoCarta = datard.GetOrdinal("IdTipoCarta");
                        int posObligada = datard.GetOrdinal("Obligada");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        obeCartas = new beCartas();
                        while (datard.Read())
                        {
                            obeCartas = new beCartas();
                            obeCartas.IdCarta = datard.GetInt32(posIdCarta);
                            obeCartas.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeCartas.Numero = datard.GetInt32(posNumero);
                            obeCartas.Inciso = datard.GetString(posInciso);
                            obeCartas.Nombre = datard.GetString(posNombre);
                            obeCartas.Carta = datard.GetString(posCarta);
                            obeCartas.Solicitada = datard.GetString(posSolicitada);
                            obeCartas.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeCartas.IdTipoCarta = datard.GetInt32(posIdTipoCarta);
                            obeCartas.Obligada = datard.GetInt32(posObligada);
                            obeCartas.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeCartas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeCartas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeCartas;
            }
        }
        public List<beCartas> listarTodos_Cartas(SqlConnection Conexion)
        {
            string sp = "Proc_Cartas_Traer_Todos";
            List<beCartas> lbeCartas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCarta = datard.GetOrdinal("IdCarta");
                        int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int posNumero = datard.GetOrdinal("Numero");
                        int posInciso = datard.GetOrdinal("Inciso");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCarta = datard.GetOrdinal("Carta");
                        int posSolicitada = datard.GetOrdinal("Solicitada");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdTipoCarta = datard.GetOrdinal("IdTipoCarta");
                        int posObligada = datard.GetOrdinal("Obligada");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeCartas = new List<beCartas>();
                        beCartas obeCartas;
                        while (datard.Read())
                        {
                            obeCartas = new beCartas();
                            obeCartas.IdCarta = datard.GetInt32(posIdCarta);
                            obeCartas.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeCartas.Numero = datard.GetInt32(posNumero);
                            obeCartas.Inciso = datard.GetString(posInciso);
                            obeCartas.Nombre = datard.GetString(posNombre);
                            obeCartas.Carta = datard.GetString(posCarta);
                            obeCartas.Solicitada = datard.GetString(posSolicitada);
                            obeCartas.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeCartas.IdTipoCarta = datard.GetInt32(posIdTipoCarta);
                            obeCartas.Obligada = datard.GetInt32(posObligada);
                            obeCartas.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeCartas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeCartas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            lbeCartas.Add(obeCartas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCartas;
            }
        }
        public List<beCartas> listar_Cartas_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_Cartas_TraerTodos_GetAll";
            List<beCartas> lbeCartas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCarta = datard.GetOrdinal("IdCarta");
                        int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int posNumero = datard.GetOrdinal("Numero");
                        int posInciso = datard.GetOrdinal("Inciso");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCarta = datard.GetOrdinal("Carta");
                        int posSolicitada = datard.GetOrdinal("Solicitada");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdTipoCarta = datard.GetOrdinal("IdTipoCarta");
                        int posObligada = datard.GetOrdinal("Obligada");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posTipoCarta = datard.GetOrdinal("TipoCarta");
                        lbeCartas = new List<beCartas>();
                        beCartas obeCartas;
                        while (datard.Read())
                        {
                            obeCartas = new beCartas();
                            obeCartas.IdCarta = datard.GetInt32(posIdCarta);
                            obeCartas.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeCartas.Numero = datard.GetInt32(posNumero);
                            obeCartas.Inciso = datard.GetString(posInciso);
                            obeCartas.Nombre = datard.GetString(posNombre);
                            obeCartas.Carta = datard.GetString(posCarta);
                            obeCartas.Solicitada = datard.GetString(posSolicitada);
                            obeCartas.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeCartas.IdTipoCarta = datard.GetInt32(posIdTipoCarta);
                            obeCartas.Obligada = datard.GetInt32(posObligada);
                            obeCartas.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeCartas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeCartas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeCartas.TipoCarta = datard.GetString(posTipoCarta);
                            // debe agregar campos de la Vista
                            lbeCartas.Add(obeCartas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCartas;
            }
        }
        public List<beCartas> listarTodos_Cartas_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_Cartas_TraerTodos_GetAll";
            List<beCartas> lbeCartas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeCartas = new List<beCartas>();
                        beCartas obeCartas;
                        while (datard.Read())
                        {
                            obeCartas = new beCartas();
                            obeCartas.IdCarta = datard.GetInt32(0);
                            obeCartas.Numero = datard.GetInt32(1);
                            obeCartas.Inciso = datard.GetString(2);
                            obeCartas.Nombre = datard.GetString(3);
                            obeCartas.Carta = datard.GetString(4);
                            obeCartas.Solicitada = datard.GetString(5);
                            obeCartas.IdEstatus = datard.GetInt32(6);
                            obeCartas.IdTipoCarta = datard.GetInt32(7);
                            obeCartas.Obligada = datard.GetInt32(8);
                            obeCartas.IdGobierno = datard.GetInt32(9);
                            obeCartas.IdUsuarioRegistro = datard.GetInt32(10);
                            obeCartas.FechaRegistro = datard.GetDateTime(11);


                            lbeCartas.Add(obeCartas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCartas;
            }
        }
        public List<beCartas> listar_Cartas_x_IdRequisicion(SqlConnection Conexion, int pIdRequisicion)
        {
            string sp = "Proc_RequisicionesCartas_x_IdRequisicion";
            List<beCartas> lbeCartas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = pIdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCarta = datard.GetOrdinal("IdCarta");
                        int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int posNumero = datard.GetOrdinal("Numero");
                        int posInciso = datard.GetOrdinal("Inciso");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCarta = datard.GetOrdinal("Carta");
                        int posSolicitada = datard.GetOrdinal("Solicitada");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdTipoCarta = datard.GetOrdinal("IdTipoCarta");
                        int posObligada = datard.GetOrdinal("Obligada");
                        //int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        //int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        //int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posTipoCarta = datard.GetOrdinal("TipoCarta");
                        int posIdProveedorRequisicionCarta = datard.GetOrdinal("IdProveedorRequisicionCarta");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posAutorizada = datard.GetOrdinal("Autorizada");

                        lbeCartas = new List<beCartas>();
                        beCartas obeCartas;
                        while (datard.Read())
                        {
                            obeCartas = new beCartas();
                            obeCartas.IdCarta = datard.GetInt32(posIdCarta);
                            obeCartas.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            obeCartas.Numero = datard.GetInt32(posNumero);
                            obeCartas.Inciso = datard.GetString(posInciso);
                            obeCartas.Nombre = datard.GetString(posNombre);
                            obeCartas.Carta = datard.GetString(posCarta);
                            obeCartas.Solicitada = datard.GetString(posSolicitada);
                            obeCartas.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeCartas.IdTipoCarta = datard.GetInt32(posIdTipoCarta);
                            obeCartas.Obligada = datard.GetInt32(posObligada);
                            //obeCartas.IdGobierno = datard.GetInt32(posIdGobierno);
                            //obeCartas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            //obeCartas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeCartas.TipoCarta = datard.GetString(posTipoCarta);
                            obeCartas.IdProveedorRequisicionCarta = datard.GetInt32(posIdProveedorRequisicionCarta);
                            obeCartas.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeCartas.Autorizada = datard.GetInt32(posAutorizada);
                            // debe agregar campos de la Vista
                            lbeCartas.Add(obeCartas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCartas;
            }
        }
        public List<beCartas> listar_Cartas_x_IdProveedorRqInvitacion(SqlConnection Conexion, int pIdProveedorRqInvitacion)
        {
            string sp = "Proc_ProveedoresRequisicionesCartas_x_IdProveedorRqInvitacion";
            List<beCartas> lbeCartas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = pIdProveedorRqInvitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCarta = datard.GetOrdinal("IdCarta");
                       
                        int posNumero = datard.GetOrdinal("Numero");
                        int posInciso = datard.GetOrdinal("Inciso");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCarta = datard.GetOrdinal("Carta");

                        int IdProveedorCarta = datard.GetOrdinal("IdProveedorCarta");
                        int IdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int AceptacionCarta = datard.GetOrdinal("AceptacionCarta");
                        int FechaAceptacion = datard.GetOrdinal("FechaAceptacion");

                        lbeCartas = new List<beCartas>();
                        beCartas obeCartas;
                        while (datard.Read())
                        {
                            obeCartas = new beCartas();
                            obeCartas.IdCarta = datard.GetInt32(posIdCarta);
                            
                            obeCartas.Numero = datard.GetInt32(posNumero);
                            obeCartas.Inciso = datard.GetString(posInciso);
                            obeCartas.Nombre = datard.GetString(posNombre);
                            obeCartas.Carta = datard.GetString(posCarta);
                            obeCartas.IdProveedorCarta = datard.GetInt32(IdProveedorCarta);
                            obeCartas.IdProveedorRqInvitacion = datard.GetInt32(IdProveedorRqInvitacion);
                            obeCartas.AceptacionCarta = datard.GetBoolean(AceptacionCarta);
                            obeCartas.FechaAceptacion = datard[FechaAceptacion] ==DBNull.Value? DateTime.Now: datard.GetDateTime(FechaAceptacion);

                            // debe agregar campos de la Vista
                            lbeCartas.Add(obeCartas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCartas;
            }
        }
    }
}
