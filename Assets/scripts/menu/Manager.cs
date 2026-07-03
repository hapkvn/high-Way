using System;
using System.Threading;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Tạo một biến static duy nhất để các script khác gọi thẳng không cần Find
    public static Manager instance;
    private static int deathCount = 0;

    private int adWarchCount = 1;
    [SerializeField] private TMP_Text adW_Text;

    private int adPowerUp = 1;
    [SerializeField] private TMP_Text adPU_Text;
    [SerializeField] private TMP_Text adPU2_Text;

    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private TMP_Text f_Text;
    private int Score;

    [Header("UI Panels")]
    [SerializeField] private GameObject gameOver;   
    [SerializeField] private GameObject pausePanel; 

    [Header("HUD Buttons & Text")]
    [SerializeField] private GameObject btn;         
    [SerializeField] private GameObject pause;       
    [SerializeField] private GameObject sorce;       

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        adWarchCount = 1;
        Score = 0;
        UpdateUI(); 
    }

    public void AddScore()
    {
        Score++;
        UpdateUI();
    }

    public float up_difficulty()
    {
        int level = Score / 50;
        float multiplier = 1f + (level * 0.2f);
        return multiplier;
    }

    private void UpdateUI()
    {
        if (m_Text != null)
        {
            m_Text.text = "" + Score;
        }
    }

    public void ui()
    {
        if (AdManager.instance != null)
        {
            AdManager.instance.ShowBanner();
        }
        
        
        f_Text.text = m_Text.text;

        gameOver.SetActive(true);
        btn.SetActive(false);
        pause.SetActive(false);
        sorce.SetActive(false);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (Score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", Score);
            PlayerPrefs.Save();
        }

        deathCount++;
        if (deathCount >= 3)
        {
            if (AdManager.instance != null)
            {
                AdManager.instance.ShowInterstitial();
            }
            deathCount = 0;
        }
    }

    public void playerRevice()
    {
        if (adWarchCount >= 3)
        {
            return;
        }

        if (AdManager.instance != null)
        {
            AdManager.instance.ShowRewarded(() =>
            {
                adWarchCount++;
                adW_Text.text = "ADx" + adWarchCount;

                Time.timeScale = 1f;
                gameOver.SetActive(false);

               
                btn.SetActive(true);
                pause.SetActive(true);
                sorce.SetActive(true);
                AdManager.instance.HideBanner();

                if (player.instance != null)
                {
                    player.instance.activeShield(); 
                }
            });
            AdManager.instance.LoadRewarded();
        }
    }

    public void getSpeed()
    {
        if (adPowerUp >= 5)
        {
            Debug.Log("Đã hết lượt nhận buff trong ván này!");
            return;
        }

        if (AdManager.instance != null)
        {
            AdManager.instance.ShowRewarded(() =>
            {
                adPowerUp++;
                adPU_Text.text = "ADx" + adPowerUp;

                Time.timeScale = 1f;

                if (pausePanel != null) pausePanel.SetActive(false);

                btn.SetActive(true);
                pause.SetActive(true);
                sorce.SetActive(true);

                if (player.instance != null)
                {
                    player.instance.activeSpeed();
                }
            });
            AdManager.instance.LoadRewarded();
        }
    }

    public void getShield()
    {
        if (adPowerUp >= 5)
        {
            Debug.Log("Đã hết lượt nhận buff trong ván này!");
            return;
        }

        if (AdManager.instance != null)
        {
            AdManager.instance.ShowRewarded(() =>
            {
                adPowerUp++;
                adPU2_Text.text = "ADx" + adPowerUp;

                Time.timeScale = 1f;

                if (pausePanel != null) pausePanel.SetActive(false);

                btn.SetActive(true);
                pause.SetActive(true);
                sorce.SetActive(true);

                if (player.instance != null)
                {
                    player.instance.activeShield();
                }
            });
            AdManager.instance.LoadRewarded();
        }
    }
}