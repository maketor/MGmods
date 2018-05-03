using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Reflection;

public class Nice{

    public static string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\3DMagicGame\\" + "\\Save\\";

    void Start()
    {
        if (Directory.Exists(_path) == false )
        {
            DirectoryInfo di = Directory.CreateDirectory(_path);
            
        }
    }

    void Update()
    {
        

    }
    public bool threed,stream;
    
   
}
