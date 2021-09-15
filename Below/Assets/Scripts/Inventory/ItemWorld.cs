using UnityEngine;

public class ItemWorld : MonoBehaviour {
    public Item Item => item;
    private Item item;

    public static ItemWorld SpawnItemWorld(Vector3 position, string name) {
        return SpawnItemWorld(position, ItemLibrary.GetItem(name));
    }

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item) {
        if(item == null)
            return null;

        GameObject go = GameObject.Instantiate(AssetsStaticRefsSO.GetObject("ItemWorld") as GameObject);
        go.name = $"{item.name} ItemWorld";
        go.transform.position = position;
        go.transform.rotation = Quaternion.identity;
        Transform transform = go.transform;
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }


    public void SetItem(Item item) {
        this.item = item;
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }
        GameObject.Instantiate(item.Prefab, transform);
    }

    public void DestroySelf() {
        GameObject.Destroy(gameObject);
    }
}
