using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 0;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal") * moveSpeed;
        float ver = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector2(hor, ver);

        anim.SetBool("IsMoving",(Mathf.Abs(hor) > 0 || Mathf.Abs(ver) > 0));

        spr.flipX = hor < 0;
    }
}





//AAAAAAAAAAAAAA I DON"T KNOW WHERE TO PUT HTIS
[System.Serializable]
public struct waveEnemy
{
    public GameObject enemyType;    //What type of enemy to spawn
    public int number;              //How many enemies to spawn
    public float interval;          //delay between each enemy spawn
    public float timeToAppear;     //When the enemy appears
}
