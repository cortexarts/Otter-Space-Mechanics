using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject missile;
    public GameObject homingMissile;
    public Transform missileSpawn;
    public float fireRate;

    private float delay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > delay)
        {
            delay = Time.time + fireRate;
            Instantiate(missile, missileSpawn.position, missileSpawn.rotation);
        }

        if (Input.GetButton("Fire2") && Time.time > delay)
        {
            delay = Time.time + fireRate;
            Instantiate(homingMissile, missileSpawn.position, missileSpawn.rotation);
            HomingMissileMovement homingMissileMovement = homingMissile.GetComponent<HomingMissileMovement>();
            homingMissileMovement.target = GameObject.Find("Target").transform;
        }
    }
}
