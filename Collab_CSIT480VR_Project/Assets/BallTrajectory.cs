using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrajectory : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform ballTransform;
    public int lineSegment = 5; // Number of line segments to represent the trajectory
    public float simulationTime = 2f; // Simulation time in seconds

    private Rigidbody ballRigidbody;

    void Start()
    {
        ballRigidbody = ballTransform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (ballRigidbody.velocity.magnitude > 0.3f) // Only draw trajectory when the ball is moving
        {
            DrawTrajectory();
        }
        else
        {
            lineRenderer.positionCount = 0; // Clear the line renderer when the ball is not moving
        }
    }

    void DrawTrajectory()
    {
        Vector3[] points = new Vector3[lineSegment + 1];
        Vector3 currentVelocity = ballRigidbody.velocity;
        Vector3 currentPosition = ballTransform.position;

        for (int i = 0; i <= lineSegment; i++)
        {
            float time = (float)i / lineSegment * simulationTime;
            points[i] = currentPosition + currentVelocity * time + 0.5f * Physics.gravity * time * time;
        }

        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
    }
}