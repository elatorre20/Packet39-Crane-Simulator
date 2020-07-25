using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLever : MonoBehaviour
{
    public Transform pivot;
    public Transform craneCab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = new Vector3(0, 1, 0);
        float angle = craneCab.rotation.y;
        transform.RotateAround(pivot.position, axis, angle);
    }
}
