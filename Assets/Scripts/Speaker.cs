#pragma warning disable 0649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Speaker : ScriptableObject
{
    [SerializeField]
    string[] sentences;
    [SerializeField]
    string speakerName;
    [SerializeField]
    Sprite speakerSprite;

    public string GetName()
    {
        return speakerName;
    }
    public Sprite GetSprite()
    {
        return speakerSprite;
    }
}
