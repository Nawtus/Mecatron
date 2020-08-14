using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    //public PlayerController player;
    private PlayerController2 player; // new
    public float radius = 3f;

    private Vector2 screenBounds;

    void Awake()
    {
        //player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        player = FindObjectOfType(typeof(PlayerController2)) as PlayerController2; //new
    }

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.CollectPiece();
            Destroy(gameObject);
        }
    }
}
