using System.Linq;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private WaypointPath _waypointPath;

    [SerializeField] private float _speed;

    private int _targetWaypointIndex;
    private Transform _previousWayPoint;
    private Transform _targetWaypoint;
    private float _elapsedTime;
    private float _timeToWaypoint;


    void Start()
    {
        TargetNextWaypoint();
    }

    void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;
        float elapsedPercentage = _elapsedTime / _timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        transform.position = Vector3.Lerp(_previousWayPoint.position
            , _targetWaypoint.position, elapsedPercentage);
        transform.rotation = Quaternion.Lerp(_previousWayPoint.rotation
            , _targetWaypoint.rotation, elapsedPercentage);

        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }
    private void TargetNextWaypoint()
    {
        _previousWayPoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;
        float distanceToWaypoint = Vector3.Distance(_previousWayPoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }

}
