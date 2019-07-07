using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public SimpleObjectPool answerButtonObjectPool;
	public Text questionText;
	public Text scoreDisplay;
	public Text timeRemainingDisplay;
	public Transform answerButtonParent;

	public GameObject questionDisplay;
	public GameObject roundEndDisplay;
	public Text highScoreDisplay;

	private DataController dataController;
	private RoundData currentRoundData;
	private QuestionData[] questionPool;

	private bool isRoundActive = false;
	private float timeRemaining;
	private int playerScore;
	private int questionIndex;
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();

	void Start()
	{
        // Store a reference to the DataController so we can request the data we need for this round
        dataController = FindObjectOfType<DataController>();    
        // Ask the DataController for the data for the current round. 
        currentRoundData = dataController.GetCurrentRoundData();
        // Take a copy of the questions so we could shuffle the pool or drop questions from it without affecting the original
        questionPool = currentRoundData.questions;

        // Set the time limit for this round based on the RoundData object
        timeRemaining = currentRoundData.timeLimitInSeconds;
		UpdateTimeRemainingDisplay();
		playerScore = 0;
		questionIndex = 0;

		ShowQuestion();
		isRoundActive = true;
	}

	void Update()
	{
		if (isRoundActive)
		{
            // If the round is active, subtract the time since Update() was last called from timeRemaining
            timeRemaining -= Time.deltaTime;	
			UpdateTimeRemainingDisplay();

            // If timeRemaining is 0 or less, the round ends
            if (timeRemaining <= 0f)	
			{
				EndRound();
			}
		}
	}

	void ShowQuestion()
	{

		RemoveAnswerButtons();
        // Get the QuestionData for the current question
        QuestionData questionData = questionPool[questionIndex];
        // Update questionText with the correct text
        questionText.text = questionData.questionText;

        // For every AnswerData in the current QuestionData...
        for (int i = 0; i < questionData.answers.Length; i ++)								
		{
            // Spawn AnswerButton from the object pool
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();			
			answerButtonGameObjects.Add(answerButtonGameObject);
			answerButtonGameObject.transform.SetParent(answerButtonParent);
			answerButtonGameObject.transform.localScale = Vector3.one;

			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            // Pass the AnswerData to the AnswerButton
            answerButton.SetUp(questionData.answers[i]);									
		}
	}

	void RemoveAnswerButtons()
	{
		while (answerButtonGameObjects.Count > 0)											
		{
            // Return all spawned AnswerButtons to the object pool
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
			answerButtonGameObjects.RemoveAt(0);
		}
	}
	public void AnswerButtonClicked(bool isCorrect)
	{
		if (isCorrect)
		{
            // If the AnswerButton that was clicked was the correct answer, add points
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;					
			scoreDisplay.text = playerScore.ToString();
		}

        // If there are more questions, show the next question
        if (questionPool.Length > questionIndex + 1)											
		{
			questionIndex++;
			ShowQuestion();
		}
		else																				
		{
			EndRound();
		}
	}
	private void UpdateTimeRemainingDisplay()
	{
		timeRemainingDisplay.text = Mathf.Round(timeRemaining).ToString();
	}

	public void EndRound()
	{
		isRoundActive = false;
        playerScore += currentRoundData.timeLimitInSeconds;
        dataController.SubmitNewPlayerScore(playerScore);
        highScoreDisplay.text = dataController.GetHighestPlayerScore().ToString(); //Convert score retrieved to string and display


		questionDisplay.SetActive(false);
		roundEndDisplay.SetActive(true);
	}

	public void ReturnToMenu()
	{
		SceneManager.LoadScene("MenuScreen");
	}
}