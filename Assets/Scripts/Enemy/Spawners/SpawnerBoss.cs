using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnerBoss : MonoBehaviour
{
    [SerializeField] private GameObject PrefabEnemy;
    [SerializeField] private List<Transform> SpawnPoints;
    [SerializeField] private float TimeSpawnEnemy;

    private void Start()
    {
        StartCoroutine(SpawnerHardEnemy());
    }

    private IEnumerator SpawnerHardEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeSpawnEnemy);
            var spawn = Random.Range(0, SpawnPoints.Count);
            Instantiate(PrefabEnemy, SpawnPoints[spawn]);
        }
    }
}
