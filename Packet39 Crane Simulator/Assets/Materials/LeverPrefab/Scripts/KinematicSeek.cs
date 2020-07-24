using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KinematicSeek : MonoBehaviour
{
    private Rigidbody _rb;
    private LineRenderer _lr;
    
    public Rigidbody seekTarget;
    public float deadzoneDistance;
    public float falloffDistance;
    public float maxForce;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _lr = GetComponent<LineRenderer>();
        _lr.SetPosition(0,transform.position);
        _lr.SetPosition(1,seekTarget.transform.position);
    }

    private void OnValidate()
    {
        deadzoneDistance = deadzoneDistance < 0 ? 0 : deadzoneDistance;
        falloffDistance = falloffDistance < deadzoneDistance ? deadzoneDistance : falloffDistance;
    }

    private void FixedUpdate()
    {
        float distance = (seekTarget.transform.position - transform.position).magnitude;
        
        // Target out of deadzone, begin seek
        if ( distance > deadzoneDistance)
        {
            // Debug.Log("Seeking at Distance: " + distance);
            float force = distance < falloffDistance ? maxForce * (distance / falloffDistance) : maxForce;
            _rb.AddForce((seekTarget.transform.position - transform.position).normalized * force);
            
        }
        _lr.SetPosition(0,transform.position);
        _lr.SetPosition(1,seekTarget.transform.position);
    }

    public void Recenter()
    {
        seekTarget.transform.position = transform.position;
    }
}
