using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BirdController b = collision.GetComponent<BirdController>();
        if (b == null) return;
        b.Die();
        GameManager.Instance.GameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BirdController b = collision.transform.GetComponent<BirdController>();
        if (b == null) return;
        b.Die();
        GameManager.Instance.GameOver();
    }
}
