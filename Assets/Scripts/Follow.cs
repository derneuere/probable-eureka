using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Target;
    public float Smoothing = 0.5f;
    
    private Vector3 _velocity;

    private void Update()
    {
        var goal = Target.position;
        goal.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, goal, ref _velocity, Smoothing);
    }
}
