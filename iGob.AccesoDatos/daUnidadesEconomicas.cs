using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daUnidadesEconomicas
 {
	public int guardarUnidadesEconomicas(SqlConnection Conexion, beUnidadesEconomicas obeUnidadesEconomicas)
	{
		int Id=0;
		string sp = "Proc_UnidadesEconomicasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@id", SqlDbType.Int).Value = obeUnidadesEconomicas.Id;
				cmd.Parameters.Add("@nom_estab", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_estab;
				cmd.Parameters.Add("@raz_social", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Raz_social;
				cmd.Parameters.Add("@codigo_act", SqlDbType.Int).Value = obeUnidadesEconomicas.Codigo_act;
				cmd.Parameters.Add("@nombre_act", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nombre_act;
				cmd.Parameters.Add("@per_ocu", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Per_ocu;
				cmd.Parameters.Add("@tipo_vial", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Tipo_vial;
				cmd.Parameters.Add("@nom_vial", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_vial;
				cmd.Parameters.Add("@tipo_v_e_1", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Tipo_v_e_1;
				cmd.Parameters.Add("@nom_v_e_1", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_v_e_1;
				cmd.Parameters.Add("@tipo_v_e_2", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Tipo_v_e_2;
				cmd.Parameters.Add("@nom_v_e_2", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_v_e_2;
				cmd.Parameters.Add("@tipo_v_e_3", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Tipo_v_e_3;
				cmd.Parameters.Add("@nom_v_e_3", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_v_e_3;
				cmd.Parameters.Add("@numero_ext", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Numero_ext;
				cmd.Parameters.Add("@letra_ext", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Letra_ext;
				cmd.Parameters.Add("@edificio", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Edificio;
				cmd.Parameters.Add("@edificio_e", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Edificio_e;
				cmd.Parameters.Add("@numero_int", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Numero_int;
				cmd.Parameters.Add("@letra_int", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Letra_int;
				cmd.Parameters.Add("@tipo_asent", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Tipo_asent;
				cmd.Parameters.Add("@nomb_asent", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nomb_asent;
				cmd.Parameters.Add("@tipoCenCom", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.TipoCenCom;
				cmd.Parameters.Add("@nom_CenCom", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_CenCom;
				cmd.Parameters.Add("@num_local", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Num_local;
				cmd.Parameters.Add("@cod_postal", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Cod_postal;
				cmd.Parameters.Add("@cve_ent", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Cve_ent;
				cmd.Parameters.Add("@entidad", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Entidad;
				cmd.Parameters.Add("@cve_mun", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Cve_mun;
				cmd.Parameters.Add("@municipio", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Municipio;
				cmd.Parameters.Add("@cve_loc", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Cve_loc;
				cmd.Parameters.Add("@localidad", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Localidad;
				cmd.Parameters.Add("@ageb", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Ageb;
				cmd.Parameters.Add("@manzana", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Manzana;
				cmd.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Telefono;
				cmd.Parameters.Add("@correoelec", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Correoelec;
				cmd.Parameters.Add("@www", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Www;
				cmd.Parameters.Add("@tipoUniEco", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.TipoUniEco;
				cmd.Parameters.Add("@latitud", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Latitud;
				cmd.Parameters.Add("@longitud", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Longitud;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarUnidadesEconomicas(SqlConnection Conexion, beUnidadesEconomicas obeUnidadesEconomicas)
	{
		string sp = "Proc_UnidadesEconomicasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@id", SqlDbType.Int).Value = obeUnidadesEconomicas.Id;
				cmd.Parameters.Add("@nom_estab", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_estab;
				cmd.Parameters.Add("@raz_social", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Raz_social;
				cmd.Parameters.Add("@codigo_act", SqlDbType.Int).Value = obeUnidadesEconomicas.Codigo_act;
				cmd.Parameters.Add("@nombre_act", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nombre_act;
				cmd.Parameters.Add("@per_ocu", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Per_ocu;
				cmd.Parameters.Add("@tipo_vial", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Tipo_vial;
				cmd.Parameters.Add("@nom_vial", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_vial;
				cmd.Parameters.Add("@tipo_v_e_1", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Tipo_v_e_1;
				cmd.Parameters.Add("@nom_v_e_1", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_v_e_1;
				cmd.Parameters.Add("@tipo_v_e_2", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Tipo_v_e_2;
				cmd.Parameters.Add("@nom_v_e_2", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_v_e_2;
				cmd.Parameters.Add("@tipo_v_e_3", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Tipo_v_e_3;
				cmd.Parameters.Add("@nom_v_e_3", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_v_e_3;
				cmd.Parameters.Add("@numero_ext", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Numero_ext;
				cmd.Parameters.Add("@letra_ext", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Letra_ext;
				cmd.Parameters.Add("@edificio", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Edificio;
				cmd.Parameters.Add("@edificio_e", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Edificio_e;
				cmd.Parameters.Add("@numero_int", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Numero_int;
				cmd.Parameters.Add("@letra_int", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Letra_int;
				cmd.Parameters.Add("@tipo_asent", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Tipo_asent;
				cmd.Parameters.Add("@nomb_asent", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nomb_asent;
				cmd.Parameters.Add("@tipoCenCom", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.TipoCenCom;
				cmd.Parameters.Add("@nom_CenCom", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Nom_CenCom;
				cmd.Parameters.Add("@num_local", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Num_local;
				cmd.Parameters.Add("@cod_postal", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Cod_postal;
				cmd.Parameters.Add("@cve_ent", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Cve_ent;
				cmd.Parameters.Add("@entidad", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Entidad;
				cmd.Parameters.Add("@cve_mun", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Cve_mun;
				cmd.Parameters.Add("@municipio", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Municipio;
				cmd.Parameters.Add("@cve_loc", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Cve_loc;
				cmd.Parameters.Add("@localidad", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Localidad;
				cmd.Parameters.Add("@ageb", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Ageb;
				cmd.Parameters.Add("@manzana", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Manzana;
				cmd.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Telefono;
				cmd.Parameters.Add("@correoelec", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Correoelec;
				cmd.Parameters.Add("@www", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Www;
				cmd.Parameters.Add("@tipoUniEco", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.TipoUniEco;
				cmd.Parameters.Add("@latitud", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Latitud;
				cmd.Parameters.Add("@longitud", SqlDbType.NVarChar).Value = obeUnidadesEconomicas.Longitud;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarUnidadesEconomicas(SqlConnection Conexion,int pCodigo_act)
	{
		string sp = "Proc_UnidadesEconomicasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Codigo_act", SqlDbType.Int).Value = pCodigo_act;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beUnidadesEconomicas traerUnidadesEconomicas_x_Codigo_act(SqlConnection Conexion,int Codigo_act)
	{
		string sp = "Proc_UnidadesEconomicas_x_Codigo_act";
				beUnidadesEconomicas obeUnidadesEconomicas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Codigo_act", SqlDbType.Int).Value = Codigo_act;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posid = datard.GetOrdinal("id");
						int posnom_estab = datard.GetOrdinal("nom_estab");
						int posraz_social = datard.GetOrdinal("raz_social");
						int poscodigo_act = datard.GetOrdinal("codigo_act");
						int posnombre_act = datard.GetOrdinal("nombre_act");
						int posper_ocu = datard.GetOrdinal("per_ocu");
						int postipo_vial = datard.GetOrdinal("tipo_vial");
						int posnom_vial = datard.GetOrdinal("nom_vial");
						int postipo_v_e_1 = datard.GetOrdinal("tipo_v_e_1");
						int posnom_v_e_1 = datard.GetOrdinal("nom_v_e_1");
						int postipo_v_e_2 = datard.GetOrdinal("tipo_v_e_2");
						int posnom_v_e_2 = datard.GetOrdinal("nom_v_e_2");
						int postipo_v_e_3 = datard.GetOrdinal("tipo_v_e_3");
						int posnom_v_e_3 = datard.GetOrdinal("nom_v_e_3");
						int posnumero_ext = datard.GetOrdinal("numero_ext");
						int posletra_ext = datard.GetOrdinal("letra_ext");
						int posedificio = datard.GetOrdinal("edificio");
						int posedificio_e = datard.GetOrdinal("edificio_e");
						int posnumero_int = datard.GetOrdinal("numero_int");
						int posletra_int = datard.GetOrdinal("letra_int");
						int postipo_asent = datard.GetOrdinal("tipo_asent");
						int posnomb_asent = datard.GetOrdinal("nomb_asent");
						int postipoCenCom = datard.GetOrdinal("tipoCenCom");
						int posnom_CenCom = datard.GetOrdinal("nom_CenCom");
						int posnum_local = datard.GetOrdinal("num_local");
						int poscod_postal = datard.GetOrdinal("cod_postal");
						int poscve_ent = datard.GetOrdinal("cve_ent");
						int posentidad = datard.GetOrdinal("entidad");
						int poscve_mun = datard.GetOrdinal("cve_mun");
						int posmunicipio = datard.GetOrdinal("municipio");
						int poscve_loc = datard.GetOrdinal("cve_loc");
						int poslocalidad = datard.GetOrdinal("localidad");
						int posageb = datard.GetOrdinal("ageb");
						int posmanzana = datard.GetOrdinal("manzana");
						int postelefono = datard.GetOrdinal("telefono");
						int poscorreoelec = datard.GetOrdinal("correoelec");
						int poswww = datard.GetOrdinal("www");
						int postipoUniEco = datard.GetOrdinal("tipoUniEco");
						int poslatitud = datard.GetOrdinal("latitud");
						int poslongitud = datard.GetOrdinal("longitud");
					 obeUnidadesEconomicas = new beUnidadesEconomicas();
				while (datard.Read())
					{
                            obeUnidadesEconomicas.Id = datard.GetInt32(posid);
                            obeUnidadesEconomicas.Nom_estab = datard.GetString(posnom_estab);
                            obeUnidadesEconomicas.Raz_social = datard.GetString(posraz_social);
                            obeUnidadesEconomicas.Codigo_act = datard.GetInt32(poscodigo_act);
                            obeUnidadesEconomicas.Nombre_act = datard.GetString(posnombre_act);
                            obeUnidadesEconomicas.Per_ocu = datard.GetString(posper_ocu);
                            obeUnidadesEconomicas.Tipo_vial = datard.GetString(postipo_vial);
                            obeUnidadesEconomicas.Nom_vial = datard.GetString(posnom_vial);
                            obeUnidadesEconomicas.Tipo_v_e_1 = datard.GetString(postipo_v_e_1);
                            obeUnidadesEconomicas.Nom_v_e_1 = datard.GetString(posnom_v_e_1);
                            obeUnidadesEconomicas.Tipo_v_e_2 = datard.GetString(postipo_v_e_2);
                            obeUnidadesEconomicas.Nom_v_e_2 = datard.GetString(posnom_v_e_2);
                            obeUnidadesEconomicas.Tipo_v_e_3 = datard.GetString(postipo_v_e_3);
                            obeUnidadesEconomicas.Nom_v_e_3 = datard.GetString(posnom_v_e_3);
                            obeUnidadesEconomicas.Numero_ext = datard.GetString(posnumero_ext);
                            obeUnidadesEconomicas.Letra_ext = datard.GetString(posletra_ext);
                            obeUnidadesEconomicas.Edificio = datard.GetString(posedificio);
                            obeUnidadesEconomicas.Edificio_e = datard.GetString(posedificio_e);
                            obeUnidadesEconomicas.Numero_int = datard.GetString(posnumero_int);
                            obeUnidadesEconomicas.Letra_int = datard.GetString(posletra_int);
                            obeUnidadesEconomicas.Tipo_asent = datard.GetString(postipo_asent);
                            obeUnidadesEconomicas.Nomb_asent = datard.GetString(posnomb_asent);
                            obeUnidadesEconomicas.TipoCenCom = datard.GetString(postipoCenCom);
                            obeUnidadesEconomicas.Nom_CenCom = datard.GetString(posnom_CenCom);
                            obeUnidadesEconomicas.Num_local = datard.GetString(posnum_local);
                            obeUnidadesEconomicas.Cod_postal = datard.GetString(poscod_postal);
                            obeUnidadesEconomicas.Cve_ent = datard.GetString(poscve_ent);
                            obeUnidadesEconomicas.Entidad = datard.GetString(posentidad);
                            obeUnidadesEconomicas.Cve_mun = datard.GetString(poscve_mun);
                            obeUnidadesEconomicas.Municipio = datard.GetString(posmunicipio);
                            obeUnidadesEconomicas.Cve_loc = datard.GetString(poscve_loc);
                            obeUnidadesEconomicas.Localidad = datard.GetString(poslocalidad);
                            obeUnidadesEconomicas.Ageb = datard.GetString(posageb);
                            obeUnidadesEconomicas.Manzana = datard.GetString(posmanzana);
                            obeUnidadesEconomicas.Telefono = datard.GetString(postelefono);
                            obeUnidadesEconomicas.Correoelec = datard.GetString(poscorreoelec);
                            obeUnidadesEconomicas.Www = datard.GetString(poswww);
                            obeUnidadesEconomicas.TipoUniEco = datard.GetString(postipoUniEco);
                            obeUnidadesEconomicas.Latitud = datard.GetString(poslatitud);
                            obeUnidadesEconomicas.Longitud = datard.GetString(poslongitud);
                        }
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeUnidadesEconomicas;
			}
	}
	public List< beUnidadesEconomicas> listarTodos_UnidadesEconomicas(SqlConnection Conexion)
	 {
		string sp = "Proc_UnidadesEconomicas_Traer_Todos";
		List<beUnidadesEconomicas> lbeUnidadesEconomicas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posid = datard.GetOrdinal("id");
						int posnom_estab = datard.GetOrdinal("nom_estab");
						int posraz_social = datard.GetOrdinal("raz_social");
						int poscodigo_act = datard.GetOrdinal("codigo_act");
						int posnombre_act = datard.GetOrdinal("nombre_act");
						int posper_ocu = datard.GetOrdinal("per_ocu");
						int postipo_vial = datard.GetOrdinal("tipo_vial");
						int posnom_vial = datard.GetOrdinal("nom_vial");
						int postipo_v_e_1 = datard.GetOrdinal("tipo_v_e_1");
						int posnom_v_e_1 = datard.GetOrdinal("nom_v_e_1");
						int postipo_v_e_2 = datard.GetOrdinal("tipo_v_e_2");
						int posnom_v_e_2 = datard.GetOrdinal("nom_v_e_2");
						int postipo_v_e_3 = datard.GetOrdinal("tipo_v_e_3");
						int posnom_v_e_3 = datard.GetOrdinal("nom_v_e_3");
						int posnumero_ext = datard.GetOrdinal("numero_ext");
						int posletra_ext = datard.GetOrdinal("letra_ext");
						int posedificio = datard.GetOrdinal("edificio");
						int posedificio_e = datard.GetOrdinal("edificio_e");
						int posnumero_int = datard.GetOrdinal("numero_int");
						int posletra_int = datard.GetOrdinal("letra_int");
						int postipo_asent = datard.GetOrdinal("tipo_asent");
						int posnomb_asent = datard.GetOrdinal("nomb_asent");
						int postipoCenCom = datard.GetOrdinal("tipoCenCom");
						int posnom_CenCom = datard.GetOrdinal("nom_CenCom");
						int posnum_local = datard.GetOrdinal("num_local");
						int poscod_postal = datard.GetOrdinal("cod_postal");
						int poscve_ent = datard.GetOrdinal("cve_ent");
						int posentidad = datard.GetOrdinal("entidad");
						int poscve_mun = datard.GetOrdinal("cve_mun");
						int posmunicipio = datard.GetOrdinal("municipio");
						int poscve_loc = datard.GetOrdinal("cve_loc");
						int poslocalidad = datard.GetOrdinal("localidad");
						int posageb = datard.GetOrdinal("ageb");
						int posmanzana = datard.GetOrdinal("manzana");
						int postelefono = datard.GetOrdinal("telefono");
						int poscorreoelec = datard.GetOrdinal("correoelec");
						int poswww = datard.GetOrdinal("www");
						int postipoUniEco = datard.GetOrdinal("tipoUniEco");
						int poslatitud = datard.GetOrdinal("latitud");
						int poslongitud = datard.GetOrdinal("longitud");
				lbeUnidadesEconomicas = new List<beUnidadesEconomicas>();
				beUnidadesEconomicas obeUnidadesEconomicas;
				while (datard.Read())
				{
					 obeUnidadesEconomicas = new beUnidadesEconomicas();
                            obeUnidadesEconomicas.Id = datard.GetInt32(posid);
                            obeUnidadesEconomicas.Nom_estab = datard.GetString(posnom_estab);
                            obeUnidadesEconomicas.Raz_social = datard.GetString(posraz_social);
                            obeUnidadesEconomicas.Codigo_act = datard.GetInt32(poscodigo_act);
                            obeUnidadesEconomicas.Nombre_act = datard.GetString(posnombre_act);
                            obeUnidadesEconomicas.Per_ocu = datard.GetString(posper_ocu);
                            obeUnidadesEconomicas.Tipo_vial = datard.GetString(postipo_vial);
                            obeUnidadesEconomicas.Nom_vial = datard.GetString(posnom_vial);
                            obeUnidadesEconomicas.Tipo_v_e_1 = datard.GetString(postipo_v_e_1);
                            obeUnidadesEconomicas.Nom_v_e_1 = datard.GetString(posnom_v_e_1);
                            obeUnidadesEconomicas.Tipo_v_e_2 = datard.GetString(postipo_v_e_2);
                            obeUnidadesEconomicas.Nom_v_e_2 = datard.GetString(posnom_v_e_2);
                            obeUnidadesEconomicas.Tipo_v_e_3 = datard.GetString(postipo_v_e_3);
                            obeUnidadesEconomicas.Nom_v_e_3 = datard.GetString(posnom_v_e_3);
                            obeUnidadesEconomicas.Numero_ext = datard.GetString(posnumero_ext);
                            obeUnidadesEconomicas.Letra_ext = datard.GetString(posletra_ext);
                            obeUnidadesEconomicas.Edificio = datard.GetString(posedificio);
                            obeUnidadesEconomicas.Edificio_e = datard.GetString(posedificio_e);
                            obeUnidadesEconomicas.Numero_int = datard.GetString(posnumero_int);
                            obeUnidadesEconomicas.Letra_int = datard.GetString(posletra_int);
                            obeUnidadesEconomicas.Tipo_asent = datard.GetString(postipo_asent);
                            obeUnidadesEconomicas.Nomb_asent = datard.GetString(posnomb_asent);
                            obeUnidadesEconomicas.TipoCenCom = datard.GetString(postipoCenCom);
                            obeUnidadesEconomicas.Nom_CenCom = datard.GetString(posnom_CenCom);
                            obeUnidadesEconomicas.Num_local = datard.GetString(posnum_local);
                            obeUnidadesEconomicas.Cod_postal = datard.GetString(poscod_postal);
                            obeUnidadesEconomicas.Cve_ent = datard.GetString(poscve_ent);
                            obeUnidadesEconomicas.Entidad = datard.GetString(posentidad);
                            obeUnidadesEconomicas.Cve_mun = datard.GetString(poscve_mun);
                            obeUnidadesEconomicas.Municipio = datard.GetString(posmunicipio);
                            obeUnidadesEconomicas.Cve_loc = datard.GetString(poscve_loc);
                            obeUnidadesEconomicas.Localidad = datard.GetString(poslocalidad);
                            obeUnidadesEconomicas.Ageb = datard.GetString(posageb);
                            obeUnidadesEconomicas.Manzana = datard.GetString(posmanzana);
                            obeUnidadesEconomicas.Telefono = datard.GetString(postelefono);
                            obeUnidadesEconomicas.Correoelec = datard.GetString(poscorreoelec);
                            obeUnidadesEconomicas.Www = datard.GetString(poswww);
                            obeUnidadesEconomicas.TipoUniEco = datard.GetString(postipoUniEco);
                            obeUnidadesEconomicas.Latitud = datard.GetString(poslatitud);
                            obeUnidadesEconomicas.Longitud = datard.GetString(poslongitud);
                            lbeUnidadesEconomicas.Add(obeUnidadesEconomicas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeUnidadesEconomicas;
		}
	}
	public List< beUnidadesEconomicas> listar_UnidadesEconomicas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_UnidadesEconomicas_TraerTodos_GetAll";
		List<beUnidadesEconomicas> lbeUnidadesEconomicas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posid = datard.GetOrdinal("id");
						int posnom_estab = datard.GetOrdinal("nom_estab");
						int posraz_social = datard.GetOrdinal("raz_social");
						int poscodigo_act = datard.GetOrdinal("codigo_act");
						int posnombre_act = datard.GetOrdinal("nombre_act");
						int posper_ocu = datard.GetOrdinal("per_ocu");
						int postipo_vial = datard.GetOrdinal("tipo_vial");
						int posnom_vial = datard.GetOrdinal("nom_vial");
						int postipo_v_e_1 = datard.GetOrdinal("tipo_v_e_1");
						int posnom_v_e_1 = datard.GetOrdinal("nom_v_e_1");
						int postipo_v_e_2 = datard.GetOrdinal("tipo_v_e_2");
						int posnom_v_e_2 = datard.GetOrdinal("nom_v_e_2");
						int postipo_v_e_3 = datard.GetOrdinal("tipo_v_e_3");
						int posnom_v_e_3 = datard.GetOrdinal("nom_v_e_3");
						int posnumero_ext = datard.GetOrdinal("numero_ext");
						int posletra_ext = datard.GetOrdinal("letra_ext");
						int posedificio = datard.GetOrdinal("edificio");
						int posedificio_e = datard.GetOrdinal("edificio_e");
						int posnumero_int = datard.GetOrdinal("numero_int");
						int posletra_int = datard.GetOrdinal("letra_int");
						int postipo_asent = datard.GetOrdinal("tipo_asent");
						int posnomb_asent = datard.GetOrdinal("nomb_asent");
						int postipoCenCom = datard.GetOrdinal("tipoCenCom");
						int posnom_CenCom = datard.GetOrdinal("nom_CenCom");
						int posnum_local = datard.GetOrdinal("num_local");
						int poscod_postal = datard.GetOrdinal("cod_postal");
						int poscve_ent = datard.GetOrdinal("cve_ent");
						int posentidad = datard.GetOrdinal("entidad");
						int poscve_mun = datard.GetOrdinal("cve_mun");
						int posmunicipio = datard.GetOrdinal("municipio");
						int poscve_loc = datard.GetOrdinal("cve_loc");
						int poslocalidad = datard.GetOrdinal("localidad");
						int posageb = datard.GetOrdinal("ageb");
						int posmanzana = datard.GetOrdinal("manzana");
						int postelefono = datard.GetOrdinal("telefono");
						int poscorreoelec = datard.GetOrdinal("correoelec");
						int poswww = datard.GetOrdinal("www");
						int postipoUniEco = datard.GetOrdinal("tipoUniEco");
						int poslatitud = datard.GetOrdinal("latitud");
						int poslongitud = datard.GetOrdinal("longitud");
				lbeUnidadesEconomicas = new List<beUnidadesEconomicas>();
				beUnidadesEconomicas obeUnidadesEconomicas;
				while (datard.Read())
				{
					 obeUnidadesEconomicas = new beUnidadesEconomicas();
                            obeUnidadesEconomicas.Id = datard.GetInt32(posid);
                            obeUnidadesEconomicas.Nom_estab = datard.GetString(posnom_estab);
                            obeUnidadesEconomicas.Raz_social = datard.GetString(posraz_social);
                            obeUnidadesEconomicas.Codigo_act = datard.GetInt32(poscodigo_act);
                            obeUnidadesEconomicas.Nombre_act = datard.GetString(posnombre_act);
                            obeUnidadesEconomicas.Per_ocu = datard.GetString(posper_ocu);
                            obeUnidadesEconomicas.Tipo_vial = datard.GetString(postipo_vial);
                            obeUnidadesEconomicas.Nom_vial = datard.GetString(posnom_vial);
                            obeUnidadesEconomicas.Tipo_v_e_1 = datard.GetString(postipo_v_e_1);
                            obeUnidadesEconomicas.Nom_v_e_1 = datard.GetString(posnom_v_e_1);
                            obeUnidadesEconomicas.Tipo_v_e_2 = datard.GetString(postipo_v_e_2);
                            obeUnidadesEconomicas.Nom_v_e_2 = datard.GetString(posnom_v_e_2);
                            obeUnidadesEconomicas.Tipo_v_e_3 = datard.GetString(postipo_v_e_3);
                            obeUnidadesEconomicas.Nom_v_e_3 = datard.GetString(posnom_v_e_3);
                            obeUnidadesEconomicas.Numero_ext = datard.GetString(posnumero_ext);
                            obeUnidadesEconomicas.Letra_ext = datard.GetString(posletra_ext);
                            obeUnidadesEconomicas.Edificio = datard.GetString(posedificio);
                            obeUnidadesEconomicas.Edificio_e = datard.GetString(posedificio_e);
                            obeUnidadesEconomicas.Numero_int = datard.GetString(posnumero_int);
                            obeUnidadesEconomicas.Letra_int = datard.GetString(posletra_int);
                            obeUnidadesEconomicas.Tipo_asent = datard.GetString(postipo_asent);
                            obeUnidadesEconomicas.Nomb_asent = datard.GetString(posnomb_asent);
                            obeUnidadesEconomicas.TipoCenCom = datard.GetString(postipoCenCom);
                            obeUnidadesEconomicas.Nom_CenCom = datard.GetString(posnom_CenCom);
                            obeUnidadesEconomicas.Num_local = datard.GetString(posnum_local);
                            obeUnidadesEconomicas.Cod_postal = datard.GetString(poscod_postal);
                            obeUnidadesEconomicas.Cve_ent = datard.GetString(poscve_ent);
                            obeUnidadesEconomicas.Entidad = datard.GetString(posentidad);
                            obeUnidadesEconomicas.Cve_mun = datard.GetString(poscve_mun);
                            obeUnidadesEconomicas.Municipio = datard.GetString(posmunicipio);
                            obeUnidadesEconomicas.Cve_loc = datard.GetString(poscve_loc);
                            obeUnidadesEconomicas.Localidad = datard.GetString(poslocalidad);
                            obeUnidadesEconomicas.Ageb = datard.GetString(posageb);
                            obeUnidadesEconomicas.Manzana = datard.GetString(posmanzana);
                            obeUnidadesEconomicas.Telefono = datard.GetString(postelefono);
                            obeUnidadesEconomicas.Correoelec = datard.GetString(poscorreoelec);
                            obeUnidadesEconomicas.Www = datard.GetString(poswww);
                            obeUnidadesEconomicas.TipoUniEco = datard.GetString(postipoUniEco);
                            obeUnidadesEconomicas.Latitud = datard.GetString(poslatitud);
                            obeUnidadesEconomicas.Longitud = datard.GetString(poslongitud);
                            // debe agregar campos de la Vista
                            lbeUnidadesEconomicas.Add(obeUnidadesEconomicas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeUnidadesEconomicas;
		}
	}

        public beUnidadesEconomicas UnidadesEconomicas_NumeroUnidades(SqlConnection Conexion, int num,string str)
        {
            string sp = "Proc_UnidadesEconomicas_NumeroUnidades";
            beUnidadesEconomicas obeUnidadesEconomicas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = num;//531113
            cmd.Parameters.Add("@TamannoUE", SqlDbType.VarChar).Value = str;//'0 a 5 personas'
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posnumero_int = datard.GetOrdinal("NumeroUE");
                        obeUnidadesEconomicas = new beUnidadesEconomicas();
                        while (datard.Read())
                        {
                            obeUnidadesEconomicas.Id = datard.GetInt32(posnumero_int);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeUnidadesEconomicas;
            }
        }

        public List<beUnidadesEconomicas> UnidadesEconomicas_x_nom_estab(SqlConnection Conexion, string texto, int cve_ent)/*, int cve_mun*/
        {
            string sp = "Proc_UnidadesEconomicas_x_nom_estab";
            beUnidadesEconomicas obeUnidadesEconomicas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            //string mun = cve_mun.ToString().Remove(0,cve_ent.ToString().Length);
            cmd.Parameters.Add("@texto", SqlDbType.NVarChar).Value = texto;
            cmd.Parameters.Add("@cve_ent", SqlDbType.Int).Value = cve_ent;
            //cmd.Parameters.Add("@cve_mun", SqlDbType.Int).Value = mun;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                List<beUnidadesEconomicas> lbeUnidadesEconomicas = new List<beUnidadesEconomicas>();
                try
                {
                    if (datard != null)
                    {
                        int posid = datard.GetOrdinal("id");
                        int posNombreEstado = datard.GetOrdinal("NombreEstado");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posCodigoActivo = datard.GetOrdinal("CodigoActivo");
                        int posNumbreActivo = datard.GetOrdinal("NumbreActivo");
                        while (datard.Read())
                        {
                            obeUnidadesEconomicas = new beUnidadesEconomicas();
                            obeUnidadesEconomicas.Id = datard.GetInt32(posid);
                            obeUnidadesEconomicas.Nom_estab = datard.GetString(posNombreEstado);
                            obeUnidadesEconomicas.Raz_social = datard.GetString(posRazonSocial);
                            obeUnidadesEconomicas.Codigo_act = datard.GetInt32(posCodigoActivo);
                            obeUnidadesEconomicas.Nombre_act = datard.GetString(posNumbreActivo);
                            lbeUnidadesEconomicas.Add(obeUnidadesEconomicas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeUnidadesEconomicas;
            }
        }

        public List<beUnidadesEconomicas> UnidadesEconomicasMuestra(SqlConnection Conexion, string TamanoEU, int Codigo, int CveEstado, int NoUnidadesEconomicas, int TamanoMuestra)
        {
            string sp = "Proc_UnidadesEconomicasMuestra";
            beUnidadesEconomicas obeUnidadesEconomicas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TamanoEU", SqlDbType.NVarChar).Value = TamanoEU;
            cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
            cmd.Parameters.Add("@CveEstado", SqlDbType.Int).Value = CveEstado;
            cmd.Parameters.Add("@NoUnidadesEconomicas", SqlDbType.Int).Value = NoUnidadesEconomicas;
            cmd.Parameters.Add("@TamanoMuestra", SqlDbType.Int).Value = TamanoMuestra;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                List<beUnidadesEconomicas> lbeUnidadesEconomicas = new List<beUnidadesEconomicas>();
                try
                {
                    if (datard != null)
                    {
                        int posid = datard.GetOrdinal("Id");
                        int posNombreEstado = datard.GetOrdinal("nom_estab");
                        int posRazonSocial = datard.GetOrdinal("raz_social");
                        int posCodigoActivo = datard.GetOrdinal("codigo_act");
                        while (datard.Read())
                        {
                            obeUnidadesEconomicas = new beUnidadesEconomicas();
                            obeUnidadesEconomicas.Id = datard.GetInt32(posid);
                            obeUnidadesEconomicas.Nom_estab = datard.GetString(posNombreEstado);
                            obeUnidadesEconomicas.Raz_social = datard.GetString(posRazonSocial);
                            obeUnidadesEconomicas.Codigo_act = datard.GetInt32(posCodigoActivo);
                            lbeUnidadesEconomicas.Add(obeUnidadesEconomicas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeUnidadesEconomicas;
            }
        }
    }
}
