using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

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
        rigidbody2d.AddRelativeForce(Vector2.up * movementSpeed * Time.fixedDeltaTime);
    }
}
