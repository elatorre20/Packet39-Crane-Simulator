using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExtensionArm : MonoBehaviour
{
    public GameObject arm2;
    public GameObject arm3;
    public GameObject arm4;
    public float increment = 0.01f; //Change the value of increment the adjust the speed of the movement of the arm.
    private float count;
    private float maxCount;
    private Vector3 mvmt;

    // Start is called before the first frame update
    void Start()
    {
        maxCount = 8f;
        count = 0f;

    }

    // Update is called once per frame
    void Update()
    { 

        ///* for customized input based on lever control, remove 'increment' and replace with your own variable */

        //if (Input.GetKey(KeyCode.E))
        //{
        //    ExtendArm(increment);
        //}
        //else if (Input.GetKey(KeyCode.R))
        //{
        //    RetractArm(increment);
        //}
    }

    public void ExtendArm()
    {
        float speed = 0.01f;
        mvmt = new Vector3(-speed, 0f, 0f);

        if (count < maxCount)
        {
            arm4.transform.localPosition += mvmt;
            count += speed;
            //Debug.Log("Extending: Arm-4, " + count);
        } else if (count < (maxCount * 2))
        {
            arm3.transform.localPosition += mvmt;
            count += speed;
        } else if (count < (maxCount * 3))
        {
            arm2.transform.localPosition += mvmt;
            count += speed;
        }
    }

    public void RetractArm()
    {
        Debug.Log("Retract");
        float speed = 0.01f;
        mvmt = new Vector3(-speed, 0f, 0f);

        if (count > (maxCount * 2))
        {
            arm2.transform.localPosition -= mvmt;
            count -= speed;
        } else if (count > maxCount)
        {
            arm3.transform.localPosition -= mvmt;
            count -= speed;
        } else if (count > 0)
        {
            arm4.transform.localPosition -= mvmt;
            count -= speed;
        }
    }
}
