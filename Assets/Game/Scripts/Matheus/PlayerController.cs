using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private AudioController audioController;
    public LevelLoader levelLoader;
    public Rigidbody2D body;
    public Text keysNumber;
    public Text killCountText;

    private int killCount = 0;

    //Animação
    private Animator animPlayer;
    public bool moving;

    //inventory
    public static int pieces = 0;

    //movement
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    private bool isLookLeft;

    public float runSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            moving = true;
            animPlayer.SetBool("Run", moving);
        }
        else
        {
            moving = false;
            animPlayer.SetBool("Run", moving);
        }

        float h = Input.GetAxis("Horizontal"); // FLIPPAR DIREITA/ESQUERDA
        if (h > 0 && isLookLeft == true)
        {
            Flip();
        }
        else if (h < 0 && isLookLeft == false)
        {
            Flip();
        }

        keysNumber.text = pieces.ToString();
        killCountText.text = killCount.ToString();
    }

    public int getKillCount()
    {
        return killCount;
    }

    public void DiedScene()
    {
        levelLoader.LoadNextScene(2);
    }

    public void Died()
    {
        animPlayer.SetBool("Died", true);
        audioController.playSfx(audioController.sfxPlayerDied, 0.5f);
        pieces = 0;
    }
    public void IncreaseKillCount()
    {
        killCount += 1;
        WinGame();
    }

    private void WinGame()
    {
        if (killCount >= 100)
        {
            levelLoader.LoadNextScene(1);
        }
    }

    public void CollectPiece()
    {
        pieces += 1;
        audioController.playSfx(audioController.sfxPick[Random.Range(0,audioController.sfxPick.Length)], 0.8f);
    }
    public int DropPieces()
    {
        int aux = pieces;
        if (pieces > 0)
        {
            audioController.playSfx(audioController.sfxFixTower[Random.Range(0,audioController.sfxFixTower.Length)], 0.5f);
        }
        pieces = 0;
        return aux;
    }
    void Flip()
    {
        isLookLeft = !isLookLeft;
        GetComponent<SpriteRenderer>().flipX = isLookLeft;
    }
}
