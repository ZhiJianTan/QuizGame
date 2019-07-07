using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class ScienceDataController : MonoBehaviour 
{
	private ScienceRoundData[] allRoundData;

    private SciencePlayerProgress playerProgress;
    private string gameDataFileName = "data.json";

	
	void Start ()  
	{
		DontDestroyOnLoad (gameObject);
		LoadGameData();
        LoadPlayerProgress();

		SceneManager.LoadScene ("ScienceMenuScreen");
	}
	
	public ScienceRoundData GetCurrentRoundData()
	{
		return allRoundData [0];
	}

    public void SubmitNewPlayerScore(int newScore)
    {
        if (newScore > playerProgress.highestScore)
        {
            playerProgress.highestScore = newScore;
            SavePlayerProgress();
        }
    }

    public void SubmitCurrentPlayerScore(int newScore)
    {
        playerProgress.currentScore = newScore;
    }

    public int GetCurrentScore()
    {
        return playerProgress.currentScore;
    }

    public int GetHighestPlayerScore()
    {
        return playerProgress.highestScore;
    }

    private void LoadPlayerProgress()
    {
        playerProgress = new SciencePlayerProgress();

        if (PlayerPrefs.HasKey("highestScore"))
        {
            playerProgress.highestScore = PlayerPrefs.GetInt("highestScore");
        }
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highestScore", playerProgress.highestScore);
    }

    private void LoadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            ScienceGameData loadedData = JsonUtility.FromJson<ScienceGameData>(dataAsJson);

            allRoundData = loadedData.allRoundData;
        }
        else
        {
            Debug.LogError("Cannot load game data");
        }
    }

}