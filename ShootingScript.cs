using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private Sprite bulletSprite;
    [SerializeField] private int speed;
    public void Fire(int direction)
    {
        var bullet = new GameObject();
        bullet.name = "Bullet";
        bullet.tag = "Bullet";
        bullet.layer = 6;
        bullet.transform.position = this.gameObject.transform.position;
        bullet.transform.localScale = new Vector3(10f, 10f, 1);
        var bulletCollider = bullet.AddComponent<BoxCollider2D>();
        bulletCollider.size = new Vector2(0.1f, 0.1f);
        bulletCollider.isTrigger = true;
        var bulletRenderer = bullet.AddComponent<SpriteRenderer>();
        bulletRenderer.sprite = bulletSprite;
        bulletRenderer.color = new Color(1f, 1f, 1f);
        var bulletRigidbody = bullet.AddComponent<Rigidbody2D>();
        bulletRigidbody.gravityScale = 0;
        bulletRigidbody.velocity *= speed;
        var bulletScript = bullet.AddComponent<BulletScript>();
        bulletScript.SetSpeed(speed);
        bulletScript.SetDirection(direction);
    }
}
