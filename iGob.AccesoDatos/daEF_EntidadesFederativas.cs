using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daEF_EntidadesFederativas
 {
	public int guardarEF_EntidadesFederativas(SqlConnection Conexion, beEF_EntidadesFederativas obeEF_EntidadesFederativas)
	{
		int Id=0;
		string sp = "Proc_EF_EntidadesFederativasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClaveEstado", SqlDbType.Char).Value = obeEF_EntidadesFederativas.ClaveEstado;
				cmd.Parameters.Add("@Clave", SqlDbType.Char).Value = obeEF_EntidadesFederativas.Clave;
				cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = obeEF_EntidadesFederativas.Estado;
				cmd.Parameters.Add("@AbreviacionEdo", SqlDbType.Char).Value = obeEF_EntidadesFederativas.AbreviacionEdo;
				cmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = obeEF_EntidadesFederativas.IdPais;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarEF_EntidadesFederativas(SqlConnection Conexion, beEF_EntidadesFederativas obeEF_EntidadesFederativas)
	{
		string sp = "Proc_EF_EntidadesFederativasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClaveEstado", SqlDbType.Char).Value = obeEF_EntidadesFederativas.ClaveEstado;
				cmd.Parameters.Add("@Clave", SqlDbType.Char).Value = obeEF_EntidadesFederativas.Clave;
				cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = obeEF_EntidadesFederativas.Estado;
				cmd.Parameters.Add("@AbreviacionEdo", SqlDbType.Char).Value = obeEF_EntidadesFederativas.AbreviacionEdo;
				cmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = obeEF_EntidadesFederativas.IdPais;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarEF_EntidadesFederativas(SqlConnection Conexion,string pClaveEstado)
	{
		string sp = "Proc_EF_EntidadesFederativasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClaveEstado", SqlDbType.Char).Value = pClaveEstado;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beEF_EntidadesFederativas traerEF_EntidadesFederativas_x_ClaveEstado(SqlConnection Conexion,string ClaveEstado)
	{
		string sp = "Proc_EF_EntidadesFederativas_x_ClaveEstado";
				beEF_EntidadesFederativas obeEF_EntidadesFederativas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@ClaveEstado", SqlDbType.Char).Value = ClaveEstado;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posClaveEstado = datard.GetOrdinal("ClaveEstado");
						int posClave = datard.GetOrdinal("Clave");
						int posEstado = datard.GetOrdinal("Estado");
						int posAbreviacionEdo = datard.GetOrdinal("AbreviacionEdo");
						int posIdPais = datard.GetOrdinal("IdPais");
					 obeEF_EntidadesFederativas = new beEF_EntidadesFederativas();
				while (datard.Read())
					{
						obeEF_EntidadesFederativas.ClaveEstado =  datard.GetString(posClaveEstado);
						obeEF_EntidadesFederativas.Clave =  datard.GetString(posClave);
						obeEF_EntidadesFederativas.Estado =  datard.GetString(posEstado);
						obeEF_EntidadesFederativas.AbreviacionEdo =  datard.GetString(posAbreviacionEdo);
						obeEF_EntidadesFederativas.IdPais =  datard.GetInt32(posIdPais);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEF_EntidadesFederativas;
			}
	}
	public List< beEF_EntidadesFederativas> listarTodos_EF_EntidadesFederativas(SqlConnection Conexion)
	 {
		string sp = "Proc_EF_EntidadesFederativas_Traer_Todos";
		List<beEF_EntidadesFederativas> lbeEF_EntidadesFederativas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posClaveEstado = datard.GetOrdinal("ClaveEstado");
						int posClave = datard.GetOrdinal("Clave");
						int posEstado = datard.GetOrdinal("Estado");
						int posAbreviacionEdo = datard.GetOrdinal("AbreviacionEdo");
						int posIdPais = datard.GetOrdinal("IdPais");
				lbeEF_EntidadesFederativas = new List<beEF_EntidadesFederativas>();
				beEF_EntidadesFederativas obeEF_EntidadesFederativas;
				while (datard.Read())
				{
					 obeEF_EntidadesFederativas = new beEF_EntidadesFederativas();
					obeEF_EntidadesFederativas.ClaveEstado =  datard.GetString(posClaveEstado);
					obeEF_EntidadesFederativas.Clave =  datard.GetString(posClave);
					obeEF_EntidadesFederativas.Estado =  datard.GetString(posEstado);
					obeEF_EntidadesFederativas.AbreviacionEdo =  datard.GetString(posAbreviacionEdo);
					obeEF_EntidadesFederativas.IdPais =  datard.GetInt32(posIdPais);
					lbeEF_EntidadesFederativas.Add(obeEF_EntidadesFederativas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_EntidadesFederativas;
		}
	}
	public List< beEF_EntidadesFederativas> listar_EF_EntidadesFederativas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_EF_EntidadesFederativas_TraerTodos_GetAll";
		List<beEF_EntidadesFederativas> lbeEF_EntidadesFederativas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posClaveEstado = datard.GetOrdinal("ClaveEstado");
						int posClave = datard.GetOrdinal("Clave");
						int posEstado = datard.GetOrdinal("Estado");
						int posAbreviacionEdo = datard.GetOrdinal("AbreviacionEdo");
						int posIdPais = datard.GetOrdinal("IdPais");
				lbeEF_EntidadesFederativas = new List<beEF_EntidadesFederativas>();
				beEF_EntidadesFederativas obeEF_EntidadesFederativas;
				while (datard.Read())
				{
					 obeEF_EntidadesFederativas = new beEF_EntidadesFederativas();
					obeEF_EntidadesFederativas.ClaveEstado =  datard.GetString(posClaveEstado);
					obeEF_EntidadesFederativas.Clave =  datard.GetString(posClave);
					obeEF_EntidadesFederativas.Estado =  datard.GetString(posEstado);
					obeEF_EntidadesFederativas.AbreviacionEdo =  datard.GetString(posAbreviacionEdo);
					obeEF_EntidadesFederativas.IdPais =  datard.GetInt32(posIdPais);
			// debe agregar campos de la Vista
					lbeEF_EntidadesFederativas.Add(obeEF_EntidadesFederativas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_EntidadesFederativas;
		}
	}

        public List<beEF_EntidadesFederativas> listarTodos_EF_EntidadesFederativasEstMerc(SqlConnection Conexion)
        {
            string sp = "Proc_EF_EntidadesFederativas_Traer_Todos";
            List<beEF_EntidadesFederativas> lbeEF_EntidadesFederativas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posClaveEstado = datard.GetOrdinal("ClaveEstado");
                        int posClave = datard.GetOrdinal("Clave");
                        int posEstado = datard.GetOrdinal("Estado");
                        int posAbreviacionEdo = datard.GetOrdinal("AbreviacionEdo");
                        int posIdPais = datard.GetOrdinal("IdPais");
                        lbeEF_EntidadesFederativas = new List<beEF_EntidadesFederativas>();
                        beEF_EntidadesFederativas obeEF_EntidadesFederativas;
                        while (datard.Read())
                        {
                            obeEF_EntidadesFederativas = new beEF_EntidadesFederativas();
                            obeEF_EntidadesFederativas.ClaveEstado2 = Int32.Parse(datard.GetString(posClaveEstado));
                            obeEF_EntidadesFederativas.Clave = datard.GetString(posClave);
                            obeEF_EntidadesFederativas.Estado = datard.GetString(posEstado);
                            obeEF_EntidadesFederativas.AbreviacionEdo = datard.GetString(posAbreviacionEdo);
                            obeEF_EntidadesFederativas.IdPais = datard.GetInt32(posIdPais);
                            lbeEF_EntidadesFederativas.Add(obeEF_EntidadesFederativas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeEF_EntidadesFederativas;
            }
        }
    }
}
