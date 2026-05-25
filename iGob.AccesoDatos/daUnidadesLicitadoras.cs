using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daUnidadesLicitadoras
 {
	public int guardarUnidadesLicitadoras(SqlConnection Conexion, beUnidadesLicitadoras obeUnidadesLicitadoras)
	{
		int Id=0;
		string sp = "Proc_UnidadesLicitadorasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdUnidadLicitadora", SqlDbType.Int).Value = obeUnidadesLicitadoras.IdUnidadLicitadora;
				cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeUnidadesLicitadoras.IdDependencia;
				cmd.Parameters.Add("@UnidadLicitadora", SqlDbType.NChar).Value = obeUnidadesLicitadoras.UnidadLicitadora;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeUnidadesLicitadoras.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarUnidadesLicitadoras(SqlConnection Conexion, beUnidadesLicitadoras obeUnidadesLicitadoras)
	{
		string sp = "Proc_UnidadesLicitadorasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdUnidadLicitadora", SqlDbType.Int).Value = obeUnidadesLicitadoras.IdUnidadLicitadora;
				cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeUnidadesLicitadoras.IdDependencia;
				cmd.Parameters.Add("@UnidadLicitadora", SqlDbType.NChar).Value = obeUnidadesLicitadoras.UnidadLicitadora;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeUnidadesLicitadoras.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarUnidadesLicitadoras(SqlConnection Conexion,int pIdUnidadLicitadora)
	{
		string sp = "Proc_UnidadesLicitadorasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdUnidadLicitadora", SqlDbType.Int).Value = pIdUnidadLicitadora;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beUnidadesLicitadoras traerUnidadesLicitadoras_x_IdUnidadLicitadora(SqlConnection Conexion,int IdUnidadLicitadora)
	{
		string sp = "Proc_UnidadesLicitadoras_x_IdUnidadLicitadora";
		List<beUnidadesLicitadoras> lbeUnidadesLicitadoras = null;
				beUnidadesLicitadoras obeUnidadesLicitadoras=new beUnidadesLicitadoras();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdUnidadLicitadora", SqlDbType.Int).Value = IdUnidadLicitadora;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeUnidadesLicitadoras = new List<beUnidadesLicitadoras>();
				while (datard.Read())
					{
					 obeUnidadesLicitadoras = new beUnidadesLicitadoras();
						obeUnidadesLicitadoras.IdUnidadLicitadora =  datard.GetInt32(0);
						obeUnidadesLicitadoras.IdDependencia =  datard.GetInt32(1);
						obeUnidadesLicitadoras.UnidadLicitadora =  datard.GetString(2);
						obeUnidadesLicitadoras.Activo =  datard.GetBoolean(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeUnidadesLicitadoras;
			}
	}
	public List< beUnidadesLicitadoras> listarTodos_UnidadesLicitadoras(SqlConnection Conexion)
	 {
		string sp = "Proc_UnidadesLicitadoras_Traer_Todos";
		List<beUnidadesLicitadoras> lbeUnidadesLicitadoras = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeUnidadesLicitadoras = new List<beUnidadesLicitadoras>();
				beUnidadesLicitadoras obeUnidadesLicitadoras;
				while (datard.Read())
				{
					 obeUnidadesLicitadoras = new beUnidadesLicitadoras();
					obeUnidadesLicitadoras.IdUnidadLicitadora =  datard.GetInt32(0);
					obeUnidadesLicitadoras.IdDependencia =  datard.GetInt32(1);
					obeUnidadesLicitadoras.UnidadLicitadora =  datard.GetString(2);
					obeUnidadesLicitadoras.Activo =  datard.GetBoolean(3);
					lbeUnidadesLicitadoras.Add(obeUnidadesLicitadoras);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeUnidadesLicitadoras;
		}
	}
	public DataTable listarUnidadesLicitadoras_x_(SqlConnection Conexion,int IdUnidadLicitadora)
	 {
		string sp = "Proc_UnidadesLicitadoras_Traer_Todos";
		DataTable dtUnidadesLicitadoras = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdUnidadLicitadora", SqlDbType.Int).Value = IdUnidadLicitadora;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtUnidadesLicitadoras = new DataTable();
				dtUnidadesLicitadoras.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtUnidadesLicitadoras;
		}
	}

    /* Dependencia 24/08/2018 */
    public List<beUnidadesLicitadoras> listarTodos_UnidadesLicitadoras_GetAll(SqlConnection Conexion)
    {
        string sp = "Proc_UnidadesLicitadoras_TraerTodos_GetAll";
        List<beUnidadesLicitadoras> lbeUnidadesLicitadoras = null;
        SqlCommand cmd = new SqlCommand(sp, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            try
            {
                if (datard != null)
                {
                    lbeUnidadesLicitadoras = new List<beUnidadesLicitadoras>();
                    beUnidadesLicitadoras obeUnidadesLicitadoras;
                    while (datard.Read())
                    {
                        obeUnidadesLicitadoras = new beUnidadesLicitadoras();
                        obeUnidadesLicitadoras.IdUnidadLicitadora = datard.GetInt32(0);
                        obeUnidadesLicitadoras.IdDependencia = datard.GetInt32(1);
                        obeUnidadesLicitadoras.UnidadLicitadora = datard.GetString(2);
                        obeUnidadesLicitadoras.Activo = datard.GetBoolean(3);

                        obeUnidadesLicitadoras.Dependencia = datard.GetString(4);
                        
                        lbeUnidadesLicitadoras.Add(obeUnidadesLicitadoras);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeUnidadesLicitadoras;
        }
    }
    }
}
