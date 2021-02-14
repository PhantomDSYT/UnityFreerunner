using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera mainCamera;

    private bool jumKey;
    private Rigidbody rigidbodyComp;
    private float speed = 3;
    private float horizontalInput;
    private float verticalInput;
    private float facing;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComp = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumKey = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        facing = mainCamera.transform.eulerAngles.y;
    }

    private void FixedUpdate()
    {
        Vector3 inputVector = new Vector3(horizontalInput * speed, rigidbodyComp.velocity.y, verticalInput * speed);
        Vector3 turnedInput = Quaternion.Euler(0, facing, 0) * inputVector;
        rigidbodyComp.velocity = turnedInput;

        if (jumKey)
        {
            rigidbodyComp.AddForce(Vector3.up * 9, ForceMode.VelocityChange);
            jumKey = false;
        }
    }
}
