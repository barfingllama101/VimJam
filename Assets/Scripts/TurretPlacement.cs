using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [SerializeField]
    GameObject turret;

    [SerializeField]
    TilemapCollider2D prohibitedArea;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            if (!prohibitedArea.OverlapPoint(spawnPos))
            {
                Instantiate(turret, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);

                //TODO: remove the placed object from the inventory
            }
        }
    }
}
