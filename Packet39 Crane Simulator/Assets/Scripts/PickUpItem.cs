using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private bool _holdingItem;
    private GameObject itemForPickUp;
    private FixedJoint _joint;
    //public Button raiseButton;
    public GameController control;
    public AudioManager audio;


    void Start()
    {
        _holdingItem = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collide");
        if (other.tag.Equals("Movable") && _holdingItem == false)
        {
            audio.Play("ItemAttached");
            other.gameObject.AddComponent<FixedJoint>();
            itemForPickUp = other.gameObject;
            _joint = other.gameObject.GetComponent<FixedJoint>();
            other.gameObject.GetComponent<FixedJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            _holdingItem = true;
        }
    }

    public void Drop()
    {
        if (_holdingItem)
        {
            float height = Mathf.Infinity;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                height = Vector3.Distance(hit.point, transform.position);
            }
            Debug.Log(height.ToString());
            control.TrainingSafetyCheck(height);
            Destroy(_joint);
            _holdingItem = false;

        }
    }

}

