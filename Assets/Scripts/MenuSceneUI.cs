using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuSceneUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI userText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TMP_InputField userTextField;

    // Start is called before the first frame update
    void Start()
    {
        string userName = "User: ";
        string score = "Best Score: ";

        DataPersistenceMangager.instance.LoadUserData();
        if (DataPersistenceMangager.instance.userName.Length != 0)
        {
            userName = userName + DataPersistenceMangager.instance.userName;
        } else
        {
            userName = userName + "unknow";
        }

        score = score + DataPersistenceMangager.instance.higestScore;
        userText.SetText(userName);
        scoreText.SetText(score);
    }

    public void OnClickEnterButton()
    {
        if (userTextField.text.Length != 0)
        {
            DataPersistenceMangager.instance.userName = userTextField.text;
        }
        DataPersistenceMangager.instance.SaveUserData();
        SceneManager.LoadScene(1);
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
