using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beBienesServicios {

	    public int IdBienServicio { get; set;}
	    public string Codigo { get; set;}
	    public string ClaveCubs { get; set;}
	    public string BienServicio { get; set;}
	    public string Descripcion { get; set;}
	    public int IdModificador { get; set;}
	    public int IdTipoProducto { get; set;}
	    public int IdMarca { get; set;}
	    public int IdFamilia { get; set;}
	    public int IdUnidadMedida { get; set;}
	    public int IdImpuesto { get; set;}
	    public decimal PrecioUnitario { get; set;}
	    public int IdPartida { get; set;}
	    public decimal PrecioUnitarioMejorLicitado { get; set;}
	    public int IdCertificacion { get; set;}
	    public int IdTipoMoneda { get; set;}
	    public bool Activo { get; set;}
	    public int IdUsuarioRegistro { get; set;}
	    public DateTime? FechaRegistro { get; set;}
        public string TipoProducto { get; set; }
        public string Marca { get; set; }
        public string UnidadMedida { get; set; }
        public string Familia { get; set; }
        public string Impuesto { get; set; }
        public string Certificacion { get; set; }
        public string Partida { get; set; }
        public string Capitulo { get; set; }
        public string Modificador { get; set; }
        public int IdCapitulo { get; set; }
        public DateTime FechaActualizacionPrecio { get; set; }
        public int CodigoScian { get; set; }

        public beBienesServicios()
	    {
		
	    }

	    public beBienesServicios( int pIdBienServicio, string pCodigo, string pClaveCubs, string pBienServicio, string pDescripcion, int pIdModificador, int pIdTipoProducto, int pIdMarca, int pIdFamilia, int pIdUnidadMedida, int pIdImpuesto, decimal pPrecioUnitario, int pIdPartida, decimal pPrecioUnitarioMejorLicitado, int pIdCertificacion, int pIdTipoMoneda, bool pActivo, int pIdUsuarioRegistro, DateTime pFechaRegistro, DateTime pFechaActualizacionPrecio, int pCodigoScian)
	    {
		    this.IdBienServicio = pIdBienServicio;
		    this.Codigo = pCodigo;
		    this.ClaveCubs = pClaveCubs;
		    this.BienServicio = pBienServicio;
		    this.Descripcion = pDescripcion;
		    this.IdModificador = pIdModificador;
		    this.IdTipoProducto = pIdTipoProducto;
		    this.IdMarca = pIdMarca;
		    this.IdFamilia = pIdFamilia;
		    this.IdUnidadMedida = pIdUnidadMedida;
		    this.IdImpuesto = pIdImpuesto;
		    this.PrecioUnitario = pPrecioUnitario;
		    this.IdPartida = pIdPartida;
		    this.PrecioUnitarioMejorLicitado = pPrecioUnitarioMejorLicitado;
		    this.IdCertificacion = pIdCertificacion;
		    this.IdTipoMoneda = pIdTipoMoneda;
		    this.Activo = pActivo;
		    this.IdUsuarioRegistro = pIdUsuarioRegistro;
		    this.FechaRegistro = pFechaRegistro;
            this.FechaActualizacionPrecio = pFechaActualizacionPrecio;
            this.CodigoScian = pCodigoScian;
        }


    }
}
