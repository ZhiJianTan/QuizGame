using UnityEngine;
using System.Collections;

[System.Serializable]
public class MathRoundData
{
    public string name;
    public int timeLimitInSeconds;
    public int pointsAddedForCorrectAnswer;
    public MathQuestionData[] questions;

}