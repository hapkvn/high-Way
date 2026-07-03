using UnityEngine;
using UnityEngine.EventSystems;

public class FlyButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.instance != null)
        {
            player.instance.fly();
        }
    }
}