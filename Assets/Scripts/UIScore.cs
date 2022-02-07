using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public Text ScoreText;

    private void Update()
    {
        ScoreText.text = $"SCORE : [{GameManager.Instance.Score}]";
    }
}
