using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public Transform launchPoint; 
    public GameObject projectile;
    public float acceleration = 3f;
    public float initialVelocity = 2f;
    public float launchTime = 1f;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Launch();
        }
    }

    private void Launch()
    {
        // Instantiate the projectile at the launch point
        GameObject newProjectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);

        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Calculate the displacement using the formula
            float displacement = 0.5f * acceleration * launchTime * initialVelocity * launchTime;

            Vector3 launchDirection = launchPoint.up * displacement;

            // Directly set the Rigidbody's velocity
            rb.velocity = launchDirection;

            rb.AddForce(launchDirection, ForceMode.Impulse);

        }
    }
}
