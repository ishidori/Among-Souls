using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] PrefabEnemy;
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
            
            for (int i = 0; i < PrefabEnemy.Length; i++)
            {
                var spawn = Random.Range(0,SpawnPoints.Count);             
                Instantiate(PrefabEnemy[i],SpawnPoints[spawn]);
            }
            yield return new WaitForSeconds(TimeSpawnEnemy);
        }
       
    }
}
