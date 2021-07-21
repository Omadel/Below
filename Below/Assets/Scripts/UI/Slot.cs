using System;
using UnityEngine.EventSystems;

namespace UnityEngine.UI {
    [RequireComponent(typeof(CanvasGroup))]
    public class Slot : MonoBehaviour, IDropHandler {
        public Draggable Draggable => draggable;

        public event Action<PointerEventData> OnDropEvent;
        public event Action OnClearedEvent;

        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnDrop(PointerEventData eventData) {
            Debug.Log($"Drop in {gameObject.name}");
            GameObject pointerDrag = eventData.pointerDrag;
            if(pointerDrag != null && pointerDrag.TryGetComponent<Draggable>(out draggable)) {
                draggable.IsDroppedInSlot(this, rectTransform.position);
                canvasGroup.blocksRaycasts = false;
            }
            OnDropEvent?.Invoke(eventData);
        }

        public void CleanSlot() {
            canvasGroup.blocksRaycasts = true;
            draggable = null;
            OnClearedEvent?.Invoke();
        }

        private CanvasGroup canvasGroup;
        private Draggable draggable;
        private RectTransform rectTransform;
    }
}