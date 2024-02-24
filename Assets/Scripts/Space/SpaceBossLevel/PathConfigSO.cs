using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Path Config", fileName = "New Path Config")]
public class PathConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> meteorPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenMeteorSpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public int GetMeteorCount()
    {
        return meteorPrefabs.Count;
    }

    public GameObject GetMeteorPrefab(int index)
    {
        return meteorPrefabs[index];
    }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenMeteorSpawns - spawnTimeVariance, timeBetweenMeteorSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
