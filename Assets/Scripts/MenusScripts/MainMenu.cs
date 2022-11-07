using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuState
{
    Quit,
    OpenLevel,
    LevelsPage,
    MainMenuPage
}
public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    private MenuState state;
    private string levelName;

    [SerializeField] private GameObject MainMenuBlock;
    [SerializeField] private GameObject LevelsBlock;

    public void Start()
    {
        Instance = this;
        state = MenuState.MainMenuPage;
    }

    public void QuitGame()
    {
        UpdateGameState(MenuState.Quit);
    }

    public void LevelsPage()
    {
        UpdateGameState(MenuState.LevelsPage);
    }

    public void MainMenuPage()
    {
        UpdateGameState(MenuState.MainMenuPage);
    }

    public void OpenLevel(string levelName)
    {
        this.levelName = levelName;
        UpdateGameState(MenuState.OpenLevel);
    }


    public void UpdateGameState(MenuState newState)
    {
        switch (newState)
        {
            case MenuState.Quit:
                HandleQuitGame();
                break;
            case MenuState.OpenLevel:
                HandleOpenLevel();
                break;
            case MenuState.LevelsPage:
                HandleLevelsPage();
                break;
            case MenuState.MainMenuPage:
                HandleMainMenuPage();
                break;
        }

        state = newState;
    }


    private void HandleQuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    private void HandleMainMenuPage()
    {
        MainMenuBlock.SetActive(true);
        LevelsBlock.SetActive(false);
    }

    private void HandleLevelsPage()
    {
        MainMenuBlock.SetActive(false);
        LevelsBlock.SetActive(true);
    }

    private void HandleOpenLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
