using UnityEngine;

public class MapController : MonoBehaviour
{
    public void StartEnglishQuiz()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Persistent");
    }
    public void StartMathQuiz()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MathPersistant");
    }

    public void StartScienceQuiz()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SainsPersistent");
    }

    public void backMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
