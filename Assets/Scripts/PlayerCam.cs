using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float xRotation;
    public float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * 100 * Time.deltaTime;

        float mouseY = Input.GetAxisRaw("Mouse Y") * 100 * Time.deltaTime;
        yRotation += mouseX;
        xRotation -= mouseY;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
