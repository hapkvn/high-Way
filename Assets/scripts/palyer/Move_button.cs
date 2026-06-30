using UnityEngine;
using UnityEngine.EventSystems;

public class Move_button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float valueX;
    public float valueY;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (valueX != 0) player.instance.setMoveX(valueX);
        if (valueY != 0) player.instance.setMoveY(valueY);
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (valueX != 0) player.instance.setMoveX(0);
        if (valueY != 0) player.instance.setMoveY(0);
    }
}
