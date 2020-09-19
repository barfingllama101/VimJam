using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject objectToSpawn;

    [SerializeField]
    EnemyPath path;

    int spawnNum = 5;

    float spawnInterval = .6f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startSpawning());
    }


    IEnumerator startSpawning()
    {
        for(int i = 0; i < spawnNum; i++)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity).GetComponent<EnemyBase>().path = path;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
