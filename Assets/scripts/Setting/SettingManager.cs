using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance;
    private float difficultyLevel = 1f;
    private string diff_key = "diff_key";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            LoadSaveDiff();
        }
        else
        {
            Destroy(gameObject); 
        }
        Screen.fullScreen = false;

    }
    
    public void Change_Scene()
    {
       
        SceneManager.LoadScene("Menu_game");

    }


    public void DifficultyFromMenu(int dropdownValue)
    {
        PlayerPrefs.SetInt(diff_key, dropdownValue);
        PlayerPrefs.Save();
        if (dropdownValue == 0)
        {
            difficultyLevel = 1f;
        }
        else if (dropdownValue == 1)
        {
            difficultyLevel = 1.5f;
        }
        else if (dropdownValue == 2)
        {
            difficultyLevel = 2f;
        }
        else if (dropdownValue == 3)
        {
            difficultyLevel = 4f;
        }
    }

    private void LoadSaveDiff()
    {
        int saved = PlayerPrefs.GetInt("diff_key", 0);
        DifficultyFromMenu (saved);
    }

    public float GetDifficultyLevel()
    {
        return difficultyLevel;
    }
}