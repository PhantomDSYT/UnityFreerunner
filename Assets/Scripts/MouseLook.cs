using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    internal static Camera main;
    private float pitch = 0.0f;
    private float yaw = 0.0f;
    private float XRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        yaw = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        pitch = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        XRotation -= pitch;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * yaw);
        
    }
}
