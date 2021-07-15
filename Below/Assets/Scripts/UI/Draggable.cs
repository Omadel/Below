using DG.Tweening;
using UnityEngine.EventSystems;

namespace UnityEngine.UI {
    [RequireComponent(typeof(CanvasGroup))]
    public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler {
        [SerializeField] private Canvas canvas;
        [SerializeField] private bool isFree = false;
        [SerializeField] private float normalAlpha = 1f, dragAlpha = .6f;
        [SerializeField] private float fadeDuration = .1f;
        [SerializeField] private float moveDuration = .1f;

        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnPointerDown(PointerEventData eventData) {
            Debug.Log("Pointer Down");
        }

        public void OnDrag(PointerEventData eventData) {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnBeginDrag(PointerEventData eventData) {
            Debug.Log("Drag Begin");
            canvasGroup.blocksRaycasts = false;
            canvasGroup.DOComplete();
            canvasGroup.DOFade(dragAlpha, fadeDuration);
            oldPosition = rectTransform.anchoredPosition;
            canMove = false;
        }

        public void OnEndDrag(PointerEventData eventData) {
            Debug.Log("Drag Ended");
            canvasGroup.blocksRaycasts = true;
            canvasGroup.DOComplete();
            canvasGroup.DOFade(normalAlpha, fadeDuration);
            if(!isFree && !canMove) {
                Snap(oldPosition);
            }
        }

        public void Snap(Vector2 position) {
            rectTransform.DOAnchorPos(position, moveDuration);
        }

        public void IsDroppedInSlot() {
            canMove = true;
        }

        private bool canMove = false;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private Vector2 oldPosition;
    }
}