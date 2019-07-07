using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MathGameController : MonoBehaviour
{


    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;

    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public Text highScoreDisplay;

    private MathDataController dataController;
    private MathRoundData currentRoundData;
    private MathQuestionData[] questionPool;

    private bool isRoundActive = false;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>(); //List allows dynamic sizing easily.

    // Use this for initialization
    void Start()
    {
        dataController = FindObjectOfType<MathDataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();
        highScoreDisplay.text = "Highscore: " + dataController.GetHighestPlayerScore().ToString();
        playerScore = 0;
        questionIndex = 0;

        ShowQuestion();
        isRoundActive = true;
       
    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        MathQuestionData questionData = questionPool[questionIndex]; //Hold data on current question displayed
        questionDisplayText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject(); //used to get buttons that is unused
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent); //Puts the panel as the parent of buttons

            MathAnswerButton answerButton = answerButtonGameObject.GetComponent<MathAnswerButton>(); //get reference to aAnswerbutton script linked to Answerbutton
            answerButton.Setup(questionData.answers[i]); // pass over to AnswerButton script for it to set relevant answers on button
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]); //Send back to object pool to be reused
            answerButtonGameObjects.RemoveAt(0); //remove it from list of active game objects
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
        }

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

    public void EndRound()
    {
        isRoundActive = false;
        playerScore += currentRoundData.timeLimitInSeconds;
        dataController.SubmitNewPlayerScore(playerScore);
        highScoreDisplay.text = "Highscore: " + dataController.GetHighestPlayerScore ().ToString();


        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MathMenuScreen");
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString(); //convert time remaining to string, round it and add it to "Time: "
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime; //Decrease time
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                EndRound();
            }

        }
    }
}