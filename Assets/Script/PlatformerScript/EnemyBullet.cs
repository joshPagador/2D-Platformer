using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public Vector2 dir;
    Rigidbody2D rb;
    public bool harmPlayer;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //gets rigidbody2D components
        Destroy(gameObject, 2.3f); //destroys the game object after 2.3 seconds
    }

    void FixedUpdate()
    {
        transform.Translate(-0.1f, 0f, 0f); //changes direction to the left --> shoots to the left (x axis)
        rb.velocity = dir; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && harmPlayer)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Info>().DeathReset();
        } // if bullet collides with a gameobject that is tagged as player, gets component deathreset within the Info(script)
    }
}
