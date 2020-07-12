using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private FixedJoint _joint;
    private bool _holdingItem;

    // Start is called before the first frame update
    void Start()
    {
        _joint = gameObject.GetComponent<FixedJoint>();
       // _joint.spring = 20;
        _holdingItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        _joint = gameObject.GetComponent<FixedJoint>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Movable") && _holdingItem == false)
        {
            Debug.Log("Collide");
            _joint.connectedBody = other.GetComponent<Rigidbody>();
            other.GetComponent<Rigidbody>().isKinematic = false;
            //_springJoint.connectedAnchor = new Vector3(0, 0, 0);
            _holdingItem = true;
        }

    }
}
