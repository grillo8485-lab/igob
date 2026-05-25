using System;
using System.Data;

namespace iGob.Entidades
{
    public class beLicitacionesAclaracionDudas
    {
        //Licitaciones

        public int IdLicitacion { get; set; }
        public string FolioOficial { get; set; }
        public DateTime FechaPublicacion { get; set; }

        //tablas externas
        public string FechaAclaracionDudas { get; set; }
        public string HoraAclaracionDudas { get; set; }
        public string Titulo { get; set; }
        public string Dependencias { get; set; }
        public string Partidas { get; set; }
        public string FolioRequisiciones { get; set; }
        public string EmpresasProveedoras { get; set; }


        //Preguntas
        public string RazonSocial { get; set; }
        public int IdProveedorRqInvitacion { get; set; }
        public string RequisicionFolio { get; set; }
        public string Partida { get; set; }
        public string Dependencia { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }


        public beLicitacionesAclaracionDudas()
        {

        }
    }
}
