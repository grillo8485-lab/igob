using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using SoftHomeDeco.Entidades;
using SoftHomeDeco.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace IGOB.Models
{
    public class ClsLogin
    {
        protected string username = string.Empty;
        protected string password = string.Empty;
        public ClsLogin(string _username, string _password)
        {
            username = _username.Trim();
            password = _password.Trim();
            password = EncodeMd5(_password.Trim());
        }
        public ClsLogin()
        {

        }
        public beSysUsuarios getUsuario_x_Usuario()
        {
            return findUsuario();
        }
        protected beSysUsuarios findUsuario()
        {
            beSysUsuarios usuario = new beSysUsuarios();
            brSysUsuarios brUsuario = new brSysUsuarios();
            usuario = brUsuario.traerSysUsuario_x_Usuario_X_Password(username.Trim());
            return usuario;
        }
        public beSysUsuarios searchUsuario_x_Usuario()
        {
            return findUsuario();
        }
        protected beSysUsuarios findPassword()
        {
            beSysUsuarios usuario = new beSysUsuarios();
            brSysUsuarios brUsuario = new brSysUsuarios();
            usuario = brUsuario.traerSysUsuario_x_Usuario_X_Password(username.Trim(), password.Trim());
            return usuario;
        }
        protected beSysPerfiles getPerfil(int IdPerfil)
        {
            beSysPerfiles perfil = new beSysPerfiles();
            brSysPerfiles brPerfil = new brSysPerfiles();
            perfil = brPerfil.traerSysPerfiles_x_IdPerfil(IdPerfil);
            return perfil;
        }
        protected beGobierno getGobierno(int IdDependencia, int Gobierno = 0)
        {
            brDependencias brPerfil = new brDependencias();
            brGobierno c = new brGobierno();
            if (Gobierno == 0)
            {

                var a = brPerfil.traerDependencias_x_IdDependencia(IdDependencia);
                return c.traerGobierno_x_IdGobierno(a.IdGobierno);
            }
            else
            {
                return c.traerGobierno_x_IdGobierno(Gobierno);
            }

        }
        protected beDependencias getDependencia(int pIdDependencia)
        {
            brDependencias d = new brDependencias();
            return d.traerDependencias_x_IdDependencia(pIdDependencia);
        }
        protected beProveedores getProveedores(int pIdProveedores)
        {
            return (new brProveedores()).traerProveedores_x_IdProveedor(pIdProveedores);
        }
        public ClsGenerica getAcceso()
        {
            var modoDebug = Convert.ToBoolean(ConfigurationManager.AppSettings["ModoDebug"].ToString());
            ClsGenerica a = new ClsGenerica();
            a.id7 = 0;
            var buscar = findUsuario();
            if (buscar.Usuario == null)
            {
                a.string1 = "<span class='fa fa-exclamation-triangle fa-1x'></span>Usuario <strong>" + this.username + "</strong> no existe, favor de verificar";
                a.bool2 = false;
                a.id7 = 1;
                return a;
            }
            if (!buscar.Activo)
            {
                a.string1 = "<span class='fa fa-exclamation-triangle fa-1x'></span>Usuario <strong>" + this.username + "</strong> no esta activo, favor de verificar";
                a.bool2 = false;
                a.id7 = 2;
                return a;
            }
            if (!modoDebug)
            {
                if (buscar.NoToken.Trim() == "0" || buscar.NoToken.Trim() == "")
                {
                    a.string1 = "<span class='fa fa-exclamation-triangle fa-1x'></span>Usuario <strong>" + this.username + "</strong>, no tiene asignado token favor de verificar con el adminsitrador.";
                    a.bool2 = false;
                    a.id7 = 3;
                    return a;
                }
                if (buscar.LlaveAcceso.Trim() != "")
                {
                    a.string1 = "<span class='fa fa-exclamation-triangle fa-1x'></span>Usuario <strong>" + this.username + "</strong> está ocupada en otra sesión.";
                    a.bool2 = false;
                    a.id7 = 4;
                    a.string5 = username;
                    return a;
                }
            }


            var pass = findPassword();
            if (pass.Usuario == null)
            {
                a.string1 = "<span class='fa fa-exclamation-triangle fa-1x'></span>Usuario <strong>" + this.username + "</strong>, contraseña no coincide, favor de verificar.";
                a.bool2 = false;
                a.id7 = 5;
                return a;
            }
            var d = new beGobierno();
            var persona = getDatosPersonas(pass.IdPersona);
            a.string1 = persona.Nombres.Trim().ToUpper() + " " + persona.Apellidos.Trim().ToUpper();
            a.id = pass.IdPerfil;
            a.id2 = pass.IdUsuario;
            a.id3 = pass.IdPersona;
            a.id4 = pass.IdDependencia;
            a.bool2 = true;
            a.string2 = getPerfil(pass.IdPerfil).Descripcion;

            

            a.id6 = pass.IdProveedor;

            int result = 0;

            if (int.TryParse(pass.IdDependencia.ToString(), out result) && pass.IdDependencia != 0)
            {
                var fDependencia = getDependencia(pass.IdDependencia);
                a.string4 = fDependencia.Dependencia.Trim();
                d = getGobierno(fDependencia.IdDependencia);
                a.string3 = d.Gobierno;
            }
            else
            {
                var proveedor = getProveedores(pass.IdProveedor);
                a.string4 = proveedor.RazonSocial.Trim();
                d = getGobierno(0, proveedor.IdGobierno);
                a.string3 = d.Gobierno;
            }

            a.id5 = d.IdGobierno;
            a.string5 = username;
            a.string6 = EncodeMd5(pass.NoToken.Trim());
            a.string7 = pass.NoToken.Trim();
            a.string9 = Guid.NewGuid().ToString();
            a.string8 = GetKeyAccesoCookie(a.string9);           
            return a;
        }


        public string getKeyAcceso(string str)
        {
            return EncodeMd5(str);
        }
        protected string EncodeSha1(string str)
        {
            byte[] results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            var HashProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(password));

            var TDESAlgorithm = new System.Security.Cryptography.TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = System.Security.Cryptography.CipherMode.ECB;
            TDESAlgorithm.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            byte[] dataToEncrypt = UTF8.GetBytes(str + "iGob");

            try
            {
                var encryptor = TDESAlgorithm.CreateEncryptor();
                results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return Convert.ToBase64String(results);
        }
        private string DecryptdataSh256(string str)
        {
            byte[] results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            var hashProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] tdesKey = hashProvider.ComputeHash(UTF8.GetBytes(password));

            var tdesAlgorithm = new System.Security.Cryptography.TripleDESCryptoServiceProvider();

            tdesAlgorithm.Key = tdesKey;
            tdesAlgorithm.Mode = System.Security.Cryptography.CipherMode.ECB;
            tdesAlgorithm.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            byte[] dataToDecrypt = Convert.FromBase64String(str);

            try
            {
                System.Security.Cryptography.ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor();
                results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }

            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }

            return UTF8.GetString(results);
        }


        protected string EncodeMd5(string message)
        {
            string passphrase = "A!9HHhi%XjjYY4YP2@Nob009X";
            byte[] results;
            UTF8Encoding utf8 = new UTF8Encoding();
            //to create the object for UTF8Encoding  class
            //TO create the object for MD5CryptoServiceProvider 
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] deskey = md5.ComputeHash(utf8.GetBytes(passphrase));
            //to convert to binary passkey
            //TO create the object for  TripleDESCryptoServiceProvider 
            TripleDESCryptoServiceProvider desalg = new TripleDESCryptoServiceProvider();
            desalg.Key = deskey;//to  pass encode key
            desalg.Mode = CipherMode.ECB;
            desalg.Padding = PaddingMode.PKCS7;
            byte[] encrypt_data = utf8.GetBytes(message);
            //to convert the string to utf encoding binary 

            try
            {


                //To transform the utf binary code to md5 encrypt    
                ICryptoTransform encryptor = desalg.CreateEncryptor();
                results = encryptor.TransformFinalBlock(encrypt_data, 0, encrypt_data.Length);

            }
            finally
            {
                //to clear the allocated memory
                desalg.Clear();
                md5.Clear();
            }
            //to convert to 64 bit string from converted md5 algorithm binary code
            return Convert.ToBase64String(results);

        }

        public string DecryptMD5(string message)
        {
            string passphrase = "A!9HHhi%XjjYY4YP2@Nob009X";
            byte[] results;
            UTF8Encoding utf8 = new UTF8Encoding();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] deskey = md5.ComputeHash(utf8.GetBytes(passphrase));
            TripleDESCryptoServiceProvider desalg = new TripleDESCryptoServiceProvider();
            desalg.Key = deskey;
            desalg.Mode = CipherMode.ECB;
            desalg.Padding = PaddingMode.PKCS7;
            byte[] decrypt_data = Convert.FromBase64String(message);
            try
            {
                //To transform the utf binary code to md5 decrypt
                ICryptoTransform decryptor = desalg.CreateDecryptor();
                results = decryptor.TransformFinalBlock(decrypt_data, 0, decrypt_data.Length);
            }
            finally
            {
                desalg.Clear();
                md5.Clear();
            }
            //TO convert decrypted binery code to string
            return utf8.GetString(results);
        }
        public void bitacoraAcceso(int idUsuario, bool acceso, string llaveAcceso)
        {
            beSysBitacoraAcceso bitacoraAcceso = new beSysBitacoraAcceso();
            bitacoraAcceso.IdAcceso = 0;
            bitacoraAcceso.IdUsuario = idUsuario;
            bitacoraAcceso.Acceso = acceso;
            bitacoraAcceso.Fecha = DateTime.Now;
            bitacoraAcceso.LlaveAcceso = llaveAcceso;
            brSysBitacoraAcceso brBitacoraAcceso = new brSysBitacoraAcceso();
            brBitacoraAcceso.guardarSysBitacoraAcceso(bitacoraAcceso);
        }

        public void cerrarSecision(int idUsuario, bool acceso, string llaveAcceso)
        {
            bitacoraAcceso(idUsuario, acceso, llaveAcceso);
        }
        public beSysBitacoraAcceso getBitacora_x_LlaveAcceso(string llaveAcceso)
        {
            //beSysBitacoraAcceso traerSysBitacoraAcceso_x_LlaveAcceso
            return (new brSysBitacoraAcceso()).traerSysBitacoraAcceso_x_LlaveAcceso(llaveAcceso);
        }
        public string getPassword()
        {
            return password;
        }
        public string GetKeyAccesoCookie(string key)
        {
            //string key = Guid.NewGuid().ToString();
            return EncodeMd5(EncodeSha1(key));
        }
        public beSysUsuarios getUsuario_x_IdUsuario(int IdUsuario)
        {
            beSysUsuarios usuario = new beSysUsuarios();
            brSysUsuarios brUsuario = new brSysUsuarios();
            usuario = brUsuario.traerSysUsuarios_x_IdUsuario(IdUsuario);
            return usuario;
        }
        public int saveEditUsuarioLlave(beSysUsuarios oUsuario)
        {
            int usuario = 0;
            brSysUsuarios brUsuario = new brSysUsuarios();
            usuario = brUsuario.actualizarSysUsuarios(oUsuario);
            return usuario;
        }
        public beTokenHistorial getToken(string token)
        {
            return (new brTokenHistorial()).traerTokenHistorial_x_Token(token);
        }
        public int saveToken(beTokenHistorial ptoken)
        {
            return (new brTokenHistorial()).guardarTokenHistorial(ptoken);
        }

        public beDatosPersonas getDatosPersonas(int pIdpErsona)
        {
            return (new brDatosPersonas()).traerDatosPersonas_x_IdPersona(pIdpErsona);
        }
        public beAcceso leerArchivo(string urlPadre)
        {
            var accesoSistema = new beAcceso();
            string fichero = urlPadre + "\\bomba.txt";
            string contenido = String.Empty;

            if (File.Exists(fichero))
            {
                //Abrir el archivo, recuperar filas y cerrar el archivo
                string[] rows = File.ReadAllLines(@fichero, Encoding.Default);
                if (rows.Length > 1)
                {
                    accesoSistema.FechaAcceso = rows[0];
                    accesoSistema.FechaAccesoTotal = rows[1];
                    accesoSistema.result= 0;
                }
                else
                {
                    accesoSistema.result = 1;
                }
               
            }
            else
            {
                accesoSistema.result = 2;
            }
            return accesoSistema;
        }
        protected beAcceso getAccesoDb()
        {
            return (new brAcceso()).listarTodos_Acceso().FirstOrDefault();
        }
        public beAcceso leerAccesoDb()
        {
            var accesoSistema = new beAcceso();
            accesoSistema = this.getAccesoDb();
            if (accesoSistema != null)
            {
                accesoSistema.result = 0;

            }
            else
            {
                accesoSistema = new beAcceso();
                accesoSistema.result= 1;
            }
            return accesoSistema;
        }
        public int comprarCadenas(beAcceso archivo, beAcceso bd, beAcceso sistema)
        {
            int result = 0;
            if(archivo.FechaAcceso == bd.FechaAcceso)
            {
                if (archivo.FechaAccesoTotal.Trim() == bd.FechaAccesoTotal.Trim())
                {
                    result = 0;
                }
                else
                {
                    result =1;
                }
            }
            else
            {
                result =1;
            }
            if(result == 0)
            {
                if (archivo.FechaAccesoTotal == sistema.FechaAccesoTotal)
                {
                    if (archivo.FechaAccesoTotal == sistema.FechaAccesoTotal)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = 1;
                    }
                }
                else
                {
                    result = 1;
                }
            }

            if (result == 0)
            {
                var fechaActualSistema = DateTime.Parse(DateTime.Now.ToShortDateString());
                var fechaActualDb = DateTime.Parse(this.DecryptMD5(sistema.FechaAccesoTotal));

                if (fechaActualSistema < fechaActualDb)
                {
                    result = 0;
                }
                else
                {
                    result = 1;
                }
            }
            return result;
        }
    }
}