using System;
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
        AudioManager.Instance.PlayMenuMusic();
    }

    private void Update()
    {
        if (!mainMenuPanel.activeSelf && difficultyPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            ShowMainMenu();
    }

    public void OnVolumeSliderChanged(float value)
    {
        AudioManager.Instance.SetVolume(value);
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
        GameSettings.carSpawnInterval = 1f;
        GameSettings.currentDifficulty = "easy";
        LoadGameScene();
    }

    public void StartGameMedium()
    {
        GameSettings.carSpawnInterval = 0.75f;
        GameSettings.currentDifficulty = "medium";
        LoadGameScene();
    }

    public void StartGameHard()
    {
        GameSettings.carSpawnInterval = 0.56f;
        GameSettings.currentDifficulty = "hard";
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
