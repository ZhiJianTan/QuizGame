using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SainsAnswerButton : MonoBehaviour 
{
	public Text answerText;

	private SainsGameController sainsgameController;
	private SainsAnswerData answerData;

	void Start()
	{
		sainsgameController = FindObjectOfType<SainsGameController>();
	}

	public void SetUp(SainsAnswerData data)
	{
		answerData = data;
		answerText.text = answerData.answerText;
	}

	public void HandleClick()
	{
		sainsgameController.AnswerButtonClicked(answerData.isCorrect);
	}
}
