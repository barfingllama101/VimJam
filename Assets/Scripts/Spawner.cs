using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    Waves wave;

    [SerializeField]
    public EnemyPath path;                //Path that spawned enemies will go to

    // Start is called before the first frame update
    void Start()
    {
        startWave();
    }

    void startWave()
    {
        for (int i = 0; i < wave.enemies.Length; i++)
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
    }
}
