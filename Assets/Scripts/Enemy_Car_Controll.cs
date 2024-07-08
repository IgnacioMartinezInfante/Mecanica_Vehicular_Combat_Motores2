using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Car_Controll : MonoBehaviour
{
    public float motorTorque = 2000;
    public float brakeTorque = 2000;
    public float maxSpeed = 20;
    public float steeringRange = 30;
    public float steeringRangeAtMaxSpeed = 10;
    public float centreOfGravityOffset = -1f;
    public Transform playerTransform; // Referencia al transform del jugador
    public float minPauseTime = 1f; // Tiempo mínimo de pausa
    public float maxPauseTime = 3f; // Tiempo máximo de pausa

    private WheelControl[] wheels;
    private Rigidbody rigidBody;
    private Vector3 targetDirection;
    private bool isPaused;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.centerOfMass += Vector3.up * centreOfGravityOffset;
        wheels = GetComponentsInChildren<WheelControl>();
        StartCoroutine(UpdateTargetDirection());
    }

    void Update()
    {
        if (!isPaused)
        {
            float vInput = 1; // Siempre acelerando hacia adelante
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            float hInput = Vector3.Dot(transform.right, directionToPlayer) > 0 ? 1 : -1;

            float forwardSpeed = Vector3.Dot(transform.forward, rigidBody.velocity);
            float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed);
            float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);
            float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);
            bool isAccelerating = Mathf.Sign(vInput) == Mathf.Sign(forwardSpeed);

            foreach (var wheel in wheels)
            {
                if (wheel.steerable)
                {
                    wheel.WheelCollider.steerAngle = hInput * currentSteerRange;
                }

                if (isAccelerating)
                {
                    if (wheel.motorized)
                    {
                        wheel.WheelCollider.motorTorque = vInput * currentMotorTorque;
                    }
                    wheel.WheelCollider.brakeTorque = 0;
                }
                else
                {
                    wheel.WheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
                    wheel.WheelCollider.motorTorque = 0;
                }
            }
        }
    }

    IEnumerator UpdateTargetDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minPauseTime, maxPauseTime));
            targetDirection = (playerTransform.position - transform.position).normalized;
            isPaused = !isPaused;

            if (isPaused)
            {
                yield return new WaitForSeconds(Random.Range(minPauseTime, maxPauseTime));
                isPaused = !isPaused;
            }
        }
    }
}
