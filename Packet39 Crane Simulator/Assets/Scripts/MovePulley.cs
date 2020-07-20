using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class MovePulley : MonoBehaviour
{
    public GameObject magnettip;
    public GameObject magnet;
    public Button raiseButton;
    public float speed;

    private LineRenderer line;
    private float cableWidth;


    // Start is called before the first frame update
    void Start()
    {
        cableWidth = 0.1f;
        speed = 1f;
        line = GetComponent<LineRenderer>();
        line.SetWidth(cableWidth, cableWidth);
        line.useWorldSpace = true;

        line.positionCount = 2;

        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, magnettip.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //NEED TO: add checking for max and min length of the cable
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, magnettip.transform.position);
    }

    public void Raise()
    {
        Debug.Log("up");
        magnet.GetComponent<Rigidbody>().isKinematic = false;
        float strength = magnet.GetComponent<SpringJoint>().spring;
        strength = strength * 1.2f * speed;
        magnet.GetComponent<SpringJoint>().spring = strength;
    }

    public void Lower()
    {
        Debug.Log("down");
        if (magnet.GetComponent<SpringJoint>().spring > 10)
        {
            magnet.GetComponent<Rigidbody>().isKinematic = false;
            raiseButton.interactable = true;
            float strength = magnet.GetComponent<SpringJoint>().spring;
            strength = strength * 0.8f * speed;
            magnet.GetComponent<SpringJoint>().spring = strength;
        }
        else
        {
            Debug.Log("Reaches full length");
        }
    }
}