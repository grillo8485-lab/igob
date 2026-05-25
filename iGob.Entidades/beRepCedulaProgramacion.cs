using System;
using System.Data;

namespace iGob.Entidades
{
    public class beRepCedulaProgramacion
    {
        //licitación
        public int IdLicitacion { get; set; }
        public string Titulo { get; set; }
        public string Modalidad { get; set; }
        public string NumeroOficial { get; set; }
        public int Ejercicio { get; set; }
        public string Tiempo { get; set; }
        public string NumeroLicitacion { get; set; }
        public DateTime FechaAutorizacion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaDisposicionBases { get; set; }
        public DateTime FechaLimitePreguntas { get; set; }
        public DateTime FechaLimiteRespuestas { get; set; }
        public DateTime FechaHoraAclaracionDudas { get; set; }
        public DateTime FechaEnvioPropuestasTecEco { get; set; }
        public DateTime FechaLimiteDictamen { get; set; }
        public DateTime FechaFallo { get; set; }
        public int IdUnidadLicitadora { get; set; }
        public string UnidadLicitadora { get; set; }

        //requisición
        public int IdRequisicion { get; set; }
        public string Dependencia { get; set; }
        public string Partida { get; set; }
        public string RequisicionFolio { get; set; }
        public string Recepcion { get; set; }

        public beRepCedulaProgramacion()
        {

        }
    }
}
