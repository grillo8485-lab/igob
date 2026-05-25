using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daBienesServicios
 {
	public int guardarBienesServicios(SqlConnection Conexion, beBienesServicios obeBienesServicios)
	{
		int Id=0;
		string sp = "Proc_BienesServiciosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeBienesServicios.IdBienServicio;
				cmd.Parameters.Add("@Codigo", SqlDbType.Char).Value = obeBienesServicios.Codigo;
				cmd.Parameters.Add("@ClaveCubs", SqlDbType.NChar).Value = obeBienesServicios.ClaveCubs;
				cmd.Parameters.Add("@BienServicio", SqlDbType.VarChar).Value = obeBienesServicios.BienServicio;
				cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = obeBienesServicios.Descripcion;
				cmd.Parameters.Add("@IdModificador", SqlDbType.Int).Value = obeBienesServicios.IdModificador;
				cmd.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = obeBienesServicios.IdTipoProducto;
				cmd.Parameters.Add("@IdMarca", SqlDbType.Int).Value = obeBienesServicios.IdMarca;
				cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = obeBienesServicios.IdFamilia;
				cmd.Parameters.Add("@IdUnidadMedida", SqlDbType.Int).Value = obeBienesServicios.IdUnidadMedida;
				cmd.Parameters.Add("@IdImpuesto", SqlDbType.Int).Value = obeBienesServicios.IdImpuesto;
				cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obeBienesServicios.PrecioUnitario;
				cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obeBienesServicios.IdPartida;
				cmd.Parameters.Add("@PrecioUnitarioMejorLicitado", SqlDbType.Decimal).Value = obeBienesServicios.PrecioUnitarioMejorLicitado;
				cmd.Parameters.Add("@IdCertificacion", SqlDbType.Int).Value = obeBienesServicios.IdCertificacion;
				cmd.Parameters.Add("@IdTipoMoneda", SqlDbType.Int).Value = obeBienesServicios.IdTipoMoneda;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeBienesServicios.Activo;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeBienesServicios.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeBienesServicios.FechaRegistro;
                cmd.Parameters.Add("@FechaActualizacionPrecio", SqlDbType.DateTime).Value = obeBienesServicios.FechaActualizacionPrecio!=null ? obeBienesServicios.FechaActualizacionPrecio : DateTime.Now;
                cmd.Parameters.Add("@CodigoScian", SqlDbType.Int).Value = obeBienesServicios.CodigoScian!=0 ? obeBienesServicios.CodigoScian : 1;

                Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarBienesServicios(SqlConnection Conexion, beBienesServicios obeBienesServicios)
	{
		string sp = "Proc_BienesServiciosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeBienesServicios.IdBienServicio;
				cmd.Parameters.Add("@Codigo", SqlDbType.Char).Value = obeBienesServicios.Codigo;
				cmd.Parameters.Add("@ClaveCubs", SqlDbType.NChar).Value = obeBienesServicios.ClaveCubs;
				cmd.Parameters.Add("@BienServicio", SqlDbType.VarChar).Value = obeBienesServicios.BienServicio;
				cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = obeBienesServicios.Descripcion;
				cmd.Parameters.Add("@IdModificador", SqlDbType.Int).Value = obeBienesServicios.IdModificador;
				cmd.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = obeBienesServicios.IdTipoProducto;
				cmd.Parameters.Add("@IdMarca", SqlDbType.Int).Value = obeBienesServicios.IdMarca;
				cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = obeBienesServicios.IdFamilia;
				cmd.Parameters.Add("@IdUnidadMedida", SqlDbType.Int).Value = obeBienesServicios.IdUnidadMedida;
				cmd.Parameters.Add("@IdImpuesto", SqlDbType.Int).Value = obeBienesServicios.IdImpuesto;
				cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obeBienesServicios.PrecioUnitario;
				cmd.Parameters.Add("@IdPartida", SqlDbType.Int).Value = obeBienesServicios.IdPartida;
				cmd.Parameters.Add("@PrecioUnitarioMejorLicitado", SqlDbType.Decimal).Value = obeBienesServicios.PrecioUnitarioMejorLicitado;
				cmd.Parameters.Add("@IdCertificacion", SqlDbType.Int).Value = obeBienesServicios.IdCertificacion;
				cmd.Parameters.Add("@IdTipoMoneda", SqlDbType.Int).Value = obeBienesServicios.IdTipoMoneda;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeBienesServicios.Activo;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeBienesServicios.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeBienesServicios.FechaRegistro;
                cmd.Parameters.Add("@FechaActualizacionPrecio", SqlDbType.DateTime).Value = obeBienesServicios.FechaActualizacionPrecio!=null ? obeBienesServicios.FechaActualizacionPrecio : DateTime.Now;
                cmd.Parameters.Add("@CodigoScian", SqlDbType.Int).Value = obeBienesServicios.CodigoScian!=0 ? obeBienesServicios.CodigoScian : 1;

                cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarBienesServicios(SqlConnection Conexion,int pIdBienServicio)
	{
		string sp = "Proc_BienesServiciosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = pIdBienServicio;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beBienesServicios traerBienesServicios_x_IdBienServicio(SqlConnection Conexion,int IdBienServicio)
	{
            string sp = "Proc_BienesServicios_x_IdBienServicio";
            beBienesServicios obeBienesServicios = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = IdBienServicio;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posCodigo = datard.GetOrdinal("Codigo");
                        int posClaveCubs = datard.GetOrdinal("ClaveCubs");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIdModificador = datard.GetOrdinal("IdModificador");
                        int posIdTipoProducto = datard.GetOrdinal("IdTipoProducto");
                        int posIdMarca = datard.GetOrdinal("IdMarca");
                        int posIdFamilia = datard.GetOrdinal("IdFamilia");
                        int posIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int posIdImpuesto = datard.GetOrdinal("IdImpuesto");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posPrecioUnitarioMejorLicitado = datard.GetOrdinal("PrecioUnitarioMejorLicitado");
                        int posIdCertificacion = datard.GetOrdinal("IdCertificacion");
                        int posIdTipoMoneda = datard.GetOrdinal("IdTipoMoneda");
                        int posActivo = datard.GetOrdinal("Activo");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posFechaActualizacionPrecio = datard.GetOrdinal("FechaActualizacionPrecio");
                        int posCodigoScian = datard.GetOrdinal("CodigoScian");
                        obeBienesServicios = new beBienesServicios();
                        while (datard.Read())
                        {
                            obeBienesServicios.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeBienesServicios.Codigo = datard.GetString(posCodigo);
                            obeBienesServicios.ClaveCubs = datard.GetString(posClaveCubs);
                            obeBienesServicios.BienServicio = datard.GetString(posBienServicio);
                            obeBienesServicios.Descripcion = datard.GetString(posDescripcion);
                            obeBienesServicios.IdModificador = datard.GetInt32(posIdModificador);
                            obeBienesServicios.IdTipoProducto = datard.GetInt32(posIdTipoProducto);
                            obeBienesServicios.IdMarca = datard.GetInt32(posIdMarca);
                            obeBienesServicios.IdFamilia = datard.GetInt32(posIdFamilia);
                            obeBienesServicios.IdUnidadMedida = datard.GetInt32(posIdUnidadMedida);
                            obeBienesServicios.IdImpuesto = datard.GetInt32(posIdImpuesto);
                            obeBienesServicios.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeBienesServicios.IdPartida = datard.GetInt32(posIdPartida);
                            obeBienesServicios.PrecioUnitarioMejorLicitado = datard.GetDecimal(posPrecioUnitarioMejorLicitado);
                            obeBienesServicios.IdCertificacion = datard.GetInt32(posIdCertificacion);
                            obeBienesServicios.IdTipoMoneda = datard.GetInt32(posIdTipoMoneda);
                            obeBienesServicios.Activo = datard.GetBoolean(posActivo);
                            obeBienesServicios.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeBienesServicios.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeBienesServicios.FechaActualizacionPrecio = datard[posFechaActualizacionPrecio] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaActualizacionPrecio);// datard.GetDateTime(posFechaActualizacionPrecio);
                            obeBienesServicios.CodigoScian = datard[posCodigoScian] == DBNull.Value ? 0 : datard.GetInt32(posCodigoScian);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeBienesServicios;
            }
        }
	public List< beBienesServicios> listarTodos_BienesServicios(SqlConnection Conexion)
	{
            string sp = "Proc_BienesServicios_Traer_Todos";
            List<beBienesServicios> lbeBienesServicios = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posCodigo = datard.GetOrdinal("Codigo");
                        int posClaveCubs = datard.GetOrdinal("ClaveCubs");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIdModificador = datard.GetOrdinal("IdModificador");
                        int posIdTipoProducto = datard.GetOrdinal("IdTipoProducto");
                        int posIdMarca = datard.GetOrdinal("IdMarca");
                        int posIdFamilia = datard.GetOrdinal("IdFamilia");
                        int posIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int posIdImpuesto = datard.GetOrdinal("IdImpuesto");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posPrecioUnitarioMejorLicitado = datard.GetOrdinal("PrecioUnitarioMejorLicitado");
                        int posIdCertificacion = datard.GetOrdinal("IdCertificacion");
                        int posIdTipoMoneda = datard.GetOrdinal("IdTipoMoneda");
                        int posActivo = datard.GetOrdinal("Activo");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posFechaActualizacionPrecio = datard.GetOrdinal("FechaActualizacionPrecio");
                        int posCodigoScian = datard.GetOrdinal("CodigoScian");
                        lbeBienesServicios = new List<beBienesServicios>();
                        beBienesServicios obeBienesServicios;
                        while (datard.Read())
                        {
                            obeBienesServicios = new beBienesServicios();
                            obeBienesServicios.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeBienesServicios.Codigo = datard.GetString(posCodigo);
                            obeBienesServicios.ClaveCubs = datard.GetString(posClaveCubs);
                            obeBienesServicios.BienServicio = datard.GetString(posBienServicio);
                            obeBienesServicios.Descripcion = datard.GetString(posDescripcion);
                            obeBienesServicios.IdModificador = datard.GetInt32(posIdModificador);
                            obeBienesServicios.IdTipoProducto = datard.GetInt32(posIdTipoProducto);
                            obeBienesServicios.IdMarca = datard.GetInt32(posIdMarca);
                            obeBienesServicios.IdFamilia = datard.GetInt32(posIdFamilia);
                            obeBienesServicios.IdUnidadMedida = datard.GetInt32(posIdUnidadMedida);
                            obeBienesServicios.IdImpuesto = datard.GetInt32(posIdImpuesto);
                            obeBienesServicios.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeBienesServicios.IdPartida = datard.GetInt32(posIdPartida);
                            obeBienesServicios.PrecioUnitarioMejorLicitado = datard.GetDecimal(posPrecioUnitarioMejorLicitado);
                            obeBienesServicios.IdCertificacion = datard.GetInt32(posIdCertificacion);
                            obeBienesServicios.IdTipoMoneda = datard.GetInt32(posIdTipoMoneda);
                            obeBienesServicios.Activo = datard.GetBoolean(posActivo);
                            obeBienesServicios.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeBienesServicios.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeBienesServicios.FechaActualizacionPrecio = datard[posFechaActualizacionPrecio] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaActualizacionPrecio); //datard.GetDateTime(posFechaActualizacionPrecio);
                            obeBienesServicios.CodigoScian = datard[posCodigoScian] == DBNull.Value ? 0 : datard.GetInt32(posCodigoScian); //datard.GetInt32(posCodigoScian);
                            lbeBienesServicios.Add(obeBienesServicios);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeBienesServicios;
            }
        }
	public DataTable listarBienesServicios_x_(SqlConnection Conexion,int IdBienServicio)
	 {
		string sp = "Proc_BienesServicios_Traer_Todos";
		DataTable dtBienesServicios = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = IdBienServicio;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtBienesServicios = new DataTable();
				dtBienesServicios.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtBienesServicios;
		}
	}

        public List<beBienesServicios> listarBienesServicios_x_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_BienesServicios_TraerTodos_GetAll";
            List<beBienesServicios> lbeBienesServicios = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
                        int posCodigo = datard.GetOrdinal("Codigo");
                        int posClaveCubs = datard.GetOrdinal("ClaveCubs");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIdModificador = datard.GetOrdinal("IdModificador");
                        int posIdTipoProducto = datard.GetOrdinal("IdTipoProducto");
                        int posIdMarca = datard.GetOrdinal("IdMarca");
                        int posIdFamilia = datard.GetOrdinal("IdFamilia");
                        int posIdUnidadMedida = datard.GetOrdinal("IdUnidadMedida");
                        int posIdImpuesto = datard.GetOrdinal("IdImpuesto");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posIdPartida = datard.GetOrdinal("IdPartida");
                        int posPrecioUnitarioMejorLicitado = datard.GetOrdinal("PrecioUnitarioMejorLicitado");
                        int posIdCertificacion = datard.GetOrdinal("IdCertificacion");
                        int posIdTipoMoneda = datard.GetOrdinal("IdTipoMoneda");
                        int posActivo = datard.GetOrdinal("Activo");
                        //int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        //int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posFechaActualizacionPrecio = datard.GetOrdinal("FechaActualizacionPrecio");
                        int posCodigoScian = datard.GetOrdinal("CodigoScian");
                        lbeBienesServicios = new List<beBienesServicios>();
                        beBienesServicios obeBienesServicios;
                        while (datard.Read())
                        {
                            obeBienesServicios = new beBienesServicios();
                            obeBienesServicios.IdBienServicio = datard.GetInt32(posIdBienServicio);
                            obeBienesServicios.Codigo = datard.GetString(posCodigo);
                            obeBienesServicios.ClaveCubs = datard.GetString(posClaveCubs);
                            obeBienesServicios.BienServicio = datard.GetString(posBienServicio);
                            obeBienesServicios.Descripcion = datard.GetString(posDescripcion);
                            obeBienesServicios.IdModificador = datard.GetInt32(posIdModificador);
                            obeBienesServicios.IdTipoProducto = datard.GetInt32(posIdTipoProducto);
                            obeBienesServicios.IdMarca = datard.GetInt32(posIdMarca);
                            obeBienesServicios.IdFamilia = datard.GetInt32(posIdFamilia);
                            obeBienesServicios.IdUnidadMedida = datard.GetInt32(posIdUnidadMedida);
                            obeBienesServicios.IdImpuesto = datard.GetInt32(posIdImpuesto);
                            obeBienesServicios.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeBienesServicios.IdPartida = datard.GetInt32(posIdPartida);
                            obeBienesServicios.PrecioUnitarioMejorLicitado = datard.GetDecimal(posPrecioUnitarioMejorLicitado);
                            obeBienesServicios.IdCertificacion = datard.GetInt32(posIdCertificacion);
                            obeBienesServicios.IdTipoMoneda = datard.GetInt32(posIdTipoMoneda);
                            obeBienesServicios.Activo = datard.GetBoolean(posActivo);
                            //obeBienesServicios.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            //obeBienesServicios.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeBienesServicios.FechaActualizacionPrecio = datard[posFechaActualizacionPrecio] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaActualizacionPrecio);
                            obeBienesServicios.CodigoScian = datard[posCodigoScian] == DBNull.Value ? 0 : datard.GetInt32(posCodigoScian);
                            // debe agregar campos de la Vista
                            lbeBienesServicios.Add(obeBienesServicios);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeBienesServicios;
            }
        }
        public List<beBienesServicios> listarTodos_GetAllBienesServicios_x_IdCapitulo(SqlConnection Conexion,int pIdCapitulo/*,string cadena*/)
        {
            string sp = "Proc_BienesServicios_TraerTodos_x_IdCapitulo";
            List<beBienesServicios> lbeBienesServicios = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCapitulo", SqlDbType.Int).Value = pIdCapitulo;
            //cmd.Parameters.Add("@texto", SqlDbType.VarChar).Value = cadena;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeBienesServicios = new List<beBienesServicios>();

                        beBienesServicios obeBienesServicios;
                        while (datard.Read())
                        {
                            obeBienesServicios = new beBienesServicios();
                            obeBienesServicios.IdBienServicio = datard.GetInt32(0);
                            obeBienesServicios.Codigo = datard.GetString(1);
                            obeBienesServicios.ClaveCubs = datard.GetString(2);
                            obeBienesServicios.BienServicio = datard.GetString(3);
                            obeBienesServicios.Descripcion = datard.GetString(4);
                            obeBienesServicios.IdModificador = datard.GetInt32(5);
                            obeBienesServicios.IdTipoProducto = datard.GetInt32(6);
                            obeBienesServicios.IdMarca = datard.GetInt32(7);
                            obeBienesServicios.IdFamilia = datard.GetInt32(8);
                            obeBienesServicios.IdUnidadMedida = datard.GetInt32(9);
                            obeBienesServicios.IdImpuesto = datard.GetInt32(10);
                            obeBienesServicios.PrecioUnitario = datard.GetDecimal(11);
                            obeBienesServicios.IdPartida = datard.GetInt32(12);
                            obeBienesServicios.PrecioUnitarioMejorLicitado = datard.GetDecimal(13);
                            obeBienesServicios.IdCertificacion = datard.GetInt32(14);
                            obeBienesServicios.IdTipoMoneda = datard.GetInt32(15);
                            obeBienesServicios.Activo = datard.GetBoolean(16);
                            //obeBienesServicios.IdUsuarioRegistro = datard.GetInt32(17);
                            //obeBienesServicios.FechaRegistro = datard.GetDateTime(17);
                            obeBienesServicios.TipoProducto = datard.GetString(17);
                            obeBienesServicios.Marca = datard.GetString(18);
                            obeBienesServicios.UnidadMedida = datard.GetString(19);
                            obeBienesServicios.Familia = datard.GetString(20);
                            obeBienesServicios.Impuesto = datard.GetString(21);
                            obeBienesServicios.Certificacion = datard.GetString(22);
                            obeBienesServicios.Partida = datard.GetString(23);
                            obeBienesServicios.IdCapitulo = datard.GetInt32(24);
                            obeBienesServicios.Capitulo = datard.GetString(25);
                            obeBienesServicios.Modificador = datard.GetString(26);

                            obeBienesServicios.CodigoScian = datard.GetInt32(28);
                            lbeBienesServicios.Add(obeBienesServicios);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeBienesServicios;
            }
        }
    }
}
