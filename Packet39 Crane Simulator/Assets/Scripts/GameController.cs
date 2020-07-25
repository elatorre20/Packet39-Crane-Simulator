using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
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

    public AudioManager audio;

    //levers 
    public Material mat1; //material of the joystick
    public Material mat2; //highlight material
    public Material mat3; //material of the oil tank

    public GameObject BoomLever;
    public GameObject CabLever;
    public GameObject PulleyLever;
    public GameObject ArmLever;

    //timer 
    private float timer;
    private bool paused;
    private int maxHeight;

    //Motor on and off
    private bool motorOn; 


    void Start()
    {
        motorOn = false;
        paused = false;
        timer = 0.0f;
        maxHeight = 5;
        mistakeDisplay.gameObject.SetActive(false);
        startPanel.gameObject.SetActive(true);
        mainPanel.gameObject.SetActive(false);
        tutorialPanel.gameObject.SetActive(false);
        pause.interactable = true;
        restart.interactable = false;
    }

    // Update the timer 
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

    public void MotorOnOff(bool on_off)
    {
        motorOn = on_off;
        if (motorOn)
        {
            Debug.Log("motorSound");
            audio.Play("CraneMotor");
        } else
        {
            audio.Stop("CraneMotor");
        }
    }


    public bool motorStatus()
    {
        return motorOn;
    }

    public void startButton()
    {
        timer = 0.0f;
        startPanel.gameObject.SetActive(false);
        mainPanel.gameObject.SetActive(true);
        MotorOnOff(true);
    }

    public void pauseButton()
    {
        MotorOnOff(false);
        paused = true;
        pause.interactable = false;
        restart.interactable = true;
    }

    public void restartButton()
    {
        MotorOnOff(true);
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
            LeverDeHighlight();
        }
        else
        {
            for (int i = 0; i<3; i++)
            {
                StartCoroutine(highlight(-1));
            }
        }
    }

    public void demoCabLever(bool check)
    {
        if (check)
        {
            for (int i = 0; i < 2; i++)
            {
                StartCoroutine(highlight(0));
            }
        } else
        {
            CabLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat1);
        }
    }

    public void demoBoomLever(bool check)
    {
        if (check)
        {
            for (int i = 0; i<2; i++)
            {
                StartCoroutine(highlight(1));
            }
        } else
        {
            BoomLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat1);
        }
    }

    public void demoPulleyLever(bool check)
    {
        if (check)
        {
            for (int i = 0; i < 2; i++)
            {
                StartCoroutine(highlight(2));
            }
        }
        else
        {
            PulleyLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat1);
        }
    }
   

    public void demoExtensionLever(bool check)
    {
        if (check)
        {
            for (int i = 0; i < 2; i++)
            {
                StartCoroutine(highlight(3));
            }
        }
        else
        {
            ArmLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat1);
        }
    }

    IEnumerator highlight(int x)
    {
        if (x == 1)
        {
            BoomLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat2);
        }
        else if (x == 0)
        {
            CabLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat2);
        }
        else if (x == -1)
        {
            ItemForPickUp.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat2);
        } else if (x == 2)
        {
            PulleyLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat2);
        } else if (x == 3)
        {
            ArmLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat2);
        }
        yield return new WaitForSeconds(1f);
        if (x > -1)
        {
            LeverDeHighlight();
        }
        else if (x == -1)
        {
            ItemForPickUp.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat3);
        }
    }

    private void LeverDeHighlight()
    {
        CabLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat1);
        BoomLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat1);
        PulleyLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat1);
        ArmLever.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat1);
    }
    public void TrainingSafetyCheck(float height)
    {
        float h = (int)height;
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