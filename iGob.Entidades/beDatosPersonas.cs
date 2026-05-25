using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beDatosPersonas
    {

        public int IdPersona { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string EntFedNacimiento { get; set; }
        public string Curp { get; set; }
        public string Rfc { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string CorreoElectronico { get; set; }
        public string Calle { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public string Localidad { get; set; }
        public string IdColonia { get; set; }
        public string CodigoPostal { get; set; }
        public string EstadoCivil { get; set; }
        public string Nacionalidad { get; set; }
        public int IdDependencia { get; set; }
        public int IdProveedor { get; set; }
        public int IdEstatus { get; set; }
        public int IdTipoPersona { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

        public beDatosPersonas()
        {

        }

        public beDatosPersonas(int pIdPersona, string pApellidos, string pNombres, DateTime pFechaNacimiento, string pSexo, string pEntFedNacimiento, string pCurp, string pRfc, string pTelefono, string pCelular, string pCorreoElectronico, string pCalle, string pNoExterior, string pNoInterior, string pLocalidad, string pIdColonia, string pCodigoPostal, string pEstadoCivil, string pNacionalidad, int pIdDependencia, int pIdProveedor, int pIdEstatus, int pIdTipoPersona, int pIdUsuarioRegistro, DateTime pFechaRegistro)
        {
            this.IdPersona = pIdPersona;
            this.Apellidos = pApellidos;
            this.Nombres = pNombres;
            this.FechaNacimiento = pFechaNacimiento;
            this.Sexo = pSexo;
            this.EntFedNacimiento = pEntFedNacimiento;
            this.Curp = pCurp;
            this.Rfc = pRfc;
            this.Telefono = pTelefono;
            this.Celular = pCelular;
            this.CorreoElectronico = pCorreoElectronico;
            this.Calle = pCalle;
            this.NoExterior = pNoExterior;
            this.NoInterior = pNoInterior;
            this.Localidad = pLocalidad;
            this.IdColonia = pIdColonia;
            this.CodigoPostal = pCodigoPostal;
            this.EstadoCivil = pEstadoCivil;
            this.Nacionalidad = pNacionalidad;
            this.IdDependencia = pIdDependencia;
            this.IdProveedor = pIdProveedor;
            this.IdEstatus = pIdEstatus;
            this.IdTipoPersona = pIdTipoPersona;
            this.IdUsuarioRegistro = pIdUsuarioRegistro;
            this.FechaRegistro = pFechaRegistro;
        }


    }
}
