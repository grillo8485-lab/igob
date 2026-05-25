using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beGobiernoLogoBanner {

	public int IdLogoBanner { get; set;}
	public int IdGobierno { get; set;}
	public string Logo { get; set;}
	public string Banner { get; set;}

	public beGobiernoLogoBanner()
	{
		
	}

	public beGobiernoLogoBanner( int pIdLogoBanner, int pIdGobierno, string pLogo, string pBanner)
	{
		this.IdLogoBanner = pIdLogoBanner;
		this.IdGobierno = pIdGobierno;
		this.Logo = pLogo;
		this.Banner = pBanner;
	}


}
}
