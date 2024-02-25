using UnityEngine;

public class TableTennisBall : MonoBehaviour
{
    public float initialSpeed = 5f; // Initial speed of the ball
    public float speedIncreaseFactor = 1.05f; // Factor by which speed increases after each hit
    public float maxSpeed = 10f; // Maximum speed of the ball
    public float spinFactor = 0.5f; // Factor for applying spin to the ball
    public float gravityMultiplier = 2f; // Multiplier for gravity, to make the ball fall more realistically

    public Vector3 direction; // Direction of the ball's initial movement

    private Rigidbody rb;
    private Vector3 lastVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Start the ball moving in the specified direction with the initial speed
        rb.velocity = direction.normalized * initialSpeed;
        // Increase gravity for a more realistic ball behavior
        Physics.gravity *= gravityMultiplier;
    }

    void FixedUpdate()
    {
        // Save the current velocity to calculate spin
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the paddle
        if (collision.gameObject.CompareTag("UserPaddle"))
        {
            // Calculate the direction of the ball's bounce
            Vector3 normal = collision.contacts[0].normal;
            Vector3 newDirection = Vector3.Reflect(lastVelocity.normalized, normal).normalized;

            // Increase speed
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.velocity *= speedIncreaseFactor;
            }

            // Apply spin
            Vector3 spin = Vector3.Cross(rb.velocity, normal).normalized * spinFactor;
            rb.angularVelocity = spin;

            // Apply the new direction
            rb.velocity = newDirection * rb.velocity.magnitude;
        }
    }
}
