using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
	public class brPlantillas:brConexion
    {
	    public int guardarPlantillas(bePlantillas obePlantillas)
	    {
		    int IdPlantilla;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
		    daPlantillas odaPlantillas= new daPlantillas();
			    IdPlantilla =  odaPlantillas.guardarPlantillas(con, obePlantillas);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdPlantilla;
			    }
	    }

	    public int actualizarPlantillas(bePlantillas obePlantillas)
	    {
		    int IdPlantilla;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daPlantillas odaPlantillas= new daPlantillas();
				    IdPlantilla =  odaPlantillas.actualizarPlantillas(con, obePlantillas);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdPlantilla;
			    }
	    }

	    public int eliminarPlantillas(int IdPlantilla)
	    {
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daPlantillas odaPlantillas= new daPlantillas();
				    IdPlantilla =  odaPlantillas.eliminarPlantillas(con, IdPlantilla);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdPlantilla;
			    }
	    }

	    public bePlantillas traerPlantillas_x_IdPlantilla (int IdPlantilla)
	    {
		    bePlantillas obePlantillas=new bePlantillas();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daPlantillas odaPlantillas= new daPlantillas();
				     obePlantillas =  odaPlantillas.traerPlantillas_x_IdPlantilla(con, IdPlantilla);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obePlantillas;
			    }
	    }

	    public List<bePlantillas> listarTodos_Plantillas()
	     {
		    List<bePlantillas> lbePlantillas =new List<bePlantillas>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daPlantillas odaPlantillas= new daPlantillas();
				     lbePlantillas =  odaPlantillas.listarTodos_Plantillas(con);
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbePlantillas;
		    }
	    }

	    public List<bePlantillas> listarTodos_Plantillas_GetAll()
	     {
		    List<bePlantillas> lbePlantillas =new List<bePlantillas>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daPlantillas odaPlantillas= new daPlantillas();
				     lbePlantillas =  odaPlantillas.listar_Plantillas_GetAll(con);
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbePlantillas;
		    }
	    }

        public bePlantillas traerPlantillas_x_IdTipoUsoPlantilla(int IdTipoUsoPlantilla, int IdGobierno)
        {
            bePlantillas obePlantillas = new bePlantillas();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPlantillas odaPlantillas = new daPlantillas();
                    obePlantillas = odaPlantillas.traerPlantillas_x_IdTipoUsoPlantilla(con, IdTipoUsoPlantilla, IdGobierno);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obePlantillas;
            }
        }

        public List<bePlantillas> listar_Plantillas_TipoUso()
        {
            List<bePlantillas> lbePlantillas = new List<bePlantillas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPlantillas odaPlantillas = new daPlantillas();
                    lbePlantillas = odaPlantillas.listar_Plantillas_TipoUso(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePlantillas;
            }
        }

        public List<bePlantillas> listar_TipoUso(int IdGobierno)
        {
            List<bePlantillas> lbePlantillas = new List<bePlantillas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPlantillas odaPlantillas = new daPlantillas();
                    lbePlantillas = odaPlantillas.listar_TipoUso(con, IdGobierno);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePlantillas;
            }
        }

        public bePlantillas traerPlantillas_x_IdPlantilla_GetAll(int IdPlantilla)
        {
            bePlantillas obePlantillas = new bePlantillas();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPlantillas odaPlantillas = new daPlantillas();
                    obePlantillas = odaPlantillas.traerPlantillas_x_IdPlantilla_GetAll(con, IdPlantilla);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obePlantillas;
            }
        }
    }
}
