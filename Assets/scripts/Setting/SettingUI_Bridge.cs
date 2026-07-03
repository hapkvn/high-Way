using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingUI_Bridge : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown difficultyDropdown;

    private void Start()
    {
        if (difficultyDropdown != null)
        {
            difficultyDropdown.value = PlayerPrefs.GetInt("diff_key", 0);
        }
    }

    
    public void OnDropdownValueChanged(int value)
    {
        
        if (SettingManager.Instance != null)
        {
            SettingManager.Instance.DifficultyFromMenu(value);
        }
    }

    
    public void OnBackButtonClicked()
    {
        if (SettingManager.Instance != null)
        {
            SettingManager.Instance.Change_Scene();
        }
        else
        {
            SceneManager.LoadScene("Menu_game");
        }
    }
}