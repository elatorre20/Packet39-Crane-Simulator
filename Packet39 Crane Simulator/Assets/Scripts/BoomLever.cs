using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomLever : MonoBehaviour
{
    public Lever leverRotation;
    public BoomUpDown moveBoom;
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
            float value = leverRotation.ReadAxis();
            if (value > 0)
            {
                moveBoom.MoveUp();
            }
            else if (value < 0)
            {
                moveBoom.MoveDown();
            }
            else if (Mathf.Approximately(value, 0))
            {
                moveBoom.armStop();
            }
        }
        
    }
}
