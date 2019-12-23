using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerlook : MonoBehaviour
{
    // Getting the mouse inputs
    [SerializeField] private string mouseXname, mouseYname;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;

    //clamp the camera
    private float xAxisclmap;

    private void Awake()
    {
        Lockcursor();
        xAxisclmap = 0.0f;
    }
    private void Lockcursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXname) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYname) * mouseSensitivity * Time.deltaTime;

        xAxisclmap += mouseY;
        
        if(xAxisclmap > 90.0f)
        {
            xAxisclmap = 90.0f;
            mouseY = 0.0f;
            ClampxAxisR(270.0f);
        }

        else if (xAxisclmap < -90.0f)
        {
            xAxisclmap = -90.0f;
            mouseY = 0.0f;
            ClampxAxisR(90.0f);
        }

        transform.Rotate(Vector3.left* mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampxAxisR(float value)
    {
        Vector3 eulerR = transform.eulerAngles;
        eulerR.x = value;
        transform.eulerAngles = eulerR;
    }

}