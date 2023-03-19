using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Item : MonoBehaviour
{
    public int ValueItem;
    public int PriceItem;
    public TextMeshProUGUI Text_Item;
    [SerializeField] private Shop shop;
    [HideInInspector] public bool isBuy;
    
    public void BuyItem()
    {
        if (!isBuy)
        {
            shop.ValueItem = ValueItem;
            shop.PriceItem = PriceItem;
            shop.BuyItem();
            shop.ButtonClickSound.Play();
        }

        if (isBuy)
        {
            PlayerPrefs.SetInt("ValueWeaponSwich", Convert.ToInt32(ValueItem));
            shop.SelectionIndicator();
            shop.ButtonClickSound.Play();
        }        
    }
}
