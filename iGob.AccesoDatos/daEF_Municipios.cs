using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daEF_Municipios
    {
	    public int guardarEF_Municipios(SqlConnection Conexion, beEF_Municipios obeEF_Municipios)
	    {
		    int Id=0;
		    string sp = "Proc_EF_MunicipiosInsertar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeEF_Municipios.IdMunicipio;
				    cmd.Parameters.Add("@Municipio", SqlDbType.NVarChar).Value = obeEF_Municipios.Municipio;
				    cmd.Parameters.Add("@ClaveEstado", SqlDbType.Char).Value = obeEF_Municipios.ClaveEstado;
			
				    Id =(int)cmd.ExecuteScalar();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return Id;
			    }
	    }

	    public int actualizarEF_Municipios(SqlConnection Conexion, beEF_Municipios obeEF_Municipios)
	    {
		    string sp = "Proc_EF_MunicipiosActualizar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeEF_Municipios.IdMunicipio;
				    cmd.Parameters.Add("@Municipio", SqlDbType.NVarChar).Value = obeEF_Municipios.Municipio;
				    cmd.Parameters.Add("@ClaveEstado", SqlDbType.Char).Value = obeEF_Municipios.ClaveEstado;
			
				    cmd.ExecuteNonQuery();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return 0;
			    }
	    }

	    public int eliminarEF_Municipios(SqlConnection Conexion,string pIdMunicipio)
	    {
		    string sp = "Proc_EF_MunicipiosEliminar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = pIdMunicipio;
				    cmd.ExecuteNonQuery();
				    }
				    catch (Exception ex) {
					    throw ex;
				    }
			    return 0;
			    }
	    }
	    public beEF_Municipios traerEF_Municipios_x_IdMunicipio(SqlConnection Conexion,string IdMunicipio)
	    {
		    string sp = "Proc_EF_Municipios_x_IdMunicipio";
				    beEF_Municipios obeEF_Municipios=null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = IdMunicipio;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
			    try {
				    if (datard != null)
				    {
						    int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
						    int posMunicipio = datard.GetOrdinal("Municipio");
						    int posClaveEstado = datard.GetOrdinal("ClaveEstado");
					     obeEF_Municipios = new beEF_Municipios();
				    while (datard.Read())
					    {
						    obeEF_Municipios.IdMunicipio =  datard.GetString(posIdMunicipio);
						    obeEF_Municipios.Municipio =  datard.GetString(posMunicipio);
						    obeEF_Municipios.ClaveEstado =  datard.GetString(posClaveEstado);
					    }
				    }
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obeEF_Municipios;
			    }
	    }
	    public List< beEF_Municipios> listarTodos_EF_Municipios(SqlConnection Conexion)
	     {
		    string sp = "Proc_EF_Municipios_Traer_Todos";
		    List<beEF_Municipios> lbeEF_Municipios = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
						    int posMunicipio = datard.GetOrdinal("Municipio");
						    int posClaveEstado = datard.GetOrdinal("ClaveEstado");
				    lbeEF_Municipios = new List<beEF_Municipios>();
				    beEF_Municipios obeEF_Municipios;
				    while (datard.Read())
				    {
					     obeEF_Municipios = new beEF_Municipios();
					    obeEF_Municipios.IdMunicipio =  datard.GetString(posIdMunicipio);
					    obeEF_Municipios.Municipio =  datard.GetString(posMunicipio);
					    obeEF_Municipios.ClaveEstado =  datard.GetString(posClaveEstado);
					    lbeEF_Municipios.Add(obeEF_Municipios);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeEF_Municipios;
		    }
	    }
	    public List< beEF_Municipios> listar_EF_Municipios_GetAll(SqlConnection Conexion)
	     {
		    string sp = "Proc_EF_Municipios_TraerTodos_GetAll";
		    List<beEF_Municipios> lbeEF_Municipios = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
						    int posMunicipio = datard.GetOrdinal("Municipio");
						    int posClaveEstado = datard.GetOrdinal("ClaveEstado");
				    lbeEF_Municipios = new List<beEF_Municipios>();
				    beEF_Municipios obeEF_Municipios;
				    while (datard.Read())
				    {
					     obeEF_Municipios = new beEF_Municipios();
					    obeEF_Municipios.IdMunicipio =  datard.GetString(posIdMunicipio);
					    obeEF_Municipios.Municipio =  datard.GetString(posMunicipio);
					    obeEF_Municipios.ClaveEstado =  datard.GetString(posClaveEstado);
			    // debe agregar campos de la Vista
					    lbeEF_Municipios.Add(obeEF_Municipios);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeEF_Municipios;
		    }
	    }

        public List<beEF_Municipios> traerEF_Municipios_x_ClaveEstado(SqlConnection Conexion,string ClaveEstado)
        {
            string sp = "Proc_EF_Municipios_x_ClaveEstado";
            List<beEF_Municipios> lbeEF_Municipios = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClaveEstado", SqlDbType.Char).Value = ClaveEstado;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
                        int posMunicipio = datard.GetOrdinal("Municipio");
                        int posClaveEstado = datard.GetOrdinal("ClaveEstado");
                        lbeEF_Municipios = new List<beEF_Municipios>();
                        beEF_Municipios obeEF_Municipios;
                        while (datard.Read())
                        {
                            obeEF_Municipios = new beEF_Municipios();
                            obeEF_Municipios.IdMunicipio = datard.GetString(posIdMunicipio);
                            obeEF_Municipios.Municipio = datard.GetString(posMunicipio);
                            obeEF_Municipios.ClaveEstado = datard.GetString(posClaveEstado);
                            lbeEF_Municipios.Add(obeEF_Municipios);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeEF_Municipios;
            }
        }

        public List<beEF_Municipios> listarTodos_EF_MunicipiosEstMer(SqlConnection Conexion)
        {
            string sp = "Proc_EF_Municipios_Traer_Todos";
            List<beEF_Municipios> lbeEF_Municipios = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdMunicipio = datard.GetOrdinal("IdMunicipio");
                        int posMunicipio = datard.GetOrdinal("Municipio");
                        int posClaveEstado = datard.GetOrdinal("ClaveEstado");
                        lbeEF_Municipios = new List<beEF_Municipios>();
                        beEF_Municipios obeEF_Municipios;
                        while (datard.Read())
                        {
                            obeEF_Municipios = new beEF_Municipios();
                            obeEF_Municipios.IdMunicipio2 = int.Parse(datard.GetString(posIdMunicipio));
                            obeEF_Municipios.Municipio = datard.GetString(posMunicipio);
                            obeEF_Municipios.ClaveEstado2 = int.Parse(datard.GetString(posClaveEstado));
                            lbeEF_Municipios.Add(obeEF_Municipios);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeEF_Municipios;
            }
        }
    }
}
