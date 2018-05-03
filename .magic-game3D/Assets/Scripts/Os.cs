using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Os : MonoBehaviour {

	
	void Start () {
        Debug.Log(SystemInfo.batteryStatus);//muestra si esta cargando o esta desconectado
        Debug.Log(SystemInfo.systemMemorySize); //memoria de ram           int
        Debug.Log(SystemInfo.graphicsMemorySize + " mb " + SystemInfo.graphicsDeviceName);//memoria de grafica.. int

        Debug.Log("<color=blue>Pantallas conectadas: </color><color=red>" + Display.displays.Length + "</color>");
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();

    }
	
	// Update is called once per frame
	void Update () {
        //Handheld.Vibrate();                   //testin vibration on the cellphone android and ios..
	}
    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 30, 30), SystemInfo.batteryLevel.ToString());
    }
}
