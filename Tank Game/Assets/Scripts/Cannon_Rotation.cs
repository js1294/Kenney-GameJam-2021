using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Rotation : MonoBehaviour
{

    public float rotationSpeed = 200f;
    Vector3 currentAngle;
    float z;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
        {
           z = 1; 
        } 
        if (Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow))
        {
            z = -1;
        } 
        if (Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.RightArrow))
        {
            z = 0;
        }

        currentAngle += new Vector3(0, 0, z) * Time.deltaTime * rotationSpeed;
        transform.eulerAngles = currentAngle;
    }
}
