using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour {

    public List<Tipos> Elementos;
    

    void Update()
    {
        foreach(Tipos t in Elementos)
        {
           if(t.xp >= 100)
            {
                t.xp = 0;
                t.Lvl = t.Lvl+ 1; 
            } 
        }
    }

}
        [System.Serializable]
        public class Tipos
{
    public string Basicos;
    public bool aprendido;
    public Color color; [Range(0,1)]public float emision;
    public Material material;

    public float xp;

    public int price;
    public int Lvl;
    public int minlvl;
    public Button boton; 

    public void Ecolor() {
            
    }
}