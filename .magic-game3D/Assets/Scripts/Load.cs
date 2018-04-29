using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MGLoader;
using APIMG;

public class Load : MonoBehaviour {
    void Awake()
    {
        DontDestroyOnLoad(this);
        Loader.CargarArchivos();
    }

    void Start()
    {
        Loader.callAtStart();
    }
    void Update()
    {
        Loader.callAtUpdate();
    }
}
