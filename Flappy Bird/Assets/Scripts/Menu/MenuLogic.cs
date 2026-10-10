using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button birdSelectButton;

    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject birdPanel;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(GoPlay);
        birdSelectButton.onClick.AddListener(GoBirdSelect);
    }

    void GoPlay()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    void GoBirdSelect()
    {
        mainPanel.SetActive(false);
        birdPanel.SetActive(true);
    }

   
}
