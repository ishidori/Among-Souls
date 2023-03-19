using UnityEngine;
using TMPro;

public class FromMenuSoulsCounter : MonoBehaviour
{
    [HideInInspector] public int Souls;
    [HideInInspector] public TextMeshProUGUI TMpro;
    [HideInInspector] public int Score;
    

    private void Start()
    {
        TMpro = GetComponent<TextMeshProUGUI>();
        CounterSouls();
        
    }


    public void CounterSouls()
    {
        //    Souls = PlayerPrefs.GetInt("Souls");
        //    Score = PlayerPrefs.GetInt("SoulsScore");
        //    Souls += Score;
        //    PlayerPrefs.SetInt("Souls", Souls);
        //    TMpro.text = "Souls : " + Souls;
        //    PlayerPrefs.SetInt("SoulsScore",0);
        //

        TMpro.text = "Souls : " + PlayerSavedGame.Instance.Souls;
    }
}
