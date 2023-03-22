using UnityEngine;
using TMPro;

public class MenuDead : MonoBehaviour
{
    [SerializeField] private Canvas MenuAfterDead;
    [SerializeField] private TimeLive Time;
    [SerializeField] private FromGameSoulsCounter CounterSouls;
    [SerializeField] private TextMeshProUGUI Time_TextInMenu;
    [SerializeField] private TextMeshProUGUI Souls_TextInMenu;
    [SerializeField] private TextMeshProUGUI Record;
    [SerializeField] private AudioSource VolumeReload;

    
    private void Start()
    {
        MenuAfterDead.enabled = false;
    }

    public void Menu()
    {
        MenuAfterDead.enabled = true;
        Time_TextInMenu.text += Time.Time_Text.text;       
        Destroy(Time);
        Time.Time_Text.text = "";

        Souls_TextInMenu.text = "Collect souls: " + CounterSouls._CounterScore.ToString();
        CounterSouls._CounterText.text = "";
        VolumeReload.Stop();
    }
}
