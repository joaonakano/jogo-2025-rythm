using UnityEngine;

public class Animatable : MonoBehaviour
{
    public Animator objectAnimator;  
    public string animationBoolParam; 
    public string customMessage;    


    public string GetInteractionMessage()
    {
        return string.IsNullOrEmpty(customMessage) ? "Interagir com " + gameObject.name : customMessage;
    }


    public virtual void Interact()
    {
        if (objectAnimator != null)
        {
           
            bool currentState = objectAnimator.GetBool(animationBoolParam);
            objectAnimator.SetBool(animationBoolParam, !currentState); 

            Debug.Log($"Estado da animação alterado para {(!currentState)} em {gameObject.name}");
        }
        else
        {
            Debug.LogWarning("Animator não encontrado no objeto!");
        }
    }
}