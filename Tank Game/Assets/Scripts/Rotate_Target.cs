using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Target : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (target != null){
            Vector3 vectorToTarget = target.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle+90f, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }
    }
}
