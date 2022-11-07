using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    Play,
    Victory,
    Lose,
    Shop,
    Pause
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameState state;
    public static event Action<GameState> OnGameStateChange;

    public GameObject pauseMenu;
    [SerializeField] private TMP_Text text;
    void Start()
    {
        Instance = this;
        state = GameState.Play;
    }

    private void Update()
    {
        if ((state == GameState.Lose || state == GameState.Victory) && Input.GetKey(KeyCode.Q))
        {
            UpdateGameState(GameState.MainMenu);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (state)
            {
                case GameState.Pause:
                    UpdateGameState(GameState.Play);
                    break;
                case GameState.Lose:
                case GameState.Victory:
                    UpdateGameState(GameState.MainMenu);
                    break;
                default:
                    UpdateGameState(GameState.Pause);
                    break;
            }
        }
    }


    public void Resume()
    {
        UpdateGameState(GameState.Play);
    }

    public void MainMenu()
    {
        UpdateGameState(GameState.MainMenu);
    }

    public void UpdateGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.MainMenu:
                HandleMainMenu();
                break;
            case GameState.Play:
                HandlePlay();                
                break;
            case GameState.Victory:
                if (!HandleVictory())
                {
                    return;
                }
                break;
            case GameState.Lose:
                if (!HandleLose())
                {
                    return;
                }
                break;
            case GameState.Shop:
                break;
            case GameState.Pause:
                HandlePause();
                break;
            default:
                break;
        }

        state = newState;
        OnGameStateChange?.Invoke(newState);
    }

    private bool HandleLose()
    {
        if (state == GameState.Victory)
        {
            return false;
        }
        text.enabled = true;
        text.text = "You lose!";
        return true;
    }

    private bool HandleVictory()
    {
        if (state == GameState.Lose)
        {
            return false;
        }
        text.enabled = true;
        text.text = "You won!";
        return true;
    }

    private void HandlePlay()
    {
        text.enabled = false;
        if (state == GameState.Pause)
        {
            pauseMenu.SetActive(false);
        }
    }
    private void HandleMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void HandlePause()
    {
        pauseMenu.SetActive(true);
    }
}
