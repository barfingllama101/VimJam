using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public Conversation convo;
    public Conversation PostConvo;
    collectable gift = null;
    private bool hasTalked = false;

    /// <summary>
    /// jumble up!
    /// </summary>
    void Start() {
        // you can do this because its [n,n)
        int index = Random.Range(0, AssetList.availableCollectables.Count);
        gift = AssetList.availableCollectables[index];
        Dialogue.index = 0;
    
    }
 void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!hasTalked)
            {
                DialogueManager.StartConversation(convo);
            }
            else if (hasTalked && DialogueManager.Instance.canGive)
            {
                DialogueManager.StartConversation(PostConvo);
            }
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
           
        if (!hasTalked)
        {
            hasTalked = true;
            Debug.Log(gift.name);
            GameObject.FindGameObjectWithTag("Player").GetComponent<TurretPlacement>().add(gift);
            
            
        }
        DialogueManager.isTalking = false;
 
    }
   
}
