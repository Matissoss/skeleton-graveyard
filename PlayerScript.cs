using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float speed;
    private int level;
    private float exp;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        level = 1;
        var neededExp = (level * level * level * 1.4f) + 50;
        exp = 0;
        speed = PlayerPrefs.GetFloat("speed");
        PlayerPrefs.SetFloat("currentExp", exp);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetFloat("neededExp", neededExp);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerRb.velocity = new Vector2(-1, playerRb.velocity.y);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerRb.velocity = new Vector2(1, playerRb.velocity.y);
        }
        else
        {
            playerRb.velocity =new Vector2(0, playerRb.velocity.y);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, 1);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, -1);
        }
        else
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
        }
        playerRb.velocity *= speed;
        speed = PlayerPrefs.GetFloat("speed");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void AddExp(int value)
    {
        exp += value * PlayerPrefs.GetFloat("XPMultiplier");
        PlayerPrefs.SetFloat("currentExp", exp);
        Debug.Log(exp.ToString());
        CheckIfLevelUp();
    }
    private void CheckIfLevelUp()
    {
        var neededExp = (level * level * level * 1.4f ) + 50;
        PlayerPrefs.SetFloat("neededExp", neededExp);
        Debug.Log("Exp needed for LevelUp: " + neededExp.ToString());
        if(exp >= neededExp) 
        {
            LevelUp();
        }
    }
    private void LevelUp()
    {
        PlayerPrefs.SetInt("isLeveling", 1);
        level++;
        PlayerPrefs.SetInt("level", level);
        exp = 0;
        Debug.Log("Level Up: " + level.ToString());
        var NewLevel = new GameObject();
        NewLevel.name = level.ToString();
    }
}
