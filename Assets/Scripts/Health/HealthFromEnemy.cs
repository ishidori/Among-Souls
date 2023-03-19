using System;
using UnityEngine;
public class HealthFromEnemy : MonoBehaviour
{    
    [SerializeField] private int _maxHealth = 100;
    private FromGameSoulsCounter soulsCounter;
    
    private int _currentHealth;

    public event Action <float> HealthChanged;
    public event Action Died;



    private void Start()
    {
        _currentHealth = _maxHealth;
        soulsCounter = FindObjectOfType<FromGameSoulsCounter>();
    }



    public void ChangeHealth(int value)
    {
        _currentHealth += value;
        
        if(_currentHealth <= 0)      
            Death();                   
        else
        {
            float _CurrentHealthAsPercantage = (float) _currentHealth / _maxHealth;
            HealthChanged?.Invoke(_CurrentHealthAsPercantage);  
        }
    }



    private void Death()
    {
        soulsCounter.CanCounterIncrease = true;
        Died?.Invoke();
        HealthChanged?.Invoke(0);
        Destroy(gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            ChangeHealth(-10);
            Destroy(other.gameObject);
        }
    }

}
