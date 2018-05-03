using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Os : MonoBehaviour {

	
	void Start () {
        Debug.Log(SystemInfo.batteryStatus);//muestra si esta cargando o esta desconectado
        Debug.Log(SystemInfo.systemMemorySize); //memoria de ram           int
        Debug.Log(SystemInfo.graphicsMemorySize + " mb " + SystemInfo.graphicsDeviceName);//memoria de grafica.. int
    }
	
	// Update is called once per frame
	void Update () {
        Handheld.Vibrate();
	}
    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 30, 30), SystemInfo.batteryLevel.ToString());
    }
}
