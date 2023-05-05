using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WaypointSequence : MonoBehaviour
{
    [SerializeField] private bool showDebugLines;
    [SerializeField] private Color lineColor;
    [Range(1, 50)] [SerializeField] private int thickness;
    private List<Waypoint> _waypoints = new();

    private void Awake() => _waypoints.AddRange(GetComponentsInChildren<Waypoint>());

    private void OnDrawGizmos()
    {
        if (showDebugLines)
        {
            for (int i = 0; i < _waypoints.Count-1; i++)
            {
                //Debug.DrawLine(waypoints[i].transform.position, waypoints[i+1].transform.position, lineColor);
                var p1 = _waypoints[i].transform.position;
                var p2 = _waypoints[i+1].transform.position;
                Handles.DrawBezier(p1,p2,p1,p2, lineColor,null, thickness);
            }
        }
    }

    public Waypoint GetWaypoint(int index)
    {
        return _waypoints[index];
    }
}