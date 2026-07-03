using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioToggleButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    // Tạo một menu thả xuống ngoài Inspector để chọn nhiệm vụ cho nút
    public enum AudioType { NhacNen_BGM, HieuUng_SFX }

    [Header("CÀI ĐẶT CHỨC NĂNG NÚT")]
    public AudioType targetAudio;

    [Header("Trạng thái BẬT ÂM THANH (Loa thường)")]
    public Sprite unmutedNormal;
    public Sprite unmutedPressed;

    [Header("Trạng thái TẮT ÂM THANH (Loa gạch chéo)")]
    public Sprite mutedNormal;
    public Sprite mutedPressed;

    private Image myImage;
    private bool isMuted = false;

    private string GetPrefsKey()
    {
        return targetAudio == AudioType.NhacNen_BGM ? "MuteBGM" : "MuteSFX";
    }

    private void Start()
    {
        myImage = GetComponent<Image>();

        isMuted = PlayerPrefs.GetInt(GetPrefsKey(), 0) == 1;

        ApplyAudioState();
        UpdateVisualNormal();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (myImage != null)
        {
            myImage.sprite = isMuted ? mutedPressed : unmutedPressed;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UpdateVisualNormal();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isMuted = !isMuted;

        PlayerPrefs.SetInt(GetPrefsKey(), isMuted ? 1 : 0);
        PlayerPrefs.Save();

        ApplyAudioState();
        UpdateVisualNormal();
    }

    private void UpdateVisualNormal()
    {
        if (myImage != null)
        {
            myImage.sprite = isMuted ? mutedNormal : unmutedNormal;
        }
    }

    private void ApplyAudioState()
    {
        if (targetAudio == AudioType.NhacNen_BGM)
        {
            if (BGMManager.instance != null)
            {
                BGMManager.instance.GetComponent<AudioSource>().mute = isMuted;
            }
        }
        else if (targetAudio == AudioType.HieuUng_SFX)
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.GetComponent<AudioSource>().mute = isMuted;
            }
        }
    }
}