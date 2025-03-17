using UnityEngine;

public class CubeController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // We'll move the cube forward
        // transform.Translate(0, 0.5f * Time.deltaTime, 1 * Time.deltaTime);
        // * Translate always change the position of an object

        // 1 seg / 60frames
        transform.Translate(Vector3.forward * Time.deltaTime * 70);
    }
}
