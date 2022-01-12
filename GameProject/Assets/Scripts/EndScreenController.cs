using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class EndScreenController : MonoBehaviour
{
    public void playAgain() {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        LevelManager.instance.ResetVariables();
    }
 
    public void mainMenu() {
        SceneManager.LoadScene("Menu");
    }
}