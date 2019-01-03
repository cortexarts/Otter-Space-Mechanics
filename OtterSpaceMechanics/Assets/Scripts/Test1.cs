using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    public float verticalInputAcceleration = 1;
    public float horizontalInputAcceleration = 20;

    public float maxSpeed = 10;
    public float maxRotationSpeed = 100;

    public float velocityDrag = 1;
    public float rotationDrag = 1;

    [SerializeField]
    private float linearVelocity;

    private Vector3 velocity;
    private float zRotationVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Apply forward input
        Vector3 acceleration = Input.GetAxis("Vertical") * verticalInputAcceleration * transform.up;
        velocity += acceleration * Time.deltaTime;

        // Apply turn input
        float zTurnAcceleration = -1 * Input.GetAxis("Horizontal") * horizontalInputAcceleration;
        zRotationVelocity += zTurnAcceleration * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        // Apply velocity drag
        velocity = velocity * (1 - Time.fixedDeltaTime * velocityDrag);

        // Clamp to maxSpeed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        linearVelocity = velocity.sqrMagnitude;

        // Apply rotation drag
        zRotationVelocity = zRotationVelocity * (1 - Time.fixedDeltaTime * rotationDrag);

        // Clamp to maxRotationSpeed
        zRotationVelocity = Mathf.Clamp(zRotationVelocity, -maxRotationSpeed, maxRotationSpeed);

        // Update transform
        transform.position += velocity * Time.fixedDeltaTime;
        transform.Rotate(0, 0, zRotationVelocity * Time.fixedDeltaTime);
    }
}
