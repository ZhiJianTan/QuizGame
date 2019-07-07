using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScienceAnswerButton : MonoBehaviour 
{
	public Text answerText;

	private ScienceGameController gameController;
	private ScienceAnswerData answerData;

	void Start()
	{
		gameController = FindObjectOfType<ScienceGameController>();
	}

	public void SetUp(ScienceAnswerData data)
	{
		answerData = data;
		answerText.text = answerData.answerText;
	}

	public void HandleClick()
	{
		gameController.AnswerButtonClicked(answerData.isCorrect);
	}
}
