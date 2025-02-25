using UnityEngine;

public class ColorChange : MonoBehaviour, IInteractable
{
    Material mat;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    public string GetDescription()
    {
        return "Altera pra uma Cor Aleatória.";
    }

    public void Interact()
    {
        mat.color = new Color(Random.value, Random.value, Random.value);
    }
}
