using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static List<collectable> buildings = new List<collectable>();

    void printInventory()
    {
        foreach(collectable c in buildings)
        {
            Debug.Log(c.objectName);
            Debug.Log(c.damage);
        }
    }
   
}
