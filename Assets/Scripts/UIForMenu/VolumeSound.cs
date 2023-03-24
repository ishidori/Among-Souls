using UnityEngine;

public class VolumeSound : MonoBehaviour
{
    [SerializeField] private AudioSource Music;
    [SerializeField] private AudioSource Sfx;
    
    private void Start()
    {
        if(PlayerPrefs.GetString("FirstStartGameForSfx") == "false")           
            Sfx.volume = PlayerPrefs.GetFloat("SliderVolumeSfx");
        
        if(PlayerPrefs.GetString("FirstStartGameForMusic") == "false")
            Music.volume = PlayerPrefs.GetFloat("SliderVolumeMusic");
    }
}
