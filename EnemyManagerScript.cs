using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    [Header("Spawners")]
    [SerializeField] private Transform spawner1;
    [SerializeField] private Transform spawner2;
    [SerializeField] private Transform spawner3;
    [SerializeField] private Transform spawner4;
    [Header("Enemy")]
    [SerializeField] private Sprite enemySprite;
    [SerializeField] private Sprite expPickupSprite;
    [Header("Player")]
    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        StartCoroutine("spawnEnemy");
        PlayerPrefs.SetInt("canMove", 1);
    }
    private void SpawnEnemy(int spawner)
    {
        var Enemy = new GameObject();
        Enemy.name = "Enemy";
        Enemy.layer = 7;
        
        Enemy.transform.localScale = new Vector3(10, 10, 1);
        switch (spawner)
        {
            case 1:
                Enemy.transform.position = spawner1.position;
                break;
            case 2:
                Enemy.transform.position = spawner2.position;
                break;
            case 3:
                Enemy.transform.position = spawner3.position;
                break;
            case 4:
                Enemy.transform.position = spawner4.position;
                break;
        }
        var EnemyRenderer = Enemy.AddComponent<SpriteRenderer>();
        var EnemyCollider = Enemy.AddComponent<BoxCollider2D>();
        EnemyCollider.size = new Vector2(0.05f, 0.05f);
        EnemyCollider.offset = new Vector2(0, 0);
        EnemyRenderer.sprite = enemySprite;
        EnemyRenderer.color = new Color(1, 1, 1);
        var EnemyRigidbody = Enemy.AddComponent<Rigidbody2D>();
        EnemyRigidbody.gravityScale = 0;
        EnemyRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        var EnemyScript = Enemy.AddComponent<EnemyScript>();
        EnemyScript.SetTarget(playerTransform);
        EnemyScript.expPickupSprite = expPickupSprite;
        
    }
    private IEnumerator spawnEnemy()
    {
        var enemyCount = Random.Range(15, 20);
        for (int i = 0; i <= enemyCount; i++)
        {
            SpawnEnemy(Random.Range(1, 4));
        }
        yield return new WaitForSecondsRealtime(Random.Range(1,3));
        StartCoroutine("spawnEnemy");
    }
}
