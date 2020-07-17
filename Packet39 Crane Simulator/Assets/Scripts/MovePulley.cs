using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class MovePulley : MonoBehaviour
{
    public GameObject magnettip;
    public GameObject magnet;
    public Button raiseButton;

    private LineRenderer line;
    private float cableWidth;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
        cableWidth = 0.1f;

        line = GetComponent<LineRenderer>();
        line.SetWidth(cableWidth, cableWidth);
        line.useWorldSpace = true;

        line.positionCount = 2;

        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, magnettip.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //NEED TO: add checking for max and min length of the cable
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, magnettip.transform.position);
    }

    public void Raise()
    {
        Debug.Log("up");
        magnet.GetComponent<Rigidbody>().isKinematic = false;
        Vector3 anchor = magnet.GetComponent<SpringJoint>().connectedAnchor;
        anchor.y += speed;
        magnet.GetComponent<SpringJoint>().connectedAnchor = anchor;
    }

    public void Lower()
    {
        Debug.Log("down");
        magnet.GetComponent<Rigidbody>().isKinematic = false;
        raiseButton.interactable = true;
        Vector3 connectedAnchor = magnet.GetComponent<SpringJoint>().connectedAnchor;
        connectedAnchor.y -= speed;
        magnet.GetComponent<SpringJoint>().connectedAnchor = connectedAnchor;
    }

}