using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beManifiestosProveedores {

	public int IdManifiestoProveedor { get; set;}
	public int IdProveedorRqInvitacion { get; set;}
	public int AplicaCapitalContable { get; set;}
	public string Infraestructura { get; set;}
	public int AnnioExperiencia { get; set;}
	public int NumeroEmpleados { get; set;}
	public string Domicilio { get; set;}
	public decimal CapitalContable { get; set;}
	public decimal IngresosUltimoAnnio { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}
    public int IdRequisicion { get; set; }

        public beManifiestosProveedores()
	{
		
	}

	public beManifiestosProveedores( int pIdManifiestoProveedor, int pIdProveedorRqInvitacion, int pAplicaCapitalContable, string pInfraestructura, int pAnnioExperiencia, int pNumeroEmpleados, string pDomicilio, decimal pCapitalContable, decimal pIngresosUltimoAnnio, int pIdUsuarioRegistro, DateTime pFechaRegistro)
	{
		this.IdManifiestoProveedor = pIdManifiestoProveedor;
		this.IdProveedorRqInvitacion = pIdProveedorRqInvitacion;
		this.AplicaCapitalContable = pAplicaCapitalContable;
		this.Infraestructura = pInfraestructura;
		this.AnnioExperiencia = pAnnioExperiencia;
		this.NumeroEmpleados = pNumeroEmpleados;
		this.Domicilio = pDomicilio;
		this.CapitalContable = pCapitalContable;
		this.IngresosUltimoAnnio = pIngresosUltimoAnnio;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
	}


}
}
