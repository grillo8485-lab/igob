using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daBienServicioEstudioMercado
 {
	public int guardarBienServicioEstudioMercado(SqlConnection Conexion, beBienServicioEstudioMercado obeBienServicioEstudioMercado)
	{
		int Id=0;
		string sp = "Proc_BienServicioEstudioMercadoInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDatoEstudioMercado", SqlDbType.Int).Value = obeBienServicioEstudioMercado.IdDatoEstudioMercado;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeBienServicioEstudioMercado.IdBienServicio;
				cmd.Parameters.Add("@PlazoEntrega", SqlDbType.VarChar).Value = obeBienServicioEstudioMercado.PlazoEntrega;
				cmd.Parameters.Add("@LugaresEntrega", SqlDbType.VarChar).Value = obeBienServicioEstudioMercado.LugaresEntrega;
				cmd.Parameters.Add("@FormaTerminoPago", SqlDbType.VarChar).Value = obeBienServicioEstudioMercado.FormaTerminoPago;
				cmd.Parameters.Add("@CircunstanciaAplicables", SqlDbType.VarChar).Value = obeBienServicioEstudioMercado.CircunstanciaAplicables;
				cmd.Parameters.Add("@NormasAplicables", SqlDbType.VarChar).Value = obeBienServicioEstudioMercado.NormasAplicables;
				cmd.Parameters.Add("@GradoIntegracionMexicano", SqlDbType.NChar).Value = obeBienServicioEstudioMercado.GradoIntegracionMexicano;
				cmd.Parameters.Add("@TamannoUnidades", SqlDbType.Int).Value = obeBienServicioEstudioMercado.TamannoUnidades;
				cmd.Parameters.Add("@NoUnidadesEconomicas", SqlDbType.Int).Value = obeBienServicioEstudioMercado.NoUnidadesEconomicas;
				cmd.Parameters.Add("@TipoDeterminacion", SqlDbType.Int).Value = obeBienServicioEstudioMercado.TipoDeterminacion;
				cmd.Parameters.Add("@IdEstatusEstudioMercado", SqlDbType.Int).Value = obeBienServicioEstudioMercado.IdEstatusEstudioMercado;
				cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = obeBienServicioEstudioMercado.Estado;
				cmd.Parameters.Add("@Municipio", SqlDbType.Int).Value = obeBienServicioEstudioMercado.Municipio;
				cmd.Parameters.Add("@Localidad", SqlDbType.Int).Value = obeBienServicioEstudioMercado.Localidad;
				cmd.Parameters.Add("@UEVieneCatalogo", SqlDbType.Bit).Value = obeBienServicioEstudioMercado.UEVieneCatalogo;

                    Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarBienServicioEstudioMercado(SqlConnection Conexion, beBienServicioEstudioMercado obeBienServicioEstudioMercado)
	{
		string sp = "Proc_BienServicioEstudioMercadoActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDatoEstudioMercado", SqlDbType.Int).Value = obeBienServicioEstudioMercado.IdDatoEstudioMercado;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeBienServicioEstudioMercado.IdBienServicio;
				cmd.Parameters.Add("@PlazoEntrega", SqlDbType.VarChar).Value = obeBienServicioEstudioMercado.PlazoEntrega;
				cmd.Parameters.Add("@LugaresEntrega", SqlDbType.VarChar).Value = obeBienServicioEstudioMercado.LugaresEntrega;
				cmd.Parameters.Add("@FormaTerminoPago", SqlDbType.VarChar).Value = obeBienServicioEstudioMercado.FormaTerminoPago;
				cmd.Parameters.Add("@CircunstanciaAplicables", SqlDbType.VarChar).Value = obeBienServicioEstudioMercado.CircunstanciaAplicables;
				cmd.Parameters.Add("@NormasAplicables", SqlDbType.VarChar).Value = obeBienServicioEstudioMercado.NormasAplicables;
				cmd.Parameters.Add("@GradoIntegracionMexicano", SqlDbType.NChar).Value = obeBienServicioEstudioMercado.GradoIntegracionMexicano;
				cmd.Parameters.Add("@TamannoUnidades", SqlDbType.Int).Value = obeBienServicioEstudioMercado.TamannoUnidades;
				cmd.Parameters.Add("@NoUnidadesEconomicas", SqlDbType.Int).Value = obeBienServicioEstudioMercado.NoUnidadesEconomicas;
				cmd.Parameters.Add("@TipoDeterminacion", SqlDbType.Int).Value = obeBienServicioEstudioMercado.TipoDeterminacion;
				cmd.Parameters.Add("@IdEstatusEstudioMercado", SqlDbType.Int).Value = obeBienServicioEstudioMercado.IdEstatusEstudioMercado;
				cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = obeBienServicioEstudioMercado.Estado;
				cmd.Parameters.Add("@Municipio", SqlDbType.Int).Value = obeBienServicioEstudioMercado.Municipio;
				cmd.Parameters.Add("@Localidad", SqlDbType.Int).Value = obeBienServicioEstudioMercado.Localidad;
				cmd.Parameters.Add("@UEVieneCatalogo", SqlDbType.Bit).Value = obeBienServicioEstudioMercado.UEVieneCatalogo;

                    cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarBienServicioEstudioMercado(SqlConnection Conexion,int pIdDatoEstudioMercado)
	{
		string sp = "Proc_BienServicioEstudioMercadoEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDatoEstudioMercado", SqlDbType.Int).Value = pIdDatoEstudioMercado;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beBienServicioEstudioMercado traerBienServicioEstudioMercado_x_IdDatoEstudioMercado(SqlConnection Conexion,int IdDatoEstudioMercado)
	{
		string sp = "Proc_BienServicioEstudioMercado_x_IdDatoEstudioMercado";
				beBienServicioEstudioMercado obeBienServicioEstudioMercado=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdDatoEstudioMercado", SqlDbType.Int).Value = IdDatoEstudioMercado;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");
						int posLugaresEntrega = datard.GetOrdinal("LugaresEntrega");
						int posFormaTerminoPago = datard.GetOrdinal("FormaTerminoPago");
						int posCircunstanciaAplicables = datard.GetOrdinal("CircunstanciaAplicables");
						int posNormasAplicables = datard.GetOrdinal("NormasAplicables");
						int posGradoIntegracionMexicano = datard.GetOrdinal("GradoIntegracionMexicano");
						int posTamannoUnidades = datard.GetOrdinal("TamannoUnidades");
						int posNoUnidadesEconomicas = datard.GetOrdinal("NoUnidadesEconomicas");
						int posTipoDeterminacion = datard.GetOrdinal("TipoDeterminacion");
						int posIdEstatusEstudioMercado = datard.GetOrdinal("IdEstatusEstudioMercado");
						int posEstado = datard.GetOrdinal("Estado");
						int posMunicipio = datard.GetOrdinal("Municipio");
						int posLocalidad = datard.GetOrdinal("Localidad");
						int posUEVieneCatalogo = datard.GetOrdinal("UEVieneCatalogo");
                        obeBienServicioEstudioMercado = new beBienServicioEstudioMercado();
				while (datard.Read())
					{
						obeBienServicioEstudioMercado.IdDatoEstudioMercado =  datard.GetInt32(posIdDatoEstudioMercado);
						obeBienServicioEstudioMercado.IdBienServicio =  datard.GetInt32(posIdBienServicio);
						obeBienServicioEstudioMercado.PlazoEntrega =  datard.GetString(posPlazoEntrega);
						obeBienServicioEstudioMercado.LugaresEntrega =  datard.GetString(posLugaresEntrega);
						obeBienServicioEstudioMercado.FormaTerminoPago =  datard.GetString(posFormaTerminoPago);
						obeBienServicioEstudioMercado.CircunstanciaAplicables =  datard.GetString(posCircunstanciaAplicables);
						obeBienServicioEstudioMercado.NormasAplicables =  datard.GetString(posNormasAplicables);
						obeBienServicioEstudioMercado.GradoIntegracionMexicano =  datard.GetString(posGradoIntegracionMexicano);
						obeBienServicioEstudioMercado.TamannoUnidades =  datard.GetInt32(posTamannoUnidades);
						obeBienServicioEstudioMercado.NoUnidadesEconomicas =  datard.GetInt32(posNoUnidadesEconomicas);
						obeBienServicioEstudioMercado.TipoDeterminacion =  datard.GetInt32(posTipoDeterminacion);
						obeBienServicioEstudioMercado.IdEstatusEstudioMercado =  datard.GetInt32(posIdEstatusEstudioMercado);
						obeBienServicioEstudioMercado.Estado =  datard.GetInt32(posEstado);
						obeBienServicioEstudioMercado.Municipio =  datard.GetInt32(posMunicipio);
						obeBienServicioEstudioMercado.Localidad =  datard.GetInt32(posLocalidad);
						obeBienServicioEstudioMercado.UEVieneCatalogo = datard[posUEVieneCatalogo] == DBNull.Value ? false : datard.GetBoolean(posUEVieneCatalogo);
                        }
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeBienServicioEstudioMercado;
			}
	}
	public List< beBienServicioEstudioMercado> listarTodos_BienServicioEstudioMercado(SqlConnection Conexion)
	 {
		string sp = "Proc_BienServicioEstudioMercado_Traer_Todos";
		List<beBienServicioEstudioMercado> lbeBienServicioEstudioMercado = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");
						int posLugaresEntrega = datard.GetOrdinal("LugaresEntrega");
						int posFormaTerminoPago = datard.GetOrdinal("FormaTerminoPago");
						int posCircunstanciaAplicables = datard.GetOrdinal("CircunstanciaAplicables");
						int posNormasAplicables = datard.GetOrdinal("NormasAplicables");
						int posGradoIntegracionMexicano = datard.GetOrdinal("GradoIntegracionMexicano");
						int posTamannoUnidades = datard.GetOrdinal("TamannoUnidades");
						int posNoUnidadesEconomicas = datard.GetOrdinal("NoUnidadesEconomicas");
						int posTipoDeterminacion = datard.GetOrdinal("TipoDeterminacion");
						int posIdEstatusEstudioMercado = datard.GetOrdinal("IdEstatusEstudioMercado");
						int posEstado = datard.GetOrdinal("Estado");
						int posMunicipio = datard.GetOrdinal("Municipio");
						int posLocalidad = datard.GetOrdinal("Localidad");
						int posUEVieneCatalogo = datard.GetOrdinal("UEVieneCatalogo");
                        lbeBienServicioEstudioMercado = new List<beBienServicioEstudioMercado>();
				beBienServicioEstudioMercado obeBienServicioEstudioMercado;
				while (datard.Read())
				{
					 obeBienServicioEstudioMercado = new beBienServicioEstudioMercado();
					obeBienServicioEstudioMercado.IdDatoEstudioMercado =  datard.GetInt32(posIdDatoEstudioMercado);
					obeBienServicioEstudioMercado.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obeBienServicioEstudioMercado.PlazoEntrega =  datard.GetString(posPlazoEntrega);
					obeBienServicioEstudioMercado.LugaresEntrega =  datard.GetString(posLugaresEntrega);
					obeBienServicioEstudioMercado.FormaTerminoPago =  datard.GetString(posFormaTerminoPago);
					obeBienServicioEstudioMercado.CircunstanciaAplicables =  datard.GetString(posCircunstanciaAplicables);
					obeBienServicioEstudioMercado.NormasAplicables =  datard.GetString(posNormasAplicables);
					obeBienServicioEstudioMercado.GradoIntegracionMexicano =  datard.GetString(posGradoIntegracionMexicano);
					obeBienServicioEstudioMercado.TamannoUnidades =  datard.GetInt32(posTamannoUnidades);
					obeBienServicioEstudioMercado.NoUnidadesEconomicas =  datard.GetInt32(posNoUnidadesEconomicas);
					obeBienServicioEstudioMercado.TipoDeterminacion =  datard.GetInt32(posTipoDeterminacion);
					obeBienServicioEstudioMercado.IdEstatusEstudioMercado =  datard.GetInt32(posIdEstatusEstudioMercado);
					obeBienServicioEstudioMercado.Estado =  datard.GetInt32(posEstado);
					obeBienServicioEstudioMercado.Municipio =  datard.GetInt32(posMunicipio);
					obeBienServicioEstudioMercado.Localidad =  datard.GetInt32(posLocalidad);
					obeBienServicioEstudioMercado.UEVieneCatalogo = datard[posUEVieneCatalogo] == DBNull.Value ? false : datard.GetBoolean(posUEVieneCatalogo);
                            lbeBienServicioEstudioMercado.Add(obeBienServicioEstudioMercado);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeBienServicioEstudioMercado;
		}
	}
	public List< beBienServicioEstudioMercado> listar_BienServicioEstudioMercado_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_BienServicioEstudioMercado_TraerTodos_GetAll";
		List<beBienServicioEstudioMercado> lbeBienServicioEstudioMercado = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");
						int posLugaresEntrega = datard.GetOrdinal("LugaresEntrega");
						int posFormaTerminoPago = datard.GetOrdinal("FormaTerminoPago");
						int posCircunstanciaAplicables = datard.GetOrdinal("CircunstanciaAplicables");
						int posNormasAplicables = datard.GetOrdinal("NormasAplicables");
						int posGradoIntegracionMexicano = datard.GetOrdinal("GradoIntegracionMexicano");
						int posTamannoUnidades = datard.GetOrdinal("TamannoUnidades");
						int posNoUnidadesEconomicas = datard.GetOrdinal("NoUnidadesEconomicas");
						int posTipoDeterminacion = datard.GetOrdinal("TipoDeterminacion");
						int posIdEstatusEstudioMercado = datard.GetOrdinal("IdEstatusEstudioMercado");
						int posEstado = datard.GetOrdinal("Estado");
						int posMunicipio = datard.GetOrdinal("Municipio");
						int posLocalidad = datard.GetOrdinal("Localidad");
						int posUEVieneCatalogo = datard.GetOrdinal("UEVieneCatalogo");
                        lbeBienServicioEstudioMercado = new List<beBienServicioEstudioMercado>();
				beBienServicioEstudioMercado obeBienServicioEstudioMercado;
				while (datard.Read())
				{
					 obeBienServicioEstudioMercado = new beBienServicioEstudioMercado();
					obeBienServicioEstudioMercado.IdDatoEstudioMercado =  datard.GetInt32(posIdDatoEstudioMercado);
					obeBienServicioEstudioMercado.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obeBienServicioEstudioMercado.PlazoEntrega =  datard.GetString(posPlazoEntrega);
					obeBienServicioEstudioMercado.LugaresEntrega =  datard.GetString(posLugaresEntrega);
					obeBienServicioEstudioMercado.FormaTerminoPago =  datard.GetString(posFormaTerminoPago);
					obeBienServicioEstudioMercado.CircunstanciaAplicables =  datard.GetString(posCircunstanciaAplicables);
					obeBienServicioEstudioMercado.NormasAplicables =  datard.GetString(posNormasAplicables);
					obeBienServicioEstudioMercado.GradoIntegracionMexicano =  datard.GetString(posGradoIntegracionMexicano);
					obeBienServicioEstudioMercado.TamannoUnidades =  datard.GetInt32(posTamannoUnidades);
					obeBienServicioEstudioMercado.NoUnidadesEconomicas =  datard.GetInt32(posNoUnidadesEconomicas);
					obeBienServicioEstudioMercado.TipoDeterminacion =  datard.GetInt32(posTipoDeterminacion);
					obeBienServicioEstudioMercado.IdEstatusEstudioMercado =  datard.GetInt32(posIdEstatusEstudioMercado);
					obeBienServicioEstudioMercado.Estado =  datard.GetInt32(posEstado);
					obeBienServicioEstudioMercado.Municipio =  datard.GetInt32(posMunicipio);
					obeBienServicioEstudioMercado.Localidad =  datard.GetInt32(posLocalidad);
					obeBienServicioEstudioMercado.UEVieneCatalogo = datard[posUEVieneCatalogo] == DBNull.Value ? false : datard.GetBoolean(posUEVieneCatalogo);
                            // debe agregar campos de la Vista
                            lbeBienServicioEstudioMercado.Add(obeBienServicioEstudioMercado);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeBienServicioEstudioMercado;
		}
	}

        public List<beBienServicioEstudioMercado> listarTodos_BienServicioEstudioMercadoHistorial(SqlConnection Conexion)
        {
            string sp = "Proc_EstudioMercadoBienServicio_traerTodos";
            List<beBienServicioEstudioMercado> lbeBienServicioEstudioMercado = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");
                        int posLugaresEntrega = datard.GetOrdinal("LugaresEntrega");
                        int posFormaTerminoPago = datard.GetOrdinal("FormaTerminoPago");
                        int posCircunstanciaAplicables = datard.GetOrdinal("CircunstanciaAplicables");
                        int posNormasAplicables = datard.GetOrdinal("NormasAplicables");
                        int posGradoIntegracionMexicano = datard.GetOrdinal("GradoIntegracionMexicano");
                        int posTamannoUnidades = datard.GetOrdinal("TamannoUnidades");
                        int posNoUnidadesEconomicas = datard.GetOrdinal("NoUnidadesEconomicas");
                        int posTipoDeterminacion = datard.GetOrdinal("TipoDeterminacion");
                        int posIdEstatusEstudioMercado = datard.GetOrdinal("IdEstatusEstudioMercado");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posCodigoScian = datard.GetOrdinal("CodigoScian");
                        int posEstatusEstudioMercado = datard.GetOrdinal("EstatusEstudioMercado");
                        lbeBienServicioEstudioMercado = new List<beBienServicioEstudioMercado>();
                        beBienServicioEstudioMercado obeBienServicioEstudioMercado;
                        while (datard.Read())
                        {
                            obeBienServicioEstudioMercado = new beBienServicioEstudioMercado();
                            obeBienServicioEstudioMercado.IdDatoEstudioMercado = datard.GetInt32(posIdDatoEstudioMercado);
                            obeBienServicioEstudioMercado.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeBienServicioEstudioMercado.PlazoEntrega = datard.GetString(posPlazoEntrega);
                            obeBienServicioEstudioMercado.LugaresEntrega = datard.GetString(posLugaresEntrega);
                            obeBienServicioEstudioMercado.FormaTerminoPago = datard.GetString(posFormaTerminoPago);
                            obeBienServicioEstudioMercado.CircunstanciaAplicables = datard.GetString(posCircunstanciaAplicables);
                            obeBienServicioEstudioMercado.NormasAplicables = datard.GetString(posNormasAplicables);
                            obeBienServicioEstudioMercado.GradoIntegracionMexicano = datard.GetString(posGradoIntegracionMexicano);
                            obeBienServicioEstudioMercado.TamannoUnidades = datard.GetInt32(posTamannoUnidades);
                            obeBienServicioEstudioMercado.NoUnidadesEconomicas = datard.GetInt32(posNoUnidadesEconomicas);
                            obeBienServicioEstudioMercado.TipoDeterminacion = datard.GetInt32(posTipoDeterminacion);
                            obeBienServicioEstudioMercado.IdEstatusEstudioMercado = datard.GetInt32(posIdEstatusEstudioMercado);
                            obeBienServicioEstudioMercado.BienServicio = datard.GetString(posBienServicio);
                            obeBienServicioEstudioMercado.CodigoScian = datard.GetInt32(posCodigoScian);
                            obeBienServicioEstudioMercado.EstatusEstudioMercado = datard.GetString(posEstatusEstudioMercado);
                            lbeBienServicioEstudioMercado.Add(obeBienServicioEstudioMercado);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeBienServicioEstudioMercado;
            }
        }
    }
}
