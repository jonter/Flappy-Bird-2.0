using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    READY,
    PLAYING,
    DIE
}

public class GameManager : MonoBehaviour
{
    public static GameState state = GameState.READY;
    public static GameManager Instance;

    [SerializeField] GameObject overPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        state = GameState.READY;
        Instance = this;
        overPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        if (state != GameState.READY) return;
        state = GameState.PLAYING;
        FindAnyObjectByType<TubeSpawner>().StartSpawning();
    }


    public void GameOver()
    {
        if (state != GameState.PLAYING) return;
        state = GameState.DIE;
        StopTheGame();
        overPanel.SetActive(true);
    }

    void StopTheGame()
    {
        TubeSpawner ts = FindAnyObjectByType<TubeSpawner>();
        ts.gameObject.SetActive(false);
        Mover[] movers = FindObjectsOfType<Mover>();

        foreach(Mover m in movers)
        {
            m.speed = 0;
        }

    }
}
