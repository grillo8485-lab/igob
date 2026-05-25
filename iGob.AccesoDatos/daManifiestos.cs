using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daManifiestos
 {
	public int guardarManifiestos(SqlConnection Conexion, beManifiestos obeManifiestos)
	{
		int Id=0;
		string sp = "Proc_ManifiestosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdManifiesto", SqlDbType.Int).Value = obeManifiestos.IdManifiesto;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeManifiestos.IdGobierno;
				cmd.Parameters.Add("@Manifiesto", SqlDbType.Text).Value = obeManifiestos.Manifiesto;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeManifiestos.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarManifiestos(SqlConnection Conexion, beManifiestos obeManifiestos)
	{
		string sp = "Proc_ManifiestosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdManifiesto", SqlDbType.Int).Value = obeManifiestos.IdManifiesto;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeManifiestos.IdGobierno;
				cmd.Parameters.Add("@Manifiesto", SqlDbType.Text).Value = obeManifiestos.Manifiesto;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeManifiestos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarManifiestos(SqlConnection Conexion,int pIdManifiesto)
	{
		string sp = "Proc_ManifiestosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdManifiesto", SqlDbType.Int).Value = pIdManifiesto;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beManifiestos traerManifiestos_x_IdManifiesto(SqlConnection Conexion,int IdManifiesto)
	{
		string sp = "Proc_Manifiestos_x_IdManifiesto";
		List<beManifiestos> lbeManifiestos = null;
				beManifiestos obeManifiestos=new beManifiestos();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdManifiesto", SqlDbType.Int).Value = IdManifiesto;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeManifiestos = new List<beManifiestos>();
				while (datard.Read())
					{
					 obeManifiestos = new beManifiestos();
						obeManifiestos.IdManifiesto =  datard.GetInt32(0);
						obeManifiestos.IdGobierno =  datard.GetInt32(1);
						obeManifiestos.Manifiesto =  datard.GetString(2);
						obeManifiestos.Activo =  datard.GetBoolean(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeManifiestos;
			}
	}
	public List< beManifiestos> listarTodos_Manifiestos(SqlConnection Conexion)
	 {
		string sp = "Proc_Manifiestos_Traer_Todos";
		List<beManifiestos> lbeManifiestos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeManifiestos = new List<beManifiestos>();
				beManifiestos obeManifiestos;
				while (datard.Read())
				{
					 obeManifiestos = new beManifiestos();
					obeManifiestos.IdManifiesto =  datard.GetInt32(0);
					obeManifiestos.IdGobierno =  datard.GetInt32(1);
					obeManifiestos.Manifiesto =  datard.GetString(2);
					obeManifiestos.Activo =  datard.GetBoolean(3);
					lbeManifiestos.Add(obeManifiestos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeManifiestos;
		}
	}
	public DataTable listarManifiestos_x_(SqlConnection Conexion,int IdManifiesto)
	 {
		string sp = "Proc_Manifiestos_Traer_Todos";
		DataTable dtManifiestos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdManifiesto", SqlDbType.Int).Value = IdManifiesto;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtManifiestos = new DataTable();
				dtManifiestos.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtManifiestos;
		}
	}
    /* Gobierno 24/08/2018 */
    public List<beManifiestos> listarTodos_Manifiestos_GetAll(SqlConnection Conexion)
    {
        string sp = "Proc_Manifiestos_TraerTodos_GetAll";
        List<beManifiestos> lbeManifiestos = null;
        SqlCommand cmd = new SqlCommand(sp, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            try
            {
                if (datard != null)
                {
                    lbeManifiestos = new List<beManifiestos>();
                    beManifiestos obeManifiestos;
                    while (datard.Read())
                    {
                        obeManifiestos = new beManifiestos();
                        obeManifiestos.IdManifiesto = datard.GetInt32(0);
                        obeManifiestos.IdGobierno = datard.GetInt32(1);
                        obeManifiestos.Manifiesto = datard.GetString(2);
                        obeManifiestos.Activo = datard.GetBoolean(3);
                        
                        obeManifiestos.Gobierno = datard.GetString(4);
                        
                        lbeManifiestos.Add(obeManifiestos);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeManifiestos;
        }
    }
    /**/

    }
}
