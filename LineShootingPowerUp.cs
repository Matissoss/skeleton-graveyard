using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineShootingPowerUp : MonoBehaviour
{
    private int lineMode;
    private float time;
    private ShootingScript shootingScript;
    private void Start()
    {
        time = 2.35f;
        StartCoroutine("shoot");
        shootingScript = this.gameObject.GetComponent<ShootingScript>();
    }
    public void SetFireMode(int value)
    {
        if(value == 0)
        {
            lineMode = 0;
        }
        else if(value == 1)
        {
            lineMode = 1;
        }
        else if(value == 2) 
        {
            lineMode = 2;
        }
        else if (value == 3)
        {
            lineMode = 3;
        }
    }
    private IEnumerator shoot()
    {
        yield return new WaitForSecondsRealtime(time - PlayerPrefs.GetFloat("FireRate"));
        if(lineMode == 0)
        {
            // Up&Down
            shootingScript.Fire(2);
            shootingScript.Fire(7);
        }
        else if(lineMode == 1)
        {
            //Left&Right
            shootingScript.Fire(4);
            shootingScript.Fire(5);
        }
        else if(lineMode == 2)
        {
            shootingScript.Fire(1);
            shootingScript.Fire(3);
            shootingScript.Fire(6);
            shootingScript.Fire(8);
        }
        else if(lineMode == 3)
        {
            shootingScript.Fire(1);
            shootingScript.Fire(2);
            shootingScript.Fire(3);
            shootingScript.Fire(4);
            shootingScript.Fire(5);
            shootingScript.Fire(6);
            shootingScript.Fire(7);
            shootingScript.Fire(8);
        }
        StartCoroutine("shoot");
    }
}
