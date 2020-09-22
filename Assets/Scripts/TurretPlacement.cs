using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [SerializeField]
    TilemapCollider2D prohibitedArea;

    [SerializeField]
    Transform content;

    [SerializeField]
    GameObject UIElement;

    //public collectable buildings;

    // Update is called once per frame
    void Update()
    {
        /*
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
        */
    }

    public void placeBuilding(collectable building)
    {
        if (Inventory.buildings.Contains(building))
        {
            Vector3 spawnPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            if (!prohibitedArea.OverlapPoint(spawnPos))
            {
                Instantiate(building.building, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);

                Inventory.buildings.Remove(building);

                building = null;
            }
        }
        else
        {
            Debug.Log("ERROR: This shouldn't be happening! Something's wrong! panic! AAAAA!");
        }
    }

    //Test function
    public void add(collectable building)
    {
        Inventory.buildings.Add(building);
        Inventory_UI ui = Instantiate(UIElement, content).GetComponent<Inventory_UI>();
        ui.SetUp(Inventory.buildings.Count, building);
    }

}
