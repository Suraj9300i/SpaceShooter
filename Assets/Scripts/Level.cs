using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;
    public void LoadStartMenu()
    {
        FindObjectOfType<GameSession>().resetGame();
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadGamePlay()
    { 
        SceneManager.LoadScene("GamePlay");
        FindObjectOfType<GameSession>().resetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }


    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadQuitMenu()
    {
        Application.Quit();
    }
}
