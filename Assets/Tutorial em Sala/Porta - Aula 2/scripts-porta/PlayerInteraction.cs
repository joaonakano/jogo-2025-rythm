using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 2.0f; 
    public LayerMask interactionLayer;    
    public KeyCode interactionKey = KeyCode.E;  

    public GameObject interactionUI;      
    public TextMeshProUGUI interactionText; 

    private Interactable currentInteractable;  

    void Update()
    {
       
        Collider[] interactablesInRange = Physics.OverlapSphere(transform.position, interactionRange, interactionLayer);

        if (interactablesInRange.Length > 0)
        {
            
            currentInteractable = interactablesInRange[0].GetComponent<Interactable>();

            if (currentInteractable != null)
            {
               
                ShowInteractionUI(true, currentInteractable.GetInteractionMessage());

                
                if (Input.GetKeyDown(interactionKey))
                {
                    currentInteractable.Interact(); 
                }
            }
            else
            {
               
                Animatable currentAnimatable = interactablesInRange[0].GetComponent<Animatable>();
                if (currentAnimatable != null)
                {
                   
                    ShowInteractionUI(true, currentAnimatable.GetInteractionMessage());

                   
                    if (Input.GetKeyDown(interactionKey))
                    {
                        currentAnimatable.Interact();  
                    }
                }
            }
        }
        else
        {
            
            currentInteractable = null;
            ShowInteractionUI(false);
        }
    }

    private void ShowInteractionUI(bool state, string message = "")
    {
        if (interactionUI != null)
        {
            interactionUI.SetActive(state);  

            if (state && interactionText != null)
            {
                interactionText.text = message;  
            }
        }
    }

   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);  
    }
}