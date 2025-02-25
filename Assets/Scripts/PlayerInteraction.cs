<<<<<<< Updated upstream
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 2f;
    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;


    private void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        bool hitSomething = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                hitSomething = true;
                interactionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class PlayerInteraction : MonoBehaviour {
 
    public Camera mainCam;
    public float interactionDistance = 2f;
 
    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;
 
 
    private void Update() {
        InteractionRay();
    }
 
    void InteractionRay() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
 
        bool hitSomething = false;
 
        if (Physics.Raycast(ray, out hit, interactionDistance)) {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
 
            if (interactable != null) {
                hitSomething = true;
                interactionText.text = interactable.GetDescription();
 
                if (Input.GetKeyDown(KeyCode.E)) {
>>>>>>> Stashed changes
                    interactable.Interact();
                }
            }
        }
<<<<<<< Updated upstream
        interactionUI.SetActive(hitSomething);
    }
}
=======
 
        interactionUI.SetActive(hitSomething);
    }
}
>>>>>>> Stashed changes
