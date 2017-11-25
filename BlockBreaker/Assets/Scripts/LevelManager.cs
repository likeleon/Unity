using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.BreakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
