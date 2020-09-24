using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : TurretBase
{
    float timer;

    [SerializeField]
    GameObject projectile;

    private void Update()
    {
        timer += Time.deltaTime;

        if (!LookAtTarget())
            return;

        if(timer > shootDelay)
        {
            timer = 0;

            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}
