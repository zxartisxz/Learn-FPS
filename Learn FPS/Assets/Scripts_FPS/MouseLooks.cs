using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooks : MonoBehaviour
{

    public float mouseSensitivity = 2000f;

    public Transform playerBody;
    private bool mouseLock = true;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Sets maximum rotation around x axis

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.I) && mouseLock)
        {
            Cursor.lockState = CursorLockMode.Confined;
            mouseLock = false;
        }
        else if(Input.GetKeyDown(KeyCode.I) && !mouseLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            mouseLock = true;
        }

    }
}
