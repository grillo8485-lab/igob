using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daClavesPresupuestalesDetalles
 {
    public int guardarClavesPresupuestalesDetalles(SqlConnection Conexion, beClavesPresupuestalesDetalles obeClavesPresupuestalesDetalles)
    {
        int Id = 0;
        string sp = "Proc_ClavesPresupuestalesDetallesInsertar";
        using (SqlCommand cmd = new SqlCommand(sp, Conexion))
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdClavePresupuestalDetalle", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdClavePresupuestalDetalle;
                cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdPresupuestoPartida;
                cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdOrigenRecurso;
                cmd.Parameters.Add("@IdMesInicio", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdMesInicio;
                cmd.Parameters.Add("@IdMesFinal", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdMesFinal;
                cmd.Parameters.Add("@ClavePresupuestal", SqlDbType.VarChar).Value = obeClavesPresupuestalesDetalles.ClavePresupuestal;
                cmd.Parameters.Add("@MontoPresupuestado", SqlDbType.Decimal).Value = obeClavesPresupuestalesDetalles.MontoPresupuestado;
                cmd.Parameters.Add("@MontoComprometido", SqlDbType.Decimal).Value = obeClavesPresupuestalesDetalles.MontoComprometido;
                cmd.Parameters.Add("@MontoDisponible", SqlDbType.Decimal).Value = obeClavesPresupuestalesDetalles.MontoDisponible;
                cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdUsuarioRegistro;
                cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeClavesPresupuestalesDetalles.FechaRegistro;

                Id = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
    }

    public int actualizarClavesPresupuestalesDetalles(SqlConnection Conexion, beClavesPresupuestalesDetalles obeClavesPresupuestalesDetalles)
    {
        string sp = "Proc_ClavesPresupuestalesDetallesActualizar";
        using (SqlCommand cmd = new SqlCommand(sp, Conexion))
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdClavePresupuestalDetalle", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdClavePresupuestalDetalle;
                cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdPresupuestoPartida;
                cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdOrigenRecurso;
                cmd.Parameters.Add("@IdMesInicio", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdMesInicio;
                cmd.Parameters.Add("@IdMesFinal", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdMesFinal;
                cmd.Parameters.Add("@ClavePresupuestal", SqlDbType.VarChar).Value = obeClavesPresupuestalesDetalles.ClavePresupuestal;
                cmd.Parameters.Add("@MontoPresupuestado", SqlDbType.Decimal).Value = obeClavesPresupuestalesDetalles.MontoPresupuestado;
                cmd.Parameters.Add("@MontoComprometido", SqlDbType.Decimal).Value = obeClavesPresupuestalesDetalles.MontoComprometido;
                cmd.Parameters.Add("@MontoDisponible", SqlDbType.Decimal).Value = obeClavesPresupuestalesDetalles.MontoDisponible;
                cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeClavesPresupuestalesDetalles.IdUsuarioRegistro;
                cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeClavesPresupuestalesDetalles.FechaRegistro;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }
    }

    public int eliminarClavesPresupuestalesDetalles(SqlConnection Conexion, int pIdClavePresupuestalDetalle)
    {
        string sp = "Proc_ClavesPresupuestalesDetallesEliminar";
        using (SqlCommand cmd = new SqlCommand(sp, Conexion))
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdClavePresupuestalDetalle", SqlDbType.Int).Value = pIdClavePresupuestalDetalle;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }
    }

    public beClavesPresupuestalesDetalles traerClavesPresupuestalesDetalles_x_IdClavePresupuestalDetalle(SqlConnection Conexion, int IdClavePresupuestalDetalle)
    {
        string sp = "Proc_ClavesPresupuestalesDetalles_x_IdClavePresupuestalDetalle";
        beClavesPresupuestalesDetalles obeClavesPresupuestalesDetalles = null;
        SqlCommand cmd = new SqlCommand(sp, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@IdClavePresupuestalDetalle", SqlDbType.Int).Value = IdClavePresupuestalDetalle;
        using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            try
            {
                if (datard != null)
                {
                    int posIdClavePresupuestalDetalle = datard.GetOrdinal("IdClavePresupuestalDetalle");
                    int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                    int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                    int posIdMesInicio = datard.GetOrdinal("IdMesInicio");
                    int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
                    int posClavePresupuestal = datard.GetOrdinal("ClavePresupuestal");
                    int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                    int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                    int posMontoDisponible = datard.GetOrdinal("MontoDisponible");
                    int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                    int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                    obeClavesPresupuestalesDetalles = new beClavesPresupuestalesDetalles();
                    while (datard.Read())
                    {
                        obeClavesPresupuestalesDetalles.IdClavePresupuestalDetalle = datard.GetInt32(posIdClavePresupuestalDetalle);
                        obeClavesPresupuestalesDetalles.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                        obeClavesPresupuestalesDetalles.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                        obeClavesPresupuestalesDetalles.IdMesInicio = datard.GetInt32(posIdMesInicio);
                        obeClavesPresupuestalesDetalles.IdMesFinal = datard.GetInt32(posIdMesFinal);
                        obeClavesPresupuestalesDetalles.ClavePresupuestal = datard.GetString(posClavePresupuestal);
                        obeClavesPresupuestalesDetalles.MontoPresupuestado = datard.GetDecimal(posMontoPresupuestado);
                        obeClavesPresupuestalesDetalles.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                        obeClavesPresupuestalesDetalles.MontoDisponible = datard.GetDecimal(posMontoDisponible);
                        obeClavesPresupuestalesDetalles.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                        obeClavesPresupuestalesDetalles.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obeClavesPresupuestalesDetalles;
        }
    }

    public List<beClavesPresupuestalesDetalles> listarTodos_ClavesPresupuestalesDetalles(SqlConnection Conexion)
    {
        string sp = "Proc_ClavesPresupuestalesDetalles_Traer_Todos";
        List<beClavesPresupuestalesDetalles> lbeClavesPresupuestalesDetalles = null;
        SqlCommand cmd = new SqlCommand(sp, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            try
            {
                if (datard != null)
                {
                    int posIdClavePresupuestalDetalle = datard.GetOrdinal("IdClavePresupuestalDetalle");
                    int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                    int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                    int posIdMesInicio = datard.GetOrdinal("IdMesInicio");
                    int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
                    int posClavePresupuestal = datard.GetOrdinal("ClavePresupuestal");
                    int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                    int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                    int posMontoDisponible = datard.GetOrdinal("MontoDisponible");
                    int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                    int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                    lbeClavesPresupuestalesDetalles = new List<beClavesPresupuestalesDetalles>();
                    beClavesPresupuestalesDetalles obeClavesPresupuestalesDetalles;
                    while (datard.Read())
                    {
                        obeClavesPresupuestalesDetalles = new beClavesPresupuestalesDetalles();
                        obeClavesPresupuestalesDetalles.IdClavePresupuestalDetalle = datard.GetInt32(posIdClavePresupuestalDetalle);
                        obeClavesPresupuestalesDetalles.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                        obeClavesPresupuestalesDetalles.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                        obeClavesPresupuestalesDetalles.IdMesInicio = datard.GetInt32(posIdMesInicio);
                        obeClavesPresupuestalesDetalles.IdMesFinal = datard.GetInt32(posIdMesFinal);
                        obeClavesPresupuestalesDetalles.ClavePresupuestal = datard.GetString(posClavePresupuestal);
                        obeClavesPresupuestalesDetalles.MontoPresupuestado = datard.GetDecimal(posMontoPresupuestado);
                        obeClavesPresupuestalesDetalles.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                        obeClavesPresupuestalesDetalles.MontoDisponible = datard.GetDecimal(posMontoDisponible);
                        obeClavesPresupuestalesDetalles.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                        obeClavesPresupuestalesDetalles.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        lbeClavesPresupuestalesDetalles.Add(obeClavesPresupuestalesDetalles);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeClavesPresupuestalesDetalles;
        }
    }

    public List<beClavesPresupuestalesDetalles> listar_ClavesPresupuestalesDetalles_GetAll(SqlConnection Conexion)
    {
        string sp = "Proc_ClavesPresupuestalesDetalles_TraerTodos_GetAll";
        List<beClavesPresupuestalesDetalles> lbeClavesPresupuestalesDetalles = null;
        SqlCommand cmd = new SqlCommand(sp, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            try
            {
                if (datard != null)
                {
                    int posIdClavePresupuestalDetalle = datard.GetOrdinal("IdClavePresupuestalDetalle");
                    int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                    int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                    int posIdMesInicio = datard.GetOrdinal("IdMesInicio");
                    int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
                    int posClavePresupuestal = datard.GetOrdinal("ClavePresupuestal");
                    int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                    int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                    int posMontoDisponible = datard.GetOrdinal("MontoDisponible");
                    int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                    int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                    lbeClavesPresupuestalesDetalles = new List<beClavesPresupuestalesDetalles>();
                    beClavesPresupuestalesDetalles obeClavesPresupuestalesDetalles;
                    while (datard.Read())
                    {
                        obeClavesPresupuestalesDetalles = new beClavesPresupuestalesDetalles();
                        obeClavesPresupuestalesDetalles.IdClavePresupuestalDetalle = datard.GetInt32(posIdClavePresupuestalDetalle);
                        obeClavesPresupuestalesDetalles.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                        obeClavesPresupuestalesDetalles.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                        obeClavesPresupuestalesDetalles.IdMesInicio = datard.GetInt32(posIdMesInicio);
                        obeClavesPresupuestalesDetalles.IdMesFinal = datard.GetInt32(posIdMesFinal);
                        obeClavesPresupuestalesDetalles.ClavePresupuestal = datard.GetString(posClavePresupuestal);
                        obeClavesPresupuestalesDetalles.MontoPresupuestado = datard.GetDecimal(posMontoPresupuestado);
                        obeClavesPresupuestalesDetalles.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                        obeClavesPresupuestalesDetalles.MontoDisponible = datard.GetDecimal(posMontoDisponible);
                        obeClavesPresupuestalesDetalles.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                        obeClavesPresupuestalesDetalles.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        // debe agregar campos de la Vista
                        lbeClavesPresupuestalesDetalles.Add(obeClavesPresupuestalesDetalles);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeClavesPresupuestalesDetalles;
        }
    }

        public DataTable listarClavesPresupuestalesDetalles_x_(SqlConnection Conexion,int IdClavePresupuestalDetalle)
	    {
	        string sp = "Proc_ClavesPresupuestalesDetalles_Traer_Todos";
	        DataTable dtClavesPresupuestalesDetalles = null;
	        SqlCommand cmd = new SqlCommand(sp,Conexion);
	        cmd.CommandType = CommandType.StoredProcedure;
	        cmd.Parameters.Add("@IdClavePresupuestalDetalle", SqlDbType.Int).Value = IdClavePresupuestalDetalle;
	        using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
	        {
	            try {
		            if (datard != null)
		            {
			            dtClavesPresupuestalesDetalles = new DataTable();
			            dtClavesPresupuestalesDetalles.Load(datard);
		            }
	            }
	            catch (Exception ex) {
		            throw ex;
	            }
		        return dtClavesPresupuestalesDetalles;
	        }
        }

        public List<beClavesPresupuestalesDetalles> traer_ClavesPresupuestalesDetalles_x_IdClavePresupuestalDetalle(SqlConnection Conexion, int IdPresupuestoPartida)
    {
            string sp = "Proc_ClavePresupuestalDetalle_traer_IdPresupuestoPartida";
            List<beClavesPresupuestalesDetalles> lbeClavesPresupuestalesDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPresuestoPartida", SqlDbType.Int).Value = IdPresupuestoPartida;

        using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdClavePresupuestalDetalle = datard.GetOrdinal("IdClavePresupuestalDetalle");
                        int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        int posIdOrigenRecurso = datard.GetOrdinal("IdOrigenRecurso");
                        int posIdMesInicio = datard.GetOrdinal("IdMesInicio");
                        int posIdMesFinal = datard.GetOrdinal("IdMesFinal");
                        int posClavePresupuestal = datard.GetOrdinal("ClavePresupuestal");
                        int posMontoPresupuestado = datard.GetOrdinal("MontoPresupuestado");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posMontoDisponible = datard.GetOrdinal("MontoDisponible");

                        int posMesInicial = datard.GetOrdinal("MesInicial");
                        int posMesFinal = datard.GetOrdinal("MesFinal");
                        int posOrigenRecurso = datard.GetOrdinal("OrigenRecurso");

                        lbeClavesPresupuestalesDetalles = new List<beClavesPresupuestalesDetalles>();
                        beClavesPresupuestalesDetalles obeClavesPresupuestalesDetalles;

                        while (datard.Read())
                        {
                            obeClavesPresupuestalesDetalles = new beClavesPresupuestalesDetalles();
                            obeClavesPresupuestalesDetalles.IdClavePresupuestalDetalle = datard.GetInt32(posIdClavePresupuestalDetalle);
                            obeClavesPresupuestalesDetalles.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            obeClavesPresupuestalesDetalles.IdOrigenRecurso = datard.GetInt32(posIdOrigenRecurso);
                            obeClavesPresupuestalesDetalles.IdMesInicio = datard.GetInt32(posIdMesInicio);
                            obeClavesPresupuestalesDetalles.IdMesFinal = datard.GetInt32(posIdMesFinal);
                            obeClavesPresupuestalesDetalles.ClavePresupuestal = datard.GetString(posClavePresupuestal);
                            obeClavesPresupuestalesDetalles.MontoPresupuestado = datard.GetDecimal(posMontoPresupuestado);
                            obeClavesPresupuestalesDetalles.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obeClavesPresupuestalesDetalles.MontoDisponible = datard.GetDecimal(posMontoDisponible);

                            obeClavesPresupuestalesDetalles.MesInicial = datard.GetString(posMesInicial);
                            obeClavesPresupuestalesDetalles.MesFinal = datard.GetString(posMesFinal);
                            obeClavesPresupuestalesDetalles.OrigenRecurso = datard.GetString(posOrigenRecurso);


                            lbeClavesPresupuestalesDetalles.Add(obeClavesPresupuestalesDetalles);


                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeClavesPresupuestalesDetalles;
            }
        }

        public int eliminarClavesPresupuestalesDetalles_x_IdPresupuestoPartida(SqlConnection Conexion, int IdPresupuestoPartida)
        {
            string sp = "Proc_ClavesPresupuestalesDetallesEliminar_x_IdPresupuestoPartida";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = IdPresupuestoPartida;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

    }
}
