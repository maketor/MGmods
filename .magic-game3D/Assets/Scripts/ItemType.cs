using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemType : ScriptableObject {

    public int ID;
    public float _Cost;
    public GameObject _Object;
    int stock ;
    public int maxstock;   
}

[CreateAssetMenu]
public class Recipes: ScriptableObject
{
    public GameObject[] input;
    public GameObject output;
}
