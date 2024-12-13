using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float life = 5f; // Time before the projectile gets destroyed
    private Vector3 initialPosition; // To store the initial position of the projectile

    void Awake()
    {
        initialPosition = transform.position; // Record the starting position
        Destroy(gameObject, life); // Destroy after `life` seconds
    }

    void OnCollisionEnter(Collision collision)
    {
        // Calculate the distance from the initial position to the collision point
        float distanceTravelled = Vector3.Distance(initialPosition, transform.position);

        // Log the distance
        Debug.Log($"Projectile traveled a distance of: {distanceTravelled} units.");

        // Destroy the projectile on impact (optional)
        Destroy(gameObject);
    }
}