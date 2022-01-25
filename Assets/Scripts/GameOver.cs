using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool IsPlayerDead = false; 
    private Text gameOver;

    private void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
    }

    private void Update()
    {
        if (IsPlayerDead == true)
        {
            Debug.Log("Player is dead");
            Time.timeScale = 0;
            gameOver.enabled = true;
            //PlayerScore.instance.RestartScore();
        }
    }
}
