using Etienne;
using UnityEngine;
public class UIInventory : MonoBehaviour {
    //todo https://youtu.be/2WnAOV7nHW0?t=496;

    private Inventory inventory;
    private Transform itemSlotsContainer, itemSlotTemplate;
    private RectTransform itemSlotsContainerRectTransform, itemSlotTemplateRectTransform;
    private Vector2 itemSlotCellSize;

    private void Awake() {
        itemSlotsContainer = transform.Find("ItemSlotsContainer");
        itemSlotsContainerRectTransform = itemSlotsContainer.GetComponent<RectTransform>();
        itemSlotTemplate = itemSlotsContainer.Find("itemSlotTemplate");
        itemSlotTemplateRectTransform = itemSlotTemplate.GetComponent<RectTransform>();
        itemSlotCellSize = new Vector2(itemSlotTemplateRectTransform.rect.width, itemSlotTemplateRectTransform.rect.height);
    }

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        RefreshInvetoryItems();
    }

    private void RefreshInvetoryItems() {
        int x = 0, y = 0;
        foreach(Item item in inventory.Items) {
            Transform itemSlot = Instantiate(itemSlotTemplate, itemSlotsContainer);
            itemSlot.name = "ItemSlot";
            RectTransform itemSlotRectTransform = itemSlot.GetComponent<RectTransform>();
            itemSlotRectTransform.anchoredPosition = new Vector2(x, -y).Multiply(itemSlotCellSize);
            itemSlotRectTransform.gameObject.SetActive(true);
            x++;
            bool needNewLine = x * itemSlotCellSize.x >= itemSlotsContainerRectTransform.rect.width;
            if(needNewLine) {
                x = 0;
                y++;
            }
        }
    }

}
