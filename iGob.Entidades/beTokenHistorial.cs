using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTokenHistorial {

	public int IdTokenHistorial { get; set;}
	public int IdUsuario { get; set;}
	public int IdPerfil { get; set;}
	public string Usuario { get; set;}
	public string NoToken { get; set;}
	public string LlaveAcceso { get; set;}
	public string Token { get; set;}
	public DateTime FechaRegistro { get; set;}

	public beTokenHistorial()
	{
            this.IdTokenHistorial = int.MinValue;
            this.IdUsuario = int.MinValue;
            this.IdPerfil = int.MinValue;
            this.Usuario = string.Empty;
            this.NoToken = string.Empty;
            this.LlaveAcceso = string.Empty;
            this.Token = string.Empty;
            this.FechaRegistro = DateTime.MinValue;
        }

	public beTokenHistorial( int pIdTokenHistorial, int pIdUsuario, int pIdPerfil, string pUsuario, string pNoToken, string pllaveAcceso, string pToken, DateTime pFechaRegistro)
	{
		this.IdTokenHistorial = pIdTokenHistorial;
		this.IdUsuario = pIdUsuario;
		this.IdPerfil = pIdPerfil;
		this.Usuario = pUsuario;
		this.NoToken = pNoToken;
		this.LlaveAcceso = pllaveAcceso;
		this.Token = pToken;
		this.FechaRegistro = pFechaRegistro;
	}


}
}
