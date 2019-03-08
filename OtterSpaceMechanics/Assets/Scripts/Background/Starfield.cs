using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Starfield : MonoBehaviour
{
    public float parallaxFactor;
    public int MaxStars = 100;
    public float StarSize = 0.1f;
    public float starSizeRange = 0.5f;
    public float fieldWidth = 20f;
    public float fieldHeight = 25f;
    public bool colorize = false;

    private ParticleSystem m_particleSystem;
    private ParticleSystem.Particle[] stars;
    private Transform mainCameraTransform;
    private float xOffset;
    private float yOffset;

    // Used to initialize any variables or game state before the game start
    void Awake()
    {
        stars = new ParticleSystem.Particle[MaxStars];
        m_particleSystem = GetComponent<ParticleSystem>();

        Assert.IsNotNull(m_particleSystem, "Particle system missing from object!");

        xOffset = fieldWidth * 0.5f; // Offset the coordinates to distribute the spread
        yOffset = fieldHeight * 0.5f; // around the object's center

        for (int i = 0; i < MaxStars; i++)
        {
            float randSize = Random.Range(starSizeRange, starSizeRange + 1f); // Randomize star size within parameters
            float scaledColor = (true == colorize) ? randSize - starSizeRange : 1f; // If coloration is desired, color based on size

            stars[i].position = GetRandomInRectangle(fieldWidth, fieldHeight) + transform.position;
            stars[i].startSize = StarSize * randSize;
            stars[i].startColor = new Color(1f, scaledColor, scaledColor, 1f);
        }

        m_particleSystem.SetParticles(stars, stars.Length); // Write data to the particle system
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < MaxStars; i++)
        {
            Vector3 pos = stars[i].position + transform.position;

            if (pos.x < (mainCameraTransform.position.x - xOffset))
            {
                pos.x += fieldWidth;
            }
            else if (pos.x > (mainCameraTransform.position.x + xOffset))
            {
                pos.x -= fieldWidth;
            }

            if (pos.y < (mainCameraTransform.position.y - yOffset))
            {
                pos.y += fieldHeight;
            }
            else if (pos.y > (mainCameraTransform.position.y + yOffset))
            {
                pos.y -= fieldHeight;
            }

            stars[i].position = pos - transform.position;
        }

        m_particleSystem.SetParticles(stars, stars.Length);

        Vector3 newPos = mainCameraTransform.position * parallaxFactor; // Calculate the position of the object
        newPos.z = 0; // Force Z-axis to zero, since we're in 2D
        transform.position = newPos;
    }

    // Get a random value within a certain rectangle area
    private Vector3 GetRandomInRectangle(float width, float height)
    {
        float x = Random.Range(0, width);
        float y = Random.Range(0, height);
        return new Vector3(x - xOffset, y - yOffset, 0);
    }
}
