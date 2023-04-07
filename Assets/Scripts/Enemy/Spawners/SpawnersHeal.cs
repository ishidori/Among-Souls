using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersHeal : MonoBehaviour
{
    [SerializeField] private GameObject PrefabEnemy;
    [SerializeField] private List<Transform> SpawnPoints;
    [SerializeField] private float TimeSpawnEnemy;
    [SerializeField] private FromGameSoulsCounter counter;
    private TimeLive Timer;
    private bool endWave = false;

    private void Start()
    {
        StartCoroutine(SpawnerHardEnemy());
        Timer = FindObjectOfType<TimeLive>();
    }


    private void Update()
    {
        WaveEnemy();
    }


    private void WaveEnemy()
    {
        switch (endWave)
        {
            case false:

                switch (Timer._sec)
                {
                    case 15:
                        endWave = true;
                        TimeSpawnEnemy -= 6f;
                        break;
                    case 45:
                        endWave = true;
                        TimeSpawnEnemy -= 6f;
                        break;
                }
                break;
        }

        if (Timer._sec == 16 || Timer._sec == 46)
            endWave = false;


        if (TimeSpawnEnemy < 15)
            TimeSpawnEnemy = 13;
    }


    private IEnumerator SpawnerHardEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeSpawnEnemy);
            var spawn = Random.Range(0, SpawnPoints.Count);
            Instantiate(PrefabEnemy, SpawnPoints[spawn]);
            counter.FindEnemyForCounter();
        }
    }
}
