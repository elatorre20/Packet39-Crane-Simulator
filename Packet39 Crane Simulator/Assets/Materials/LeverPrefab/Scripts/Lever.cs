using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Lever : MonoBehaviour
{
    public GameObject highlightVolume;
    public float deadzoneAngle;


    private HingeJoint hinge;
    private float value;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        Highlight(false);

    }

    public void Update()
    {
        // assume damping target is 0
        float percent = hinge.angle < 0 ? -hinge.angle / hinge.limits.max : hinge.angle / hinge.limits.min;

        value = Mathf.Abs(hinge.angle) < deadzoneAngle ? 0 : percent;

        // Debug.Log(ReadAxis());
    }

    // Returns a value from -1 to 1 denoting the state of this lever
    public float ReadAxis()
    {
        return value;
    }

    public void Highlight(bool active)
    {
        highlightVolume.SetActive(active);
    }
}
