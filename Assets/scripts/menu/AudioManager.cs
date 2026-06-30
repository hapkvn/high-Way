using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip crash;
    [SerializeField] private AudioClip fly;
    [SerializeField] private AudioClip crash_S;
    [SerializeField] private AudioClip powerUp;
    [SerializeField] private AudioClip[] background;
    [SerializeField] private AudioClip[] background_Game;

    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(gameObject); 
        }
        audioSource.mute = PlayerPrefs.GetInt("MuteSFX", 0) == 1;
         
    }
    public void playCrash()
    {
        audioSource.PlayOneShot(crash);
    }
    public void playFly()
    {
        audioSource.PlayOneShot(fly);
    }
    public void playPowerUp()
    {
        audioSource.PlayOneShot(powerUp);
    }
    public void playcrash_S()
    {
        audioSource.PlayOneShot(crash_S);
    }
}
