using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnersEasyEnemy : MonoBehaviour
{
    [SerializeField] private GameObject PrefabEnemy;
    [SerializeField] private List<Transform> SpawnPoints;
    [SerializeField] private float TimeSpawnEnemy;
    [SerializeField] private int StopSpawnMin;
    private TimeLive Timer;
    private bool endWave = false;
    private bool stop = false;
    
    private void Start()
    {
        StartCoroutine(SpawnerEasyEnemy());
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
                    case 45:
                        endWave = true;
                        TimeSpawnEnemy -= 1.5f;
                        break;
                }
                break;               
        }  
        
        if(Timer._sec == 16 || Timer._sec == 46)
            endWave = false;
        

        if(TimeSpawnEnemy < 6)
            TimeSpawnEnemy = 5;

        
        if(Timer._min == 1 && stop == false)
        {
            TimeSpawnEnemy += 3;
            endWave = true;
            stop = true;
        }
                
        
        //if (Timer._min == StopSpawnMin)
        //{
        //    SpawnPoints.Clear();
        //    StopCoroutine(SpawnerEasyEnemy());
        //}

    }


    private IEnumerator SpawnerEasyEnemy()
    {
        while (true)
        {           
            var spawn = Random.Range(0,SpawnPoints.Count);             
            Instantiate(PrefabEnemy,SpawnPoints[spawn]);
           
            yield return new WaitForSeconds(TimeSpawnEnemy);
        }
       
    }
}
