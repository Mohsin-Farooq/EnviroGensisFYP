using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMotion : MonoBehaviour
{
    public float speed = 0.5f;           // Speed of the pendulum swing
    public float maxAngle = 20.0f;       // Maximum angle of rotation (degrees)
    public Transform topLine;            // Reference to the top line object
    public Transform bottomLine;         // Reference to the bottom line object

    private float angle;

    void Start()
    {
        // Initialize angle (starting point of the swing)
        angle = 0;
    }

    void Update()
    {
        // Calculate the pendulum swing angle using sine for smooth motion
        angle = maxAngle * Mathf.Sin(Time.time * speed);

        // Apply rotation to both top and bottom lines (assuming they're rotated around their center)
        topLine.localRotation = Quaternion.Euler(0, 0, angle);
        bottomLine.localRotation = Quaternion.Euler(0, 0, -angle);
    }
}
