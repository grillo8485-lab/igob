using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
	public class brLugaresEntregasPagosCM:brConexion
	{
	    public int guardarLugaresEntregasPagosCM(beLugaresEntregasPagosCM obeLugaresEntregasPagosCM)
	    {
		    int IdLugarEntregaFirma;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
		        daLugaresEntregasPagosCM odaLugaresEntregasPagosCM= new daLugaresEntregasPagosCM();
			    IdLugarEntregaFirma =  odaLugaresEntregasPagosCM.guardarLugaresEntregasPagosCM(con, obeLugaresEntregasPagosCM);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdLugarEntregaFirma;
			    }
	    }

	    public int actualizarLugaresEntregasPagosCM(beLugaresEntregasPagosCM obeLugaresEntregasPagosCM)
	    {
		    int IdLugarEntregaFirma;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daLugaresEntregasPagosCM odaLugaresEntregasPagosCM= new daLugaresEntregasPagosCM();
				    IdLugarEntregaFirma =  odaLugaresEntregasPagosCM.actualizarLugaresEntregasPagosCM(con, obeLugaresEntregasPagosCM);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdLugarEntregaFirma;
			    }
	    }

	    public int eliminarLugaresEntregasPagosCM(int IdLugarEntregaFirma)
	    {
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daLugaresEntregasPagosCM odaLugaresEntregasPagosCM= new daLugaresEntregasPagosCM();
				    IdLugarEntregaFirma =  odaLugaresEntregasPagosCM.eliminarLugaresEntregasPagosCM(con, IdLugarEntregaFirma);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdLugarEntregaFirma;
			    }
	    }

	    public beLugaresEntregasPagosCM traerLugaresEntregasPagosCM_x_IdLugarEntregaPago(int IdLugarEntregaPago)
	    {
		    beLugaresEntregasPagosCM obeLugaresEntregasPagosCM=new beLugaresEntregasPagosCM();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daLugaresEntregasPagosCM odaLugaresEntregasPagosCM= new daLugaresEntregasPagosCM();
				     obeLugaresEntregasPagosCM =  odaLugaresEntregasPagosCM.traerLugaresEntregasPagosCM_x_IdLugarEntregaPago(con, IdLugarEntregaPago);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obeLugaresEntregasPagosCM;
			    }
	    }

	    public List<beLugaresEntregasPagosCM> listarTodos_LugaresEntregasPagosCM()
	    {
		    List<beLugaresEntregasPagosCM> lbeLugaresEntregasPagosCM =new List<beLugaresEntregasPagosCM>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daLugaresEntregasPagosCM odaLugaresEntregasPagosCM= new daLugaresEntregasPagosCM();
				     lbeLugaresEntregasPagosCM =  odaLugaresEntregasPagosCM.listarTodos_LugaresEntregasPagosCM(con);
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeLugaresEntregasPagosCM;
		    }
	    }
	    public List<beLugaresEntregasPagosCM> listarTodos_LugaresEntregasPagosCM_GetAll()
	    {
		    List<beLugaresEntregasPagosCM> lbeLugaresEntregasPagosCM =new List<beLugaresEntregasPagosCM>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daLugaresEntregasPagosCM odaLugaresEntregasPagosCM= new daLugaresEntregasPagosCM();
				     lbeLugaresEntregasPagosCM =  odaLugaresEntregasPagosCM.listar_LugaresEntregasPagosCM_GetAll(con);
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeLugaresEntregasPagosCM;
		    }
	    }

        public List<beLugaresEntregasPagosCM> traerLugaresPagosCM_x_IdDependencia(int IdDependencia)
        {
            List<beLugaresEntregasPagosCM> lbeLugaresEntregasPagosCM = new List<beLugaresEntregasPagosCM>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLugaresEntregasPagosCM odaLugaresEntregasPagosCM = new daLugaresEntregasPagosCM();
                    lbeLugaresEntregasPagosCM = odaLugaresEntregasPagosCM.traerLugaresPagosCM_x_IdDependencia(con, IdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregasPagosCM;
            }
        }

        public List<beLugaresEntregasPagosCM> traerLugaresEntregasCM_x_IdDependencia(int IdDependencia)
        {
            List<beLugaresEntregasPagosCM> lbeLugaresEntregasPagosCM = new List<beLugaresEntregasPagosCM>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLugaresEntregasPagosCM odaLugaresEntregasPagosCM = new daLugaresEntregasPagosCM();
                    lbeLugaresEntregasPagosCM = odaLugaresEntregasPagosCM.traerLugaresEntregasCM_x_IdDependencia(con, IdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregasPagosCM;
            }
        }

        public List<beLugaresEntregasPagosCM> traerLugaresEntregasPagosCM_x_IdDependencia(int IdDependencia)
        {
            List<beLugaresEntregasPagosCM> lbeLugaresEntregasPagosCM = new List<beLugaresEntregasPagosCM>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLugaresEntregasPagosCM odaLugaresEntregasPagosCM = new daLugaresEntregasPagosCM();
                    lbeLugaresEntregasPagosCM = odaLugaresEntregasPagosCM.traerLugaresEntregasPagosCM_x_IdDependencia(con, IdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregasPagosCM;
            }
        }
    }
}
