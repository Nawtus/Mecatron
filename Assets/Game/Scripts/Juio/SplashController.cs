using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    public LevelLoader levelLoader;
    public float time;

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 4f)
        {
            levelLoader.LoadNextScene(1);
        }
    }
}
