using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Gem")
        {
            Destroy(other.gameObject);
            LevelManager.score++;
            LevelManager.instance.SetScoreText();
        }

        if(other.transform.tag == "Gem_5")
        {
            Destroy(other.gameObject);
            LevelManager.score+=5;
            LevelManager.instance.SetScoreText();
        }
    }
}
