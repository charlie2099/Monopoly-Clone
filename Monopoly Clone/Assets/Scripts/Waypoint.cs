using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Color gizmoColour = Color.red;
    [SerializeField] private float gizmoSize = 0.25f;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColour;
        Gizmos.DrawSphere(transform.position, gizmoSize);
    }
}
