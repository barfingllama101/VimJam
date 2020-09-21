using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplayTMP;
    public static List<string> sentences;
    public static int index = 0;
    public float typingSpeed;
    public static bool isTalking = false;
    public GameObject continueButton;

    public static bool check = false;
    IEnumerator Type()
    {
        if (isTalking)
        {
            foreach (char letter in sentences[index].ToCharArray())
            {
              
                textDisplayTMP.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        yield return null;
    }

    //link to gotdam button 
    public void NextSentence()
    {
        //continueButton.SetActive(false);
        if(index < sentences.Count - 1)
        {
            
            StartCoroutine(Type());
            index++;
        }
        else if(index == sentences.Count - 1)
        {
           
            textDisplayTMP.text = "";
            check = true;
            StartCoroutine(Type());
            
        }
        else
        {
            textDisplayTMP.text = "";
            continueButton.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            if (textDisplayTMP.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
        }
        
    }
}
