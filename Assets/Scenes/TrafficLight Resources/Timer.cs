using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timeLeft;
    public float countDownTime;
    public Text timerText;
    public Material greenMat, redMat, yellowMat, offMat;
    public GameObject redLight, yellowLight, greenLight;
    private Renderer redRend, yellowRend, greenRend;
    private bool buttonPressed;
    private bool bRed;
    private bool bYellow;
    private bool bGreen;

    // Use this for initialization
    private void Start()
    {
        // Setting the Timer Text to zero
        timerText.text = "0";

        // getting the renderer components for each light
        redRend = redLight.GetComponent<Renderer>();
        yellowRend = yellowLight.GetComponent<Renderer>();
        greenRend = greenLight.GetComponent<Renderer>();
        greenRend.material = greenMat;
        redRend.material = offMat;
        yellowRend.material = offMat;

    }

    private void Update()
    {
        // Update Text
        timerText.text = timeLeft.ToString();

        if (timeLeft > 0)
        {
            setLights();
            bGreen = true;
            bYellow = false;
            bRed = false;
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft < 20)
        {
            bRed = false;
            bYellow = true;
            bGreen = false;
        }
        if (timeLeft < 15)
        {
            bRed = true;
            bYellow = false;
            bGreen = false;
        }
        if (timeLeft < 5)
        {
            bRed = true;
            bYellow = true;
            bGreen = false;
        }
        if (timeLeft < 4)
        {
            bRed = true;
            bYellow = false;
            bGreen = false;
        }
        if (timeLeft < 3)
        {
            bRed = true;
            bYellow = true;
            bGreen = false;
        }
        if (timeLeft < 2)
        {
            bRed = true;
            bYellow = false;
            bGreen = false;
        }
        if (timeLeft < 1)
        {
            bRed = false;
            bYellow = false;
            bGreen = true;
        }
        if (timeLeft < 0)
        {
            bRed = false;
            bYellow = false;
            bGreen = true;
            buttonPressed = false; //resets button timer
            timerText.text = "0"; //sets time to 0 after reaching 0 rather than a float
        }

    }

    // Function called when the button is pressed
    public void startTimer()
    {
        if (!buttonPressed)
        {

            timeLeft = countDownTime;
            buttonPressed = true;
        }
    }

    void setLights() //function used to call to render in the the light materials if true or false to change the state of the lights between each time interval
    {
        if (bRed)
        {
            redRend.material = redMat;
        }
        else
        {
            redRend.material = offMat;
        }

        if (bYellow)
        {
            yellowRend.material = yellowMat;
        }
        else
        {
            yellowRend.material = offMat;
        }

        if (bGreen)
        {
            greenRend.material = greenMat;
        }
        else
        {
            greenRend.material = offMat;
        }
    }
}