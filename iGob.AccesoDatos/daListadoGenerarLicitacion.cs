using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.AccesoDatos
{
    public class daListadoGenerarLicitacion
    {
        public List<beListadoGenerarLicitacion> ListadoGenerarLicitacion(SqlConnection Conexion,int IdTipoLicitacion, int IdEjercicioFiscal,int IdUsuarioRevisor, int IdTipoRequisicion)
        {
            List<beListadoGenerarLicitacion> listadoGenerarlicitacion = new List<beListadoGenerarLicitacion>();
            string sp = "Proc_Requisiciones_Traer_AutorizadaLicitacion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = IdTipoLicitacion;
            cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = IdEjercicioFiscal;
            cmd.Parameters.Add("@IdUsuarioRevisor", SqlDbType.Int).Value = IdUsuarioRevisor;
            cmd.Parameters.Add("@IdTipoRequisicion", SqlDbType.Int).Value = IdTipoRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard.FieldCount > 0)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdRequisicionOrigen = datard.GetOrdinal("IdRequisicionOrigen");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdTipoRequisicion = datard.GetOrdinal("IdTipoRequisicion");
                        int posIdTipoSolicitud = datard.GetOrdinal("IdTipoSolicitud");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdOrigenRecursoAutorizado = datard.GetOrdinal("IdOrigenRecursoAutorizado");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posMontoAproximado = datard.GetOrdinal("MontoAproximado");
                        int posMontoAproximadoAutorizado = datard.GetOrdinal("MontoAproximadoAutorizado");
                        int posIdUsuarioRevisor = datard.GetOrdinal("IdUsuarioRevisor");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posClavePartida = datard.GetOrdinal("ClavePartida");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posTipoSolicitud = datard.GetOrdinal("TipoSolicitud");
                        int posSeleccionada = datard.GetOrdinal("Seleccionada");
                        int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posLicitacion = datard.GetOrdinal("Licitacion");
                        while (datard.Read())
                        {
                            beListadoGenerarLicitacion ObeListadoGenerarLicitacion = new beListadoGenerarLicitacion();
                            ObeListadoGenerarLicitacion.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            ObeListadoGenerarLicitacion.IdRequisicionOrigen = datard.GetInt32(posIdRequisicionOrigen);
                            ObeListadoGenerarLicitacion.IdDependencia = datard.GetInt32(posIdDependencia);
                            ObeListadoGenerarLicitacion.IdTipoRequisicion = datard.GetInt32(posIdTipoRequisicion);
                            ObeListadoGenerarLicitacion.IdTipoSolicitud = datard.GetInt32(posIdTipoSolicitud);
                            ObeListadoGenerarLicitacion.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            ObeListadoGenerarLicitacion.IdOrigenRecursoAutorizado = datard.GetInt32(posIdOrigenRecursoAutorizado);
                            ObeListadoGenerarLicitacion.IdEstatus = datard.GetInt32(posIdEstatus);
                            ObeListadoGenerarLicitacion.IdPartida = datard.GetInt32(posIdPartida);
                            ObeListadoGenerarLicitacion.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            ObeListadoGenerarLicitacion.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            ObeListadoGenerarLicitacion.MontoAproximado = datard.GetDecimal(posMontoAproximado);
                            ObeListadoGenerarLicitacion.MontoAproximadoAutorizado = datard.GetDecimal(posMontoAproximadoAutorizado);
                            ObeListadoGenerarLicitacion.IdUsuarioRevisor = datard.GetInt32(posIdUsuarioRevisor);
                            ObeListadoGenerarLicitacion.Dependencia = datard.GetString(posDependencia);
                            ObeListadoGenerarLicitacion.ClavePartida = datard.GetString(posClavePartida);
                            ObeListadoGenerarLicitacion.Partida = datard.GetString(posPartida);
                            ObeListadoGenerarLicitacion.TipoSolicitud = datard.GetString(posTipoSolicitud);
                            ObeListadoGenerarLicitacion.Seleccionada = datard.GetInt32(posSeleccionada);
                            ObeListadoGenerarLicitacion.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            ObeListadoGenerarLicitacion.NumeroLicitacion = datard.GetInt32(posNumeroLicitacion);
                            ObeListadoGenerarLicitacion.Licitacion = datard.GetString(posLicitacion);
                            listadoGenerarlicitacion.Add(ObeListadoGenerarLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoGenerarlicitacion;
            }
        }
    }
}
