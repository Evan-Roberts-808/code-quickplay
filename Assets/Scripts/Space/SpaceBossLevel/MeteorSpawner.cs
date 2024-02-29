using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] List<PathConfigSO> pathConfigs;
    [SerializeField] List<GameObject> meteorVariants;
    [SerializeField] float timeBetweenPaths = 0f;
    [SerializeField] bool isLooping;
    PathConfigSO randomPath;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMeteorPaths());
    }

    public PathConfigSO GetRandomPath()
    {
        return randomPath;
    }

    IEnumerator SpawnMeteorPaths()
    {
        do
        {
            int randomPathIndex = Random.Range(0, pathConfigs.Count);
            Debug.Log(randomPathIndex);
            randomPath = pathConfigs[randomPathIndex];
            Debug.Log(randomPath);
            int randomMeteorIndex = Random.Range(0, meteorVariants.Count);
            Debug.Log(randomMeteorIndex);
            GameObject randomMeteor = meteorVariants[randomMeteorIndex];
            Debug.Log(randomMeteor);

            Instantiate(randomMeteor, randomPath.GetStartingWaypoint().position,
                        Quaternion.Euler(0, 0, 180), transform);

            yield return new WaitForSeconds(randomPath.GetRandomSpawnTime());

            yield return new WaitForSeconds(timeBetweenPaths);
        } while (isLooping);
    }
}
