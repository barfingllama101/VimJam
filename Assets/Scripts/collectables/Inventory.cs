using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static List<collectable> buildings = new List<collectable>();
    public static void printInventory()
    {
        foreach(collectable c in buildings)
        {
            Debug.Log(c.objectName);
        }
    }
   
}
