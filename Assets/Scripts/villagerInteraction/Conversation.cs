#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Conversation : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] private DialogueLine[] allLines;
    public DialogueLine GetLineByIndex(int index)
    {
        return allLines[index];
    }
    public int getLength()
    {
        return allLines.Length - 1;
    }
   
}
