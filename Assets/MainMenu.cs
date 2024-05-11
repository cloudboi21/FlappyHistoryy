using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
       SceneManager.LoadSceneAsync("Level1");
   }
    public void level1()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
    public void level2()
    {
        SceneManager.LoadSceneAsync("Level2");
    }
    public void level3()
    {
        SceneManager.LoadSceneAsync("Level3");
    }
    public void endless()
    {
        SceneManager.LoadSceneAsync("Endless");
    }
    public void QuitGame()
    {
        Application.Quit();
    }






}
