using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onTapBegin;
    public UnityEvent onTapEnd;


    public void OnPointerDown(PointerEventData eventData)
    {
        onTapBegin.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onTapEnd.Invoke();
    }
}