using UnityEngine;

public class FakePlayer : MonoBehaviour {
    private Inventory inventory;
    [SerializeField] private UIInventory uIInventory;
    //[SerializeField] private List<Item> items;

    private void Start() {
        //inventory = new Inventory(items);
        inventory = new Inventory();
        inventory.AddItems("ManaPotion", "Sword", "HealthPotion", "FailTest");
        uIInventory.SetInventory(inventory);
        ItemWorld.SpawnItemWorld(Vector3.zero, "HealthPotion");
        ItemWorld.SpawnItemWorld(Vector3.right, "ManaPotion");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<ItemWorld>(out ItemWorld itemWorld)) {
            inventory.AddItem(itemWorld.Item);
            itemWorld.DestroySelf();
        }

    }
}
