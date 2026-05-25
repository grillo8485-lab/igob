using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beConfiguracionMailSalida {

	public int IdConfigMailSalida { get; set;}
	public string Nombre { get; set;}
	public string Correo { get; set;}
	public string Contrasena { get; set;}
	public string Smtp { get; set;}
	public int Puerto { get; set;}
	public string Servidor { get; set;}
	public bool Activo { get; set;}

	public beConfiguracionMailSalida()
	{
		
	}

	public beConfiguracionMailSalida( int pIdConfigMailSalida, string pNombre, string pCorreo, string pContrasena, string pSmtp, string Servidor, int pPuerto, bool pActivo)
	{
		this.IdConfigMailSalida = pIdConfigMailSalida;
		this.Nombre = pNombre;
		this.Correo = pCorreo;
		this.Contrasena = pContrasena;
		this.Smtp = pSmtp;
        this.Puerto = pPuerto;
		this.Servidor = Servidor;
		this.Activo = pActivo;
	}


}
}
