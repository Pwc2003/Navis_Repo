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
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        rectTransform.SetAsFirstSibling();
        rectTransform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData) {
        rectTransform.SetAsLastSibling();
    }
}
