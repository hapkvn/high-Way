using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
   

    public void StartGame()
    {
        if (AdManager.instance != null)
        {
            AdManager.instance.HideBanner();
        }
        SceneManager.LoadScene("main_play");
        Time.timeScale = 1f;
    }

    public void Setting_menu()
    {
        SceneManager.LoadScene("Setting_game");
    }

    public void Menu()
    {
       
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu_game");
    }
    public void QuitGame()
    {
        
        Application.Quit();
    }
}