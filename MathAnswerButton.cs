using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathAnswerButton : MonoBehaviour
{

    public Text answerText;
    private MathGameController gameController;
    private MathAnswerData answerData;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<MathGameController>();
    }

    public void Setup(MathAnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }

    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}
