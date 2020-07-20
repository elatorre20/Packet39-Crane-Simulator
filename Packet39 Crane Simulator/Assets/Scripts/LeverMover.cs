using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMover : MonoBehaviour
{
    public Transform handle;
    public GameObject handController;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == handController)
        {
            transform.LookAt(other.transform.position, transform.up);
        }
        
    }

    public void followHand()
    {
    }

    public void selected()
    {
        Debug.Log("lever selected");
    }
}
