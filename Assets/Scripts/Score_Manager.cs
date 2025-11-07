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
        highScore = PlayerPrefs.GetInt("high_score", 0);
        highScoreText.text = "Лучший счет: " + highScore.ToString();
        lastScoreText.text = "Последний счет: " + lastScore.ToString();
    }
    
    void Update()
    {
        scoreText.text = "Счет: " + score.ToString();
        if(score>highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("high_score", highScore);
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
