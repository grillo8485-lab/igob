using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daDeterminacionPrecios
 {
	public int guardarDeterminacionPrecios(SqlConnection Conexion, beDeterminacionPrecios obeDeterminacionPrecios)
	{
		int Id=0;
		string sp = "Proc_DeterminacionPreciosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDeterminaPrecioBienServicio", SqlDbType.Int).Value = obeDeterminacionPrecios.IdDeterminaPrecioBienServicio;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeDeterminacionPrecios.IdBienServicio;
				cmd.Parameters.Add("@IdDatoEstudioMercado", SqlDbType.Int).Value = obeDeterminacionPrecios.IdDatoEstudioMercado;
				cmd.Parameters.Add("@Poblacion", SqlDbType.Int).Value = obeDeterminacionPrecios.Poblacion;
				cmd.Parameters.Add("@NivelConfianza", SqlDbType.Decimal).Value = obeDeterminacionPrecios.NivelConfianza;
				cmd.Parameters.Add("@ConstanteNivelConfianza", SqlDbType.Decimal).Value = obeDeterminacionPrecios.ConstanteNivelConfianza;
				cmd.Parameters.Add("@Varianza", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Varianza;
				cmd.Parameters.Add("@MargenError", SqlDbType.Decimal).Value = obeDeterminacionPrecios.MargenError;
				cmd.Parameters.Add("@Muestra", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Muestra;
				cmd.Parameters.Add("@MuestraRedondeada", SqlDbType.Int).Value = obeDeterminacionPrecios.MuestraRedondeada;
				cmd.Parameters.Add("@FechaCalculoMuestra", SqlDbType.DateTime).Value = obeDeterminacionPrecios.FechaCalculoMuestra;
				cmd.Parameters.Add("@Promedio", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Promedio;
				cmd.Parameters.Add("@Maximo", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Maximo;
				cmd.Parameters.Add("@Minimo", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Minimo;
				cmd.Parameters.Add("@Moda", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Moda;
				cmd.Parameters.Add("@Mediana", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Mediana;
				cmd.Parameters.Add("@FechaCalculoPrecio", SqlDbType.DateTime).Value = obeDeterminacionPrecios.FechaCalculoPrecio;
				cmd.Parameters.Add("@PrecioAplicado", SqlDbType.Decimal).Value = obeDeterminacionPrecios.PrecioAplicado;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarDeterminacionPrecios(SqlConnection Conexion, beDeterminacionPrecios obeDeterminacionPrecios)
	{
		string sp = "Proc_DeterminacionPreciosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDeterminaPrecioBienServicio", SqlDbType.Int).Value = obeDeterminacionPrecios.IdDeterminaPrecioBienServicio;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeDeterminacionPrecios.IdBienServicio;
				cmd.Parameters.Add("@IdDatoEstudioMercado", SqlDbType.Int).Value = obeDeterminacionPrecios.IdDatoEstudioMercado;
				cmd.Parameters.Add("@Poblacion", SqlDbType.Int).Value = obeDeterminacionPrecios.Poblacion;
				cmd.Parameters.Add("@NivelConfianza", SqlDbType.Decimal).Value = obeDeterminacionPrecios.NivelConfianza;
				cmd.Parameters.Add("@ConstanteNivelConfianza", SqlDbType.Decimal).Value = obeDeterminacionPrecios.ConstanteNivelConfianza;
				cmd.Parameters.Add("@Varianza", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Varianza;
				cmd.Parameters.Add("@MargenError", SqlDbType.Decimal).Value = obeDeterminacionPrecios.MargenError;
				cmd.Parameters.Add("@Muestra", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Muestra;
				cmd.Parameters.Add("@MuestraRedondeada", SqlDbType.Int).Value = obeDeterminacionPrecios.MuestraRedondeada;
				cmd.Parameters.Add("@FechaCalculoMuestra", SqlDbType.DateTime).Value = obeDeterminacionPrecios.FechaCalculoMuestra;
				cmd.Parameters.Add("@Promedio", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Promedio;
				cmd.Parameters.Add("@Maximo", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Maximo;
				cmd.Parameters.Add("@Minimo", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Minimo;
				cmd.Parameters.Add("@Moda", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Moda;
				cmd.Parameters.Add("@Mediana", SqlDbType.Decimal).Value = obeDeterminacionPrecios.Mediana;
				cmd.Parameters.Add("@FechaCalculoPrecio", SqlDbType.DateTime).Value = obeDeterminacionPrecios.FechaCalculoPrecio;
				cmd.Parameters.Add("@PrecioAplicado", SqlDbType.Decimal).Value = obeDeterminacionPrecios.PrecioAplicado;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarDeterminacionPrecios(SqlConnection Conexion,int pIdDeterminaPrecioBienServicio)
	{
		string sp = "Proc_DeterminacionPreciosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdDeterminaPrecioBienServicio", SqlDbType.Int).Value = pIdDeterminaPrecioBienServicio;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beDeterminacionPrecios traerDeterminacionPrecios_x_IdDeterminaPrecioBienServicio(SqlConnection Conexion,int IdDeterminaPrecioBienServicio)
	{
		string sp = "Proc_DeterminacionPrecios_x_IdDeterminaPrecioBienServicio";
				beDeterminacionPrecios obeDeterminacionPrecios=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdDeterminaPrecioBienServicio", SqlDbType.Int).Value = IdDeterminaPrecioBienServicio;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdDeterminaPrecioBienServicio = datard.GetOrdinal("IdDeterminaPrecioBienServicio");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
						int posPoblacion = datard.GetOrdinal("Poblacion");
						int posNivelConfianza = datard.GetOrdinal("NivelConfianza");
						int posConstanteNivelConfianza = datard.GetOrdinal("ConstanteNivelConfianza");
						int posVarianza = datard.GetOrdinal("Varianza");
						int posMargenError = datard.GetOrdinal("MargenError");
						int posMuestra = datard.GetOrdinal("Muestra");
						int posMuestraRedondeada = datard.GetOrdinal("MuestraRedondeada");
						int posFechaCalculoMuestra = datard.GetOrdinal("FechaCalculoMuestra");
						int posPromedio = datard.GetOrdinal("Promedio");
						int posMaximo = datard.GetOrdinal("Maximo");
						int posMinimo = datard.GetOrdinal("Minimo");
						int posModa = datard.GetOrdinal("Moda");
						int posMediana = datard.GetOrdinal("Mediana");
						int posFechaCalculoPrecio = datard.GetOrdinal("FechaCalculoPrecio");
						int posPrecioAplicado = datard.GetOrdinal("PrecioAplicado");
					 obeDeterminacionPrecios = new beDeterminacionPrecios();
				while (datard.Read())
					{
						obeDeterminacionPrecios.IdDeterminaPrecioBienServicio =  datard.GetInt32(posIdDeterminaPrecioBienServicio);
						obeDeterminacionPrecios.IdBienServicio =  datard.GetInt32(posIdBienServicio);
						obeDeterminacionPrecios.IdDatoEstudioMercado =  datard.GetInt32(posIdDatoEstudioMercado);
						obeDeterminacionPrecios.Poblacion =  datard.GetInt32(posPoblacion);
						obeDeterminacionPrecios.NivelConfianza =  datard.GetDecimal(posNivelConfianza);
						obeDeterminacionPrecios.ConstanteNivelConfianza =  datard.GetDecimal(posConstanteNivelConfianza);
						obeDeterminacionPrecios.Varianza =  datard.GetDecimal(posVarianza);
						obeDeterminacionPrecios.MargenError =  datard.GetDecimal(posMargenError);
						obeDeterminacionPrecios.Muestra =  datard.GetDecimal(posMuestra);
						obeDeterminacionPrecios.MuestraRedondeada =  datard.GetInt32(posMuestraRedondeada);
						obeDeterminacionPrecios.FechaCalculoMuestra =  datard.GetDateTime(posFechaCalculoMuestra);
						obeDeterminacionPrecios.Promedio =  datard.GetDecimal(posPromedio);
						obeDeterminacionPrecios.Maximo =  datard.GetDecimal(posMaximo);
						obeDeterminacionPrecios.Minimo =  datard.GetDecimal(posMinimo);
						obeDeterminacionPrecios.Moda =  datard.GetDecimal(posModa);
						obeDeterminacionPrecios.Mediana =  datard.GetDecimal(posMediana);
						obeDeterminacionPrecios.FechaCalculoPrecio =  datard.GetDateTime(posFechaCalculoPrecio);
						obeDeterminacionPrecios.PrecioAplicado =  datard.GetDecimal(posPrecioAplicado);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeDeterminacionPrecios;
			}
	}
	public List< beDeterminacionPrecios> listarTodos_DeterminacionPrecios(SqlConnection Conexion)
	 {
		string sp = "Proc_DeterminacionPrecios_Traer_Todos";
		List<beDeterminacionPrecios> lbeDeterminacionPrecios = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdDeterminaPrecioBienServicio = datard.GetOrdinal("IdDeterminaPrecioBienServicio");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
						int posPoblacion = datard.GetOrdinal("Poblacion");
						int posNivelConfianza = datard.GetOrdinal("NivelConfianza");
						int posConstanteNivelConfianza = datard.GetOrdinal("ConstanteNivelConfianza");
						int posVarianza = datard.GetOrdinal("Varianza");
						int posMargenError = datard.GetOrdinal("MargenError");
						int posMuestra = datard.GetOrdinal("Muestra");
						int posMuestraRedondeada = datard.GetOrdinal("MuestraRedondeada");
						int posFechaCalculoMuestra = datard.GetOrdinal("FechaCalculoMuestra");
						int posPromedio = datard.GetOrdinal("Promedio");
						int posMaximo = datard.GetOrdinal("Maximo");
						int posMinimo = datard.GetOrdinal("Minimo");
						int posModa = datard.GetOrdinal("Moda");
						int posMediana = datard.GetOrdinal("Mediana");
						int posFechaCalculoPrecio = datard.GetOrdinal("FechaCalculoPrecio");
						int posPrecioAplicado = datard.GetOrdinal("PrecioAplicado");
				lbeDeterminacionPrecios = new List<beDeterminacionPrecios>();
				beDeterminacionPrecios obeDeterminacionPrecios;
				while (datard.Read())
				{
					 obeDeterminacionPrecios = new beDeterminacionPrecios();
					obeDeterminacionPrecios.IdDeterminaPrecioBienServicio =  datard.GetInt32(posIdDeterminaPrecioBienServicio);
					obeDeterminacionPrecios.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obeDeterminacionPrecios.IdDatoEstudioMercado = datard[posIdDatoEstudioMercado] != DBNull.Value ? datard.GetInt32(posIdDatoEstudioMercado) : 0;
					obeDeterminacionPrecios.Poblacion =  datard.GetInt32(posPoblacion);
					obeDeterminacionPrecios.NivelConfianza =  datard.GetDecimal(posNivelConfianza);
					obeDeterminacionPrecios.ConstanteNivelConfianza =  datard.GetDecimal(posConstanteNivelConfianza);
					obeDeterminacionPrecios.Varianza =  datard.GetDecimal(posVarianza);
					obeDeterminacionPrecios.MargenError =  datard.GetDecimal(posMargenError);
					obeDeterminacionPrecios.Muestra =  datard.GetDecimal(posMuestra);
					obeDeterminacionPrecios.MuestraRedondeada =  datard.GetInt32(posMuestraRedondeada);
					obeDeterminacionPrecios.FechaCalculoMuestra =  datard.GetDateTime(posFechaCalculoMuestra);
					obeDeterminacionPrecios.Promedio =  datard.GetDecimal(posPromedio);
					obeDeterminacionPrecios.Maximo =  datard.GetDecimal(posMaximo);
					obeDeterminacionPrecios.Minimo =  datard.GetDecimal(posMinimo);
					obeDeterminacionPrecios.Moda =  datard.GetDecimal(posModa);
					obeDeterminacionPrecios.Mediana =  datard.GetDecimal(posMediana);
					obeDeterminacionPrecios.FechaCalculoPrecio =  datard.GetDateTime(posFechaCalculoPrecio);
					obeDeterminacionPrecios.PrecioAplicado =  datard.GetDecimal(posPrecioAplicado);
					lbeDeterminacionPrecios.Add(obeDeterminacionPrecios);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDeterminacionPrecios;
		}
	}
	public List< beDeterminacionPrecios> listar_DeterminacionPrecios_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_DeterminacionPrecios_TraerTodos_GetAll";
		List<beDeterminacionPrecios> lbeDeterminacionPrecios = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdDeterminaPrecioBienServicio = datard.GetOrdinal("IdDeterminaPrecioBienServicio");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
						int posPoblacion = datard.GetOrdinal("Poblacion");
						int posNivelConfianza = datard.GetOrdinal("NivelConfianza");
						int posConstanteNivelConfianza = datard.GetOrdinal("ConstanteNivelConfianza");
						int posVarianza = datard.GetOrdinal("Varianza");
						int posMargenError = datard.GetOrdinal("MargenError");
						int posMuestra = datard.GetOrdinal("Muestra");
						int posMuestraRedondeada = datard.GetOrdinal("MuestraRedondeada");
						int posFechaCalculoMuestra = datard.GetOrdinal("FechaCalculoMuestra");
						int posPromedio = datard.GetOrdinal("Promedio");
						int posMaximo = datard.GetOrdinal("Maximo");
						int posMinimo = datard.GetOrdinal("Minimo");
						int posModa = datard.GetOrdinal("Moda");
						int posMediana = datard.GetOrdinal("Mediana");
						int posFechaCalculoPrecio = datard.GetOrdinal("FechaCalculoPrecio");
						int posPrecioAplicado = datard.GetOrdinal("PrecioAplicado");
				lbeDeterminacionPrecios = new List<beDeterminacionPrecios>();
				beDeterminacionPrecios obeDeterminacionPrecios;
				while (datard.Read())
				{
					 obeDeterminacionPrecios = new beDeterminacionPrecios();
					obeDeterminacionPrecios.IdDeterminaPrecioBienServicio =  datard.GetInt32(posIdDeterminaPrecioBienServicio);
					obeDeterminacionPrecios.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obeDeterminacionPrecios.IdDatoEstudioMercado =  datard.GetInt32(posIdDatoEstudioMercado);
					obeDeterminacionPrecios.Poblacion =  datard.GetInt32(posPoblacion);
					obeDeterminacionPrecios.NivelConfianza =  datard.GetDecimal(posNivelConfianza);
					obeDeterminacionPrecios.ConstanteNivelConfianza =  datard.GetDecimal(posConstanteNivelConfianza);
					obeDeterminacionPrecios.Varianza =  datard.GetDecimal(posVarianza);
					obeDeterminacionPrecios.MargenError =  datard.GetDecimal(posMargenError);
					obeDeterminacionPrecios.Muestra =  datard.GetDecimal(posMuestra);
					obeDeterminacionPrecios.MuestraRedondeada =  datard.GetInt32(posMuestraRedondeada);
					obeDeterminacionPrecios.FechaCalculoMuestra =  datard.GetDateTime(posFechaCalculoMuestra);
					obeDeterminacionPrecios.Promedio =  datard.GetDecimal(posPromedio);
					obeDeterminacionPrecios.Maximo =  datard.GetDecimal(posMaximo);
					obeDeterminacionPrecios.Minimo =  datard.GetDecimal(posMinimo);
					obeDeterminacionPrecios.Moda =  datard.GetDecimal(posModa);
					obeDeterminacionPrecios.Mediana =  datard.GetDecimal(posMediana);
					obeDeterminacionPrecios.FechaCalculoPrecio =  datard.GetDateTime(posFechaCalculoPrecio);
					obeDeterminacionPrecios.PrecioAplicado =  datard.GetDecimal(posPrecioAplicado);
			// debe agregar campos de la Vista
					lbeDeterminacionPrecios.Add(obeDeterminacionPrecios);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDeterminacionPrecios;
		}
	}
}
}
