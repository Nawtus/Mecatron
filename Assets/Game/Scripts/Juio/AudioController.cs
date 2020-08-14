using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioSource musicSource;

    public AudioClip sfxPlayerDied;
    public AudioClip sfxWin;
    public AudioClip sfxLose;
    public AudioClip sfxButton;
    public AudioClip[] sfxFixTower;
    public AudioClip[] sfxPick;
    public AudioClip[] sfxEnemyDied;
    public AudioClip[] sfxTowerShoot;

    void Awake()
    {
        GameObject[] objts = GameObject.FindGameObjectsWithTag("GameController");
        if (objts.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void playSfx(AudioClip sfxClip,float volume)
    {
        sfxSource.PlayOneShot(sfxClip, volume);
    } 
}
