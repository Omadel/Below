using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slot), typeof(Image))]
public class Item : Draggable {
    public Image image;
    protected override void Awake() {
        base.Awake();
        selfSlot = GetComponent<Slot>();
        image = GetComponent<Image>();
        selfSlot.OnDropEvent += Slot_OnDropEvent;
    }

    private void Slot_OnDropEvent(UnityEngine.EventSystems.PointerEventData eventData) {
        if(eventData.pointerDrag.TryGetComponent<Item>(out Item item)) {
            image.color = (image.color + item.image.color) / 2;
            GameObject.Destroy(item.gameObject);
        }
    }

    private Slot selfSlot;
}
