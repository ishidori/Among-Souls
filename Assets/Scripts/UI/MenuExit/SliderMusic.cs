using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class SliderMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Slider sliderMusic;
    private string FirtStartGame;

    private void Start()
    {
        StartCoroutine(CoroutineSaveValueMusic());
        
        FirtStartGame = PlayerPrefs.GetString("FirstStartGameForMusic");       
        sliderMusic.value = PlayerPrefs.GetFloat("SliderVolumeMusic");        
        if(PlayerPrefs.GetFloat("SliderVolumeMusic") == 0f && FirtStartGame == "")
        {
            sliderMusic.value = 0.2f;
            FirtStartGame = "false";
            PlayerPrefs.SetString("FirstStartGameForMusic", FirtStartGame);
        }
    }


    private void OnEnable()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("SliderVolumeMusic");
    }


    private void OnDisable()
    {
        PlayerPrefs.SetFloat("SliderVolumeMusic", sliderMusic.value);
    }


    private void Update()
    {       
        UpdateValueVolume();
    }


    private void UpdateValueVolume()
    {
        musicSource.volume = sliderMusic.value;
    }


    private IEnumerator CoroutineSaveValueMusic()
    {
        while (true)
        {
            PlayerPrefs.SetFloat("SliderVolumeMusic", sliderMusic.value);
            yield return new WaitForSeconds(5);
        }
    }
}