using TMPro;
using UnityEngine;
public class Localization : MonoBehaviour
{

    [SerializeField] private string[] Text;
    private int Language;
    private TextMeshProUGUI Tmpro;

    void Start()
    {
        FunctionLocalization();
    }


    public void FunctionLocalization()
    {
        Language = PlayerPrefs.GetInt("Language");
        Tmpro = GetComponent<TextMeshProUGUI>();
        Tmpro.text = Text[Language];
    }

  
}
