using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName, dialogue, nextBTN;
    public Button nxt;
    public Image speakerSprite;
    private static DialogueManager instance;
    private int currentIndex;
    private Conversation currConvo;
    public bool canGive = false;
    public bool canCheckGiveDirty = false;

    [SerializeField]
    CanvasGroup cg;

    public static bool isTalking = false;

    private Coroutine typing;

    public Coroutine typetype
    {
        get { return typing; }
        set { typing = value; }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isTalking)
        {
            Debug.Log("it is");
            cg.alpha = 1;

        }
        else
        {
            cg.alpha = 0;
        }
    }
    public  TextMeshProUGUI btn
    {
        get { return nextBTN; }
    }

    public static DialogueManager Instance
    {
        get { return instance; }
    }
    public static void StartConversation(Conversation conversation)
    {
        isTalking = true;
        instance.currentIndex =  0;
        instance.currConvo = conversation;
        instance.speakerName.text = "";
        instance.dialogue.text = "";
        instance.nextBTN.text = ">";
        instance.readNext();
    }
    public void stopConvo() {
        Debug.Log("stop it");
    }
    public void readNext()
    {
        Debug.Log(instance.currentIndex);
        if (currentIndex > currConvo.getLength())
        {
            
            return;
        }
        if (currConvo.getLength() == 0)
        {
            nxt.gameObject.SetActive(false);
        }
        else
        {
            nxt.gameObject.SetActive(true);
        }
        if (currentIndex == currConvo.getLength())
        {
            instance.canCheckGiveDirty = true;
            nxt.gameObject.SetActive(false);
        }
        else
        {
            nxt.gameObject.SetActive(true);
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
            if(index == text.Length)
            {
               
                complete = true;
            }
        }
        typing = null;
    }
}
