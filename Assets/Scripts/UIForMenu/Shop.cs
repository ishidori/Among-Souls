using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{ 
    [HideInInspector] public int ValueItem;
    [HideInInspector] public int PriceItem;
    [HideInInspector] public int Souls;
    [SerializeField] private GameObject[] AllItem;
    [SerializeField] private Image[] Indicator;
    [SerializeField] public TextMeshProUGUI CounterSouls;
    [SerializeField] public AudioSource ButtonClickSound;
    [SerializeField] private string[] text;
    [SerializeField] public string[] text1;
    private int Language;

    private void Start()
    {
        Language = PlayerPrefs.GetInt("Language");
        PlayerSavedGame.Load();     
        UpdateWeaponList();       
        CounterSouls.text = text[Language] + PlayerSavedGame.Instance.Souls.ToString();
        PlayerSavedGame.Save();
        SelectionIndicator();
        BuyItem();
    }


    public void BuyItem()
    {
        if (PlayerSavedGame.Instance.Souls >= PriceItem)
        {
            PlayerSavedGame.Instance.BuyItems.Add(ValueItem.ToString());
            PlayerSavedGame.Instance.Souls = PlayerSavedGame.Instance.Souls - PriceItem;
            CounterSouls.text = text[Language] + PlayerSavedGame.Instance.Souls.ToString();   
            PlayerSavedGame.Save();
            PlayerSavedGame.Load();
            UpdateWeaponList();
        }
    }


    public void UpdateWeaponList()
    {
        for (int i = 0; i < PlayerSavedGame.Instance.BuyItems.Count; i++)
        {
            for (int y = 0; y < AllItem.Length; y++)
            {
                if (AllItem[y].GetComponent<Item>().ValueItem.ToString() == PlayerSavedGame.Instance.BuyItems[i])
                {              
                    Language = PlayerPrefs.GetInt("Language");
                    CounterSouls.text = text[Language] + PlayerSavedGame.Instance.Souls.ToString();
                    AllItem[y].GetComponent<Item>().Text_Item.text = text1[Language];
                    AllItem[y].GetComponent<Item>().isBuy = true;
                }
            }
        }
    }


    public void SelectionIndicator()
    {
        int i = 0;
        foreach(Image Selection in Indicator)
        {
            if(i == PlayerPrefs.GetInt("ValueWeaponSwich"))
                Selection.enabled = true;
            else
                Selection.enabled = false;
            i++;
        }
    }
}
