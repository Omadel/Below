using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
    public Sprite Sprite => sprite;
    public GameObject Prefab => prefab;

    [SerializeField, Etienne.PreviewSprite] private Sprite sprite;
    [SerializeField] private GameObject prefab;
}
