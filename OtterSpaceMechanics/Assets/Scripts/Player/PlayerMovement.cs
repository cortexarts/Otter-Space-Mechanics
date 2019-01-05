using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float maxForce = 10.0f;

    [SerializeField]
    private float forceMultiplier = 1.0f;

    [SerializeField]
    private Vector2 relativeForce = Vector2.zero;

    [SerializeField]
    private float rotation;

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        if (rigidbody2d == null)
        {
            Debug.LogWarning("No Rigidbody2D found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    // FixedUpdate is called every fixed frame-rate frame
    private void FixedUpdate()
    {
        relativeForce.y = verticalInput * forceMultiplier * Time.fixedDeltaTime;
        relativeForce.y = Mathf.Clamp(relativeForce.y, 0.0f, maxForce);

        rigidbody2d.AddRelativeForce(relativeForce);

        // TODO: Rotation clamping or wrapping
        rotation = rigidbody2d.rotation - (horizontalInput * forceMultiplier * Time.fixedDeltaTime);

        rigidbody2d.MoveRotation(rotation);
    }
}
