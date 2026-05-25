using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beUnidadesEconomicas {

	public int Id { get; set;}
	public string Nom_estab { get; set;}
	public string Raz_social { get; set;}
	public int Codigo_act { get; set;}
	public string Nombre_act { get; set;}
	public string Per_ocu { get; set;}
	public string Tipo_vial { get; set;}
	public string Nom_vial { get; set;}
	public string Tipo_v_e_1 { get; set;}
	public string Nom_v_e_1 { get; set;}
	public string Tipo_v_e_2 { get; set;}
	public string Nom_v_e_2 { get; set;}
	public string Tipo_v_e_3 { get; set;}
	public string Nom_v_e_3 { get; set;}
	public string Numero_ext { get; set;}
	public string Letra_ext { get; set;}
	public string Edificio { get; set;}
	public string Edificio_e { get; set;}
	public string Numero_int { get; set;}
	public string Letra_int { get; set;}
	public string Tipo_asent { get; set;}
	public string Nomb_asent { get; set;}
	public string TipoCenCom { get; set;}
	public string Nom_CenCom { get; set;}
	public string Num_local { get; set;}
	public string Cod_postal { get; set;}
	public string Cve_ent { get; set;}
	public string Entidad { get; set;}
	public string Cve_mun { get; set;}
	public string Municipio { get; set;}
	public string Cve_loc { get; set;}
	public string Localidad { get; set;}
	public string Ageb { get; set;}
	public string Manzana { get; set;}
	public string Telefono { get; set;}
	public string Correoelec { get; set;}
	public string Www { get; set;}
	public string TipoUniEco { get; set;}
	public string Latitud { get; set;}
	public string Longitud { get; set;}

	public beUnidadesEconomicas()
	{
		
	}

	public beUnidadesEconomicas( int pid, string pnom_estab, string praz_social, int pcodigo_act, string pnombre_act, string pper_ocu, string ptipo_vial, string pnom_vial, string ptipo_v_e_1, string pnom_v_e_1, string ptipo_v_e_2, string pnom_v_e_2, string ptipo_v_e_3, string pnom_v_e_3, string pnumero_ext, string pletra_ext, string pedificio, string pedificio_e, string pnumero_int, string pletra_int, string ptipo_asent, string pnomb_asent, string ptipoCenCom, string pnom_CenCom, string pnum_local, string pcod_postal, string pcve_ent, string pentidad, string pcve_mun, string pmunicipio, string pcve_loc, string plocalidad, string pageb, string pmanzana, string ptelefono, string pcorreoelec, string pwww, string ptipoUniEco, string platitud, string plongitud)
	{
		this.Id = pid;
		this.Nom_estab = pnom_estab;
		this.Raz_social = praz_social;
		this.Codigo_act = pcodigo_act;
		this.Nombre_act = pnombre_act;
		this.Per_ocu = pper_ocu;
		this.Tipo_vial = ptipo_vial;
		this.Nom_vial = pnom_vial;
		this.Tipo_v_e_1 = ptipo_v_e_1;
		this.Nom_v_e_1 = pnom_v_e_1;
		this.Tipo_v_e_2 = ptipo_v_e_2;
		this.Nom_v_e_2 = pnom_v_e_2;
		this.Tipo_v_e_3 = ptipo_v_e_3;
		this.Nom_v_e_3 = pnom_v_e_3;
		this.Numero_ext = pnumero_ext;
		this.Letra_ext = pletra_ext;
		this.Edificio = pedificio;
		this.Edificio_e = pedificio_e;
		this.Numero_int = pnumero_int;
		this.Letra_int = pletra_int;
		this.Tipo_asent = ptipo_asent;
		this.Nomb_asent = pnomb_asent;
		this.TipoCenCom = ptipoCenCom;
		this.Nom_CenCom = pnom_CenCom;
		this.Num_local = pnum_local;
		this.Cod_postal = pcod_postal;
		this.Cve_ent = pcve_ent;
		this.Entidad = pentidad;
		this.Cve_mun = pcve_mun;
		this.Municipio = pmunicipio;
		this.Cve_loc = pcve_loc;
		this.Localidad = plocalidad;
		this.Ageb = pageb;
		this.Manzana = pmanzana;
		this.Telefono = ptelefono;
		this.Correoelec = pcorreoelec;
		this.Www = pwww;
		this.TipoUniEco = ptipoUniEco;
		this.Latitud = platitud;
		this.Longitud = plongitud;
	}


}
}
