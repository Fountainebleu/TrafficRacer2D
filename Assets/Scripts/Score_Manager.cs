using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
    public int score = 0;
    public int highScore;
    public static int lastScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI lastScoreText;
    
    void Start()
    {
        StartCoroutine(Score());
        var highScoreKey = "high_score_" + DefaultNamespace.GameSettings.currentDifficulty;
        var lastScoreKey = "last_score_" + DefaultNamespace.GameSettings.currentDifficulty;

        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        lastScore = PlayerPrefs.GetInt(lastScoreKey, 0);
        highScoreText.text = "Лучший счет: " + highScore.ToString();
        lastScoreText.text = "Последний счет: " + lastScore.ToString();
    }
    
    void Update()
    {
        scoreText.text = "Счет: " + score.ToString();
        string lastScoreKey = "last_score_" + DefaultNamespace.GameSettings.currentDifficulty;
        PlayerPrefs.SetInt(lastScoreKey, score);
        if(score>highScore)
        {
            highScore = score;
            var highScoreKey = "high_score_" + DefaultNamespace.GameSettings.currentDifficulty;
            PlayerPrefs.SetInt(highScoreKey, highScore);
        }
    }

    IEnumerator Score()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.8f);
            score = score + 1;
            lastScore = score;

        }
    }
}
