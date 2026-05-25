using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beBienServicioEstudioMercado {

	    public int IdDatoEstudioMercado { get; set;}
	    public int IdBienServicio { get; set;}
	    public string PlazoEntrega { get; set;}
	    public string LugaresEntrega { get; set;}
	    public string FormaTerminoPago { get; set;}
	    public string CircunstanciaAplicables { get; set;}
	    public string NormasAplicables { get; set;}
	    public string GradoIntegracionMexicano { get; set;}
	    public int TamannoUnidades { get; set;}
	    public int NoUnidadesEconomicas { get; set;}
	    public int TipoDeterminacion { get; set;}
	    public int IdEstatusEstudioMercado { get; set;}
	    public int Estado { get; set;}
	    public int Municipio { get; set;}
	    public int Localidad { get; set;}
        public bool UEVieneCatalogo { get; set; }

        public string BienServicio { get; set; }
	    public int CodigoScian { get; set; }
	    public string EstatusEstudioMercado { get; set; }


        public beBienServicioEstudioMercado()
	    {
		
	    }

	    public beBienServicioEstudioMercado( int pIdDatoEstudioMercado, int pIdBienServicio, string pPlazoEntrega, string pLugaresEntrega, string pFormaTerminoPago, string pCircunstanciaAplicables, string pNormasAplicables, string pGradoIntegracionMexicano, int pTamannoUnidades, int pNoUnidadesEconomicas, int pTipoDeterminacion, int pIdEstatusEstudioMercado, int pEstado, int pMunicipio, int pLocalidad, bool pUEVieneCatalogo, string pBienServicio, int pCodigoScian, string pEstatusEstudioMercado)
	    {
		    this.IdDatoEstudioMercado = pIdDatoEstudioMercado;
		    this.IdBienServicio = pIdBienServicio;
		    this.PlazoEntrega = pPlazoEntrega;
		    this.LugaresEntrega = pLugaresEntrega;
		    this.FormaTerminoPago = pFormaTerminoPago;
		    this.CircunstanciaAplicables = pCircunstanciaAplicables;
		    this.NormasAplicables = pNormasAplicables;
		    this.GradoIntegracionMexicano = pGradoIntegracionMexicano;
		    this.TamannoUnidades = pTamannoUnidades;
		    this.NoUnidadesEconomicas = pNoUnidadesEconomicas;
		    this.TipoDeterminacion = pTipoDeterminacion;
		    this.IdEstatusEstudioMercado = pIdEstatusEstudioMercado;
		    this.Estado = pEstado;
		    this.Municipio = pMunicipio;
		    this.Localidad = pLocalidad;
            this.UEVieneCatalogo = pUEVieneCatalogo;
            this.BienServicio = pBienServicio;
            this.CodigoScian = pCodigoScian;
            this.EstatusEstudioMercado = pEstatusEstudioMercado;
        }
    }
}
