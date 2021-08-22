using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float timeDestoy = 10f;
    public float timeProtect = 0.5f;
    public float speed = 10f;
    public Animator animComponent;
    private Rigidbody2D rb;
    private float initializationTime;
    private Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        initializationTime = Time.timeSinceLevelLoad;
        rb = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<Collider2D>();
        rb.velocity = transform.up * speed;
        coll.isTrigger = true;
    }

    void Update()
    {
        if(coll != null){
            float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
            if(timeSinceInitialization >= timeDestoy)
            {
                Explosion();
            }
            if(timeSinceInitialization >= timeProtect)
            {
                coll.isTrigger = false;
            }
        }
    }
    
    void OnCollisionEnter2D()
    {
        Explosion();
    }

    void Explosion()
    {
        animComponent.SetTrigger("die");
        Destroy(coll);
        rb.bodyType = RigidbodyType2D.Static;
        Destroy(gameObject, 0.60f); 
    }
}
