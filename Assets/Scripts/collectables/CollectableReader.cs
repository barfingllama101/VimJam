using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableReader : MonoBehaviour
{
    public collectable collectable;

    public string name;
    public int damage; 
    // Start is called before the first frame update
    void Start()
    {
        name = collectable.objectName;
        damage = collectable.damage;
    }

   
}
