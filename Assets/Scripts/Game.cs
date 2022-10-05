using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Game : MonoBehaviour
{
    public SnakeHead SnakeHead;
    public ObjectPool PickUpsPool;

    public GameObject WinScreen;
    public GameObject LosScreen;
    public GameObject MusicSpring;



    public enum State
    {
        Playing,
        Win,
        Loose,
    }

    public State CurrentState { get; set; }

    public void ContiniueGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
        LevelIndex = 0;
        PlayerPrefs.SetInt("Score", 0);
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";

    public void OnDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loose;
        SnakeHead.ForwardSpeed = 0;
        SnakeHead.Sensitivity = 0;
        Debug.Log("Game over!");
        PlayerPrefs.SetInt("Score", 0);
        LosScreen.SetActive(true);
        MusicSpring.SetActive(false);

    }

    public void OnReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Win;
        SnakeHead.ForwardSpeed = 0;
        SnakeHead.Sensitivity = 0;
        SnakeHead.Score += 50 * SnakeHead._snakeTail._bodyParts.Count;
        LevelIndex++;
        Debug.Log("Stage cleared!");
        WinScreen.SetActive(true);
        MusicSpring.SetActive(false);
    }
}
