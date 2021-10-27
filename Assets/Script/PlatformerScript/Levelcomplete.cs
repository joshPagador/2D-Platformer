using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelcomplete : MonoBehaviour {

    public GameObject levelCompleteCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject Controller2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelCompleteCanvas.SetActive(true);
            pauseMenuCanvas.SetActive(false); //disables escape button being pressed while levelcompleteCanvas is active
            Controller2D.SetActive(false); //disables fire bullet interaction from getbuttondown
            Time.timeScale = 0f;
        }
    }
}
