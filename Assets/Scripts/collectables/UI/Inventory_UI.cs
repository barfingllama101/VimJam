using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Inventory_UI : MonoBehaviour
{
    collectable building;

    TurretPlacement player;

    // Start is called before the first frame update
    public void SetUp(int count, collectable collect)
    {
        building = collect;
        transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = building.sprite;
        transform.GetChild(1).GetComponent<Text>().text = building.objectName;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TurretPlacement>();

        //GetComponent<RectTransform>().localPosition = new Vector3(0, -200 * count + 500, 0);
    }

    bool beingDragged = false;
    private void Update()
    {
        if (beingDragged)
        {
            GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    public void startDrag()
    {
        beingDragged = true;
        transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
    }

    public void endDrag()
    {
        //Mouse has dragged to this point
        player.placeBuilding(building);
        Destroy(gameObject);
    }
}
