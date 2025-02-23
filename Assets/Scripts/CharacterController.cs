using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody rigidB;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public Animator Animate;

    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

    // Start is called before the first frame update
    void Start()
    {
        //rigidB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        // rigidB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rigidB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        /*
         if(Input.GetButtonDown("Jump"))
         {
             rigidB.velocity = new Vector3(rigidB.velocity.x, jumpForce, rigidB.velocity.z);

         }
         */
        // moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) 
            + (transform.right * Input.GetAxis("Horizontal")) ;
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        Animate.SetBool("isGrounded", controller.isGrounded);

        Animate.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
}