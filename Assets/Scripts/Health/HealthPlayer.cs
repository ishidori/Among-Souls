using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{

    [SerializeField] public Image HpBarPlayer;
    [SerializeField] private MenuDead MenuDie;
    
    //for destroy
    [SerializeField] private SpawnersEasyEnemy[] SpawnersEasy;
    [SerializeField] private SpawnerBoss SpawnersBoss;
    [SerializeField] private SpawnersHardEnemy[] SpawnersHard;
    [SerializeField] private SpawnersHeal SpawnersHeal;
    [SerializeField] private MovementJoystick MoveJoystick;
    [SerializeField] private ShootingJoystick ShootingJoystick;
    
    public float Hp = 100f;
    [HideInInspector] public bool PlayerDied = false;
    [HideInInspector] public float currentHp;


    private void Start()
    {
        currentHp = Hp;
    } 


    public void Die()
    {
        if (Hp <= 0f)
        {
            Destroy(gameObject);
            MenuDie.Menu();
            PlayerDied = true;
        }

        float _CurrentHealthAsPercantage = Hp / currentHp;
        HpBarPlayer.fillAmount = _CurrentHealthAsPercantage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bulletEnemy"))
        {
            Hp -= 10;
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        Destroy(SpawnersEasy[0]);
        Destroy(SpawnersEasy[1]);
        Destroy(SpawnersBoss);
        Destroy(SpawnersHard[0]);
        Destroy(SpawnersHard[1]);
        Destroy(SpawnersHeal);
        Destroy(MoveJoystick);
        Destroy(ShootingJoystick);
    }
}
