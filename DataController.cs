using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour 
{
	public RoundData[] allRoundData;

    private PlayerProgress playerProgress;
    private int highscore;
	
	void Start ()  
	{
		DontDestroyOnLoad (gameObject);
        LoadPlayerProgress(); //Loads in high score from previous sessions

		SceneManager.LoadScene ("MenuScreen");
	}
	
	public RoundData GetCurrentRoundData()
	{
		return allRoundData [0];
	}

    public void SubmitNewPlayerScore(int newScore) //used for checkking if the submitted score at the end of the round is higher than highscore
    {
        highscore = playerProgress.highestScore = PlayerPrefs.GetInt("highestScore1");
        if (newScore > highscore)
        {
            playerProgress.highestScore = newScore;
            SavePlayerProgress();
        }
    }

    public int GetHighestPlayerScore() //retrieve highest score
    {
        return playerProgress.highestScore = PlayerPrefs.GetInt("highestScore1");
    }
    private void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();

        if (PlayerPrefs.HasKey("highestScore1")) //if there is a high score set in previous section
        {
            playerProgress.highestScore = PlayerPrefs.GetInt("highestScore1"); //retrieve the score as an int
        }
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highestScore1", playerProgress.highestScore); // used for saving score into playerprefs
    }

   
}