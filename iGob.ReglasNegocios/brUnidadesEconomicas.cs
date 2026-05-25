using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brUnidadesEconomicas:brConexion
	{
	    public int guardarUnidadesEconomicas(beUnidadesEconomicas obeUnidadesEconomicas)
	    {
		    int Codigo_act;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
		    daUnidadesEconomicas odaUnidadesEconomicas= new daUnidadesEconomicas();
			    Codigo_act =  odaUnidadesEconomicas.guardarUnidadesEconomicas(con, obeUnidadesEconomicas);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return Codigo_act;
			    }
	    }

	    public int actualizarUnidadesEconomicas(beUnidadesEconomicas obeUnidadesEconomicas)
	    {
		    int Codigo_act;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daUnidadesEconomicas odaUnidadesEconomicas = new daUnidadesEconomicas();
                    Codigo_act = odaUnidadesEconomicas.actualizarUnidadesEconomicas(con, obeUnidadesEconomicas);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Codigo_act;
            }
	    }

	    public int eliminarUnidadesEconomicas(int Codigo_act)
	    {
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
		    {
		        try {
			        con.Open();
			        daUnidadesEconomicas odaUnidadesEconomicas= new daUnidadesEconomicas();
			        Codigo_act =  odaUnidadesEconomicas.eliminarUnidadesEconomicas(con, Codigo_act);
			        }
		        catch (Exception ex) {
			        throw ex;
		        }
		        return Codigo_act;
		    }
	    }

	    public beUnidadesEconomicas traerUnidadesEconomicas_x_Codigo_act (int Codigo_act)
	    {
		    beUnidadesEconomicas obeUnidadesEconomicas=new beUnidadesEconomicas();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
		    {
			    try {
				    con.Open();
				    daUnidadesEconomicas odaUnidadesEconomicas= new daUnidadesEconomicas();
				     obeUnidadesEconomicas =  odaUnidadesEconomicas.traerUnidadesEconomicas_x_Codigo_act(con, Codigo_act);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obeUnidadesEconomicas;
		    }
	    }

	    public List<beUnidadesEconomicas> listarTodos_UnidadesEconomicas()
	     {
		    List<beUnidadesEconomicas> lbeUnidadesEconomicas =new List<beUnidadesEconomicas>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
		    {
			    try {
				    con.Open();
				    daUnidadesEconomicas odaUnidadesEconomicas= new daUnidadesEconomicas();
				     lbeUnidadesEconomicas =  odaUnidadesEconomicas.listarTodos_UnidadesEconomicas(con);
			    }
			    catch (Exception ex) {
			        throw ex;
			    }
			    return lbeUnidadesEconomicas;
		    }
	    }

	    public List<beUnidadesEconomicas> listarTodos_UnidadesEconomicas_GetAll()
	     {
		    List<beUnidadesEconomicas> lbeUnidadesEconomicas =new List<beUnidadesEconomicas>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
		    {
			    try {
				    con.Open();
				    daUnidadesEconomicas odaUnidadesEconomicas= new daUnidadesEconomicas();
				     lbeUnidadesEconomicas =  odaUnidadesEconomicas.listar_UnidadesEconomicas_GetAll(con);
			    }
			    catch (Exception ex) {
			        throw ex;
			    }
			    return lbeUnidadesEconomicas;
		    }
	    }

        public beUnidadesEconomicas UnidadesEconomicas_NumeroUnidades(int num, string str)
        {
            beUnidadesEconomicas lbeUnidadesEconomicas = new beUnidadesEconomicas();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daUnidadesEconomicas odaUnidadesEconomicas = new daUnidadesEconomicas();
                    lbeUnidadesEconomicas = odaUnidadesEconomicas.UnidadesEconomicas_NumeroUnidades(con,num,str);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeUnidadesEconomicas;
            }
        }

        public List<beUnidadesEconomicas> UnidadesEconomicas_x_nom_estab(string texto, int cve_ent)/*, int cve_mun*/
        {
            List<beUnidadesEconomicas> lbeUnidadesEconomicas = new List<beUnidadesEconomicas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daUnidadesEconomicas odaUnidadesEconomicas = new daUnidadesEconomicas();
                    lbeUnidadesEconomicas = odaUnidadesEconomicas.UnidadesEconomicas_x_nom_estab(con,texto,cve_ent);/*,cve_mun*/
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeUnidadesEconomicas;
            }
        }

        public List<beUnidadesEconomicas> UnidadesEconomicasMuestra(string TamanoEU, int Codigo, int CveEstado, int NoUnidadesEconomicas, int TamanoMuestra)
        {
            List<beUnidadesEconomicas> lbeUnidadesEconomicas = new List<beUnidadesEconomicas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daUnidadesEconomicas odaUnidadesEconomicas = new daUnidadesEconomicas();
                    lbeUnidadesEconomicas = odaUnidadesEconomicas.UnidadesEconomicasMuestra(con, TamanoEU,Codigo,CveEstado,NoUnidadesEconomicas,TamanoMuestra);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeUnidadesEconomicas;
            }
        }
    }
}
