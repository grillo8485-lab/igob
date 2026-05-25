using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsInvesticacionPrecio
    {
        public List<beNivelesConfianza> getAllNivelesConfianza()
        {
            return (new brNivelesConfianza()).listarTodos_NivelesConfianza();
        }
        public beNivelesConfianza getNivelesConfianza(int idNivelConfianza)
        {
            return (new brNivelesConfianza()).traerNivelesConfianza_x_IdNivelConfianza(idNivelConfianza);
        }
        public List<beDeterminacionPrecios> getAllDispercionMuestraPrecios()
        {
            return (new brDeterminacionPrecios()).listarTodos_DeterminacionPrecios();
        }
        public List<beGenerica> getProductos(beGenerica oGenerica)
        {
            return (new brRequisicionesLotes()).listarTodos_BienServicio_x_Producto(oGenerica);
        }
        public beDeterminacionPrecios getDeterminacionPrecio(int IdDeterminaPrecioBienServicio)
        {
            return (new brDeterminacionPrecios()).traerDeterminacionPrecios_x_IdDeterminaPrecioBienServicio(IdDeterminaPrecioBienServicio);
        }
        public beBienesServicios getBienesServicios(int IdBienServicio)
        {
            return (new brBienesServicios()).traerBienesServicios_x_IdBienServicio(IdBienServicio);
        }
        public int saveInvestigacionPrecio(beDeterminacionPrecios pDeterminacionPrecios)
        {
            return (new brDeterminacionPrecios()).guardarDeterminacionPrecios(pDeterminacionPrecios);
        }
        public int updateInvestigacionPrecio(beDeterminacionPrecios pDeterminacionPrecios)
        {
            return (new brDeterminacionPrecios()).actualizarDeterminacionPrecios(pDeterminacionPrecios);
        }
    }
}