using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private bool _endPoint;

    [SerializeField]
    private Waypoint _nextWaypoint;
    
    public Waypoint GetNextWaypoint {
        get { return _nextWaypoint; }
    }

    public bool EndPoint {
        get { return _endPoint; }
    }
}
