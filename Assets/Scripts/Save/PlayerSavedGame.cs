using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerSavedGame
{
    public static PlayerSavedGame Instance = new PlayerSavedGame();
    public int Souls;
    public List<string> BuyItems;

    public static void Save()
    {
        var json = JsonUtility.ToJson(PlayerSavedGame.Instance);
        PlayerPrefs.SetString("Save", json);
        PlayerPrefs.Save();
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {          
            var json = PlayerPrefs.GetString("Save");
            PlayerSavedGame.Instance = JsonUtility.FromJson<PlayerSavedGame>(json);
        }
       
        if (Instance.BuyItems == null)
            Instance.BuyItems = new List<string>();
    }
}