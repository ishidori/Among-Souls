using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderSfx : MonoBehaviour
{
    [SerializeField] private AudioSource[] SfxSource;
    [SerializeField] public Slider sliderSfx;
    private string FirtStartGame;

    private void Start()
    {
        StartCoroutine(CoroutineSaveValueSfx());
        
        FirtStartGame = PlayerPrefs.GetString("FirstStartGameForSfx");
        sliderSfx.value = PlayerPrefs.GetFloat("SliderVolumeSfx");          
        
        if (PlayerPrefs.GetFloat("SliderVolumeSfx") == 0f && FirtStartGame == "")
        {
            sliderSfx.value = 1f;
            FirtStartGame = "false";
            PlayerPrefs.SetString("FirstStartGameForSfx", FirtStartGame);
        }       
    }


    private void OnEnable()
    {
        sliderSfx.value = PlayerPrefs.GetFloat("SliderVolumeSfx");
    }


    private void OnDisable()
    {
        PlayerPrefs.SetFloat("SliderVolumeSfx", sliderSfx.value);
    }


    private void Update()
    {
        UpdateValueVolume();
    }


    private void UpdateValueVolume()
    {        
        foreach(AudioSource Source in SfxSource)
        {
            if (Time.timeScale == 1f)
                Source.volume = sliderSfx.value;
        }
    }

    private IEnumerator CoroutineSaveValueSfx()
    {
        while (true)
        {
            PlayerPrefs.SetFloat("SliderVolumeSfx", sliderSfx.value);
            yield return new WaitForSeconds(5);
        }

    }
}
