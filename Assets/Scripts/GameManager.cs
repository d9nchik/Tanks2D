using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState
{
    MainMenu,
    Play,
    Victory,
    Lose,
    Shop
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameState state;
    public static event Action<GameState> OnGameStateChange;
    [SerializeField] private TMP_Text text;
    void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.MainMenu:
                break;
            case GameState.Play:
                HandlePlay();
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            case GameState.Shop:
                break;
            default:
                break;
        }

        OnGameStateChange?.Invoke(newState);
    }

    private void HandleLose()
    {
        text.enabled = true;
        text.text = "You lose!";
    }

    private void HandleVictory()
    {
        text.enabled = true;
        text.text = "You won!";
    }

    private void HandlePlay()
    {
        text.enabled = false;
    }
}
