using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    public List<Item> Items => items;
    private List<Item> items;

    public Inventory() {
        items = new List<Item>();
        AddItem(new Item());
        AddItem(new Item());
        AddItem(new Item());
        AddItem(new Item());
        AddItem(new Item());
        AddItem(new Item());
        AddItem(new Item());
        AddItem(new Item());
        AddItem(new Item());
        AddItem(new Item());
        Debug.Log($"Inventory {items.Count}");
    }

    public void AddItem(Item item) {
        items.Add(item);
    }
}
