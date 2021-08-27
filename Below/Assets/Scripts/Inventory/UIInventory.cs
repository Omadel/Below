using Etienne;
using UnityEngine;
public class UIInventory : MonoBehaviour {
    //todo https://youtu.be/2WnAOV7nHW0?t=920;
    //https://www.youtube.com/watch?v=E91NYvDqsy8

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
        inventory.OnItemListChanged += RefreshInvetoryItems;
        RefreshInvetoryItems();
    }

    private void RefreshInvetoryItems() {
        foreach(Transform child in itemSlotsContainer) {
            if(child == itemSlotTemplate) continue;
            GameObject.Destroy(child.gameObject);
        }
        int x = 0, y = 0;
        foreach(Item item in inventory.Items) {
            Transform itemSlot = Instantiate(itemSlotTemplate, itemSlotsContainer);
            itemSlot.name = "ItemSlot";
            UnityEngine.UI.Image image = itemSlot.Find("Image").GetComponent<UnityEngine.UI.Image>();
            image.sprite = item.Sprite;
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
