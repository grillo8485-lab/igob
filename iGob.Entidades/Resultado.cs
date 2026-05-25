using System;
using System.Data;

public class Resultado {

	public int id { get; set;}
	public bool Realizado { get; set;}
	public string Mensaje { get; set;}
	public string NumeroError { get; set;}
	public string NombreStored { get; set;}

	public Resultado(){
	}

	public Resultado(int pId, bool pRealizado, string pMensaje )
	{
		this.Id = pId;
		this.Realizado = pRealizado;
		this.Mensaje = pMensaje;
	}


}
