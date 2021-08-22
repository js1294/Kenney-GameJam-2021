using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_move : MonoBehaviour
{

    public float xSpeed;
    public float ySpeed;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(xSpeed ,ySpeed , 0, Space.World);
    }
}
