using UnityEngine;
using UnityEngine.SceneManagement; 

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;
    private AudioSource audioSource;

    [Header("Kéo thả nhạc vào đây")]
    public AudioClip menuMusic; 
    public AudioClip gameMusic; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        audioSource.mute = PlayerPrefs.GetInt("MuteBGM", 0) == 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (this != instance) return;

        if (scene.name == "Menu_game" || scene.name == "setting_game")
        {
            ChangeMusic(menuMusic);
        }
        else if (scene.name == "main_play")
        {
            ChangeMusic(gameMusic);
        }
    }

    private void ChangeMusic(AudioClip newClip)
    {
       
        if (audioSource.clip == newClip)
        {
            return;
        }

        audioSource.clip = newClip;
        audioSource.Play();
    }
}