using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRead : MonoBehaviour
{
    public HingeJoint Lever;
    public BoomUpDown Boom;
    public CabinRotate Cabin;
    public float DeadzoneDegrees = 20f;

    public bool CabinRotation;
    public bool BoomElevation;
    public bool BoomExtension;
    public bool RopeExtension;

    private float CurrentAngle = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentAngle = Lever.angle;
        Debug.Log(CurrentAngle);

        if (CabinRotation)
        {
            if(CurrentAngle > DeadzoneDegrees)
            {
                Cabin.MoveRight();
            }
            if(CurrentAngle < -DeadzoneDegrees)
            {
                Cabin.MoveLeft();
            }
        }

        if (BoomElevation)
        {
            if (CurrentAngle > DeadzoneDegrees)
            {
                Boom.MoveDown();
            }
            if (CurrentAngle < -DeadzoneDegrees)
            {
                Boom.MoveUp();
            }
        }

    }
}
