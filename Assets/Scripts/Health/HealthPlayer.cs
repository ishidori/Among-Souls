using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private Image HpBarPlayer;
    [SerializeField] private Canvas MenuDead;
    [SerializeField] private TimeLive Time;
    [SerializeField] private FromGameSoulsCounter CounterSouls;
    [SerializeField] private TextMeshProUGUI Time_TextInMenu;
    [SerializeField] private TextMeshProUGUI Souls_TextInMenu;
    [SerializeField] private AudioSource VolumeReload;

    public float Hp = 100f;
    private float currentHp;


    private void Start()
    {
        currentHp = Hp;
        MenuDead.enabled = false;
    }


    public void Die()
    {
        if (Hp <= 0f)
        {
            MenuDead.enabled = true;
            Destroy(gameObject);            
            
            Time_TextInMenu.text += Time.Time_Text.text;
            Destroy(Time);
            Time.Time_Text.text = "";

            Souls_TextInMenu.text = "Collect souls: " + CounterSouls._CounterScore.ToString();
            CounterSouls._CounterText.text = "";
            VolumeReload.Stop();
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
