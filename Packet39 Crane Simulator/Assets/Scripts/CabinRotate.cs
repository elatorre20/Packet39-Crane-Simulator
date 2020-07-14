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
        if (Input.GetKey("left"))
        {
            if (CabinMotor.targetVelocity < mVelocity)
                CabinMotor.targetVelocity += 1;
            Debug.Log("Left arrow pressed.\n" + CabinMotor.targetVelocity.ToString());
        }
        else if (Input.GetKey("right"))
        {
            if (CabinMotor.targetVelocity > (mVelocity * -1))
                CabinMotor.targetVelocity -= 1;
            Debug.Log("Right arrow pressed.\n" + CabinMotor.targetVelocity.ToString());
        }
        else
        {
            CabinMotor.targetVelocity = 0;
        }
        CabinHinge.motor = CabinMotor;
    }
}
