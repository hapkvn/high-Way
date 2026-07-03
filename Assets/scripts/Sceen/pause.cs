using UnityEngine;

public class pause : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] GameObject touch;
    [SerializeField] GameObject pause_button;
    [SerializeField] GameObject pause_menu;

    
    public void TogglePause()
    {
        isPaused = !isPaused; 

        if (isPaused)
        {
            
            Time.timeScale = 0f;
            Debug.Log("Game đã tạm dừng!");

           
            touch.SetActive(false);
            pause_button.SetActive(false);
            pause_menu.SetActive(true);

        }
        else
        {
            
            Time.timeScale = 1f;
            Debug.Log("Tiếp tục chơi!");
            touch.SetActive(true);
            pause_button.SetActive(true);
            pause_menu.SetActive(false);

          
        }
    }


}
