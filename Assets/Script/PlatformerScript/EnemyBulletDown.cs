using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDown : MonoBehaviour {

    public Vector2 dir;
    Rigidbody2D rb;
    public bool harmPlayer;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
    }

    void FixedUpdate()
    {
        transform.Translate(0f, -0.1f, 0f); //changes direction of bullet on the y axis (shoots down)
        rb.velocity = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && harmPlayer)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Info>().DeathReset();
        }// if bullet collides with a gameobject that is tagged as player, gets component deathreset within the Info(script)
    }
}
