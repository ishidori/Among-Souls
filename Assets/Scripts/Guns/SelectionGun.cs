using UnityEngine;

public class SelectionGun : MonoBehaviour
{
    
    [HideInInspector] public int WeaponSwitch = 0;

    private void Start()
    {
        WeaponSwitch = PlayerPrefs.GetInt("ValueWeaponSwich");
        SelectionWeapon();
    }


    private void SelectionWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == WeaponSwitch)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);               
            i++;
        }
    }
}

