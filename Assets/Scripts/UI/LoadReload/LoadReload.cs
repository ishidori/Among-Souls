using UnityEngine;
using UnityEngine.UI;

public class LoadReload : MonoBehaviour
{
    [SerializeField] private  Weapon[] _barReload;
    [SerializeField] private Image imageBarReload;


    private void Awake()
    {
        foreach (Weapon weapons in _barReload)
        {
            weapons.TimeReload += BarReload;
        } 
    }

    private void OnDestroy()
    {
        foreach (Weapon weapons in _barReload)
        {
            weapons.TimeReload -= BarReload;
        }
    }



    private void BarReload(float TimeReload)
    {
        imageBarReload.fillAmount = TimeReload;
    }
}
