using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMultProjectile : TurretBase
{
    float timer;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    int num;

    private void Update()
    {
        timer += Time.deltaTime;

        if (!LookAtTarget())
            return;

        if(timer > shootDelay)
        {
            timer = 0;

            for (int i = 0; i < num; i++)
            {
                Instantiate(projectile, transform.position, Quaternion.Euler(0,0,(360/num) * i));
            }
        }
    }
}
