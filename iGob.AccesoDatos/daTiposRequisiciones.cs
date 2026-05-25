using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposRequisiciones
 {
	public int guardarTiposRequisiciones(SqlConnection Conexion, beTiposRequisiciones obeTiposRequisiciones)
	{
		int Id=0;
		string sp = "Proc_TiposRequisicionesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoRequisicion", SqlDbType.Int).Value = obeTiposRequisiciones.IdTipoRequisicion;
				cmd.Parameters.Add("@TipoRequisicion", SqlDbType.VarChar).Value = obeTiposRequisiciones.TipoRequisicion;
				cmd.Parameters.Add("@Abreviacion", SqlDbType.Char).Value = obeTiposRequisiciones.Abreviacion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposRequisiciones.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposRequisiciones(SqlConnection Conexion, beTiposRequisiciones obeTiposRequisiciones)
	{
		string sp = "Proc_TiposRequisicionesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoRequisicion", SqlDbType.Int).Value = obeTiposRequisiciones.IdTipoRequisicion;
				cmd.Parameters.Add("@TipoRequisicion", SqlDbType.VarChar).Value = obeTiposRequisiciones.TipoRequisicion;
				cmd.Parameters.Add("@Abreviacion", SqlDbType.Char).Value = obeTiposRequisiciones.Abreviacion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposRequisiciones.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposRequisiciones(SqlConnection Conexion,int pIdTipoRequisicion)
	{
		string sp = "Proc_TiposRequisicionesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoRequisicion", SqlDbType.Int).Value = pIdTipoRequisicion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposRequisiciones traerTiposRequisiciones_x_IdTipoRequisicion(SqlConnection Conexion,int IdTipoRequisicion)
	{
		string sp = "Proc_TiposRequisiciones_x_IdTipoRequisicion";
				beTiposRequisiciones obeTiposRequisiciones=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoRequisicion", SqlDbType.Int).Value = IdTipoRequisicion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdTipoRequisicion = datard.GetOrdinal("IdTipoRequisicion");
						int posTipoRequisicion = datard.GetOrdinal("TipoRequisicion");
						int posAbreviacion = datard.GetOrdinal("Abreviacion");
						int posActivo = datard.GetOrdinal("Activo");
					 obeTiposRequisiciones = new beTiposRequisiciones();
				while (datard.Read())
					{
						obeTiposRequisiciones.IdTipoRequisicion =  datard.GetInt32(posIdTipoRequisicion);
						obeTiposRequisiciones.TipoRequisicion =  datard.GetString(posTipoRequisicion);
						obeTiposRequisiciones.Abreviacion =  datard.GetString(posAbreviacion);
						obeTiposRequisiciones.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposRequisiciones;
			}
	}
	public List< beTiposRequisiciones> listarTodos_TiposRequisiciones(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposRequisiciones_Traer_Todos";
		List<beTiposRequisiciones> lbeTiposRequisiciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoRequisicion = datard.GetOrdinal("IdTipoRequisicion");
						int posTipoRequisicion = datard.GetOrdinal("TipoRequisicion");
						int posAbreviacion = datard.GetOrdinal("Abreviacion");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposRequisiciones = new List<beTiposRequisiciones>();
				beTiposRequisiciones obeTiposRequisiciones;
				while (datard.Read())
				{
					 obeTiposRequisiciones = new beTiposRequisiciones();
					obeTiposRequisiciones.IdTipoRequisicion =  datard.GetInt32(posIdTipoRequisicion);
					obeTiposRequisiciones.TipoRequisicion =  datard.GetString(posTipoRequisicion);
					obeTiposRequisiciones.Abreviacion =  datard.GetString(posAbreviacion);
					obeTiposRequisiciones.Activo =  datard.GetBoolean(posActivo);
					lbeTiposRequisiciones.Add(obeTiposRequisiciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposRequisiciones;
		}
	}
	public List< beTiposRequisiciones> listar_TiposRequisiciones_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposRequisiciones_TraerTodos_GetAll";
		List<beTiposRequisiciones> lbeTiposRequisiciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoRequisicion = datard.GetOrdinal("IdTipoRequisicion");
						int posTipoRequisicion = datard.GetOrdinal("TipoRequisicion");
						int posAbreviacion = datard.GetOrdinal("Abreviacion");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposRequisiciones = new List<beTiposRequisiciones>();
				beTiposRequisiciones obeTiposRequisiciones;
				while (datard.Read())
				{
					 obeTiposRequisiciones = new beTiposRequisiciones();
					obeTiposRequisiciones.IdTipoRequisicion =  datard.GetInt32(posIdTipoRequisicion);
					obeTiposRequisiciones.TipoRequisicion =  datard.GetString(posTipoRequisicion);
					obeTiposRequisiciones.Abreviacion =  datard.GetString(posAbreviacion);
					obeTiposRequisiciones.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeTiposRequisiciones.Add(obeTiposRequisiciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposRequisiciones;
		}
	}
        public List<beTiposRequisiciones> listar_TiposRequisiciones_Abiertas(SqlConnection Conexion)
        {
            string sp = "Proc_Tiposrequisiciones_abiertas";
            List<beTiposRequisiciones> lbeTiposRequisiciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdTipoRequisicion = datard.GetOrdinal("IdTipoRequisicion");
                        int posTipoRequisicion = datard.GetOrdinal("TipoRequisicion");
                        int posAbreviacion = datard.GetOrdinal("Abreviacion");
                        //int posActivo = datard.GetOrdinal("Activo");
                        lbeTiposRequisiciones = new List<beTiposRequisiciones>();
                        beTiposRequisiciones obeTiposRequisiciones;
                        while (datard.Read())
                        {
                            obeTiposRequisiciones = new beTiposRequisiciones();
                            obeTiposRequisiciones.IdTipoRequisicion = datard.GetInt32(posIdTipoRequisicion);
                            obeTiposRequisiciones.TipoRequisicion = datard.GetString(posTipoRequisicion);
                            obeTiposRequisiciones.Abreviacion = datard.GetString(posAbreviacion);
                            //obeTiposRequisiciones.Activo = datard.GetBoolean(posActivo);
                            // debe agregar campos de la Vista
                            lbeTiposRequisiciones.Add(obeTiposRequisiciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeTiposRequisiciones;
            }
        }
    }
}
