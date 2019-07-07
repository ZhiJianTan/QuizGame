using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MathDataController : MonoBehaviour
{
    public MathRoundData[] allRoundData;
    private MathPlayerProgress playerProgress;


    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject); //Prevents objects from previous scene from getting destroyed when switching scene
        LoadPlayerProgress();
        SceneManager.LoadScene("MathMenuScreen");

    }
    

    public MathRoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }

    public void SubmitNewPlayerScore(int newScore)
    {

        if(newScore>playerProgress.highestScore)
        {
            playerProgress.highestScore = newScore;
            SavePlayerProgress();
        }
     //   else
       // {
       //   playerProgress.highestScore = 0;
     //       SavePlayerProgress();
    //    }
    }

    public int GetHighestPlayerScore()
    {

        return playerProgress.highestScore;

    }

    private void LoadPlayerProgress()
    {
        // Create a new PlayerProgress object
        playerProgress = new MathPlayerProgress();

        // If PlayerPrefs contains a key called "highestScore", set the value of playerProgress.highestScore using the value associated with that key
        if (PlayerPrefs.HasKey("mathscore"))
        {
            playerProgress.highestScore = PlayerPrefs.GetInt("mathscore");
        }
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("mathscore", playerProgress.highestScore);
    }

   public void ResetPlayerProgress()
    {
        PlayerPrefs.SetInt("mathscore", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}