using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    public Vector3[] nodes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            Gizmos.DrawSphere(nodes[i], .5f);

            if(i > 0)
                Gizmos.DrawLine(nodes[i], nodes[i - 1]);
        }
    }
}
