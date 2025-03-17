using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public float rotationSpeed = 720;

    private UnityEngine.CharacterController characterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<UnityEngine.CharacterController>();

        if (characterController == null)
        {
            Debug.LogWarning("CharacterController component not found!");
        }

    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;

        //transform.Translate(movementDirection * Time.deltaTime * magnitude, Space.World);
        characterController.SimpleMove(movementDirection * magnitude);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}