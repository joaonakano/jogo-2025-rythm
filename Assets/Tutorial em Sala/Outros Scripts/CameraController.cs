using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;

    public Transform pivot;

    public float maxViewAngles;
    public float minViewAngles;

    public bool invertY;
    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;

            pivot.transform.position = target.transform.position;
            //pivot.transform.parent = target.transform;
            pivot.transform.parent = null;

            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pivot.transform.position = target.transform.position;

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //pivot.Rotate(-vertical, 0, 0);
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > maxViewAngles && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngles, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngles)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngles, 0, 0);
        }

        float YAngle = pivot.eulerAngles.y;
        float XAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(XAngle, YAngle, 0);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - .5f,
                transform.position.z);
        }
        transform.LookAt(target);

    }
}