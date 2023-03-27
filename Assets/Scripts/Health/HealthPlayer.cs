using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] public Image HpBarPlayer;
    [SerializeField] private MenuDead MenuDie;
    public float Hp = 100f;
    [HideInInspector] public float currentHp;

    private void Start() => currentHp = Hp;

    public void Die()
    {
        if (Hp <= 0f)
        {
            Destroy(gameObject);
            MenuDie.Menu();
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
}
