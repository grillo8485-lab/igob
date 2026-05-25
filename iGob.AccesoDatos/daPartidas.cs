using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daPartidas
 {
	public int guardarPartidas(SqlConnection Conexion, bePartidas obePartidas)
	{
		int Id=0;
		string sp = "Proc_PartidasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obePartidas.IdPartida;
				cmd.Parameters.Add("@IdPartidaGenerica", SqlDbType.Int).Value = obePartidas.IdPartidaGenerica;
				cmd.Parameters.Add("@IdCapitulo", SqlDbType.Int).Value = obePartidas.IdCapitulo;
				cmd.Parameters.Add("@ClavePartida", SqlDbType.NChar).Value = obePartidas.ClavePartida;
				cmd.Parameters.Add("@Partida", SqlDbType.VarChar).Value = obePartidas.Partida;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obePartidas.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obePartidas.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarPartidas(SqlConnection Conexion, bePartidas obePartidas)
	{
		string sp = "Proc_PartidasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obePartidas.IdPartida;
				cmd.Parameters.Add("@IdPartidaGenerica", SqlDbType.Int).Value = obePartidas.IdPartidaGenerica;
				cmd.Parameters.Add("@IdCapitulo", SqlDbType.Int).Value = obePartidas.IdCapitulo;
				cmd.Parameters.Add("@ClavePartida", SqlDbType.NChar).Value = obePartidas.ClavePartida;
				cmd.Parameters.Add("@Partida", SqlDbType.VarChar).Value = obePartidas.Partida;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obePartidas.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obePartidas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarPartidas(SqlConnection Conexion,int pIdPartida)
	{
		string sp = "Proc_PartidasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = pIdPartida;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public bePartidas traerPartidas_x_IdPartida(SqlConnection Conexion,int IdPartida)
	{
		string sp = "Proc_Partidas_x_IdPartida";
		List<bePartidas> lbePartidas = null;
				bePartidas obePartidas=new bePartidas();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = IdPartida;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbePartidas = new List<bePartidas>();
				while (datard.Read())
					{
					 obePartidas = new bePartidas();
						obePartidas.IdPartida =  datard.GetInt32(0);
						obePartidas.IdPartidaGenerica =  datard.GetInt32(1);
						obePartidas.IdCapitulo =  datard.GetInt32(2);
						obePartidas.ClavePartida =  datard.GetString(3);
						obePartidas.Partida =  datard.GetString(4);
						obePartidas.Descripcion =  datard.GetString(5);
						obePartidas.Activo =  datard.GetBoolean(6);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePartidas;
			}
	}
	public List< bePartidas> listarTodos_Partidas(SqlConnection Conexion)
	 {
		string sp = "Proc_Partidas_Traer_Todos";
		List<bePartidas> lbePartidas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbePartidas = new List<bePartidas>();
				bePartidas obePartidas;
				while (datard.Read())
				{
					 obePartidas = new bePartidas();
					obePartidas.IdPartida =  datard.GetInt32(0);
					obePartidas.IdPartidaGenerica =  datard.GetInt32(1);
					obePartidas.IdCapitulo =  datard.GetInt32(2);
					obePartidas.ClavePartida =  datard.GetString(3);
					obePartidas.Partida =  datard.GetString(4);
					obePartidas.Descripcion =  datard.GetString(5);
					obePartidas.Activo =  datard.GetBoolean(6);
					lbePartidas.Add(obePartidas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePartidas;
		}
	}
        public List<bePartidas> listarPartidas_x_IdCapitulo(SqlConnection Conexion,int pIdCapitulo)
        {
            string sp = "Proc_Partidas_x_IdCapitulo";
            List<bePartidas> lbePartidas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCapitulo", SqlDbType.Int).Value = pIdCapitulo;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbePartidas = new List<bePartidas>();
                        bePartidas obePartidas;
                        while (datard.Read())
                        {
                            obePartidas = new bePartidas();
                            obePartidas.IdPartida = datard.GetInt32(0);
                            obePartidas.IdPartidaGenerica = datard.GetInt32(1);
                            obePartidas.IdCapitulo = datard.GetInt32(2);
                            obePartidas.ClavePartida = datard.GetString(3);
                            obePartidas.Partida = datard.GetString(4);
                            obePartidas.Descripcion = datard.GetString(5);
                            obePartidas.Activo = datard.GetBoolean(6);
                            lbePartidas.Add(obePartidas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePartidas;
            }
        }
        public DataTable listarPartidas_x_(SqlConnection Conexion,int IdPartida)
	 {
		string sp = "Proc_Partidas_Traer_Todos";
		DataTable dtPartidas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = IdPartida;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtPartidas = new DataTable();
				dtPartidas.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtPartidas;
		}
	}
}
}
