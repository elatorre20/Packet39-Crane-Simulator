using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyLever : MonoBehaviour
{
    public Lever leverRoatation;
    public GameObject magnet;
    public GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.motorStatus())
        {
            float value = leverRoatation.ReadAxis();
            float strength = magnet.GetComponent<SpringJoint>().spring;
            if ((strength < 100f && value > 0) || (strength > 10f && value < 0))
            {
                //Debug.Log("Pulley");
                strength = strength + 2f * value;
                magnet.GetComponent<SpringJoint>().spring = strength;
            }
        }
       

    }
}
