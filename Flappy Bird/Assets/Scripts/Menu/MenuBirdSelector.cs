using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuBirdSelector : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;

    [SerializeField] GameObject[] birds;
    int num = 0;
    GameObject currentBird;

    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] Button chooseButton;
    [SerializeField] TMP_Text nameText;

    private void OnEnable()
    {
        num = PlayerPrefs.GetInt("bird");
        ShowBird(num);
        leftButton.onClick.AddListener(GoLeft);
        rightButton.onClick.AddListener(GoRight);
        chooseButton.onClick.AddListener(Choose);
    }

    private void OnDisable()
    {
        leftButton.onClick.RemoveAllListeners();
        rightButton.onClick.RemoveAllListeners();
        chooseButton.onClick.RemoveAllListeners();
        Destroy(currentBird);
    }

    void ShowBird(int index)
    {
        if (currentBird != null) Destroy(currentBird);
        currentBird = Instantiate(birds[index]);
        currentBird.transform.position = new Vector3();
        currentBird.GetComponent<BirdController>().enabled = false;
        nameText.text = birds[index].name;
    }

    void GoLeft()
    {
        num -= 1;
        if (num < 0) num = 0;
        ShowBird(num);
    }

    void GoRight()
    {
        num += 1;
        if (num >= birds.Length) num = birds.Length - 1;
        ShowBird(num);
    }

    void Choose()
    {
        PlayerPrefs.SetInt("bird", num);
        gameObject.SetActive(false);
        mainPanel.SetActive(true);
    }

}
