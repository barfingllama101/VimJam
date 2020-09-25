using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public Conversation convo;
    public Conversation PostConvo;
    private bool hasTalked = false;

    private bool inConvo = false;

    [SerializeField]
    int waveToAppear;
    bool appeared = true;

    [SerializeField]
    collectable gift = null;

    /// <summary>
    /// jumble up!
    /// </summary>
    void Start() {
        // you can do this because its [n,n)
        int index = Random.Range(0, AssetList.availableCollectables.Count);
        Dialogue.index = 0;
        Debug.Log(gift.name);

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
                DialogueManager.StartConversation(convo);
            }
            else if (hasTalked && !DialogueManager.Instance.canGive)
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
            DialogueManager.Instance.canGive = false;
        }


        if(!appeared && WaveManager.waveCounter >= waveToAppear)
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
