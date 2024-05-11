using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject gameCheckpointScreen;

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        if(playerScore < 10)
        {
            playerScore = playerScore + 1;
            scoreText.text = playerScore.ToString();
            if (playerScore == 3)
            {
                gameCheckpoint();
            }
        }
        else
        {
            nextLevel();
        }
        
    }
    public void nextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    [ContextMenu("Checkpoint")]
    public void gameCheckpoint()
    {
        gameCheckpointScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void continueCheckpoint()
    {
        gameCheckpointScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void returnToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}

