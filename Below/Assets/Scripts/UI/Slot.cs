using System;
using UnityEngine.EventSystems;

namespace UnityEngine.UI {
    public class Slot : MonoBehaviour, IDropHandler {

        public event Action<PointerEventData> OnDropEvent;

        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnDrop(PointerEventData eventData) {
            Debug.Log($"Drop in {gameObject.name}");
            GameObject pointerDrag = eventData.pointerDrag;
            if(pointerDrag != null && pointerDrag.TryGetComponent<Draggable>(out draggable)) {
                draggable.IsDroppedInSlot(this, rectTransform.anchoredPosition);
            }
            OnDropEvent?.Invoke(eventData);
        }

        public void CleanSlot() {
            draggable = null;
        }

        private Draggable draggable;
        private RectTransform rectTransform;
    }
}