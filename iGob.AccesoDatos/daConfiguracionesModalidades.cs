using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daConfiguracionesModalidades
     {
	    public int guardarConfiguracionesModalidades(SqlConnection Conexion, beConfiguracionesModalidades obeConfiguracionesModalidades)
	    {
		    int Id=0;
		    string sp = "Proc_ConfiguracionesModalidadesInsertar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdConfiguracionModalidad", SqlDbType.Int).Value = obeConfiguracionesModalidades.IdConfiguracionModalidad;
				    cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeConfiguracionesModalidades.IdGobierno;
				    cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeConfiguracionesModalidades.IdTiempo;
				    cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = obeConfiguracionesModalidades.IdTipoLicitacion;
				    cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = obeConfiguracionesModalidades.IdModalidadLicitacion;
				    cmd.Parameters.Add("@PublicacionConvocatoriaDia", SqlDbType.Int).Value = obeConfiguracionesModalidades.PublicacionConvocatoriaDia;
				    cmd.Parameters.Add("@DisposicionBasesDias", SqlDbType.Int).Value = obeConfiguracionesModalidades.DisposicionBasesDias;
				    cmd.Parameters.Add("@LimiteEnvioPreguntasHoras", SqlDbType.Int).Value = obeConfiguracionesModalidades.LimiteEnvioPreguntasHoras;
				    cmd.Parameters.Add("@LimiteEnvioRespuestasHoras", SqlDbType.Int).Value = obeConfiguracionesModalidades.LimiteEnvioRespuestasHoras;
				    cmd.Parameters.Add("@AclaracionDudasDias", SqlDbType.Int).Value = obeConfiguracionesModalidades.AclaracionDudasDias;
				    cmd.Parameters.Add("@EnvioProuestaTecEcoDias", SqlDbType.Int).Value = obeConfiguracionesModalidades.EnvioProuestaTecEcoDias;
				    cmd.Parameters.Add("@EntregaDictamenDias", SqlDbType.Int).Value = obeConfiguracionesModalidades.EntregaDictamenDias;
				    cmd.Parameters.Add("@FalloDias", SqlDbType.Int).Value = obeConfiguracionesModalidades.FalloDias;
				    cmd.Parameters.Add("@CantidadLotesLicitacion", SqlDbType.Int).Value = obeConfiguracionesModalidades.CantidadLotesLicitacion;
				    cmd.Parameters.Add("@CantidadLotesRequiscion", SqlDbType.Int).Value = obeConfiguracionesModalidades.CantidadLotesRequiscion;
				    cmd.Parameters.Add("@NumeroPujas", SqlDbType.Int).Value = obeConfiguracionesModalidades.NumeroPujas;
				    cmd.Parameters.Add("@MnimoProveedores", SqlDbType.Int).Value = obeConfiguracionesModalidades.MnimoProveedores;
				    cmd.Parameters.Add("@NomenclaturaProveedores", SqlDbType.NChar).Value = obeConfiguracionesModalidades.NomenclaturaProveedores;
				    cmd.Parameters.Add("@NomenclaturaPreguntas", SqlDbType.NChar).Value = obeConfiguracionesModalidades.NomenclaturaPreguntas;
			
				    Id =(int)cmd.ExecuteScalar();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return Id;
			    }
	    }

	    public int actualizarConfiguracionesModalidades(SqlConnection Conexion, beConfiguracionesModalidades obeConfiguracionesModalidades)
	    {
		    string sp = "Proc_ConfiguracionesModalidadesActualizar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdConfiguracionModalidad", SqlDbType.Int).Value = obeConfiguracionesModalidades.IdConfiguracionModalidad;
				    cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeConfiguracionesModalidades.IdGobierno;
				    cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeConfiguracionesModalidades.IdTiempo;
				    cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = obeConfiguracionesModalidades.IdTipoLicitacion;
				    cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = obeConfiguracionesModalidades.IdModalidadLicitacion;
				    cmd.Parameters.Add("@PublicacionConvocatoriaDia", SqlDbType.Int).Value = obeConfiguracionesModalidades.PublicacionConvocatoriaDia;
				    cmd.Parameters.Add("@DisposicionBasesDias", SqlDbType.Int).Value = obeConfiguracionesModalidades.DisposicionBasesDias;
				    cmd.Parameters.Add("@LimiteEnvioPreguntasHoras", SqlDbType.Int).Value = obeConfiguracionesModalidades.LimiteEnvioPreguntasHoras;
				    cmd.Parameters.Add("@LimiteEnvioRespuestasHoras", SqlDbType.Int).Value = obeConfiguracionesModalidades.LimiteEnvioRespuestasHoras;
				    cmd.Parameters.Add("@AclaracionDudasDias", SqlDbType.Int).Value = obeConfiguracionesModalidades.AclaracionDudasDias;
				    cmd.Parameters.Add("@EnvioProuestaTecEcoDias", SqlDbType.Int).Value = obeConfiguracionesModalidades.EnvioProuestaTecEcoDias;
				    cmd.Parameters.Add("@EntregaDictamenDias", SqlDbType.Int).Value = obeConfiguracionesModalidades.EntregaDictamenDias;
				    cmd.Parameters.Add("@FalloDias", SqlDbType.Int).Value = obeConfiguracionesModalidades.FalloDias;
				    cmd.Parameters.Add("@CantidadLotesLicitacion", SqlDbType.Int).Value = obeConfiguracionesModalidades.CantidadLotesLicitacion;
				    cmd.Parameters.Add("@CantidadLotesRequiscion", SqlDbType.Int).Value = obeConfiguracionesModalidades.CantidadLotesRequiscion;
				    cmd.Parameters.Add("@NumeroPujas", SqlDbType.Int).Value = obeConfiguracionesModalidades.NumeroPujas;
				    cmd.Parameters.Add("@MnimoProveedores", SqlDbType.Int).Value = obeConfiguracionesModalidades.MnimoProveedores;
				    cmd.Parameters.Add("@NomenclaturaProveedores", SqlDbType.NChar).Value = obeConfiguracionesModalidades.NomenclaturaProveedores;
				    cmd.Parameters.Add("@NomenclaturaPreguntas", SqlDbType.NChar).Value = obeConfiguracionesModalidades.NomenclaturaPreguntas;
			
				    cmd.ExecuteNonQuery();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return 0;
			    }
	    }

	    public int eliminarConfiguracionesModalidades(SqlConnection Conexion,int pIdConfiguracionModalidad)
	    {
		    string sp = "Proc_ConfiguracionesModalidadesEliminar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdConfiguracionModalidad", SqlDbType.Int).Value = pIdConfiguracionModalidad;
				    cmd.ExecuteNonQuery();
				    }
				    catch (Exception ex) {
					    throw ex;
				    }
			    return 0;
			    }
	    }
	    public beConfiguracionesModalidades traerConfiguracionesModalidades_x_IdConfiguracionModalidad(SqlConnection Conexion,int IdConfiguracionModalidad)
	    {
		    string sp = "Proc_ConfiguracionesModalidades_x_IdConfiguracionModalidad";
				    beConfiguracionesModalidades obeConfiguracionesModalidades=null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    cmd.Parameters.Add("@IdConfiguracionModalidad", SqlDbType.Int).Value = IdConfiguracionModalidad;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
			    try {
				    if (datard != null)
				    {
						    int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
						    int posIdGobierno = datard.GetOrdinal("IdGobierno");
						    int posIdTiempo = datard.GetOrdinal("IdTiempo");
						    int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						    int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
						    int posPublicacionConvocatoriaDia = datard.GetOrdinal("PublicacionConvocatoriaDia");
						    int posDisposicionBasesDias = datard.GetOrdinal("DisposicionBasesDias");
						    int posLimiteEnvioPreguntasHoras = datard.GetOrdinal("LimiteEnvioPreguntasHoras");
						    int posLimiteEnvioRespuestasHoras = datard.GetOrdinal("LimiteEnvioRespuestasHoras");
						    int posAclaracionDudasDias = datard.GetOrdinal("AclaracionDudasDias");
						    int posEnvioProuestaTecEcoDias = datard.GetOrdinal("EnvioProuestaTecEcoDias");
						    int posEntregaDictamenDias = datard.GetOrdinal("EntregaDictamenDias");
						    int posFalloDias = datard.GetOrdinal("FalloDias");
						    int posCantidadLotesLicitacion = datard.GetOrdinal("CantidadLotesLicitacion");
						    int posCantidadLotesRequiscion = datard.GetOrdinal("CantidadLotesRequiscion");
						    int posNumeroPujas = datard.GetOrdinal("NumeroPujas");
						    int posMnimoProveedores = datard.GetOrdinal("MnimoProveedores");
						    int posNomenclaturaProveedores = datard.GetOrdinal("NomenclaturaProveedores");
						    int posNomenclaturaPreguntas = datard.GetOrdinal("NomenclaturaPreguntas");
					     obeConfiguracionesModalidades = new beConfiguracionesModalidades();
				    while (datard.Read())
					    {
						    obeConfiguracionesModalidades.IdConfiguracionModalidad =  datard.GetInt32(posIdConfiguracionModalidad);
						    obeConfiguracionesModalidades.IdGobierno =  datard.GetInt32(posIdGobierno);
						    obeConfiguracionesModalidades.IdTiempo =  datard.GetInt32(posIdTiempo);
						    obeConfiguracionesModalidades.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
						    obeConfiguracionesModalidades.IdModalidadLicitacion =  datard.GetInt32(posIdModalidadLicitacion);
						    obeConfiguracionesModalidades.PublicacionConvocatoriaDia =  datard.GetInt32(posPublicacionConvocatoriaDia);
						    obeConfiguracionesModalidades.DisposicionBasesDias =  datard.GetInt32(posDisposicionBasesDias);
						    obeConfiguracionesModalidades.LimiteEnvioPreguntasHoras =  datard.GetInt32(posLimiteEnvioPreguntasHoras);
						    obeConfiguracionesModalidades.LimiteEnvioRespuestasHoras =  datard.GetInt32(posLimiteEnvioRespuestasHoras);
						    obeConfiguracionesModalidades.AclaracionDudasDias =  datard.GetInt32(posAclaracionDudasDias);
						    obeConfiguracionesModalidades.EnvioProuestaTecEcoDias =  datard.GetInt32(posEnvioProuestaTecEcoDias);
						    obeConfiguracionesModalidades.EntregaDictamenDias =  datard.GetInt32(posEntregaDictamenDias);
						    obeConfiguracionesModalidades.FalloDias =  datard.GetInt32(posFalloDias);
						    obeConfiguracionesModalidades.CantidadLotesLicitacion =  datard.GetInt32(posCantidadLotesLicitacion);
						    obeConfiguracionesModalidades.CantidadLotesRequiscion =  datard.GetInt32(posCantidadLotesRequiscion);
						    obeConfiguracionesModalidades.NumeroPujas =  datard.GetInt32(posNumeroPujas);
						    obeConfiguracionesModalidades.MnimoProveedores =  datard.GetInt32(posMnimoProveedores);
						    obeConfiguracionesModalidades.NomenclaturaProveedores =  datard.GetString(posNomenclaturaProveedores);
						    obeConfiguracionesModalidades.NomenclaturaPreguntas =  datard.GetString(posNomenclaturaPreguntas);
					    }
				    }
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obeConfiguracionesModalidades;
			    }
	    }
	    public List< beConfiguracionesModalidades> listarTodos_ConfiguracionesModalidades(SqlConnection Conexion)
	     {
		    string sp = "Proc_ConfiguracionesModalidades_Traer_Todos";
		    List<beConfiguracionesModalidades> lbeConfiguracionesModalidades = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
						    int posIdGobierno = datard.GetOrdinal("IdGobierno");
						    int posIdTiempo = datard.GetOrdinal("IdTiempo");
						    int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						    int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
						    int posPublicacionConvocatoriaDia = datard.GetOrdinal("PublicacionConvocatoriaDia");
						    int posDisposicionBasesDias = datard.GetOrdinal("DisposicionBasesDias");
						    int posLimiteEnvioPreguntasHoras = datard.GetOrdinal("LimiteEnvioPreguntasHoras");
						    int posLimiteEnvioRespuestasHoras = datard.GetOrdinal("LimiteEnvioRespuestasHoras");
						    int posAclaracionDudasDias = datard.GetOrdinal("AclaracionDudasDias");
						    int posEnvioProuestaTecEcoDias = datard.GetOrdinal("EnvioProuestaTecEcoDias");
						    int posEntregaDictamenDias = datard.GetOrdinal("EntregaDictamenDias");
						    int posFalloDias = datard.GetOrdinal("FalloDias");
						    int posCantidadLotesLicitacion = datard.GetOrdinal("CantidadLotesLicitacion");
						    int posCantidadLotesRequiscion = datard.GetOrdinal("CantidadLotesRequiscion");
						    int posNumeroPujas = datard.GetOrdinal("NumeroPujas");
						    int posMnimoProveedores = datard.GetOrdinal("MnimoProveedores");
						    int posNomenclaturaProveedores = datard.GetOrdinal("NomenclaturaProveedores");
						    int posNomenclaturaPreguntas = datard.GetOrdinal("NomenclaturaPreguntas");
				    lbeConfiguracionesModalidades = new List<beConfiguracionesModalidades>();
				    beConfiguracionesModalidades obeConfiguracionesModalidades;
				    while (datard.Read())
				    {
					     obeConfiguracionesModalidades = new beConfiguracionesModalidades();
					    obeConfiguracionesModalidades.IdConfiguracionModalidad =  datard.GetInt32(posIdConfiguracionModalidad);
					    obeConfiguracionesModalidades.IdGobierno =  datard.GetInt32(posIdGobierno);
					    obeConfiguracionesModalidades.IdTiempo =  datard.GetInt32(posIdTiempo);
					    obeConfiguracionesModalidades.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
					    obeConfiguracionesModalidades.IdModalidadLicitacion =  datard.GetInt32(posIdModalidadLicitacion);
					    obeConfiguracionesModalidades.PublicacionConvocatoriaDia =  datard.GetInt32(posPublicacionConvocatoriaDia);
					    obeConfiguracionesModalidades.DisposicionBasesDias =  datard.GetInt32(posDisposicionBasesDias);
					    obeConfiguracionesModalidades.LimiteEnvioPreguntasHoras =  datard.GetInt32(posLimiteEnvioPreguntasHoras);
					    obeConfiguracionesModalidades.LimiteEnvioRespuestasHoras =  datard.GetInt32(posLimiteEnvioRespuestasHoras);
					    obeConfiguracionesModalidades.AclaracionDudasDias =  datard.GetInt32(posAclaracionDudasDias);
					    obeConfiguracionesModalidades.EnvioProuestaTecEcoDias =  datard.GetInt32(posEnvioProuestaTecEcoDias);
					    obeConfiguracionesModalidades.EntregaDictamenDias =  datard.GetInt32(posEntregaDictamenDias);
					    obeConfiguracionesModalidades.FalloDias =  datard.GetInt32(posFalloDias);
					    obeConfiguracionesModalidades.CantidadLotesLicitacion =  datard.GetInt32(posCantidadLotesLicitacion);
					    obeConfiguracionesModalidades.CantidadLotesRequiscion =  datard.GetInt32(posCantidadLotesRequiscion);
					    obeConfiguracionesModalidades.NumeroPujas =  datard.GetInt32(posNumeroPujas);
					    obeConfiguracionesModalidades.MnimoProveedores =  datard.GetInt32(posMnimoProveedores);
					    obeConfiguracionesModalidades.NomenclaturaProveedores =  datard.GetString(posNomenclaturaProveedores);
					    obeConfiguracionesModalidades.NomenclaturaPreguntas =  datard.GetString(posNomenclaturaPreguntas);
					    lbeConfiguracionesModalidades.Add(obeConfiguracionesModalidades);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeConfiguracionesModalidades;
		    }
	    }
	    public List< beConfiguracionesModalidades> listar_ConfiguracionesModalidades_GetAll(SqlConnection Conexion)
	     {
		    string sp = "Proc_ConfiguracionesModalidades_TraerTodos_GetAll";
		    List<beConfiguracionesModalidades> lbeConfiguracionesModalidades = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
						    int posIdGobierno = datard.GetOrdinal("IdGobierno");
						    int posIdTiempo = datard.GetOrdinal("IdTiempo");
						    int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						    int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
						    int posPublicacionConvocatoriaDia = datard.GetOrdinal("PublicacionConvocatoriaDia");
						    int posDisposicionBasesDias = datard.GetOrdinal("DisposicionBasesDias");
						    int posLimiteEnvioPreguntasHoras = datard.GetOrdinal("LimiteEnvioPreguntasHoras");
						    int posLimiteEnvioRespuestasHoras = datard.GetOrdinal("LimiteEnvioRespuestasHoras");
						    int posAclaracionDudasDias = datard.GetOrdinal("AclaracionDudasDias");
						    int posEnvioProuestaTecEcoDias = datard.GetOrdinal("EnvioProuestaTecEcoDias");
						    int posEntregaDictamenDias = datard.GetOrdinal("EntregaDictamenDias");
						    int posFalloDias = datard.GetOrdinal("FalloDias");
						    int posCantidadLotesLicitacion = datard.GetOrdinal("CantidadLotesLicitacion");
						    int posCantidadLotesRequiscion = datard.GetOrdinal("CantidadLotesRequiscion");
						    int posNumeroPujas = datard.GetOrdinal("NumeroPujas");
						    int posMnimoProveedores = datard.GetOrdinal("MnimoProveedores");
						    int posNomenclaturaProveedores = datard.GetOrdinal("NomenclaturaProveedores");
						    int posNomenclaturaPreguntas = datard.GetOrdinal("NomenclaturaPreguntas");
				    lbeConfiguracionesModalidades = new List<beConfiguracionesModalidades>();
				    beConfiguracionesModalidades obeConfiguracionesModalidades;
				    while (datard.Read())
				    {
					     obeConfiguracionesModalidades = new beConfiguracionesModalidades();
					    obeConfiguracionesModalidades.IdConfiguracionModalidad =  datard.GetInt32(posIdConfiguracionModalidad);
					    obeConfiguracionesModalidades.IdGobierno =  datard.GetInt32(posIdGobierno);
					    obeConfiguracionesModalidades.IdTiempo =  datard.GetInt32(posIdTiempo);
					    obeConfiguracionesModalidades.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
					    obeConfiguracionesModalidades.IdModalidadLicitacion =  datard.GetInt32(posIdModalidadLicitacion);
					    obeConfiguracionesModalidades.PublicacionConvocatoriaDia =  datard.GetInt32(posPublicacionConvocatoriaDia);
					    obeConfiguracionesModalidades.DisposicionBasesDias =  datard.GetInt32(posDisposicionBasesDias);
					    obeConfiguracionesModalidades.LimiteEnvioPreguntasHoras =  datard.GetInt32(posLimiteEnvioPreguntasHoras);
					    obeConfiguracionesModalidades.LimiteEnvioRespuestasHoras =  datard.GetInt32(posLimiteEnvioRespuestasHoras);
					    obeConfiguracionesModalidades.AclaracionDudasDias =  datard.GetInt32(posAclaracionDudasDias);
					    obeConfiguracionesModalidades.EnvioProuestaTecEcoDias =  datard.GetInt32(posEnvioProuestaTecEcoDias);
					    obeConfiguracionesModalidades.EntregaDictamenDias =  datard.GetInt32(posEntregaDictamenDias);
					    obeConfiguracionesModalidades.FalloDias =  datard.GetInt32(posFalloDias);
					    obeConfiguracionesModalidades.CantidadLotesLicitacion =  datard.GetInt32(posCantidadLotesLicitacion);
					    obeConfiguracionesModalidades.CantidadLotesRequiscion =  datard.GetInt32(posCantidadLotesRequiscion);
					    obeConfiguracionesModalidades.NumeroPujas =  datard.GetInt32(posNumeroPujas);
					    obeConfiguracionesModalidades.MnimoProveedores =  datard.GetInt32(posMnimoProveedores);
					    obeConfiguracionesModalidades.NomenclaturaProveedores =  datard.GetString(posNomenclaturaProveedores);
					    obeConfiguracionesModalidades.NomenclaturaPreguntas =  datard.GetString(posNomenclaturaPreguntas);
			    // debe agregar campos de la Vista
					    lbeConfiguracionesModalidades.Add(obeConfiguracionesModalidades);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeConfiguracionesModalidades;
		    }
	    }

        public List<beConfiguracionesModalidades> ConfiguracionesModalidades_traer_TiposLicitacion(SqlConnection Conexion)
        {
            string sp = "Proc_ConfiguracionesModalidades_traer_TiposLicitacionTiempos";
            List<beConfiguracionesModalidades> lbeConfiguracionesModalidades = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        int posIdTiempo = datard.GetOrdinal("IdTiempo");
                        int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posTipoLicitacion = datard.GetOrdinal("TipoLicitacion");
                        int posModalidadLicitacion = datard.GetOrdinal("ModalidadLicitacion");
                        int posTiempo = datard.GetOrdinal("Tiempo");
                        lbeConfiguracionesModalidades = new List<beConfiguracionesModalidades>();
                        beConfiguracionesModalidades obeConfiguracionesModalidades;
                        while (datard.Read())
                        {
                            obeConfiguracionesModalidades = new beConfiguracionesModalidades();
                            obeConfiguracionesModalidades.IdConfiguracionModalidad = datard.GetInt32(posIdConfiguracionModalidad);
                            obeConfiguracionesModalidades.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeConfiguracionesModalidades.IdTiempo = datard.GetInt32(posIdTiempo);
                            obeConfiguracionesModalidades.IdTipoLicitacion = datard.GetInt32(posIdTipoLicitacion);
                            obeConfiguracionesModalidades.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeConfiguracionesModalidades.TipoLicitacion = datard.GetString(posTipoLicitacion);
                            obeConfiguracionesModalidades.ModalidadesLicitaciones = datard.GetString(posModalidadLicitacion);
                            obeConfiguracionesModalidades.Tiempo = datard.GetString(posTiempo);
                            lbeConfiguracionesModalidades.Add(obeConfiguracionesModalidades);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionesModalidades;
            }
        }
    }
}
