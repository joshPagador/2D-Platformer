using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour {

    public int score = 0, lives = 3, bulletsLeft = 20;
    Vector3 lastCheckPoint;
    public Image[] hearts;
    public GameObject gameOverPanel;
    public Text bulletsText, scoreText;
    
	void Start() 

	{
        
        lastCheckPoint = transform.position;
        UpdateLives(0);
        UpdateBullets(0);
    }

    public void DeathReset()
    {
        transform.position = lastCheckPoint;
        UpdateLives(-1);
    }

    public void UpdateCheckpoint()
    {
        lastCheckPoint = transform.position;
    }

    public void UpdateLives(int l)
    {
        lives += l;
        if(lives > 5)
        {
            lives = 5;
        }
        for (int i = 0; i < 5; i++)
        {
            if (i < lives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if(lives == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        GetComponent<Controller2D>().enabled = false;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy e in enemies)
        {
            e.enabled = false;
        }

        EnemyShootPlayer[] EnemyShootPlayer = FindObjectsOfType<EnemyShootPlayer>();
        foreach (EnemyShootPlayer esp in EnemyShootPlayer)
        {
            esp.enabled = false;
        }
    }

    public void UpdateScore(int s)
    {
        score += s;
        scoreText.text = score.ToString();
    }

    public void UpdateBullets(int b)
    {
        bulletsLeft += b;
        bulletsText.text = bulletsLeft.ToString();
    }
}
