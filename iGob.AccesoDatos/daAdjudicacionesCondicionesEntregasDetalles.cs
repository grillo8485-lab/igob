using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesCondicionesEntregasDetalles
 {
	public int guardarAdjudicacionesCondicionesEntregasDetalles(SqlConnection Conexion, beAdjudicacionesCondicionesEntregasDetalles obeAdjudicacionesCondicionesEntregasDetalles)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesCondicionesEntregasDetallesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdCondicionEntregaDetalle", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregasDetalles.IdAdCondicionEntregaDetalle;
				cmd.Parameters.Add("@IdAdjudicacionCondicionEntrega", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionCondicionEntrega;
				cmd.Parameters.Add("@IdLugarEntrega", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregasDetalles.IdLugarEntrega;
				cmd.Parameters.Add("@NumeroEntrega", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregasDetalles.NumeroEntrega;
				cmd.Parameters.Add("@IdAdjudicacionLote", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionLote;
				cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesEntregasDetalles.Cantidad;
				cmd.Parameters.Add("@HorarioInicio", SqlDbType.Time).Value = obeAdjudicacionesCondicionesEntregasDetalles.HorarioInicio;
				cmd.Parameters.Add("@HorarioFinal", SqlDbType.Time).Value = obeAdjudicacionesCondicionesEntregasDetalles.HorarioFinal;
				cmd.Parameters.Add("@Lunes", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Lunes;
				cmd.Parameters.Add("@Martes", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Martes;
				cmd.Parameters.Add("@Miercoles", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Miercoles;
				cmd.Parameters.Add("@Jueves", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Jueves;
				cmd.Parameters.Add("@Viernes", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Viernes;
				cmd.Parameters.Add("@Sabado", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Sabado;
				cmd.Parameters.Add("@Domingo", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Domingo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesCondicionesEntregasDetalles(SqlConnection Conexion, beAdjudicacionesCondicionesEntregasDetalles obeAdjudicacionesCondicionesEntregasDetalles)
	{
		string sp = "Proc_AdjudicacionesCondicionesEntregasDetallesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdCondicionEntregaDetalle", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregasDetalles.IdAdCondicionEntregaDetalle;
				cmd.Parameters.Add("@IdAdjudicacionCondicionEntrega", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionCondicionEntrega;
				cmd.Parameters.Add("@IdLugarEntrega", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregasDetalles.IdLugarEntrega;
				cmd.Parameters.Add("@NumeroEntrega", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregasDetalles.NumeroEntrega;
				cmd.Parameters.Add("@IdAdjudicacionLote", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionLote;
				cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesEntregasDetalles.Cantidad;
				cmd.Parameters.Add("@HorarioInicio", SqlDbType.Time).Value = obeAdjudicacionesCondicionesEntregasDetalles.HorarioInicio;
				cmd.Parameters.Add("@HorarioFinal", SqlDbType.Time).Value = obeAdjudicacionesCondicionesEntregasDetalles.HorarioFinal;
				cmd.Parameters.Add("@Lunes", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Lunes;
				cmd.Parameters.Add("@Martes", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Martes;
				cmd.Parameters.Add("@Miercoles", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Miercoles;
				cmd.Parameters.Add("@Jueves", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Jueves;
				cmd.Parameters.Add("@Viernes", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Viernes;
				cmd.Parameters.Add("@Sabado", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Sabado;
				cmd.Parameters.Add("@Domingo", SqlDbType.TinyInt).Value = obeAdjudicacionesCondicionesEntregasDetalles.Domingo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesCondicionesEntregasDetalles(SqlConnection Conexion,int pIdAdCondicionEntregaDetalle)
	{
		string sp = "Proc_AdjudicacionesCondicionesEntregasDetallesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdCondicionEntregaDetalle", SqlDbType.Int).Value = pIdAdCondicionEntregaDetalle;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesCondicionesEntregasDetalles traerAdjudicacionesCondicionesEntregasDetalles_x_IdAdCondicionEntregaDetalle(SqlConnection Conexion,int IdAdCondicionEntregaDetalle)
	{
		string sp = "Proc_AdjudicacionesCondicionesEntregasDetalles_x_IdAdCondicionEntregaDetalle";
				beAdjudicacionesCondicionesEntregasDetalles obeAdjudicacionesCondicionesEntregasDetalles=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdCondicionEntregaDetalle", SqlDbType.Int).Value = IdAdCondicionEntregaDetalle;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdCondicionEntregaDetalle = datard.GetOrdinal("IdAdCondicionEntregaDetalle");
						int posIdAdjudicacionCondicionEntrega = datard.GetOrdinal("IdAdjudicacionCondicionEntrega");
						int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
						int posNumeroEntrega = datard.GetOrdinal("NumeroEntrega");
						int posIdAdjudicacionLote = datard.GetOrdinal("IdAdjudicacionLote");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posHorarioInicio = datard.GetOrdinal("HorarioInicio");
						int posHorarioFinal = datard.GetOrdinal("HorarioFinal");
						int posLunes = datard.GetOrdinal("Lunes");
						int posMartes = datard.GetOrdinal("Martes");
						int posMiercoles = datard.GetOrdinal("Miercoles");
						int posJueves = datard.GetOrdinal("Jueves");
						int posViernes = datard.GetOrdinal("Viernes");
						int posSabado = datard.GetOrdinal("Sabado");
						int posDomingo = datard.GetOrdinal("Domingo");
					 obeAdjudicacionesCondicionesEntregasDetalles = new beAdjudicacionesCondicionesEntregasDetalles();
				while (datard.Read())
					{
						obeAdjudicacionesCondicionesEntregasDetalles.IdAdCondicionEntregaDetalle =  datard.GetInt32(posIdAdCondicionEntregaDetalle);
						obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionCondicionEntrega =  datard.GetInt32(posIdAdjudicacionCondicionEntrega);
						obeAdjudicacionesCondicionesEntregasDetalles.IdLugarEntrega =  datard.GetInt32(posIdLugarEntrega);
						obeAdjudicacionesCondicionesEntregasDetalles.NumeroEntrega =  datard.GetInt32(posNumeroEntrega);
						obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionLote =  datard.GetInt32(posIdAdjudicacionLote);
						obeAdjudicacionesCondicionesEntregasDetalles.Cantidad =  datard.GetDecimal(posCantidad);
						obeAdjudicacionesCondicionesEntregasDetalles.HorarioInicio =  datard.GetTimeSpan(posHorarioInicio);
						obeAdjudicacionesCondicionesEntregasDetalles.HorarioFinal =  datard.GetTimeSpan(posHorarioFinal);
						obeAdjudicacionesCondicionesEntregasDetalles.Lunes =  datard.GetByte(posLunes);
						obeAdjudicacionesCondicionesEntregasDetalles.Martes =  datard.GetByte(posMartes);
						obeAdjudicacionesCondicionesEntregasDetalles.Miercoles =  datard.GetByte(posMiercoles);
						obeAdjudicacionesCondicionesEntregasDetalles.Jueves =  datard.GetByte(posJueves);
						obeAdjudicacionesCondicionesEntregasDetalles.Viernes =  datard.GetByte(posViernes);
						obeAdjudicacionesCondicionesEntregasDetalles.Sabado =  datard.GetByte(posSabado);
						obeAdjudicacionesCondicionesEntregasDetalles.Domingo =  datard.GetByte(posDomingo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesCondicionesEntregasDetalles;
			}
	}
	public List< beAdjudicacionesCondicionesEntregasDetalles> listarTodos_AdjudicacionesCondicionesEntregasDetalles(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesCondicionesEntregasDetalles_Traer_Todos";
		List<beAdjudicacionesCondicionesEntregasDetalles> lbeAdjudicacionesCondicionesEntregasDetalles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdCondicionEntregaDetalle = datard.GetOrdinal("IdAdCondicionEntregaDetalle");
						int posIdAdjudicacionCondicionEntrega = datard.GetOrdinal("IdAdjudicacionCondicionEntrega");
						int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
						int posNumeroEntrega = datard.GetOrdinal("NumeroEntrega");
						int posIdAdjudicacionLote = datard.GetOrdinal("IdAdjudicacionLote");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posHorarioInicio = datard.GetOrdinal("HorarioInicio");
						int posHorarioFinal = datard.GetOrdinal("HorarioFinal");
						int posLunes = datard.GetOrdinal("Lunes");
						int posMartes = datard.GetOrdinal("Martes");
						int posMiercoles = datard.GetOrdinal("Miercoles");
						int posJueves = datard.GetOrdinal("Jueves");
						int posViernes = datard.GetOrdinal("Viernes");
						int posSabado = datard.GetOrdinal("Sabado");
						int posDomingo = datard.GetOrdinal("Domingo");
				lbeAdjudicacionesCondicionesEntregasDetalles = new List<beAdjudicacionesCondicionesEntregasDetalles>();
				beAdjudicacionesCondicionesEntregasDetalles obeAdjudicacionesCondicionesEntregasDetalles;
				while (datard.Read())
				{
					 obeAdjudicacionesCondicionesEntregasDetalles = new beAdjudicacionesCondicionesEntregasDetalles();
					obeAdjudicacionesCondicionesEntregasDetalles.IdAdCondicionEntregaDetalle =  datard.GetInt32(posIdAdCondicionEntregaDetalle);
					obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionCondicionEntrega =  datard.GetInt32(posIdAdjudicacionCondicionEntrega);
					obeAdjudicacionesCondicionesEntregasDetalles.IdLugarEntrega =  datard.GetInt32(posIdLugarEntrega);
					obeAdjudicacionesCondicionesEntregasDetalles.NumeroEntrega =  datard.GetInt32(posNumeroEntrega);
					obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionLote =  datard.GetInt32(posIdAdjudicacionLote);
					obeAdjudicacionesCondicionesEntregasDetalles.Cantidad =  datard.GetDecimal(posCantidad);
					obeAdjudicacionesCondicionesEntregasDetalles.HorarioInicio =  datard.GetTimeSpan(posHorarioInicio);
					obeAdjudicacionesCondicionesEntregasDetalles.HorarioFinal =  datard.GetTimeSpan(posHorarioFinal);
					obeAdjudicacionesCondicionesEntregasDetalles.Lunes =  datard.GetByte(posLunes);
					obeAdjudicacionesCondicionesEntregasDetalles.Martes =  datard.GetByte(posMartes);
					obeAdjudicacionesCondicionesEntregasDetalles.Miercoles =  datard.GetByte(posMiercoles);
					obeAdjudicacionesCondicionesEntregasDetalles.Jueves =  datard.GetByte(posJueves);
					obeAdjudicacionesCondicionesEntregasDetalles.Viernes =  datard.GetByte(posViernes);
					obeAdjudicacionesCondicionesEntregasDetalles.Sabado =  datard.GetByte(posSabado);
					obeAdjudicacionesCondicionesEntregasDetalles.Domingo =  datard.GetByte(posDomingo);
					lbeAdjudicacionesCondicionesEntregasDetalles.Add(obeAdjudicacionesCondicionesEntregasDetalles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesEntregasDetalles;
		}
	}
	public List< beAdjudicacionesCondicionesEntregasDetalles> listar_AdjudicacionesCondicionesEntregasDetalles_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesCondicionesEntregasDetalles_TraerTodos_GetAll";
		List<beAdjudicacionesCondicionesEntregasDetalles> lbeAdjudicacionesCondicionesEntregasDetalles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdCondicionEntregaDetalle = datard.GetOrdinal("IdAdCondicionEntregaDetalle");
						int posIdAdjudicacionCondicionEntrega = datard.GetOrdinal("IdAdjudicacionCondicionEntrega");
						int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
						int posNumeroEntrega = datard.GetOrdinal("NumeroEntrega");
						int posIdAdjudicacionLote = datard.GetOrdinal("IdAdjudicacionLote");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posHorarioInicio = datard.GetOrdinal("HorarioInicio");
						int posHorarioFinal = datard.GetOrdinal("HorarioFinal");
						int posLunes = datard.GetOrdinal("Lunes");
						int posMartes = datard.GetOrdinal("Martes");
						int posMiercoles = datard.GetOrdinal("Miercoles");
						int posJueves = datard.GetOrdinal("Jueves");
						int posViernes = datard.GetOrdinal("Viernes");
						int posSabado = datard.GetOrdinal("Sabado");
						int posDomingo = datard.GetOrdinal("Domingo");
				lbeAdjudicacionesCondicionesEntregasDetalles = new List<beAdjudicacionesCondicionesEntregasDetalles>();
				beAdjudicacionesCondicionesEntregasDetalles obeAdjudicacionesCondicionesEntregasDetalles;
				while (datard.Read())
				{
					 obeAdjudicacionesCondicionesEntregasDetalles = new beAdjudicacionesCondicionesEntregasDetalles();
					obeAdjudicacionesCondicionesEntregasDetalles.IdAdCondicionEntregaDetalle =  datard.GetInt32(posIdAdCondicionEntregaDetalle);
					obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionCondicionEntrega =  datard.GetInt32(posIdAdjudicacionCondicionEntrega);
					obeAdjudicacionesCondicionesEntregasDetalles.IdLugarEntrega =  datard.GetInt32(posIdLugarEntrega);
					obeAdjudicacionesCondicionesEntregasDetalles.NumeroEntrega =  datard.GetInt32(posNumeroEntrega);
					obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionLote =  datard.GetInt32(posIdAdjudicacionLote);
					obeAdjudicacionesCondicionesEntregasDetalles.Cantidad =  datard.GetDecimal(posCantidad);
					obeAdjudicacionesCondicionesEntregasDetalles.HorarioInicio =  datard.GetTimeSpan(posHorarioInicio);
					obeAdjudicacionesCondicionesEntregasDetalles.HorarioFinal =  datard.GetTimeSpan(posHorarioFinal);
					obeAdjudicacionesCondicionesEntregasDetalles.Lunes =  datard.GetByte(posLunes);
					obeAdjudicacionesCondicionesEntregasDetalles.Martes =  datard.GetByte(posMartes);
					obeAdjudicacionesCondicionesEntregasDetalles.Miercoles =  datard.GetByte(posMiercoles);
					obeAdjudicacionesCondicionesEntregasDetalles.Jueves =  datard.GetByte(posJueves);
					obeAdjudicacionesCondicionesEntregasDetalles.Viernes =  datard.GetByte(posViernes);
					obeAdjudicacionesCondicionesEntregasDetalles.Sabado =  datard.GetByte(posSabado);
					obeAdjudicacionesCondicionesEntregasDetalles.Domingo =  datard.GetByte(posDomingo);
			// debe agregar campos de la Vista
					lbeAdjudicacionesCondicionesEntregasDetalles.Add(obeAdjudicacionesCondicionesEntregasDetalles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesEntregasDetalles;
		}
	}

        public List<beAdjudicacionesCondicionesDetallesIdAdjudicacion> listar_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_AdjudicacionesCondicionesEntregaDetalles_traer_IdAdjudicacion";
            List<beAdjudicacionesCondicionesDetallesIdAdjudicacion> lbeAdjudicacionesCondicionesEntregasDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int pIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int pNoLote = datard.GetOrdinal("NoLote");
                        int pCantidad = datard.GetOrdinal("Cantidad");
                        int pBienServicio = datard.GetOrdinal("BienServicio");
                        int pIdLote = datard.GetOrdinal("IdLote");
                        int pCantidadLotesxAsignar = datard.GetOrdinal("CantidadLotesxAsignar");
                        int pCantidadLoteAsignado = datard.GetOrdinal("CantidadLoteAsignado");
                        int pCantidadxAsignar = datard.GetOrdinal("CantidadxAsignar");

                        lbeAdjudicacionesCondicionesEntregasDetalles = new List<beAdjudicacionesCondicionesDetallesIdAdjudicacion>();
                        beAdjudicacionesCondicionesDetallesIdAdjudicacion obeAdjudicacionesCondicionesEntregasDetalles;
                        while (datard.Read())
                        {
                            obeAdjudicacionesCondicionesEntregasDetalles = new beAdjudicacionesCondicionesDetallesIdAdjudicacion();
                            obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacion = datard.GetInt32(pIdAdjudicacion);
                            obeAdjudicacionesCondicionesEntregasDetalles.NoLote = datard.GetInt32(pNoLote);
                            obeAdjudicacionesCondicionesEntregasDetalles.Cantidad = datard.GetDecimal(pCantidad);
                            obeAdjudicacionesCondicionesEntregasDetalles.BienServicio = datard.GetString(pBienServicio);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdLote = datard.GetInt32(pIdLote);
                            obeAdjudicacionesCondicionesEntregasDetalles.CantidadLotesxAsignar = datard.GetString(pCantidadLotesxAsignar);
                            obeAdjudicacionesCondicionesEntregasDetalles.CantidadLoteAsignado = datard.GetDecimal(pCantidadLoteAsignado);
                            obeAdjudicacionesCondicionesEntregasDetalles.CantidadxAsignar = datard.GetDecimal(pCantidadxAsignar);
                            // debe agregar campos de la Vista
                            lbeAdjudicacionesCondicionesEntregasDetalles.Add(obeAdjudicacionesCondicionesEntregasDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesCondicionesEntregasDetalles;
            }
        }

        public List<beAdjudicacionesCondicionesEntregasDetalles> listar_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacionCondicionEntrega(SqlConnection Conexion, int IdAdjudicacionCondicionEntrega)
        {
            string sp = "Proc_AdjudicacionesCondicionesEntregasDetalles_x_IdCondicionEntrega";
            List<beAdjudicacionesCondicionesEntregasDetalles> lbeAdjudicacionesCondicionesEntregasDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCondicionEntrega", SqlDbType.Int).Value = IdAdjudicacionCondicionEntrega;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int pIdAdjudicacionCondicionEntrega = datard.GetOrdinal("IdAdjudicacionCondicionEntrega");
                        int pIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int pIdTipoDia = datard.GetOrdinal("IdTipoDia");
                        int pIdPlazoEntegra = datard.GetOrdinal("IdPlazoEntegra");
                        int pIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
                        int pPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
                        int pFechaLimite = datard.GetOrdinal("FechaLimite");
                        int pIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
                        int pObservaciones = datard.GetOrdinal("Observaciones");
                        int pNotaEspecial = datard.GetOrdinal("NotaEspecial");
                        int pIdEstatus = datard.GetOrdinal("IdEstatus");
                        int pIdAdCondicionEntregaDetalle = datard.GetOrdinal("IdAdCondicionEntregaDetalle");
                        int pIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int pNumeroEntrega = datard.GetOrdinal("NumeroEntrega");
                        int pIdAdjudicacionLote = datard.GetOrdinal("IdAdjudicacionLote");
                        int pCantidad = datard.GetOrdinal("Cantidad");
                        int pHorarioInicio = datard.GetOrdinal("HorarioInicio");
                        int pHorarioFinal = datard.GetOrdinal("HorarioFinal");
                        int pLunes = datard.GetOrdinal("Lunes");
                        int pMartes = datard.GetOrdinal("Martes");
                        int pMiercoles = datard.GetOrdinal("Miercoles");
                        int pJueves = datard.GetOrdinal("Jueves");
                        int pViernes = datard.GetOrdinal("Viernes");
                        int pSabado = datard.GetOrdinal("Sabado");
                        int pDomingo = datard.GetOrdinal("Domingo");

                        int pLugar = datard.GetOrdinal("Lugar");
                        int pDireccion = datard.GetOrdinal("Direccion");
                        int pColonia = datard.GetOrdinal("Colonia");
                        int pCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int pLocalizacionGoogle = datard.GetOrdinal("LocalizacionGoogle");
                        int pIdMunicipio = datard.GetOrdinal("IdMunicipio");
                        int pMunicipio = datard.GetOrdinal("Municipio");
                        int pEstado = datard.GetOrdinal("Estado");
                        int pNoLote = datard.GetOrdinal("NoLote");

                        lbeAdjudicacionesCondicionesEntregasDetalles = new List<beAdjudicacionesCondicionesEntregasDetalles >();
                        beAdjudicacionesCondicionesEntregasDetalles obeAdjudicacionesCondicionesEntregasDetalles;
                        while (datard.Read())
                        {

                            obeAdjudicacionesCondicionesEntregasDetalles = new beAdjudicacionesCondicionesEntregasDetalles();
                            obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionCondicionEntrega = datard.GetInt32(pIdAdjudicacionCondicionEntrega);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacion = datard.GetInt32(pIdAdjudicacion);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdTipoDia = datard.GetInt32(pIdTipoDia);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdPlazoEntegra = datard.GetInt32(pIdPlazoEntegra);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdPlazoTiempo = datard.GetInt32(pIdPlazoTiempo);
                            obeAdjudicacionesCondicionesEntregasDetalles.PlazoEntregaCantidad = datard.GetInt32(pPlazoEntregaCantidad);
                            obeAdjudicacionesCondicionesEntregasDetalles.FechaLimite = datard.GetDateTime(pFechaLimite);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdTipoEntrega = datard.GetInt32(pIdTipoEntrega);

                            obeAdjudicacionesCondicionesEntregasDetalles.Observaciones = datard.GetString(pObservaciones);
                            obeAdjudicacionesCondicionesEntregasDetalles.NotaEspecial = datard.GetString(pNotaEspecial);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdEstatus = datard.GetInt32(pIdEstatus);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdAdCondicionEntregaDetalle = datard.GetInt32(pIdAdCondicionEntregaDetalle);

                            obeAdjudicacionesCondicionesEntregasDetalles.IdLugarEntrega = datard.GetInt32(pIdLugarEntrega);
                            obeAdjudicacionesCondicionesEntregasDetalles.NumeroEntrega = datard.GetInt32(pNumeroEntrega);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdAdjucacionLote = datard.GetInt32(pIdAdjudicacionLote);
                            obeAdjudicacionesCondicionesEntregasDetalles.Cantidad = datard.GetDecimal(pCantidad);
                            
                            obeAdjudicacionesCondicionesEntregasDetalles.HorarioInicio = datard.GetTimeSpan(pHorarioInicio);
                            obeAdjudicacionesCondicionesEntregasDetalles.HorarioFinal = datard.GetTimeSpan(pHorarioFinal);
                            obeAdjudicacionesCondicionesEntregasDetalles.Lunes = datard.GetByte(pLunes);
                            obeAdjudicacionesCondicionesEntregasDetalles.Martes = datard.GetByte(pMartes);
                            obeAdjudicacionesCondicionesEntregasDetalles.Miercoles = datard.GetByte(pMiercoles);
                            obeAdjudicacionesCondicionesEntregasDetalles.Jueves = datard.GetByte(pJueves);
                            obeAdjudicacionesCondicionesEntregasDetalles.Viernes = datard.GetByte(pViernes);
                            obeAdjudicacionesCondicionesEntregasDetalles.Sabado = datard.GetByte(pSabado);
                            obeAdjudicacionesCondicionesEntregasDetalles.Domingo = datard.GetByte(pDomingo);

                            obeAdjudicacionesCondicionesEntregasDetalles.Lugar = datard.GetString(pLugar);
                            obeAdjudicacionesCondicionesEntregasDetalles.Direccion = datard.GetString(pDireccion);
                            obeAdjudicacionesCondicionesEntregasDetalles.Colonia = datard.GetString(pColonia);
                            obeAdjudicacionesCondicionesEntregasDetalles.CodigoPostal = datard.GetString(pCodigoPostal);
                            obeAdjudicacionesCondicionesEntregasDetalles.LocalizacionGoogle = datard.GetString(pLocalizacionGoogle);
                            obeAdjudicacionesCondicionesEntregasDetalles.IdMunicipio = datard.GetString(pIdMunicipio);
                            obeAdjudicacionesCondicionesEntregasDetalles.Municipio = datard.GetString(pMunicipio);
                            obeAdjudicacionesCondicionesEntregasDetalles.Estado = datard.GetString(pEstado);
                            obeAdjudicacionesCondicionesEntregasDetalles.NoLote = datard.GetInt32(pNoLote);

                            // debe agregar campos de la Vista
                            lbeAdjudicacionesCondicionesEntregasDetalles.Add(obeAdjudicacionesCondicionesEntregasDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesCondicionesEntregasDetalles;
            }
        }
    }
}
