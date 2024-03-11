using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BossPathfinder : Pathfinder
{

    [SerializeField] PathConfigSO bossPathConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    [SerializeField] float moveSpeed = 10f;

    void Start()
    {
        waypoints = bossPathConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            UnityEngine.Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = moveSpeed * Time.deltaTime;
            transform.position = UnityEngine.Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
                if (waypointIndex >= waypoints.Count)
                {
                    waypointIndex = 0;
                }
            }
        }
    }
}
