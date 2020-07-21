using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomUpDown : MonoBehaviour
{
    private HingeJoint BoomHingeJoint;
    private JointMotor motor;
    public int MaxVeolcity;
    public bool inputActive = false;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        BoomHingeJoint = transform.GetComponent<HingeJoint>();

        motor = BoomHingeJoint.motor;
        motor.targetVelocity = 0;
        motor.force = 10;
        BoomHingeJoint.motor = motor;
        
        audioManager.Play(0); // 0 is the car_start sound
        StartCoroutine(AudioWait());

        audioManager.Play(2); // the idle sound, this will loop forever
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            inputActive = true;
            MoveUp();
        } 
        else if (Input.GetKey("down"))
        {
            inputActive = true;
            MoveDown();
        }
        if(!inputActive)
        {
            motor.targetVelocity = 0;
            BoomHingeJoint.motor = motor;

            audioManager.Stop(1); // hardcoded since there are only 3 sounds, this is the crane moving sound
        }
        else if(inputActive)
        {
            audioManager.Play(1); // hardcoded since there are only 3 sounds, this is the crane moving sound
        }    
    }

    public void MoveUp()
    {
        if (motor.targetVelocity < MaxVeolcity)
            motor.targetVelocity += 1;
        //Debug.Log("Up arrow pressed.\n" + motor.targetVelocity.ToString());
        BoomHingeJoint.motor = motor;
    }

    public void MoveDown()
    {
        if (motor.targetVelocity > (MaxVeolcity * -1))
            motor.targetVelocity -= 1;
       //Debug.Log("Down arrow pressed.\n" + motor.targetVelocity.ToString());
        BoomHingeJoint.motor = motor;
    }

    IEnumerator AudioWait()
    {
        //Wait for 7 seconds, duration of "car_start" clip
        yield return new WaitForSeconds(7);
    }
}
