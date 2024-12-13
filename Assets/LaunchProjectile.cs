using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public Transform launchPoint; // Point from which the projectile is launched
    public GameObject projectile; // Prefab of the projectile
    public float acceleration = 3f; // Acceleration applied to the projectile
    public float initialVelocity = 2f; // Initial velocity of the projectile
    public float launchTime = 1f; // Time duration of the launch

    private void Update()
    {
        // Launch the projectile when space or left mouse button is pressed
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Launch();
        }
    }

    private void Launch()
    {
        // Instantiate the projectile at the launch point
        GameObject newProjectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);

        // Ensure the projectile has a Rigidbody
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Calculate the displacement using the formula
            float displacement = 0.5f * acceleration * launchTime * initialVelocity * launchTime;

            // Determine the velocity vector based on displacement and scaling factor
            Vector3 launchDirection = launchPoint.up * displacement;

            // Directly set the Rigidbody's velocity
            rb.velocity = launchDirection;

            rb.AddForce(launchDirection, ForceMode.Impulse);

        }
    }
}
