using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabLever : MonoBehaviour
{
    public Lever leverRoatation;
    public CabinRotate moveCab;
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
            moveCab.MoveRight();
        }
        else if (value < 0)
        {
            moveCab.MoveLeft();
        }
        else if (Mathf.Approximately(value, 0))
        {
            moveCab.StopRotate();
        }
    }
}
