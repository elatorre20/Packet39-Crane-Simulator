using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyLever : MonoBehaviour
{
    public Lever leverRoatation;
    public MovePulley movePulley;
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
            movePulley.Raise();
        }
        else if (value < 0)
        {
            movePulley.Lower();
        }

    }
}
