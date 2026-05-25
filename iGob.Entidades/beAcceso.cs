using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAcceso {

	public int IdAcceso { get; set;}
	public string FechaAcceso { get; set;}
	public string FechaAccesoTotal { get; set;}
	public bool Activo { get; set;}
        public int result { get; set; }
        public beAcceso()
	{
            this.result = int.MinValue;

    }

	public beAcceso( int pIdAcceso, string pFechaAcceso, string pFechaAccesoTotal, bool pActivo)
	{
		this.IdAcceso = pIdAcceso;
		this.FechaAcceso = pFechaAcceso;
		this.FechaAccesoTotal = pFechaAccesoTotal;
		this.Activo = pActivo;
	}


}
}
