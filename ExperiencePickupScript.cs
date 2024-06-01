using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePickupScript : MonoBehaviour
{
    private int exp;
    private void Start()
    {
        StartCoroutine("optimalized");
        exp = Random.Range(1, 5);
    }
    private IEnumerator optimalized()
    {
        yield return new WaitForSecondsRealtime(20);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            var playerScript = collision.GetComponent<PlayerScript>();
            playerScript.AddExp(exp);
            Destroy(this.gameObject, 0.01f);
        }
    }
}
