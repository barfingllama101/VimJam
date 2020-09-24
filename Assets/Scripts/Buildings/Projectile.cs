using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    [SerializeField]
    float damage;
    [SerializeField]
    float speed;

    Rigidbody2D rb;

    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed * transform.right;
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyBase>().health -= damage;
            Destroy(gameObject);
        }
    }
}
