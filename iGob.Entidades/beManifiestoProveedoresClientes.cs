using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beManifiestoProveedoresClientes {

	public int IdManifiestoProveedorCliente { get; set;}
	public int IdManifiestoProveedor { get; set;}
	public string NombreCliente { get; set;}
	public string DirecionCliente { get; set;}
	public string TelefonoCliente { get; set;}
        public int IdRequisicion { get; set; }
        public int IdProveedorRqInvitacion { get; set; }

        public beManifiestoProveedoresClientes()
	{
		
	}

	public beManifiestoProveedoresClientes( int pIdManifiestoProveedorCliente, int pIdManifiestoProveedor, string pNombreCliente, string pDirecionCliente, string pTelefonoCliente)
	{
		this.IdManifiestoProveedorCliente = pIdManifiestoProveedorCliente;
		this.IdManifiestoProveedor = pIdManifiestoProveedor;
		this.NombreCliente = pNombreCliente;
		this.DirecionCliente = pDirecionCliente;
		this.TelefonoCliente = pTelefonoCliente;
	}


}
}
