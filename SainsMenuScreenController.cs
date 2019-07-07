using UnityEngine;

public class SainsMenuScreenController : MonoBehaviour
{
	public void StartGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("SainsGame");

	}
    public void MainMenuPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }
}