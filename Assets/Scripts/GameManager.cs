using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public int currentTime = 60;
    public string userName = "";
    public int higestScore = 0;
    [SerializeField] Canvas canvas;
    private MainSceneUI mainSceneUI;

    // Start is called before the first frame update
    void Start()
    {
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
            currentTime = 60;
            CancelInvoke("CountDown");
        }
    }

}
