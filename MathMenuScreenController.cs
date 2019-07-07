using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MathMenuScreenController : MonoBehaviour
{
    private MathDataController dataController;
    public Text highscore;
    void Start()
    {
        dataController = FindObjectOfType<MathDataController>();
        // highScoreDisplay.text = "hello";

        if (dataController.GetHighestPlayerScore() == null)
        {
            highscore.text = "Highscore : 0";
        }
        else
        {
            highscore.text = "Highscore : "+dataController.GetHighestPlayerScore().ToString();
        }
    }
    

    public void StartGame()
    {
        SceneManager.LoadScene("MathGame");
    }

    public void MainMenuPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }

    public void resethighscore()
    {

        dataController.ResetPlayerProgress();
        highscore.text = "Highscore : 0";
    }
}