using UnityEngine;

public class ScienceMenuScreenController : MonoBehaviour
{
	public void StartGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("ScienceGame");
	}
}