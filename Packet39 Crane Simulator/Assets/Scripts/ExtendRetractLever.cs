using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendRetractLever : MonoBehaviour
{
    public Lever leverRoatation;
    public ExtensionArm moveArm;
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
            if (value > 0)
            {
                moveArm.ExtendArm();
            }
            else if (value < 0)
            {
                moveArm.RetractArm();
            }
        }
       
    }
}
