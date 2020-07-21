using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinRotate : MonoBehaviour
{
    private HingeJoint CabinHinge;
    private JointMotor CabinMotor;
    public int mVelocity;
    public AudioManager audioManager;

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
            MoveLeft();
            audioManager.Play(1);  // plays crane move sound

        }
        else if (Input.GetKey("right"))
        {
            MoveRight();
            audioManager.Play(1);
        }
        else
        {
            CabinMotor.targetVelocity = 0;
            audioManager.Stop(1);
        }
        CabinHinge.motor = CabinMotor;

    }

    public void MoveLeft()
    {
        if (CabinMotor.targetVelocity < mVelocity)
            CabinMotor.targetVelocity += 1;
        //Debug.Log("Left arrow pressed.\n" + CabinMotor.targetVelocity.ToString());
    }

    public void MoveRight()
    {
        if (CabinMotor.targetVelocity > (mVelocity * -1))
            CabinMotor.targetVelocity -= 1;
        //Debug.Log("Right arrow pressed.\n" + CabinMotor.targetVelocity.ToString());
    }
}
