using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public GameObject GUICanvas;
    public GameObject EndScreenCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Finish")
        {
            LevelManager.runSpeed = 0f;
            LevelManager.instance.SetSummaryText();
            GUICanvas.SetActive(false);
            EndScreenCanvas.SetActive(true);
        }
    }

    public void SetCanvas(GameObject GUI, GameObject EndScreen)
    {
        GUICanvas = GUI;
        EndScreenCanvas = EndScreen;
    }
}
