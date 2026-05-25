using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsReactivosConclusionEM
    {
        public List<beReactivosConclusionEM> getAllReactivosConclusionEM()
        {
            brReactivosConclusionEM br = new brReactivosConclusionEM();
            return br.listarTodos_ReactivosConclusionEM();
        }
        public beReactivosConclusionEM getReactivosConclusionEM(int IdReactivosConclusionEM)
        {
            brReactivosConclusionEM br = new brReactivosConclusionEM();
            return br.traerReactivosConclusionEM_x_IdReactivoConclusionEM(IdReactivosConclusionEM);
        }
        public int saveReactivosConclusionEM(beReactivosConclusionEM pReactivosConclusionEM)
        {
            brReactivosConclusionEM br = new brReactivosConclusionEM();
            return br.guardarReactivosConclusionEM(pReactivosConclusionEM);
        }
        public int updateReactivosConclusionEM(beReactivosConclusionEM pReactivosConclusionEM)
        {
            brReactivosConclusionEM br = new brReactivosConclusionEM();
            return br.actualizarReactivosConclusionEM(pReactivosConclusionEM);
        }
    }
}