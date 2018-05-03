using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MGLoader;
using APIMG;

public class Load : MonoBehaviour {

    public bool CargarMods;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (CargarMods == true)
        {
            Loader.CargarArchivos();
        }
        else
        {
            Debug.Log("<color=red>Mods Desactivados</color>");
        }
    }
    
    void Start()
    {
        if(CargarMods == true)
        {
            Loader.Start();
        }        
    }
    void Update()
    {
        if (CargarMods == true)
        {
            Loader.Update();
        }        
    }

    void OnGUI()
    {
        if (CargarMods == true)
        {
            Loader.OnGUI();
        }
    }
}
/* 
if (CargarMods == true)
{

}
*/
