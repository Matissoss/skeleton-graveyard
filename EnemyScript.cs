using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Transform target;
    private float speed;
    private float XDistance, YDistance;
    private Rigidbody2D enemyRb;
    private int health;
    public Sprite expPickupSprite;
    private void Start()
    {
        health = Random.Range(1, 3);
        enemyRb = GetComponent<Rigidbody2D>();
        speed = Random.Range(1,3);
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("canMove") == 1)
        {
            XDistance = transform.position.x - target.transform.position.x;
            YDistance = transform.position.y - target.transform.position.y;
            if (XDistance == 0)
            {
                enemyRb.velocity = new Vector2(0, enemyRb.velocity.y);
            }
            else if (XDistance < 0)
            {
                enemyRb.velocity = new Vector2(1, enemyRb.velocity.y);
            }
            else
            {
                enemyRb.velocity = new Vector2(-1, enemyRb.velocity.y);
            }

            if (YDistance == 0)
            {
                enemyRb.velocity = new Vector2(enemyRb.velocity.x, 0);
            }
            else if (YDistance < 0)
            {
                enemyRb.velocity = new Vector2(enemyRb.velocity.x, 1);
            }
            else
            {
                enemyRb.velocity = new Vector2(enemyRb.velocity.x, -1);
            }
            enemyRb.velocity *= speed;
        }
        else
        {
            enemyRb.velocity = new Vector2(0, 0);
        }
    }
    public void SetTarget(Transform value)
    {
        target = value;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.layer == 6)
        {
            health--;
            if(health <= 0)
            {
                CreateExpPickup();
                Destroy(this.gameObject, 0.01f);
            }
        }
    }
    private void CreateExpPickup()
    {
        var expPickup = new GameObject();
        expPickup.name = "xpPickup";
        expPickup.transform.position = this.gameObject.transform.position;
        expPickup.transform.localScale = new Vector3(5f, 5f, 0);
        var expPickupRenderer = expPickup.AddComponent<SpriteRenderer>();
        expPickupRenderer.sprite = expPickupSprite;
        expPickupRenderer.color = new Color(1,1,1);
        var expPickupCollider = expPickup.AddComponent<BoxCollider2D>();
        expPickupCollider.size = new Vector2(0.1f, 0.1f);
        
        expPickupCollider.isTrigger = true;
        var expPickupRigidbody = expPickup.AddComponent<Rigidbody2D>();
        expPickupRigidbody.gravityScale = 0;
        var expPickupScript = expPickup.AddComponent<ExperiencePickupScript>();
    }
}
