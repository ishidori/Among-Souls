using UnityEngine;
using UnityEngine.SceneManagement;

public class FuctionButton : MonoBehaviour
{
    [SerializeField] private Canvas MenuExit;
    [SerializeField] private Canvas MenuDie;
    [SerializeField] private AudioSource Click;
    [SerializeField] private AudioSource AudioSourceReloadAndShoot;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void Yes()
    {
        SceneManager.LoadScene(0);
    }


    public void No()
    {
        MenuExit.enabled = false;
        Click.Play();
        Time.timeScale = 1f;
        AudioSourceReloadAndShoot.volume = 1f;
    }


    public void ExitMenu()
    {
        if (MenuDie.enabled == false)
        {
            if (MenuExit.enabled)
            {
                MenuExit.enabled = false;
                Click.Play();
                Time.timeScale = 1f;
                AudioSourceReloadAndShoot.volume = 1f;
            }

            else if (!MenuExit.enabled)
            {
                MenuExit.enabled = true;
                Click.Play();
                Time.timeScale = 0f;
                AudioSourceReloadAndShoot.volume = 0f;
            }
        }       
    }


    public void Exit()
    {
        SceneManager.LoadScene(0);
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
