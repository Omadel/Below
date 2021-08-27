using Etienne;
using System.Collections.Generic;
using UnityEngine;

[UnityEngine.CreateAssetMenu(fileName = "Library", menuName = "Inventory/Library")]
public class ItemLibrary : ScriptableObjectLibrary<Item> {
    public static Dictionary<string, Item> Dictionary;

    public override void Initialize() {
#if UNITY_EDITOR
        base.Initialize();

        Dictionary = new Dictionary<string, Item>();
        foreach(Item item in library) {
            Dictionary.Add(item.name, item);
        }
#endif
    }

    public static Item GetItem(string name) {
        if(Dictionary.TryGetValue(name, out Item item)) {
            return item;
        } else {
            Debug.LogWarning($"Could not find {name} in ItemLibrary, item null");
            return null;
        }
    }
}
