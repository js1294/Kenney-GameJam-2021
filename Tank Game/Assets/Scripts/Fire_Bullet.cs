using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Bullet : MonoBehaviour
{
    public Transform firePoint;
    private Quaternion bulletRotation;
    public GameObject bulletPrefab;
    public GameObject firePrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
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