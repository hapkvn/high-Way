using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonImageSwap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Image myImage;

    [Header("Kéo thả 2 bức ảnh vào đây")]
    public Sprite normalSprite;  // Ảnh lúc bình thường (Nổi)
    public Sprite pressedSprite; // Ảnh lúc bị nhấn (Lún)

    private void Start()
    {
        // Tự động tìm Component Image đang gắn trên nút này
        myImage = GetComponent<Image>();

        // Đảm bảo lúc mới vào game, nút hiển thị ảnh bình thường
        if (myImage != null && normalSprite != null)
        {
            myImage.sprite = normalSprite;
        }
    }

    // Khi VỪA CHẠM ngón tay vào
    public void OnPointerDown(PointerEventData eventData)
    {
        if (myImage != null && pressedSprite != null)
        {
            myImage.sprite = pressedSprite; // Tráo thành ảnh lún
        }
    }

    // Khi NHẢ ngón tay ra
    public void OnPointerUp(PointerEventData eventData)
    {
        if (myImage != null && normalSprite != null)
        {
            myImage.sprite = normalSprite; // Trả lại ảnh nổi
        }
    }
}