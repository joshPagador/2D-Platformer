using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    Vector2 cDir;
    bool jump;
    Rigidbody2D cRB;
    int groundLayer, enemyLayer;
    RaycastHit2D grounded, enemySquish;
    public Transform groundCheck;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float speed = 3f;
	public float jumpForce = 400f;
    public float bulletSpeed = 5f;
	bool facingRight = true;
    Info inf; 
   

    // Use this for initialization
    void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");
        enemyLayer = LayerMask.GetMask("Enemy");
        inf = GetComponent<Info>();
        cRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cDir.x = Input.GetAxis("Horizontal") * speed;

		if (cDir.x < 0f && facingRight) {
			facingRight = false;
			transform.localScale = new Vector3 (-1f, 1f, 1f);

		} else if (cDir.x > 0f && !facingRight) {
			facingRight = true;
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            if(inf.bulletsLeft > 0)
            {
                inf.UpdateBullets(-1);
                GameObject newBullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
                if (facingRight)
                {
                    newBullet.GetComponent<Bullet>().dir = new Vector2(bulletSpeed, 0f);
                }
                else
                {
                    newBullet.GetComponent<Bullet>().dir = new Vector2(bulletSpeed * -1, 0f);
                }
            }
        }
          
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.CircleCast(groundCheck.position, 0.2f, Vector2.down, 0f, groundLayer);
        enemySquish = Physics2D.CircleCast(groundCheck.position, 0.2f, Vector2.down, 0f, enemyLayer);
        if (jump)
        {
            if (grounded)
            {
				cRB.AddForce(new Vector2(0f, jumpForce));
            }
        }

        if (enemySquish)
        {
			cRB.AddForce(new Vector2(0f, jumpForce));
            GameObject thisEnemy = enemySquish.collider.gameObject;
            thisEnemy.GetComponent<Enemy>().BeenHit();


        }

            jump = false;

            cDir.y = cRB.velocity.y;
            cRB.velocity = cDir;
        }

        private void OnDrawGizmos()
    {
            Gizmos.DrawSphere(groundCheck.position, 0.2f);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy") 
		{
			GetComponent<Info> ().DeathReset ();
		}
	}
}

