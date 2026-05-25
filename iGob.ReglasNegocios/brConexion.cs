using System;
using System.Configuration;

namespace iGob.ReglasNegocios
{
    public class brConexion
    {
        public string CadenaConexion { get; set; }
        //atributos
        public string servidor = "192.168.100.4";
        public string usuario = "UseriGob";
        public string password = "DataiGob18";
        public string baseDeDatos = "db_iGob";
        public brConexion()
       {
          CadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
          getData();
          
       }

        public void getData()
        {
            string[] sC = CadenaConexion.Split(';');
            foreach (String s in sC)
            {

                //separamos por el simbolo = para obtener el campo y el valor
                string[] spliter = s.Split('=');
                //comparamos los valores
                switch (spliter[0].ToUpper())
                {

                    case "DATA SOURCE":
                        servidor = spliter[1];
                        break;
                    case "USER ID":
                        usuario = spliter[1];
                        break;
                    case "PASSWORD":
                        password = spliter[1];
                        break;
                    case "INITIAL CATALOG":
                        baseDeDatos = spliter[1];
                        break;

                }
            }

        }

    }
}
