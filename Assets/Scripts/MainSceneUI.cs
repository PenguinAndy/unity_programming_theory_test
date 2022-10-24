using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI rankText;
    [SerializeField] GameObject gameManagerObj;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    // refresh score text
    public void RefreshScore()
    {
        string text = "Score:" + gameManager.score;
        scoreText.SetText(text);
    }

    // refresh time text
    public void RefreshTime()
    {
        string text = gameManager.currentTime + "s";
        timeText.SetText(text);
    }

    // show rank text
    public void ShowRank()
    {
        string text = gameManager.userName + " " + "higest score:" + gameManager.higestScore;
        rankText.SetText(text);
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
}
