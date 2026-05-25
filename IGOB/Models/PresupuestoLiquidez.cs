using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class PresupuestoLiquidez
    {
        public string Partida = string.Empty;
        public decimal MontoSolicitado = decimal.MinValue;
        public decimal SaldoPatida = decimal.MinValue;
        public decimal MontoPresupuestoAutorizado = decimal.MinValue;
        public decimal SaldoPresupuestoAutorizado = decimal.MinValue;
        public string OrigenRecurso = string.Empty;
        public List<ClavesPresupuestales> ClavesPresupuestalesDetalles = new List<ClavesPresupuestales>();

    }
}