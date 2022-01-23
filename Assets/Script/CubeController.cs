using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float rotationSpeed = 30f;
    private float verticalInput;
    private float horizontalInput;
    private bool sizeInput;

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        sizeInput = Input.GetButton("Jump");

        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
        transform.Rotate(Vector3.right, rotationSpeed * verticalInput * Time.deltaTime);

        if (sizeInput == true) // If space is pressed the size will increase w.r.p to time
        {
            transform.localScale = transform.localScale + new Vector3(1, 1, 1) * Time.deltaTime;
        }
        else if (transform.localScale.x > 1.01f && transform.localScale.y > 1.01f && transform.localScale.z > 1.01f && !Input.GetKeyDown(KeyCode.F)) // Start decreasing size when space is disabled
        {
            transform.localScale = transform.localScale - new Vector3(1, 1, 1) * Time.deltaTime;
        }
        // For making sure cube is in perfect (1,1,1) not (1..., 1..., 1...)
        else if (transform.localScale.x <= 1.01f && transform.localScale.y <= 1.01f && transform.localScale.z <= 1.01f && !Input.GetKeyDown(KeyCode.F)) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.F)) // When F key is pressed cube will go to its original size and rotation value
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.identity;
        }

    }
}
