using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daEF_Colonias
 {
	public int guardarEF_Colonias(SqlConnection Conexion, beEF_Colonias obeEF_Colonias)
	{
		int Id=0;
		string sp = "Proc_EF_ColoniasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdColonia", SqlDbType.Char).Value = obeEF_Colonias.IdColonia;
				cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = obeEF_Colonias.Colonia;
				cmd.Parameters.Add("@CodigoPostal", SqlDbType.Char).Value = obeEF_Colonias.CodigoPostal;
				cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeEF_Colonias.IdMunicipio;
				cmd.Parameters.Add("@IdTipoAsenta", SqlDbType.Char).Value = obeEF_Colonias.IdTipoAsenta;
				cmd.Parameters.Add("@IdCiudad", SqlDbType.Char).Value = obeEF_Colonias.IdCiudad;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarEF_Colonias(SqlConnection Conexion, beEF_Colonias obeEF_Colonias)
	{
		string sp = "Proc_EF_ColoniasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdColonia", SqlDbType.Char).Value = obeEF_Colonias.IdColonia;
				cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = obeEF_Colonias.Colonia;
				cmd.Parameters.Add("@CodigoPostal", SqlDbType.Char).Value = obeEF_Colonias.CodigoPostal;
				cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeEF_Colonias.IdMunicipio;
				cmd.Parameters.Add("@IdTipoAsenta", SqlDbType.Char).Value = obeEF_Colonias.IdTipoAsenta;
				cmd.Parameters.Add("@IdCiudad", SqlDbType.Char).Value = obeEF_Colonias.IdCiudad;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarEF_Colonias(SqlConnection Conexion,string pIdColonia)
	{
		string sp = "Proc_EF_ColoniasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdColonia", SqlDbType.Char).Value = pIdColonia;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beEF_Colonias traerEF_Colonias_x_IdColonia(SqlConnection Conexion,string IdColonia)
	{
		string sp = "Proc_EF_Colonias_x_IdColonia";
				beEF_Colonias obeEF_Colonias=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdColonia", SqlDbType.Char).Value = IdColonia;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdColonia = datard.GetOrdinal("IdColonia");
						int posColonia = datard.GetOrdinal("Colonia");
						int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
						int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
						int posIdTipoAsenta = datard.GetOrdinal("IdTipoAsenta");
						int posIdCiudad = datard.GetOrdinal("IdCiudad");
					 obeEF_Colonias = new beEF_Colonias();
				while (datard.Read())
					{
						obeEF_Colonias.IdColonia =  datard.GetString(posIdColonia);
						obeEF_Colonias.Colonia =  datard.GetString(posColonia);
						obeEF_Colonias.CodigoPostal =  datard.GetString(posCodigoPostal);
						obeEF_Colonias.IdMunicipio =  datard.GetString(posIdMunicipio);
						obeEF_Colonias.IdTipoAsenta =  datard.GetString(posIdTipoAsenta);
						obeEF_Colonias.IdCiudad =  datard.GetString(posIdCiudad);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEF_Colonias;
			}
	}
	public List< beEF_Colonias> listarTodos_EF_Colonias(SqlConnection Conexion)
	 {
		string sp = "Proc_EF_Colonias_Traer_Todos";
		List<beEF_Colonias> lbeEF_Colonias = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdColonia = datard.GetOrdinal("IdColonia");
						int posColonia = datard.GetOrdinal("Colonia");
						int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
						int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
						int posIdTipoAsenta = datard.GetOrdinal("IdTipoAsenta");
						int posIdCiudad = datard.GetOrdinal("IdCiudad");
				lbeEF_Colonias = new List<beEF_Colonias>();
				beEF_Colonias obeEF_Colonias;
				while (datard.Read())
				{
					 obeEF_Colonias = new beEF_Colonias();
					obeEF_Colonias.IdColonia =  datard.GetString(posIdColonia);
					obeEF_Colonias.Colonia =  datard.GetString(posColonia);
					obeEF_Colonias.CodigoPostal =  datard.GetString(posCodigoPostal);
					obeEF_Colonias.IdMunicipio =  datard.GetString(posIdMunicipio);
					obeEF_Colonias.IdTipoAsenta =  datard.GetString(posIdTipoAsenta);
					obeEF_Colonias.IdCiudad =  datard.GetString(posIdCiudad);
					lbeEF_Colonias.Add(obeEF_Colonias);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_Colonias;
		}
	}
	public List< beEF_Colonias> listar_EF_Colonias_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_EF_Colonias_TraerTodos_GetAll";
		List<beEF_Colonias> lbeEF_Colonias = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdColonia = datard.GetOrdinal("IdColonia");
						int posColonia = datard.GetOrdinal("Colonia");
						int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
						int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
						int posIdTipoAsenta = datard.GetOrdinal("IdTipoAsenta");
						int posIdCiudad = datard.GetOrdinal("IdCiudad");
				lbeEF_Colonias = new List<beEF_Colonias>();
				beEF_Colonias obeEF_Colonias;
				while (datard.Read())
				{
					 obeEF_Colonias = new beEF_Colonias();
					obeEF_Colonias.IdColonia =  datard.GetString(posIdColonia);
					obeEF_Colonias.Colonia =  datard.GetString(posColonia);
					obeEF_Colonias.CodigoPostal =  datard.GetString(posCodigoPostal);
					obeEF_Colonias.IdMunicipio =  datard.GetString(posIdMunicipio);
					obeEF_Colonias.IdTipoAsenta =  datard.GetString(posIdTipoAsenta);
					obeEF_Colonias.IdCiudad =  datard.GetString(posIdCiudad);
			// debe agregar campos de la Vista
					lbeEF_Colonias.Add(obeEF_Colonias);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_Colonias;
		}
	}
        public List<beEF_Colonias> listarTodos_EF_ColoniasEstMerc(SqlConnection Conexion)
        {
            string sp = "Proc_EF_Colonias_Traer_Todos";
            List<beEF_Colonias> lbeEF_Colonias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdColonia = datard.GetOrdinal("IdColonia");
                        int posColonia = datard.GetOrdinal("Colonia");
                        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
                        int posIdTipoAsenta = datard.GetOrdinal("IdTipoAsenta");
                        int posIdCiudad = datard.GetOrdinal("IdCiudad");
                        lbeEF_Colonias = new List<beEF_Colonias>();
                        beEF_Colonias obeEF_Colonias;
                        while (datard.Read())
                        {
                            obeEF_Colonias = new beEF_Colonias();
                            obeEF_Colonias.IdColonia2 = int.Parse(datard.GetString(posIdColonia));
                            obeEF_Colonias.Colonia = datard.GetString(posColonia);
                            obeEF_Colonias.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeEF_Colonias.IdMunicipio2 = int.Parse(datard.GetString(posIdMunicipio));
                            obeEF_Colonias.IdTipoAsenta = datard.GetString(posIdTipoAsenta);
                            obeEF_Colonias.IdCiudad = datard.GetString(posIdCiudad);
                            lbeEF_Colonias.Add(obeEF_Colonias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeEF_Colonias;
            }
        }
    }
}
