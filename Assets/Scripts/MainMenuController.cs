using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject difficultyPanel;

    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        difficultyPanel.SetActive(false);
    }

    public void ShowDifficultyPanel()
    {
        mainMenuPanel.SetActive(false);
        difficultyPanel.SetActive(true);
    }

    public void StartGameEasy()
    {
        GameSettings.carSpawnInterval = 1.0f; // реже — легче
        LoadGameScene();
    }

    public void StartGameMedium()
    {
        GameSettings.carSpawnInterval = 0.5f; // как у тебя сейчас
        LoadGameScene();
    }

    public void StartGameHard()
    {
        GameSettings.carSpawnInterval = 0.25f; // чаще — сложнее
        LoadGameScene();
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
