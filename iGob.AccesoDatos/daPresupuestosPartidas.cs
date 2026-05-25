using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daPresupuestosPartidas
     {
	    public int guardarPresupuestosPartidas(SqlConnection Conexion, bePresupuestosPartidas obePresupuestosPartidas)
	    {
		    int Id=0;
		    string sp = "Proc_PresupuestosPartidasInsertar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = obePresupuestosPartidas.IdPresupuestoPartida;
				    //cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = obePresupuestosPartidas.IdPresupuesto;
                    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obePresupuestosPartidas.IdDependencia;
                    cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obePresupuestosPartidas.IdEjercicioFiscal;
                    cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obePresupuestosPartidas.IdPartida;
                    cmd.Parameters.Add("@MontoPresupuesto", SqlDbType.Decimal).Value = obePresupuestosPartidas.MontoPresupuesto;
				    cmd.Parameters.Add("@MontoComprometido", SqlDbType.Decimal).Value = obePresupuestosPartidas.MontoComprometido;
				    cmd.Parameters.Add("@MontoEjecutadoTotal", SqlDbType.Decimal).Value = obePresupuestosPartidas.MontoEjecutadoTotal;
				    cmd.Parameters.Add("@MontoSaldo", SqlDbType.Decimal).Value = obePresupuestosPartidas.MontoSaldo;
				    cmd.Parameters.Add("@MontoEconomia", SqlDbType.Decimal).Value = obePresupuestosPartidas.MontoEconomia;
				    cmd.Parameters.Add("@NumeroMinistracion", SqlDbType.Char).Value = obePresupuestosPartidas.NumeroMinistracion;
				    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obePresupuestosPartidas.IdUsuarioRegistro;
				    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obePresupuestosPartidas.FechaRegistro;

                    Id = (int)cmd.ExecuteScalar();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return Id;
			    }
	    }

	    public int actualizarPresupuestosPartidas(SqlConnection Conexion, bePresupuestosPartidas obePresupuestosPartidas)
	    {
		    string sp = "Proc_PresupuestosPartidasActualizar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = obePresupuestosPartidas.IdPresupuestoPartida;
				    //cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = obePresupuestosPartidas.IdPresupuesto;
                    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obePresupuestosPartidas.IdDependencia;
                    cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obePresupuestosPartidas.IdEjercicioFiscal;
                    cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obePresupuestosPartidas.IdPartida;
				    cmd.Parameters.Add("@MontoPresupuesto", SqlDbType.Decimal).Value = obePresupuestosPartidas.MontoPresupuesto;
				    cmd.Parameters.Add("@MontoComprometido", SqlDbType.Decimal).Value = obePresupuestosPartidas.MontoComprometido;
				    cmd.Parameters.Add("@MontoEjecutadoTotal", SqlDbType.Decimal).Value = obePresupuestosPartidas.MontoEjecutadoTotal;
				    cmd.Parameters.Add("@MontoSaldo", SqlDbType.Decimal).Value = obePresupuestosPartidas.MontoSaldo;
				    cmd.Parameters.Add("@MontoEconomia", SqlDbType.Decimal).Value = obePresupuestosPartidas.MontoEconomia;
				    cmd.Parameters.Add("@NumeroMinistracion", SqlDbType.Char).Value = obePresupuestosPartidas.NumeroMinistracion;
				    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obePresupuestosPartidas.IdUsuarioRegistro;
				    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obePresupuestosPartidas.FechaRegistro;
			
				    cmd.ExecuteNonQuery();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return 0;
			}
	    }

	    public int eliminarPresupuestosPartidas(SqlConnection Conexion,int pIdPresupuestoPartida)
	    {
		    string sp = "Proc_PresupuestosPartidasEliminar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = pIdPresupuestoPartida;
				    cmd.ExecuteNonQuery();
				    }
				    catch (Exception ex) {
					    throw ex;
				    }
			    return 0;
			    }
	    }
        
            public bePresupuestosPartidas traerPresupuestosPartidas_x_IdPartida(SqlConnection Conexion, int IdPresupuestoPartida)
        {
            string sp = "Proc_PresupuestosPartidas_x_IdPresupuestoPartida";
            List<bePresupuestosPartidas> lbePresupuestosPartidas = null;
            bePresupuestosPartidas obePresupuestosPartidas = new bePresupuestosPartidas();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = IdPresupuestoPartida;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbePresupuestosPartidas = new List<bePresupuestosPartidas>();
                        int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        //int posIdPresupuesto = datard.GetOrdinal("IdPresupuesto");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posMontoPresupuesto = datard.GetOrdinal("MontoPresupuesto");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posMontoEjecutadoTotal = datard.GetOrdinal("MontoEjecutadoTotal");
                        int posMontoSaldo = datard.GetOrdinal("MontoSaldo");
                        int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
                        int posNumeroMinistracion = datard.GetOrdinal("NumeroMinistracion");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        while (datard.Read())
                        {
                            obePresupuestosPartidas = new bePresupuestosPartidas();
                            obePresupuestosPartidas.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            //obePresupuestosPartidas.IdPresupuesto = datard.GetInt32(posIdPresupuesto);
                            obePresupuestosPartidas.IdDependencia = datard.GetInt32(posIdDependencia);
                            obePresupuestosPartidas.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obePresupuestosPartidas.IdPartida = datard.GetInt32(posIdPartida);
                            obePresupuestosPartidas.MontoPresupuesto = datard.GetDecimal(posMontoPresupuesto);
                            obePresupuestosPartidas.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obePresupuestosPartidas.MontoEjecutadoTotal = datard.GetDecimal(posMontoEjecutadoTotal);
                            obePresupuestosPartidas.MontoSaldo = datard.GetDecimal(posMontoSaldo);
                            obePresupuestosPartidas.MontoEconomia = datard.GetDecimal(posMontoEconomia);
                            obePresupuestosPartidas.NumeroMinistracion = datard.GetString(posNumeroMinistracion);
                            obePresupuestosPartidas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obePresupuestosPartidas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obePresupuestosPartidas;
            }
        }
        public bePresupuestosPartidas traerPresupuestosPartidas_x_IdPresupuestoPartida(SqlConnection Conexion,int IdPresupuestoPartida)
	    {
		    string sp = "Proc_PresupuestosPartidas_x_IdPresupuestoPartida";
		    List<bePresupuestosPartidas> lbePresupuestosPartidas = null;
				    bePresupuestosPartidas obePresupuestosPartidas=new bePresupuestosPartidas();
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    cmd.Parameters.Add("@IdPresupuestoPartida", SqlDbType.Int).Value = IdPresupuestoPartida;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
			    try {
				    if (datard != null)
				    {
				    lbePresupuestosPartidas = new List<bePresupuestosPartidas>();
                        int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posMontoPresupuesto = datard.GetOrdinal("MontoPresupuesto");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posMontoEjecutadoTotal = datard.GetOrdinal("MontoEjecutadoTotal");
                        int posMontoSaldo = datard.GetOrdinal("MontoSaldo");
                        int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
                        int posNumeroMinistracion = datard.GetOrdinal("NumeroMinistracion");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        while (datard.Read())
					    {

                            obePresupuestosPartidas = new bePresupuestosPartidas();
                            obePresupuestosPartidas.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            obePresupuestosPartidas.IdDependencia = datard.GetInt32(posIdDependencia);
                            obePresupuestosPartidas.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obePresupuestosPartidas.IdPartida = datard.GetInt32(posIdPartida);
                            obePresupuestosPartidas.MontoPresupuesto = datard.GetDecimal(posMontoPresupuesto);
                            obePresupuestosPartidas.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obePresupuestosPartidas.MontoEjecutadoTotal = datard.GetDecimal(posMontoEjecutadoTotal);
                            obePresupuestosPartidas.MontoSaldo = datard.GetDecimal(posMontoSaldo);
                            obePresupuestosPartidas.MontoEconomia = datard.GetDecimal(posMontoEconomia);
                            obePresupuestosPartidas.NumeroMinistracion = datard.GetString(posNumeroMinistracion);
                            obePresupuestosPartidas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obePresupuestosPartidas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            lbePresupuestosPartidas.Add(obePresupuestosPartidas);
					    }
				    }
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obePresupuestosPartidas;
			    }
	    }

        public List< bePresupuestosPartidas> listarTodos_PresupuestosPartidas(SqlConnection Conexion)
	     {
		    string sp = "Proc_PresupuestosPartidas_Traer_Todos";
		    List<bePresupuestosPartidas> lbePresupuestosPartidas = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
						    //int posIdPresupuesto = datard.GetOrdinal("IdPresupuesto");
                            int posIdDependencia = datard.GetOrdinal("IdDependencia");
                            int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                            int posIdPartida = datard.GetOrdinal("IdPartida");
						    int posMontoPresupuesto = datard.GetOrdinal("MontoPresupuesto");
						    int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
						    int posMontoEjecutadoTotal = datard.GetOrdinal("MontoEjecutadoTotal");
						    int posMontoSaldo = datard.GetOrdinal("MontoSaldo");
						    int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
						    int posNumeroMinistracion = datard.GetOrdinal("NumeroMinistracion");
						    int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						    int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				    lbePresupuestosPartidas = new List<bePresupuestosPartidas>();
				    bePresupuestosPartidas obePresupuestosPartidas;
				    while (datard.Read())
				    {
					     obePresupuestosPartidas = new bePresupuestosPartidas();
					    obePresupuestosPartidas.IdPresupuestoPartida =  datard.GetInt32(posIdPresupuestoPartida);
					    //obePresupuestosPartidas.IdPresupuesto =  datard.GetInt32(posIdPresupuesto);
                        obePresupuestosPartidas.IdDependencia = datard.GetInt32(posIdDependencia);
                        obePresupuestosPartidas.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                        obePresupuestosPartidas.IdPartida =  datard.GetInt32(posIdPartida);
					    obePresupuestosPartidas.MontoPresupuesto =  datard.GetDecimal(posMontoPresupuesto);
					    obePresupuestosPartidas.MontoComprometido =  datard.GetDecimal(posMontoComprometido);
					    obePresupuestosPartidas.MontoEjecutadoTotal =  datard.GetDecimal(posMontoEjecutadoTotal);
					    obePresupuestosPartidas.MontoSaldo =  datard.GetDecimal(posMontoSaldo);
					    obePresupuestosPartidas.MontoEconomia =  datard.GetDecimal(posMontoEconomia);
					    obePresupuestosPartidas.NumeroMinistracion =  datard.GetString(posNumeroMinistracion);
					    obePresupuestosPartidas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					    obePresupuestosPartidas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					    lbePresupuestosPartidas.Add(obePresupuestosPartidas);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbePresupuestosPartidas;
		    }
	    }
	    public List< bePresupuestosPartidas> listar_PresupuestosPartidas_GetAll(SqlConnection Conexion)
	     {
		    string sp = "Proc_PresupuestosPartidas_TraerTodos_GetAll";
		    List<bePresupuestosPartidas> lbePresupuestosPartidas = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
					int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
					//int posIdPresupuesto = datard.GetOrdinal("IdPresupuesto");
                    int posIdDependencia = datard.GetOrdinal("IdDependencia");
                    int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                    int posIdPartida = datard.GetOrdinal("IdPartida");
					int posMontoPresupuesto = datard.GetOrdinal("MontoPresupuesto");
					int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
					int posMontoEjecutadoTotal = datard.GetOrdinal("MontoEjecutadoTotal");
					int posMontoSaldo = datard.GetOrdinal("MontoSaldo");
					int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
					int posNumeroMinistracion = datard.GetOrdinal("NumeroMinistracion");

                    int posDependencia = datard.GetOrdinal("Dependencia");
                    int posCapitulo = datard.GetOrdinal("Capitulo");
                    int posPartida = datard.GetOrdinal("Partida");
                    int posEjercicio = datard.GetOrdinal("Ejercicio");
                        

				    lbePresupuestosPartidas = new List<bePresupuestosPartidas>();
				    bePresupuestosPartidas obePresupuestosPartidas;
				    while (datard.Read())
				    {
					     obePresupuestosPartidas = new bePresupuestosPartidas();
					    obePresupuestosPartidas.IdPresupuestoPartida =  datard.GetInt32(posIdPresupuestoPartida);
					    //obePresupuestosPartidas.IdPresupuesto =  datard.GetInt32(posIdPresupuesto);
                        obePresupuestosPartidas.IdDependencia = datard.GetInt32(posIdDependencia);
                        obePresupuestosPartidas.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                        obePresupuestosPartidas.IdPartida =  datard.GetInt32(posIdPartida);
					    obePresupuestosPartidas.MontoPresupuesto =  datard.GetDecimal(posMontoPresupuesto);
					    obePresupuestosPartidas.MontoComprometido =  datard.GetDecimal(posMontoComprometido);
					    obePresupuestosPartidas.MontoEjecutadoTotal =  datard.GetDecimal(posMontoEjecutadoTotal);
					    obePresupuestosPartidas.MontoSaldo =  datard.GetDecimal(posMontoSaldo);
					    obePresupuestosPartidas.MontoEconomia =  datard.GetDecimal(posMontoEconomia);
					    obePresupuestosPartidas.NumeroMinistracion =  datard.GetString(posNumeroMinistracion);
                        obePresupuestosPartidas.Dependencia = datard.GetString(posDependencia);
                        obePresupuestosPartidas.Capitulo = datard.GetString(posCapitulo);
                        obePresupuestosPartidas.Partida = datard.GetString(posPartida);
                        obePresupuestosPartidas.Ejercicio = datard.GetInt32(posEjercicio);

                            // debe agregar campos de la Vista
                            lbePresupuestosPartidas.Add(obePresupuestosPartidas);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbePresupuestosPartidas;
		    }
	    }
        public List<bePresupuestosPartidas> PresupuestosPartidas_Traer_Dependencia(SqlConnection Conexion, int IdDependencia)
        {
            string sp = "Proc_PresupuestosPartidas_Traer_Dependencia";
            List<bePresupuestosPartidas> lbePresupuestosPartidas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = IdDependencia;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        //int posIdPresupuesto = datard.GetOrdinal("IdPresupuesto");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posMontoPresupuesto = datard.GetOrdinal("MontoPresupuesto");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posMontoEjecutadoTotal = datard.GetOrdinal("MontoEjecutadoTotal");
                        int posMontoSaldo = datard.GetOrdinal("MontoSaldo");
                        int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
                        int posNumeroMinistracion = datard.GetOrdinal("NumeroMinistracion");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        int posMontoPresupuestoTotal = datard.GetOrdinal("MontoPresupuestoTotal");
                        int posPreMontoComprometido = datard.GetOrdinal("PreMontoComprometido");
                        int posPreMontoEjecutadoTotal = datard.GetOrdinal("PreMontoEjecutadoTotal");
                        int posPreMontoSaldo = datard.GetOrdinal("PreMontoSaldo");
                        int posPreMontoEconomia = datard.GetOrdinal("PreMontoEconomia");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posCapitulo = datard.GetOrdinal("Capitulo");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posPartida = datard.GetOrdinal("Partida");

                        lbePresupuestosPartidas = new List<bePresupuestosPartidas>();
                        bePresupuestosPartidas obePresupuestosPartidas;
                        while (datard.Read())
                        {
                            obePresupuestosPartidas = new bePresupuestosPartidas();
                            obePresupuestosPartidas.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            //obePresupuestosPartidas.IdPresupuesto = datard.GetInt32(posIdPresupuesto);
                            obePresupuestosPartidas.IdPartida = datard.GetInt32(posIdPartida);
                            obePresupuestosPartidas.MontoPresupuesto = datard.GetDecimal(posMontoPresupuesto);
                            obePresupuestosPartidas.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obePresupuestosPartidas.MontoEjecutadoTotal = datard.GetDecimal(posMontoEjecutadoTotal);
                            obePresupuestosPartidas.MontoSaldo = datard.GetDecimal(posMontoSaldo);
                            obePresupuestosPartidas.MontoEconomia = datard.GetDecimal(posMontoEconomia);
                            obePresupuestosPartidas.NumeroMinistracion = datard.GetString(posNumeroMinistracion);
                            obePresupuestosPartidas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obePresupuestosPartidas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            // debe agregar campos de la Vista
                            obePresupuestosPartidas.IdDependencia = datard.GetInt32(posIdDependencia);
                            obePresupuestosPartidas.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            obePresupuestosPartidas.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            obePresupuestosPartidas.MontoPresupuestoTotal = datard.GetDecimal(posMontoPresupuestoTotal);
                            obePresupuestosPartidas.PreMontoComprometido = datard.GetDecimal(posPreMontoComprometido);
                            obePresupuestosPartidas.PreMontoEjecutadoTotal = datard.GetDecimal(posPreMontoEjecutadoTotal);
                            obePresupuestosPartidas.PreMontoSaldo = datard.GetDecimal(posPreMontoSaldo);
                            obePresupuestosPartidas.PreMontoEconomia = datard.GetDecimal(posPreMontoEconomia);
                            obePresupuestosPartidas.Dependencia = datard.GetString(posDependencia);
                            obePresupuestosPartidas.Capitulo = datard.GetString(posCapitulo);
                            obePresupuestosPartidas.Ejercicio = datard.GetInt32(posEjercicio);
                            obePresupuestosPartidas.Partida = datard.GetString(posPartida);
                            lbePresupuestosPartidas.Add(obePresupuestosPartidas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePresupuestosPartidas;
            }
        }

        public bePresupuestosPartidas PresupuestosPartidas_Traer_IdDependencia_IdPartida(SqlConnection Conexion, int IdDependencia, int IdPartida)
        {
            string sp = "Proc_PresupuestosPartidas_x_IdDependenciaIdPartida";
            bePresupuestosPartidas obePresupuestosPartidas = new bePresupuestosPartidas();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = IdDependencia;
            cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = IdPartida;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPresupuestoPartida = datard.GetOrdinal("IdPresupuestoPartida");
                        //int posIdPresupuesto = datard.GetOrdinal("IdPresupuesto");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posMontoPresupuesto = datard.GetOrdinal("MontoPresupuesto");
                        int posMontoComprometido = datard.GetOrdinal("MontoComprometido");
                        int posMontoEjecutadoTotal = datard.GetOrdinal("MontoEjecutadoTotal");
                        int posMontoSaldo = datard.GetOrdinal("MontoSaldo");
                        int posMontoEconomia = datard.GetOrdinal("MontoEconomia");
                        int posNumeroMinistracion = datard.GetOrdinal("NumeroMinistracion");
                        //int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        //int posFechaRegistro = datard.GetOrdinal("FechaRegistro");

                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        //int posIdCapitulo = datard.GetOrdinal("IdCapitulo");
                        int posIdEjercicioFiscal = datard.GetOrdinal("IdEjercicioFiscal");
                        //int posMontoPresupuestoTotal = datard.GetOrdinal("MontoPresupuestoTotal");
                        //int posPreMontoComprometido = datard.GetOrdinal("PreMontoComprometido");
                        //int posPreMontoEjecutadoTotal = datard.GetOrdinal("PreMontoEjecutadoTotal");
                        //int posPreMontoSaldo = datard.GetOrdinal("PreMontoSaldo");
                        //int posPreMontoEconomia = datard.GetOrdinal("PreMontoEconomia");
                        //int posDependencia = datard.GetOrdinal("Dependencia");
                        //int posCapitulo = datard.GetOrdinal("Capitulo");
                        //int posEjercicio = datard.GetOrdinal("Ejercicio");
                        //int posPartida = datard.GetOrdinal("Partida");

                        while (datard.Read())
                        {
                            obePresupuestosPartidas = new bePresupuestosPartidas();
                            obePresupuestosPartidas.IdPresupuestoPartida = datard.GetInt32(posIdPresupuestoPartida);
                            //obePresupuestosPartidas.IdPresupuesto = datard.GetInt32(posIdPresupuesto);
                            obePresupuestosPartidas.IdPartida = datard.GetInt32(posIdPartida);
                            obePresupuestosPartidas.MontoPresupuesto = datard.GetDecimal(posMontoPresupuesto);
                            obePresupuestosPartidas.MontoComprometido = datard.GetDecimal(posMontoComprometido);
                            obePresupuestosPartidas.MontoEjecutadoTotal = datard.GetDecimal(posMontoEjecutadoTotal);
                            obePresupuestosPartidas.MontoSaldo = datard.GetDecimal(posMontoSaldo);
                            obePresupuestosPartidas.MontoEconomia = datard.GetDecimal(posMontoEconomia);
                            obePresupuestosPartidas.NumeroMinistracion = datard.GetString(posNumeroMinistracion);
                            //obePresupuestosPartidas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            //obePresupuestosPartidas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            // debe agregar campos de la Vista
                            obePresupuestosPartidas.IdDependencia = datard.GetInt32(posIdDependencia);
                            //obePresupuestosPartidas.IdCapitulo = datard.GetInt32(posIdCapitulo);
                            obePresupuestosPartidas.IdEjercicioFiscal = datard.GetInt32(posIdEjercicioFiscal);
                            //obePresupuestosPartidas.MontoPresupuestoTotal = datard.GetDecimal(posMontoPresupuestoTotal);
                            //obePresupuestosPartidas.PreMontoComprometido = datard.GetDecimal(posPreMontoComprometido);
                            //obePresupuestosPartidas.PreMontoEjecutadoTotal = datard.GetDecimal(posPreMontoEjecutadoTotal);
                            //obePresupuestosPartidas.PreMontoSaldo = datard.GetDecimal(posPreMontoSaldo);
                            //obePresupuestosPartidas.PreMontoEconomia = datard.GetDecimal(posPreMontoEconomia);
                            //obePresupuestosPartidas.Dependencia = datard.GetString(posDependencia);
                            //obePresupuestosPartidas.Capitulo = datard.GetString(posCapitulo);
                            //obePresupuestosPartidas.Ejercicio = datard.GetInt32(posEjercicio);
                            //obePresupuestosPartidas.Partida = datard.GetString(posPartida);
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obePresupuestosPartidas;
            }
        }

    }
}
