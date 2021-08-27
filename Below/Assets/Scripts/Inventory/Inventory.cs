using System;
using System.Collections.Generic;

public class Inventory {
    public event Action OnItemListChanged;

    public List<Item> Items => items;
    private List<Item> items;

    public Inventory() => items = new List<Item>();

    public Inventory(List<Item> items) => this.items = items;

    public void AddItem(Item item) {
        if(item != null) {
            items.Add(item);
            OnItemListChanged?.Invoke();
        }
    }
    public void AddItem(string name) {
        AddItem(ItemLibrary.GetItem(name));
    }

    public void AddItems(params string[] names) {
        foreach(string name in names) {
            AddItem(name);
        }
    }
}
