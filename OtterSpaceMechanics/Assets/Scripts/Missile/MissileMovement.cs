using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public float missileSpeed;
    public float missileTilt;

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
    void FixedUpdate()
    {
        rigidbody2d.velocity = Vector2.up * missileSpeed * Time.fixedDeltaTime;
        rigidbody2d.rotation = rigidbody2d.velocity.x * -missileTilt;
    }
}
