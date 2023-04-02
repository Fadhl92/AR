using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed; // Speed of dragon's movement

    private FixedJoystick fixedJoystick; // Reference to the joystick controller
    private Rigidbody rigidBody; // Reference to the dragon's Rigidbody component

    private void OnEnable()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>(); // Find the FixedJoystick component in the scene
        rigidBody = gameObject.GetComponent<Rigidbody>(); // Get the dragon's Rigidbody component
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal; // Get the joystick's horizontal input value
        float yVal = fixedJoystick.Vertical; // Get the joystick's vertical input value

        Vector3 movement = new Vector3(xVal, 0, yVal); // Create a Vector3 movement direction based on joystick input
        rigidBody.velocity = movement * speed; // Move the dragon using Rigidbody velocity

        if (xVal != 0 && yVal != 0) // If joystick input is detected in both horizontal and vertical axes
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z); // Rotate the dragon towards the joystick's direction
    }
}

