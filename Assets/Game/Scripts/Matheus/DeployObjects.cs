using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployObjects : MonoBehaviour
{
    public GameObject objectPrefab;
    public float respawnTime = 2.0f;

    public Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(PieceWave());
    }

    private void SpawnPiece()
    {
        GameObject a = Instantiate(objectPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator PieceWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnPiece();
        }
    }
}
