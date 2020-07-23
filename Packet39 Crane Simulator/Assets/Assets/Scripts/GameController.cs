using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //For Motor on and off
    public GameObject CraneCab;
    public GameObject BoomSection1;
    public GameObject BoomSection2;
    public GameObject BoomSection4;
    public GameObject Head;
    public GameObject ItemForPickUp;

    //menus
    public GameObject startPanel;
    public GameObject mainPanel;
    public GameObject tutorialPanel;
   
    //objects on the mainmenu
    public Button pause;
    public Button restart;
    public Text timeText;
    public Slider boxSizeSlider;
    public Text mistakeDisplay;

    //objects on the tutorialmenu
    public Text leftfunction;
    public Text rightfunction;

    public Material mat1;
    public Material mat2;

    public GameObject joystickRight;
    public GameObject joystickLeft;

    private float timer;
    private bool paused;
    private int maxHeight;


    void Start()
    {
        turnMotorOff();
        paused = false;
        timer = 0.0f;
        maxHeight = 5;
        startPanel.gameObject.SetActive(true);
        mainPanel.gameObject.SetActive(false);
        tutorialPanel.gameObject.SetActive(false);
        leftfunction.gameObject.SetActive(false);
        rightfunction.gameObject.SetActive(false);
        pause.interactable = true;
        restart.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            timer += Time.deltaTime;
            int minute = (int)(timer / 60f);
            float second = (int)timer - minute * 60f;
            timeText.text = minute.ToString() + " minute, " + second.ToString() + " sec";
        }
    }

    public void changeBoxSize(float sizeScale)
    {
        Vector3 temp = ItemForPickUp.transform.localScale;
        temp.x = sizeScale;
        temp.z = sizeScale;
        ItemForPickUp.transform.localScale = temp;
    }
    public void turnMotorOff()
    {
        CraneCab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        Head.GetComponent<MovePulley>().enabled = false;
        BoomSection1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        BoomSection2.GetComponent<ExtensionArm>().enabled = false;

    }
    public void turnMotorOn()
    {
        CraneCab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Head.GetComponent<MovePulley>().enabled = true;
        BoomSection1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        BoomSection2.GetComponent<ExtensionArm>().enabled = true;
    }

    public void startButton()
    {
        timer = 0.0f;
        startPanel.gameObject.SetActive(false);
        mainPanel.gameObject.SetActive(true);
        turnMotorOn();
    }

    public void pauseButton()
    {
        turnMotorOff();
        paused = true;
        pause.interactable = false;
        restart.interactable = true;
    }

    public void restartButton()
    {
        turnMotorOn();
        paused = false;
        pause.interactable = true;
        restart.interactable = false;
    }
   
    public void tutorialBack(bool tutorialOn)
    {
        startPanel.gameObject.SetActive(!tutorialOn);
        tutorialPanel.gameObject.SetActive(tutorialOn);
        if (tutorialOn == false)
        {
            leftfunction.gameObject.SetActive(tutorialOn);
            rightfunction.gameObject.SetActive(tutorialOn);
        }
    }

    public void demoLeft(bool check)
    {
        leftfunction.gameObject.SetActive(check);
        if (check)
        {
            StartCoroutine(highlight(1));
        }
    }

    public void demoRight(bool check)
    {
        rightfunction.gameObject.SetActive(check);
        if (check)
        {
            StartCoroutine(highlight(0));
        }
    }

    IEnumerator highlight(int x)
    {
        if (x == 1)
        {
            joystickLeft.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat2);
        } else if (x == 0)
        {
            joystickRight.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat2);
        }
        yield return new WaitForSeconds(2f);
        joystickRight.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat1);
        joystickLeft.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat1);
    }

    public void TrainingSafetyCheck(float height)
    {
        float h = (int) height;
        if (h > maxHeight)
        {
            Debug.Log("Safety");
            mainPanel.gameObject.SetActive(false);
            mistakeDisplay.gameObject.SetActive(true);
            mistakeDisplay.text = "Height Dropped: " + h.ToString() + " > " + maxHeight.ToString() + " *OBJECT DAMAGED*";
            StartCoroutine(waitTime());
        }
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(8f);
        mistakeDisplay.gameObject.SetActive(false);
        mistakeDisplay.text = "";
        mainPanel.gameObject.SetActive(true);
    }

}
