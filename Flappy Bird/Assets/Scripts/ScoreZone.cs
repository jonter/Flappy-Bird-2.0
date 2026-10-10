using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BirdController b = collision.GetComponent<BirdController>();
        if (b == null) return;
        if (GameManager.state != GameState.PLAYING) return;
        GameManager.Instance.AddScore();
        GetComponent<AudioSource>().Play();
    }
}
