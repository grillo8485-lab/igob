using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
	public class brEF_Municipios:brConexion
	{
	    public int guardarEF_Municipios(beEF_Municipios obeEF_Municipios)
	    {
		    int IdMunicipio;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
		    daEF_Municipios odaEF_Municipios= new daEF_Municipios();
			    IdMunicipio =  odaEF_Municipios.guardarEF_Municipios(con, obeEF_Municipios);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdMunicipio;
			    }
	    }

	    public int actualizarEF_Municipios(beEF_Municipios obeEF_Municipios)
	    {
		    int IdMunicipio;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daEF_Municipios odaEF_Municipios= new daEF_Municipios();
				    IdMunicipio =  odaEF_Municipios.actualizarEF_Municipios(con, obeEF_Municipios);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdMunicipio;
			    }
	    }

	    public int eliminarEF_Municipios(string IdMunicipio)
	    {
                int id = 0;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daEF_Municipios odaEF_Municipios= new daEF_Municipios();
                        id =  odaEF_Municipios.eliminarEF_Municipios(con, IdMunicipio);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return id;
			    }
	    }

	    public beEF_Municipios traerEF_Municipios_x_IdMunicipio (string IdMunicipio)
	    {
		    beEF_Municipios obeEF_Municipios=new beEF_Municipios();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daEF_Municipios odaEF_Municipios= new daEF_Municipios();
				     obeEF_Municipios =  odaEF_Municipios.traerEF_Municipios_x_IdMunicipio(con, IdMunicipio);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obeEF_Municipios;
			    }
	    }

	    public List<beEF_Municipios> listarTodos_EF_Municipios()
	     {
		    List<beEF_Municipios> lbeEF_Municipios =new List<beEF_Municipios>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daEF_Municipios odaEF_Municipios= new daEF_Municipios();
				     lbeEF_Municipios =  odaEF_Municipios.listarTodos_EF_Municipios(con);
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeEF_Municipios;
		    }
	    }
	    public List<beEF_Municipios> listarTodos_EF_Municipios_GetAll()
	    {
		    List<beEF_Municipios> lbeEF_Municipios =new List<beEF_Municipios>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			    try {
				    con.Open();
				    daEF_Municipios odaEF_Municipios= new daEF_Municipios();
				     lbeEF_Municipios =  odaEF_Municipios.listar_EF_Municipios_GetAll(con);
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeEF_Municipios;
		    }
	    }

        public List<beEF_Municipios> traerEF_Municipios_x_ClaveEstado(string ClaveEstado)
        {
            List<beEF_Municipios> lbeEF_Municipios = new List<beEF_Municipios>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEF_Municipios odaEF_Municipios = new daEF_Municipios();
                    lbeEF_Municipios = odaEF_Municipios.traerEF_Municipios_x_ClaveEstado(con, ClaveEstado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeEF_Municipios;
            }
        }

        public List<beEF_Municipios> listarTodos_EF_MunicipiosEstMerc()
        {
            List<beEF_Municipios> lbeEF_Municipios = new List<beEF_Municipios>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEF_Municipios odaEF_Municipios = new daEF_Municipios();
                    lbeEF_Municipios = odaEF_Municipios.listarTodos_EF_MunicipiosEstMer(con);
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
