using UnityEngine;
using TMPro;

public class FromGameSoulsCounter : MonoBehaviour
{  
    [SerializeField] public TextMeshProUGUI _CounterText;
    [HideInInspector] public int _CounterScore;
    private HealthFromEnemy[] EventDied;
    [HideInInspector] public bool CanCounterIncrease = true;
    [HideInInspector] public int value;

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
            PlayerSavedGame.Instance.Souls += _CounterScore;
            PlayerSavedGame.Save();
            value += _CounterScore;
            _CounterText.text = "Souls : " + value;
            CanCounterIncrease = false;
            _CounterScore -= _CounterScore;
        }      
    }
}
