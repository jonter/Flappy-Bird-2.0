using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button menuButton;
    [SerializeField] TMP_Text recordText;

    private void OnEnable()
    {
        CheckRecord();
        restartButton.onClick.AddListener(RestartGame);
        menuButton.onClick.AddListener(GoMenu);
    }

    void CheckRecord()
    {
        int record = PlayerPrefs.GetInt("record");
        if(GameManager.Score <= record)
        {
            recordText.text = "Рекорд: " + record;
        }
        else
        {
            recordText.text = "Новый \nРекорд: " + GameManager.Score;
            PlayerPrefs.SetInt("record", GameManager.Score);
        }
    }

    void RestartGame()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
