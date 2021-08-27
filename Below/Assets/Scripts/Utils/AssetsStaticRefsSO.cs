using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AssetsStaticRefs", menuName = "Static/AssetsStaticRefs")]
public class AssetsStaticRefsSO : Etienne.InitializableScriptableObject {
    private static Dictionary<string, Object> dictionary;
    [SerializeField] private Object[] objects;

    public override void Initialize() {
        dictionary = new Dictionary<string, Object>();
        foreach(Object obj in objects) {
            dictionary.Add(obj.name, obj);
        }
    }

    public static Object GetObject(string name) {
        if(dictionary.TryGetValue(name, out Object obj)) {
            return obj;
        } else {
            Debug.LogWarning($"Could not find {name} in AssetsStaticRefsSO, object null");
            return null;
        }
    }
}
