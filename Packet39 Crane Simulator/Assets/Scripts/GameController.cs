using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject CraneCab;
    public GameObject BoomSection1;
    public GameObject BoomSection2;
    public GameObject BoomSection4;
    public GameObject Magnet;
    public GameObject ItemForPickUp;

    public GameObject startPanel;
    public GameObject mainPanel;
    public Button pause;
    public Button restart;

    public Text timeText;

    public Slider boxSizeSlider;

    private float timer;
    private bool paused;

    void Start()
    {
        turnMotorOff();
        paused = false;
        timer = 0.0f;
        startPanel.gameObject.SetActive(true);
        mainPanel.gameObject.SetActive(false);
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
        Magnet.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        BoomSection1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        BoomSection2.GetComponent<ExtensionArm>().enabled = false;

    }
    public void turnMotorOn()
    {
        CraneCab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Magnet.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
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
   
}
