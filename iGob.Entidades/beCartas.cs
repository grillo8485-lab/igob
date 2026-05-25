using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beCartas {

	    public int IdCarta { get; set;}
	    public int IdTipoSolicitud { get; set;}
	    public int Numero { get; set;}
	    public string Inciso { get; set;}
	    public string Nombre { get; set;}
	    public string Carta { get; set;}
	    public string Solicitada { get; set;}
	    public int IdEstatus { get; set;}
	    public int IdTipoCarta { get; set;}
	    public int Obligada { get; set;}
	    public int IdGobierno { get; set;}
	    public int IdUsuarioRegistro { get; set;}
	    public DateTime FechaRegistro { get; set;}

        public string TipoCarta { get; set; }
        public int IdProveedorRequisicionCarta { get; set; }
        public int IdRequisicion { get; set; }
        public int Autorizada { get; set; }

        public int IdProveedorCarta { get; set; }
        public int IdProveedorRqInvitacion { get; set; }
        public bool AceptacionCarta { get; set; }
        public DateTime FechaAceptacion { get; set; }

        public beCartas()
	    {
		
	    }

	    public beCartas( int pIdCarta, int pIdTipoSolicitud, int pNumero, string pInciso, string pNombre, string pCarta, string pSolicitada, int pIdEstatus, int pIdTipoCarta, int pObligada, int pIdGobierno, int pIdUsuarioRegistro, DateTime pFechaRegistro, string pTipoCarta)

	    {
		    this.IdCarta = pIdCarta;
		    this.IdTipoSolicitud = pIdTipoSolicitud;
		    this.Numero = pNumero;
		    this.Inciso = pInciso;
		    this.Nombre = pNombre;
		    this.Carta = pCarta;
		    this.Solicitada = pSolicitada;
		    this.IdEstatus = pIdEstatus;
		    this.IdTipoCarta = pIdTipoCarta;
		    this.Obligada = pObligada;
		    this.IdGobierno = pIdGobierno;
		    this.IdUsuarioRegistro = pIdUsuarioRegistro;
		    this.FechaRegistro = pFechaRegistro;
            this.TipoCarta = pTipoCarta;

        }
    }
}
