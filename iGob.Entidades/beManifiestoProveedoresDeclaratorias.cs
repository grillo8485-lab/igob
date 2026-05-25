using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beManifiestoProveedoresDeclaratorias {

	public int IdManifiestoProveedorDeclaratoria { get; set;}
	public int IdManifiestoProveedor { get; set;}
	public int IdManifiesto { get; set;}
	public bool Aceptacion { get; set;}
        public string Manifiesto { get; set; }

        public int IdProveedorRqInvitacion { get; set; }
        public int IdRequisicion { get; set; }

        public beManifiestoProveedoresDeclaratorias()
	{
		
	}

	public beManifiestoProveedoresDeclaratorias( int pIdManifiestoProveedorDeclaratoria, int pIdManifiestoProveedor, int pIdManifiesto, bool pAceptacion)
	{
		this.IdManifiestoProveedorDeclaratoria = pIdManifiestoProveedorDeclaratoria;
		this.IdManifiestoProveedor = pIdManifiestoProveedor;
		this.IdManifiesto = pIdManifiesto;
		this.Aceptacion = pAceptacion;
	}


}
}
