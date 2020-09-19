using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    [SerializeField]
    public EnemyPath path;

    [SerializeField]
    protected float speed;

    [SerializeField]
    public float health;


    protected Rigidbody2D rb;
    protected int currentNode;

    protected enum state
    {
        MOVING,
        ATTACKING
    }
    protected state currentState = state.MOVING;

    private void Update()
    {
        if(health <= 0)
        {
            //TODO: Die and stuff
            Destroy(gameObject);
        }
    }

    protected int findNearestNode()
    {
        int closest = 0;
        float closestDist = 100;
        float dist;

        for (int i = 0; i < path.nodes.Length; i++)
        {
            dist = Vector3.Distance(path.nodes[i], transform.position);
            if (dist < closestDist)
            {
                closest = i;
                closestDist = dist;
            }
        }

        return closest;
    }

    protected float distFromCurrentNode()
    {
        return Vector3.Distance(transform.position, path.nodes[currentNode]);
    }

    protected void moveToCurrentNode()
    {
        Vector3 dir = (path.nodes[currentNode] - transform.position).normalized;

        rb.velocity = dir * speed;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x));
    }
}
