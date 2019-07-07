using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetScore : MonoBehaviour
{
    private void Resetscore()
    {
        PlayerPrefs.SetInt("highestScore", 0);
    }


}
