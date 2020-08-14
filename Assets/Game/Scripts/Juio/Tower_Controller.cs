using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Controller : MonoBehaviour
{
    private AudioController audioController;
    [Header("Tower")]
    public GameObject spot;
    public GameObject bullet;
    public float time;
    private Animator towerAnim;

    //public PlayerController player;
    private PlayerController2 player;
    public Image loadingInside;
    private float pieces = 0f;
    private float maxPieces = 5f;
    private float need;

    private void Awake()
    {
        //player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        player = FindObjectOfType(typeof(PlayerController2)) as PlayerController2; // new
    }

    void Start()
    {
        towerAnim = GetComponent<Animator>();
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
    }
    void Update()
    {
        need = maxPieces - pieces;

        if (pieces == maxPieces)
        {
            towerAnim.SetBool("isFixed", true);
            time += Time.deltaTime;
            
            if (time >= 2.5f)
            {
                var Enemies = GameObject.FindGameObjectsWithTag("EnemyCollider");
                if (Enemies == null)
                {
                    time = 0;
                    return;
                }
                Instantiate(bullet, new Vector3(spot.transform.position.x, spot.transform.position.y, spot.transform.position.z), spot.transform.rotation).GetComponent<Bullet_Controller>().Enemies = Enemies;
                audioController.playSfx(audioController.sfxTowerShoot[Random.Range(0,audioController.sfxTowerShoot.Length)], 0.5f);
                time = 0;
            }
        }

        loadingInside.fillAmount = (pieces / maxPieces);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.pieces > need)
            {
                player.pieces = (player.pieces - need);
                pieces = maxPieces;
            }
            else
            {
                pieces += player.pieces;
                player.pieces = 0;
                if (pieces >= 5)
                {
                    pieces = maxPieces;
                    audioController.playSfx(audioController.sfxFixTower[Random.Range(0, audioController.sfxFixTower.Length)], 0.5f);
                }
            }
        }
    }   
}