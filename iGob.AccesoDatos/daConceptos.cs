using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using igob.Entidades;

namespace igob.AccesoDatos
{
public class daConceptos
 {
	public int guardarConceptos(SqlConnection Conexion, beConceptos obeConceptos)
	{
		int Id=0;
		string sp = "Proc_ConceptosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConcepto", SqlDbType.Int).Value = obeConceptos.IdConcepto;
				cmd.Parameters.Add("@IdCapitulo", SqlDbType.Int).Value = obeConceptos.IdCapitulo;
				cmd.Parameters.Add("@ConceptoNumero", SqlDbType.VarChar).Value = obeConceptos.ConceptoNumero;
				cmd.Parameters.Add("@Concepto", SqlDbType.VarChar).Value = obeConceptos.Concepto;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeConceptos.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Int).Value = obeConceptos.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarConceptos(SqlConnection Conexion, beConceptos obeConceptos)
	{
		string sp = "Proc_ConceptosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConcepto", SqlDbType.Int).Value = obeConceptos.IdConcepto;
				cmd.Parameters.Add("@IdCapitulo", SqlDbType.Int).Value = obeConceptos.IdCapitulo;
				cmd.Parameters.Add("@ConceptoNumero", SqlDbType.VarChar).Value = obeConceptos.ConceptoNumero;
				cmd.Parameters.Add("@Concepto", SqlDbType.VarChar).Value = obeConceptos.Concepto;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeConceptos.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Int).Value = obeConceptos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarConceptos(SqlConnection Conexion,int pIdConcepto)
	{
		string sp = "Proc_ConceptosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConcepto", SqlDbType.Int).Value = pIdConcepto;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beConceptos traerConceptos_x_IdConcepto(SqlConnection Conexion,int IdConcepto)
	{
		string sp = "Proc_Conceptos_x_IdConcepto";
		List<beConceptos> lbeConceptos = null;
				beConceptos obeConceptos=new beConceptos();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdConcepto", SqlDbType.Int).Value = IdConcepto;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeConceptos = new List<beConceptos>();
				while (datard.Read())
					{
					 obeConceptos = new beConceptos();
						obeConceptos.IdConcepto =  datard.GetInt32(0);
						obeConceptos.IdCapitulo =  datard.GetInt32(1);
						obeConceptos.ConceptoNumero =  datard.GetString(2);
						obeConceptos.Concepto =  datard.GetString(3);
						obeConceptos.Descripcion =  datard.GetString(4);
						obeConceptos.Activo =  datard.GetInt32(5);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeConceptos;
			}
	}
	public List< beConceptos> listarTodos_Conceptos(SqlConnection Conexion)
	 {
		string sp = "Proc_Conceptos_Traer_Todos";
		List<beConceptos> lbeConceptos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeConceptos = new List<beConceptos>();
				beConceptos obeConceptos;
				while (datard.Read())
				{
					 obeConceptos = new beConceptos();
					obeConceptos.IdConcepto =  datard.GetInt32(0);
					obeConceptos.IdCapitulo =  datard.GetInt32(1);
					obeConceptos.ConceptoNumero =  datard.GetString(2);
					obeConceptos.Concepto =  datard.GetString(3);
					obeConceptos.Descripcion =  datard.GetString(4);
					obeConceptos.Activo =  datard.GetInt32(5);
					lbeConceptos.Add(obeConceptos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConceptos;
		}
	}
	public DataTable listarConceptos_x_(SqlConnection Conexion,int IdConcepto)
	 {
		string sp = "Proc_Conceptos_Traer_Todos";
		DataTable dtConceptos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdConcepto", SqlDbType.Int).Value = IdConcepto;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtConceptos = new DataTable();
				dtConceptos.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtConceptos;
		}
	}
}
}
