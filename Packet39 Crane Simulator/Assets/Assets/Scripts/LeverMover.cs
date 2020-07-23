using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMover : MonoBehaviour
{
    public Transform handle;
    public HingeJoint leverJoint;
    private JointMotor motor;
    private Vector3 origin;
    public float deadzone = 0.1f;
    float distance;
    private bool isSelected = false;

    private void Start()
    {
        origin = handle.position;
        motor = leverJoint.motor;
        motor.targetVelocity = 0;
        motor.force = 100;
        leverJoint.motor = motor;
        snapBack();
    }
    public void getDistance()
    {
        distance = transform.position.x - handle.position.x;
        //Debug.Log(distance);
    }

    public void snapBack()
    {
        transform.position = origin;
    }

    private void Update()
    {
        getDistance();
        if(distance > deadzone)
        {
            leverJoint.useMotor = true;
            motor.targetVelocity = -20;
            leverJoint.motor = motor;
        }
        if(distance < -deadzone)
        {
            leverJoint.useMotor = true;
            motor.targetVelocity = 20;
            leverJoint.motor = motor;
        }
        if(!(distance > deadzone) && !(distance < -deadzone))
        {
            //motor.targetVelocity = 0;
            leverJoint.useMotor = false;
        }
        

        if(!isSelected)
        {
            snapBack();
        }
    }

    public void selected()
    {
        isSelected = true;
    }

    public void deselected()
    {
        isSelected = false;
    }




    //    public void selected()
    //    {
    //        Debug.Log("lever selected");
    //    }
}
