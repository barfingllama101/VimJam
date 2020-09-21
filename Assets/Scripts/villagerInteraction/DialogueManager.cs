using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName, dialogue, nextBTN;
    public Image speakerSprite;
    private static DialogueManager instance;
    private int currentIndex;
    private Conversation currConvo;
    public bool canGive = false;

    private Coroutine typing;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static DialogueManager Instance
    {
        get { return instance; }
    }
    public static void StartConversation(Conversation conversation)
    {
        instance.currentIndex =  0;
        instance.currConvo = conversation;
        instance.speakerName.text = "";
        instance.dialogue.text = "";
        instance.nextBTN.text = ">";

        instance.readNext();
    }
    public void readNext()
    {

        if (currentIndex > currConvo.getLength())
        {
            return;
        }
        if(currentIndex == currConvo.getLength())
        {
            instance.canGive = true;
        }
        speakerName.text= currConvo.GetLineByIndex(currentIndex).villager.GetName();
        if (typing == null)
        {
          
            typing = instance.StartCoroutine(Type(currConvo.GetLineByIndex(currentIndex).dialogue));

        }
        else{
           
            instance.StopCoroutine(typing);
            typing = null;
            typing = instance.StartCoroutine(Type(currConvo.GetLineByIndex(currentIndex).dialogue));

        }
        speakerSprite.sprite = currConvo.GetLineByIndex(currentIndex).villager.GetSprite();
        currentIndex++;
    }
    // Start is called before the first frame update
    private IEnumerator Type(string text)
    {
        dialogue.text = "";
        bool complete = false;
        int index = 0;
        while(!complete){
            dialogue.text += text[index];
            index++;
            yield return new WaitForSeconds(0.02f);
            if(index == text.Length/* - 1*/)
            {
               
                complete = true;
            }
        }
        typing = null;
    }
}
