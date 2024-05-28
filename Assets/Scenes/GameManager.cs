using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int lives = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
        }
    }
    public int getLives()
    {
        return lives;
    }
    public void ResetLives()
    {
        lives = 3;
    }
}

