using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public Text bestScoreText;

    private void Start()
    {
        SetBestScore();
    }
    public void SetNameField(string newName = "")
    {
        ScoreData.Instance.playerName = newName;
        Debug.Log(ScoreData.Instance.playerName);
    }

    public void SetBestScore()
    {
        if(ScoreData.Instance.currentHighscore != 0)
            bestScoreText.text = $"{ScoreData.Instance.bestPlayer} : {ScoreData.Instance.currentHighscore}";
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGameButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
