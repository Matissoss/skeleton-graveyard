using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D bulletRigidbody;
    private int speed;
    private int dir;
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine("KeepDirection");
        StartCoroutine("waitForDestroy");
    }
    private IEnumerator KeepDirection()
    {
        for(int i = 0; i<3; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        switch (dir)
        {
            //Right Top
            case 1:
                bulletRigidbody.velocity = new Vector2(1, 1);
                break;
            //Center Top
            case 2:
                bulletRigidbody.velocity = new Vector2(0, 1);
                break;
            //Left Top
            case 3:
                bulletRigidbody.velocity = new Vector2(-1, 1);
                break;
            //Right Center
            case 4:
                bulletRigidbody.velocity = new Vector2(1, 0);
                break;
            //Left Center
            case 5:
                bulletRigidbody.velocity = new Vector2(-1, 0);
                break;
            //Right Down
            case 6:
                bulletRigidbody.velocity = new Vector2(1, -1);
                break;
            //Center Down
            case 7:
                bulletRigidbody.velocity = new Vector2(0, -1);
                break;
            //Left Down
            case 8:
                bulletRigidbody.velocity = new Vector2(-1, -1);
                break;
        }
        bulletRigidbody.velocity *= speed;
        StartCoroutine("KeepDirection");
    }
    public void SetDirection(int direction)
    {
        dir = direction;
    }
    public void SetSpeed(int value)
    {
        speed = value;
    }
    private IEnumerator waitForDestroy()
    {
        yield return new WaitForSecondsRealtime(4);
        Destroy(this.gameObject);
    }
}
