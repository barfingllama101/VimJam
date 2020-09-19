using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSimple : TurretBase
{
    float timer;

    private void Update()
    {
        LookAtTarget();

        timer += Time.deltaTime;
        if(timer > shootDelay)
        {
            timer = 0;
            shoot();
        }
    }
}
