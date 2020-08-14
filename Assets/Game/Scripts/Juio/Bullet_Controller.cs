using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float Velocity;
    public GameObject[] Enemies;
    public GameObject enemy;
    private void Start()
    {
        enemy = Enemies[Random.Range(0, Enemies.Length)];
    }
    void Update()
    {
        if (enemy)
        {
            transform.position += (enemy.transform.position - transform.position).normalized * Time.deltaTime * Velocity;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    /*void SearchAgain()
    {
        Enemies = GameObject.FindGameObjectsWithTag("EnemyCollider");
        enemy = Enemies[Random.Range(0, Enemies.Length)];
        transform.position += (enemy.transform.position - transform.position).normalized * Time.deltaTime * Velocity;
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyCollider"))
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<EnemyController>().Died();
        }
    }
}

