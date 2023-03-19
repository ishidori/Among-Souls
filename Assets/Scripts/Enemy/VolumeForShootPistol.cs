using UnityEngine;

public class VolumeForShootPistol : MonoBehaviour
{
    [SerializeField] private AudioSource Source;
    private SliderSfx SliderSfx;

    private void Start()
    {
        SliderSfx = FindObjectOfType<SliderSfx>();
    }

    private void Update()
    {
        ChangeValueVolume();
    }


    private void ChangeValueVolume()
    {
        Source.volume = SliderSfx.sliderSfx.value;
    }
}
