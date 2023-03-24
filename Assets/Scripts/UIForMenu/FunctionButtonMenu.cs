using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionButtonMenu : MonoBehaviour
{
    [SerializeField] private AudioSource ButtonClickSound;

    //For MenuSetting
    [SerializeField] private Canvas MenuSettings;

    //For MenuRecord
    [SerializeField] private Canvas MenuRecord;

    //For ShopGun
    [SerializeField] private Canvas MenuShopGuns;


    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
        ButtonClickSound.Play();
    }


    public void ButtonReset()
    {
        PlayerPrefs.DeleteAll();
    }


    public void ButtonGuns()
    {
        FunctionButtonsForMenu(MenuShopGuns);
        ButtonClickSound.Play();
        
        if (MenuSettings.enabled == true)
        {
            MenuSettings.enabled = false;
        }
        
        else if (MenuRecord.enabled == true)
        {
            MenuRecord.enabled = false;
        }
        
    }


    public void ButtonSettings()
    {
        FunctionButtonsForMenu(MenuSettings);
        ButtonClickSound.Play();
        
        if (MenuShopGuns.enabled == true)
        {
            MenuShopGuns.enabled = false;
        }
        
        else if (MenuRecord.enabled == true)
        {
            MenuRecord.enabled = false;
        }
    }


    public void ButtonRecord()
    {
        FunctionButtonsForMenu(MenuRecord);
        ButtonClickSound.Play();
        
        if (MenuShopGuns.enabled == true)
        {
            MenuShopGuns.enabled = false;
        }
        
        else if (MenuSettings.enabled == true)
        {
            MenuSettings.enabled = false;
        }
    }


    public void ButtonGitHub()
    {
        Application.OpenURL("https://github.com/ishidori/Among-Souls");
        ButtonClickSound.Play();
    }


    private void FunctionButtonsForMenu(Canvas canvas)
    {
        if (canvas.enabled == true)
        {
            canvas.enabled = false;
        }

        else if (canvas.enabled == false)
        {
            canvas.enabled = true;
        }     
    }


}
