using UnityEngine;

public class MenuScreenController : MonoBehaviour
{
	public void StartGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

    public void Resetscore()
    {
        PlayerPrefs.SetInt("highestScore", 0);
        PlayerPrefs.SetInt("mathscore", 0);
        PlayerPrefs.SetInt("highestScore1", 0);
    }

    public void ResetEnglishScore()
    {
        PlayerPrefs.SetInt("highestScore1", 0);
    }

    public void MainMenuPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }

    public void MainMenuScore()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Score");
    }
}