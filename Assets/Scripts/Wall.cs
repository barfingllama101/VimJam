using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("Lose");
        }
    }
}
