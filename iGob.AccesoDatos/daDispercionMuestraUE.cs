using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daDispercionMuestraUE
 {
	public int guardarDispercionMuestraUE(SqlConnection Conexion, beDispercionMuestraUE obeDispercionMuestraUE)
	{
		int Id=0;
		string sp = "Proc_DispercionMuestraUEInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDispercionMuestraUE", SqlDbType.Int).Value = obeDispercionMuestraUE.IdDispercionMuestraUE;
				cmd.Parameters.Add("@IdDeterminaPrecioBienServicio", SqlDbType.Int).Value = obeDispercionMuestraUE.IdDeterminaPrecioBienServicio;
				cmd.Parameters.Add("@UnidadEconomica", SqlDbType.VarChar).Value = obeDispercionMuestraUE.UnidadEconomica;
				cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = obeDispercionMuestraUE.Direccion;
				cmd.Parameters.Add("@PrecioSinImpuesto", SqlDbType.Decimal).Value = obeDispercionMuestraUE.PrecioSinImpuesto;
				cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = obeDispercionMuestraUE.Precio;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarDispercionMuestraUE(SqlConnection Conexion, beDispercionMuestraUE obeDispercionMuestraUE)
	{
		string sp = "Proc_DispercionMuestraUEActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDispercionMuestraUE", SqlDbType.Int).Value = obeDispercionMuestraUE.IdDispercionMuestraUE;
				cmd.Parameters.Add("@IdDeterminaPrecioBienServicio", SqlDbType.Int).Value = obeDispercionMuestraUE.IdDeterminaPrecioBienServicio;
				cmd.Parameters.Add("@UnidadEconomica", SqlDbType.VarChar).Value = obeDispercionMuestraUE.UnidadEconomica;
				cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = obeDispercionMuestraUE.Direccion;
				cmd.Parameters.Add("@PrecioSinImpuesto", SqlDbType.Decimal).Value = obeDispercionMuestraUE.PrecioSinImpuesto;
				cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = obeDispercionMuestraUE.Precio;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarDispercionMuestraUE(SqlConnection Conexion,int pIdDispercionMuestraUE)
	{
		string sp = "Proc_DispercionMuestraUEEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDispercionMuestraUE", SqlDbType.Int).Value = pIdDispercionMuestraUE;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beDispercionMuestraUE traerDispercionMuestraUE_x_IdDispercionMuestraUE(SqlConnection Conexion,int IdDispercionMuestraUE)
	{
		string sp = "Proc_DispercionMuestraUE_x_IdDispercionMuestraUE";
				beDispercionMuestraUE obeDispercionMuestraUE=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdDispercionMuestraUE", SqlDbType.Int).Value = IdDispercionMuestraUE;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdDispercionMuestraUE = datard.GetOrdinal("IdDispercionMuestraUE");
						int posIdDeterminaPrecioBienServicio = datard.GetOrdinal("IdDeterminaPrecioBienServicio");
						int posUnidadEconomica = datard.GetOrdinal("UnidadEconomica");
						int posDireccion = datard.GetOrdinal("Direccion");
						int posPrecioSinImpuesto = datard.GetOrdinal("PrecioSinImpuesto");
						int posPrecio = datard.GetOrdinal("Precio");
					 obeDispercionMuestraUE = new beDispercionMuestraUE();
				while (datard.Read())
					{
						obeDispercionMuestraUE.IdDispercionMuestraUE =  datard.GetInt32(posIdDispercionMuestraUE);
						obeDispercionMuestraUE.IdDeterminaPrecioBienServicio =  datard.GetInt32(posIdDeterminaPrecioBienServicio);
						obeDispercionMuestraUE.UnidadEconomica =  datard.GetString(posUnidadEconomica);
						obeDispercionMuestraUE.Direccion =  datard.GetString(posDireccion);
						obeDispercionMuestraUE.PrecioSinImpuesto =  datard.GetDecimal(posPrecioSinImpuesto);
						obeDispercionMuestraUE.Precio =  datard.GetDecimal(posPrecio);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeDispercionMuestraUE;
			}
	}
	public List< beDispercionMuestraUE> listarTodos_DispercionMuestraUE(SqlConnection Conexion)
	 {
		string sp = "Proc_DispercionMuestraUE_Traer_Todos";
		List<beDispercionMuestraUE> lbeDispercionMuestraUE = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdDispercionMuestraUE = datard.GetOrdinal("IdDispercionMuestraUE");
						int posIdDeterminaPrecioBienServicio = datard.GetOrdinal("IdDeterminaPrecioBienServicio");
						int posUnidadEconomica = datard.GetOrdinal("UnidadEconomica");
						int posDireccion = datard.GetOrdinal("Direccion");
						int posPrecioSinImpuesto = datard.GetOrdinal("PrecioSinImpuesto");
						int posPrecio = datard.GetOrdinal("Precio");
				lbeDispercionMuestraUE = new List<beDispercionMuestraUE>();
				beDispercionMuestraUE obeDispercionMuestraUE;
				while (datard.Read())
				{
					 obeDispercionMuestraUE = new beDispercionMuestraUE();
					obeDispercionMuestraUE.IdDispercionMuestraUE =  datard.GetInt32(posIdDispercionMuestraUE);
					obeDispercionMuestraUE.IdDeterminaPrecioBienServicio =  datard.GetInt32(posIdDeterminaPrecioBienServicio);
					obeDispercionMuestraUE.UnidadEconomica =  datard.GetString(posUnidadEconomica);
					obeDispercionMuestraUE.Direccion =  datard.GetString(posDireccion);
					obeDispercionMuestraUE.PrecioSinImpuesto =  datard.GetDecimal(posPrecioSinImpuesto);
					obeDispercionMuestraUE.Precio =  datard.GetDecimal(posPrecio);
					lbeDispercionMuestraUE.Add(obeDispercionMuestraUE);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDispercionMuestraUE;
		}
	}
	public List< beDispercionMuestraUE> listar_DispercionMuestraUE_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_DispercionMuestraUE_TraerTodos_GetAll";
		List<beDispercionMuestraUE> lbeDispercionMuestraUE = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdDispercionMuestraUE = datard.GetOrdinal("IdDispercionMuestraUE");
						int posIdDeterminaPrecioBienServicio = datard.GetOrdinal("IdDeterminaPrecioBienServicio");
						int posUnidadEconomica = datard.GetOrdinal("UnidadEconomica");
						int posDireccion = datard.GetOrdinal("Direccion");
						int posPrecioSinImpuesto = datard.GetOrdinal("PrecioSinImpuesto");
						int posPrecio = datard.GetOrdinal("Precio");
				lbeDispercionMuestraUE = new List<beDispercionMuestraUE>();
				beDispercionMuestraUE obeDispercionMuestraUE;
				while (datard.Read())
				{
					 obeDispercionMuestraUE = new beDispercionMuestraUE();
					obeDispercionMuestraUE.IdDispercionMuestraUE =  datard.GetInt32(posIdDispercionMuestraUE);
					obeDispercionMuestraUE.IdDeterminaPrecioBienServicio =  datard.GetInt32(posIdDeterminaPrecioBienServicio);
					obeDispercionMuestraUE.UnidadEconomica =  datard.GetString(posUnidadEconomica);
					obeDispercionMuestraUE.Direccion =  datard.GetString(posDireccion);
					obeDispercionMuestraUE.PrecioSinImpuesto =  datard.GetDecimal(posPrecioSinImpuesto);
					obeDispercionMuestraUE.Precio =  datard.GetDecimal(posPrecio);
			// debe agregar campos de la Vista
					lbeDispercionMuestraUE.Add(obeDispercionMuestraUE);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDispercionMuestraUE;
		}
	}
}
}
