using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    //public static float playerScore = 0;
    //private Text scoreText;

    //private void Start()
    //{
    //    scoreText = GetComponent<Text>();
    //}

    //private void Update()
    //{
    //    scoreText.text = "Score" + playerScore;
    //}

    [SerializeField] private Text scoreText;
    private int score;
    public static PlayerScore instance;

    private void Start()
    {
        instance = GetComponent<PlayerScore>();
        score = 0;
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        ScoreUpdate();
    }

    public void RestartScore()
    {
        score = 0;
        ScoreUpdate();
    }
}
