using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileMovement : MonoBehaviour
{
    public Transform target;
    public float angleChangingSpeed;
    public float movementSpeed;

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
        
    }

    // FixedUpdate is called every fixed frame-rate frame
    private void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("No target found!");
            return;
        }

        Vector2 direction = (Vector2)target.position - rigidbody2d.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rigidbody2d.angularVelocity = -angleChangingSpeed * rotateAmount;
        rigidbody2d.velocity = transform.up * movementSpeed * Time.fixedDeltaTime;
    }
}
