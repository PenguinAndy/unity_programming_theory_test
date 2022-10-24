using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public int currentTime = 60;
    public string userName = "";
    public int higestScore = 0;
    public bool isGameOver = false;

    [SerializeField] List<GameObject> enemys;
    [SerializeField] Canvas canvas;
    [SerializeField] int enemyCount = 10;


    private MainSceneUI mainSceneUI;
    private float moveRange = 22.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();

        mainSceneUI = canvas.gameObject.GetComponent<MainSceneUI>();

        if (DataPersistenceMangager.instance != null)
        {
            userName = DataPersistenceMangager.instance.userName;
            higestScore = DataPersistenceMangager.instance.higestScore;
        }

        mainSceneUI.ShowRank();

        InvokeRepeating("CountDown", 1, 1);
    }

    // count down timer
    void CountDown()
    {
        if (currentTime >= 0)
        {
            currentTime -= 1;
            mainSceneUI.RefreshTime();
        } else
        {
            GameOver();
            currentTime = 60;
            CancelInvoke("CountDown");
        }
    }


    public void CatchEnemy(int enemyScore)
    {
        score = score + enemyScore;
        mainSceneUI.RefreshScore();
    }

    void SpawnEnemy()
    {
        for (int i = 0; i<enemyCount; i++)
        {
            int index = Random.Range(0, enemys.Count);
            GameObject enemy = enemys[index];
            Instantiate(enemy, RandomPosition(enemy), enemy.transform.rotation);
        }
    }

    void GameOver()
    {
        isGameOver = true;
        print("game over");
    }

    private Vector3 RandomPosition(GameObject enemy)
    {
        float x = Random.Range(-moveRange, moveRange);
        float z = Random.Range(-moveRange, moveRange);
        Vector3 position = new Vector3(x, enemy.transform.position.y, z);
        return position;
    }
}
