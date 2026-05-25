using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daPlantillas
    {
	    public int guardarPlantillas(SqlConnection Conexion, bePlantillas obePlantillas)
	    {
		    int Id=0;
		    string sp = "Proc_PlantillasInsertar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdPlantilla", SqlDbType.Int).Value = obePlantillas.IdPlantilla;
				    cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obePlantillas.IdGobierno;
				    cmd.Parameters.Add("@IdTipoUsoPlantilla", SqlDbType.Int).Value = obePlantillas.IdTipoUsoPlantilla;
				    cmd.Parameters.Add("@UrlPlantilla", SqlDbType.Text).Value = obePlantillas.UrlPlantilla;
				    cmd.Parameters.Add("@NombreArchivo", SqlDbType.NVarChar).Value = obePlantillas.NombreArchivo;
				    cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = obePlantillas.Descripcion;
			
				    Id =(int)cmd.ExecuteScalar();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return Id;
			    }
	    }

	    public int actualizarPlantillas(SqlConnection Conexion, bePlantillas obePlantillas)
	    {
		    string sp = "Proc_PlantillasActualizar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdPlantilla", SqlDbType.Int).Value = obePlantillas.IdPlantilla;
				    cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obePlantillas.IdGobierno;
				    cmd.Parameters.Add("@IdTipoUsoPlantilla", SqlDbType.Int).Value = obePlantillas.IdTipoUsoPlantilla;
				    cmd.Parameters.Add("@UrlPlantilla", SqlDbType.Text).Value = obePlantillas.UrlPlantilla;
				    cmd.Parameters.Add("@NombreArchivo", SqlDbType.NVarChar).Value = obePlantillas.NombreArchivo;
				    cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = obePlantillas.Descripcion;
			
				    cmd.ExecuteNonQuery();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return 0;
			    }
	    }

	    public int eliminarPlantillas(SqlConnection Conexion,int pIdPlantilla)
	    {
		    string sp = "Proc_PlantillasEliminar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdPlantilla", SqlDbType.Int).Value = pIdPlantilla;
				    cmd.ExecuteNonQuery();
				    }
				    catch (Exception ex) {
					    throw ex;
				    }
			    return 0;
			    }
	    }
	    public bePlantillas traerPlantillas_x_IdPlantilla(SqlConnection Conexion,int IdPlantilla)
	    {
		    string sp = "Proc_Plantillas_x_IdPlantilla";
				    bePlantillas obePlantillas=null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    cmd.Parameters.Add("@IdPlantilla", SqlDbType.Int).Value = IdPlantilla;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
			    try {
				    if (datard != null)
				    {
						    int posIdPlantilla = datard.GetOrdinal("IdPlantilla");
						    int posIdGobierno = datard.GetOrdinal("IdGobierno");
						    int posIdTipoUsoPlantilla = datard.GetOrdinal("IdTipoUsoPlantilla");
						    int posUrlPlantilla = datard.GetOrdinal("UrlPlantilla");
						    int posNombreArchivo = datard.GetOrdinal("NombreArchivo");
						    int posDescripcion = datard.GetOrdinal("Descripcion");
					     obePlantillas = new bePlantillas();
				    while (datard.Read())
					    {
						    obePlantillas.IdPlantilla =  datard.GetInt32(posIdPlantilla);
						    obePlantillas.IdGobierno =  datard.GetInt32(posIdGobierno);
						    obePlantillas.IdTipoUsoPlantilla =  datard.GetInt32(posIdTipoUsoPlantilla);
						    obePlantillas.UrlPlantilla =  datard.GetString(posUrlPlantilla);
						    obePlantillas.NombreArchivo =  datard.GetString(posNombreArchivo);
						    obePlantillas.Descripcion =  datard.GetString(posDescripcion);
					    }
				    }
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obePlantillas;
			    }
	    }
	    public List< bePlantillas> listarTodos_Plantillas(SqlConnection Conexion)
	     {
		    string sp = "Proc_Plantillas_Traer_Todos";
		    List<bePlantillas> lbePlantillas = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdPlantilla = datard.GetOrdinal("IdPlantilla");
						    int posIdGobierno = datard.GetOrdinal("IdGobierno");
						    int posIdTipoUsoPlantilla = datard.GetOrdinal("IdTipoUsoPlantilla");
						    int posUrlPlantilla = datard.GetOrdinal("UrlPlantilla");
						    int posNombreArchivo = datard.GetOrdinal("NombreArchivo");
						    int posDescripcion = datard.GetOrdinal("Descripcion");
				    lbePlantillas = new List<bePlantillas>();
				    bePlantillas obePlantillas;
				    while (datard.Read())
				    {
					     obePlantillas = new bePlantillas();
					    obePlantillas.IdPlantilla =  datard.GetInt32(posIdPlantilla);
					    obePlantillas.IdGobierno =  datard.GetInt32(posIdGobierno);
					    obePlantillas.IdTipoUsoPlantilla =  datard.GetInt32(posIdTipoUsoPlantilla);
					    obePlantillas.UrlPlantilla =  datard.GetString(posUrlPlantilla);
					    obePlantillas.NombreArchivo =  datard.GetString(posNombreArchivo);
					    obePlantillas.Descripcion =  datard.GetString(posDescripcion);
					    lbePlantillas.Add(obePlantillas);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbePlantillas;
		    }
	    }
	    public List< bePlantillas> listar_Plantillas_GetAll(SqlConnection Conexion)
	     {
		    string sp = "Proc_Plantillas_TraerTodos_GetAll";
		    List<bePlantillas> lbePlantillas = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdPlantilla = datard.GetOrdinal("IdPlantilla");
						    int posIdGobierno = datard.GetOrdinal("IdGobierno");
						    int posIdTipoUsoPlantilla = datard.GetOrdinal("IdTipoUsoPlantilla");
						    int posUrlPlantilla = datard.GetOrdinal("UrlPlantilla");
						    int posNombreArchivo = datard.GetOrdinal("NombreArchivo");
						    int posDescripcion = datard.GetOrdinal("Descripcion");
				    lbePlantillas = new List<bePlantillas>();
				    bePlantillas obePlantillas;
				    while (datard.Read())
				    {
					     obePlantillas = new bePlantillas();
					    obePlantillas.IdPlantilla =  datard.GetInt32(posIdPlantilla);
					    obePlantillas.IdGobierno =  datard.GetInt32(posIdGobierno);
					    obePlantillas.IdTipoUsoPlantilla =  datard.GetInt32(posIdTipoUsoPlantilla);
					    obePlantillas.UrlPlantilla =  datard.GetString(posUrlPlantilla);
					    obePlantillas.NombreArchivo =  datard.GetString(posNombreArchivo);
					    obePlantillas.Descripcion =  datard.GetString(posDescripcion);
			    // debe agregar campos de la Vista
					    lbePlantillas.Add(obePlantillas);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbePlantillas;
		    }
	    }
        public bePlantillas traerPlantillas_x_IdTipoUsoPlantilla(SqlConnection Conexion, int IdTipoUsoPlantilla, int IdGobierno)
        {
            string sp = "Proc_Plantillas_x_IdTipoUsoPlantilla";
            bePlantillas obePlantillas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdTipoUsoPlantilla", SqlDbType.Int).Value = IdTipoUsoPlantilla;
            cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = IdGobierno;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        
                        int posIdPlantilla = datard.GetOrdinal("IdPlantilla");
                        int posIdTipoUsoPlantilla = datard.GetOrdinal("IdTipoUsoPlantilla");
                        int posUrlPlantilla = datard.GetOrdinal("UrlPlantilla");
                        int posNombreArchivo = datard.GetOrdinal("NombreArchivo");
                        int posTipoUso = datard.GetOrdinal("TipoUso");
                        obePlantillas = new bePlantillas();
                        while (datard.Read())
                        {
                            obePlantillas.UrlPlantilla = datard.GetString(posUrlPlantilla);
                            obePlantillas.NombreArchivo = datard.GetString(posNombreArchivo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obePlantillas;
            }
        }

        public List<bePlantillas> listar_Plantillas_TipoUso(SqlConnection Conexion)
        {
            string sp = "Proc_Plantillas_Traer_TipoUso";
            List<bePlantillas> lbePlantillas = new List<bePlantillas>();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPlantilla = datard.GetOrdinal("IdPlantilla");
                        int posIdTipoUsoPlantilla = datard.GetOrdinal("IdTipoUsoPlantilla");
                        int posUrlPlantilla = datard.GetOrdinal("UrlPlantilla");
                        int posNombreArchivo = datard.GetOrdinal("NombreArchivo");
                        int posTipoUso = datard.GetOrdinal("TipoUso");                        
                        bePlantillas obePlantillas;
                        while (datard.Read())
                        {
                            obePlantillas = new bePlantillas();
                            obePlantillas.IdPlantilla = datard.GetInt32(posIdPlantilla);
                            obePlantillas.IdTipoUsoPlantilla = datard.GetInt32(posIdTipoUsoPlantilla);
                            obePlantillas.UrlPlantilla = datard.GetString(posUrlPlantilla);
                            obePlantillas.NombreArchivo = datard.GetString(posNombreArchivo);
                            obePlantillas.TipoUso = datard.GetString(posTipoUso);
                            lbePlantillas.Add(obePlantillas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePlantillas;
            }
        }

        public List<bePlantillas> listar_TipoUso(SqlConnection Conexion, int IdGobierno)
        {
            string sp = "Proc_PlantillasTipoUsoSinAsignarArchivo_IdGobierno";
            List<bePlantillas> lbePlantillas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = IdGobierno;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdTipoUsoPlantilla = datard.GetOrdinal("IdTipoUsoPlantilla");
                        int posTipoUso = datard.GetOrdinal("TipoUso");
                        lbePlantillas = new List<bePlantillas>();
                        bePlantillas obePlantillas;
                        while (datard.Read())
                        {
                            obePlantillas = new bePlantillas();
                            obePlantillas.IdTipoUsoPlantilla = datard.GetInt32(posIdTipoUsoPlantilla);
                            obePlantillas.TipoUso = datard.GetString(posTipoUso);
                            lbePlantillas.Add(obePlantillas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePlantillas;
            }
        }

        public bePlantillas traerPlantillas_x_IdPlantilla_GetAll(SqlConnection Conexion, int IdPlantilla)
        {
            string sp = "Proc_Plantillas_x_IdPlantilla_GetAll";
            bePlantillas obePlantillas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPlantilla", SqlDbType.Int).Value = IdPlantilla;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPlantilla = datard.GetOrdinal("IdPlantilla");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        int posIdTipoUsoPlantilla = datard.GetOrdinal("IdTipoUsoPlantilla");
                        int posUrlPlantilla = datard.GetOrdinal("UrlPlantilla");
                        int posNombreArchivo = datard.GetOrdinal("NombreArchivo");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posTipoUso = datard.GetOrdinal("TipoUso");
                        obePlantillas = new bePlantillas();
                        while (datard.Read())
                        {
                            obePlantillas.IdPlantilla = datard.GetInt32(posIdPlantilla);
                            obePlantillas.IdGobierno = datard.GetInt32(posIdGobierno);
                            obePlantillas.IdTipoUsoPlantilla = datard.GetInt32(posIdTipoUsoPlantilla);
                            obePlantillas.UrlPlantilla = datard.GetString(posUrlPlantilla);
                            obePlantillas.NombreArchivo = datard.GetString(posNombreArchivo);
                            obePlantillas.Descripcion = datard.GetString(posDescripcion);
                            obePlantillas.TipoUso = datard.GetString(posTipoUso);
                        }
                    }
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
