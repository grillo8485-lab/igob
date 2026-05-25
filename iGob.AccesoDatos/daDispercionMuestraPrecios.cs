using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daDispercionMuestraPrecios
 {
	public int guardarDispercionMuestraPrecios(SqlConnection Conexion, beDispercionMuestraPrecios obeDispercionMuestraPrecios)
	{
		int Id=0;
		string sp = "Proc_DispercionMuestraPreciosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDispercionMuestraPrecio", SqlDbType.Int).Value = obeDispercionMuestraPrecios.IdDispercionMuestraPrecio;
				cmd.Parameters.Add("@IdDeterminaPrecioBienServicio", SqlDbType.Int).Value = obeDispercionMuestraPrecios.IdDeterminaPrecioBienServicio;
				cmd.Parameters.Add("@IdUnidadEconomica", SqlDbType.Int).Value = obeDispercionMuestraPrecios.IdUnidadEconomica;
				cmd.Parameters.Add("@PrecioSinImpuesto", SqlDbType.Decimal).Value = obeDispercionMuestraPrecios.PrecioSinImpuesto;
				cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = obeDispercionMuestraPrecios.Precio;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarDispercionMuestraPrecios(SqlConnection Conexion, beDispercionMuestraPrecios obeDispercionMuestraPrecios)
	{
		string sp = "Proc_DispercionMuestraPreciosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDispercionMuestraPrecio", SqlDbType.Int).Value = obeDispercionMuestraPrecios.IdDispercionMuestraPrecio;
				cmd.Parameters.Add("@IdDeterminaPrecioBienServicio", SqlDbType.Int).Value = obeDispercionMuestraPrecios.IdDeterminaPrecioBienServicio;
				cmd.Parameters.Add("@IdUnidadEconomica", SqlDbType.Int).Value = obeDispercionMuestraPrecios.IdUnidadEconomica;
				cmd.Parameters.Add("@PrecioSinImpuesto", SqlDbType.Decimal).Value = obeDispercionMuestraPrecios.PrecioSinImpuesto;
				cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = obeDispercionMuestraPrecios.Precio;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarDispercionMuestraPrecios(SqlConnection Conexion,int pIdDispercionMuestraPrecio)
	{
		string sp = "Proc_DispercionMuestraPreciosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDispercionMuestraPrecio", SqlDbType.Int).Value = pIdDispercionMuestraPrecio;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beDispercionMuestraPrecios traerDispercionMuestraPrecios_x_IdDispercionMuestraPrecio(SqlConnection Conexion,int IdDispercionMuestraPrecio)
	{
		string sp = "Proc_DispercionMuestraPrecios_x_IdDispercionMuestraPrecio";
				beDispercionMuestraPrecios obeDispercionMuestraPrecios=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdDispercionMuestraPrecio", SqlDbType.Int).Value = IdDispercionMuestraPrecio;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdDispercionMuestraPrecio = datard.GetOrdinal("IdDispercionMuestraPrecio");
						int posIdDeterminaPrecioBienServicio = datard.GetOrdinal("IdDeterminaPrecioBienServicio");
						int posIdUnidadEconomica = datard.GetOrdinal("IdUnidadEconomica");
						int posPrecioSinImpuesto = datard.GetOrdinal("PrecioSinImpuesto");
						int posPrecio = datard.GetOrdinal("Precio");
					 obeDispercionMuestraPrecios = new beDispercionMuestraPrecios();
				while (datard.Read())
					{
						obeDispercionMuestraPrecios.IdDispercionMuestraPrecio =  datard.GetInt32(posIdDispercionMuestraPrecio);
						obeDispercionMuestraPrecios.IdDeterminaPrecioBienServicio =  datard.GetInt32(posIdDeterminaPrecioBienServicio);
						obeDispercionMuestraPrecios.IdUnidadEconomica =  datard.GetInt32(posIdUnidadEconomica);
						obeDispercionMuestraPrecios.PrecioSinImpuesto =  datard.GetDecimal(posPrecioSinImpuesto);
						obeDispercionMuestraPrecios.Precio =  datard.GetDecimal(posPrecio);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeDispercionMuestraPrecios;
			}
	}
	public List< beDispercionMuestraPrecios> listarTodos_DispercionMuestraPrecios(SqlConnection Conexion)
	 {
		string sp = "Proc_DispercionMuestraPrecios_Traer_Todos";
		List<beDispercionMuestraPrecios> lbeDispercionMuestraPrecios = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdDispercionMuestraPrecio = datard.GetOrdinal("IdDispercionMuestraPrecio");
						int posIdDeterminaPrecioBienServicio = datard.GetOrdinal("IdDeterminaPrecioBienServicio");
						int posIdUnidadEconomica = datard.GetOrdinal("IdUnidadEconomica");
						int posPrecioSinImpuesto = datard.GetOrdinal("PrecioSinImpuesto");
						int posPrecio = datard.GetOrdinal("Precio");
                        int posNombreUnidadEconomica = datard.GetOrdinal("NombreUnidadEconomica");

                lbeDispercionMuestraPrecios = new List<beDispercionMuestraPrecios>();
				beDispercionMuestraPrecios obeDispercionMuestraPrecios;
				while (datard.Read())
				{
					 obeDispercionMuestraPrecios = new beDispercionMuestraPrecios();
					obeDispercionMuestraPrecios.IdDispercionMuestraPrecio =  datard.GetInt32(posIdDispercionMuestraPrecio);
					obeDispercionMuestraPrecios.IdDeterminaPrecioBienServicio =  datard.GetInt32(posIdDeterminaPrecioBienServicio);
					obeDispercionMuestraPrecios.IdUnidadEconomica =  datard.GetInt32(posIdUnidadEconomica);
					obeDispercionMuestraPrecios.PrecioSinImpuesto =  datard.GetDecimal(posPrecioSinImpuesto);
					obeDispercionMuestraPrecios.Precio =  datard.GetDecimal(posPrecio);
					obeDispercionMuestraPrecios.NombreUnidadEconomica =  datard.GetString(posNombreUnidadEconomica);
                            lbeDispercionMuestraPrecios.Add(obeDispercionMuestraPrecios);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDispercionMuestraPrecios;
		}
	}
	public List< beDispercionMuestraPrecios> listar_DispercionMuestraPrecios_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_DispercionMuestraPrecios_TraerTodos_GetAll";
		List<beDispercionMuestraPrecios> lbeDispercionMuestraPrecios = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdDispercionMuestraPrecio = datard.GetOrdinal("IdDispercionMuestraPrecio");
						int posIdDeterminaPrecioBienServicio = datard.GetOrdinal("IdDeterminaPrecioBienServicio");
						int posIdUnidadEconomica = datard.GetOrdinal("IdUnidadEconomica");
						int posPrecioSinImpuesto = datard.GetOrdinal("PrecioSinImpuesto");
						int posPrecio = datard.GetOrdinal("Precio");
				lbeDispercionMuestraPrecios = new List<beDispercionMuestraPrecios>();
				beDispercionMuestraPrecios obeDispercionMuestraPrecios;
				while (datard.Read())
				{
					 obeDispercionMuestraPrecios = new beDispercionMuestraPrecios();
					obeDispercionMuestraPrecios.IdDispercionMuestraPrecio =  datard.GetInt32(posIdDispercionMuestraPrecio);
					obeDispercionMuestraPrecios.IdDeterminaPrecioBienServicio =  datard.GetInt32(posIdDeterminaPrecioBienServicio);
					obeDispercionMuestraPrecios.IdUnidadEconomica =  datard.GetInt32(posIdUnidadEconomica);
					obeDispercionMuestraPrecios.PrecioSinImpuesto =  datard.GetDecimal(posPrecioSinImpuesto);
					obeDispercionMuestraPrecios.Precio =  datard.GetDecimal(posPrecio);
			// debe agregar campos de la Vista
					lbeDispercionMuestraPrecios.Add(obeDispercionMuestraPrecios);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDispercionMuestraPrecios;
		}
	}
}
}
