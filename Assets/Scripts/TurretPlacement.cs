using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TurretPlacement : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [SerializeField]
    GameObject turret;

    PolygonCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            if (col.OverlapPoint(spawnPos))
            {
                Instantiate(turret, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);

                //TODO: remove the placed object from the inventory
            }
        }
    }

    private void OnMouseDown()
    {
        
    }
}
