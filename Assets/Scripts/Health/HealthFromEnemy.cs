using System;
using UnityEngine;

public class HealthFromEnemy : MonoBehaviour
{    
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] public int Souls;  
    [HideInInspector] public int _currentHealth;
    private FromGameSoulsCounter soulsCounter;

    public event Action <float> HealthChanged;
    public event Action Died;
    
    private bool _isAlive = true;

    private void Start()
    {
        _currentHealth = _maxHealth;
        soulsCounter = FindObjectOfType<FromGameSoulsCounter>();
    }



    public void ChangeHealth(int value)
    {
        _currentHealth -= value;
        
        if(_currentHealth <= 0)
            Death();
                           
        else
        {
            float _CurrentHealthAsPercantage = (float) _currentHealth / _maxHealth;
            HealthChanged?.Invoke(_CurrentHealthAsPercantage);  
        }
    }


    public void Death()
    {
        if (_isAlive)
        {
            soulsCounter._CounterScore += Souls;
            soulsCounter.CanCounterIncrease = true;
            HealthChanged?.Invoke(0);
            Died?.Invoke();                     
            Destroy(gameObject);
            _isAlive = false;
        } 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            ChangeHealth(10);
            Destroy(other.gameObject);
        }
    }

}
