using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public Conversation convo;
    public Conversation PostConvo;
    collectable gift = null;
    private bool hasTalked = false;

    private bool inConvo = false;

    /// <summary>
    /// jumble up!
    /// </summary>
    void Start() {
        // you can do this because its [n,n)
        int index = Random.Range(0, AssetList.availableCollectables.Count);
        gift = AssetList.availableCollectables[index];
        Dialogue.index = 0;
        Debug.Log(gift.name);

    }
 void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inConvo = true;
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

    private void Update()
    {
        if (!hasTalked && inConvo && DialogueManager.Instance.canGive)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<TurretPlacement>().add(gift);
            Debug.Log(gift.name);
            hasTalked = true;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {

        inConvo = false;
        DialogueManager.isTalking = false;
 
    }
   
}
