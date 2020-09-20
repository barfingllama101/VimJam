using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollectable : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CollectableReader>())
        {
            Inventory.buildings.Add(other.gameObject.GetComponent<CollectableReader>().collectable);
            Debug.Log(other.gameObject.GetComponent<CollectableReader>().name);
        }
    }

}
