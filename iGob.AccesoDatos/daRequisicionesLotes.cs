using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRequisicionesLotes
    {
        public int guardarRequisicionesLotes(SqlConnection Conexion, beRequisicionesLotes obeRequisicionesLotes)
        {
            int Id = 0;
            string sp = "Proc_RequisicionesLotesInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdLote", SqlDbType.Int).Value = obeRequisicionesLotes.IdLote;
                    cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesLotes.IdRequisicion;
                    cmd.Parameters.Add("@NoLote", SqlDbType.Int).Value = obeRequisicionesLotes.NoLote;
                    cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeRequisicionesLotes.IdBienServicio;
                    cmd.Parameters.Add("@Pantone", SqlDbType.Char).Value = obeRequisicionesLotes.Pantone;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeRequisicionesLotes.Cantidad;
                    cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obeRequisicionesLotes.PrecioUnitario;
                    cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obeRequisicionesLotes.Importe;
                    cmd.Parameters.Add("@PorcentajeImpuesto", SqlDbType.Decimal).Value = obeRequisicionesLotes.PorcentajeImpuesto;
                    cmd.Parameters.Add("@ImporteCImpuesto", SqlDbType.Decimal).Value = obeRequisicionesLotes.ImporteCImpuesto;
                    cmd.Parameters.Add("@ImporteMesnsualCImpuesto", SqlDbType.Decimal).Value = obeRequisicionesLotes.ImporteMesnsualCImpuesto;
                    cmd.Parameters.Add("@MesesServicio", SqlDbType.Int).Value = obeRequisicionesLotes.MesesServicio;
                    cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeRequisicionesLotes.Total;
                    cmd.Parameters.Add("@MesInicial", SqlDbType.Int).Value = obeRequisicionesLotes.MesInicial;
                    cmd.Parameters.Add("@MesFinal", SqlDbType.Int).Value = obeRequisicionesLotes.MesFinal;
                    cmd.Parameters.Add("@Frecuencia", SqlDbType.Int).Value = obeRequisicionesLotes.Frecuencia;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesLotes.FechaRegistro;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesLotes.IdUsuarioRegistro;
                    cmd.Parameters.Add("@IdMuestra", SqlDbType.Int).Value = obeRequisicionesLotes.IdMuestra;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarRequisicionesLotes(SqlConnection Conexion, beRequisicionesLotes obeRequisicionesLotes)
        {
            string sp = "Proc_RequisicionesLotesActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdLote", SqlDbType.Int).Value = obeRequisicionesLotes.IdLote;
                    cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesLotes.IdRequisicion;
                    cmd.Parameters.Add("@NoLote", SqlDbType.Int).Value = obeRequisicionesLotes.NoLote;
                    cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeRequisicionesLotes.IdBienServicio;
                    cmd.Parameters.Add("@Pantone", SqlDbType.Char).Value = obeRequisicionesLotes.Pantone;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeRequisicionesLotes.Cantidad;
                    cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obeRequisicionesLotes.PrecioUnitario;
                    cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obeRequisicionesLotes.Importe;
                    cmd.Parameters.Add("@PorcentajeImpuesto", SqlDbType.Decimal).Value = obeRequisicionesLotes.PorcentajeImpuesto;
                    cmd.Parameters.Add("@ImporteCImpuesto", SqlDbType.Decimal).Value = obeRequisicionesLotes.ImporteCImpuesto;
                    cmd.Parameters.Add("@ImporteMesnsualCImpuesto", SqlDbType.Decimal).Value = obeRequisicionesLotes.ImporteMesnsualCImpuesto;
                    cmd.Parameters.Add("@MesesServicio", SqlDbType.Int).Value = obeRequisicionesLotes.MesesServicio;
                    cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeRequisicionesLotes.Total;
                    cmd.Parameters.Add("@MesInicial", SqlDbType.Int).Value = obeRequisicionesLotes.MesInicial;
                    cmd.Parameters.Add("@MesFinal", SqlDbType.Int).Value = obeRequisicionesLotes.MesFinal;
                    cmd.Parameters.Add("@Frecuencia", SqlDbType.Int).Value = obeRequisicionesLotes.Frecuencia;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesLotes.FechaRegistro;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesLotes.IdUsuarioRegistro;
                    cmd.Parameters.Add("@IdMuestra", SqlDbType.Int).Value = obeRequisicionesLotes.IdMuestra;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarRequisicionesLotes(SqlConnection Conexion, int pIdLote)
        {
            string sp = "Proc_RequisicionesLotesEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdLote", SqlDbType.Int).Value = pIdLote;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beRequisicionesLotes traerRequisicionesLotes_x_IdLote(SqlConnection Conexion, int IdLote)
        {
            string sp = "Proc_RequisicionesLotes_x_IdLote";
            beRequisicionesLotes obeRequisicionesLotes = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLote", SqlDbType.Int).Value = IdLote;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPantone = datard.GetOrdinal("Pantone");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posImporteMesnsualCImpuesto = datard.GetOrdinal("ImporteMesnsualCImpuesto");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");
                        int posTotal = datard.GetOrdinal("Total");
                        int posMesInicial = datard.GetOrdinal("MesInicial");
                        int posMesFinal = datard.GetOrdinal("MesFinal");
                        int posFrecuencia = datard.GetOrdinal("Frecuencia");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posIdMuestra = datard.GetOrdinal("IdMuestra");

                        obeRequisicionesLotes = new beRequisicionesLotes();
                        while (datard.Read())
                        {
                            obeRequisicionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeRequisicionesLotes.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeRequisicionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeRequisicionesLotes.Pantone = datard.GetString(posPantone);
                            obeRequisicionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeRequisicionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeRequisicionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeRequisicionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeRequisicionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeRequisicionesLotes.ImporteMesnsualCImpuesto = datard.GetDecimal(posImporteMesnsualCImpuesto);
                            obeRequisicionesLotes.MesesServicio = datard.GetInt32(posMesesServicio);
                            obeRequisicionesLotes.Total = datard.GetDecimal(posTotal);
                            obeRequisicionesLotes.MesInicial = datard.GetInt32(posMesInicial);
                            obeRequisicionesLotes.MesFinal = datard.GetInt32(posMesFinal);
                            obeRequisicionesLotes.Frecuencia = datard.GetInt32(posFrecuencia);
                            obeRequisicionesLotes.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRequisicionesLotes.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesLotes.IdMuestra = datard.GetInt32(posIdMuestra);

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesLotes;
            }
        }
        public List<beRequisicionesLotes> listarTodos_RequisicionesLotes(SqlConnection Conexion)
        {
            string sp = "Proc_RequisicionesLotes_Traer_Todos";
            List<beRequisicionesLotes> lbeRequisicionesLotes = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPantone = datard.GetOrdinal("Pantone");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posImporteMesnsualCImpuesto = datard.GetOrdinal("ImporteMesnsualCImpuesto");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");
                        int posTotal = datard.GetOrdinal("Total");
                        int posMesInicial = datard.GetOrdinal("MesInicial");
                        int posMesFinal = datard.GetOrdinal("MesFinal");
                        int posFrecuencia = datard.GetOrdinal("Frecuencia");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posIdMuestra = datard.GetOrdinal("IdMuestra");

                        lbeRequisicionesLotes = new List<beRequisicionesLotes>();
                        beRequisicionesLotes obeRequisicionesLotes;
                        while (datard.Read())
                        {
                            obeRequisicionesLotes = new beRequisicionesLotes();
                            obeRequisicionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeRequisicionesLotes.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeRequisicionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeRequisicionesLotes.Pantone = datard.GetString(posPantone);
                            obeRequisicionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeRequisicionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeRequisicionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeRequisicionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeRequisicionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeRequisicionesLotes.ImporteMesnsualCImpuesto = datard.GetDecimal(posImporteMesnsualCImpuesto);
                            obeRequisicionesLotes.MesesServicio = datard.GetInt32(posMesesServicio);
                            obeRequisicionesLotes.Total = datard.GetDecimal(posTotal);
                            obeRequisicionesLotes.MesInicial = datard.GetInt32(posMesInicial);
                            obeRequisicionesLotes.MesFinal = datard.GetInt32(posMesFinal);
                            obeRequisicionesLotes.Frecuencia = datard.GetInt32(posFrecuencia);
                            obeRequisicionesLotes.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRequisicionesLotes.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesLotes.IdMuestra = datard.GetInt32(posIdMuestra);
                            lbeRequisicionesLotes.Add(obeRequisicionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }
        public List<beRequisicionesLotes> listar_RequisicionesLotes_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_RequisicionesLotes_TraerTodos_GetAll";
            List<beRequisicionesLotes> lbeRequisicionesLotes = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPantone = datard.GetOrdinal("Pantone");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posImporteMesnsualCImpuesto = datard.GetOrdinal("ImporteMesnsualCImpuesto");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");
                        int posTotal = datard.GetOrdinal("Total");
                        int posMesInicial = datard.GetOrdinal("MesInicial");
                        int posMesFinal = datard.GetOrdinal("MesFinal");
                        int posFrecuencia = datard.GetOrdinal("Frecuencia");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posIdMuestra = datard.GetOrdinal("IdMuestra");
                        lbeRequisicionesLotes = new List<beRequisicionesLotes>();
                        beRequisicionesLotes obeRequisicionesLotes;
                        while (datard.Read())
                        {
                            obeRequisicionesLotes = new beRequisicionesLotes();
                            obeRequisicionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeRequisicionesLotes.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeRequisicionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeRequisicionesLotes.Pantone = datard.GetString(posPantone);
                            obeRequisicionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeRequisicionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeRequisicionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeRequisicionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeRequisicionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeRequisicionesLotes.ImporteMesnsualCImpuesto = datard.GetDecimal(posImporteMesnsualCImpuesto);
                            obeRequisicionesLotes.MesesServicio = datard.GetInt32(posMesesServicio);
                            obeRequisicionesLotes.Total = datard.GetDecimal(posTotal);
                            obeRequisicionesLotes.MesInicial = datard.GetInt32(posMesInicial);
                            obeRequisicionesLotes.MesFinal = datard.GetInt32(posMesFinal);
                            obeRequisicionesLotes.Frecuencia = datard.GetInt32(posFrecuencia);
                            obeRequisicionesLotes.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRequisicionesLotes.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesLotes.IdMuestra = datard.GetInt32(posIdMuestra);
                            // debe agregar campos de la Vista
                            lbeRequisicionesLotes.Add(obeRequisicionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }

        }
        public List<beGenerica> listarTodos_RequisicionesLotes_x_IdPartida_BienServicio(SqlConnection Conexion, beGenerica oGenerica)
        {
            string sp = "Proc_RequisicionesLotes_Traer_x_IdPartida_BienServicio";
            List<beGenerica> lbeRequisicionesLotes = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = oGenerica.entero;
            cmd.Parameters.Add("@BienServicio", SqlDbType.NVarChar).Value = oGenerica.string1;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int pIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int pCodigo = datard.GetOrdinal("Codigo");
                        int pBienServicio = datard.GetOrdinal("BienServicio");
                        int pDescripcion = datard.GetOrdinal("Descripcion");
                        int pIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int pIdImpuesto = datard.GetOrdinal("IdImpuesto");
                        int pPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int pUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int pTasa = datard.GetOrdinal("Tasa");
                        int pDescripcionImpuesto = datard.GetOrdinal("DescripcionImpuesto");
                        int pActivo = datard.GetOrdinal("Activo");

                        lbeRequisicionesLotes = new List<beGenerica>();
                        beGenerica obeRequisicionesLotes;
                        while (datard.Read())
                        {
                            obeRequisicionesLotes = new beGenerica();
                            obeRequisicionesLotes.entero = datard.GetInt32(pIdBienServicio);
                            obeRequisicionesLotes.entero2 = datard.GetInt32(pIdUnidadMedida);
                            obeRequisicionesLotes.entero3 = datard.GetInt32(pIdImpuesto);
                            obeRequisicionesLotes.string1 = datard.GetString(pCodigo);
                            obeRequisicionesLotes.string2 = datard.GetString(pDescripcion);
                            obeRequisicionesLotes.decimal1 = datard.GetDecimal(pPrecioUnitario);
                            obeRequisicionesLotes.string3 = datard.GetString(pUnidadMedida);
                            obeRequisicionesLotes.decimal2 = datard.GetDecimal(pTasa);
                            obeRequisicionesLotes.string4 = datard.GetString(pDescripcionImpuesto);
                            obeRequisicionesLotes.bool1 = datard.GetBoolean(pActivo);
                            obeRequisicionesLotes.string5 = datard.GetString(pBienServicio);
                            lbeRequisicionesLotes.Add(obeRequisicionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }

        public beGenerica traerRequisicionesLotes_x_IdBienServicio(SqlConnection Conexion, int IdBienServicio)
        {
            string sp = "Proc_RequisicionesLotes_Traer_x_IdBienServicio";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = IdBienServicio;
            beGenerica obeRequisicionesLotes = new beGenerica();
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int pIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int pCodigo = datard.GetOrdinal("Codigo");
                        int pBienServicio = datard.GetOrdinal("BienServicio");
                        int pDescripcion = datard.GetOrdinal("Descripcion");
                        int pIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int pIdImpuesto = datard.GetOrdinal("IdImpuesto");
                        int pPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int pUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int pTasa = datard.GetOrdinal("Tasa");
                        int pDescripcionImpuesto = datard.GetOrdinal("DescripcionImpuesto");
                        int pActivo = datard.GetOrdinal("Activo");



                        while (datard.Read())
                        {
                            obeRequisicionesLotes = new beGenerica();
                            obeRequisicionesLotes.entero = datard.GetInt32(pIdBienServicio);
                            obeRequisicionesLotes.entero2 = datard.GetInt32(pIdUnidadMedida);
                            obeRequisicionesLotes.entero3 = datard.GetInt32(pIdImpuesto);
                            obeRequisicionesLotes.string1 = datard.GetString(pCodigo);
                            obeRequisicionesLotes.string2 = datard.GetString(pDescripcion);
                            obeRequisicionesLotes.decimal1 = datard.GetDecimal(pPrecioUnitario);
                            obeRequisicionesLotes.string3 = datard.GetString(pUnidadMedida);
                            obeRequisicionesLotes.decimal2 = datard.GetDecimal(pTasa);
                            obeRequisicionesLotes.string4 = datard.GetString(pDescripcionImpuesto);
                            obeRequisicionesLotes.bool1 = datard.GetBoolean(pActivo);


                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesLotes;
            }
        }
        public List<beRequisicionLotesIdRequisicion> traerRequisicionesLotes_x_IdRequisicion(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_RequisicionesLotes_Traer_IdRequisicion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            List<beRequisicionLotesIdRequisicion> lbeRequisicionesLotes = new List<beRequisicionLotesIdRequisicion>();
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPantone = datard.GetOrdinal("Pantone");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posImporteMesnsualCImpuesto = datard.GetOrdinal("ImporteMesnsualCImpuesto");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");
                        int posTotal = datard.GetOrdinal("Total");
                        int posMesInicial = datard.GetOrdinal("MesInicial");
                        int posMesFinal = datard.GetOrdinal("MesFinal");
                        int posFrecuencia = datard.GetOrdinal("Frecuencia");
                        
                        int posIdMuestra = datard.GetOrdinal("IdMuestra");
                        int posCodigo = datard.GetOrdinal("Codigo");
                        int posClaveCubs=  datard.GetOrdinal("ClaveCubs");             
                        int posBienServicio=datard.GetOrdinal("BienServicio");
                        int posDescripcion=datard.GetOrdinal("Descripcion");
                        int posIdTipoProducto=datard.GetOrdinal("IdTipoProducto");
                        int posIdMarca=datard.GetOrdinal("IdMarca");
                        int posIdFamilia=datard.GetOrdinal("IdFamilia");
                        int posIdUnidadMedida=datard.GetOrdinal("IdUnidadMedida");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posIdImpuesto=datard.GetOrdinal("IdImpuesto");
                        int posMuestra=datard.GetOrdinal("Muestra");
                        int posDesCricionMesInicial=datard.GetOrdinal("DesCricionMesInicial");
                        int posDesCricionMesFinal=datard.GetOrdinal("DesCricionMesFinal");
                        int posImpuesto=datard.GetOrdinal("Impuesto");
                        int posDescripcionFrecuencia = datard.GetOrdinal("DescripcionFrecuencia");
                        lbeRequisicionesLotes = new List<beRequisicionLotesIdRequisicion>();
                        beRequisicionLotesIdRequisicion obeRequisicionesLotes;
                        while (datard.Read())
                        {
                            obeRequisicionesLotes = new beRequisicionLotesIdRequisicion();
                            obeRequisicionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeRequisicionesLotes.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeRequisicionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeRequisicionesLotes.Pantone = datard.GetString(posPantone);
                            obeRequisicionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeRequisicionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeRequisicionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeRequisicionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeRequisicionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeRequisicionesLotes.ImporteMesnsualCImpuesto = datard.GetDecimal(posImporteMesnsualCImpuesto);
                            obeRequisicionesLotes.MesesServicio = datard.GetInt32(posMesesServicio);
                            obeRequisicionesLotes.Total = datard.GetDecimal(posTotal);
                            obeRequisicionesLotes.MesInicial = datard.GetInt32(posMesInicial);
                            obeRequisicionesLotes.MesFinal = datard.GetInt32(posMesFinal);
                            obeRequisicionesLotes.Frecuencia = datard.GetInt32(posFrecuencia);
                            obeRequisicionesLotes.Codigo = datard.GetString(posCodigo);
                            obeRequisicionesLotes.ClaveCubs= datard.GetString(posClaveCubs);
                            obeRequisicionesLotes.BienServicio= datard.GetString(posBienServicio);
                            obeRequisicionesLotes.Descripcion= datard.GetString(posDescripcion);
                            obeRequisicionesLotes.IdTipoProducto= datard.GetInt32(posIdTipoProducto);
                            obeRequisicionesLotes.IdMarca= datard.GetInt32(posIdMarca);
                            obeRequisicionesLotes.IdFamilia= datard.GetInt32(posIdMarca);
                            obeRequisicionesLotes.IdUnidadMedida= datard.GetInt32(posIdUnidadMedida);
                            obeRequisicionesLotes.UnidadMedida = datard.GetString(posUnidadMedida);
                            obeRequisicionesLotes.IdImpuesto= datard.GetInt32(posIdImpuesto);
                            obeRequisicionesLotes.Muestra= datard.GetString(posMuestra);
                            obeRequisicionesLotes.DesCricionMesInicial= datard.GetString(posDesCricionMesInicial);
                            obeRequisicionesLotes.DesCricionMesFinal= datard.GetString(posDesCricionMesFinal);
                            obeRequisicionesLotes.Impuesto= datard.GetString(posImpuesto);
                            obeRequisicionesLotes.IdMuestra = datard.GetInt32(posIdMuestra);
                            obeRequisicionesLotes.DescripcionFrecuencia = datard.GetString(posDescripcionFrecuencia);
                            
                            // debe agregar campos de la Vista
                            lbeRequisicionesLotes.Add(obeRequisicionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }

        public List<beRequisicionLotesIdRequisicion> traerRequisicionesLotes_x_IdProveedorRqInvitacion(SqlConnection Conexion, int pIdProveedorRqInvitacion)
        {
            string sp = "Proc_PropuestaTecEcoLote_x_IdProveedorRqInvitacion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = pIdProveedorRqInvitacion;
            List<beRequisicionLotesIdRequisicion> lbeRequisicionesLotes = new List<beRequisicionLotesIdRequisicion>();
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPantone = datard.GetOrdinal("Pantone");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posImporteMesnsualCImpuesto = datard.GetOrdinal("ImporteMesnsualCImpuesto");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");
                        int posTotal = datard.GetOrdinal("Total");
                        int posMesInicial = datard.GetOrdinal("MesInicial");
                        int posMesFinal = datard.GetOrdinal("MesFinal");
                        int posFrecuencia = datard.GetOrdinal("Frecuencia");

                        int posIdMuestra = datard.GetOrdinal("IdMuestra");
                        //int posCodigo = datard.GetOrdinal("Codigo");
                        int posClaveCubs = datard.GetOrdinal("ClaveCubs");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIdTipoProducto = datard.GetOrdinal("IdTipoProducto");
                        int posIdMarca = datard.GetOrdinal("IdMarca");
                        int posIdFamilia = datard.GetOrdinal("IdFamilia");
                        int posIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posIdImpuesto = datard.GetOrdinal("IdImpuesto");
                        int posMuestra = datard.GetOrdinal("Muestra");
                        int posDesCricionMesInicial = datard.GetOrdinal("DesCricionMesInicial");
                        int posDesCricionMesFinal = datard.GetOrdinal("DesCricionMesFinal");
                        int posImpuesto = datard.GetOrdinal("Impuesto");
                        int posDescripcionFrecuencia = datard.GetOrdinal("DescripcionFrecuencia");

                        int IdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int IdEstatusEnvioPropuestaTecnica = datard.GetOrdinal("IdEstatusEnvioPropuestaTecnica");
                        int IdUsuaroEnviaPropuestaTecnica = datard.GetOrdinal("IdUsuaroEnviaPropuestaTecnica");
                        int FechaEnvioPropuestaTecnica = datard.GetOrdinal("FechaEnvioPropuestaTecnica");
                        int IdEstatusEnvioPropuestaEconomica = datard.GetOrdinal("IdEstatusEnvioPropuestaEconomica");
                        int IdUsuaroEnviaPropuestaEconomica = datard.GetOrdinal("IdUsuaroEnviaPropuestaEconomica");
                        int FechaEnvioPropuestaEconomica = datard.GetOrdinal("FechaEnvioPropuestaEconomica");
                        int IdPropuestaTecnicaEconomica = datard.GetOrdinal("IdPropuestaTecnicaEconomica");
                        int LoteOfertado = datard.GetOrdinal("LoteOfertado");
                        int Mejora = datard.GetOrdinal("Mejora");
                        int EstatusMejora = datard.GetOrdinal("EstatusMejora");
                        int PrecioUnitarioRefencia = datard.GetOrdinal("PrecioUnitarioRefencia");
                        int PrecioUnitarioOfertado = datard.GetOrdinal("PrecioUnitarioOfertado");
                        int ImporteOfertado = datard.GetOrdinal("ImporteOfertado");
                        int ImpuestoPorcentaje = datard.GetOrdinal("ImpuestoPorcentaje");
                        int ImpuestoImporte = datard.GetOrdinal("ImpuestoImporte");
                        int TotalOfertado = datard.GetOrdinal("TotalOfertado");
                        int URLFileMuestraCatalogo = datard.GetOrdinal("URLFileMuestraCatalogo");
                        int URLFileCertificacion = datard.GetOrdinal("URLFileCertificacion");
                        int ImportePeriodo = datard.GetOrdinal("ImportePeriodo");
                        int ImpuestoPeriodo = datard.GetOrdinal("ImpuestoPeriodo");
                        int TotalPeriodo = datard.GetOrdinal("TotalPeriodo");
                        int IdEstatusPropuesta = datard.GetOrdinal("IdEstatusPropuesta");

                         int AdquisicionCumple= datard.GetOrdinal("AdquisicionCumple");
	                     int AdquisicionObserva= datard.GetOrdinal("AdquisicionObserva");
	                     int DependenciaCumple= datard.GetOrdinal("DependenciaCumple");
	                     int FundamentoLegal = datard.GetOrdinal("FundamentoLegal");

                        lbeRequisicionesLotes = new List<beRequisicionLotesIdRequisicion>();
                        beRequisicionLotesIdRequisicion obeRequisicionesLotes;
                        while (datard.Read())
                        {
                            obeRequisicionesLotes = new beRequisicionLotesIdRequisicion();
                            obeRequisicionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeRequisicionesLotes.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeRequisicionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeRequisicionesLotes.Pantone = datard.GetString(posPantone);
                            obeRequisicionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeRequisicionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeRequisicionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeRequisicionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeRequisicionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeRequisicionesLotes.ImporteMesnsualCImpuesto = datard.GetDecimal(posImporteMesnsualCImpuesto);
                            obeRequisicionesLotes.MesesServicio = datard.GetInt32(posMesesServicio);
                            obeRequisicionesLotes.Total = datard.GetDecimal(posTotal);
                            obeRequisicionesLotes.MesInicial = datard.GetInt32(posMesInicial);
                            obeRequisicionesLotes.MesFinal = datard.GetInt32(posMesFinal);
                            obeRequisicionesLotes.Frecuencia = datard.GetInt32(posFrecuencia);
                            //obeRequisicionesLotes.Codigo = datard.GetString(posCodigo);
                            obeRequisicionesLotes.ClaveCubs = datard.GetString(posClaveCubs);
                            obeRequisicionesLotes.BienServicio = datard.GetString(posBienServicio);
                            obeRequisicionesLotes.Descripcion = datard.GetString(posDescripcion);
                            obeRequisicionesLotes.IdTipoProducto = datard.GetInt32(posIdTipoProducto);
                            obeRequisicionesLotes.IdMarca = datard.GetInt32(posIdMarca);
                            obeRequisicionesLotes.IdFamilia = datard.GetInt32(posIdMarca);
                            obeRequisicionesLotes.IdUnidadMedida = datard.GetInt32(posIdUnidadMedida);
                            obeRequisicionesLotes.UnidadMedida = datard.GetString(posUnidadMedida);
                            obeRequisicionesLotes.IdImpuesto = datard.GetInt32(posIdImpuesto);
                            obeRequisicionesLotes.Muestra = datard.GetString(posMuestra);
                            obeRequisicionesLotes.DesCricionMesInicial = datard.GetString(posDesCricionMesInicial);
                            obeRequisicionesLotes.DesCricionMesFinal = datard.GetString(posDesCricionMesFinal);
                            obeRequisicionesLotes.Impuesto = datard.GetString(posImpuesto);
                            obeRequisicionesLotes.IdMuestra = datard.GetInt32(posIdMuestra);
                            obeRequisicionesLotes.DescripcionFrecuencia = datard.GetString(posDescripcionFrecuencia);


                            obeRequisicionesLotes.IdProveedorRqInvitacion = datard[IdProveedorRqInvitacion] == DBNull.Value ? 0 : datard.GetInt32(IdProveedorRqInvitacion);
                            obeRequisicionesLotes.IdEstatusEnvioPropuestaTecnica = datard[IdEstatusEnvioPropuestaTecnica] == DBNull.Value ? 0 : datard.GetInt32(IdEstatusEnvioPropuestaTecnica);
                            obeRequisicionesLotes.IdUsuaroEnviaPropuestaTecnica = datard[IdUsuaroEnviaPropuestaTecnica] == DBNull.Value ? 0 : datard.GetInt32(IdUsuaroEnviaPropuestaTecnica);
                            obeRequisicionesLotes.FechaEnvioPropuestaTecnica = datard[FechaEnvioPropuestaTecnica] == DBNull.Value ? DateTime.MinValue : datard.GetDateTime(FechaEnvioPropuestaTecnica);
                            obeRequisicionesLotes.IdEstatusEnvioPropuestaEconomica = datard[IdEstatusEnvioPropuestaEconomica] == DBNull.Value ? 0 : datard.GetInt32(IdEstatusEnvioPropuestaEconomica);
                            obeRequisicionesLotes.IdUsuaroEnviaPropuestaEconomica = datard[IdUsuaroEnviaPropuestaEconomica] == DBNull.Value ? 0 : datard.GetInt32(IdUsuaroEnviaPropuestaEconomica);
                            obeRequisicionesLotes.FechaEnvioPropuestaEconomica = datard[FechaEnvioPropuestaEconomica] == DBNull.Value ? DateTime.MinValue : datard.GetDateTime(FechaEnvioPropuestaEconomica);
                            obeRequisicionesLotes.IdPropuestaTecnicaEconomica = datard[IdPropuestaTecnicaEconomica] == DBNull.Value ? 0 : datard.GetInt32(IdPropuestaTecnicaEconomica);
                            obeRequisicionesLotes.LoteOfertado = datard[LoteOfertado] == DBNull.Value ? false : datard.GetBoolean(LoteOfertado);
                            obeRequisicionesLotes.Mejora = datard[Mejora] == DBNull.Value ? "" : datard.GetString(Mejora);
                            obeRequisicionesLotes.EstatusMejora = datard[EstatusMejora] == DBNull.Value ? 0 : datard.GetInt32(EstatusMejora);
                            obeRequisicionesLotes.PrecioUnitarioRefencia = datard[PrecioUnitarioRefencia] == DBNull.Value ? 0 : datard.GetDecimal(PrecioUnitarioRefencia);
                            obeRequisicionesLotes.PrecioUnitarioOfertado = datard[PrecioUnitarioOfertado] == DBNull.Value ? 0 : datard.GetDecimal(PrecioUnitarioOfertado);
                            obeRequisicionesLotes.ImporteOfertado = datard[ImporteOfertado] == DBNull.Value ? 0 : datard.GetDecimal(ImporteOfertado);
                            obeRequisicionesLotes.ImpuestoPorcentaje = datard[ImpuestoPorcentaje] == DBNull.Value ? 0 : datard.GetDecimal(ImpuestoPorcentaje);
                            obeRequisicionesLotes.ImpuestoImporte = datard[ImpuestoImporte] == DBNull.Value ? 0 : datard.GetDecimal(ImpuestoImporte);
                            obeRequisicionesLotes.TotalOfertado = datard[TotalOfertado] == DBNull.Value ? 0 : datard.GetDecimal(TotalOfertado);
                            obeRequisicionesLotes.URLFileMuestraCatalogo = datard[URLFileMuestraCatalogo] == DBNull.Value ? "" : datard.GetString(URLFileMuestraCatalogo);
                            obeRequisicionesLotes.URLFileCertificacion = datard[URLFileCertificacion] == DBNull.Value ? "" : datard.GetString(URLFileCertificacion);
                            obeRequisicionesLotes.ImportePeriodo = datard[ImportePeriodo] == DBNull.Value ? 0 : datard.GetDecimal(ImportePeriodo);
                            obeRequisicionesLotes.ImpuestoPeriodo = datard[ImpuestoPeriodo] == DBNull.Value ? 0 : datard.GetDecimal(ImpuestoPeriodo);
                            obeRequisicionesLotes.TotalPeriodo = datard[TotalPeriodo] == DBNull.Value ? 0 : datard.GetDecimal(TotalPeriodo);
                            obeRequisicionesLotes.IdEstatusPropuesta = datard[IdEstatusPropuesta] == DBNull.Value ? 0 : datard.GetInt32(IdEstatusPropuesta);

                            obeRequisicionesLotes.AdquisicionCumple = datard[AdquisicionCumple] == DBNull.Value ? false : datard.GetBoolean(AdquisicionCumple);
                            obeRequisicionesLotes.AdquisicionObserva = datard[AdquisicionObserva] == DBNull.Value ? "": datard.GetString(AdquisicionObserva);
                            obeRequisicionesLotes.DependenciaCumple = datard[DependenciaCumple] == DBNull.Value ?false : datard.GetBoolean(DependenciaCumple);
                            obeRequisicionesLotes.FundamentoLegal = datard[FundamentoLegal] == DBNull.Value ? "" : datard.GetString(FundamentoLegal);

                            // debe agregar campos de la Vista
                            lbeRequisicionesLotes.Add(obeRequisicionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }
        public List<beGenerica> listarTodos_BienServicio_x_Producto(SqlConnection Conexion, beGenerica oGenerica)
        {
            string sp = "Proc_BienesServicios_x_BienServicio";
            List<beGenerica> lbeRequisicionesLotes = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BienServicio", SqlDbType.NVarChar).Value = oGenerica.string1;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int pIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int pCodigo = datard.GetOrdinal("Codigo");
                        int pBienServicio = datard.GetOrdinal("BienServicio");
                        int pDescripcion = datard.GetOrdinal("Descripcion");
                        int pIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int pIdImpuesto = datard.GetOrdinal("IdImpuesto");
                        int pPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int pUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int pTasa = datard.GetOrdinal("Tasa");
                        int pDescripcionImpuesto = datard.GetOrdinal("DescripcionImpuesto");
                        int pActivo = datard.GetOrdinal("Activo");

                        lbeRequisicionesLotes = new List<beGenerica>();
                        beGenerica obeRequisicionesLotes;
                        while (datard.Read())
                        {
                            obeRequisicionesLotes = new beGenerica();
                            obeRequisicionesLotes.entero = datard.GetInt32(pIdBienServicio);
                            obeRequisicionesLotes.entero2 = datard.GetInt32(pIdUnidadMedida);
                            obeRequisicionesLotes.entero3 = datard.GetInt32(pIdImpuesto);
                            obeRequisicionesLotes.string1 = datard.GetString(pCodigo);
                            obeRequisicionesLotes.string2 = datard.GetString(pDescripcion);
                            obeRequisicionesLotes.decimal1 = datard.GetDecimal(pPrecioUnitario);
                            obeRequisicionesLotes.string3 = datard.GetString(pUnidadMedida);
                            obeRequisicionesLotes.decimal2 = datard.GetDecimal(pTasa);
                            obeRequisicionesLotes.string4 = datard.GetString(pDescripcionImpuesto);
                            obeRequisicionesLotes.bool1 = datard.GetBoolean(pActivo);
                            obeRequisicionesLotes.string5 = datard.GetString(pBienServicio);
                            lbeRequisicionesLotes.Add(obeRequisicionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }
    }
}
