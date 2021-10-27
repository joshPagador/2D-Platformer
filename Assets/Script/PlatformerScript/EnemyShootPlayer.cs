using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootPlayer : MonoBehaviour {

    public GameObject Ebullet;
    public Transform EnemyBulletSpawn;
    public float fireRate;
    private float reloadCounter;
    public int point = 10;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > reloadCounter)
        {
            reloadCounter = Time.time + fireRate;
            Instantiate(Ebullet, EnemyBulletSpawn.position, Quaternion.identity); //function to create multple instances of gameobject, ebullet=object to be instantiated(cloned)
        }
    }

    public void BeenHit()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Info>().UpdateScore(point);
        Destroy(gameObject);
    }
}
