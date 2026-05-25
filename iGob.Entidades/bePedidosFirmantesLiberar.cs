using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class bePedidosFirmantesLiberar
    {
        public int IdPedidoFirmante { get; set; }
        public int IdPedido { get; set; }
        public int IdPerfil { get; set; }
        public int Ordenamiento { get; set; }
        public string Cargo { get; set; }
        public int IdEstatusFirmaPedido { get; set; }
        public int IdUsuarioFirmante { get; set; }
        public DateTime FechaFirma { get; set; }
        public string Perfil { get; set; }
        public int IdPersona { get; set; }
        public string NombreCompleto { get; set; }
        public string check { get; set; }
        public string activo { get; set; }
        public string EstatusFirmaPedido { get; set; }
    }
}
