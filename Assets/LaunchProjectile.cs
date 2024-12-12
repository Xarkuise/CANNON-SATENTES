using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectile;
    public float initialVelocity = 3f;
    public float additionalForce = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newProjectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Set initial velocity
                rb.velocity = launchPoint.up * initialVelocity;

                // Calculate additional force vector and apply it using AddForce
                Vector3 launchDirection = launchPoint.up * additionalForce;
                rb.AddForce(launchDirection, ForceMode.Impulse);
            }
        }
    }
}
