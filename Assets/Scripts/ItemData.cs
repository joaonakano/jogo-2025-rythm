using UnityEngine;

// Errei o "filename = NewItem" por ItemData
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string description;
    public GameObject itemModel;    // Errei o "public GameObject itemModel" por gameObject
}
