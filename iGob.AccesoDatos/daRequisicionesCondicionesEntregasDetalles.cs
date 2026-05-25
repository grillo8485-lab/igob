using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRequisicionesCondicionesEntregasDetalles
    {
        public int guardarRequisicionesCondicionesEntregasDetalles(SqlConnection Conexion, beRequisicionesCondicionesEntregasDetalles obeRequisicionesCondicionesEntregasDetalles)
        {
            int Id = 0;
            string sp = "Proc_RequisicionesCondicionesEntregasDetallesInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCondicionEntregaDetalle", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregasDetalles.IdCondicionEntregaDetalle;
                    cmd.Parameters.Add("@IdRequisicionCondicionEntrega", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregasDetalles.IdRequisicionCondicionEntrega;
                    cmd.Parameters.Add("@IdLugarEntrega", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregasDetalles.IdLugarEntrega;
                    cmd.Parameters.Add("@NumeroEntrega", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregasDetalles.NumeroEntrega;
                    cmd.Parameters.Add("@IdRequisicionLote", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregasDetalles.IdRequisicionLote;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeRequisicionesCondicionesEntregasDetalles.Cantidad;
                    cmd.Parameters.Add("@HorarioInicio", SqlDbType.Time).Value = obeRequisicionesCondicionesEntregasDetalles.HorarioInicio;
                    cmd.Parameters.Add("@HorarioFinal", SqlDbType.Time).Value = obeRequisicionesCondicionesEntregasDetalles.HorarioFinal;
                    cmd.Parameters.Add("@Lunes", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Lunes;
                    cmd.Parameters.Add("@Martes", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Martes;
                    cmd.Parameters.Add("@Miercoles", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Miercoles;
                    cmd.Parameters.Add("@Jueves", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Jueves;
                    cmd.Parameters.Add("@Viernes", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Viernes;
                    cmd.Parameters.Add("@Sabado", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Sabado;
                    cmd.Parameters.Add("@Domingo", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Domingo;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarRequisicionesCondicionesEntregasDetalles(SqlConnection Conexion, beRequisicionesCondicionesEntregasDetalles obeRequisicionesCondicionesEntregasDetalles)
        {
            string sp = "Proc_RequisicionesCondicionesEntregasDetallesActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCondicionEntregaDetalle", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregasDetalles.IdCondicionEntregaDetalle;
                    cmd.Parameters.Add("@IdRequisicionCondicionEntrega", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregasDetalles.IdRequisicionCondicionEntrega;
                    cmd.Parameters.Add("@IdLugarEntrega", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregasDetalles.IdLugarEntrega;
                    cmd.Parameters.Add("@NumeroEntrega", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregasDetalles.NumeroEntrega;
                    cmd.Parameters.Add("@IdRequisicionLote", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregasDetalles.IdRequisicionLote;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeRequisicionesCondicionesEntregasDetalles.Cantidad;
                    cmd.Parameters.Add("@HorarioInicio", SqlDbType.Time).Value = obeRequisicionesCondicionesEntregasDetalles.HorarioInicio;
                    cmd.Parameters.Add("@HorarioFinal", SqlDbType.Time).Value = obeRequisicionesCondicionesEntregasDetalles.HorarioFinal;
                    cmd.Parameters.Add("@Lunes", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Lunes;
                    cmd.Parameters.Add("@Martes", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Martes;
                    cmd.Parameters.Add("@Miercoles", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Miercoles;
                    cmd.Parameters.Add("@Jueves", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Jueves;
                    cmd.Parameters.Add("@Viernes", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Viernes;
                    cmd.Parameters.Add("@Sabado", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Sabado;
                    cmd.Parameters.Add("@Domingo", SqlDbType.TinyInt).Value = obeRequisicionesCondicionesEntregasDetalles.Domingo;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarRequisicionesCondicionesEntregasDetalles(SqlConnection Conexion, int pIdCondicionEntregaDetalle)
        {
            string sp = "Proc_RequisicionesCondicionesEntregasDetallesEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCondicionEntregaDetalle", SqlDbType.Int).Value = pIdCondicionEntregaDetalle;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beRequisicionesCondicionesEntregasDetalles traerRequisicionesCondicionesEntregasDetalles_x_IdCondicionEntregaDetalle(SqlConnection Conexion, int IdCondicionEntregaDetalle)
        {
            string sp = "Proc_RequisicionesCondicionesEntregasDetalles_x_IdCondicionEntregaDetalle";
            beRequisicionesCondicionesEntregasDetalles obeRequisicionesCondicionesEntregasDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCondicionEntregaDetalle", SqlDbType.Int).Value = IdCondicionEntregaDetalle;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        int posIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posNumeroEntrega = datard.GetOrdinal("NumeroEntrega");
                        int posIdRequisicionLote = datard.GetOrdinal("IdRequisicionLote");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posHorarioInicio = datard.GetOrdinal("HorarioInicio");
                        int posHorarioFinal = datard.GetOrdinal("HorarioFinal");
                        int posLunes = datard.GetOrdinal("Lunes");
                        int posMartes = datard.GetOrdinal("Martes");
                        int posMiercoles = datard.GetOrdinal("Miercoles");
                        int posJueves = datard.GetOrdinal("Jueves");
                        int posViernes = datard.GetOrdinal("Viernes");
                        int posSabado = datard.GetOrdinal("Sabado");
                        int posDomingo = datard.GetOrdinal("Domingo");
                        obeRequisicionesCondicionesEntregasDetalles = new beRequisicionesCondicionesEntregasDetalles();
                        while (datard.Read())
                        {
                            obeRequisicionesCondicionesEntregasDetalles.IdCondicionEntregaDetalle = datard.GetInt32(posIdCondicionEntregaDetalle);
                            obeRequisicionesCondicionesEntregasDetalles.IdRequisicionCondicionEntrega = datard.GetInt32(posIdRequisicionCondicionEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.NumeroEntrega = datard.GetInt32(posNumeroEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.IdRequisicionLote = datard.GetInt32(posIdRequisicionLote);
                            obeRequisicionesCondicionesEntregasDetalles.Cantidad = datard.GetDecimal(posCantidad);
                            obeRequisicionesCondicionesEntregasDetalles.HorarioInicio = datard.GetTimeSpan(posHorarioInicio);
                            obeRequisicionesCondicionesEntregasDetalles.HorarioFinal = datard.GetTimeSpan(posHorarioFinal);
                            obeRequisicionesCondicionesEntregasDetalles.Lunes = datard.GetByte(posLunes);
                            obeRequisicionesCondicionesEntregasDetalles.Martes = datard.GetByte(posMartes);
                            obeRequisicionesCondicionesEntregasDetalles.Miercoles = datard.GetByte(posMiercoles);
                            obeRequisicionesCondicionesEntregasDetalles.Jueves = datard.GetByte(posJueves);
                            obeRequisicionesCondicionesEntregasDetalles.Viernes = datard.GetByte(posViernes);
                            obeRequisicionesCondicionesEntregasDetalles.Sabado = datard.GetByte(posSabado);
                            obeRequisicionesCondicionesEntregasDetalles.Domingo = datard.GetByte(posDomingo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesCondicionesEntregasDetalles;
            }
        }
        public List<beRequisicionesCondicionesEntregasDetalles> listarTodos_RequisicionesCondicionesEntregasDetalles(SqlConnection Conexion)
        {
            string sp = "Proc_RequisicionesCondicionesEntregasDetalles_Traer_Todos";
            List<beRequisicionesCondicionesEntregasDetalles> lbeRequisicionesCondicionesEntregasDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        int posIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posNumeroEntrega = datard.GetOrdinal("NumeroEntrega");
                        int posIdRequisicionLote = datard.GetOrdinal("IdRequisicionLote");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posHorarioInicio = datard.GetOrdinal("HorarioInicio");
                        int posHorarioFinal = datard.GetOrdinal("HorarioFinal");
                        int posLunes = datard.GetOrdinal("Lunes");
                        int posMartes = datard.GetOrdinal("Martes");
                        int posMiercoles = datard.GetOrdinal("Miercoles");
                        int posJueves = datard.GetOrdinal("Jueves");
                        int posViernes = datard.GetOrdinal("Viernes");
                        int posSabado = datard.GetOrdinal("Sabado");
                        int posDomingo = datard.GetOrdinal("Domingo");
                        lbeRequisicionesCondicionesEntregasDetalles = new List<beRequisicionesCondicionesEntregasDetalles>();
                        beRequisicionesCondicionesEntregasDetalles obeRequisicionesCondicionesEntregasDetalles;
                        while (datard.Read())
                        {
                            obeRequisicionesCondicionesEntregasDetalles = new beRequisicionesCondicionesEntregasDetalles();
                            obeRequisicionesCondicionesEntregasDetalles.IdCondicionEntregaDetalle = datard.GetInt32(posIdCondicionEntregaDetalle);
                            obeRequisicionesCondicionesEntregasDetalles.IdRequisicionCondicionEntrega = datard.GetInt32(posIdRequisicionCondicionEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.NumeroEntrega = datard.GetInt32(posNumeroEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.IdRequisicionLote = datard.GetInt32(posIdRequisicionLote);
                            obeRequisicionesCondicionesEntregasDetalles.Cantidad = datard.GetDecimal(posCantidad);
                            obeRequisicionesCondicionesEntregasDetalles.HorarioInicio = datard.GetTimeSpan(posHorarioInicio);
                            obeRequisicionesCondicionesEntregasDetalles.HorarioFinal = datard.GetTimeSpan(posHorarioFinal);
                            obeRequisicionesCondicionesEntregasDetalles.Lunes = datard.GetByte(posLunes);
                            obeRequisicionesCondicionesEntregasDetalles.Martes = datard.GetByte(posMartes);
                            obeRequisicionesCondicionesEntregasDetalles.Miercoles = datard.GetByte(posMiercoles);
                            obeRequisicionesCondicionesEntregasDetalles.Jueves = datard.GetByte(posJueves);
                            obeRequisicionesCondicionesEntregasDetalles.Viernes = datard.GetByte(posViernes);
                            obeRequisicionesCondicionesEntregasDetalles.Sabado = datard.GetByte(posSabado);
                            obeRequisicionesCondicionesEntregasDetalles.Domingo = datard.GetByte(posDomingo);
                            lbeRequisicionesCondicionesEntregasDetalles.Add(obeRequisicionesCondicionesEntregasDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesEntregasDetalles;
            }
        }
        public List<beRequisicionesCondicionesEntregasDetalles> listar_RequisicionesCondicionesEntregasDetalles_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_RequisicionesCondicionesEntregasDetalles_TraerTodos_GetAll";
            List<beRequisicionesCondicionesEntregasDetalles> lbeRequisicionesCondicionesEntregasDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        int posIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posNumeroEntrega = datard.GetOrdinal("NumeroEntrega");
                        int posIdRequisicionLote = datard.GetOrdinal("IdRequisicionLote");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posHorarioInicio = datard.GetOrdinal("HorarioInicio");
                        int posHorarioFinal = datard.GetOrdinal("HorarioFinal");
                        int posLunes = datard.GetOrdinal("Lunes");
                        int posMartes = datard.GetOrdinal("Martes");
                        int posMiercoles = datard.GetOrdinal("Miercoles");
                        int posJueves = datard.GetOrdinal("Jueves");
                        int posViernes = datard.GetOrdinal("Viernes");
                        int posSabado = datard.GetOrdinal("Sabado");
                        int posDomingo = datard.GetOrdinal("Domingo");
                        lbeRequisicionesCondicionesEntregasDetalles = new List<beRequisicionesCondicionesEntregasDetalles>();
                        beRequisicionesCondicionesEntregasDetalles obeRequisicionesCondicionesEntregasDetalles;
                        while (datard.Read())
                        {
                            obeRequisicionesCondicionesEntregasDetalles = new beRequisicionesCondicionesEntregasDetalles();
                            obeRequisicionesCondicionesEntregasDetalles.IdCondicionEntregaDetalle = datard.GetInt32(posIdCondicionEntregaDetalle);
                            obeRequisicionesCondicionesEntregasDetalles.IdRequisicionCondicionEntrega = datard.GetInt32(posIdRequisicionCondicionEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.NumeroEntrega = datard.GetInt32(posNumeroEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.IdRequisicionLote = datard.GetInt32(posIdRequisicionLote);
                            obeRequisicionesCondicionesEntregasDetalles.Cantidad = datard.GetDecimal(posCantidad);
                            obeRequisicionesCondicionesEntregasDetalles.HorarioInicio = datard.GetTimeSpan(posHorarioInicio);
                            obeRequisicionesCondicionesEntregasDetalles.HorarioFinal = datard.GetTimeSpan(posHorarioFinal);
                            obeRequisicionesCondicionesEntregasDetalles.Lunes = datard.GetByte(posLunes);
                            obeRequisicionesCondicionesEntregasDetalles.Martes = datard.GetByte(posMartes);
                            obeRequisicionesCondicionesEntregasDetalles.Miercoles = datard.GetByte(posMiercoles);
                            obeRequisicionesCondicionesEntregasDetalles.Jueves = datard.GetByte(posJueves);
                            obeRequisicionesCondicionesEntregasDetalles.Viernes = datard.GetByte(posViernes);
                            obeRequisicionesCondicionesEntregasDetalles.Sabado = datard.GetByte(posSabado);
                            obeRequisicionesCondicionesEntregasDetalles.Domingo = datard.GetByte(posDomingo);
                            // debe agregar campos de la Vista
                            lbeRequisicionesCondicionesEntregasDetalles.Add(obeRequisicionesCondicionesEntregasDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesEntregasDetalles;
            }
        }

        public List<beRequisiciconesCondicionesDetallesIdRequisicion> listar_RequisicionesCondicionesEntregasDetalles_x_IdRequisicion(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_RequisiciconesCondicionesDetalles_traer_IdRequisicion";
            List<beRequisiciconesCondicionesDetallesIdRequisicion> lbeRequisicionesCondicionesEntregasDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int pIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int pNoLote = datard.GetOrdinal("NoLote");
                        int pCantidad = datard.GetOrdinal("Cantidad");
                        int pBienServicio = datard.GetOrdinal("BienServicio");
                        int pIdLote = datard.GetOrdinal("IdLote");
                        int pCantidadLotesxAsignar = datard.GetOrdinal("CantidadLotesxAsignar");
                        int pCantidadLoteAsignado = datard.GetOrdinal("CantidadLoteAsignado");
                        int pCantidadxAsignar = datard.GetOrdinal("CantidadxAsignar");

                        lbeRequisicionesCondicionesEntregasDetalles = new List<beRequisiciconesCondicionesDetallesIdRequisicion>();
                        beRequisiciconesCondicionesDetallesIdRequisicion obeRequisicionesCondicionesEntregasDetalles;
                        while (datard.Read())
                        {
                            obeRequisicionesCondicionesEntregasDetalles = new beRequisiciconesCondicionesDetallesIdRequisicion();
                            obeRequisicionesCondicionesEntregasDetalles.IdRequisicion = datard.GetInt32(pIdRequisicion);
                            obeRequisicionesCondicionesEntregasDetalles.NoLote = datard.GetInt32(pNoLote);
                            obeRequisicionesCondicionesEntregasDetalles.Cantidad = datard.GetDecimal(pCantidad);
                            obeRequisicionesCondicionesEntregasDetalles.BienServicio = datard.GetString(pBienServicio);
                            obeRequisicionesCondicionesEntregasDetalles.IdLote = datard.GetInt32(pIdLote);
                            obeRequisicionesCondicionesEntregasDetalles.CantidadLotesxAsignar = datard.GetString(pCantidadLotesxAsignar);
                            obeRequisicionesCondicionesEntregasDetalles.CantidadLoteAsignado = datard.GetDecimal(pCantidadLoteAsignado);
                            obeRequisicionesCondicionesEntregasDetalles.CantidadxAsignar = datard.GetDecimal(pCantidadxAsignar);
                            // debe agregar campos de la Vista
                            lbeRequisicionesCondicionesEntregasDetalles.Add(obeRequisicionesCondicionesEntregasDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesEntregasDetalles;
            }
        }
        public List<beRequisicionCondicionesEntregaDetalleConsulta> listar_RequisicionesCondicionesEntregasDetalles_x_IdRequisicionCondicionEntrega(SqlConnection Conexion, int IdRequisicionCondicionEntrega)
        {
            string sp = "Proc_RequisicionCondicionEntregaDet_traer_IdReqCondEntrega";
            List<beRequisicionCondicionesEntregaDetalleConsulta> lbeRequisicionesCondicionesEntregasDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicionCondicionEntrega", SqlDbType.Int).Value = IdRequisicionCondicionEntrega;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int pIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        int pIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
                        int pNumeroEntrega = datard.GetOrdinal("NumeroEntrega");
                        int pNoLote = datard.GetOrdinal("NoLote");
                        int pCantidadEntregaDetalle = datard.GetOrdinal("CantidadEntregaDetalle");
                        int pLugar = datard.GetOrdinal("Lugar");
                        int pDomicilioEntrega = datard.GetOrdinal("DomicilioEntrega");
                        int pLocalizacionGoogle = datard.GetOrdinal("LocalizacionGoogle");
                        int pHorarioInicio = datard.GetOrdinal("HorarioInicio");
                        int pHorarioFinal = datard.GetOrdinal("HorarioFinal");
                        int pLunes = datard.GetOrdinal("Lunes");
                        int pMartes = datard.GetOrdinal("Martes");
                        int pMiercoles = datard.GetOrdinal("Miercoles");
                        int pJueves = datard.GetOrdinal("Jueves");
                        int pViernes = datard.GetOrdinal("Viernes");
                        int pSabado = datard.GetOrdinal("Sabado");
                        int pDomingo = datard.GetOrdinal("Domingo");

                        lbeRequisicionesCondicionesEntregasDetalles = new List<beRequisicionCondicionesEntregaDetalleConsulta>();
                        beRequisicionCondicionesEntregaDetalleConsulta obeRequisicionesCondicionesEntregasDetalles;
                        while (datard.Read())
                        {
                            
                            obeRequisicionesCondicionesEntregasDetalles = new beRequisicionCondicionesEntregaDetalleConsulta();
                            obeRequisicionesCondicionesEntregasDetalles.IdCondicionEntregaDetalle = datard.GetInt32(pIdCondicionEntregaDetalle);
                            obeRequisicionesCondicionesEntregasDetalles.IdRequisicionCondicionEntrega = datard.GetInt32(pIdRequisicionCondicionEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.NumeroEntrega = datard.GetInt32(pNumeroEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.NoLote = datard.GetInt32(pNoLote);
                            obeRequisicionesCondicionesEntregasDetalles.CantidadEntregaDetalle = datard.GetDecimal(pCantidadEntregaDetalle);
                            obeRequisicionesCondicionesEntregasDetalles.Lugar = datard.GetString(pLugar);
                            obeRequisicionesCondicionesEntregasDetalles.DomicilioEntrega = datard.GetString(pDomicilioEntrega);
                            obeRequisicionesCondicionesEntregasDetalles.LocalizacionGoogle = datard.GetString(pLocalizacionGoogle);
                            obeRequisicionesCondicionesEntregasDetalles.HorarioInicio = datard.GetTimeSpan(pHorarioInicio);
                            obeRequisicionesCondicionesEntregasDetalles.HorarioFinal = datard.GetTimeSpan(pHorarioFinal);
                            obeRequisicionesCondicionesEntregasDetalles.Lunes = datard.GetByte(pLunes);
                            obeRequisicionesCondicionesEntregasDetalles.Martes = datard.GetByte(pMartes);
                            obeRequisicionesCondicionesEntregasDetalles.Miercoles = datard.GetByte(pMiercoles);
                            obeRequisicionesCondicionesEntregasDetalles.Jueves = datard.GetByte(pJueves);
                            obeRequisicionesCondicionesEntregasDetalles.Viernes = datard.GetByte(pViernes);
                            obeRequisicionesCondicionesEntregasDetalles.Sabado = datard.GetByte(pSabado);
                            obeRequisicionesCondicionesEntregasDetalles.Domingo = datard.GetByte(pDomingo);
                            // debe agregar campos de la Vista
                            lbeRequisicionesCondicionesEntregasDetalles.Add(obeRequisicionesCondicionesEntregasDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesEntregasDetalles;
            }
        }

    }
}
