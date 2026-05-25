using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beSysUsuarios {

	public int IdUsuario { get; set;}
	public string Usuario { get; set;}
	public string Password { get; set;}
	public string Apellidos { get; set;}
	public string Nombres { get; set;}
	public int IdPerfil { get; set;}
	public string IdEstatusUsuario { get; set;}
	public int IdDependencia { get; set;}
	public int IdProveedor { get; set;}
	public int IdPersona { get; set;}
	public string CorreoElectronico { get; set;}
	public bool Activo { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}
	public string NoToken { get; set;}
	public string LlaveAcceso { get; set;}

	public beSysUsuarios()
	{
		
	}

	public beSysUsuarios( int pIdUsuario, string pUsuario, string pPassword, string pApellidos, string pNombres, int pIdPerfil, string pIdEstatusUsuario, int pIdDependencia, int pIdProveedor, int pIdPersona, string pCorreoElectronico, bool pActivo, int pIdUsuarioRegistro, DateTime pFechaRegistro, string pNoToken, string pllaveAcceso)
	{
		this.IdUsuario = pIdUsuario;
		this.Usuario = pUsuario;
		this.Password = pPassword;
		this.Apellidos = pApellidos;
		this.Nombres = pNombres;
		this.IdPerfil = pIdPerfil;
		this.IdEstatusUsuario = pIdEstatusUsuario;
		this.IdDependencia = pIdDependencia;
		this.IdProveedor = pIdProveedor;
		this.IdPersona = pIdPersona;
		this.CorreoElectronico = pCorreoElectronico;
		this.Activo = pActivo;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
		this.NoToken = pNoToken;
		this.LlaveAcceso = pllaveAcceso;
	}


}
}
