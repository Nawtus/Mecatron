using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityController : MonoBehaviour
{
    public Image HUD_KeyCount;
    public Text keysNumber;
    public Image HUD_KillCount;
    public Text killCountText;

    private float opacity = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HUD_KeyCount.GetComponent<Image>().color = new Color(HUD_KeyCount.color.r, HUD_KeyCount.color.g, HUD_KeyCount.color.b, opacity);
            keysNumber.GetComponent<Text>().color = new Color(keysNumber.color.r, keysNumber.color.g, keysNumber.color.b, opacity);
            HUD_KillCount.GetComponent<Image>().color = new Color(HUD_KillCount.color.r, HUD_KillCount.color.g, HUD_KillCount.color.b, opacity);
            killCountText.GetComponent<Text>().color = new Color(killCountText.color.r, killCountText.color.g, killCountText.color.b, opacity);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HUD_KeyCount.GetComponent<Image>().color = new Color(HUD_KeyCount.color.r, HUD_KeyCount.color.g, HUD_KeyCount.color.b, 1);
            keysNumber.GetComponent<Text>().color = new Color(keysNumber.color.r, keysNumber.color.g, keysNumber.color.b, 1);
            HUD_KillCount.GetComponent<Image>().color = new Color(HUD_KillCount.color.r, HUD_KillCount.color.g, HUD_KillCount.color.b, 1);
            killCountText.GetComponent<Text>().color = new Color(killCountText.color.r, killCountText.color.g, killCountText.color.b, 1);
        }
    }
}
