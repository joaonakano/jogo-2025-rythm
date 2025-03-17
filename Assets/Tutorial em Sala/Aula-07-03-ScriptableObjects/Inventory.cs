using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemData, int> inventory = new Dictionary<ItemData, int>();

    public void AddItem(ItemData newItem)
    {
        if (inventory.ContainsKey(newItem)) {
            inventory[newItem]++;
        } else
        {
            inventory.Add(newItem, 1);  // Errei o "inventory.Add(newItem, 1)" por inventory[newItem] = 1
        }
        Debug.Log($"O item '{newItem.itemName}' foi adicionado ao inventário! Quantidade: {inventory[newItem]}");
    }

    public void ShowInventory()
    {
        Debug.Log("Inventário:");
        foreach (KeyValuePair<ItemData, int> item in inventory)     // Errei o "KeyValuePair<ItemData, int> item" por "KeyValuePair<ItemData, int> as item
        {
            Debug.Log($"{item.Key.itemName} - Quantidade: {item.Value}");
        }
    }

    public int GetItemCount(ItemData item)
    {
        if (inventory.ContainsKey(item))
        {
            return inventory[item];
        } else
        {
            return 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }
    }
}
