using UnityEngine;
using TMPro;

public class FromGameSoulsCounter : MonoBehaviour
{  
    [SerializeField] public TextMeshProUGUI _CounterText;
    [HideInInspector] public int _CounterScore;
    private HealthFromEnemy[] EventDied;
    [HideInInspector] public bool CanCounterIncrease = true;


    private void Update()
    {
        FindEnemyForCounter();
    }



    public void FindEnemyForCounter()
    {
        EventDied = FindObjectsOfType<HealthFromEnemy>();
        foreach (var EventDied in EventDied)
            EventDied.Died += OnDied;
    }



    private void OnDestroy()
    {
        foreach (var EventDied in EventDied)
            EventDied.Died -= OnDied;
    }



    private void OnDied()
    {
        if (CanCounterIncrease)
        {            
            _CounterScore += 1;
            PlayerSavedGame.Instance.Souls++;
            PlayerSavedGame.Save();
            _CounterText.text = "Souls : " + _CounterScore;
            CanCounterIncrease = false;
        }      
    }
}
