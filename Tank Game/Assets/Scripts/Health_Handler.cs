using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Handler : MonoBehaviour
{
    public float health;
    private Rigidbody2D rb;
    private Collider2D coll;
    public Animator animComponent;
    public Text txt;
    public Text loseText;
    public Image healthBar;
    public Image rightHealthCurved;
    public Image leftHealthCurved;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<Collider2D>();
        txt.text = "1000/"+health.ToString();
    }
    void Update()
    {
        switch(health)
        {
            case float n when (900 >= n && n > 800):
                healthBar.rectTransform.sizeDelta = new Vector2(16, 18);
                healthBar.rectTransform.anchoredPosition = new Vector2(-34, 0);
                rightHealthCurved.rectTransform.anchoredPosition = new Vector2(332, 0);
                break;
            case float n when (800 >= n && n > 700):
                healthBar.rectTransform.sizeDelta = new Vector2(14, 18);
                healthBar.rectTransform.anchoredPosition = new Vector2(-70, 0);
                rightHealthCurved.rectTransform.anchoredPosition = new Vector2(252, 0);
                break;
            case float n when (700 >= n && n > 600):
                healthBar.rectTransform.sizeDelta = new Vector2(12, 18);
                healthBar.rectTransform.anchoredPosition = new Vector2(-110, 0);
                rightHealthCurved.rectTransform.anchoredPosition = new Vector2(172, 0);
                break;
            case float n when (600 >= n && n > 500):
                healthBar.rectTransform.sizeDelta = new Vector2(10, 18);
                healthBar.rectTransform.anchoredPosition = new Vector2(-150, 0);
                rightHealthCurved.rectTransform.anchoredPosition = new Vector2(92, 0);
                break;
            case float n when (500 >= n && n > 400):
                healthBar.rectTransform.sizeDelta = new Vector2(8, 18);
                healthBar.rectTransform.anchoredPosition = new Vector2(-190, 0);
                rightHealthCurved.rectTransform.anchoredPosition = new Vector2(-14, 0);
                break;
            case float n when (400 >= n && n > 300):
                healthBar.rectTransform.sizeDelta = new Vector2(6, 18);
                healthBar.rectTransform.anchoredPosition = new Vector2(-230, 0);
                rightHealthCurved.rectTransform.anchoredPosition = new Vector2(-88, 0);
                break;
            case float n when (300 >= n && n > 200):
                healthBar.rectTransform.sizeDelta = new Vector2(4, 18);
                healthBar.rectTransform.anchoredPosition = new Vector2(-270, 0);
                rightHealthCurved.rectTransform.anchoredPosition = new Vector2(-156, 0);
                break;
            case float n when (200 >= n && n > 100):
                healthBar.rectTransform.sizeDelta = new Vector2(2, 18);
                healthBar.rectTransform.anchoredPosition = new Vector2(-310, 0);
                rightHealthCurved.rectTransform.anchoredPosition = new Vector2(-224, 0);
                break;
            case float n when (100 >= n && n > 0):
                healthBar.rectTransform.sizeDelta = new Vector2(0, 0);
                rightHealthCurved.rectTransform.anchoredPosition = new Vector2(-304, 0);
                break;
        }

        if (health <= 0)
        {
            healthBar.rectTransform.sizeDelta = new Vector2(0, 0);
            rightHealthCurved.rectTransform.sizeDelta = new Vector2(0, 0);
            leftHealthCurved.rectTransform.sizeDelta = new Vector2(0, 0);
            txt.text = "1000/0";
            Explosion();
            loseText.text = "You Lose!";
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Small Enemy Bullet")
        {
            health -= 4 + Random.Range(0,1);
        }
        if (collision.gameObject.tag == "Enemy Bullet")
        {
            health -= 8 + Random.Range(0,5);
        }
        if (collision.gameObject.tag == "Bomb")
        {
            health -= 10 + Random.Range(2,11);
        }
        txt.text = "1000/"+health.ToString();
    }
    void Explosion()
    {
        animComponent.SetTrigger("die");
        Destroy(gameObject, 0.60f); 
    }
}
