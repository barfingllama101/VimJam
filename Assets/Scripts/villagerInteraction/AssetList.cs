﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetList : MonoBehaviour
{
    public static List<collectable> availableCollectables;
    // Start is called before the first frame update
    void Awake()
    {
        availableCollectables = new List<collectable>();
        Object[] availableObjects = Resources.LoadAll("ourCollectables");
        Debug.Log(availableObjects.Length);
        foreach (var x in availableObjects)
        {
            collectable i = x as collectable;
            availableCollectables.Add(i);
        }
        print(availableCollectables.Count);
    }
}
