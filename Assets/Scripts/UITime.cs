using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITime : MonoBehaviour
{
    public Text timeText;

    private void Update()
    {
        float time = GameManager.Instance.gameTimer;
        int minute = (int)time / 60;
        int second = (int)time % 60;

        timeText.text = $"TIME : [{minute.ToString("00")} : {second.ToString("00")}]";
    }
}
