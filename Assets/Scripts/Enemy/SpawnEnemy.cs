using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] PrefabEnemyPhaze1;
    [SerializeField] private GameObject[] PrefabEnemyPhaze2;
    [SerializeField] private List<Transform> SpawnPoints;
    [SerializeField] private float TimeSpawnEnemy;
    
    private TimeLive Timer;
    private bool endWave = false;

    private void Start()
    {
        StartCoroutine(SpawnerEnemy());
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
                        TimeSpawnEnemy -= 1.5f;
                        break;                   
                }
                

                switch (Timer._min)
                {
                    case 1:
                        endWave = true;
                        break;
                }
                break;
        }  
        
        if(Timer._sec == 16)
            endWave = false;
        
        if(TimeSpawnEnemy < 4)
            TimeSpawnEnemy = 3;
    }


    private IEnumerator SpawnerEnemy()
    {
        while (true)
        {
            
            for (int i = 0; i < PrefabEnemyPhaze1.Length; i++)
            {
                var spawn = Random.Range(0,SpawnPoints.Count);             
                Instantiate(PrefabEnemyPhaze1[i],SpawnPoints[spawn]);
            }
            yield return new WaitForSeconds(TimeSpawnEnemy);
        }
       
    }
}
