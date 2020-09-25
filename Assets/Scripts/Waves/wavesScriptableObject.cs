using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Waves : ScriptableObject
{
    public waveEnemy[] enemies;
}



[System.Serializable]
public struct waveEnemy
{
    public GameObject enemyType;    //What type of enemy to spawn
    public int number;              //How many enemies to spawn
    public float interval;          //delay between each enemy spawn
    public float timeToAppear;     //When the enemy appears
}
