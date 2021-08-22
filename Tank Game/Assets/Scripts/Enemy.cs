using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float actionTime = 0f;
    public float shootingPeriod;
    public float rotationSpeed;
    public float distance = 2.5f;
    private Vector3 currentAngle;
    private float initializationTime;
    private bool reached = false;

    void Start()
    {
        initializationTime = Time.timeSinceLevelLoad;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (target != null){

            Vector3 vectorToTarget = target.position - transform.position;
            float step =  speed * Time.deltaTime; // calculate distance to move
            if(vectorToTarget.magnitude <= distance){
                Vector3 strafe = transform.position;
                strafe.y = transform.position.y + Random.Range(-10,10);
                strafe.x = transform.position.x + Random.Range(-2,-5);
                transform.position = Vector3.MoveTowards(transform.position, strafe, step);
                reached = true;
            }
            else if((vectorToTarget.magnitude >= distance && !reached )||(vectorToTarget.magnitude >= distance + 2 && reached ))
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, step); 
            }
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
            float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
            if (timeSinceInitialization >= actionTime) {
                actionTime += shootingPeriod;
                if (vectorToTarget.magnitude <= distance+5){
                    Shoot();
                }
            }
        }
        else
        {
            float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
            transform.RotateAround(transform.position, Vector3.back, 20 * Time.deltaTime);
            if (timeSinceInitialization >= actionTime) {
                actionTime += shootingPeriod;
                Shoot();
            }
        }
    }
    

    void Shoot()
    {
        // Creates the bullet and fire
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
