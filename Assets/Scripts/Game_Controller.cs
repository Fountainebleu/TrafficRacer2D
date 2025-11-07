using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public TextMeshProUGUI highSoreText;
    public TextMeshProUGUI scoreText;
    private int score;
    private int highScore;
    public Score_Manager score_manager;
    public GameObject gamePausePanel;
    private bool isPaused;
    
    void Start()
    {
        gamePausePanel.SetActive(false);
        isPaused = false;
    }
    
    void Update()
    {
        highScore = PlayerPrefs.GetInt("high_score");
        score = score_manager.score;
        highSoreText.text = "Лучший счет: " + highScore.ToString();
        scoreText.text = "Счет: " + score.ToString();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
    }
    
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
    }

    public void Main_Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
