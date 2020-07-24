using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendRetractLever : MonoBehaviour
{
    public Lever leverRoatation;
    public ExtensionArm moveArm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
