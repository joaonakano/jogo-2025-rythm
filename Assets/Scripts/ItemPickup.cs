using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData itemData;

    private void OnTriggerEnter(Collider other)     // Errei o "private void OnTriggerEnter(Collider other)" por "public void PickupItem(Collider other)"
    {
        if (other.CompareTag("Player")) {
            Inventory inventory = other.GetComponent<Inventory>();  // Esqueci de como pegar o inventário do personagem que interagiu com o ScriptableObject, mas é "other.GetComponent<Inventory>();"

            if (inventory != null)  // Esqueci do "inventory != null"
            {
                Debug.Log($"Você pegou o item '{itemData.itemName}' e ele foi armazenado no inventário!");
                Destroy(gameObject);
                inventory.AddItem(itemData);
            } else
            {
                Debug.LogWarning("O personagem que interagiu com o objeto não tem o Inventory3D!");
            }
        }
    }
}
