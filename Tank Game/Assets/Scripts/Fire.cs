using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public float timeDestroy;
    // Update is called once per frame
    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }
}
