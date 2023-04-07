using UnityEngine;

public class Heal : MonoBehaviour
{
    private HealthPlayer hpPlayer;
    private bool onHeal = true;
    

    private void Start()
    {
        hpPlayer = FindObjectOfType<HealthPlayer>();
    }


    private void HealPlayer()
    {
        if (onHeal)
        {
            hpPlayer.Hp += 40;

            if (hpPlayer.Hp > hpPlayer.currentHp)
            {
                hpPlayer.Hp = hpPlayer.currentHp;
            }             

            float _CurrentHealthAsPercantage = hpPlayer.Hp / hpPlayer.currentHp;
            hpPlayer.HpBarPlayer.fillAmount = _CurrentHealthAsPercantage;
            
            onHeal = false;
        }
         
    }

    private void OnDestroy()
    {
        if(hpPlayer.PlayerDied == false)
        HealPlayer();
    }
}
