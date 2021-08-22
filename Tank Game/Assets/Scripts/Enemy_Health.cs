using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public float health;
    private Rigidbody2D rb;
    private Collider2D coll;
    public Animator animComponent;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<Collider2D>();
    }
    void Update()
    {
        if (health <= 0)
        {
            Explosion();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Shell")
        {
            health -= 10;
        }
    }
    void Explosion()
    {
        animComponent.SetTrigger("die");
        Destroy(gameObject, 0.60f); 
    }
}
