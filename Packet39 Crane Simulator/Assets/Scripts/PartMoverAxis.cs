using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMover : MonoBehaviour
{
    public Transform trackedController; //the control lever controlling this object
    private Quaternion controllerPosition; //current position of that control lever
    public float moveSpeed; //speed at which the object is allowed to turn
    public string controlAxis; [Tooltip("must be x, y, or ,")]
    private float axis; //the specific axis used to control the object
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controllerPosition = trackedController.localRotation;

    }
}
