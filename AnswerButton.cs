using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnswerButton : MonoBehaviour 
{
	public Text answerText;

	private GameController EnglishgameController;
	private AnswerData answerData;

	void Start()
	{
		EnglishgameController = FindObjectOfType<GameController>();
	}

	public void SetUp(AnswerData data)
	{
		answerData = data;
		answerText.text = answerData.answerText;
	}

	public void HandleClick()
	{
		EnglishgameController.AnswerButtonClicked(answerData.isCorrect);
	}
}
