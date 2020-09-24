using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSimple : TurretBase
{
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (!LookAtTarget())
            return;

        if(timer > shootDelay)
        {
            timer = 0;
            shoot();
        }
    }
}
