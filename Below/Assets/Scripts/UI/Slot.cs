using UnityEngine.EventSystems;

namespace UnityEngine.UI {
    public class Slot : MonoBehaviour, IDropHandler {
        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnDrop(PointerEventData eventData) {
            Debug.Log("Drop");
            GameObject pointerDrag = eventData.pointerDrag;
            if(pointerDrag != null) {
                Draggable draggable = pointerDrag.GetComponent<Draggable>();
                draggable.IsDroppedInSlot();
                draggable.Snap(rectTransform.anchoredPosition);
            }
        }

        private RectTransform rectTransform;
    }
}