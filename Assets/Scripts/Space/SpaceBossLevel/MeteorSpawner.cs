using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] List<PathConfigSO> pathConfigs;
    [SerializeField] float timeBetweenPaths = 0f;
    [SerializeField] bool isLooping;
    PathConfigSO currentPath;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMeteorPaths());
    }

    public PathConfigSO GetCurrentPath()
    {
        return currentPath;
    }

    IEnumerator SpawnMeteorPaths()
    {
        do
        {
            foreach(PathConfigSO path in pathConfigs)
            {
                currentPath = path;
                for(int i = 0; i < currentPath.GetMeteorCount(); i++){
                    Instantiate(currentPath.GetMeteorPrefab(i),
                    currentPath.GetStartingWaypoint().position,
                    Quaternion.Euler(0,0,180),
                    transform);
                    yield return new WaitForSeconds(currentPath.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenPaths);
            }
        }
        while(isLooping);
    }
}
