﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    collectable gift = null;
    public List<string> dialogue;

    //if player has conversed wiht this villager, this will be true. 
    bool conversed = false;

    /// <summary>
    /// jumble up!
    /// </summary>
    void Start() {
        // you can do this because its [n,n)
        int index = Random.Range(0, AssetList.availableCollectables.Count);
        gift = AssetList.availableCollectables[0];
    
    }
 void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Dialogue.isTalking = true;
            Dialogue.sentences = dialogue;
            if (!conversed)
            {
                Inventory.buildings.Add(gift);
                Debug.Log(gift.objectName);
                conversed = true;
            }
        }
    }

   
}
