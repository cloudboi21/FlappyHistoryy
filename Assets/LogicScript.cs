using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text checkpointText;
    public GameObject gameOverScreen;
    public GameObject gameCheckpointScreen;
    Dictionary<int, string> infoDictionary = new Dictionary<int, string>()
    {
        {1,"fact 1" },
        {2,"fact 2" },
        {3,"intrebarea 3" },
        {4,"intrebarea 4" },
        {5,"intrebarea 5" },
        {6,"intrebarea 6" }
    };




    [ContextMenu("Increase Score")]
    public void addScore()
    {
        if(playerScore < 10)
        {
            playerScore = playerScore + 1;
            scoreText.text = playerScore.ToString();
            if (playerScore % 3 ==0)
            {
                gameCheckpoint();
            }
        }
        else
        {
            nextLevel();
        }
        
    }

    public void resume()
    {
        gameCheckpointScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void nextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    [ContextMenu("Checkpoint")]
    public void gameCheckpoint()
    {
        checkpointText.text = infoDictionary[playerScore / 3];
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

