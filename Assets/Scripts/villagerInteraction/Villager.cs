﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// DONT LOOK AT ME IM UGLY :( 
/// </summary>
public class Villager : MonoBehaviour
{
    public Conversation convo;
    public Conversation PostConvo;
    private bool hasTalked = false;

    private bool inConvo = false;
    [SerializeField]
    int waveToAppear;
    bool appeared = true;
    private bool JANKY = false;
    [SerializeField]
    collectable gift = null;

    /// <summary>
    /// jumble up!
    /// </summary>
    void Start() {
        // you can do this because its [n,n)
       // int index = Random.Range(0, AssetList.availableCollectables.Count);
       // Debug.Log(gift.name);

        if(waveToAppear > 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            appeared = false;
        }

    }
 void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inConvo = true;
            if (!hasTalked)
            {
                DialogueManager.isTalking = true;
                DialogueManager.StartConversation(convo);
            }
            else if (hasTalked && !DialogueManager.Instance.canGive)
            {
     
                DialogueManager.isTalking = true;
                DialogueManager.StartConversation(PostConvo);
          
            }
        }

    }

    private void Update()
    {

        if (!hasTalked && inConvo && DialogueManager.Instance.canCheckGiveDirty)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<TurretPlacement>().add(gift);
            Debug.Log(gift.name);
            hasTalked = true;
            DialogueManager.isTalking = false;
            DialogueManager.Instance.canGive = false;
            DialogueManager.Instance.canCheckGiveDirty = false;
           
        }
        if(hasTalked && inConvo)
        {
            DialogueManager.isTalking = true;
            JANKY = true;
        }
        else if(hasTalked && JANKY)
        {
            DialogueManager.Instance.canCheckGiveDirty = false;
            JANKY = false;
        }
        else
        {
            JANKY = false;
        }
        if (!appeared && WaveManager.waveCounter >= waveToAppear)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    { 
        inConvo = false;
        DialogueManager.isTalking = false;
    }
   
}
