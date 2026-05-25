using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beConfiguracionFirmatesPedidos
    {

        public int IdConfigFirmantePedido { get; set; }
        public int IdGobierno { get; set; }
        public int IdModalidadLicitacion { get; set; }
        public int IdPerfil { get; set; }
        public int Ordenamiento { get; set; }
        public string Cargo { get; set; }
        public bool Activo { get; set; }
        public int IdTipoProceso { get; set; }
        public string Perfil { get; set; }
        public string Modalidad { get; set; }
        public beConfiguracionFirmatesPedidos()
        {

        }

        public beConfiguracionFirmatesPedidos(int pIdConfigFirmantePedido, int pIdGobierno, int pIdModalidadLicitacion, int pIdPerfil, int pOrdenamiento, string pCargo, bool pActivo, int pIdTipoProceso)
        {
            this.IdConfigFirmantePedido = pIdConfigFirmantePedido;
            this.IdGobierno = pIdGobierno;
            this.IdModalidadLicitacion = pIdModalidadLicitacion;
            this.IdPerfil = pIdPerfil;
            this.Ordenamiento = pOrdenamiento;
            this.Cargo = pCargo;
            this.Activo = pActivo;
            this.IdTipoProceso = pIdTipoProceso;
        }


    }
}
