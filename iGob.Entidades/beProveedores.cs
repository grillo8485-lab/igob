using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beProveedores {

	public int IdProveedor { get; set;}
	public string RazonSocial { get; set;}
	public string NombreComercial { get; set;}
	public int TipoPersona { get; set;}
	public string Rfc { get; set;}
	public string Curp { get; set;}
	public string Calle { get; set;}
	public string NoExterior { get; set;}
	public string NoInterior { get; set;}
	public string IdMunicipio { get; set;}
	public string Colonia { get; set;}
	public string CodigoPostal { get; set;}
	public string Telefono { get; set;}
	public string NombreContacto { get; set;}
	public string CelularContacto { get; set;}
	public string Email { get; set;}
	public string Sitiooficial { get; set;}
	public int TipoProveedor { get; set;}
	public int IdBanco { get; set;}
	public string Cuenta { get; set;}
	public string Titular { get; set;}
	public string CLABE { get; set;}
	public int IdGobierno { get; set;}
	public int EstatusProveedor { get; set;}
    
    /* Get All 28/08/2018 */
    public string Municipio { get; set; }
    public string ClaveEstado { get; set; }
    public string Estado { get; set; }
    public string Gobierno { get; set; }

        public int Seleccion { get; set; }
        public int IdAdjudicacionProveedor { get; set; }
        public int IdAdjudicacion { get; set; }

    public beProveedores()
	{
		
	}

	public beProveedores( int pIdProveedor, string pRazonSocial, string pNombreComercial, int pTipoPersona, string pRfc, string pCurp, string pCalle, string pNoExterior, string pNoInterior, string pIdMunicipio, string pColonia, string pCodigoPostal, string pTelefono, string pNombreContacto, string pCelularContacto, string pEmail, string pSitiooficial, int pTipoProveedor, int pIdBanco, string pCuenta, string pTitular, string pCLABE, int pIdGobierno, int pEstatusProveedor,string pMunicipio, string pClaveEstado, string pEstado, string pGobierno, int pSeleccion, int pIdAdjudicacionProveedor, int pIdAdjudicacion)
	{
		this.IdProveedor = pIdProveedor;
		this.RazonSocial = pRazonSocial;
		this.NombreComercial = pNombreComercial;
		this.TipoPersona = pTipoPersona;
		this.Rfc = pRfc;
		this.Curp = pCurp;
		this.Calle = pCalle;
		this.NoExterior = pNoExterior;
		this.NoInterior = pNoInterior;
		this.IdMunicipio = pIdMunicipio;
		this.Colonia = pColonia;
		this.CodigoPostal = pCodigoPostal;
		this.Telefono = pTelefono;
		this.NombreContacto = pNombreContacto;
		this.CelularContacto = pCelularContacto;
		this.Email = pEmail;
		this.Sitiooficial = pSitiooficial;
		this.TipoProveedor = pTipoProveedor;
		this.IdBanco = pIdBanco;
		this.Cuenta = pCuenta;
		this.Titular = pTitular;
		this.CLABE = pCLABE;
		this.IdGobierno = pIdGobierno;
		this.EstatusProveedor = pEstatusProveedor;
        this.Municipio = pMunicipio;
        this.ClaveEstado = pClaveEstado;
        this.Estado = pEstado;
        this.Gobierno = pGobierno;
        this.Seleccion = pSeleccion;
        this.IdAdjudicacionProveedor = pIdAdjudicacionProveedor;
            this.IdAdjudicacion = pIdAdjudicacion;

    }


}
}
