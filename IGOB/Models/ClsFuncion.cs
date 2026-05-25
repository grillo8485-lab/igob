using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsFuncion
    {
        public List<ClsGenerica> getFunciones()
        {
            try
            {
                ClsModulo modulo = new ClsModulo();
                List<ClsGenerica> a = new List<ClsGenerica>();
                List<beSysFunciones> b = new List<beSysFunciones>();
                brSysFunciones c = new brSysFunciones();
                b = c.listarTodos_SysFunciones();
                foreach (var item in b)
                {
                    ClsGenerica cls = new ClsGenerica();
                    cls.id = item.IdFuncion;
                    cls.string1 = item.Funcion;
                    cls.string2 = item.Descripcion;
                    cls.string3 = item.Formulario;
                    cls.id2 = item.IdModulo;
                    cls.id3 = item.Orden;
                    cls.string4 = item.Activo ? "Activo" : "Inactivo";
                    cls.string5 = item.Icono;
                    cls.string6 = modulo.getModulo(item.IdModulo).Descripcion;
                    a.Add(cls);
                }
                return a;
            }
            catch (Exception ex)
            {
                List<ClsGenerica> a = new List<ClsGenerica>();
                return a;
            }

        }
        public beSysFunciones getFuncion(int pIdFuncion)
        {
            brSysFunciones c = new brSysFunciones();
            return c.traerSysFunciones_x_IdFuncion(pIdFuncion);
        }
        public int saveFuncion(beSysFunciones pSysFuncion)
        {
            brSysFunciones a = new brSysFunciones();
            return a.guardarSysFunciones(pSysFuncion);
        }
        public int saveEditFuncion(beSysFunciones pSysFuncion)
        {
            brSysFunciones a = new brSysFunciones();
            return a.actualizarSysFunciones(pSysFuncion);
        }
        public List<beSysFunciones> getAllFunciones()
        {
            brSysFunciones a = new brSysFunciones();
            return a.listarTodos_SysFunciones().Where(s => s.Activo == true).ToList();
        }
    }
}