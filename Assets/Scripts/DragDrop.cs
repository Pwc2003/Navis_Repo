using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        rectTransform.SetAsLastSibling();
        rectTransform.position = eventData.position;
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.position = eventData.position;
        Debug.Log("OnDrag");

    }

    public void OnEndDrag(PointerEventData eventData) {
        rectTransform.SetAsFirstSibling();
        rectTransform.position = eventData.position;
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData) {
        rectTransform.SetAsLastSibling();
        Debug.Log("OnPointerDown");
    }
}
