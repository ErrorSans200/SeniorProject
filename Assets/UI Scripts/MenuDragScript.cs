

using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragHandler : MonoBehaviour, IDragHandler, IPointerDownHandler
{

    private RectTransform rectTransform;
    private Vector2 offset;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out offset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("im being dragged!");


        Vector2 localPointerPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform,eventData.position, eventData.pressEventCamera,out localPointerPosition))
        {
            rectTransform.localPosition = localPointerPosition - offset;
        }
    }


}
