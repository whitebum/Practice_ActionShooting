using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIResultPanel : MonoBehaviour
{
    public Text scoreText;

    /// <summary>
    /// 플레이어 결과 창
    /// </summary>
    /// <param name="victory">승리 : true, 패배 : false</param>
    public void OpenPanel(bool victory)
    {
        gameObject.SetActive(true);

        if (victory)
        {
            // 점수를 계산 후 스코어에 표시
            int totalScore = GameManager.Instance.Score - (int)(GameManager.Instance.gameTimer * 50);

            if (totalScore < 0) { totalScore = 0; }

            scoreText.text = totalScore.ToString();
        }

        else
            scoreText.text = "DIED";
    }

    public void ExitGame()
    {
        Debug.Log("게임 종료");
        SceneManager.LoadScene("Title");
    }
}
