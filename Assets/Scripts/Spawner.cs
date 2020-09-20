using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Waves wave;
    public EnemyPath path;                //Path that spawned enemies will go to

    // Start is called before the first frame update
    void Start()
    {
    }

    public bool isDone = false;


    int phaseNum;
    int phasesComplete;
    public void startWave()
    {
        isDone = false;
        phasesComplete = 0;
        phaseNum = wave.enemies.Length;
        for (int i = 0; i < phaseNum; i++)
        {
            StartCoroutine(startSpawning(i));
        }
    }

    IEnumerator startSpawning(int num)
    {
        yield return new WaitForSeconds(wave.enemies[num].timeToAppear);

        GameObject objectToSpawn = wave.enemies[num].enemyType;
        objectToSpawn = wave.enemies[num].enemyType;
        int spawnNum = wave.enemies[num].number;
        float spawnInterval = wave.enemies[num].interval;

        for (int i = 0; i < spawnNum; i++)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity).GetComponent<EnemyBase>().path = path;
            yield return new WaitForSeconds(spawnInterval);
        }

        phasesComplete++;

        //Let the wavemanager know that this spawner has spawned everything!
        if(phasesComplete == phaseNum)
        {
            isDone = true;
        }
    }
}
