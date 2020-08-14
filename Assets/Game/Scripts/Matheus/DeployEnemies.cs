using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class DeployEnemies : MonoBehaviour
{
    private PlayerController2 player;
    public GameObject enemyPrefab;

    private Vector2 screenBounds;
    private int killCount = 0;
    private float respawnTime = 2.5f;

    private void Awake()
    {
        player = FindObjectOfType(typeof(PlayerController2)) as PlayerController2; // new
    }

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(EnemyWave());
    }

    private void Update()
    {
        killCount = player.killCount;
        if (killCount >= 10 && killCount < 40)
        {
            respawnTime = 1.5f;
        }
        else if (killCount >= 40 && killCount < 65)
        {
            respawnTime = 1f;
        }
        else if (killCount >= 65)
        {
            respawnTime = 0.5f;
        }

    }

    private void SpawnEnemy()
    {
        int aux = Random.Range(0, 4);
        GameObject a = Instantiate(enemyPrefab) as GameObject;
        a.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;

        switch (aux)
        {
            case 0:
                a.transform.position = new Vector2(-screenBounds.x, -screenBounds.y);
                break;
            case 1:
                a.transform.position = new Vector2(screenBounds.x, screenBounds.y);
                break;
            case 2:
                a.transform.position = new Vector2(-screenBounds.x, screenBounds.y);
                break;
            case 3:
                a.transform.position = new Vector2(screenBounds.x, -screenBounds.y);
                break;
        }
    }

    IEnumerator EnemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}
