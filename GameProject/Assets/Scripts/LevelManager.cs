using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    internal static int retryCounter = 0;
    internal static int score = 0;
    public static float runSpeed = 5f;
    private const float runSpeedConst = 5f;
    internal static bool isFinished = false;


    private List<Vector2> gemPositions = new List<Vector2>() {
        new Vector2(-33.5f, -4f),
        new Vector2(-31.5f, -4f),
        new Vector2(-29.5f, -4f),
        new Vector2(-3.9f, -2.2f),
        new Vector2(1.4f, -1f),
        new Vector2(8f, 0.7f),
        new Vector2(35.5f, 0.6f),
        new Vector2(38.5f, 2.4f),
        new Vector2(41f, 1.5f),
        new Vector2(70.7f, 1.6f),
        new Vector2(70.7f, -8.3f),
        new Vector2(73.9f, -8.3f),
        new Vector2(89.1f, -11.1f),
        new Vector2(91.1f, -11.1f),
        new Vector2(99.4f, -11.1f),
        new Vector2(101.4f, -11.1f),
        new Vector2(138f, -2.8f),
        new Vector2(140.3f, -1.3f),
        new Vector2(180.6f, -5.1f),
        new Vector2(183.6f, -5.1f),
        new Vector2(192.5f, 0.4f),
        new Vector2(196f, 0.4f),
        new Vector2(224f, 1.5f),
        new Vector2(226.3f, 3.5f),        
    };

    private List<Vector2> bigGemPositions = new List<Vector2>() {
        new Vector2(-16.3f, -1.8f),
        new Vector2(26.5f, 3.2f),
        new Vector2(89.2f, 6.6f),
        new Vector2(159.195f, -8.877f),   
        new Vector2(117.2f, -8.4f)
    };

    public Transform respawn;

    public GameObject playerPrefab;
    public GameObject gemPrefab;
    public GameObject bigGemPrefab;
    public GameObject GUICanvas;
    public GameObject EndScreenCanvas;

    public TextMeshProUGUI tmpRetries;
    public TextMeshProUGUI tmpScore;
    public TextMeshProUGUI tmpSummary;

    public CinemachineVirtualCameraBase vcBase;

    private void Awake() 
    {
        instance = this;
        isFinished = false;
        CreateGems();
        SetScoreText();
    }

    public void Respawn()
    {
        DestroyGems();
        CreateGems();
        score = 0;
        SetScoreText();
        retryCounter++;
        GameObject player = Instantiate(playerPrefab, respawn.position, Quaternion.identity);
        LevelEnd le = player.GetComponent<LevelEnd>();
        le.SetCanvas(GUICanvas, EndScreenCanvas);
        vcBase.Follow = player.transform;
        SetRetriesText();
    }

    private void DestroyGems()
    {
        List<GameObject> gems = GameObject.FindGameObjectsWithTag("Gem").ToList();
        gems.AddRange(GameObject.FindGameObjectsWithTag("Gem_5").ToList());
        foreach(GameObject gem in gems) Destroy(gem);
    }

    private void CreateGems()
    {
        foreach (Vector2 vector in gemPositions) {
            Instantiate(gemPrefab, vector, Quaternion.identity);
        }
        foreach (Vector2 vector in bigGemPositions) {
            Instantiate(bigGemPrefab, vector, Quaternion.identity);
        }
    }

    public void SetScoreText()
    {
        tmpScore.text = "Score: " + score;
    }

    public void SetRetriesText()
    {
        tmpRetries.text = "Retries: " + retryCounter;
    }

    public void SetSummaryText()
    {
        tmpSummary.text = "Finished with score " + score + " after " + retryCounter + " retries!";
    }

    public void ResetVariables()
    {
        runSpeed = runSpeedConst;
        score = 0;
        retryCounter = 0;
    }
}
