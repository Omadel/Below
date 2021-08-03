using UnityEngine;

public class FakePlayer : MonoBehaviour {
    private Inventory inventory;
    [SerializeField] private UIInventory uIInventory;

    private void Start() {
        inventory = new Inventory();
        uIInventory.SetInventory(inventory);
    }
}
