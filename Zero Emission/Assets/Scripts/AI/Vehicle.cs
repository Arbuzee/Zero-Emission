using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public enum VehicleType
    {
        Car, Bike, Scooter, AutonomousCar
    }
    public VehicleType type;
    
    [SerializeField] private float minSpeed = 20f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float rotationSpeed = 400;
    [SerializeField] private float stopDistance = 3;
    [SerializeField] private Vector3 destination;

    [SerializeField] private float movementSpeed;
    private Vector3 lastPosition;

    public bool reachedDestination;

    private void Start()
    {
        movementSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopDistance)
            {
                reachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            else
            {
                reachedDestination = true;
            }
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        reachedDestination = false;
    }
}
