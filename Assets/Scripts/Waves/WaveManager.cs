using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{

    [SerializeField]
    Spawner[] spawners;

    [SerializeField]
    Waves[] waves;

    [SerializeField]
    Text text;

    public bool inWave = false;
    public int waveCounter = 0;

    int enemiesLeft;
    // Update is called once per frame
    void Update()
    {
        if (inWave)
        {
            //Check if spawners are done
            int numDone = 0;
            for (int i = 0; i < spawners.Length; i++)
            {
                if (spawners[i].isDone)
                    numDone++;
            }
            //If all spawners are done check if there are any enemies left
            if (numDone == spawners.Length)
            {
                enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
                if (enemiesLeft == 0)
                {
                    WaveEnd();
                }
            }
        }
    }

    //When the player is ready for a new wave
    public void PlayerReady()
    {
        if (inWave)
            return;

        text.text = "In Wave " + (waveCounter + 1);

        //Give spawners the proper wave info
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].wave = waves[waveCounter];
        }

        inWave = true;
        //Tell spawners to start spawning
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].startWave();
        }
    }


    void WaveEnd()
    {
        text.text = "Wave " + (waveCounter + 1) + " Complete!";

        inWave = false;
        waveCounter++;
        print("wave has ended");

        if(waveCounter > waves.Length)
        {
            //TODO: You beat all the waves!
        }
    }
}
