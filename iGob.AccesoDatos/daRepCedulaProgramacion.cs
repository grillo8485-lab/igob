using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRepCedulaProgramacion
    {
        public beRepCedulaProgramacion traerRep_Cedula_Licitaciones_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Cedula_Licitaciones_x_IdLicitacion";
            beRepCedulaProgramacion obeLicitaciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
                        int posTitulo = datard.GetOrdinal("Titulo");
                        int posModalidad = datard.GetOrdinal("Modalidad");
                        int posNumeroOficial = datard.GetOrdinal("NumeroOficial");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        int posNumeroLicitacion = datard.GetOrdinal("NumeroLicitacion");
                        int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int posFechaPublicacion = datard.GetOrdinal("FechaPublicacion");
                        int posFechaDisposicionBases = datard.GetOrdinal("FechaDisposicionBases");
                        int posFechaLimitePreguntas = datard.GetOrdinal("FechaLimitePreguntas");
                        int posFechaLimiteRespuestas = datard.GetOrdinal("FechaLimiteRespuestas");
                        int posFechaHoraAclaracionDudas = datard.GetOrdinal("FechaHoraAclaracionDudas");
                        int posFechaEnvioPropuestasTecEco = datard.GetOrdinal("FechaEnvioPropuestasTecEco");
                        int posFechaLimiteDictamen = datard.GetOrdinal("FechaLimiteDictamen");
                        int posFechaFallo = datard.GetOrdinal("FechaFallo");
                        int posIdUnidadLicitadora = datard.GetOrdinal("IdUnidadLicitadora");
                        int posUnidadLicitadora = datard.GetOrdinal("UnidadLicitadora");



                        obeLicitaciones = new beRepCedulaProgramacion();
                        while (datard.Read())
                        {
                            obeLicitaciones.IdLicitacion = datard.GetInt32(posIdLicitacion);
                            obeLicitaciones.Titulo = datard.GetString(posTitulo);
                            obeLicitaciones.Modalidad = datard.GetString(posModalidad);
                            obeLicitaciones.NumeroOficial = datard.GetString(posNumeroOficial);
                            obeLicitaciones.Ejercicio = datard.GetInt32(posEjercicio);
                            obeLicitaciones.Tiempo = datard.GetString(posTiempo);
                            obeLicitaciones.NumeroLicitacion = datard.GetString(posNumeroLicitacion);
                            obeLicitaciones.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            obeLicitaciones.FechaPublicacion = datard.GetDateTime(posFechaPublicacion);
                            obeLicitaciones.FechaDisposicionBases = datard.GetDateTime(posFechaDisposicionBases);
                            obeLicitaciones.FechaLimitePreguntas = datard.GetDateTime(posFechaLimitePreguntas);
                            obeLicitaciones.FechaLimiteRespuestas = datard.GetDateTime(posFechaLimiteRespuestas);
                            obeLicitaciones.FechaHoraAclaracionDudas = datard.GetDateTime(posFechaHoraAclaracionDudas);
                            obeLicitaciones.FechaEnvioPropuestasTecEco = datard.GetDateTime(posFechaEnvioPropuestasTecEco);
                            obeLicitaciones.FechaLimiteDictamen = datard.GetDateTime(posFechaLimiteDictamen);
                            obeLicitaciones.FechaFallo = datard.GetDateTime(posFechaFallo);
                            obeLicitaciones.IdUnidadLicitadora = datard.GetInt32(posIdUnidadLicitadora);
                            obeLicitaciones.UnidadLicitadora = datard.GetString(posUnidadLicitadora);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }


        public List<beRepCedulaProgramacion> traerRep_Cedula_Requisiciones_x_IdLicitacion(SqlConnection Conexion, int IdLicitacion)
        {
            string sp = "Proc_Rep_Cedula_Requisiciones_x_IdLicitacion";
            List<beRepCedulaProgramacion> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = IdLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posRecepcion = datard.GetOrdinal("Recepcion");

                        lbeLicitacionesDictamen = new List<beRepCedulaProgramacion>();
                        beRepCedulaProgramacion obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beRepCedulaProgramacion();

                            obeLicitaciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeLicitaciones.Dependencia = datard.GetString(posDependencia);
                            obeLicitaciones.Partida = datard.GetString(posPartida);
                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeLicitaciones.Recepcion = datard.GetString(posRecepcion);

                            lbeLicitacionesDictamen.Add(obeLicitaciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }
    }
}
