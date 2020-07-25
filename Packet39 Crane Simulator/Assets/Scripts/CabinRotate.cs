using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinRotate : MonoBehaviour
{
    private HingeJoint CabinHinge;
    private JointMotor CabinMotor;
    public int mVelocity;

    // Start is called before the first frame update
    void Start()
    {
        CabinHinge = transform.GetComponent<HingeJoint>();

        CabinMotor = CabinHinge.motor;
        CabinMotor.targetVelocity = 0;
        CabinMotor.force = 10;
        //Debug.Log(transform.name);
        CabinHinge.motor = CabinMotor;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("left"))
        //{
        //    MoveLeft();
        //}
        //else if (Input.GetKey("right"))
        //{
        //    MoveRight();
        //}
        //else
        //{
        //    CabinMotor.targetVelocity = 0;
        //}
        //CabinHinge.motor = CabinMotor;
    }

    public void MoveLeft()
    {
        if (CabinMotor.targetVelocity < mVelocity)
        {
            CabinMotor.targetVelocity += 0.02f;
        }
        //Debug.Log("Left arrow pressed.\n" + CabinMotor.targetVelocity.ToString());
        CabinHinge.motor = CabinMotor;
    }

    public void MoveRight()
    {
        if (CabinMotor.targetVelocity > (mVelocity * -1))
        {
            CabinMotor.targetVelocity -= 0.02f;
        }
        CabinHinge.motor = CabinMotor;

        //Debug.Log("Right arrow pressed.\n" + CabinMotor.targetVelocity.ToString());
    }

    public void StopRotate()
    {
        CabinMotor.targetVelocity = 0;
        CabinHinge.motor = CabinMotor;
    }
}
