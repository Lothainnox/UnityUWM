using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour
{
    public void playGame() {
        SceneManager.LoadScene("Level1");
        LevelManager.instance.ResetVariables();
    }
 
    public void exitGame() {
        Application.Quit();
    }
}