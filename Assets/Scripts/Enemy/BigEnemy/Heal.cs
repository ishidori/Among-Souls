using UnityEngine;

public class Heal : MonoBehaviour
{
    private HealthPlayer hpPlayer;
    [HideInInspector] public float currentHp;

    private void Start()
    {
        hpPlayer = FindObjectOfType<HealthPlayer>();
        currentHp = hpPlayer.Hp;
    }


    private void OnDestroy()
    {
        hpPlayer.Hp += 40;
        
        if(hpPlayer.Hp > currentHp)
        {
            hpPlayer.Hp = currentHp;
        }

        hpPlayer.HpBarPlayer.fillAmount = hpPlayer.Hp / currentHp;
    }
}
