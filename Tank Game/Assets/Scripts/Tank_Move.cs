using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Move : MonoBehaviour
{

    public Transform target;
    public Transform left;
    public Transform right;
    public float rotationSpeed;
    public float speed;
    public float strafeSpeed;
    public float distance;
    private bool reached = false;
    void Update()
    {
        if (target != null){
            Vector3 vectorToTarget = target.position - transform.position;
            float step =  speed * Time.deltaTime; // calculate distance to move
            if (vectorToTarget.magnitude >= distance && !reached)
            {
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle+90f, Vector3.forward);
                transform.rotation = q;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
            else
            {
                reached = true;
                step = strafeSpeed * Time.deltaTime; // calculate distance to move
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
                if (transform.rotation == q && Random.Range(0,2) == 1)
                {
                    transform.position = Vector3.MoveTowards(transform.position,left.position,step);
                }
                else if (transform.rotation == q)
                {
                    transform.position = Vector3.MoveTowards(transform.position,right.position,step);
                }
            }
        }
    }
}
