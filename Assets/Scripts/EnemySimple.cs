using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimple : EnemyBase
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }


    private void FixedUpdate()
    {
        switch (currentState)
        {
            case state.MOVING:
                moveToCurrentNode();
                if (distFromCurrentNode() < .2f)
                {
                    currentNode++;
                    if (currentNode >= path.nodes.Length)
                    {
                        currentState = state.ATTACKING;
                        rb.velocity = Vector2.zero;
                    }
                }
                break;
            case state.ATTACKING:
                print("Do damage to wall or smth lol I haven't implemented this");
                break;
        }

    }
}
