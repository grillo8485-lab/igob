using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsUsuario
    {
        protected List<beSysUsuarios> getAllUsuario()
        {
            List<beSysUsuarios> lstUsuarios = new List<beSysUsuarios>();
            brSysUsuarios brUsuario = new brSysUsuarios();
            lstUsuarios = brUsuario.listarTodos_SysUsuarios();

            return lstUsuarios;
        }
        public List<ClsGenerica> getAllUsuariosText()
        {
            var usuarios = getAllUsuario();
            List<ClsGenerica> a = new List<ClsGenerica>();
            return procesarListado(usuarios);

        }
        public List<beSysPerfiles> getPerfiles()
        {
             brSysPerfiles brPerfiles = new brSysPerfiles();
             return brPerfiles.listarTodos_SysPerfiles().ToList();
            
        }
        public List<beDatosPersonas> getPersonas(string rfcNombreCompleto)
        {
            brDatosPersonas brPersonas = new brDatosPersonas();
            var c = brPersonas.listarTodos_DatosPersonas_x_RfcNombreCompleto(rfcNombreCompleto);

            foreach (beDatosPersonas item in c)
            {
                item.Nombres = item.Nombres + " " + item.Apellidos;
            }
            return c.ToList().Where(s=> s.IdEstatus==1).ToList();

        }
        public beProveedores getProveedores(int pIdProveedor)
        {
            beProveedores a = new beProveedores();
            var b = new brProveedores();
            return b.traerProveedores_x_IdProveedor(pIdProveedor);
            
        }
        public beDependencias getDependencias(int pIdDepencendia)
        {
            beDependencias a = new beDependencias();
            var b = new brDependencias();
            a = b.traerDependencias_x_IdDependencia(pIdDepencendia);
            return a;
        }
        public beProveedores getProveedor(int pIdProveedor)
        {
            beProveedores a = new beProveedores();
            var b = new brProveedores();
            a = b.traerProveedores_x_IdProveedor(pIdProveedor);
            return a;
        }
        public beDatosPersonas getPersona(int pIdPersona)
        {
            brDatosPersonas brPersonas = new brDatosPersonas();
            var c = brPersonas.traerDatosPersonas_x_IdPersona(pIdPersona);
            return c;

        }
        protected List<ClsGenerica> procesarListado(List<beSysUsuarios> lstUsuarios)
        {
            List<ClsGenerica> b = new List<ClsGenerica>();

            foreach (beSysUsuarios item in lstUsuarios)
            {
                ClsGenerica a = new ClsGenerica();
                a.id = item.IdUsuario;
                a.string1 = item.Usuario;
                var f = persona(item.IdPersona);
                a.string2 = f.Nombres + " " + f.Apellidos;
                a.string3 = perfil(item.IdPerfil).Descripcion;
                a.string4 = item.Activo ? "Activo" : "Inactivo";
                var dependencia = getDependencias(item.IdDependencia as int? ?? default(int));
                a.string5 = dependencia.Dependencia == null ? "" : dependencia.Dependencia.Trim();
                var proveedor = getProveedor(item.IdProveedor as int? ?? default(int));
                a.string6 = proveedor.RazonSocial== null?"": proveedor.RazonSocial.Trim();
                b.Add(a);
            }
            return b;
        }
        protected beSysPerfiles perfil(int pIdPerfil)
        {
            beSysPerfiles a = new beSysPerfiles();
            brSysPerfiles b = new brSysPerfiles();
            a = b.traerSysPerfiles_x_IdPerfil(pIdPerfil);
            return a;
        }
        protected beDatosPersonas persona(int pIdPersona)
        {
            beDatosPersonas a = new beDatosPersonas();
            brDatosPersonas b = new brDatosPersonas();
            a = b.traerDatosPersonas_x_IdPersona(pIdPersona);
            return a;
        }
        public int addSysUsuario(beSysUsuarios pUsuario)
        {

            brSysUsuarios b = new brSysUsuarios();
            int a = b.guardarSysUsuarios(pUsuario);
            return a;
        }

        public int deleteUsuario(beSysUsuarios pUsuario)
        {
            brSysUsuarios b = new brSysUsuarios();
            int a = b.actualizarSysUsuarios(pUsuario);
            return a;
        }
        public beSysUsuarios getUsuario_x_IdUsuario(int pIdUsuario)
        {
            brSysUsuarios b = new brSysUsuarios();
            return b.traerSysUsuarios_x_IdUsuario(pIdUsuario);
            
        }
        public List<beSysUsuarios> Usuarios_Traer_IdPerfil(int IdPerfil)
        {
            brSysUsuarios b = new brSysUsuarios();
            return b.Usuarios_Traer_IdPerfil(IdPerfil);

        }
    }
}