using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 0;

    int health;
    private void Start()
    {
        health = maxHealth;
    }

    public void damage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            //Loose condition
            print("Wall down! you suck lol");
        }
    }
}
