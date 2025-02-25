using UnityEngine;

public class Interactable : MonoBehaviour
{
    
    public string customMessage; 

    
    public string GetInteractionMessage()
    {
        return string.IsNullOrEmpty(customMessage) ? "Interagir com " + gameObject.name : customMessage;
    }

    public void Interact()
    {
        
        Debug.Log($"Interagiu com {gameObject.name}");
    }
}