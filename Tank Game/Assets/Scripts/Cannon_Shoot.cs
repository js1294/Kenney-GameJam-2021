using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Shoot : MonoBehaviour
{

    public Transform firePoint;
    private Quaternion bulletRotation;
    public GameObject bulletPrefab;
    public GameObject firePrefab;
    public Transform target;
    private float actionTime = 0f;
    private float initializationTime;
    public float shootingPeriod;
    public float distance = 8f;

    // Update is called once per frame
    void Update()
    {
        float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
        if (timeSinceInitialization >= actionTime) {
                actionTime += shootingPeriod;
                Vector3 vectorToTarget = target.position - transform.position;
            if(distance >= vectorToTarget.magnitude)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        bulletRotation = firePoint.rotation * new Quaternion(0,0,-1,0);
        // Creates the bullet and fire
        Instantiate(bulletPrefab, firePoint.position, bulletRotation);
        Instantiate(firePrefab, firePoint.position, firePoint.rotation);
    }
}
