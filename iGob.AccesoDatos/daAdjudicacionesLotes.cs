using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daAdjudicacionesLotes
    {
        public int guardarAdjudicacionesLotes(SqlConnection Conexion, beAdjudicacionesLotes obeAdjudicacionesLotes)
        {
            int Id = 0;
            string sp = "Proc_AdjudicacionesLotesInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdLote", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdLote;
                    cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdAdjudicacion;
                    cmd.Parameters.Add("@NoLote", SqlDbType.Int).Value = obeAdjudicacionesLotes.NoLote;
                    cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdBienServicio;
                    cmd.Parameters.Add("@Pantone", SqlDbType.Char).Value = obeAdjudicacionesLotes.Pantone;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.Cantidad;
                    cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.PrecioUnitario;
                    cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.Importe;
                    cmd.Parameters.Add("@PorcentajeImpuesto", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.PorcentajeImpuesto;
                    cmd.Parameters.Add("@ImporteCImpuesto", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.ImporteCImpuesto;
                    cmd.Parameters.Add("@ImporteMensualCImpuesto", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.ImporteMensualCImpuesto;
                    cmd.Parameters.Add("@MesesServicio", SqlDbType.Int).Value = obeAdjudicacionesLotes.MesesServicio;
                    cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.Total;
                    cmd.Parameters.Add("@IdMesInicial", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdMesInicial;
                    cmd.Parameters.Add("@IdMesFinal", SqlDbType.NChar).Value = obeAdjudicacionesLotes.IdMesFinal;
                    cmd.Parameters.Add("@IdFrecuencia", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdFrecuencia;
                    cmd.Parameters.Add("@IdMuestra", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdMuestra;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesLotes.FechaRegistro;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdUsuarioRegistro;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarAdjudicacionesLotes(SqlConnection Conexion, beAdjudicacionesLotes obeAdjudicacionesLotes)
        {
            string sp = "Proc_AdjudicacionesLotesActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdLote", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdLote;
                    cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdAdjudicacion;
                    cmd.Parameters.Add("@NoLote", SqlDbType.Int).Value = obeAdjudicacionesLotes.NoLote;
                    cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdBienServicio;
                    cmd.Parameters.Add("@Pantone", SqlDbType.Char).Value = obeAdjudicacionesLotes.Pantone;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.Cantidad;
                    cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.PrecioUnitario;
                    cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.Importe;
                    cmd.Parameters.Add("@PorcentajeImpuesto", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.PorcentajeImpuesto;
                    cmd.Parameters.Add("@ImporteCImpuesto", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.ImporteCImpuesto;
                    cmd.Parameters.Add("@ImporteMensualCImpuesto", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.ImporteMensualCImpuesto;
                    cmd.Parameters.Add("@MesesServicio", SqlDbType.Int).Value = obeAdjudicacionesLotes.MesesServicio;
                    cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeAdjudicacionesLotes.Total;
                    cmd.Parameters.Add("@IdMesInicial", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdMesInicial;
                    cmd.Parameters.Add("@IdMesFinal", SqlDbType.NChar).Value = obeAdjudicacionesLotes.IdMesFinal;
                    cmd.Parameters.Add("@IdFrecuencia", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdFrecuencia;
                    cmd.Parameters.Add("@IdMuestra", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdMuestra;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesLotes.FechaRegistro;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesLotes.IdUsuarioRegistro;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarAdjudicacionesLotes(SqlConnection Conexion, int pIdLote)
        {
            string sp = "Proc_AdjudicacionesLotesEliminar";
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

        public beAdjudicacionesLotes traerAdjudicacionesLotes_x_IdLote(SqlConnection Conexion, int IdLote)
        {
            string sp = "Proc_AdjudicacionesLotes_x_IdLote";
            beAdjudicacionesLotes obeAdjudicacionesLotes = null;
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
                        int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPantone = datard.GetOrdinal("Pantone");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posImporteMensualCImpuesto = datard.GetOrdinal("ImporteMensualCImpuesto");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");
                        int posTotal = datard.GetOrdinal("Total");
                        int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
                        int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
                        int posIdFrecuencia = datard.GetOrdinal("IdFrecuencia");
                        int posIdMuestra = datard.GetOrdinal("IdMuestra");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        obeAdjudicacionesLotes = new beAdjudicacionesLotes();
                        while (datard.Read())
                        {
                            obeAdjudicacionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeAdjudicacionesLotes.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicacionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeAdjudicacionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeAdjudicacionesLotes.Pantone = datard.GetString(posPantone);
                            obeAdjudicacionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeAdjudicacionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeAdjudicacionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeAdjudicacionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeAdjudicacionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeAdjudicacionesLotes.ImporteMensualCImpuesto = datard.GetDecimal(posImporteMensualCImpuesto);
                            obeAdjudicacionesLotes.MesesServicio = datard.GetInt32(posMesesServicio);
                            obeAdjudicacionesLotes.Total = datard.GetDecimal(posTotal);
                            obeAdjudicacionesLotes.IdMesInicial = datard.GetInt32(posIdMesInicial);
                            obeAdjudicacionesLotes.IdMesFinal = datard.GetString(posIdMesFinal);
                            obeAdjudicacionesLotes.IdFrecuencia = datard.GetInt32(posIdFrecuencia);
                            obeAdjudicacionesLotes.IdMuestra = datard.GetInt32(posIdMuestra);
                            obeAdjudicacionesLotes.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeAdjudicacionesLotes.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeAdjudicacionesLotes;
            }
        }



        public List<beAdjudicacionesLotes> listarTodos_AdjudicacionesLotes(SqlConnection Conexion)
        {
            string sp = "Proc_AdjudicacionesLotes_Traer_Todos";
            List<beAdjudicacionesLotes> lbeAdjudicacionesLotes = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPantone = datard.GetOrdinal("Pantone");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posImporteMensualCImpuesto = datard.GetOrdinal("ImporteMensualCImpuesto");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");
                        int posTotal = datard.GetOrdinal("Total");
                        int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
                        int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
                        int posIdFrecuencia = datard.GetOrdinal("IdFrecuencia");
                        int posIdMuestra = datard.GetOrdinal("IdMuestra");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        lbeAdjudicacionesLotes = new List<beAdjudicacionesLotes>();
                        beAdjudicacionesLotes obeAdjudicacionesLotes;
                        while (datard.Read())
                        {
                            obeAdjudicacionesLotes = new beAdjudicacionesLotes();
                            obeAdjudicacionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeAdjudicacionesLotes.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicacionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeAdjudicacionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeAdjudicacionesLotes.Pantone = datard.GetString(posPantone);
                            obeAdjudicacionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeAdjudicacionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeAdjudicacionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeAdjudicacionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeAdjudicacionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeAdjudicacionesLotes.ImporteMensualCImpuesto = datard.GetDecimal(posImporteMensualCImpuesto);
                            obeAdjudicacionesLotes.MesesServicio = datard.GetInt32(posMesesServicio);
                            obeAdjudicacionesLotes.Total = datard.GetDecimal(posTotal);
                            obeAdjudicacionesLotes.IdMesInicial = datard.GetInt32(posIdMesInicial);
                            obeAdjudicacionesLotes.IdMesFinal = datard.GetString(posIdMesFinal);
                            obeAdjudicacionesLotes.IdFrecuencia = datard.GetInt32(posIdFrecuencia);
                            obeAdjudicacionesLotes.IdMuestra = datard.GetInt32(posIdMuestra);
                            obeAdjudicacionesLotes.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeAdjudicacionesLotes.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            lbeAdjudicacionesLotes.Add(obeAdjudicacionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesLotes;
            }
        }
        public List<beAdjudicacionesLotes> listar_AdjudicacionesLotes_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_AdjudicacionesLotes_TraerTodos_GetAll";
            List<beAdjudicacionesLotes> lbeAdjudicacionesLotes = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPantone = datard.GetOrdinal("Pantone");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posImporteMensualCImpuesto = datard.GetOrdinal("ImporteMensualCImpuesto");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");
                        int posTotal = datard.GetOrdinal("Total");
                        int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
                        int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
                        int posIdFrecuencia = datard.GetOrdinal("IdFrecuencia");
                        int posIdMuestra = datard.GetOrdinal("IdMuestra");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");









                        lbeAdjudicacionesLotes = new List<beAdjudicacionesLotes>();
                        beAdjudicacionesLotes obeAdjudicacionesLotes;
                        while (datard.Read())
                        {
                            obeAdjudicacionesLotes = new beAdjudicacionesLotes();
                            obeAdjudicacionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeAdjudicacionesLotes.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicacionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeAdjudicacionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeAdjudicacionesLotes.Pantone = datard.GetString(posPantone);
                            obeAdjudicacionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeAdjudicacionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeAdjudicacionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeAdjudicacionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeAdjudicacionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeAdjudicacionesLotes.ImporteMensualCImpuesto = datard.GetDecimal(posImporteMensualCImpuesto);
                            obeAdjudicacionesLotes.MesesServicio = datard.GetInt32(posMesesServicio);
                            obeAdjudicacionesLotes.Total = datard.GetDecimal(posTotal);
                            obeAdjudicacionesLotes.IdMesInicial = datard.GetInt32(posIdMesInicial);
                            obeAdjudicacionesLotes.IdMesFinal = datard.GetString(posIdMesFinal);
                            obeAdjudicacionesLotes.IdFrecuencia = datard.GetInt32(posIdFrecuencia);
                            obeAdjudicacionesLotes.IdMuestra = datard.GetInt32(posIdMuestra);
                            obeAdjudicacionesLotes.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeAdjudicacionesLotes.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            // debe agregar campos de la Vista
                            lbeAdjudicacionesLotes.Add(obeAdjudicacionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesLotes;
            }
        }


        // nueva 

        public List<beAdjudicacionesLotes> traerAdjudicacionesLotes_x_IdAdjudicacion(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_AdjudicacionesLotes_x_IdAdjudicacion";
            List<beAdjudicacionesLotes> lbeAdjudicacionesLotes = null;

            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPantone = datard.GetOrdinal("Pantone");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posImporteMensualCImpuesto = datard.GetOrdinal("ImporteMensualCImpuesto");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");
                        int posTotal = datard.GetOrdinal("Total");
                        int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
                        int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
                        int posIdFrecuencia = datard.GetOrdinal("IdFrecuencia");
                        int posIdMuestra = datard.GetOrdinal("IdMuestra");
                        int posCodigo = datard.GetOrdinal("Codigo");
                        int posClaveCubs = datard.GetOrdinal("ClaveCubs");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIdModificador = datard.GetOrdinal("IdModificador");
                        int posIdTipoProducto = datard.GetOrdinal("IdTipoProducto");
                        int posIdMarca = datard.GetOrdinal("IdMarca");
                        int posIdFamilia = datard.GetOrdinal("IdFamilia");
                        int posIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int posIdImpuesto = datard.GetOrdinal("IdImpuesto");
                        int posBsPrecioUnitario = datard.GetOrdinal("BsPrecioUnitario");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posPrecioUnitarioMejorLicitado = datard.GetOrdinal("PrecioUnitarioMejorLicitado");
                        int posIdCertificacion = datard.GetOrdinal("IdCertificacion");
                        int posIdTipoMoneda = datard.GetOrdinal("IdTipoMoneda");
                        int posActivo = datard.GetOrdinal("Activo");
                        int posTipoProducto = datard.GetOrdinal("TipoProducto");
                        int posMarca = datard.GetOrdinal("Marca");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posFamilia = datard.GetOrdinal("Familia");
                        int posImpuesto = datard.GetOrdinal("Impuesto");
                        int posCertificacion = datard.GetOrdinal("Certificacion");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posModificador = datard.GetOrdinal("Modificador");
                        int posMuestra = datard.GetOrdinal("Muestra");
                        int posDescripcionMesInicial = datard.GetOrdinal("DescripcionMesInicial");
                        int posDescripcionMesFinal = datard.GetOrdinal("DescripcionMesFinal");
                        int posDescripcionFrecuencia = datard.GetOrdinal("DescripcionFrecuencia");

                        lbeAdjudicacionesLotes = new List<beAdjudicacionesLotes>();
                        beAdjudicacionesLotes obeAdjudicacionesLotes;
                        while (datard.Read())
                        {
                            obeAdjudicacionesLotes = new beAdjudicacionesLotes();
                            obeAdjudicacionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeAdjudicacionesLotes.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicacionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeAdjudicacionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeAdjudicacionesLotes.Pantone = datard.GetString(posPantone);
                            obeAdjudicacionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeAdjudicacionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeAdjudicacionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeAdjudicacionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeAdjudicacionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeAdjudicacionesLotes.ImporteMensualCImpuesto = datard.GetDecimal(posImporteMensualCImpuesto);
                            obeAdjudicacionesLotes.MesesServicio = datard.GetInt32(posMesesServicio);
                            obeAdjudicacionesLotes.Total = datard.GetDecimal(posTotal);
                            obeAdjudicacionesLotes.IdMesInicial = datard.GetInt32(posIdMesInicial);
                            obeAdjudicacionesLotes.IdMesFinal = datard.GetString(posIdMesFinal);
                            obeAdjudicacionesLotes.IdFrecuencia = datard.GetInt32(posIdFrecuencia);
                            obeAdjudicacionesLotes.IdMuestra = datard.GetInt32(posIdMuestra);
                            obeAdjudicacionesLotes.Codigo = datard.GetString(posCodigo);
                            obeAdjudicacionesLotes.ClaveCubs = datard.GetString(posClaveCubs);
                            obeAdjudicacionesLotes.BienServicio = datard.GetString(posBienServicio);
                            obeAdjudicacionesLotes.Descripcion = datard.GetString(posDescripcion);
                            obeAdjudicacionesLotes.IdModificador = datard.GetInt32(posIdModificador);
                            obeAdjudicacionesLotes.IdTipoProducto = datard.GetInt32(posIdTipoProducto);
                            obeAdjudicacionesLotes.IdMarca = datard.GetInt32(posIdMarca);
                            obeAdjudicacionesLotes.IdFamilia = datard.GetInt32(posIdFamilia);
                            obeAdjudicacionesLotes.IdUnidadMedida = datard.GetInt32(posIdUnidadMedida);
                            obeAdjudicacionesLotes.IdImpuesto = datard.GetInt32(posIdImpuesto);
                            obeAdjudicacionesLotes.BsPrecioUnitario = datard.GetDecimal(posBsPrecioUnitario);
                            obeAdjudicacionesLotes.IdPartida = datard.GetInt32(posIdPartida);
                            obeAdjudicacionesLotes.PrecioUnitarioMejorLicitado = datard.GetDecimal(posPrecioUnitarioMejorLicitado);
                            obeAdjudicacionesLotes.IdCertificacion = datard.GetInt32(posIdCertificacion);
                            obeAdjudicacionesLotes.IdTipoMoneda = datard.GetInt32(posIdTipoMoneda);
                            obeAdjudicacionesLotes.Activo = datard.GetBoolean(posActivo);
                            obeAdjudicacionesLotes.TipoProducto = datard.GetString(posTipoProducto);
                            obeAdjudicacionesLotes.Marca = datard.GetString(posMarca);
                            obeAdjudicacionesLotes.UnidadMedida = datard.GetString(posUnidadMedida);
                            obeAdjudicacionesLotes.Familia = datard.GetString(posFamilia);
                            obeAdjudicacionesLotes.Impuesto = datard.GetString(posImpuesto);
                            obeAdjudicacionesLotes.Certificacion = datard[posCertificacion] == DBNull.Value ? "" : datard.GetString(posCertificacion); //datard.GetString(posCertificacion);
                            obeAdjudicacionesLotes.Partida = datard.GetString(posPartida);
                            obeAdjudicacionesLotes.Modificador = datard.GetString(posModificador);
                            obeAdjudicacionesLotes.Muestra = datard.GetString(posMuestra);
                            obeAdjudicacionesLotes.DescripcionMesInicial = datard.GetString(posDescripcionMesInicial).Trim();
                            obeAdjudicacionesLotes.DescripcionMesFinal = datard.GetString(posDescripcionMesFinal).Trim();
                            obeAdjudicacionesLotes.DescripcionFrecuencia = datard.GetString(posDescripcionFrecuencia).Trim();

                            lbeAdjudicacionesLotes.Add(obeAdjudicacionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesLotes;
            }
        }


        public List<beAdjudicacionesLotes> traerAdjudicacionesProveedoresLotes_x_IdAdjudicacion(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_AdjudicacionesProveedoresLotes_x_IdAdjudicacion";
            List<beAdjudicacionesLotes> lbeAdjudicacionesLotes = null;

            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPantone = datard.GetOrdinal("Pantone");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posPorcentajeImpuesto = datard.GetOrdinal("PorcentajeImpuesto");
                        int posImporteCImpuesto = datard.GetOrdinal("ImporteCImpuesto");
                        int posImporteMensualCImpuesto = datard.GetOrdinal("ImporteMensualCImpuesto");
                        int posMesesServicio = datard.GetOrdinal("MesesServicio");
                        int posTotal = datard.GetOrdinal("Total");
                        int posIdMesInicial = datard.GetOrdinal("IdMesInicial");
                        int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
                        int posIdFrecuencia = datard.GetOrdinal("IdFrecuencia");
                        int posIdMuestra = datard.GetOrdinal("IdMuestra");
                        int posCodigo = datard.GetOrdinal("Codigo");
                        int posClaveCubs = datard.GetOrdinal("ClaveCubs");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIdModificador = datard.GetOrdinal("IdModificador");
                        int posIdTipoProducto = datard.GetOrdinal("IdTipoProducto");
                        int posIdMarca = datard.GetOrdinal("IdMarca");
                        int posIdFamilia = datard.GetOrdinal("IdFamilia");
                        int posIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int posIdImpuesto = datard.GetOrdinal("IdImpuesto");
                        int posBsPrecioUnitario = datard.GetOrdinal("BsPrecioUnitario");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posPrecioUnitarioMejorLicitado = datard.GetOrdinal("PrecioUnitarioMejorLicitado");
                        int posIdCertificacion = datard.GetOrdinal("IdCertificacion");
                        int posIdTipoMoneda = datard.GetOrdinal("IdTipoMoneda");
                        int posActivo = datard.GetOrdinal("Activo");
                        int posTipoProducto = datard.GetOrdinal("TipoProducto");
                        int posMarca = datard.GetOrdinal("Marca");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posFamilia = datard.GetOrdinal("Familia");
                        int posImpuesto = datard.GetOrdinal("Impuesto");
                        int posCertificacion = datard.GetOrdinal("Certificacion");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posModificador = datard.GetOrdinal("Modificador");
                        int posMuestra = datard.GetOrdinal("Muestra");
                        int posDescripcionMesInicial = datard.GetOrdinal("DescripcionMesInicial");
                        int posDescripcionMesFinal = datard.GetOrdinal("DescripcionMesFinal");
                        int posDescripcionFrecuencia = datard.GetOrdinal("DescripcionFrecuencia");
                        int posActivoLote = datard.GetOrdinal("ActivoLote");
                        int posIdAdjudicionPropuestaTecEco = datard.GetOrdinal("IdAdjudicionPropuestaTecEco");
                        int posIdProveedor = datard.GetOrdinal("IdProveedor");

                        lbeAdjudicacionesLotes = new List<beAdjudicacionesLotes>();
                        beAdjudicacionesLotes obeAdjudicacionesLotes;
                        while (datard.Read())
                        {
                            obeAdjudicacionesLotes = new beAdjudicacionesLotes();
                            obeAdjudicacionesLotes.IdLote = datard.GetInt32(posIdLote);
                            obeAdjudicacionesLotes.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            obeAdjudicacionesLotes.NoLote = datard.GetInt32(posNoLote);
                            obeAdjudicacionesLotes.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeAdjudicacionesLotes.Pantone = datard.GetString(posPantone);
                            obeAdjudicacionesLotes.Cantidad = datard.GetDecimal(posCantidad);
                            obeAdjudicacionesLotes.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeAdjudicacionesLotes.Importe = datard.GetDecimal(posImporte);
                            obeAdjudicacionesLotes.PorcentajeImpuesto = datard.GetDecimal(posPorcentajeImpuesto);
                            obeAdjudicacionesLotes.ImporteCImpuesto = datard.GetDecimal(posImporteCImpuesto);
                            obeAdjudicacionesLotes.ImporteMensualCImpuesto = datard.GetDecimal(posImporteMensualCImpuesto);
                            obeAdjudicacionesLotes.MesesServicio = datard.GetInt32(posMesesServicio);
                            obeAdjudicacionesLotes.Total = datard.GetDecimal(posTotal);
                            obeAdjudicacionesLotes.IdMesInicial = datard.GetInt32(posIdMesInicial);
                            obeAdjudicacionesLotes.IdMesFinal = datard.GetString(posIdMesFinal);
                            obeAdjudicacionesLotes.IdFrecuencia = datard.GetInt32(posIdFrecuencia);
                            obeAdjudicacionesLotes.IdMuestra = datard.GetInt32(posIdMuestra);
                            obeAdjudicacionesLotes.Codigo = datard.GetString(posCodigo);
                            obeAdjudicacionesLotes.ClaveCubs = datard.GetString(posClaveCubs);
                            obeAdjudicacionesLotes.BienServicio = datard.GetString(posBienServicio);
                            obeAdjudicacionesLotes.Descripcion = datard.GetString(posDescripcion);
                            obeAdjudicacionesLotes.IdModificador = datard.GetInt32(posIdModificador);
                            obeAdjudicacionesLotes.IdTipoProducto = datard.GetInt32(posIdTipoProducto);
                            obeAdjudicacionesLotes.IdMarca = datard.GetInt32(posIdMarca);
                            obeAdjudicacionesLotes.IdFamilia = datard.GetInt32(posIdFamilia);
                            obeAdjudicacionesLotes.IdUnidadMedida = datard.GetInt32(posIdUnidadMedida);
                            obeAdjudicacionesLotes.IdImpuesto = datard.GetInt32(posIdImpuesto);
                            obeAdjudicacionesLotes.BsPrecioUnitario = datard.GetDecimal(posBsPrecioUnitario);
                            obeAdjudicacionesLotes.IdPartida = datard.GetInt32(posIdPartida);
                            obeAdjudicacionesLotes.PrecioUnitarioMejorLicitado = datard.GetDecimal(posPrecioUnitarioMejorLicitado);
                            obeAdjudicacionesLotes.IdCertificacion = datard.GetInt32(posIdCertificacion);
                            obeAdjudicacionesLotes.IdTipoMoneda = datard.GetInt32(posIdTipoMoneda);
                            obeAdjudicacionesLotes.Activo = datard.GetBoolean(posActivo);
                            obeAdjudicacionesLotes.TipoProducto = datard.GetString(posTipoProducto);
                            obeAdjudicacionesLotes.Marca = datard.GetString(posMarca);
                            obeAdjudicacionesLotes.UnidadMedida = datard.GetString(posUnidadMedida);
                            obeAdjudicacionesLotes.Familia = datard.GetString(posFamilia);
                            obeAdjudicacionesLotes.Impuesto = datard.GetString(posImpuesto);
                            obeAdjudicacionesLotes.Certificacion = datard[posCertificacion] == DBNull.Value ? "" : datard.GetString(posCertificacion); //datard.GetString(posCertificacion);
                            obeAdjudicacionesLotes.Partida = datard.GetString(posPartida);
                            obeAdjudicacionesLotes.Modificador = datard.GetString(posModificador);
                            obeAdjudicacionesLotes.Muestra = datard.GetString(posMuestra);
                            obeAdjudicacionesLotes.DescripcionMesInicial = datard.GetString(posDescripcionMesInicial);
                            obeAdjudicacionesLotes.DescripcionMesFinal = datard.GetString(posDescripcionMesFinal);
                            obeAdjudicacionesLotes.DescripcionFrecuencia = datard.GetString(posDescripcionFrecuencia);
                            obeAdjudicacionesLotes.ActivoLote = datard.GetBoolean(posActivoLote);
                            obeAdjudicacionesLotes.IdAdjudicionPropuestaTecEco = datard.GetInt32(posIdAdjudicionPropuestaTecEco);
                            obeAdjudicacionesLotes.IdProveedor = datard.GetInt32(posIdProveedor);

                            lbeAdjudicacionesLotes.Add(obeAdjudicacionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesLotes;
            }
        }




        public List<beGenerica> listarTodos_AdjudicacionesLotes_x_IdPartida_BienServicio(SqlConnection Conexion, beGenerica oGenerica)
        {
            string sp = "Proc_AdjudicacionesLotes_Traer_x_IdPartida_BienServicio";
            List<beGenerica> lbeAdjudicacionesLotes = null;
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

                        lbeAdjudicacionesLotes = new List<beGenerica>();
                        beGenerica obeAdjudicacionesLotes;
                        while (datard.Read())
                        {
                            obeAdjudicacionesLotes = new beGenerica();
                            obeAdjudicacionesLotes.entero = datard.GetInt32(pIdBienServicio);
                            obeAdjudicacionesLotes.entero2 = datard.GetInt32(pIdUnidadMedida);
                            obeAdjudicacionesLotes.entero3 = datard.GetInt32(pIdImpuesto);
                            obeAdjudicacionesLotes.string1 = datard.GetString(pCodigo);
                            obeAdjudicacionesLotes.string2 = datard.GetString(pDescripcion);
                            obeAdjudicacionesLotes.decimal1 = datard.GetDecimal(pPrecioUnitario);
                            obeAdjudicacionesLotes.string3 = datard.GetString(pUnidadMedida);
                            obeAdjudicacionesLotes.decimal2 = datard.GetDecimal(pTasa);
                            obeAdjudicacionesLotes.string4 = datard.GetString(pDescripcionImpuesto);
                            obeAdjudicacionesLotes.bool1 = datard.GetBoolean(pActivo);
                            obeAdjudicacionesLotes.string5 = datard.GetString(pBienServicio);
                            lbeAdjudicacionesLotes.Add(obeAdjudicacionesLotes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesLotes;
            }
        }

        public beGenerica traerAdjudicacionesLotes_x_IdBienServicio(SqlConnection Conexion, int IdBienServicio)
        {
            string sp = "Proc_AdjudicacionesLotes_Traer_x_IdBienServicio";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = IdBienServicio;
            beGenerica obeAdjudicacionesLotes = new beGenerica();
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
                            obeAdjudicacionesLotes = new beGenerica();
                            obeAdjudicacionesLotes.entero = datard.GetInt32(pIdBienServicio);
                            obeAdjudicacionesLotes.entero2 = datard.GetInt32(pIdUnidadMedida);
                            obeAdjudicacionesLotes.entero3 = datard.GetInt32(pIdImpuesto);
                            obeAdjudicacionesLotes.string1 = datard.GetString(pCodigo);
                            obeAdjudicacionesLotes.string2 = datard.GetString(pDescripcion);
                            obeAdjudicacionesLotes.decimal1 = datard.GetDecimal(pPrecioUnitario);
                            obeAdjudicacionesLotes.string3 = datard.GetString(pUnidadMedida);
                            obeAdjudicacionesLotes.decimal2 = datard.GetDecimal(pTasa);
                            obeAdjudicacionesLotes.string4 = datard.GetString(pDescripcionImpuesto);
                            obeAdjudicacionesLotes.bool1 = datard.GetBoolean(pActivo);


                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeAdjudicacionesLotes;
            }
        }




    }
}
