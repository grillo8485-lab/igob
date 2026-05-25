using System;
using System.Data;

namespace iGob.Entidades
{
    public class beRptAppEjecutivosLicitaciones
    {
        /*Reporte Presupuesto*/
        public string Estado { get; set; }
        public decimal MontoPresupuestadoTotal { get; set; }
        public decimal MontoTotalEjercido { get; set; }
        public decimal MontoxEjercer { get; set; }
        public decimal Economia { get; set; }
        public int Ejercicio { get; set; }

        /* Reporte Adquisiciones */
        //public string Estado { get; set; }
        //public decimal MontoPresupuestadoTotal { get; set; }
        public decimal MontoAdjudicadoTotal { get; set; }
        public decimal MontoTotalLicitaAbierta { get; set; }
        public decimal MontoTotalDirecta { get; set; }
        public decimal MontoTotalRestringida { get; set; }
        //public int Ejercicio { get; set; }

        /* Lista de dependencias */
        public int IdDependencia { get; set; }
        public string Dependencia { get; set; }

        /* Reporte Presupuesto Dependencias */
        //public string Dependencia { get; set; }
        public int IdGobierno { get; set; }
        public decimal PresupuestoDependencia { get; set; }
        public decimal PresupuestoEjercido { get; set; }
        public decimal PresupuestoxEjercer { get; set; }
        public decimal MontoTotalEconomia { get; set; }

        /* Reporte Adquisiciones Dependencias*/
        //public string Dependencia { get; set; }
        public string Gobierno { get; set; }
        //public decimal MontoAdjudicadoTotal { get; set; }
        //public decimal MontoTotalLicitaAbierta { get; set; }
        //public decimal MontoTotalDirecta { get; set; }
        //public decimal MontoTotalRestringida { get; set; }
        //public int Ejercicio { get; set; }

        /* Lista de articulos */
        public int IdBienServicio { get; set; }
        public string BienServicio { get; set; }

        /* Precio de producto */
        //public int IdBienServicio { get; set; }
        //public string BienServicio { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioUnitarioMejorLicitado { get; set; }

        /* Lista de proveedores */
        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        //public int IdGobierno { get; set; }

        /* Adquisiciones Proveedores Dependencias */
        //public int IdProveedor { get; set; }
        //public int RazonSocial { get; set; }
        //public int IdDependencia { get; set; }
        //public int Dependencia { get; set; }
        public decimal MontoTotalAbiertas { get; set; }
        public decimal MontoTotalDirectas { get; set; }
        public decimal MontoTotalRestringidas { get; set; }
        public decimal MontoTotal { get; set; }


        public beRptAppEjecutivosLicitaciones()
        {

        }
    }
}
