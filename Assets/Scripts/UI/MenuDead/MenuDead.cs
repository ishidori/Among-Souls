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
    [SerializeField] private string[] text;
    private int Language;

    
    private void Start()
    {
        MenuAfterDead.enabled = false;
        Language = PlayerPrefs.GetInt("Language");

    }

    public void Menu()
    {
        MenuAfterDead.enabled = true;
        Time_TextInMenu.text += Time.Time_Text.text;       
        Destroy(Time);
        Time.Time_Text.text = "";

        Souls_TextInMenu.text = text[Language] + CounterSouls.value.ToString();
        CounterSouls._CounterText.text = "";
        VolumeReload.Stop();
    }
}
