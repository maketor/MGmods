using System.Reflection;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;



///<summary>hi.</summary>  
namespace MGLoader
{
    public delegate void MGStart();   //al iniciar
    public delegate void MGUpdate();    //mientras ejecuta
    ///<summary>Lectura y creacion de la carpeta con system.io y system.reflection</summary>                                                
    public static class Loader
    {                
        /// <summary>inician los delegados</summary>
        public static MGStart callAtStart; 
        ///<summary>ejecutando los delegados</summary>
        public static MGUpdate callAtUpdate;   

          public static string _Path_ = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\3DMagicGame\\" + "\\Mods\\";//direccion carpeta de contenidos externos . 
        
          
        public static void CargarArchivos()
        {
            if (!Directory.Exists(_Path_))
            {
                DirectoryInfo di = Directory.CreateDirectory(_Path_); //crea carpeta
            }
            else
            {
                foreach (var ss in Directory.GetFiles(_Path_, "*.dll"))     //bucle de carga de los contenidos dentro con terminacion .dll
                {
                    Assembly current = Assembly.LoadFile(ss);
                    Type type = current.GetType("Plugin.MGmod"); //plugin como namespace y kmod como class

                    type.GetMethod("Load").Invoke(Activator.CreateInstance(type), null);//cargamos la funcion Load dentro del mod que se añada.
                }
            }
        }    
    }

    public class VersionMG
    {
        string version = "0.0.1a";
        public string Version { get => version; set => version = value; }
    }
}
