using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
    }
}
