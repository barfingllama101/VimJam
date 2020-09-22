using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [SerializeField]
    TilemapCollider2D prohibitedArea;

    public collectable buildings;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Inventory.buildings.Contains(buildings))
            {
                Vector3 spawnPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
                if (!prohibitedArea.OverlapPoint(spawnPos))
                {
                    Instantiate(buildings.building, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);

                    Inventory.buildings.Remove(buildings);
                }
            }
        }
    }

    public void setActiveBuilding(collectable building)
    {
        buildings = building;
    }

    //Test function
    public void add(collectable building)
    {
        Inventory.buildings.Add(building);
    }

}
