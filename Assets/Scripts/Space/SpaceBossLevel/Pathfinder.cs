using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    MeteorSpawner meteorSpawner;
    PathConfigSO pathConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    private void Awake()
    {
        meteorSpawner = FindObjectOfType<MeteorSpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        pathConfig = meteorSpawner.GetCurrentPath();
        waypoints = pathConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = pathConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
