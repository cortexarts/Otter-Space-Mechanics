using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    Vector3 veloctiy = Vector3.zero;

    float acceleration = 4.0f;

    float maxVelocity = 1.0f;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            veloctiy += transform.forward * acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -50 * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 50 * Time.deltaTime, 0));
        }

        veloctiy = Vector3.ClampMagnitude(veloctiy, maxVelocity);

        transform.position += veloctiy;

        Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (screenPosition.y < 0)
        {
            screenPosition.y = 1;
        }
        else if (screenPosition.y > 1)
        {
            screenPosition.y = 0;
        }

        if (screenPosition.x < 0)
        {
            screenPosition.x = 1;
        }
        else if (screenPosition.x > 1)
        {
            screenPosition.x = 0;
        }

        transform.position = mainCamera.ViewportToWorldPoint(screenPosition);
    }
}
