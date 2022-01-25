using UnityEngine;
using UnityEngine.SceneManagement;
using Input = UnityEngine.Input;

public class RestartLevel : MonoBehaviour
{
    private void Update()
    {
        Restart();
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerScore.instance.RestartScore();
            GameOver.IsPlayerDead = false;
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}
